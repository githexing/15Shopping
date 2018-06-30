using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Data;
using Web.APPService.Service;
using Web.APPService.ViewModel;

namespace Web.APPService
{
    /// <summary>
    /// YuTu_Recommend 的摘要说明
    /// </summary>
    public class YunTu_SuanLiJournal : ServiceHandler
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
            string User = context.Request["UserID"];
            string Page_1 = context.Request["Page"];
            string Mumber_1 = context.Request["Mumber"];
            int Page = 0;
            int Mumber = 0;
            long UserID = 0;
            if (string.IsNullOrEmpty(User) || User.Trim() == string.Empty)
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            try
            {
                UserID = long.Parse(User);
            }
            catch (Exception)
            {
                UserID = 0;
            }
            try
            {
                Page = int.Parse(Page_1);
                Mumber = int.Parse(Mumber_1);
            }
            catch (Exception)
            {
                return ResultJson(ResultType.error, "页码错误！", "");
            }
            if (Page == 0)
            {
                Page = 1;
            }

            SuanLiJournalService svc = new SuanLiJournalService();
            SuanLiListModel model = svc.GetSuanLiJournalList(UserID, Page, Mumber);
            return ResultJson(ResultType.success, "", model);
        }
        
    }
}