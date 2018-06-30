using Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace Web.APPService.Service
{
    public class TicketService : AllCore
    {
        WebUtils _webUtils = new WebUtils();
        public lgk.BLL.tb_TicketOrder ordermodel = new lgk.BLL.tb_TicketOrder();
        public lgk.BLL.tb_Passengers passengmodel = new lgk.BLL.tb_Passengers();
        lgk.BLL.tb_Account bllaccount = new lgk.BLL.tb_Account();

        private string RequestUrl = "http://api.qianjiasu.com/ticketapi.ashx";//正式
        private string Key = "b2dbf01078974cc3921a75439c009670";//正式
        private string CompanyCode = "GX1196";//正式
        private string pwd = "666888";//正式23!@#
        //private string RequestUrl = "http://testapi.moktrip.com/ticketapi.ashx";//测试
        //private string CompanyCode = "GX1006";//测试
        //private string Key = "d2a2f264349a4061aa0e39fc32c79ce7";//测试
        //private string pwd = "888888";//测试
        #region 请求接口
        /// <summary>
        /// 请求接口
        /// </summary>
        /// <param name="dic1"></param>
        /// <param name="typename"></param>
        /// <returns></returns>
        public string RequestSumit(Dictionary<string, object> dic1, string typename)
        {
            string s = "\r\n" + "\r\n" + "\r\n" + "\r\n" + typename + ":记录时间" + DateTime.Now.ToString() + "\r\n";
            try
            {
                string SendContent = "param=" + ReplceStr(Util.DictionaryToJson(dic1));
                string response = _webUtils.DoPost(RequestUrl, SendContent);
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
        #endregion
        #region  处理请求的参数，并开始请求
        /// <summary>
        /// 处理请求的参数，并开始请求
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public string RequestBegin(Dictionary<string, object> dic)
        {
            string act = dic["act"].ToString();
            string sign = "";
            Dictionary<string, object> dic1 = ParmsPath(act);
            Dictionary<string, object> dic2 = new Dictionary<string, object>();
            foreach (var item in dic1)
            {
                foreach (var item1 in dic)
                {
                    if (item.Key.Equals(item1.Key))
                    {
                        if (item.Key.Equals("action"))
                        {
                            dic2.Add(item.Key, item1.Value);
                            dic2.Add("companycode", CompanyCode);
                            dic2.Add("key", Key);
                        }
                        else
                        {
                            dic2.Add(item.Key, item1.Value);
                        }
                       
                    }
                }
            }
            if (act.Equals("autopayvm")) //自动支付
            {
                dic2.Add("paypwd", Util.GetMD5(pwd));
            }
            foreach (var item in dic2)
            {
                sign += item.Value;
            }
            sign = Util.GetMD5(sign);
            dic2.Add("sign", sign);
            if (act.Equals("getfligtlistweb"))//站点简码查询
            {
                return RequestSumit(dic2, act);
            }
            else if (act.Equals("createorder")) //提交订单
            {
                return Submit(dic, dic1, dic2);
            }
            else if (act.Equals("ordercancel")) //取消订单
            {
                return Cancel(dic2);
            }
            else if (act.Equals("autopayvm")) //自动支付
            {
                string loacthpaypwd = Util.GetMD5(dic["loacthpaypwd"].ToString()).ToUpper();
                //dic2.Add("paypwd", Util.GetMD5(pwd));
                return PaySubmit(dic2,loacthpaypwd);
            }
            else if (act.Equals("getorder")) //查询订单
            {
                
                return Getorder(dic2);
            }
            else
            {
                return RequestSumit(dic2, act);
            }
        }
        #endregion
        #region 查询订单
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public string Getorder(Dictionary<string, object> dic)
        {
            try
            {
                string spond = RequestSumit(dic, "getorder");
                var backmodel = JsonConvert.DeserializeObject<QueryRespon>(spond);
                if (backmodel.successcode == "T")
                {
                    lgk.Model.tb_TicketOrder model = ordermodel.GetModel("OrdeID='" + backmodel.result.orderno + "'");
                    //更新订单状态
                    model.Status = Convert.ToInt32(backmodel.result.orderstatus);
                    if (ordermodel.Update(model))
                    {
                        for (int i = 0; i < backmodel.result.passengers.Count; i++)
                        {
                            passengmodel.UpdateStatus(backmodel.result.passengers[i].ticketnumber, backmodel.result.passengers[i].idnumber);
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
        #region 提交订单处理
        /// <summary>
        /// 提交订单处理
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="dic1"></param>
        /// <param name="dic2"></param>
        /// <returns></returns>
        public string Submit(Dictionary<string, object> dic, Dictionary<string, object> dic1, Dictionary<string, object> dic2)
        {
            decimal banlcen = bllaccount.BanlceAcount("TicketAccount");
            decimal money = Convert.ToDecimal(dic["allprice"].ToString());
            if (banlcen >= money)
            {
                //提交订单成功添加到本地订单
                lgk.Model.tb_user usermodel = userBLL.GetModel(Convert.ToInt32(dic["UserID"].ToString()));
                if (usermodel.IsLock == 1)
                {
                    return "{\"successcode\":\"F\",\"errorcode\":0,\"info\":\"账户已冻结，提交失败\"}";
                }
                if (usermodel.Emoney >= Convert.ToDecimal(dic["allprice"].ToString()))
                {
                    
                    //提交订单到接口
                    string respon = RequestSumit(dic2, dic["act"].ToString());
                    if (respon != "error")
                    {
                        dic2.Add("UserID", dic["UserID"].ToString());
                        var Result = JsonConvert.DeserializeObject<respondTicketResult>(respon);
                        if (Result.result != null)
                        {
                            dic2.Add("OrdeID", Result.result.orderno);
                            dic2.Add("Totaltax", Result.result.totaltax);
                            dic2.Add("PayPrice", Result.result.payprice);
                            dic2.Add("TicketPrice", Result.result.ticketprice);
                            dic2.Add("PolicyNum", Result.result.policynum);
                            dic2.Add("PostPrice", Result.result.postprice);
                            dic2.Add("InsurancePrice", Result.result.insuranceprice);
                            dic2.Add("CouponPrice", "0");
                            dic2.Add("AirName", dic["airname"].ToString());
                            dic2.Add("DepcityName", dic["depcityname"].ToString());
                            dic2.Add("ArrcityName", dic["arrcityname"].ToString());
                            //dic2["deptime"] = dic["depdate"] + " " + dic["deptime"];
                            //dic2["arrtime"] = dic["depdate"] + " " + dic["arrtime"];
                            //添加本地订单
                            OrderHandle(dic2, dic);
                           
                        }
                    }
                    return respon;
                    
                }
                else
                {
                    return "{\"successcode\":\"F\",\"errorcode\":0,\"info\":\"原始币余额不足\"}";
                }
            }
            else
            {
                 return "{\"successcode\":\"F\",\"errorcode\":\"1\",\"info\":\"该功能正在维护中\"}";
                // return "{\"successcode\":\"F\",\"errorcode\":\"1\",\"info\":\"平台余额不足，该功能已暂停使\"}";
            }
        }
        /// <summary>
        /// 添加本地订单
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public int OrderHandle(Dictionary<string, object> dic, Dictionary<string, object> dic1)
        {
            int result = 0;
            string depdate=null;
            try
            {
                lgk.Model.tb_TicketOrder order = new lgk.Model.tb_TicketOrder();
                lgk.Model.tb_Passengers orderdateil = new lgk.Model.tb_Passengers();
                Dictionary<string, object> travelsheet = Util.JsonToDictionary(dic["travelsheet"].ToString());//travelsheet对象
                Dictionary<string, object> contact = Util.JsonToDictionary(dic["contact"].ToString());//contact对象
                Dictionary<string, object> segments = Util.JsonToDictionary(dic["segments"].ToString());//segments对象
                List<Dictionary<string, object>> passengers = Util.JsonToDictionaryList(dic["passengers"].ToString());//passengers对象
                foreach (var item in contact)
                {
                    if (dic.ContainsKey(item.Key) == false)
                    {
                        dic.Add(item.Key, item.Value);
                    }
                }
                foreach (var item in travelsheet)
                {
                    if (dic.ContainsKey(item.Key)==false)
                    {
                        dic.Add(item.Key, item.Value);
                    }
                }
               
                foreach (var item in segments)
                {
                    if (item.Key == "depdate")
                    {
                        depdate = item.Value.ToString();
                    }
                    if (item.Key == "deptime")
                    {
                        dic.Add(item.Key, depdate + " " + item.Value);
                    }
                    if (item.Key == "arrtime")
                    {
                        dic.Add(item.Key, depdate + " " + item.Value);
                        //key = Convert.ToDateTime(depdate + " " + item.Value);
                    }
                    if (item.Key.Equals("prices"))
                    {
                        var prices = (Dictionary<string, object>)item.Value;
                        foreach (var item1 in prices)
                        {
                            if (dic.ContainsKey(item1.Key) == false)
                            {
                                dic.Add(item1.Key, item1.Value);
                            }
                        }
                    }
                    else
                    {
                        if (dic.ContainsKey(item.Key) == false)
                        {
                            dic.Add(item.Key, item.Value);
                        }
                    }
                }
                //给tb_TicketOrder实体赋值
                System.Reflection.PropertyInfo[] properties = order.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (System.Reflection.PropertyInfo item in properties)
                {
                    foreach (var item1 in dic)
                    {
                        object key = null;
                        if (item.Name.ToLower().Equals(item1.Key.ToLower()))
                        {
                            if (item.PropertyType.Name == "String")
                            {
                                key = item1.Value.ToString();
                            }
                            if (item.PropertyType.Name == "Int32")
                            {
                                key = Convert.ToInt32(item1.Value);
                            }
                            if (item.PropertyType.Name == "Decimal")
                            {
                                key = Convert.ToDecimal(item1.Value);
                            }
                            if (item.PropertyType.Name == "DateTime")
                            {
                                key = Convert.ToDateTime(item1.Value);
                            }
                            item.SetValue(order, key, null);
                        }
                    }
                }
                order.AddDate = DateTime.Now;
                int uid=ordermodel.Add(order);
                Dictionary<string, object> passenger = new Dictionary<string, object>();//segments对象
                //给tb_Passengers实体赋值
                System.Reflection.PropertyInfo[] prssproperties = orderdateil.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                for (int i = 0; i < passengers.Count; i++)
                {
                    foreach (var item in passengers[i])
                    {
                        if (passenger.ContainsKey(item.Key))
                        {
                            passenger[item.Key] = item.Value;
                        }
                        else
                        {
                            passenger.Add(item.Key, item.Value);
                        }
                    }
                     
                    foreach (System.Reflection.PropertyInfo item in prssproperties)
                    {
                        foreach (var item1 in passenger)
                        {
                            object key = null;
                           
                            if (item.Name.ToLower().Equals(item1.Key.ToLower()))
                            {
                                //dic2["deptime"] = dic["depdate"] + " " + dic["deptime"];
                                //dic2["arrtime"] = dic["depdate"] + " " + dic["arrtime"];
                                
                                if (item.PropertyType.Name == "String")
                                {
                                    key = item1.Value.ToString();
                                }
                                if (item.PropertyType.Name == "Int32")
                                {
                                    key = Convert.ToInt32(item1.Value);
                                }
                                if (item.PropertyType.Name == "Decimal")
                                {
                                    key = Convert.ToDecimal(item1.Value);
                                }
                                if (item.PropertyType.Name == "DateTime")
                                {
                                    key = Convert.ToDateTime(item1.Value);
                                }
                                item.SetValue(orderdateil, key, null);
                            }
                        }
                    }
                    orderdateil.OrderID = uid;
                    passengmodel.Add(orderdateil);
                }
               
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }
        public Dictionary<string, object> getProperties<T>(T t)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (t == null)
            {
                return dic;
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return dic;
            }
            
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    dic.Add(name, value);
                }
                else
                {
                    getProperties(value);
                }
            }
            return dic;
        }
        public string Bonus(lgk.Model.tb_user usermodel, decimal price)
        {
            try
            {
                usermodel.Emoney = usermodel.Emoney - price;
                userBLL.Update(usermodel);
                string bramk="订购飞机票扣除原始币"+price;
                JournalAdd(usermodel.UserID, bramk, 2, price);
                return "success";
            }
            catch (Exception)
            {

                return "error";
            }

        }
        #endregion
        #region 账户记录
        /// <summary>
        /// 账户记录
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="breakm"></param>
        /// <param name="type">1 增加 2-减少</param>
        /// <returns></returns>
        public bool JournalAdd(long userid,string breakm,int type,decimal price)
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
        #region 自动支付
        /// <summary>
        /// 自动支付
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public string PaySubmit(Dictionary<string, object> dic, string loacthpaypwd)
        {
            //提交订单到接口
            lgk.BLL.tb_TicketOrder bllorder = new lgk.BLL.tb_TicketOrder();
            lgk.Model.tb_TicketOrder model = bllorder.GetModel("OrdeID='" + dic["orderno"].ToString() + "'");
            var usermodel = userBLL.GetModel(model.UserID);
            if (usermodel.IsLock == 1)
            {
                return "{\"successcode\":\"F\",\"errorcode\":\"1\",\"info\":\"账户已冻结，提交失败\"}";  
            }
            if (usermodel.SecondPassword.Equals(loacthpaypwd))
            {

                if (usermodel.Emoney < model.PayPrice)
                {
                    return "{\"successcode\":\"F\",\"errorcode\":\"1\",\"info\":\"原始币余额不足\"}";
                }
                else
                {
                    string respon = RequestSumit(dic, "autopayvm");
                    if (respon != "error")
                    {
                        var Result = JsonConvert.DeserializeObject<respondTicketResult>(respon);
                        if (Result.successcode == "T")
                        {
                            //更新订单状态
                            if (ordermodel.UpdateStatus(Convert.ToInt32(Result.result.orderstatus), Convert.ToInt32(Result.result.paystatus), Result.result.orderno))
                            {
                                //扣除原始币
                                string bonus = Bonus(usermodel, model.PayPrice);
                                //扣除原始币账户 第三方账户
                                bllaccount.UpdateBanlcen("TicketAccount", model.PayPrice, 1);
                                return respon;
                            }
                            else
                            {
                                return "{\"successcode\":\"F\",\"errorcode\":\"1\",\"info\":\"更新本地订单状态失败，请联系平台\"}";
                            }
                        }
                        else
                        {
                            return respon;
                        }
                    }
                    else
                    {
                        return "{\"successcode\":\"F\",\"errorcode\":\"1\",\"info\":\"请求支付失败\"}";
                    }
                }
            }
            else
            {

                return "{\"successcode\":\"F\",\"errorcode\":\"1\",\"info\":\"支付密码不正确\"}";
            }
        }
        #endregion 
        #region 取消订单
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public string Cancel(Dictionary<string, object> dic)
        {
            string respon = RequestSumit(dic, "ordercancel");
            if (respon != "error")
            {
                var Result = JsonConvert.DeserializeObject<respondTicketResult>(respon);
                if (Result.successcode == "T")
                {
                    lgk.Model.tb_TicketOrder tickmodel = ordermodel.GetModel("OrdeID='" + dic["orderno"].ToString() + "'");
                    if (tickmodel.PayStatus == 1)
                    {
                        //取消订单返还账户金额
                        lgk.Model.tb_user model = userBLL.GetModel(tickmodel.UserID);
                        model.Emoney += tickmodel.TicketPrice + 20;
                        userBLL.Update(model);
                        string bramk = "取消订单" + tickmodel.OrdeID + "，返回原始币：" + tickmodel.TicketPrice;
                        JournalAdd(tickmodel.UserID, bramk, 1, tickmodel.TicketPrice);
                    }
                    //更新订单状态
                    ordermodel.UpdateStatus(10, 2, dic["orderno"].ToString());
                    return respon;
                }
                return respon;
            }
            else
            {
                return "{\"successcode\":\"F\",\"errorcode\":\"1\",\"info\":\"请求接口异常，请重试或联系接口商\"}";
            }
        }
        #endregion
        #region 封装请求参数
        /// <summary>
        /// 封装请求参数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Dictionary<string, object> ParmsPath(string type)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();

            switch (type.ToLower())
            {
                case "getfligtlistweb"://机票查询接口
                    dic.Add("action", "");
                    dic.Add("depdate", "");
                    dic.Add("depcity", "");
                    dic.Add("arrcity", "");
                    dic.Add("aircode", "");
                    break;
                case "createorder"://提交订单
                    dic.Add("action", "");
                    dic.Add("passengers", "");
                    dic.Add("segments", "");
                    dic.Add("contact", "");
                    dic.Add("travelsheet", "");
                    break;
                case "ordercancel"://取消订单
                    dic.Add("action", "");
                    dic.Add("orderno", "");
                    break;
                case "webrefundapply"://取消订单(退票)
                    dic.Add("action", "");
                    dic.Add("orderno", "");
                    dic.Add("type", "");
                    dic.Add("flights", "");
                    dic.Add("passengers", "");
                    dic.Add("refundfiles", "");
                    dic.Add("refundmemo", "");
                    break;
                case "getorder"://订单查询
                    dic.Add("action", "");
                    dic.Add("orderno", "");
                    break;
                case "getwebrefundinfo"://查询退票接口
                    dic.Add("action", "");
                    dic.Add("orderid", "");
                    dic.Add("type", "");
                    dic.Add("sign", "");
                    break;
                
                case "refund"://改签申请
                    dic.Add("action", "");
                    dic.Add("orderid", "");
                    dic.Add("type", "");
                    dic.Add("oldflight", "");
                    dic.Add("alterflight", "");
                    dic.Add("alterdate", "");
                    dic.Add("passengers", "");
                    dic.Add("altermemo", "");
                    dic.Add("sign", "");
                   
                    break;
                case "getwebalterinfo"://查询改签订单
                    dic.Add("action", "");
                    dic.Add("orderno", "");
                    dic.Add("sign", "");
                    
                    break;
                case "getinsuranceproducts"://保险产品列表查询
                    dic.Add("action", "");
                    dic.Add("type", "");
                    
                    break;
                case "getexpressinfo"://快递列表
                    dic.Add("action", "");
                    dic.Add("sign", "");
                   
                    break;
                case "autopayvm"://自动支付
                    dic.Add("action", "");
                    dic.Add("orderno", "");
                    //dic.Add("paypwd", "");
                    break;
                
                default:
                    break;
            }
            return dic;
        }
        #endregion
        public string ReplceStr(string str)
        {
            str = str.Replace("\\", "").Replace("\"[", "[").Replace("]\"", "]").Replace("\"{", "{").Replace("}\"", "}");
            return str;
        }
    }
    public class param
    {
        public string action { set; get; }
        public string companycode { set; get; }
        public string key { set; get; }
        public List<querypassengers> passengers { set; get; }
    }
    public class QueryRespon
    {
        public string successcode { set; get; }
        public string errorcode { set; get; }
        public string info { set; get; }
        public queryresult result { set; get; }
       

    }
    public class queryresult
    {
        public string orderno { set; get; }
        public string pnr { set; get; }
        public string createtime { set; get; }
        public string paytime { set; get; }
        public string totalprice { set; get; }
        public string orderstatus { set; get; }
        public string linkman { set; get; }
        public string linktel { set; get; }
        public List<flights> flights { set; get; }
        public prices prices { set; get; }
        public List<querypassengers> passengers { set; get; }
    }
    public class flights {
        public string flight { set; get; }
        public string aircode { set; get; }
        public string airname { set; get; }
        public string depcity { set; get; }
        public string depcityname { set; get; }
        public string depairport { set; get; }
        public string depterminal { set; get; }
        public string arrcity { set; get; }
        public string arrcityname { set; get; }
        public string arrairport { set; get; }
        public string arrterminal { set; get; }
        public string cabin { set; get; }
        public string deptime { set; get; }
        public string arrtime { set; get; }
        public string refundrule { set; get; }
        public string modifyrule { set; get; }
        public string updaterule { set; get; }
    }
    public class prices
    {
        public string fare{set;get;}
        public string ticketprice{set;get;}
        public string totalfax{set;get;}
    }
    public class querypassengers
    {
        public string name { set; get; }
        public string mantype { set; get; }
        public string idtype { set; get; }
        public string idnumber { set; get; }
        public string birthday { set; get; }
        public string ticketnumber { set; get; }
        public string insurancenum { set; get; }
    }
}