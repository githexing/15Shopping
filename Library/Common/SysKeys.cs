using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class SysKeys
    {
        #region 设置
        /// <summary>
        /// 测试语言设置是否成功
        /// </summary>
        public const string SYSTEM_LANGUAGE_TEST = "LangTest";
        public static string SYSTEM_LOG_SAVEPATH = AppDomain.CurrentDomain.BaseDirectory + "log";
        #region 邮箱内容 以后可能取消
        public static string Email_BODY_HTML = "<div style='position:relative;font-size:14px;height:auto;padding:15px 15px 10px 15px;z-index:1;zoom:1;line-height:1.7;' >"+    
                                "<div><font color='#000080'>亲爱的用户，您好：</font></div><br/>"+
                                "<div><font color='#000080'>&nbsp;&nbsp;&nbsp;您的马夫罗帐号验证码为：<span style='font-weight:bold;font-size:16px;color:#000;'>{0}</span></font><br><br></div>" +
                                "<div><font color='#000080'>&nbsp;&nbsp;&nbsp;为了确保您的帐号安全，该验证码仅<font color='#ff0000'>{1}分钟内有效</font>。</font><br><br></div>" +
                                "<div><font color='#000080'>&nbsp;&nbsp;&nbsp;如果该验证码已经失效，请您重新获取激活操作。<br></font><br></div>" +
                                "<div><span style='margin-right:200px;'>&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"+
                                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"+
                                "<font color='#000080'>马夫罗用户中心</font><div>" +
                                "</div>";
        #endregion
        #endregion

        #region Session

        public const string SESSION_UserInfo = "SESSION_UserInfo";
        public const string SESSION_AdminInfo = "SESSION_AdminInfo";
        public const string SESSION_ImgVerify_code = "SESSION_ImgVerify_code";//图片验证码
        public const string SESSION_ModifyBag = "SESSION_ModifyBag"; //修改钱包地址
        public const string SESSION_ModifyType = "SESSION_ModifyType"; //修改钱包地址

        #endregion

        #region Cookie

        public const string COOKIE_LANGUAGE_TEST = "Culture"; 

        #endregion


        #region DDL

        public const string DDL_Province = "province";
        public const string DDL_City = "city";

        #endregion
    }
}
