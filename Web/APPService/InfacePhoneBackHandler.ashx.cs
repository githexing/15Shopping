using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    /// <summary>
    /// InfacePhoneBackHandler 的摘要说明
    /// </summary>
    public class InfacePhoneBackHandler : IHttpHandler
    {
        public lgk.BLL.tb_PhoneOrder orderBLL = new lgk.BLL.tb_PhoneOrder();
        lgk.BLL.tb_Account bllaccount = new lgk.BLL.tb_Account();
        lgk.BLL.tb_user userBLL = new lgk.BLL.tb_user();
        lgk.BLL.tb_journal journalBLL = new lgk.BLL.tb_journal();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string s = "\r\n" + "\r\n" + "\r\n" + "\r\n" + "记录时间" + DateTime.Now.ToString() + "\r\n";
            try
            {

                context.Response.ContentType = "text/plain";
                string sporder_id = context.Request["sporder_id"];
                string orderid = context.Request["orderid"];
                string sta = context.Request["sta"];
                string sign = context.Request["sign"];
                string err_msg = context.Request["err_msg"];
                s = s + "接受内容信息:聚合订单号：" + sporder_id + "，本地订单号："+ orderid + ",订单状态："+ sta + ",签名："+ sign + "\r\n";
                //var emResult = JsonConvert.DeserializeObject<data>(data);
                if (!string.IsNullOrEmpty(sporder_id))
                {
                    lgk.Model.tb_PhoneOrder Modelreback = orderBLL.GetModel(" SporderID='" + sporder_id + "'");
                    if (Modelreback != null)
                    {
                        //if()
                        Modelreback.State = Convert.ToInt32(sta);
                        orderBLL.Update(Modelreback);
                        //充值失败处理
                        if (sta == "9")
                        {
                            lgk.Model.tb_user model = userBLL.GetModel(Modelreback.UserID);
                            model.Emoney += Convert.ToDecimal(Modelreback.OrderCash);
                            userBLL.Update(model);
                            string bramk = "充值失败" + Modelreback.UorderID + "，返回原始币：" + Modelreback.OrderCash;
                            JournalAdd(Modelreback.UserID, bramk, 1, Convert.ToDecimal(Modelreback.OrderCash));
                            bllaccount.UpdateBanlcen("PhoneAccount", Convert.ToDecimal(Modelreback.OrderCash), 2);
                        }
                        context.Response.Write("success");
                    }
                    else
                    {
                        s = s + "订单不存在\r\n";
                        context.Response.Write("订单不存在");
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
                s = s + "回调异常，错误信息" + ex.Message + "\r\n";
                context.Response.Write("回调异常，错误信息" + ex.Message);
            }
            System.IO.File.AppendAllText(context.Server.MapPath("~/log/RequestPhoneBacklog/RequestPhoneBacklog" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".txt"), s);
        }
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
            jounlmodel.JournalType = 2;
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
}