using Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService.Service
{
    public class TrainTicketsService : AllCore
    {
        WebUtils _webUtils = new WebUtils();
        lgk.BLL.tb_TrainTicketsOrder bllorder = new lgk.BLL.tb_TrainTicketsOrder();
        lgk.BLL.tb_TrainTicketsOrderDetail bllorderdeil = new lgk.BLL.tb_TrainTicketsOrderDetail();
        lgk.BLL.tb_TrainBackUrl back = new lgk.BLL.tb_TrainBackUrl();
        lgk.BLL.tb_Insurance bllince = new lgk.BLL.tb_Insurance();
        lgk.BLL.tb_CityCode bllcity = new lgk.BLL.tb_CityCode();
        lgk.BLL.tb_Account bllaccount = new lgk.BLL.tb_Account();
        private string cityCodeUrl = "http://op.juhe.cn/trainTickets/cityCode";//站点简码查询接口地址
        private string ticketsAvailableUrl = "http://op.juhe.cn/trainTickets/ticketsAvailable";//余票查询
        private string submitUrl = "http://op.juhe.cn/trainTickets/submit";//提交订单
        //private string submitUrl = "http://op.juhe.cn/trainTickets/test/submit";// (提交订单)测试地址
        private string payUrl = "http://op.juhe.cn/trainTickets/pay";//请求出票
        private string orderStatusUrl = "http://op.juhe.cn/trainTickets/orderStatus";//订单状态查询
        private string refundUrl = "http://op.juhe.cn/trainTickets/refund";//线上退票
        private string ordersUrl = "http://op.juhe.cn/trainTickets/orders";//历史订单查询
        private string exportUrl = "http://op.juhe.cn/trainTickets/export";//下载报表
        private string cancelUrl = "http://op.juhe.cn/trainTickets/cancel";//取消待支付的订单
        private string setPushUrl = "http://op.juhe.cn/trainTickets/setPush";//设置推送
        private string balanceUrl = "http://op.juhe.cn/trainTickets/balance.php";//查询账户余额
        private string AppKey = "7003fce58f743e6a01e2c80427aee60b";
        private string dtype = "json";
        public string RequestSumit(Dictionary<string, string> dic1, string url,string typename)
        {
            string s = "\r\n" + "\r\n" + "\r\n" + "\r\n" + typename+":记录时间" + DateTime.Now.ToString() + "\r\n";
            try
            {
                string SendContent = Util.PrintDic(dic1);
                string response = _webUtils.DoPost(url, SendContent);
                s = s + "发送内容信息:" + SendContent + "\r\n";
                s = s + "响应结果:" + response + "\r\n";
                System.IO.File.AppendAllText(Server.MapPath("~/log/Requestlog.txt"), s);
                return response;

            }
            catch (Exception ex)
            {
                s = s + "错误信息:" + ex.Message + "\r\n";
                return "error";
            }
            System.IO.File.AppendAllText(Server.MapPath("~/log/Requestlog.txt"), s);
        }
        /// <summary>
        /// 处理请求的参数，并开始请求
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public string RequestBegin(Dictionary<string, string> dic)
        {
            string act = dic["act"].ToLower();
            Dictionary<string, string> dic1 = ParmsPath(act);
            Dictionary<string, string> dic2 = new Dictionary<string, string>();
            dic2.Add("dtype", dtype);
            dic2.Add("key", AppKey);
            foreach (var item in dic1)
            {
                foreach (var item1 in dic)
                {
                    if (item.Key.Equals(item1.Key))
                    {
                        dic2.Add(item.Key, item1.Value);
                    }
                }
            }
            if (act.Equals("citycode"))//站点简码查询
            {
                return CityCode(dic1, dic2,act);
            }
            else if (act.Equals("submit")) //提交订单
            {
                return Submit(dic, dic1, dic2);
            }
            else if (act.Equals("cancel")) //取消订单
            {
                return CancelOrder(dic, dic1, dic2);
            }
            else if (act.Equals("orderstatus")) //查询订单
            {
                return Getorder(dic, dic1, dic2);
            }
            else if(act == "pay") //请求出票(支付)
            {
                return Pay(dic, dic2);
            }
            else
            {
                return RequestSumit(dic2, dic1["RequestUrl"].ToString(), act);
            }
        }
        #region 站点简码查询处理
        /// <summary>
        /// 站点简码查询处理
        /// </summary>
        /// <param name="dic1"></param>
        /// <param name="dic2"></param>
        /// <param name="act"></param>
        /// <returns></returns>
        private string CityCode(Dictionary<string, string> dic1, Dictionary<string, string> dic2,string act)
        {
            string respon = RequestSumit(dic2, dic1["RequestUrl"].ToString(), act);
            string reslit = "";
            if (respon != "error")
            {
                var Result = JsonConvert.DeserializeObject<ListRespondResult>(respon);
                if (Result.result.Count > 0)
                {
                    for (int i = 0; i < Result.result.Count; i++)
                    {
                        lgk.Model.tb_CityCode city = bllcity.GetModel("Name='" + Result.result[i].name+"'");
                        if (city == null)
                        {
                            lgk.Model.tb_CityCode model = new lgk.Model.tb_CityCode();
                            model.Name = Result.result[i].name;
                            model.Code = Result.result[i].code;
                            bllcity.Add(model);
                        }
                        else
                        {
                            city.Name = Result.result[i].name;
                            city.Code = Result.result[i].code;
                            bllcity.Update(city);
                        }
                    }
                    reslit = "已成功更新站点简码";
                }
                else
                {
                    reslit = "查询站点失败";
                }
            }
            else
            {
                reslit = "请求异常";
            }
            return "{\"reason\":\"成功的返回\",\"result\":\""+ reslit + "\",\"error_code\":0}";
        }
        #endregion
        #region 提交订单处理
        /// <summary>
        /// 提交订单处理
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="dic1"></param>
        /// <param name="dic2"></param>
        /// <returns></returns>
        public string Submit(Dictionary<string, string> dic, Dictionary<string, string> dic1, Dictionary<string, string> dic2)
        {
            decimal money = Convert.ToDecimal(dic["allprice"].ToString());
            decimal banlcen = bllaccount.BanlceAcount("TrainAccount");
            if (banlcen >= money)
            {
                dic2.Add("UserID", dic["UserID"].ToString());
                dic2.Add("FromStationName", dic["FromStationName"].ToString());
                dic2.Add("ToStationName", dic["ToStationName"].ToString());
                dic2.Add("FromStationDate", dic["FromStationDate"].ToString());
                dic2.Add("ToStationDate", dic["ToStationDate"].ToString());
                dic2.Add("OrderPrice", money.ToString());
                dic2.Add("LinkMan", dic["LinkMan"].ToString());
                dic2.Add("LinkPhone", dic["LinkPhone"].ToString());
                lgk.Model.tb_user usermodel = userBLL.GetModel(Convert.ToInt32(dic["UserID"].ToLower()));
                if (usermodel.Emoney >= money)
                {
                    
                    //提交订单到接口
                    string respon = RequestSumit(dic2, dic1["RequestUrl"].ToString(), dic["act"].ToLower());
                    if (respon != "error")
                    {
                        var Result = JsonConvert.DeserializeObject<RespondResult>(respon);
                        if (Result.result != null)
                        {
                            dic2.Add("OrderID", Result.result.orderid);
                            //提交订单成功添加到本地订单
                            OrderHandle(dic2);
                            //扣除释放币
                            // Bonus(usermodel, money);
                            //提交回调地址到接口
                            Dictionary<string, string> dicback = new Dictionary<string, string>();
                            lgk.Model.tb_TrainBackUrl backurl = back.GetModel("");
                            if (backurl != null)
                            {
                                dicback.Add("dtype", dtype);
                                dicback.Add("key", AppKey);
                                dicback.Add("submit_callback", backurl.SubmitCallback);
                                dicback.Add("pay_callback", backurl.PayCallback);
                                dicback.Add("refund_callback", backurl.RefundCallback);
                                dicback.Add("name", backurl.CompanName);
                                string responBack = RequestSumit(dicback, setPushUrl, "setpush");
                                var backmodel = JsonConvert.DeserializeObject<RespondResult>(responBack);
                                if (backmodel.error_code != "0")
                                {
                                    respon = "{\"reason\":\"success\",\"error_code\":\"0\",\"info\":\"推送回调地址失败\"}";
                                }
                            }
                            else
                            {
                                respon = "{\"reason\":\"success\",\"error_code\":\"0\",\"info\":\"推送回调地址为空\"}";
                            }
                        }
                        return respon;
                    }
                    else
                    {
                        return "error";
                    }
                   
                }
                else
                {
                    return "{\"reason\":\"error\",\"error_code\":\"1\",\"info\":\"释放币余额不足\"}";
                }
            }
            else
            {
                return "{\"reason\":\"error\",\"error_code\":\"1\",\"info\":\"该功能正在维护中\"}";
                //return "{\"reason\":\"error\",\"error_code\":\"1\",\"info\":\"平台余额不足，该功能已暂停使\"}";
            }
        }
        public string  Bonus(lgk.Model.tb_user usermodel,decimal price)
        {
            try
            {
                usermodel.Emoney = usermodel.Emoney - price;
                userBLL.Update(usermodel);
                string bramk="订购火车票扣除原始币：" + price;
                JournalAdd(usermodel.UserID, bramk, 2, price);
                
                return "success";
            }
            catch (Exception)
            {

                return "error";
            }
            
        }
        /// <summary>
        /// 添加本地订单
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public int OrderHandle(Dictionary<string, string> dic)
        {
            int result = 0;
            try
            {
                lgk.Model.tb_TrainTicketsOrder order = new lgk.Model.tb_TrainTicketsOrder();
                lgk.Model.tb_TrainTicketsOrderDetail orderdateil = new lgk.Model.tb_TrainTicketsOrderDetail();
                lgk.Model.tb_Insurance insurance = new lgk.Model.tb_Insurance();
                //订单信息
                order.OrderCode = dic["user_orderid"].ToString().Trim();
                order.ISAcceptStanding = dic["is_accept_standing"].ToString().Trim();
                order.FromStationCode = dic["from_station_code"].ToString().Trim();
                order.ToStationCode = dic["to_station_code"].ToString().Trim();
                order.CheCi = dic["checi"].ToString().Trim();
                order.TrainDate = DateTime.Now;
                order.UserID = Convert.ToInt32(dic["UserID"].ToString());
                order.State = 0;
                order.OrderID = dic["OrderID"].ToString().Trim();
                order.FromStationName = dic["FromStationName"].ToString().Trim();
                order.ToStationName = dic["ToStationName"].ToString().Trim();
                order.FromStationDate = dic["FromStationDate"].ToString().Trim();
                order.ToStationDate = dic["ToStationDate"].ToString().Trim();
                order.OrderPrice = Convert.ToDecimal(dic["OrderPrice"].ToString().Trim());
                order.LinkMan = dic["LinkMan"].ToString().Trim();
                order.LinkPhone = dic["LinkPhone"].ToString().Trim();
                var orderdail = JsonConvert.DeserializeObject<List<passengers>>(dic["passengers"].ToString());
                int id = bllorder.Add(order);
                if (id > 0)
                {
                    for (int i = 0; i < orderdail.Count; i++)
                    {
                        //订单乘客信息
                        orderdateil.OrderID = id;
                        orderdateil.PassengerseName = orderdail[i].passengersename;
                        orderdateil.PiaoType = orderdail[i].piaotype;
                        orderdateil.PiaotypeName = orderdail[i].piaotypename;
                        orderdateil.Passporttypeseid = orderdail[i].passporttypeseid;
                        orderdateil.PassporttypeseidName = orderdail[i].passporttypeseidname;
                        orderdateil.PassportseNO = orderdail[i].passportseno;
                        orderdateil.Price = orderdail[i].price;
                        orderdateil.ZWCode = orderdail[i].zwcode;
                        orderdateil.State = 0;
                        orderdateil.ZWName = orderdail[i].zwname;
                        orderdateil.PassengerId = Convert.ToInt32(orderdail[i].passengerid);
                        orderdateil.Disacount = 3;
                        if (orderdail[i].insurance.name != null)
                        {
                            //免费出行险
                            insurance.Name = orderdail[i].insurance.name;
                            insurance.Mobile = orderdail[i].insurance.mobile;
                            insurance.Gender = orderdail[i].insurance.gender;
                            insurance.Birth = orderdail[i].insurance.birth;
                            insurance.City = orderdail[i].insurance.city;
                            insurance.Idcard = orderdail[i].insurance.idcard;
                            int inid = bllince.Add(insurance);
                            if (inid > 0)
                            {
                                orderdateil.InsuranceID = inid;
                            }
                        }
                        else 
                        {
                            orderdateil.InsuranceID = 0;
                        }
                        bllorderdeil.Add(orderdateil);
                    }
                    result = id;
                }
                else
                {
                    result = 0;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }
        #endregion
        #region 请求出票(支付)
        /// <summary>
        /// 请求出票(支付)
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="dic2"></param>
        /// <returns></returns>
        public string Pay(Dictionary<string, string> dic, Dictionary<string, string> dic2)
        {
            lgk.Model.tb_TrainTicketsOrder model = bllorder.GetModel("OrderID='" + dic2["orderid"].ToString() + "'");
            List<lgk.Model.tb_TrainTicketsOrderDetail> list = bllorderdeil.GetModelList("OrderID=" + model.ID);
            var user = userBLL.GetModel(model.UserID);
            if (user.SecondPassword.Equals(Util.GetMD5(dic["paypwd"].ToString()).ToUpper()))
            {
                if (user.IsLock == 1)
                {
                    return "{\"reason\":\"error\",\"error_code\":\"1\",\"info\":\"账户已冻结，提交失败\"}";

                }
                if (user.Emoney < model.OrderPrice)
                {
                    return "{\"reason\":\"error\",\"error_code\":\"1\",\"info\":\"原始币余额不足\"}";

                }
                else
                {
                    Bonus(user, model.OrderPrice);
                    //扣除原始币金额
                    bllaccount.UpdateBanlcen("TrainAccount", model.OrderPrice + 3 * list.Count,1);
                    return RequestSumit(dic2, payUrl, "pay");
                }
            }
            else
            {
                return "{\"reason\":\"error\",\"error_code\":\"1\",\"info\":\"支付密码不正确\"}";
            }
                
        }
        #endregion
        #region 查询订单状态
        /// <summary>
        /// 查询订单状态
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="dic1"></param>
        /// <param name="dic2"></param>
        /// <returns></returns>
        public string Getorder(Dictionary<string, string> dic, Dictionary<string, string> dic1, Dictionary<string, string> dic2)
        {
            try
            {
                string spond = RequestSumit(dic2, orderStatusUrl, "getorder");
                var backmodel = JsonConvert.DeserializeObject<OrderQuery>(spond);
                if (backmodel.error_code == "0")
                {
                    lgk.Model.tb_TrainTicketsOrder model = bllorder.GetModel("OrderCode='" + backmodel.result.user_orderid + "'");
                    //更新订单状态
                    model.State = Convert.ToInt32(backmodel.result.status);
                    if (bllorder.Update(model))
                    {
                        for (int i = 0; i < backmodel.result.passengers.Count; i++)
                        {
                            // bllorderdeil.UpdateStatus(backmodel.result.passengers[i].cxin, Convert.ToInt32(backmodel.result.status), model.ID, Convert.ToInt32(backmodel.result.passengers[i].passengerid));
                             bllorderdeil.UpdateStatus("", Convert.ToInt32(backmodel.result.status), model.ID, Convert.ToInt32(backmodel.result.passengers[i].passengerid));
                        }
                    }
                }
                return spond;
            }
            catch (Exception)
            {

                return "{\"reason\":\"error\",\"error_code\":\"1\",\"info\":\"查询异常\"}";
            }
           
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
        #region 取消订单
        public string CancelOrder(Dictionary<string, string> dic, Dictionary<string, string> dic1, Dictionary<string, string> dic2)
        {
            string respon = RequestSumit(dic2, dic1["RequestUrl"].ToString(), dic["act"].ToLower());
            if (respon != "error")
            {
                var Result = JsonConvert.DeserializeObject<RespondResult>(respon);
                if (Result.result != null)
                {
                    dic2.Add("OrderID", Result.result.orderid);
                    if (Result.result != null)
                    {
                        //更改本地订单状态
                        lgk.Model.tb_TrainTicketsOrder order = bllorder.GetModel("OrderID='" + Result.result.orderid + "'");
                        order.State = Convert.ToInt32(Result.result.status);
                        bllorder.Update(order);
                        //取消订单返还账户金额
                        //lgk.Model.tb_user model = userBLL.GetModel(order.UserID);
                        //model.BonusAccount += order.OrderPrice;
                        //userBLL.Update(model);
                        //string bramk = "取消订单" + order.OrderCode + "，返回释放币：" + order.OrderPrice;
                        //JournalAdd(order.UserID, bramk, 1, order.OrderPrice);
                    }
                }
                return respon;
            }
            else
            {
                return "{\"reason\":\"error\",\"error_code\":\"1\",\"info\":\"请求取消订单失败\"}";
            }
        }
        #endregion
        #region 封装请求参数
        /// <summary>
        /// 封装请求参数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Dictionary<string, string> ParmsPath(string type)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
           
            switch (type.ToLower())
            {
                case "citycode"://站点简码查询
                    dic.Add("stationName", "");
                    dic.Add("all", "");
                    dic.Add("RequestUrl", cityCodeUrl);
                    break;
                case "ticketsavailable"://余票查询
                    dic.Add("train_date", "");
                    dic.Add("from_station","");
                    dic.Add("to_station", "");
                    dic.Add("RequestUrl", ticketsAvailableUrl);
                    break;
                case "submit"://提交订单
                    dic.Add("user_orderid", "");
                    dic.Add("train_date", "");
                    dic.Add("is_accept_standing", "");
                    dic.Add("from_station_code", "");
                    dic.Add("to_station_code", "");
                    dic.Add("checi", "");
                    dic.Add("passengers", "");
                    dic.Add("RequestUrl", submitUrl);
                    break;
                case "pay"://请求出票
                    dic.Add("orderid", "");
                    dic.Add("RequestUrl", payUrl);
                    break;
                case "orderstatus"://订单状态查询
                    dic.Add("orderid", "");
                    dic.Add("RequestUrl", orderStatusUrl);
                    break;
                case "refund"://线上退票
                    dic.Add("orderid", "");
                    dic.Add("ticket_no", "");
                    dic.Add("passengername", "");
                    dic.Add("passporttypeseid", "");
                    dic.Add("passportseno", "");
                    dic.Add("RequestUrl", refundUrl);
                    break;
                case "orders"://历史订单查询
                    dic.Add("page", "");
                    dic.Add("RequestUrl", ordersUrl);
                    break;
                case "export"://下载报表
                    dic.Add("since", "");
                    dic.Add("before", "");
                    dic.Add("RequestUrl", exportUrl);
                    break;
                case "cancel"://取消待支付的订单
                    dic.Add("orderid", "");
                    dic.Add("RequestUrl", cancelUrl);
                    break;
                case "setpush"://设置推送
                    dic.Add("submit_callback", "");
                    dic.Add("pay_callback", "");
                    dic.Add("refund_callback", "");
                    dic.Add("name", "");
                    dic.Add("RequestUrl", setPushUrl);
                    break;
                case "balance"://查询账户余额
                    dic.Add("RequestUrl", balanceUrl);
                    break;
                default:
                    break;
            }
            return dic;
        }
        #endregion
    }
    public class passengers
    {
        public string passengerid { set; get; }
        public string passengersename { set; get; }
        public int piaotype { set; get; }
        public string piaotypename { set; get; }
        public int passporttypeseid { set; get; }
        public string passporttypeseidname { set; get; }
        public string passportseno { set; get; }
        public decimal price { set; get; }
        public string zwcode { set; get; }
        public string zwname { set; get; }
        public insurance insurance { set; get; }
        public string cxin { set; get; }
        public string ticket_no { set; get; }
    }
    public class insurance
    {
        public string name { set; get; }
        public string mobile { set; get; }
        public string gender { set; get; }
        public DateTime birth { set; get; }
        public string city { set; get; }
        public string idcard { set; get; }
    }
    public class RespondResult
    {
        public string reason { set; get; }
        public result result { set; get; }
        public string error_code { set; get; }
    }
    public class ListRespondResult
    {
        public string reason { set; get; }
        public List<result> result { set; get; }
        public string error_code { set; get; }
    }
    public class result
    {
        public string orderid { set; get; }
        public string name { set; get; }
        public string code { set; get; }
        public string cardid { set; get; }
        public string cardnum { set; get; }
        public string ordercash { set; get; }
        public string cardname { set; get; }
        public string sporder_id { set; get; }
        public string uorderid { set; get; }
        public string game_userid { set; get; }
        public string game_state { set; get; }
        public string user_orderid { set; get; }
        public string msg { set; get; }
        public string status { set; get; }
        public string cancel_time { set; get; }
        public string submit_callback { set; get; }
        public string pay_callback { set; get; }
        public string refund_callback { set; get; }
        public string key { set; get; }
        public List<passengers> passengers { set; get;}
    }


    public class OrderQuery
    {
        public string reason { set; get; }
        public OrderQueryResult result { set; get; }
        public string error_code { set; get; }
    }

    public class OrderQueryPassengers
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
    }

    public class OrderQueryResult
    {
        public string orderid { set; get; }
        public string user_orderid { set; get; }
        public string zwname { set; get; }
        public string msg { set; get; }
        public string status { set; get; }
        public List<OrderQueryPassengers> passengers { set; get; }
        public string checi { set; get; }
        public string submit_time { set; get; }
        public string train_date { set; get; }
        public string from_station_name { set; get; }
        public string from_station_code { set; get; }
        public string to_station_name { set; get; }
        public string to_station_code { set; get; }
    
    }
}