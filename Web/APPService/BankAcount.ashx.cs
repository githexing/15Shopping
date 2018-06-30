using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// BankAcount 的摘要说明
    /// </summary>
    public class BankAcount : ServiceHandler
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
                case "addbank"://添加银行卡
                    result = AddBank(context);
                    break;
                case "banklist"://银行卡列表
                    result = BankLists(context);
                    break;
                case "addwxalipay"://绑定微信,支付宝
                    result = PayWeChat(context);
                    break;
                case "cancelbank"://绑定微信,支付宝
                    result = CancelBank(context);
                    break;
                case "banktypelist"://银行类别
                    result = BindBankList(context);
                    break;
                case "addbagaddress"://钱包地址
                    result = AddBagAddress(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常.", "BankAcount");
                    break;
            }
            context.Response.Write(result);
        }
        //添加银行
        private string AddBank(HttpContext context)
        {

            string userid = context.Request["userid"] ?? "";
            string bankname = context.Request["bankname"] ?? "";
            string bankaccount = context.Request["bankaccount"] ?? "";
            string bankuser = context.Request["bankuser"] ?? "";
            string defaults = context.Request["defaults"] ?? "";

            string strpaypwd = context.Request["paypwd"] ?? "";
            string fromwhere = context.Request["fromwhere"] ?? "";
            string message = string.Empty;
            long _userid = 0;
            if (string.IsNullOrEmpty(bankname))
            {
                return ResultJson(ResultType.error, "请输入银行卡名称", "");
            }
            if (string.IsNullOrEmpty(bankaccount))
            {
                return ResultJson(ResultType.error, "请输入银行账号", "");
            }
            if (string.IsNullOrEmpty(bankuser))
            {
                return ResultJson(ResultType.error, "请输入持卡人姓名", "");
            }
            if (defaults == "") defaults = "0";

            //LogHelper.SaveLog(string.Format("userid:{0},bankname{1},bankaccount:{2},bankuser:{3},defaults:{4}", userid, bankname, bankaccount, bankuser, defaults),"debug_Addbank");

            long.TryParse(userid, out _userid);
            BankAcountService svc = new BankAcountService();
            var result = svc.Bank(_userid, bankname, bankaccount, bankuser, defaults, strpaypwd, fromwhere, out message);
            if (result)
            {
                if(fromwhere == "pc")
                {
                    List<BankModel> list = svc.BankList(_userid).OrderByDescending(b => b.BankID).ToList();
                    return ResultJson(ResultType.success, "添加成功", list);
                }
                else 
                    return ResultJson(ResultType.success, "添加成功", "");
            }
            else
            {
                return ResultJson(ResultType.error, message, "");
            }
        }
        //银行卡列表
        private string BankLists(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string message = string.Empty;
            long _userid = 0;
            long.TryParse(userid, out _userid);
            BankAcountService svc = new BankAcountService();
            List<BankModel> list = svc.BankList(_userid);

            return ResultJson(ResultType.success, message, list);
        }
        //绑定微信,支付宝
        private string PayWeChat(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string nickname = context.Request["nickname"] ?? "";
            string accounts = context.Request["accounts"] ?? "";
            string type = context.Request["type"] ?? "";
            string defaults = context.Request["defaults"] ?? "";

            string strpaypwd = context.Request["paypwd"] ?? "";
            string fromwhere = context.Request["fromwhere"] ?? "";
            string message = string.Empty;
            int _userid = 0;

            if (string.IsNullOrEmpty(type))
            {
                return ResultJson(ResultType.error, "请输入绑定类型", "");
            }
            if (!(type == "2" || type == "3"))
            {
                return ResultJson(ResultType.error, "绑定类型错误", "");
            }

            int.TryParse(userid, out _userid);
            string path;
            upload(context, "bank", out path);

            BankAcountService svc = new BankAcountService();

            var result = svc.AlipayWeixin(_userid, nickname, accounts, type, defaults, path, strpaypwd, fromwhere, out message);
            if (result)
            {
                if (fromwhere == "pc")
                {
                    List<BankModel> list = svc.BankList(_userid);
                    return ResultJson(ResultType.success, "绑定成功", list);
                }
                else
                    return ResultJson(ResultType.success, "绑定成功", "");
            }
            else
                return ResultJson(ResultType.error, "绑定失败", "");
        }
        //取消银行卡
        private string CancelBank(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string bankid = context.Request["bankid"] ?? "";


            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }

            if (string.IsNullOrEmpty(bankid))
            {
                return ResultJson(ResultType.error, "请输入银行卡ID", "");
            }


            string message = string.Empty;
            int _userid = 0;
            int _bankid = 0;
            int.TryParse(userid, out _userid);
            int.TryParse(bankid, out _bankid);
            var tsvc = new BankAcountService();
            var result = tsvc.BankCard(_userid, _bankid, out message);
            if (result)
            {
                return ResultJson(ResultType.success, "删除成功", "");
            }
            else
                return ResultJson(ResultType.error, message, "");
        }

        /// <summary>
        /// 银行类别
        /// </summary>
        /// <returns></returns>
        public string BindBankList(HttpContext context)
        {
            string struserid = context.Request["userid"] ?? "";

            #region 用户ID
            long userid = 0;
            if (string.IsNullOrEmpty(struserid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!long.TryParse(struserid, out userid))
            {
                return ResultJson(ResultType.error, "请输入有效的用户ID", "");
            }
            #endregion

            var tsvc = new BankAcountService();
            BankTypeListModel model = tsvc.GetBankTypeList(userid);
            return ResultJson(ResultType.success, "绑定类别", model);
        }
        //添加钱包地址
        private string AddBagAddress(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string accountname = context.Request["accountname"] ?? "";
            string accounts = context.Request["accounts"] ?? "";

            string defaults = context.Request["defaults"] ?? "";

            string strpaypwd = context.Request["paypwd"] ?? "";
            string fromwhere = context.Request["fromwhere"] ?? "";
            string message = string.Empty;
            int _userid = userid.ToInt();

            BankAcountService svc = new BankAcountService();

            var result = svc.BagAddress(_userid, accountname, accounts,  defaults,  strpaypwd, fromwhere, out message);
            if (result)
            {
                if (fromwhere == "pc")
                {
                    //List<BankModel> list = svc.BankList(_userid);
                    List<BankModel> list = new List<BankModel>();
                    return ResultJson(ResultType.success, "绑定成功", list);
                }
                else
                    return ResultJson(ResultType.success, "绑定成功", "");
            }
            else
                return ResultJson(ResultType.error, "绑定失败", "");
        }
    }
}