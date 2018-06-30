using Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// Transfer 的摘要说明
    /// </summary>
    public class Trading : ServiceHandler
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
                case "house"://交易大厅
                    result = TradingFloor(context);
                    break;
                case "sell"://卖出
                    result = TradingSell(context);
                    break;
                case "buy"://买入
                    result = TradingBuy(context);
                    break;
                case "sellorder"://卖出记录
                    result = TradingSellOrder(context);
                    break;
                case "selllist"://卖出订单 已有购买
                    result = TradingSellAndBuyOrder(context);
                    break;
                case "buyorder"://买入订单
                    result = TradingBuyOrder(context);
                    break;
                case "sellorderinfo"://卖出订单详情
                    result = TradingSellOrderInfo(context);
                    break;
                case "selltransorderinfo"://卖出交易订单详情
                    result = TradingSellTransOrderInfo(context);
                    break;
                case "buyorderinfo"://买入订单详情
                    result = TradingBuyOrderInfo(context);
                    break;
                case "pay"://付款
                    result = TradingOrderPay(context);
                    break;
                case "get"://收款
                    result = TradingOrderGet(context);
                    break;
                case "sellcancel"://撤销挂卖订单
                    result = TradingSellOrderCancel(context);
                    break;
                case "buycancel"://撤销挂卖订单
                    result = TradingBuyOrderCancel(context);
                    break;
                case "getbond"://获取保证金
                    result = GetBond();
                    break;
                //case "upload":
                //    string file;
                //    upload(context,"bank",out file);
                //    ResultJson(ResultType.success, file, "upload");
                //    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常.", "trading");
                    break;
            }
            context.Response.Write(result);
        }
        private string GetBond()
        {
            TradingService svc = new TradingService();
            return ResultJson(ResultType.success, "获取成功", svc.GetBond());  
        }
        //交易大厅
        private string TradingFloor(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string message = string.Empty;
            int _userid = 0;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }

            int.TryParse(userid, out _userid);

            TradingService svc = new TradingService();
            List<TradingFloorModel> list = svc.TradingFloor(_userid);

            return ResultJson(ResultType.success, message, list);
        }
        //卖出
        private string TradingSell(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string number = context.Request["number"] ?? "";
            string phone = context.Request["phone"] ?? "";
            string bankid = context.Request["bankid"] ?? "";
            string paypassword = context.Request["paypassword"] ?? "";
            string message = string.Empty;
            long _userid = 0;
            int _bankid = 0;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }

            if (string.IsNullOrEmpty(number))
            {
                return ResultJson(ResultType.error, "请输入卖出数量", "");
            }
            if (string.IsNullOrEmpty(bankid))
            {
                return ResultJson(ResultType.error, "请输入收款账号ID", "");
            }
            if (string.IsNullOrEmpty(phone))
            {
                return ResultJson(ResultType.error, "请输入手机号", "");
            }
            if (string.IsNullOrEmpty(paypassword))
            {
                return ResultJson(ResultType.error, "请输入支付密码", "");
            }
            long.TryParse(userid, out _userid);
            int.TryParse(bankid, out _bankid);

            TradingService svc = new TradingService();
            var result = svc.Sell(_userid, number, phone, _bankid, paypassword.ToUpper(), out message);
            if (result)
            {
                return ResultJson(ResultType.success, message, "");
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
        //买入
        private string TradingBuy(HttpContext context)
        {
            
            string userid = context.Request["userid"] ?? "";
            string ordersellid = context.Request["ordersellid"] ?? "";
            string number = context.Request["number"] ?? "";
            string paypassword = context.Request["paypassword"] ?? "";
            string phone = context.Request["phone"] ?? "";
            string message = string.Empty;
            long _userid = 0;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (string.IsNullOrEmpty(ordersellid))
            {
                return ResultJson(ResultType.error, "请输入挂卖订单ID", "");
            }
            if (string.IsNullOrEmpty(number))
            {
                return ResultJson(ResultType.error, "请输入买入数量", "");
            }
            if (string.IsNullOrEmpty(phone))
            {
                return ResultJson(ResultType.error, "请输入手机号", "");
            }

            if (string.IsNullOrEmpty(paypassword))
            {
                return ResultJson(ResultType.error, "请输入支付密码", "");
            }

            long.TryParse(userid, out _userid);
            long _orderid;
            TradingService svc = new TradingService();
            var result = svc.Buy(_userid, ordersellid, number, phone, paypassword.ToUpper(),out _orderid, out message);
            if (result)
            {
                var list = svc.BuyOrderInfo(_userid, _orderid);
                var bank = svc.GetSellBank(list.BankID);
                SortedDictionary<string, object> values = new SortedDictionary<string, object>();
                values.Add("order", list);
                values.Add("bank", bank);

                return ResultJson(ResultType.success, message, values);
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
        //卖出记录
        private string TradingSellAndBuyOrder(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string orderid = context.Request["orderid"] ?? "";
            string message = string.Empty;
            int _userid = 0;
            int _orderid = 0;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (string.IsNullOrEmpty(orderid))
            {
                return ResultJson(ResultType.error, "请输入订单ID", "");
            }

            int.TryParse(userid, out _userid);
            int.TryParse(orderid, out _orderid);

            TradingService svc = new TradingService();
            var list = svc.SellAndBuyOrder(_userid, _orderid);

            return ResultJson(ResultType.success, message, list);
        }
        //卖出订单
        private string TradingSellOrder(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string message = string.Empty;
            int _userid = 0;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }

            int.TryParse(userid, out _userid);

            TradingService svc = new TradingService();
            var list = svc.SellOrder(_userid).OrderByDescending(s => s.SellDate).ToList();

            return ResultJson(ResultType.success, message, list);
        }
        //买入订单
        private string TradingBuyOrder(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string message = string.Empty;
            int _userid = 0;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }

            int.TryParse(userid, out _userid);

            TradingService svc = new TradingService();
            var list = svc.BuyOrder(_userid).OrderByDescending(s=>s.OrderDate).ToList();

            return ResultJson(ResultType.success, message, list);
        }

        //卖出详情
        private string TradingSellOrderInfo(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string orderid = context.Request["orderid"] ?? "";
            string message = string.Empty;

            int _userid = 0;
            int _orderid = 0;
            int.TryParse(userid, out _userid);
            int.TryParse(orderid, out _orderid);

            TradingService svc = new TradingService();
            var model = svc.SellOrderInfo(_userid, _orderid);
            var list = svc.SellAndBuyOrder(_userid, _orderid);
            SortedDictionary<string, object> values = new SortedDictionary<string, object>();
            values.Add("orderinfo", model);
            values.Add("orderlist", list);

            return ResultJson(ResultType.success, message, values);
        }

        //卖出交易订单详情
        private string TradingSellTransOrderInfo(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string orderid = context.Request["orderid"] ?? "";
            string message = string.Empty;

            int _userid = 0;
            int _orderid = 0;
            int.TryParse(userid, out _userid);
            int.TryParse(orderid, out _orderid);

            TradingService svc = new TradingService();
            var list = svc.SellTransOrderInfo(_userid, _orderid).FirstOrDefault();

            return ResultJson(ResultType.success, message, list);
        }

        //买入订单详情
        private string TradingBuyOrderInfo(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string orderid = context.Request["orderid"] ?? "";
            string message = string.Empty;

            int _userid = 0;
            int _orderid = 0;
            int.TryParse(userid, out _userid);
            int.TryParse(orderid, out _orderid);

            TradingService svc = new TradingService();
            var list = svc.BuyOrderInfo(_userid, _orderid);
            var bank = svc.GetSellBank(list.BankID);
            SortedDictionary<string, object> values = new SortedDictionary<string, object>();
            values.Add("order", list);
            values.Add("bank", bank);
            return ResultJson(ResultType.success, message, values);
        }
        //付款
        private string TradingOrderPay(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string orderid = context.Request["orderid"] ?? "";
            string remark = context.Request["remark"] ?? "";
            string message = string.Empty;
            int _userid = 0;
            int _orderid = 0;
            int.TryParse(userid, out _userid);
            int.TryParse(orderid, out _orderid);

            string picpath;
            upload(context, "credence", out picpath); // 上传凭证

            TradingService svc = new TradingService();
            var result = svc.OrderPay(_userid, _orderid, picpath, remark, out message);
            if (result)
            {
                return ResultJson(ResultType.success, "付款成功", "");
            }
            return ResultJson(ResultType.error, message, "");
        }
        //收款
        private string TradingOrderGet(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string orderid = context.Request["orderid"] ?? "";
            string message = string.Empty;
            int _userid = 0;
            int _orderid = 0;
            int.TryParse(userid, out _userid);
            int.TryParse(orderid, out _orderid);

            TradingService svc = new TradingService();
            var result = svc.OrderGet(_userid, _orderid, out message);
            if (result)
            {
                return ResultJson(ResultType.success, "收款成功", "");
            }

            return ResultJson(ResultType.success, message, "");
        }
        //卖家取消
        private string TradingSellOrderCancel(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string orderid = context.Request["orderid"] ?? "";
            string message = string.Empty;
            int _userid = 0;
            int _orderid = 0;
            int.TryParse(userid, out _userid);
            int.TryParse(orderid, out _orderid);

            TradingService svc = new TradingService();
            var result = svc.SellOrderCancel(_userid, _orderid, out message);
            if (result)
            {
                return ResultJson(ResultType.success, "卖家取消订单成功", "");
            }

            return ResultJson(ResultType.error, message, "");
        }

        //买家取消
        private string TradingBuyOrderCancel(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string orderid = context.Request["orderid"] ?? "";
            string message = string.Empty;
            int _userid = 0;
            int _orderid = 0;
            int.TryParse(userid, out _userid);
            int.TryParse(orderid, out _orderid);

            TradingService svc = new TradingService();
            var result = svc.BuyOrderCancel(_userid, _orderid, out message);
            if (result)
            {
                return ResultJson(ResultType.success, "买家取消订单成功", "");
            }

            return ResultJson(ResultType.error, message, "");
        }
        //private string uploadimg(HttpContext context)
        //{
        //    try
        //    {
        //       // using (context.Request.InputStream)
        //        {
        //            string s = ".jpg";

        //            string name = Util.GetUniqueIndentifier(20);
        //            string filenName = "/upload/" + name + s;
        //            string path = context.Server.MapPath(filenName);
        //            context.Request.Files["img"].SaveAs(path);

        //            return ResultJson(ResultType.success, "", "");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ResultJson(ResultType.success, ex.ToString(), "");
        //    }


        //}
    }


}