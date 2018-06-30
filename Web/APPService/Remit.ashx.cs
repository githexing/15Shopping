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
    /// Remit 的摘要说明
    /// </summary>
    public class Remit : ServiceHandler
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
                case "remit"://会员充值
                    result = MemberRemit(context);
                    break;
                case "remitlist"://会员充值列表
                    result = RemitList(context);
                    break;
                case "remitinfo"://会员充值详情
                    result = RemitInfo(context);
                    break;
                case "companyaccount"://公司账号
                    result = CompanyAccount(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常", "");
                    break;
            }
            context.Response.Write(result);
        }

        private string CompanyAccount(HttpContext context)
        {
            RemitServic svc = new RemitServic();
            List<BankModel> list = svc.BankList();

            return ResultJson(ResultType.success, "ok", list);
        }

        //会员充值
        private string MemberRemit(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string playid = context.Request["playid"] ?? "";
            string revenueid = context.Request["revenueid"] ?? "";
            string money = context.Request["money"] ?? "";
            string message = string.Empty;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (string.IsNullOrEmpty(playid))
            {
                return ResultJson(ResultType.error, "请输入打款人ID", "");
            }
            if (string.IsNullOrEmpty(revenueid))
            {
                return ResultJson(ResultType.error, "请输入收款人ID", "");
            }
            if (string.IsNullOrEmpty(money))
            {
                return ResultJson(ResultType.error, "请输入充值金额", "");
            }

            long _userid = userid.ToLong();
           
            string pictures;
            upload(context,"remit",out pictures);

            var tsvc = new RemitServic();
            var result = tsvc.Remit(_userid, playid, revenueid, money,  pictures, out message);
            if (result)
            {
                return ResultJson(ResultType.success, "申请充值成功！", "");
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
        //会员充值列表
        private string RemitList(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            string message = string.Empty;
            RemitServic svc = new RemitServic();
            int _userid = 0;
            int.TryParse(userid, out _userid);
            List<RemitModel> list = svc.ApplyRemitList(_userid).OrderByDescending(s=>s.AddDate).ToList();

            return ResultJson(ResultType.success, message, list);
        }
        //会员充值详情
        private string RemitInfo(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string remitid = context.Request["remitid"] ?? "";
            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (string.IsNullOrEmpty(remitid))
            {
                return ResultJson(ResultType.error, "请输入充值ID", "");
            }
            string message = string.Empty;
            int _userid = 0;
            int _remitid = 0;
            int.TryParse(userid, out _userid);
            int.TryParse(remitid, out _remitid);

            RemitServic svc = new RemitServic();
            var info = svc.RemitInfo(_remitid);
            var revenue = svc.BankModel(info.Remit002); //收款
            var play = svc.UserBank(info.Remit001);//打款

            var playinfo = new
            {
                play.BankName,
                play.BankAccount,
                play.BankAccountUser,
                play.BankAddress,
                AccountType = play.Bank003,
            };
            var revenueinfo = new
            {
                revenue.BankName,
                revenue.BankAccount,
                revenue.BankAccountUser,
                revenue.BankAddress,
                AccountType = revenue.BankType
            };

            var orderinfo = new
            {
                PayMoney = info.Remit006,
                info.RemitMoney,
                info.State,
                info.AddDate,
                img = WebHelper.HttpDomain + info.Remit004
            };

            SortedDictionary<string, object> values = new SortedDictionary<string, object>();
            values.Add("playinfo", playinfo);
            values.Add("revenueinfo", revenueinfo);
            values.Add("order", orderinfo);
            return ResultJson(ResultType.success, message, values);
        }
    }
}