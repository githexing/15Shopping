/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-13 16:09:09 
 * 文 件 名：		Login.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Drawing;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace Web
{
    public partial class Login : AllCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //long iUserID = Convert.ToInt64(Request["UserID"]);
            
            if (!IsPostBack)
            {
                //validatedCode v = new validatedCode();
                //string code = v.CreateVerifyCode();
                ////ImgCheck.ImageUrl = code;
                //v.CreateImageOnPage(code, this.Context);
                //Session["CheckCode"] = code;
                string host = Request.Url.Host;
                if (Request["name"] != null)
                {
                    //登录另一个域名
                    string UserName = Request.QueryString["name"];
                    lgk.Model.tb_user uModel = userBLL.GetModel(GetUserID(UserName));
                    if (uModel.Password != PageValidate.GetMd5(Request.QueryString["pwd"]))
                    {
                        return;//密码不对
                    }

                    UserUtil.Login(UserName, "A128076_user", false);
                    //放入cookie
                    HttpCookie UserCookie = new HttpCookie("A128076_user");
                    if (Request["id"] == null)
                    {
                        UserCookie["Id"] = GetUserID(UserName).ToString();
                    }
                    else
                    {
                        UserCookie["Id"] = Request.QueryString["id"];
                    }
                    
                    UserCookie["name"] = UserName;
                    Response.AppendCookie(UserCookie);
                    HttpCookie CultureCookie = new HttpCookie("Culture");
                    CultureCookie.Value = Request.QueryString["lan"];
                    //CultureCookie.Value = "zh-cn";
                    Response.AppendCookie(CultureCookie);
                    //Response.Redirect("/HTMLPage1.htm");
                    //Response.Redirect("http://" + host.Replace("www.", "vip.") + "/user/index.aspx");//跳转到会员中心
                    Response.Redirect("/user/index.aspx");
                }

            
               // if (host.IndexOf("www.") == 0)
               // {
               ////     //Response.Redirect("/HTMLPage1.htm");
               ////     //Response.Redirect("http://" + host + "/user/shop/index.aspx");//用www访问跳转到商城
               //     Response.Redirect("/user/shop/index.aspx");
               // }
               //if (string.IsNullOrEmpty(Request["adminid"]) == false)
               //{
               //    Security sec = new Security();//解密传递过来的参数
               //    string admin = sec.DecryptQueryString(Request["adminid"].ToString());//Request["adminid"].ToString();//
               //    long userid = Convert.ToInt32(sec.DecryptQueryString(Request["uid"].ToString()));//Request["adminid"].ToString();//
               //    RegexR reg = new RegexR();
               //    if(reg.Nums(admin) == true)
               //    {
               //        AdminEnter(admin, userid);
               //    }
               //    else
               //    {
               //        bindLogin();
               //    }
               //}
               //if (Request.Cookies["Culture"] == null || Request.Cookies["Culture"].Value.ToString() == "zh-cn")
               //{
               //    this.rdoZH.Checked = true;
               //}
               //else 
               //{
               //    this.rdoEn.Checked = true;
               //}
            }
        }

        private void bindLogin()
        {
            if (Session["goto_uid"] != null)
            {
                lgk.Model.tb_user loginuser = userBLL.GetModel(Convert.ToInt64(Session["goto_uid"]));
                //放入cookie
                HttpCookie UserCookie = new HttpCookie("A128076_user");                
                UserCookie["Id"] = loginuser.UserID.ToString();
                UserCookie["name"] = loginuser.UserCode;
                Response.AppendCookie(UserCookie);
                Session.Remove("goto_uid");
                Response.Redirect("user/index.aspx");
            }
        }

        protected void AdminEnter(string adminid, long iUserID)
        {
            lgk.Model.tb_user user = userBLL.GetModel(iUserID);

            UserUtil.Login(this.Phone.Value.Trim(), "A128076_user", false);
            Session["adminid"] = adminid;//管理员以会员身份登陆会员前台页面后，作出标记
            lgk.BLL.SecondPasswordBLL76.AdminId = Convert.ToInt32(adminid);//管理员以会员身份登陆会员前台页面后，作出标记

            //放入cookie
            HttpCookie UserCookie = new HttpCookie("A128076_user");
            UserCookie["Id"] = user.UserID.ToString();
            UserCookie["name"] = user.UserCode;
            Response.AppendCookie(UserCookie);
            Response.Redirect("user/index.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (setBLL.GetModel(1).IsOpenWeb == 0)
            {
                MessageBox.ShowAndRedirect(this, setBLL.GetModel(1).CloseWebRemark, "login.aspx");
            }
            else
            {
                if (this.Phone.Value.Trim() == "")
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseNmae") + "');", true);
                    return;
                    //MessageBox.ShowBox(this.Page, GetLanguage("PleaseNmae"), Library.Enums.ModalTypes.warning);//请输入用户名
                   
                    //return;
                }
                //if (this.TBUserName.Value.Trim() == "用户名")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入用户名!');", true);
                //    return;
                //}
               
                //if (this.TBPassWord.Value.Trim() == "密码")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入密码!');", true);
                //    return;
                //}
                if (this.TBCode.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Verification") + "');", true);
                    return;
                    //MessageBox.ShowBox(this.Page, GetLanguage("Verification"), Library.Enums.ModalTypes.warning);//验证码不能为空 
                    //return;
                }

                string xd = Session["CheckCode"] != null && Session["CheckCode"].ToString() != "" ? Session["CheckCode"].ToString() : "";
                if (xd.ToLower() != TBCode.Value.Trim().ToLower())
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("VerificationError") + "');", true);
                    return;
                    //MessageBox.ShowBox(this.Page, GetLanguage("VerificationError"), Library.Enums.ModalTypes.error);//验证码错误
                 
                    //return;
                }
                lgk.Model.tb_user user = userBLL.GetModel(GetUserID(Phone.Value.Trim()));
                if (user == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('"+ GetLanguage("AccountError") + "');", true);
                    return;
                    //MessageBox.ShowBox(this.Page, GetLanguage("AccountError"), Library.Enums.ModalTypes.error);//账号或密码错误 
                    //return;
                }
               
                if (Text2.Value.Trim()!="")
                {
                    string regSwitch = ConfigurationManager.AppSettings["SMS_SWITCH"];//注册短信开关
                    if (regSwitch.Equals("Open"))
                    { 
                        if (CheckSMSCode(this.Phone.Value.Trim(), Text2.Value.Trim().ToString(), 2) < 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('短信验证码错误');", true);
                            return;
                            //MessageBox.ShowBox(this.Page,"短信验证码错误", Library.Enums.ModalTypes.error);//账号或密码错误 
                            //return;
                        }
                    }
                }
                else
                {
                    if (this.TBPassWord.Value.Trim() == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('"+ GetLanguage("PleaseEnter") + "');", true);
                        return;
                        //MessageBox.ShowBox(this.Page, GetLanguage("PleaseEnter"), Library.Enums.ModalTypes.warning);//请输入密码

                        //return;
                    }
                    string pwd = user.Password;
                    string loginPwd = PageValidate.GetMd5(TBPassWord.Value);

                    //安卓端注册时偶尔会出现传递的md5密码少第一个字符，只传递了31个字符，为了兼容多端登录需要做一下特殊处理
                    if (user.Password.Length != 32 || loginPwd.Length != 32)
                    {
                        if (user.Password.Length == 32) pwd = user.Password.Substring(1, user.Password.Length-1);
                        if (loginPwd.Length == 32) loginPwd = loginPwd.Substring(1, loginPwd.Length-1);
                    }

                    if (pwd != loginPwd)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AccountError") + "');", true);
                        return;
                        //MessageBox.ShowBox(this.Page, GetLanguage("AccountError"), Library.Enums.ModalTypes.error);//账号或密码错误
                        //return;
                    }
                }
                //if (user.IsOpend != 2)
                //{
                //    Response.Redirect("/user/XLH.aspx?UserCode=" + user.UserCode);
                //}
                //if (user.IsOpend == 4 || user.IsLock == 1)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('账号已冻结不能登录!');", true);
                //    return;
                //}
                //if (user.IsOpend == 0 || user.IsOpend == 4 || user.IsLock == 1)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('账号未开通或已冻结不能登录!');", true);
                //    return;
                //}
                string UserName = this.Phone.Value.Trim();
                UserUtil.Login(UserName, "A128076_user", false);
                //放入cookie
                HttpCookie UserCookie = new HttpCookie("A128076_user");
                UserCookie["Id"] = user.UserID.ToString();
                UserCookie["name"] = UserName;
                Response.AppendCookie(UserCookie);
                //HttpCookie CultureCookie = new HttpCookie("Culture");
                //CultureCookie.Value = "zh-cn";//中文
                //Response.AppendCookie(CultureCookie);
                HttpCookie Culture;

                if (HttpContext.Current.Request.Cookies["Culture"] == null)
                    Culture = new HttpCookie("Culture");
                else
                    Culture = HttpContext.Current.Request.Cookies["Culture"];

                if (LangType.Value != "2")
                {
                    Culture.Value = "zh-cn";//中文
                }
                else
                {
                    Culture.Value = "en-us";//英文

                }

                Response.AppendCookie(Culture);

                //登录系统
                Response.Redirect("/user/index.aspx");
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("user/passwordupdata.aspx");
        }
        protected void DX_btnLogin_Click(object sender, EventArgs e)
        {
            if (Get_Yanzheng())
            {
                string phone = Phone.Value.Trim().ToString();
                //------------------验证码//
                string msg = "";

                if (smsBLL.GetSendCountOfDay(phone) >= 5) //同号码每日限制：5条 
                {
                    msg = "超出短信发送计数限制";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + msg + "');", true);
                    return;
                }
                if (smsBLL.GetSendCountOfMinute(phone, 1) >= 1) //同号码每分钟限制：1条
                {
                    msg = "操作过于频繁，请稍后重试";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + msg + "');", true);
                    return;
                }

                lgk.Model.SMS model = new lgk.Model.SMS();
                model.IsDeleted = 0;
                model.IsValid = 0;
                model.PublishTime = DateTime.Now;
                model.SCode = new Library.Common().GetRandom(6);
                model.ToPhone = phone;
                model.SMSContent = model.SCode;
                model.SendNum = 1;
                model.ToUserCode = "";
                model.ValidTime = DateTime.Now.AddMinutes(5);
                model.TypeID = 1;

                long isid = smsBLL.Add(model);
                if (isid > 0)
                {
                    //msg = "验证码已发送";
                    string strreturn = Library.SMSHelper.SendMessage2(phone, model.SCode);
                    if (strreturn == "0")
                    {
                        msg = "发送成功请注意查看手机短信";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + msg + "');", true);
                        return;
                    }
                    else
                    {
                        smsBLL.UpdateDelete(isid, -1);
                        msg = "发送失败";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + msg + "');", true);
                        return;
                    }
                }
                else
                {
                    msg = "验证码发送失败";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + msg + "');", true);
                    return;
                }

            }

        }
     

        protected void DX_Login_Click(object sender, EventArgs e)
        {
            if (Get_Yanzheng())
            {

         
            string phone = Phone.Value.Trim().ToString();

            if (CheckSMSCode(phone, Text2.Value.Trim().ToString(), 1) >= 0)
            {
                //
                    var user = userBLL.GetModelByPhoneNum(phone);
                    string UserName = user.UserCode;
                    UserUtil.Login(UserName, "A128076_user", false);
                    //放入cookie
                    HttpCookie UserCookie = new HttpCookie("A128076_user");
                    UserCookie["Id"] = user.UserID.ToString();
                    UserCookie["name"] = UserName;
                    Response.AppendCookie(UserCookie); 
                    HttpCookie Culture;  
                    if (HttpContext.Current.Request.Cookies["Culture"] == null)
                        Culture = new HttpCookie("Culture");
                    else
                        Culture = HttpContext.Current.Request.Cookies["Culture"];

                    if (LangType.Value != "2")
                    {
                        Culture.Value = "zh-cn";//中文
                    }
                    else
                    {
                        Culture.Value = "en-us";//英文 
                    } 
                    Response.AppendCookie(Culture); 
                    //登录系统
                    Response.Redirect("/user/index.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('短信验证码或手机号错误');", true);
                    return;
                }

            }

        }
        public bool Get_Yanzheng()
        {
            string phone = Phone.Value.Trim().ToString();

            //if (phone.Length != 11)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('手机长度不符合!');", true);
            //    return false;
            //}
            //------------------验证码
            //if (this.Text1.Value.Trim() == "")
            //{
            //    MessageBox.ShowBox(this.Page, GetLanguage("Verification"), Library.Enums.ModalTypes.warning);//验证码不能为空

            //    return false;
            //}

            string xd = Session["CheckCode"] != null && Session["CheckCode"].ToString() != "" ? Session["CheckCode"].ToString() : "";
            if (xd.ToLower() != TBCode.Value.Trim().ToLower())
            {
                MessageBox.ShowBox(this.Page, GetLanguage("VerificationError"), Library.Enums.ModalTypes.error);//验证码错误 
                return false;
            }
            return true;
        }
    }
   
}
