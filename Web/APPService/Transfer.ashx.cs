using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// Transfer 的摘要说明
    /// </summary>
    public class Transfer : ServiceHandler
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
                case "transfer"://转账
                    result = TransferTo(context);
                    break;
                case "transferlist"://转账
                    result = TransferList(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常", "transfer");
                    break;
            }
            context.Response.Write(result);
        }
        //转账给会员
        private string TransferTo(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string tousercode = context.Request["tousercode"] ?? "";
            string money = context.Request["money"] ?? "0";
            string transtype = context.Request["transtype"] ?? "";
            string phone = context.Request["phone"] ?? "";
            string paypassword = context.Request["paypassword"] ?? "";
            string message = string.Empty;

            if (string.IsNullOrEmpty(transtype))
            {
                return ResultJson(ResultType.error, "请选择转账类型", "");
            }
            
            if (string.IsNullOrEmpty(paypassword))
            {
                return ResultJson(ResultType.error, "请输入支付密码", "");
            }
            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (string.IsNullOrEmpty(tousercode))
            {
                return ResultJson(ResultType.error, "请输入转账用户名", "");
            }
            if (string.IsNullOrEmpty(money))
            {
                return ResultJson(ResultType.error, "请输入转账金额", "");
            }
            //if (string.IsNullOrEmpty(phone))
            //{
            //    return ResultJson(ResultType.error, "请输入手机号码", "");
            //}
            long _userid;
            long.TryParse(userid, out _userid);
            var tsvc = new TransferService();
            var result = tsvc.Transfer(_userid, tousercode, money, transtype, phone, paypassword.ToUpper(), out message);
            if (result)
            {
                return ResultJson(ResultType.success, "转账成功", "");
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
        //转账记录
        private string TransferList(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string transtype = context.Request["transtype"] ?? "";

            LogHelper.SaveLog(string.Format("TransferList ==> userid:{0},transtype:{1}", userid,transtype), "Transfer");
            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            string message = string.Empty;
            TransferService svc = new TransferService();
            int _userid = 0;

            int.TryParse(userid, out _userid);
            List<TransferModel> list;
            //if(string.IsNullOrEmpty(transtype))
            //    list = svc.TransferModelList(_userid).Where(s=>s.ChangeType.Equals("1") || s.ChangeType.Equals("2")).OrderByDescending(s=>s.ChangeDate).ToList();
            if(transtype == "2")
            {
                list = svc.TransferModelList(_userid).Where(s => s.ChangeType.Equals("2") || s.ChangeType.Equals("3")).OrderByDescending(s => s.ChangeDate).ToList();
            }
            else
                list = svc.TransferModelList(_userid).Where(s=>s.ChangeType.Equals(transtype)).OrderByDescending(s => s.ChangeDate).ToList();

            return ResultJson(ResultType.success, message, list);
        }
    }
}