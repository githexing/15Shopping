using DataAccess;
using Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Handle
{
    /// <summary>
    /// InfaceBackHandler 的摘要说明
    /// </summary>
    public class InfaceBackHandler : IHttpHandler
    {
       // string pay_memberid = System.Web.Configuration.WebConfigurationManager.AppSettings["pay_memberid"].ToString();
        lgk.BLL.tb_user userBLL = new lgk.BLL.tb_user();
        public lgk.BLL.tb_TrainTicketsOrder orderBLL = new lgk.BLL.tb_TrainTicketsOrder();
        public lgk.BLL.tb_OrderCallBack orderCallbll = new lgk.BLL.tb_OrderCallBack();
        lgk.BLL.tb_TrainTicketsOrderDetail bllorderdeil = new lgk.BLL.tb_TrainTicketsOrderDetail();
        lgk.BLL.tb_Account bllaccount = new lgk.BLL.tb_Account();
        lgk.BLL.tb_journal journalBLL = new lgk.BLL.tb_journal();
        //public lgk.BLL.tb_user userBLL = new lgk.BLL.tb_user();
        //public lgk.BLL.tb_journal journalBLL = new lgk.BLL.tb_journal();
        //public lgk.BLL.tb_bonus bonusBLL = new lgk.BLL.tb_bonus();
        AllCore ac = new AllCore();
        public void ProcessRequest(HttpContext context)
        {
            string s = "\r\n" + "\r\n" + "\r\n" + "\r\n" + "记录时间" + DateTime.Now.ToString() + "\r\n";
            try
            {
                
                context.Response.ContentType = "text/plain";
                string data = context.Request["data"];
                s = s + "接受内容信息:" + data + "\r\n";
                var emResult = JsonConvert.DeserializeObject<data>(data);
                if (emResult != null)
                {
                    lgk.Model.tb_OrderCallBack Modelreback = orderCallbll.GetModel(" OrderID='" + emResult.orderid + "'");
                    if (Modelreback == null)
                    {
                        lgk.Model.tb_OrderCallBack Model = new lgk.Model.tb_OrderCallBack();
                        Model.OrderID = emResult.orderid.Trim();
                        Model.FromStationCode = emResult.from_station_code.Trim();
                        Model.FromStationName = emResult.from_station_name.Trim();
                        Model.CheCi = emResult.checi.Trim();
                        Model.Msg = emResult.msg.Trim();
                        if (string.IsNullOrEmpty(emResult.orderamount))
                        {
                            Model.Orderamount = 0;
                        }
                        else
                        {
                            Model.Orderamount = Convert.ToDecimal(emResult.orderamount.Trim());
                        }
                        if (string.IsNullOrEmpty(emResult.ordernumber))
                        {
                            Model.Ordernumber = "";
                        }
                        else
                        {
                            Model.Ordernumber = emResult.ordernumber.Trim();
                        }
                       
                        Model.Passengers = "[";
                        for (int i = 0; i < emResult.passengers.Count; i++)
                        {
                            Model.Passengers += "{passengerid:" + emResult.passengers[i].passengerid + ",passengersename:" + emResult.passengers[i].passengersename+ ",passportseno:" + emResult.passengers[i].passportseno+ ",passporttypeseid:" + emResult.passengers[i].passporttypeseid+ ",passporttypeseidname" + emResult.passengers[i].passporttypeseidname+ ",piaotype:" + emResult.passengers[i].piaotype+ ",piaotypename:" + emResult.passengers[i].piaotypename+ ",price:" + emResult.passengers[i].price+ ",zwcode:" + emResult.passengers[i].zwcode+ ",zwname:" + emResult.passengers[i].zwname+"}";
                            if (i!= emResult.passengers.Count-1)
                            {
                                Model.Passengers += ",";
                            }
                        }
                        Model.Passengers += "]";
                        //emResult.passengers = emResult.passengers;
                        Model.RefundMoney = emResult.refund_money;
                        Model.Status = Convert.ToInt32(emResult.status.Trim());
                        Model.ToStationCode = emResult.to_station_code.Trim();
                        Model.ToStationName = emResult.to_station_name.Trim();
                        Model.TrainDate = Convert.ToDateTime(emResult.train_date.Trim());
                        Model.UserOrderid = emResult.user_orderid;
                        if (orderCallbll.Add(Model) > 0)
                        {
                            lgk.Model.tb_TrainTicketsOrder order = orderBLL.GetModel("OrderID='"+ Model.OrderID+"'");
                           
                            if (order != null)
                            {
                                List<lgk.Model.tb_TrainTicketsOrderDetail> list = bllorderdeil.GetModelList("OrderID=" + order.ID);
                                order.State = Model.Status;
                                if (orderBLL.Update(order))
                                {
                                    for (int i = 0; i < emResult.passengers.Count; i++)
                                    {
                                        bllorderdeil.UpdateStatus(emResult.passengers[i].cxin, Convert.ToInt32(Model.Status), order.ID, Convert.ToInt32(emResult.passengers[i].passengerid));
                                    }
                                    //出票失败处理
                                    if (Model.Status == 5)
                                    {
                                        lgk.Model.tb_user model = userBLL.GetModel(order.UserID);
                                        model.Emoney += order.OrderPrice;
                                        userBLL.Update(model);
                                        string bramk = "出票失败" + order.OrderCode + "，返回原始币：" + order.OrderPrice;
                                        JournalAdd(order.UserID, bramk, 1, order.OrderPrice);
                                        bllaccount.UpdateBanlcen("TrainAccount", order.OrderPrice + 3 * list.Count,2);
                                    }
                                    s = s + "更新订单状态成功，订单状态为：" + StateCode(Model.Status) + "\r\n";
                                    context.Response.Write("success");
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
                        Modelreback.Status = Convert.ToInt32(emResult.status);
                        if (orderCallbll.Update(Modelreback))
                        {
                            lgk.Model.tb_TrainTicketsOrder order = orderBLL.GetModel("OrderID='" + Modelreback.OrderID + "'");
                            List<lgk.Model.tb_TrainTicketsOrderDetail> list = bllorderdeil.GetModelList("OrderID=" + order.ID);
                            if (order != null)
                            {
                                order.State = Convert.ToInt32(emResult.status);
                                if (orderBLL.Update(order))
                                {
                                    for (int i = 0; i < emResult.passengers.Count; i++)
                                    {
                                        bllorderdeil.UpdateStatus(emResult.passengers[i].cxin, Convert.ToInt32(Modelreback.Status), order.ID, Convert.ToInt32(emResult.passengers[i].passengerid));
                                    }
                                    //出票失败处理
                                    if (Modelreback.Status == 5)
                                    {
                                        lgk.Model.tb_user model = userBLL.GetModel(order.UserID);
                                        model.Emoney += order.OrderPrice;
                                        userBLL.Update(model);
                                        string bramk = "出票失败" + order.OrderCode + "，返回原始币：" + order.OrderPrice;
                                        JournalAdd(order.UserID, bramk, 1, order.OrderPrice);
                                        bllaccount.UpdateBanlcen("TrainAccount", order.OrderPrice + 3 * list.Count, 2);
                                    }
                                    s = s + "更新订单状态成功，订单状态为：" + StateCode(Modelreback.Status) + "\r\n";
                                    //context.Response.Write("success");
                                }
                            }
                        }
                       // s = s + "重复推送\r\n";
                        context.Response.Write("success");
                    }
                }
                else
                {
                    s = s + "没有回调\r\n";
                    context.Response.Write("没有回调数据");
                }
            }
            catch (Exception ex)
            {
                s= s + "回调异常，错误信息"+ ex .Message+ "\r\n";
                context.Response.Write("回调异常，错误信息" + ex.Message);
            }
            System.IO.File.AppendAllText(context.Server.MapPath("~/log/RequesTrainBacklog/RequestBacklog" + DateTime.Now.Year +"-"+ DateTime.Now.Month +"-"+ DateTime.Now.Day+".txt"), s);
        }
        #region 订单状态
        /// <summary>
        /// 订单状态
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string StateCode(int str)
        {
            string code = "";
            switch (str)
            {
                case 1:
                    code = "失败／失效／取消的订单";
                    break;
                case 2:
                    code = "占座成功待支付（此时可取消订单，超时不支付将失效）";
                    break;
                case 3:
                    code = "支付成功待出票";
                    break;
                case 4:
                    code = "出票成功";
                    break;
                case 5:
                    code = "出票失败";
                    break;
                case 6:
                    code = "正在处理线上退票请求";
                    break;
                case 7:
                    code = "有乘客退票（改签）成功";
                    break;
                case 8:
                    code = "有乘客退票失败";
                    break;
                default:
                    code = "未知状态";
                    break;
            }
            return code;
        }
        #endregion
        #region 增加账户记录
        /// <summary>
        /// 增加账户记录
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="breakm"></param>
        /// <param name="type"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public bool JournalAdd(long userid, string breakm, int type, decimal price)
        {
            lgk.Model.tb_journal jounlmodel = new lgk.Model.tb_journal();
            jounlmodel.UserID = userid;
            jounlmodel.Remark = breakm;
            if (type == 1)
            {
                jounlmodel.InAmount = price;
                jounlmodel.OutAmount = 0;
            }
            if (type == 2)
            {
                jounlmodel.OutAmount = price;
                jounlmodel.InAmount = 0;
            }
            jounlmodel.JournalDate = DateTime.Now;
            jounlmodel.JournalType = 1;
            jounlmodel.BalanceAmount = userBLL.GetBonusAccount(userid);
            if (journalBLL.Add(jounlmodel) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

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
    public class data
    {
        public string from_station_name { set; get; }//出发站
        public string from_station_code { set; get; }//出发站简码
        public string to_station_name { set; get; }//到达站
        public string to_station_code { set; get; }//到达站简码
        public string train_date { set; get; }//出发日期
        public string orderid { set; get; }//您与聚合交互时的订单号
        public string user_orderid { set; get; }//您与用户交互时的订单号
        public string orderamount { set; get; }//订单总金额
        public string ordernumber { set; get; }//取票号
        public string checi { set; get; }//车次
        public string msg { set; get; }//订单的提示信息
        public string status { set; get; }//订单的状态码
        public List<passengers> passengers { set; get; }//乘客信息
        public string refund_money { set; get; }//此订单累积退款金额
        public string sign { set; get; }
    }
    public class passengers
    {
        public string passengerid { set; get; }
        public string passengersename { set; get; }
        public string piaotype { set; get; }
        public string piaotypename { set; get; }
        public string passporttypeseid { set; get; }
        public string passporttypeseidname { set; get; }
        public string passportseno { set; get; }
        public string price { set; get; }
        public string zwcode { set; get; }
        public string zwname { set; get; }
        public insurance insurance { set; get; }
        public string ticket_no { set; get; }
        public string cxin { set; get; }
        public string reason { set; get; }
    }
    public class insurance
    {
        public string name { set; get; }
        public string mobile { set; get; }
        public string gender { set; get; }
        public string birth { set; get; }
        public string city { set; get; }
        public string idcard { set; get; }
        public string reason { set; get; }
    }
}