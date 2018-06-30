using System.Linq;
using System.Web;
using Library;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Data;
using Web.APPService.Service;
using Web.APPService.ViewModel;
using System;

namespace Web.APPService
{
    /// <summary>
    /// Pay 的摘要说明
    /// </summary>
    public class Pay : ServiceHandler
    {
       
        //static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = string.Empty;

            result = GetSuanLiList(context);
            context.Response.Write(result);
        }

        public string GetSuanLiList(HttpContext context)
        {
            //string User = context.Request["UserID"];
            string UserCode = context.Request["UserCode"];
            string Pay = context.Request["Pay"];//1 什么币  2 什么币
            string Remark = context.Request["Remark"];//备注
            string Money = context.Request["Money"];//金额
            string Key = context.Request["Key"];//key


            int Page = 0;
            int Mumber = 0;
            long UserID = 0;
            decimal jine = 0;
            if (string.IsNullOrEmpty(UserCode) || UserCode.Trim() == string.Empty)
            {
                return ResultJson(ResultType.error, "请输入用户账号", "");
            }
            AllCore AC = new AllCore();
            UserID = AC.userBLL.GetUserID(UserCode);
            if (UserID <= 0)
            {
                return ResultJson(ResultType.error, "账号不存在!", "");
            }
            if (!decimal.TryParse(Money,out jine))
            { 
                return ResultJson(ResultType.error, "金额不正确!", "");
            }
            if (jine<=0)
            {
                return ResultJson(ResultType.error, "金额不能为0!", "");
            }
            if (Pay=="1")
            {
                AC.UpdateAccount("",UserID,jine,0);
            }
            else if (Pay == "2")
            {

            }
            else
            {
                return ResultJson(ResultType.error, "支付类型错误!", "");
            }
       
            


            SuanLiJournalService svc = new SuanLiJournalService();
            SuanLiListModel model = svc.GetSuanLiJournalList(UserID, Page, Mumber);
            return ResultJson(ResultType.success, "", model);
        }

    }
}