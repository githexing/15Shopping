using Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService.Service
{
    public class MobileRechargeService : AllCore
    {
        WebUtils _webUtils = new WebUtils();
        lgk.BLL.tb_PhoneOrder phor = new lgk.BLL.tb_PhoneOrder();
        lgk.BLL.tb_PhoneAmcount phoramount = new lgk.BLL.tb_PhoneAmcount();
        lgk.BLL.tb_Account bllaccount = new lgk.BLL.tb_Account();
        private string telcheckUrl = "http://op.juhe.cn/ofpay/mobile/telcheck";//检测手机号码是否能充值
        private string telqueryUrl = "http://op.juhe.cn/ofpay/mobile/telquery";//根据手机号和面值查询商品
        private string onlineorderUrl = "http://op.juhe.cn/ofpay/mobile/onlineorder";//手机直充接口
        private string orderstaUrl = "http://op.juhe.cn/ofpay/mobile/ordersta";//订单状态查询
        private string AppKey = "bcbe99f955a56e2315cc9179b786eecd";
        private string OpenID = "JH2434d1068d85ad1485a3d90b62b14af2";
        public string RequestSumit(Dictionary<string, string> dic1, string url, string typename)
        {
            string s = "\r\n" + "\r\n" + "\r\n" + "\r\n" + typename + ":记录时间" + DateTime.Now.ToString() + "\r\n";
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
        public bool RequestBegin(Dictionary<string, string> dic,out object msg)
        {
            string act = dic["act"].ToLower();
            Dictionary<string, string> dic1 = ParmsPath(act);
            Dictionary<string, string> dic2 = new Dictionary<string, string>();
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
            
            if (act.Equals("onlineorder"))
            {
                return OnlineOrder(act, dic1, dic2,out msg);
            }
            else if (act.Equals("orderinfo"))
            {
                msg = OrderInfo(dic2);
                return true;
            }
            else if (act.Equals("ordercash"))
            {
                msg = OrderCash();
                return true;
            }
            else
            {
                msg = RequestSumit(dic2, dic1["RequestUrl"].ToString(), act);
                return true;
            }
        }
        #region 充值订单处理
        /// <summary>
        /// 充值订单处理
        /// </summary>
        /// <param name="act"></param>
        /// <param name="dic1"></param>
        /// <param name="dic2"></param>
        /// <returns></returns>
        private bool OnlineOrder(string act, Dictionary<string, string> dic1, Dictionary<string, string> dic2,out object msg)
        {
            long _userid;
            long.TryParse(dic2["userid"].ToString(), out _userid);
            decimal allprice = Convert.ToDecimal(dic2["cardnum"].ToString());
            var user = userBLL.GetModel(_userid);
            decimal banlcen = bllaccount.BanlceAcount("PhoneAccount");
            if(banlcen>= allprice)
            {
                if (user == null)
                {
                    msg = "用户不存在";
                    return false;
                }
                if (!ValidPassword(user.SecondPassword, dic2["paypassword"].ToString()))
                {
                    msg = "支付密码错误";
                    return false;
                }
                
                if (user.IsLock == 1)
                {
                    msg = "账户已冻结，话费充值失败";
                    return false;
                }

                lgk.Model.tb_user usermodel = userBLL.GetModel(Convert.ToInt32(dic2["userid"].ToLower()));
                if(allprice > usermodel.Emoney)
                {
                    msg = "原始币不足";
                    return false;
                }
               
                dic2.Add("orderid", Util.CreateNo());//订单编号
                string sign = OpenID + AppKey + dic2["phoneno"].ToString().Trim() + dic2["cardnum"].ToString().Trim() + dic2["orderid"].ToString().Trim();
                dic2.Add("sign", Util.SignTopRequest(sign));//签名
                string respon = RequestSumit(dic2, dic1["RequestUrl"].ToString(), act);
                if (respon != "error")
                {
                    var Result = JsonConvert.DeserializeObject<RespondResult>(respon);
                    if (Result.result != null)
                    {
                        lgk.Model.tb_PhoneOrder model = new lgk.Model.tb_PhoneOrder();
                        model.PhoneNO = dic2["phoneno"].ToString().Trim();
                        model.State = Convert.ToInt32(Result.result.game_state);
                        model.CardNum = Convert.ToInt32(Result.result.cardnum);
                        model.OrderCash = allprice.ToString();//充值金额
                        model.UorderID = dic2["orderid"].ToString().Trim();
                        model.SporderID = Result.result.sporder_id;
                        model.AddDate = DateTime.Now;
                        model.UserID = Convert.ToInt32(dic2["userid"].ToString().Trim());
                        phor.Add(model);
                        Bonus(usermodel, allprice);
                        //扣除释放币金额
                        bllaccount.UpdateBanlcen("PhoneAccount", allprice, 1);
                    }
                    else
                    {
                        msg = CheckCode(Result.error_code);
                        return false;
                    }
                    msg = Result;
                    return true;
                }
                else
                {
                    msg = "error";
                    return true;
                }
            }
            else
            {
                msg = "该功能正在维护中";
                //msg = "平台余额不足，该功能已暂停使用";
                return false;
            }
        }
        public string Bonus(lgk.Model.tb_user usermodel, decimal price)
        {
            try
            {
                usermodel.Emoney = usermodel.Emoney - price;
                userBLL.Update(usermodel);
                lgk.Model.tb_journal jounlmodel = new lgk.Model.tb_journal();
                jounlmodel.UserID = usermodel.UserID;
                jounlmodel.Remark = "充值话费扣除原始币：" + price;
                jounlmodel.OutAmount = price;
                jounlmodel.InAmount = 0;
                jounlmodel.JournalDate = DateTime.Now;
                jounlmodel.JournalType = 1;
                jounlmodel.BalanceAmount = userBLL.GetBonusAccount(usermodel.UserID);
                journalBLL.Add(jounlmodel);
                
                return "success";
            }
            catch (Exception)
            {

                return "error";
            }

        }
        /// <summary>
        #endregion
        #region 查询订单列表(本地订单)
        /// <summary>
        /// 查询订单列表
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public List<lgk.Model.tb_PhoneOrder> OrderInfo(Dictionary<string, string> dic)
        {
          //  string respon = "{\"reason\":";
            //try
            //{
                string strWhere = "UserID=" + dic["userid"].ToString();
            
                if (dic.Where(s => s.Key.Equals("phoneno")).Count() > 0 )
                {
                    if (!string.IsNullOrEmpty(dic["phoneno"].ToString()))
                        strWhere += " and PhoneNO='" + dic["phoneno"].ToString() + "'";
                }
                if (dic.Where(s => s.Key.Equals("uorderid")).Count() > 0 )
                {
                    if(!string.IsNullOrEmpty(dic["uorderid"].ToString()))
                        strWhere += " and UorderID='" + dic["uorderid"].ToString() + "'";
                }
                List<lgk.Model.tb_PhoneOrder> list = phor.GetModelList(strWhere).OrderByDescending(s=>s.AddDate).ToList();
                return list;
                //if (list.Count > 0)
                //{
                //    respon += "\"查询成功\",\"data\":[";
                //    for (int i = 0; i < list.Count; i++)
                //    {
                //        respon += "{\"PhoneNO\":\"" + list[i].PhoneNO + "\",\"CardNum\":" + list[i].CardNum + ",\"UserID\":" + list[i].UserID + ",\"UorderID\":\"" + list[i].UorderID + "\",\"State\":" + list[i].State + ",\"AddDate\":\"" + list[i].AddDate + "\"}";
                //        if (i < list.Count - 1)
                //        {
                //            respon += ",";
                //        }
                //    }
                //    respon += "],\"error_code\":0";
                //}
                //else
                //{
                //    respon += "\"没有订单\",\"error_code\":19000";
                //}
            //}
            //catch (Exception e)
            //{

            //    respon += "\"系统异常，异常信息\",\"error_code\":10014";
            //}
            //respon += "}";
            //return respon;
        }
        #endregion
        #region 充值面额查询
        /// <summary>
        /// 充值面额查询
        /// </summary>
        /// <returns></returns>
        public List<lgk.Model.tb_PhoneAmcount> OrderCash()
        {
            List<lgk.Model.tb_PhoneAmcount> list = phoramount.GetModelList("State = 0");
            return list;
            //string respon = "{\"reason\":";
            //try
            //{
            //    List<lgk.Model.tb_PhoneAmcount> list = phoramount.GetModelList("");
            //    if (list.Count > 0)
            //    {
                    
            //        respon += "\"查询成功\",\"data\":[";
            //        for (int i = 0; i < list.Count; i++)
            //        {
            //            respon += "{\"Amcount\":" + list[i].Amcount + ",\"State\":" + list[i].State + "}";
            //            if (i < list.Count - 1)
            //            {
            //                respon += ",";
            //            }
            //        }
            //        respon += "],\"error_code\":0";
            //    }
            //    else
            //    {
            //        respon += "\"没有数据\",\"error_code\":19000";
            //    }
            //}
            //catch (Exception e)
            //{

            //    respon += "\"系统异常，异常信息\",\"error_code\":10014";
            //}
            //respon += "}";
            //return respon;
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
                case "telcheck"://检测手机号码是否能充值
                    dic.Add("phoneno", "");
                    dic.Add("cardnum", "");
                    dic.Add("RequestUrl", telcheckUrl);
                    break;
                case "telquery"://根据手机号和面值查询商品
                    dic.Add("phoneno", "");
                    dic.Add("cardnum", "");
                    dic.Add("RequestUrl", telqueryUrl);
                    break;
                case "onlineorder"://手机直充接口
                    dic.Add("phoneno", "");
                    dic.Add("cardnum", "");
                    dic.Add("uorderid", "");
                    dic.Add("RequestUrl", onlineorderUrl);
                    dic.Add("paypassword", "");
                    dic.Add("userid", "");
                    break;
                case "ordersta"://订单状态查询
                    dic.Add("orderid", "");
                    dic.Add("RequestUrl", orderstaUrl);
                    break;
                case "orderinfo"://订单列表查询
                    dic.Add("userid", "");
                    dic.Add("phoneno", "");
                    dic.Add("uorderid", "");
                    break;
                case "ordercash"://订单列表查询
                    break;
                default:
                    break;
            }
            return dic;
        }
        #endregion
        #region 返回代码
        /// <summary>
        /// 错误代码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string CheckCode(string code)
        {
            string result = "";
            switch (code)
            {
                case "208501":
                    result = "不允许充值的手机号码及金额";
                    break;
                case "208502":
                    result = "请求手机号和面值查询商品信息失败，请重试";
                    break;
                case "208503":
                    result = "运营商地区维护，暂不能充值";
                    break;
                case "208504":
                    result = "请求手机号和面值查询商品信息错误";
                    break;
                case "208505":
                    result = "错误的手机号码";
                    break;
                case "208506":
                    result = "错误的充值金额";
                    break;
                case "208507":
                    result = "充值失败";
                    break;
                case "208508":
                    result = "请求充值失败，请重试";
                    break;
                case "208509":
                    result = "错误的订单号";
                    break;
                case "208510":
                    result = "请求订单状态失败";
                    break;
                case "208513":
                    result = "查询订单失败";
                    break;
                case "208514":
                    result = "不合规范的订单号（8-32位）";
                    break;
                case "208515":
                    result = "校验值sign错误";
                    break;
                case "208516":
                    result = "重复的订单号";
                    break;
                case "208517":
                    result = "当前账户可用余额不足";
                    break;
                case "10001":
                    result = "错误的请求KEY";
                    break;
                case "10002":
                    result = "该KEY无请求权限";
                    break;
                case "10003":
                    result = "KEY过期";
                    break;
                case "10004":
                    result = "错误的OPENID";
                    break;
                case "10005":
                    result = "应用未审核超时，请提交认证";
                    break;
                case "10007":
                    result = "未知的请求源";
                    break;
                case "10008":
                    result = "被禁止的IP";
                    break;
                case "10009":
                    result = "被禁止的KEY";
                    break;
                case "10011":
                    result = "当前IP请求超过限制";
                    break;
                case "10012":
                    result = "请求超过次数限制";
                    break;
                case "10013":
                    result = "测试KEY超过请求限制";
                    break;
                case "10014":
                    result = "系统内部异常";
                    break;
                case "10020":
                    result = "接口维护";
                    break;
                case "10021":
                    result = "接口停用";
                    break;
                case "19000":
                    result = "没有订单";
                    break;
                default:
                    result = "success";
                    break;
            }
            return result;
        }
        #endregion
    }
}