using System;
using System.Collections.Generic;
using System.Text;
//添加命名空间
using System.Net.Mail;
using System.Net;
using System.Data;
using DataAccess;
using System.Xml;
using System.IO;
using System.Web.Script.Serialization;
using System.Configuration;

namespace Library
{
    /**/

    /// <summary>
    /// 发送短信类
    /// </summary>
    public class SMSHelper
    {
        #region 短信接口1
        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="PhoneNum"></param>
        /// <returns></returns>
        public static int SendMessage(string Code, long PhoneNum)
        {
            return SendMessage(Code, PhoneNum,1);
        }
        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="PhoneNum"></param>
        /// <returns></returns>
        public static int SendMessage(string y,string m,string d,string OrderCode, long PhoneNum)
        {
            return SendMessage(y + "," + m + "," + d + "," + OrderCode, PhoneNum, 2);
        }
        /// <summary>
        /// 短信tempCode=1：7350006匹配模版，2：7350005验证码模版
        /// 【中国红】温馨提示，您于{1}年{2}月{3}日提交的订单{4}已匹配成功，请及时进行操作。
        /// 【中国红】验证码为{1}，您正在进行会员注册，请勿将验证码告诉他人
        /// </summary>
        /// <param name="param"></param>
        /// <param name="PhoneNum"></param>
        /// <param name="tempCode"></param>
        /// <returns></returns>
        public static int SendMessage(string param, long PhoneNum, int tempCode)
        {
            string SMS_ACCOUNT_SID = System.Configuration.ConfigurationManager.AppSettings["SMS_ACCOUNT_SID"];
            string SMS_AUTH_TOKEN = System.Configuration.ConfigurationManager.AppSettings["SMS_AUTH_TOKEN"];
            string SoftVersion = System.Configuration.ConfigurationManager.AppSettings["SMS_SoftVersion"];
            string sms_switch = System.Configuration.ConfigurationManager.AppSettings["SMS_SWITCH"];//注册开关
            string smspipei_switch = System.Configuration.ConfigurationManager.AppSettings["SMS_PIPEISWITCH"];//匹配开关
            string emailTemplateId="";
            if(tempCode==2)
            {
                if (sms_switch != "Open") return -1;
                emailTemplateId = System.Configuration.ConfigurationManager.AppSettings["SMS_emailTemplateId"];
            }
            else if(tempCode==1)
            {
                if (smspipei_switch != "Open") return -1;
                emailTemplateId = System.Configuration.ConfigurationManager.AppSettings["SMS_emailTemplateId2"];
            }
            else 
            {
                return 9999;
            }
            string appId = System.Configuration.ConfigurationManager.AppSettings["SMS_appId"];
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            
            string MsgState = string.Empty;

            string PostUrl = "https://dxz.10086gg.cn/{0}/accounts/{1}/SMS/emailSMS?sig={2}&timestamp={3}";
            string sigParameter = Library.SysEncrypt.GetMd5(SMS_ACCOUNT_SID + SMS_AUTH_TOKEN + timestamp).ToLower();

            string jsonParas = "{ \"emailSMS\": {\"appId\": \"" + appId + "\",\"emailTemplateId\":\"" + emailTemplateId + "\",\"to\":\"" + PhoneNum + "\",\"param\":\"" + param + "\"}}";
            //jsonParas = System.Web.HttpUtility.UrlEncode(jsonParas); 

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(jsonParas);
            string url = string.Format(PostUrl, SoftVersion, SMS_ACCOUNT_SID,sigParameter, timestamp);
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/json;";
            myRequest.Accept = "application/json";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string responseData = reader.ReadToEnd();
                Dictionary<String, Object> dic = jss.Deserialize<Object>(responseData) as Dictionary<String, Object>;
                Dictionary<String, Object> ResultMap = dic["result"] as Dictionary<String, Object>;
                //XmlDocument xd = new XmlDocument(); 
                //xd.LoadXml(responseData);
                //XmlNode stateXmlNode = xd.ChildNodes[1].ChildNodes[0];
                string state = ResultMap["respCode"].ToString();
                MsgState = getStatesName(state);

                string sql = string.Format(" INSERT INTO [dbo].[tb_message] ([Userid],[MobileNum],[Mcontent],[Flag])VALUES('{0}','{1}','{2}','{3}')", 0, PhoneNum, MsgState, state);
                DbHelperSQL.GetSingle(sql);
                return int.Parse(state);
            }
            else
            {
                return 9999;
                //访问失败
            }
        }
        /// <summary>
        /// 返回状态名称
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private static string getStatesName(string state)
        { 
            string StatesName=state;
            switch(state)
            {
                case "00000":
                    StatesName="请求成功";
                    break;
                    case "00001":
                    StatesName="系统错误，请联系管理员";
                    break;
                    case "00002":
                    StatesName="未知的方法名";
                    break;
                    case "00003":
                    StatesName="请求方式错误";
                    break;
                    case "00004":
                    StatesName="参数非法，如request parameter (key) is missing";
                    break;
                    case "00005":
                    StatesName="timestamp已过期";
                    break;
                    case "00006":
                    StatesName="sign错误";
                    break;
                    case "00007":
                    StatesName="重复提交";
                    break;
                    case "00008":
                    StatesName="操作频繁";
                    break;
                    case "00011":
                    StatesName="请求的xml格式不对";
                    break;
                    case "00012":
                    StatesName="不支持的请求方式";
                    break;
                    case "00013":
                    StatesName="非法请求";
                    break;
                    case "00015":
                    StatesName="失效请求";
                    break;
                     case "00016":
                    StatesName="请求json格式不对";
                    break;
                     case "00017":
                    StatesName="数据库操作失败";
                    break;
                     case "00018":
                    StatesName="参数为空";
                    break;
                     case "00019":
                    StatesName="订单已存在";
                    break;
                     case "00020":
                    StatesName="用户不存在";
                    break;
                     case "00040":
                    StatesName="用户名或者密码错误";
                    break;
                     case "00031":
                    StatesName="appId为空或者没有传值";
                    break;
                    case "00032":
                    StatesName="主叫号码为空或者没有传值";
                    break;
                    case "00094":
                    StatesName="每批发送的手机号数量不得超过100个";
                    break;
                    case "00095":
                    StatesName="未开通邮件短信功能";
                    break;
                    case "00096":
                    StatesName="邮件模板未审核通过";
                    break;
                    case "00097":
                    StatesName="邮件模板未启用";
                    break;
                    case "00098":
                    StatesName="相同的应用每天只能给同一手机号发送n条不同的内容";
                    break;
                    case "00099":
                    StatesName="条相同的内容";
                    break;
                    case "00100":
                    StatesName="短信内容不能含有关键字";
                    break;
                    case "00101":
                    StatesName="配置短信端口号失败";
                    break;
                    case "00102":
                    StatesName="一个开发者只能配置一个端口";
                    break;
	                case "00103":
                    StatesName="邮件模板不存在";
                    break;
            }
            return StatesName;
        }
        private static JavaScriptSerializer jss
        {
            get { return new JavaScriptSerializer(); }
        }
        #endregion 

