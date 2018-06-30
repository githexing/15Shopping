using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// Index 的摘要说明
    /// </summary>
    public class Index : ServiceHandler
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
                case "main"://滚动图片
                    result = LinkUrlList(context);
                    break;

                default:
                    result = ResultJson(ResultType.error, "参数异常", "news");
                    break;
            }
            context.Response.Write(result);
        }


        //滚动图片
        private string LinkUrlList(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string message = string.Empty;
            int _userid = 0;
            int.TryParse(userid, out _userid);

            IndexService svc = new IndexService();
            NewsService newSvc = new NewsService();

            List<IndexModel> banner = svc.IndexList();
            List<NoticeModel> notice = newSvc.NoticList();
            var account = svc.Poly(_userid, out message);

            SortedDictionary<string, object> value = new SortedDictionary<string, object>();
            value.Add("banner", banner);
            value.Add("notice", notice.Select(s => new { s.NewsTitle ,s.ID,s.Publisher,s.PublishTime}));
            value.Add("account", account);
            
            return ResultJson(ResultType.success, message, value);

        }
    }
}