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
    /// Invest 的摘要说明
    /// </summary>
    public class Invest : ServiceHandler
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
                case "buymachine"://购买
                    result = Investment(context);
                    break;
                case "list"://报单记录
                    result = InvestList(context);
                    break;
                case "getprice"://获取价格
                    result = GetMachinePrice();
                    break;
                case "transfer"://转移矿机
                    result = TransferMachine(context);
                    break;
                case "transferlist"://转移矿机列表
                    result = TransferMachineList(context);
                    break;
                case "activelist"://激活列表
                    result = ActiveList(context);
                    break;
                case "info"://获取激活和未激活矿机数量
                    result = GetInfo(context);
                    break;
                case "active"://激活矿机
                    result = ActiveMachine(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常", "Invest");
                    break;
            }
            context.Response.Write(result);
        }
        //投资
        private string Investment(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string num = context.Request["num"] ?? "";
            string paypassword = context.Request["paypassword"] ?? "";
            string message = string.Empty;

            int _num = 0;
            long _userid = 0;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入投资人用户ID", "");
            }

            if (string.IsNullOrEmpty(num))
            {
                return ResultJson(ResultType.error, "请输入购买数量", "");
            }

            if (string.IsNullOrEmpty(paypassword))
            {
                return ResultJson(ResultType.error, "请输入支付密码", "");
            }

            int.TryParse(num,out _num);
            if (_num<=0)
            {
                return ResultJson(ResultType.error, "购买数量必须大于零", "");
            }
            long.TryParse(userid, out _userid);
            InvestService svc = new InvestService();
            bool result = svc.Invest(_userid, _num, paypassword.ToUpper(), out message);
            if (result)
            {
                return ResultJson(ResultType.success, message, "");
            }
            else
            {
                return ResultJson(ResultType.error, message, "");
            }
            
        }

        //购买记录
        private string InvestList(HttpContext context)
        {
            int pageSize = 10; //默认每页返回记录数
            int _pageindex;

            string userid = context.Request["userid"] ?? "";
            string pageindex = context.Request["pageindex"] ?? "";//页索引
            string findkey = context.Request["findkey"] ?? "";//搜索关键字

            string message = string.Empty;

            long _userid = 0;
            int.TryParse(pageindex, out _pageindex);

            if (_pageindex <= 0) _pageindex = 1;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!string.IsNullOrEmpty(findkey))
            {
                findkey = SafeHelper.GetSafeSql(findkey);
            }

            long.TryParse(userid, out _userid);
            InvestService svc = new InvestService();
            var result = svc.InvestList(_userid, _pageindex, pageSize, findkey);

            return ResultJson(ResultType.success, message, result);
        }

        private string GetMachinePrice()
        {
            InvestService svc = new InvestService();
            decimal price = svc.GetMachinePrice();
         
            SortedDictionary<string, object> value = new SortedDictionary<string, object>();
            value.Add("price", price);

            return ResultJson(ResultType.success, "ok", value);
        }

        #region 矿机转移
        /// <summary>
        /// 矿机转移
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string TransferMachine(HttpContext context)
        {
            string struserid = context.Request["userid"] ?? "";
            string tousercode = context.Request["tousercode"] ?? "";
            string strnumber = context.Request["num"] ?? "0";
            string strpaypassword = context.Request["paypassword"] ?? "";
            string message = string.Empty;

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

            #region 买入数量
            int number = 0;
            if (string.IsNullOrEmpty(strnumber))
            {
                return ResultJson(ResultType.error, "请输入买入数量", "");
            }
            if (!int.TryParse(strnumber, out number))
            {
                return ResultJson(ResultType.error, "请输入有效的买入数量", "");
            }
            if (number <= 0)
            {
                return ResultJson(ResultType.error, "挂卖数量必须大于0", "");
            }
            #endregion

            #region 支付密码
            if (string.IsNullOrEmpty(strpaypassword))
            {
                return ResultJson(ResultType.error, "请输入支付密码", "");
            }
            #endregion

            InvestService svc = new InvestService();
            var result = svc.TransferMachine(userid, tousercode, number, strpaypassword, out message);
            if (result)
            {
                return ResultJson(ResultType.success, message, "");
            }
            else
            {
                return ResultJson(ResultType.error, message, "");
            }
        }
        #endregion

        private string TransferMachineList(HttpContext context)
        {
            string struserid = context.Request["userid"] ?? "";
            string strpageindex = context.Request["pageindex"] ?? "";//页索引
            string strpagesize = context.Request["pagesize"] ?? "";//页索引
            string findkey = context.Request["findkey"] ?? "";//搜索关键字
            string message = string.Empty;

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

            #region 查询页码
            int pageindex = 0;
            if (string.IsNullOrEmpty(strpageindex))
            {
                return ResultJson(ResultType.error, "请输入查询页码", "");
            }
            if (!int.TryParse(strpageindex, out pageindex))
            {
                return ResultJson(ResultType.error, "请输入有效的查询页码", "");
            }
            if (pageindex <= 0)
            {
                return ResultJson(ResultType.error, "请输入有效的查询页码", "");
            }
            #endregion

            #region 每页显示的记录数
            int pagesize = 0;
            if (string.IsNullOrEmpty(strpagesize))
            {
                return ResultJson(ResultType.error, "请输入每页显示的记录数", "");
            }
            if (!int.TryParse(strpagesize, out pagesize))
            {
                return ResultJson(ResultType.error, "请输入有效的每页显示的记录数", "");
            }
            if (pagesize <= 0)
            {
                return ResultJson(ResultType.error, "请输入有效的每页显示的记录数", "");
            }
            #endregion

            int pagecount = 0, totalcount = 0;
            InvestService svc = new InvestService();
            TransferMachineListModel model = new TransferMachineListModel();
            model.list = svc.GetListByPage(userid, pageindex, pagesize, out pagecount, out totalcount, findkey);
            model.pagecount = pagecount;
            model.totalcount = totalcount;

            return ResultJson(ResultType.success, message, model);
        }
        //获取激活和未激活矿机数量
        private string GetInfo(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            long _userid = userid.ToInt();

            InvestService svc = new InvestService();
            var info = svc.GetInfo(_userid);

            return ResultJson(ResultType.success, "ok", info);
        }
        //激活列表
        private string ActiveList(HttpContext context)
        {
            int pageSize = 10; //默认每页返回记录数
            int _pageindex;

            string userid = context.Request["userid"] ?? "";
            string pageindex = context.Request["pageindex"] ?? "";//页索引
            string findkey = context.Request["findkey"] ?? "";//搜索关键字

            string message = string.Empty;

            long _userid = 0;

            _pageindex = pageindex.ToInt();
            if (_pageindex <= 0) _pageindex = 1;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!string.IsNullOrEmpty(findkey))
            {
                findkey = SafeHelper.GetSafeSql(findkey);
            }

            long.TryParse(userid, out _userid);
            InvestService svc = new InvestService();
            var result = svc.ActiveList(_userid, _pageindex, pageSize, findkey);
            var info = svc.GetInfo(_userid);

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("info", info); //
            dict.Add("list", result); //
            
            return ResultJson(ResultType.success, message, dict);
        }

        private string ActiveMachine(HttpContext context)
        {
            string message;
            string userid = context.Request["userid"] ?? "";
            string machineid = context.Request["machineid"] ?? "";
            long _userid = userid.ToLong();
            long _machineid = machineid.ToLong();
            
            InvestService svc = new InvestService();

            if (svc.Active(_userid, _machineid, out message))
            {
                var info = svc.GetInfo(_userid);
                return ResultJson(ResultType.success, message, info);
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
    }
}