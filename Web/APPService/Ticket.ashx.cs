using Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// Ticket 的摘要说明
    /// </summary>
    public class Ticket : ServiceHandler
    {
        TicketService tts = new TicketService();
        lgk.BLL.tb_TicketCity city = new lgk.BLL.tb_TicketCity();
      
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string train = context.Request["act"];
            string result = string.Empty;
            if (string.IsNullOrEmpty(train) || train.Trim() == string.Empty)
            {
                return;
            }
            else if (train.Equals("QueryCity"))
            {
                QueryCity(context);
            }
            else
            {
                result = RespondHandle(context);
            }

            context.Response.Write(result);
        }
        #region 处理接口请求响应数据
        /// <summary>
        /// 处理接口请求响应数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string RespondHandle(HttpContext context)
        {
            var emResult = new respondTicketResult();
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                for (int i = 0; i < context.Request.Params.Count; i++)
                {
                    dic.Add(context.Request.Params.Keys[i].ToString(), context.Request.Params[i].ToString());//将请求参数添加到Dictionary<string, string>用作接口参数的遍历赋值
                }
                string responresult = tts.RequestBegin(dic);
                if (responresult != "error")
                {
                    return ResultJson(ResultType.success, "执行成功", responresult);
                    //if (dic["getinsuranceproducts"].Equals("getinsuranceproducts"))
                    //{
                    //    emResult = new BxrespondTicketResult();
                    //    emResult = JsonConvert.DeserializeObject<BxrespondTicketResult>(responresult);
                    //}
                    //else
                    //{
                    //    emResult = new respondTicketResult();
                    //    emResult = JsonConvert.DeserializeObject<respondTicketResult>(responresult);
                    //}
                    //if (emResult.successcode.Equals("T"))
                    //    return ResultJson(ResultType.success, "执行成功", responresult);
                    //else
                    //    return ResultJson(ResultType.success, "执行成功", responresult);
                }
                else
                {
                    return ResultJson(ResultType.error, "执行失败", responresult);
                }
            }
            catch (Exception ex)
            {

                return ResultJson(ResultType.error, "执行失败", "系统异常，异常信息：" + ex.Message);
            }

            //return result;
        }
        #endregion
        #region 选择城市
        /// <summary>
        /// 选择城市
        /// </summary>
        /// <param name="context"></param>
        public void QueryCity(HttpContext context)
        {
            try
            {
                string query = context.Request["query"].ToString().Trim();
                string rm = context.Request["str"].ToString().Trim();
                if (rm.Equals("热门"))
                {
                    context.Response.Write("[{\"city\":\"北京\",\"code\":\"BJS\"},{\"city\":\"上海\",\"code\":\"SHA\"},{\"city\":\"成都\",\"code\":\"CTU\"},{\"city\":\"重庆\",\"code\":\"CKG\"},{\"city\":\"广州\",\"code\":\"CAN\"}]");
                }
                else
                {
                    string str = "[";
                    List<lgk.Model.tb_TicketCity> model = city.GetModelList(query);//"Code like '[" + query + "]%'"
                    if (model.Count > 0)
                    {
                        for (int i = 0; i < model.Count; i++)
                        {
                            str += "{\"name\":\"" + model[i].Name + "\",\"code\":\"" + model[i].Code + "\",\"city\":\"" + model[i].City + "\"}";
                            if (i != model.Count - 1)
                            {
                                str += ",";
                            }
                        }
                        str += "]";
                        context.Response.Write(str);
                    }
                    else
                    {
                        context.Response.Write("[{\"name\":\"没有找到相关数据\",\"code\":\"NONE\"}]");
                    }
                }
            }
            catch (Exception)
            {
                context.Response.Write("[{\"name\":\"没有找到相关数据\",\"code\":\"NONE\"}]");
            }
        }
        #endregion

    }
    public class respondTicketResult
    {
        public string successcode { set; get; }
        public string errorcode { set; get; }
        public string info { set; get; }
        public Ticketresult result { set; get; }
      
    }
    public class BxrespondTicketResult
    {
        public string successcode { set; get; }
        public string errorcode { set; get; }
        public string info { set; get; }
        public List<BXTicketresult> result { set; get; }

    }
    public class BXTicketresult
    {
        public string id { set; get; }
        public string name { set; get; }
        public string remark { set; get; }
        public string price { set; get; }
    }
    public class Ticketresult
    {
        public string orderno { set; get; }
        public string pnr { set; get; }
        public string payprice { set; get; }
        public string totaltax { set; get; }
        public string ticketprice { set; get; }
        public string policynum { set; get; }
        public string postprice { set; get; }
        public string insuranceprice { set; get; }
        public string totalpay { set; get; }
        public string paystatus { set; get; }
        public string orderstatus { set; get; }
        public string paytime { set; get; }
    }
}