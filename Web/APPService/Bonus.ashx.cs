using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// Bonus 的摘要说明
    /// </summary>
    public class Bonus : ServiceHandler
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
                case "poly"://聚元
                    result = Poly(context);
                    break;
                case "income"://达人收益
                    result = Amount(context);
                    break;
                case "richman"://富贵达人
                    result = RichMan(context);
                    break;
                case "consume"://消费积分
                    result = Consume(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常", "Bonus");
                    break;
            }
            context.Response.Write(result);
        }

        private string Poly(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string type = context.Request["type"] ?? "";//1:总量，2：已获取，3：未获取
            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (string.IsNullOrEmpty(type))
            {
                return ResultJson(ResultType.error, "请获取类别", "");
            }

            long _userid;
            int _type;
            long.TryParse(userid, out _userid);
            int.TryParse(type, out _type);

            BonusService svc = new BonusService();
            Dictionary<string, object> values = new Dictionary<string, object>();

            values.Add("phase", svc.GetPhase(_userid, _type));
            values.Add("bonus", svc.GetPolyBonus(_userid, _type));
            values.Add("salsephase", 0); //促销期数
            if (_type == 1 )
            {
                var result = svc.ShareGet(_userid);
                values.Add("list", result);
            }
            else if (_type == 2)
            {
                var result = svc.AlreadyBonusList(_userid);
                values.Add("list", result);
            }
            else if (_type == 3)
            {
                var result = svc.ShareGet(_userid);
                values.Add("list", result.Where(s=>s.Flag == 0));
            }
            return ResultJson(ResultType.success, "获取成功", values);
        }
        //达人收益
        private string Amount(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string type = context.Request["type"] ?? "";
            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (string.IsNullOrEmpty(type))
            {
                return ResultJson(ResultType.error, "请输入类别ID", "");
            }
            long _userid;
            long.TryParse(userid, out _userid);
            BonusService svc = new BonusService();
            Dictionary<string, object> values = new Dictionary<string, object>();

            values.Add("bonus", svc.GetDarenTotal(_userid));
            var result = svc.DarenBonusList(_userid);
            values.Add("list", result);
            return ResultJson(ResultType.success, "获取成功", values);
        }
        //富贵达人列表
        private string RichMan(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            long _userid;
            long.TryParse(userid, out _userid);
            BonusService svc = new BonusService();
            Dictionary<string, object> values = new Dictionary<string, object>();
            var result = svc.RichManBonusList(_userid);
            values.Add("richnumber", 0);
            values.Add("teamnumber", 0);
            values.Add("list", result);
            values.Add("isrichman", svc.IsRichMan(_userid));
            return ResultJson(ResultType.success, "获取成功", values);


        }

        //达人收益
        private string Consume(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }

            long _userid;
            long.TryParse(userid, out _userid);
            BonusService svc = new BonusService();
            Dictionary<string, object> values = new Dictionary<string, object>();

            var result = svc.ConsumeBonusList(_userid);
            values.Add("bonus", result.Sum(s=>decimal.Parse(s.Bonus)));
            values.Add("list", result);
            return ResultJson(ResultType.success, "获取成功", values);
        }
    }
}