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
    /// MobileRecharge 的摘要说明
    /// </summary>
    public class MobileRecharge : ServiceHandler
    {
        MobileRechargeService tts = new MobileRechargeService();
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string train = context.Request["act"];
            string result = string.Empty;
            if (string.IsNullOrEmpty(train) || train.Trim() == string.Empty)
            {
                return;
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
            try
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                for (int i = 0; i < context.Request.Params.Count; i++)
                {
                    dic.Add(context.Request.Params.Keys[i].ToString(), context.Request.Params[i].ToString());//将请求参数添加到Dictionary<string, string>用作接口参数的遍历赋值
                }
                object responresult;
                bool result = tts.RequestBegin(dic,out responresult);

                LogHelper.SaveLog(ResultJson(ResultType.success, "log", responresult), "mobile");
                
                if (responresult.ToString() != "error")
                {
                  //  var emResult = responresult;// JsonConvert.DeserializeObject<respondPhoneResult>(responresult.ToString());
                    //string result = CheckCode(emResult.error_code);
                   // if (result.Equals("success"))
                   if(result)
                        return ResultJson(ResultType.success, "执行成功", responresult);
                   else 
                        return ResultJson(ResultType.error, responresult.ToString(), "");
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

    }
    public class respondPhoneResult
    {
        public string reason { set; get; }
        public string error_code { set; get; }
        public List<data> data { set; get; }
    }
    public class data
    {
        public string PhoneNO { set; get; }
        public string CardNum { set; get; }
        public string UserID { set; get; }
        public string UorderID { set; get; }
        public string State { set; get; }
        public string AddDate { set; get; }
        public string Amcount { set; get; }
    }
}