using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Quartz;
using System.Text;
using Library;
//using Web.sync;

/// <summary>
/// 实现了IJob接口的类，功能是配合InsertKeyWordsAuto类实现定时触发向数据库插入搜索关键字次数
/// </summary>
public class DoIJob : IJob
{
    private Web.RegexR regx = new Web.RegexR();
    private static int tn = 0;
    public void Execute(IJobExecutionContext context)
    {
        try
        {
            lgk.BLL.SMS ruleLock = new lgk.BLL.SMS();
            lock (ruleLock)
            {
                DataSet ds = ruleLock.GetList(1," IsValid=1 and IsDeleted=0 and SendNum<2 "," ID ");
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    List<lgk.Model.SMS> SMSList = ruleLock.DataTableToList(ds.Tables[0]);
                    foreach (lgk.Model.SMS smsModel in SMSList)
                    {
                        long phoneNum = regx.PhoneNum(smsModel.ToPhone);
                        try
                        {
                            if (smsModel.ValidTime>DateTime.Now)
                            {
                                //短信有效期已过
                                smsModel.IsValid = 0;
                                ruleLock.Update(smsModel);
                            }
                            int SmsTempType = smsModel.TypeID;
                            string flag = Library.SMSHelper.SendMessage2(phoneNum.ToString(),smsModel.SMSContent);
                            if (phoneNum > 0 && flag == "0")
                            {
                                smsModel.IsValid = 0;
                                Library.LogHelper.SaveLog("发送短信成功！" + phoneNum, "SMS");
                            }
                            else
                            {
                                Library.LogHelper.SaveLog("发送短信失败！" + phoneNum + "," + flag, "SMS");
                            }
                        }
                        catch (Exception ex)
                        {
                            Library.LogHelper.SaveLog("短信发送错误！" + phoneNum + "(" + ex.Message + ")", "SMS");
                        }
                        finally
                        {
                            smsModel.SendNum += 1;
                            StringBuilder UpSmsSql = new StringBuilder();
                            UpSmsSql.Append(" update SMS ");
                            UpSmsSql.AppendFormat(" Set SendNum+=1,IsValid={0} ", smsModel.IsValid);
                            UpSmsSql.AppendFormat(" where ToPhone='{0}' and SMSContent='{1}' ", phoneNum, smsModel.SMSContent);
                            UpSmsSql.AppendFormat(" and DATEADD(MM,-1,CONVERT(datetime,'{0}',101))<= PublishTime and DATEADD(MM,1,CONVERT(datetime,'{1}',101))>=PublishTime ", smsModel.PublishTime.ToString(), smsModel.PublishTime.ToString());
                            //UpSmsSql.Append(" and IsValid=1 and IsDeleted=0 ");
  
                            int n = DataAccess.DbHelperSQL.ExecuteSql(UpSmsSql.ToString());
                            if (n>0)
                            {
                                Library.LogHelper.SaveLog("短信状态更新成功！" + phoneNum, "SMS");
                            }
                            else
                            {
                                Library.LogHelper.SaveLog("短信状态更新失败！" + phoneNum, "SMS");
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //ISchedulerFactory sf = new Quartz.Impl.StdSchedulerFactory();
            //IScheduler sched = sf.GetScheduler();
            //sched.DeleteJob(new JobKey("job1", "group1"));
            Library.LogHelper.SaveLog("发送短信失败，停止运行作业！" + ex.StackTrace, "SMSErr");
        }
    }

}