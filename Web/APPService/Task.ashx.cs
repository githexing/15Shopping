using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// Task 的摘要说明
    /// </summary>
    public class Task : ServiceHandler
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
                case "get"://获取任务
                    result = GetTask(context);
                    break;
                case "done"://完成任务
                    result = DoneTask(context);
                    break;
                case "list"://任务列表
                    result = ListTask(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常", "Task");
                    break;
            }
            context.Response.Write(result);
        }
        //获取任务
        private string GetTask(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";

            string message = string.Empty;

            long _userid = 0;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }

            long.TryParse(userid, out _userid);
            TaskService svc = new TaskService();
            var result = svc.GetTask(_userid );

            return ResultJson(ResultType.success, "获取成功", result);
        }
        //完成任务 , 时长，完成步数，已释放
        private string DoneTask(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string taskkey = context.Request["taskkey"] ?? "";
            string timelong = context.Request["timelong"] ?? "";
            string donenum = context.Request["donenum"] ?? "";

            string message = string.Empty;

            long _userid = 0;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }

            if (string.IsNullOrEmpty(taskkey))
            {
                return ResultJson(ResultType.error, "请输入任务KEY", "");
            }

            long.TryParse(userid, out _userid);
            TaskService svc = new TaskService();
            var result = svc.DoneTask(_userid, taskkey, timelong, donenum, out message);

            if (result)
                return ResultJson(ResultType.success, message,new { text = message });

            return ResultJson(ResultType.error, message, "");

        }
        //任务列表
        private string ListTask(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";

            long _userid = 0;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }

            long.TryParse(userid, out _userid);
            TaskService svc = new TaskService();
            var result = svc.ListTask(_userid);
            
            return ResultJson(ResultType.success, "获取成功", result);
        }
    }
}