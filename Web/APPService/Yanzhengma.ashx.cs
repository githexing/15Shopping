using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.SessionState;

namespace Web.APPService
{
    /// <summary>
    /// Yanzhengma 的摘要说明
    /// </summary>
    public class Yanzhengma : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string result = "error";
            string message = "手机号输入错误！";
            string dates = "";
            string phone = context.Request["phone"];
            string YZM = context.Request["YZM"];
            string Type = context.Request["Type"];//0注册 1登陆

            string a = context.Session["CheckCode"]==null ? " ": context.Session["CheckCode"].ToString();
            if (a=="")
            {
                message = "验证码已过期！";
                SendResponse(context, result, message, dates);
            }
            if (YZM!= a)
            { 
                message = "验证码错误,请输入正确的验证码！";
                SendResponse(context, result, message, dates);
            }

            //if (phone.Length!=11)
            //{
            //    SendResponse(context, result, message, dates);
            //}

            AllCore AC = new AllCore();
            var User=  AC.userBLL.GetModelByPhoneNum(phone);//不存在的情况， 可以注册， 存在那就对比
            if (User!=null && Type=="1")
            {
                if (AC.smsBLL.GetSendCountOfDay(phone) >= 5) //同号码每日限制：5条 
                {
                    message = "超出短信发送计数限制";
                    SendResponse(context, result, message, dates);
                    return;
                }
                if (AC.smsBLL.GetSendCountOfMinute(phone, 1) >= 1) //同号码每分钟限制：1条
                {
                    message = "操作过于频繁，请稍后重试";
                    SendResponse(context, result, message, dates);
                    return;
                }

                string regSwitch = ConfigurationManager.AppSettings["SMS_SWITCH"];//注册短信开关
                if (regSwitch.Equals("Open"))
                {


                    //------------------验证码//

                    lgk.Model.SMS model = new lgk.Model.SMS();
                    model.IsDeleted = 0;
                    model.IsValid = 0;
                    model.PublishTime = DateTime.Now;
                    model.SCode = new Library.Common().GetRandom(6);
                    model.ToPhone = phone;
                    model.SMSContent = model.SCode;
                    model.SendNum = 1;
                    model.ToUserCode = "";
                    model.ValidTime = DateTime.Now.AddMinutes(5);
                    model.TypeID = 2;

                    long isid = AC.smsBLL.Add(model);
                    if (isid > 0)
                    {
                        //msg = "验证码已发送";
                        string strreturn = Library.SMSHelper.SendMessage2(phone, model.SCode);
                        if (strreturn == "0")
                        {
                            result = "success";
                            message = "发送成功请注意查看手机短信";

                        }
                        else
                        {
                            AC.smsBLL.UpdateDelete(isid, -1);
                            message = "发送失败";


                        }
                    }
                    else
                    {
                        message = "验证码发送失败";

                    }

                }
                else
                {
                    message = "短信接口已经关闭";
                }
                SendResponse(context, result, message, dates);
            }
            else if(Type == "0")//注册
            {
                if(User != null )
                {
                    message = "该手机号已注册";
                    SendResponse(context, result, message, dates);
                    return;
                }
                string regSwitch = ConfigurationManager.AppSettings["SMS_SWITCH"];//注册短信开关
                if (regSwitch.Equals("Open"))
                {
                    //------------------验证码//
                    #region 短信验证码
                    lgk.Model.SMS model = new lgk.Model.SMS();
                    model.IsDeleted = 0;
                    model.IsValid = 0;
                    model.PublishTime = DateTime.Now;
                    model.SCode = new Library.Common().GetRandom(6);
                    model.ToPhone = phone;
                    model.SMSContent = model.SCode;
                    model.SendNum = 1;
                    model.ToUserCode = "";
                    model.ValidTime = DateTime.Now.AddMinutes(5);
                    model.TypeID = 1; 
                    #endregion

                    long isid = AC.smsBLL.Add(model);
                    if (isid > 0)
                    {
                        string strreturn = Library.SMSHelper.SendMessage2(phone, model.SCode);
                        if (strreturn == "0")
                        {
                            result = "success";
                            message = "发送成功请注意查看手机短信";
                        }
                        else
                        {
                            AC.smsBLL.UpdateDelete(isid, -1);
                            message = "发送失败";
                        }
                    }
                    else
                    {
                        message = "验证码发送失败";
                    }

                }
                else
                {
                    message = "短信接口已经关闭";
                }
                SendResponse(context, result, message, dates);
            }

            SendResponse(context, result, message, dates);
        }

        private void SendResponse(HttpContext context, string result, string returnString, string dates)
        {
            context.Response.Clear();
            string json = "{\"state\":\"" + result.ToString() + "\",\"message\":\"" + returnString + "\",\"data\":{" + dates + "}}";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.Serialize(json);
            context.Response.Write(json);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}