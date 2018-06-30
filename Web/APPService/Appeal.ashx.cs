using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// Appeal 的摘要说明
    /// </summary>
    public class Appeal : ServiceHandler
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
                case "put"://申诉
                    result = AppealContent(context);
                    break;
                case "list"://申诉记录
                    result = AppealList(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常.", "Account");
                    break;
            }
            context.Response.Write(result);
        
    }

        private string AppealList(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string type = context.Request["type"] ?? "";
            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            long _userid = 0;
            int _type = 0;
            long.TryParse(userid, out _userid);
            int.TryParse(type, out _type);

            AppealServic svc = new AppealServic();
            var list = svc.AppealList(_userid, _type);
            return ResultJson(ResultType.success, "获取成功", list);
        }

        private string AppealContent(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string content = context.Request["content"] ?? "";
            string type = context.Request["type"] ?? "";//申诉类别 1：充值，2：提现
            string message = string.Empty;
            if (string.IsNullOrEmpty(content))
            {
                return ResultJson(ResultType.error, "请输入申诉内容", "");
            }
            if (string.IsNullOrEmpty(type))
            {
                return ResultJson(ResultType.error, "申诉类别不能为空", "");
            }
            long _userid = 0;
            int _type = 0;
            long.TryParse(userid, out _userid);
            int.TryParse(type, out _type);

            string picpath;
            upload(context,"appeal",out picpath);

            AppealServic svc = new AppealServic();
            var result = svc.Appeal(_userid, _type, content, picpath, out message);
            if (result)
            {
                return ResultJson(ResultType.success, "申诉成功", "");
            }
            else
                return ResultJson(ResultType.error, "申诉失败", "");
        }

        }
}