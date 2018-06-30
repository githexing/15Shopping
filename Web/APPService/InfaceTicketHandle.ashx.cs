using Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    /// <summary>
    /// InfaceTicketHandle 的摘要说明
    /// </summary>
    public class InfaceTicketHandle : IHttpHandler
    {
        public lgk.BLL.tb_TicketOrder orderBLL = new lgk.BLL.tb_TicketOrder();
        public lgk.BLL.tb_TicketBack orderCallbll = new lgk.BLL.tb_TicketBack();
        public lgk.BLL.tb_user userBLL = new lgk.BLL.tb_user();
        lgk.BLL.tb_Account bllaccount = new lgk.BLL.tb_Account();
        AllCore ac = new AllCore();
        public void ProcessRequest(HttpContext context)
        {
            string s = "\r\n" + "\r\n" + "\r\n" + "\r\n" + "记录时间" + DateTime.Now.ToString() + "\r\n";
            try
            {
                context.Response.ContentType = "text/plain";
                lgk.Model.tb_TicketBack Model = new lgk.Model.tb_TicketBack();
                if (context.Request["type"] == null)
                {
                    s = s + "没有回调\r\n";
                    context.Response.Write("没有回调数据");
                }
                else
                {
                    Model.Type = context.Request["type"];
                    if (Model.Type == "0")
                    {
                        Model.OrderNo = context.Request["orderno"];
                        Model.OrderStatus = context.Request["orderstatus"];
                        Model.Reason = context.Request["reason"];
                    }
                    else if (Model.Type == "1")
                    {
                        Model.OrderNo = context.Request["orderno"];
                        Model.OrderStatus = context.Request["orderstatus"];
                        Model.TicketNos = context.Request["ticketnos"];
                    }
                    else if (Model.Type == "3")
                    {
                        Model.FefundMoney = context.Request["fefundmoney"];
                        Model.PoundageFee = context.Request["poundagefee"];
                        Model.Reason = context.Request["fefunstatemsg"];
                        Model.OrderStatus = context.Request["fefundstate"];
                        Model.OrderNo = context.Request["fefundno"];
                    }
                    Model.Sign = context.Request["sign"];
                    s = s + "接受内容信息:通知类型：" + Model.Type + ",订单号：" + Model.OrderNo + "，订单状态：" + Model.OrderStatus + "，返回结果集：" + Model.Reason + "\r\n";
                    if (Model != null)
                    {
                        lgk.Model.tb_TicketBack Modelreback = orderCallbll.GetModel(" OrderNo='" + Model.OrderNo + "'");
                        if (Modelreback == null)
                        {
                            if (orderCallbll.Add(Model) > 0)
                            {
                                lgk.Model.tb_TicketOrder order = orderBLL.GetModel("OrdeID='" + Model.OrderNo + "'");
                                if (order != null)
                                {
                                    if (orderBLL.UpdateStatus(Convert.ToInt32(Model.OrderStatus), 1, Model.OrderNo))
                                    {
                                        s = s + "更新订单状态成功，订单状态为：" + StateCode(Model.OrderStatus.ToString()) + "\r\n";
                                        //退票退款通知 返还金额到账户
                                        if (Model.Type == "3" || Model.Type == "0" || Model.OrderStatus != "3")
                                        {
                                            lgk.Model.tb_user model = userBLL.GetModel(order.UserID);
                                            model.Emoney += Convert.ToDecimal(order.PayPrice);
                                            userBLL.Update(model);
                                            string bramk = "退票退款:" + order.PayPrice;
                                            ac.AddJournal(Convert.ToInt32(order.UserID), bramk, Convert.ToDecimal(order.PayPrice), 0, model.Emoney, 1);
                                            bllaccount.UpdateBanlcen("TicketAccount", Convert.ToDecimal(order.PayPrice), 2);
                                        }
                                        context.Response.Write("SUCCESS");
                                    }
                                }
                                else
                                {
                                    s = s + "订单不存在\r\n";
                                    context.Response.Write("订单不存在");
                                }
                            }
                        }
                        else
                        {
                            if (orderCallbll.Update(Model))
                            {
                                lgk.Model.tb_TicketOrder order = orderBLL.GetModel("OrdeID='" + Model.OrderNo + "'");
                                if (order != null)
                                {
                                    if (orderBLL.UpdateStatus(Convert.ToInt32(Model.OrderStatus), 1, Model.OrderNo))
                                    {
                                        s = s + "更新订单状态成功，订单状态为：" + StateCode(Model.OrderStatus.ToString()) + "\r\n";
                                        //退票退款通知 返还金额到账户
                                        if (Model.Type == "3" || Model.Type == "0" || Model.OrderStatus!="3")
                                        {
                                            lgk.Model.tb_user model = userBLL.GetModel(order.UserID);
                                            model.Emoney += Convert.ToDecimal(Model.FefundMoney);
                                            userBLL.Update(model);
                                            string bramk = "退票退款";
                                            ac.AddJournal(Convert.ToInt32(order.UserID), bramk, Convert.ToDecimal(Model.FefundMoney), 0, model.Emoney, 1);
                                            bllaccount.UpdateBanlcen("TicketAccount", Convert.ToDecimal(Model.FefundMoney), 2);
                                        }
                                    }
                                }
                                else
                                {
                                    s = s + "订单不存在\r\n";
                                    context.Response.Write("订单不存在");
                                }
                            }
                            s = s + "重复推送\r\n";
                            context.Response.Write("SUCCESS");
                        }
                    }
                    else
                    {
                        s = s + "回调数据为空\r\n";
                        context.Response.Write("没有回调数据");
                    }
                }
            }
            catch (Exception ex)
            {
                s = s + "回调异常，错误信息" + ex.Message + "\r\n";
                context.Response.Write("回调异常，错误信息" + ex.Message);
            }
            System.IO.File.AppendAllText(context.Server.MapPath("~/log/RequesTicketBacklog/RequestBacklog" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".txt"), s);
        }
        #region 订单状态
        /// <summary>
        /// 订单状态
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string StateCode(string state)
        {
            string str = "";
            if (state == "0")
            {
                str = "待确认";
            }
            if (state == "1")
            {
                str = "等待支付";
            }
            if (state == "2")
            {
                str = "等待出票";
            }
            if (state == "3")
            {
                str = "出票完成";
            }
            if (state == "10")
            {
                str = "订单关闭";
            }
            if (state == "16")
            {
                str = "暂不能出票";
            }
            if (state == "19")
            {
                str = "已拒单";
            }
            if (state == "31")
            {
                str = "退款中";
            }
            if (state == "32")
            {
                str = "退款失败";
            }
            if (state == "33")
            {
                str = "退款成功";
            }
            return str;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    public class param
    {
        public string type { set; get; }//通知类型
        public string orderno { set; get; }//订单号
        public string orderstatus { set; get; }//订单状态
        public string reason { set; get; }//说明
        public string ticketnos { set; get; }//票号参数
        public string poundagefee { set; get; }//退票手续费
        public string fefundmoney { set; get; }//退票退款金额
        public string sign { set; get; }
    }
    
}