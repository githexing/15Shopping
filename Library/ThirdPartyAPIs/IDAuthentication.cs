using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Library.ThirdPartyAPIs
{
    /// <summary>
    /// 身份证验证接口
    /// </summary>
    public class IDAuthentication
    {
        public IDAuthentication() { }

        private JavaScriptSerializer jss = new JavaScriptSerializer();

        private string appkey = "ebdfc719180a4788c6b8dc099b41b42f";

        public string AuthenticationIDAndName(string IDCard, string RealName)
        {
            string strswitch = System.Configuration.ConfigurationManager.AppSettings["IDCARD_SWITCH"];
            if (strswitch == "OPEN")
            {
                string postUrl = "http://op.juhe.cn/idcard/query";
                string nameEncode = HttpUtility.UrlEncode(RealName, Encoding.UTF8);

                //IDictionary<string, string> param = new Dictionary<string, string>();
                //param.Add("key", appkey);
                //param.Add("idcard", IDCard);
                //param.Add("realname", nameEncode);
                //string resultjson = WEBRequest.sendPost(postUrl, param, "post");

                string jsonData = "key=" + appkey + "&idcard=" + IDCard + "&realname=" + RealName + "&sign=";
                byte[] postData = Encoding.UTF8.GetBytes(jsonData);
                string resultjson = "[" + WEBRequest.Request(postData, postUrl) + "]";
                LogHelper.SaveLog(resultjson, "IDCardAuthen");
                ReturnMsg model = new JavaScriptSerializer().Deserialize<List<ReturnMsg>>(resultjson).FirstOrDefault();
                if (model.error_code == "0")
                {
                    return "success";
                }
                else
                {
                    string resultmsg = GetError_CodeMsg(model.error_code);
                    LogHelper.SaveLog(resultmsg, "IDAuthentication");
                    return resultmsg;
                }
            }
            else
            {
                return "success";
            }
            
        }

        #region 错误代码内容
        /// <summary>
        /// 错误代码内容
        /// </summary>
        /// <param name="error_code"></param>
        /// <returns></returns>
        public string GetError_CodeMsg(string error_code)
        {
            string message = "";

            switch (error_code)
            {
                //系统级错误
                case "10001":
                    message = "错误的请求KEY";
                    break;
                case "10002":
                    message = "该KEY无请求权限";
                    break;
                case "10003":
                    message = "KEY过期";
                    break;
                case "10004":
                    message = "错误的OPENID";
                    break;
                case "10005":
                    message = "应用未审核超时，请提交认证";
                    break;
                case "10007":
                    message = "未知的请求源";
                    break;
                case "10008":
                    message = "被禁止的IP";
                    break;
                case "10009":
                    message = "被禁止的KEY";
                    break;
                case "10011":
                    message = "当前IP请求超过限制";
                    break;
                case "10012":
                    message = "请求超过次数限制";
                    break;
                case "10013":
                    message = "测试KEY超过请求限制";
                    break;
                case "10014":
                    message = "系统内部异常(调用充值类业务时，请务必联系客服或通过订单查询接口检测订单，避免造成损失)";
                    break;
                case "10020":
                    message = "接口维护";
                    break;
                case "10021":
                    message = "接口停用";
                    break;
                //服务器级错误码
                case "210301":
                    message = "库中无此身份证记录";
                    break;
                case "210302":
                    message = "第三方服务器异常";
                    break;
                case "210303":
                    message = "服务器维护";
                    break;
                case "210304":
                    message = "参数异常";
                    break;
                case "210305":
                    message = "网络错误，请重试";
                    break;
                case "210306":
                    message = "数据源错误，具体参照reason";
                    break;
                case "210307":
                    message = "sign错误";
                    break;
            }

            return message;
        } 
        #endregion

    }

    public class ReturnMsg
    {
        public string error_code { get; set; }
        public string reason { get; set; }
        public ResultModel result { get; set; }
       
       
    }
    public class ResultModel
    {
        public string realname { get; set; }
        public string idcard { get; set; }
        public string res { get; set; }/*1：匹配 2：不匹配*/
    }

}
