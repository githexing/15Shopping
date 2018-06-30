using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// Account 的摘要说明
    /// </summary>
    public class Account : ServiceHandler
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
                case "wallet"://我的资产
                    result = GetAccountInfo(context);
                    break;
                case "asset"://我的钱包
                    result = GetAssetInfo(context);
                    break;
                case "list"://账户明细
                    result = GetAccountList(context);
                    break;
                case "balance"://账户余额
                    result = GetAccountBalance(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常.", "Account");
                    break;
            }
            context.Response.Write(result);
        }

        private string GetAssetInfo(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            object info = string.Empty;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            int _userid = 0;
            int.TryParse(userid, out _userid);

            AccountService svc = new AccountService();
            var result = svc.AssetInfo(_userid, out info);
            if (result)
            {
                return ResultJson(ResultType.success, "获取成功", info);
            }
            else
                return ResultJson(ResultType.error, info.ToString(), "");
        }

        private string GetAccountList(HttpContext context)
        {
            int pageSize = 10; //默认每页返回记录数
            int _pageindex;
            int _type;

            string userid = context.Request["userid"] ?? "";
            string pageindex = context.Request["pageindex"] ?? "";//页索引
            string findkey = context.Request["findkey"] ?? "";//搜索关键字
            string type = context.Request["type"] ?? "";//类型

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (string.IsNullOrEmpty(pageindex))
            {
                return ResultJson(ResultType.error, "页索引不能为空", "");
            }
            if (string.IsNullOrEmpty(type))
            {
                return ResultJson(ResultType.error, "类型不能为空", "");
            }
            int.TryParse(pageindex, out _pageindex);

            if (_pageindex <= 0) _pageindex = 1;

            long _userid = 0;
            long.TryParse(userid, out _userid);
            int.TryParse(type, out _type);

            if (!string.IsNullOrEmpty(findkey))
            {
                findkey = SafeHelper.GetSafeSql(findkey);
            }

            AccountService svc = new AccountService();
            object result;
            if("1".Equals(type))
                result = svc.AccountList(_userid, _pageindex,pageSize, findkey, _type);
            else
                result = svc.AccountYTList(_userid, _pageindex, pageSize, findkey, _type);
            return ResultJson(ResultType.success, "获取成功", result);

        }

        private string GetAccountInfo(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            object info = string.Empty;
            
            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            int _userid = 0;
            int.TryParse(userid, out _userid);

            AccountService svc = new AccountService();
            var result = svc.AccountInfo(_userid,out info);
            if (result)
            {
                return ResultJson(ResultType.success, "获取成功", info);
            }
            else
                return ResultJson(ResultType.error, info.ToString(), "");
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetAccountBalance(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            object info = string.Empty;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            int _userid = 0;
            int.TryParse(userid, out _userid);

            AccountService svc = new AccountService();
            var result = svc.AccountBalance(_userid, out info);
            if (result)
            {
                return ResultJson(ResultType.success, "获取成功", info);
            }
            else
                return ResultJson(ResultType.error, info.ToString(), "");
        }

    }
}