        #region 短信接口2 
        /// <summary>
        /// 短信tempCode=1：匹配模版，2：验证码模版
        /// 验证码为{0}，您正在进行会员注册，请勿将验证码告诉他人【中国红】
        /// 温馨提示，您于{0}年{1}月{2}日提交的订单{3}已匹配成功，请及时进行操作。【中国红】
        /// </summary>
        /// <param name="param"></param>
        /// <param name="PhoneNum"></param>
        /// <param name="tempCode"></param>
        /// <returns></returns>
        public static string SendMessageAll(string param, string PhoneNum, int tempCode)
        {
            StringBuilder smsg = new StringBuilder();
            try
            {
                int state = 0;
                string sms_switch = System.Configuration.ConfigurationManager.AppSettings["SMS_SWITCH"];//注册开关
               // string smspipei_switch = System.Configuration.ConfigurationManager.AppSettings["SMS_PIPEISWITCH"];//匹配开关
                //if (tempCode == 1)
                {
                    if (sms_switch != "Open") return "-1";
                    string[] attrParam = param.Trim().Split(',');
                    smsg.AppendFormat(System.Configuration.ConfigurationManager.AppSettings["SMS_Template1"], attrParam);
                }
                //else if (tempCode == 2)
                //{
                //    if (sms_switch != "Open") return "-1";
                //    //  if (smspipei_switch != "Open") return -1;
                //    //string[] attrParam = param.Trim().Split(',');
                //    // if (attrParam.Length != 4) state = -2;//如果参数不对
                //    smsg.AppendFormat(System.Configuration.ConfigurationManager.AppSettings["SMS_Template2"], param);
                //}
                //else
                //{
                //    state = -3;
                //}
                if (state == 0)
                {
                    LogHelper.SaveLog(smsg.ToString(), "smscontent");
                    return SendMessage2(PhoneNum, smsg.ToString());
                }
                else
                {
                    string MsgState = state == -2 ? "匹配验证码参数不是4个" : state == -3 ? "短信模版不存在！" : "";
                    string sql = string.Format(" INSERT INTO [dbo].[tb_message] ([Userid],[MobileNum],[Mcontent],[Flag])VALUES('{0}','{1}','{2}','{3}')", 0, PhoneNum, smsg.ToString() + "," + MsgState, state);
                    DbHelperSQL.GetSingle(sql);
                    return "9999";
                }
            }
            catch(Exception e)
            {
                string sql = string.Format(" INSERT INTO [dbo].[tb_message] ([Userid],[MobileNum],[Mcontent],[Flag])VALUES('{0}','{1}','{2}','{3}')", 0, PhoneNum, smsg.ToString() + ",短信未发送," + e.Message, 9999);
                DbHelperSQL.GetSingle(sql);
                return "9999";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PhoneNum"></param>
        /// <param name="smsg"></param> 
        /// <returns></returns>
        public static string SendMessage2(string PhoneNum, string smsg)
        {
            string user = System.Configuration.ConfigurationManager.AppSettings["SMS_USER"];
            string pass = System.Configuration.ConfigurationManager.AppSettings["SMS_PASS"];
            string product = System.Configuration.ConfigurationManager.AppSettings["SMS_PRODUCT"];
            string sms_switch = System.Configuration.ConfigurationManager.AppSettings["SMS_SWITCH"];
            string content = string.Format(ConfigurationManager.AppSettings["SMS_Template1"], smsg);//发送内容
           // if (sms_switch != "Open") return -1;

            string MsgState = string.Empty;

            string sname = user;// new lgk.BLL.tb_globeParam().GetModel(" ParamName='MessageName'").ParamVarchar;
            string spwd = pass;// new lgk.BLL.tb_globeParam().GetModel(" ParamName='MessagePsw'").ParamVarchar;
            string scorpid = "";// this.TxtScorpid.Text.Trim();
            string sprdid = product;

            string PostUrl = "http://cf.lmobile.cn/submitdata/service.asmx/g_Submit";

            string postStrTpl = "sname={0}&spwd={1}&scorpid={2}&sprdid={3}&sdst={4}&smsg={5}";

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, sname, spwd, scorpid, sprdid, PhoneNum, content));

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string responseData = reader.ReadToEnd();

                XmlDocument xd = new XmlDocument();
                xd.LoadXml(responseData);
                XmlNode stateXmlNode = xd.ChildNodes[1].ChildNodes[0];
                string state = stateXmlNode.InnerText;

                //如果成功则保存到数据库
                if (state == "0")
                {
                    MsgState = "";
                }
                else
                {
                    XmlNode msgIDXmlNode = xd.ChildNodes[1].ChildNodes[2];
                    MsgState = msgIDXmlNode.InnerText;
                }
                //反序列化upfileMmsMsg.Text
                //实现自己的逻辑

                string sql = string.Format(" INSERT INTO [dbo].[tb_message] ([Userid],[MobileNum],[Mcontent],[Flag])VALUES('{0}','{1}','{2}','{3}')", 0, PhoneNum, content + "," + MsgState, state);
                DbHelperSQL.GetSingle(sql);
                return state;
            }
            else
            {
                return "9999";
                //访问失败
            }
        }

        //<!--短信设置-->
        //<add key="SMS_USER" value="dlgxnn07"/>
        //<add key="SMS_PASS" value="d0JAEWy4"/>
        //<!--短信产品号-->
        //<add key="SMS_PRODUCT" value="1012818"/>
        //<!--短信emailTemplateId-->
        //<add key="SMS_Template1" value="验证码为{0}，您正在进行会员注册，请勿将验证码告诉他人【中国红】"/>
        //<!--短信emailTemplateId-->
        //<add key="SMS_Template2" value="温馨提示，您于{0}年{1}月{2}日提交的订单{3}已匹配成功，请及时进行操作。【中国红】"/>
        #endregion



    }
}
