using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;
using Web.APPService.ViewModel;

namespace Web.APPService
{
    /// <summary>
    /// TakeMoney 的摘要说明
    /// </summary>
    public class TakeMoney : ServiceHandler
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
                case "take"://会员提现
                    result = TakeMoneyAccount(context);
                    break;
                case "list"://会员提现记录
                    result = TakeMember(context);
                    break;
                case "cancel"://取消会员提现
                    result = TakeCancellation(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常", "");
                    break;
            }
            context.Response.Write(result);
        }

        //会员提现
        private string TakeMoneyAccount(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string currency = context.Request["currency"] ?? "";
            string money = context.Request["money"] ?? "";
            string bankid = context.Request["bankid"] ?? "";
            string paypassword = context.Request["paypassword"] ?? "";
            string message = string.Empty;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (string.IsNullOrEmpty(currency))
            {
                return ResultJson(ResultType.error, "请选择币种", "");
            }
            if (string.IsNullOrEmpty(money))
            {
                return ResultJson(ResultType.error, "请输入提现金额", "");
            }
            if (string.IsNullOrEmpty(bankid))
            {
                return ResultJson(ResultType.error, "请输入提现ID", "");
            }
            if (string.IsNullOrEmpty(paypassword))
            {
                return ResultJson(ResultType.error, "请输入支付密码", "");
            }
            int _userid = 0;
           
            int.TryParse(userid, out _userid);
            var tsvc = new TakeMoneyService();
            var result = tsvc.TakeMoney(_userid, currency, money, bankid, paypassword.ToUpper(), out message);
            if (result)
            {
                return ResultJson(ResultType.success, "提现成功", "");
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
        //会员提现记录
        private string TakeMember(HttpContext context)
        {
            string id = context.Request["userid"] ?? "";
            string type = context.Request["type"] ?? "";//0:申请提现，1：已提现
            if (string.IsNullOrEmpty(id))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            string message = string.Empty;
            TakeMoneyService svc = new TakeMoneyService();
            int _userid = id.ToInt();
            
            LogHelper.SaveLog(string.Format("TakeMember > userid:{0},type:{1}", _userid,type), "takemoney");

            List<TakeMoneyModel> list = svc.TakeModelList(_userid.ToString()).Where(s => s.Flag == type).OrderByDescending(o=>o.TakeTime).ToList();

            return ResultJson(ResultType.success, message, list);
        }
        //取消会员提现
        private string TakeCancellation(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string txid = context.Request["takeid"] ?? "";
            string paypassword = context.Request["paypassword"] ?? "";

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }

            if (string.IsNullOrEmpty(txid))
            {
                return ResultJson(ResultType.error, "请输入提现ID", "");
            }

            if (string.IsNullOrEmpty(paypassword))
            {
                return ResultJson(ResultType.error, "请输入支付密码", "");
            }

            string message = string.Empty;
            int _userid = 0;
            int _txid = 0;
            int.TryParse(userid, out _userid);
            int.TryParse(txid, out _txid);
            var tsvc = new TakeMoneyService();
            var result = tsvc.ItemCommand(_userid, _txid, paypassword.ToUpper(), out message);
            if (result)
            {
                return ResultJson(ResultType.success, "取消提现成功", "");
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
        }
}