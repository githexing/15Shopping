using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// News 的摘要说明
    /// </summary>
    public class News : ServiceHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = string.Empty;

            string act = context.Request["act"];
            if (string.IsNullOrEmpty(act) || act.Trim() == string.Empty)
            {
                return;
            }
            switch (act.ToLower())
            {
                case "news"://新闻公告
                    result = NoticeList(context);
                    break;
                case "details"://新闻详情
                    result = NoticeDetail(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常", "news");
                    break;
            }
            context.Response.Write(result);
        }

        //新闻公告
        private string NoticeList(HttpContext context)
        {
           
            string message = string.Empty;
            NewsService svc = new NewsService();
            List<NoticeModel> list = svc.NoticList();

            return ResultJson(ResultType.success, message, list);
        }
        //新闻详情
        private string NoticeDetail(HttpContext context)
        {
            string userid = context.Request["id"] ?? "";
            string message = string.Empty;
            NewsService svc = new NewsService();
            int _userid = 0;

            int.TryParse(userid, out _userid);
            NoticeModel detail = svc.NoticeDetail(_userid);

            return ResultJson(ResultType.success, message, detail);
        }
    }
}