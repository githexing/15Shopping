using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// Log 的摘要说明
    /// </summary>
    public class Log : ServiceHandler
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
                case "app"://记录
                    result = Record(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常", "Invest");
                    break;
            }
            context.Response.Write(result);
        }
        //经纬度，mac，手机版本，手机品牌，手机系统
        private string Record(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string longitude = context.Request["longitude"] ?? "";//经纬度
            string mac = context.Request["mac"] ?? "";//mac
            string version = context.Request["version"] ?? ""; //手机版本
            string brand = context.Request["brand"] ?? ""; //手机品牌
            string system = context.Request["system"] ?? ""; //手机系统
            
            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            
            long _userid = 0;
            long.TryParse(userid, out _userid);
            LogService svc = new LogService();
            svc.Record(_userid, longitude, mac, version, brand, system);

            return ResultJson(ResultType.success, "ok", "");
        }
    }
}