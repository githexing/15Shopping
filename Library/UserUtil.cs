using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Security.Principal;

namespace Library
{
    /// <summary>
    /// 用户实用类
    /// </summary>
    public sealed class UserUtil
    {
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="roles">权限</param>
        /// <param name="isPersistent">输入true时，Cookies存在的时间是一个月！输入false时，Cookies存在时间是一小时</param>
        public static void Login(string username, string roles, bool isPersistent)
        {
            
            DateTime dt = isPersistent ? DateTime.Now.AddDays(30) : DateTime.Now.AddMinutes(60);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                                                                                1, // 票据版本号
                                                                                username, // 票据持有者
                                                                                DateTime.Now, //分配票据的时间
                                                                                dt, // 失效时间
                                                                                isPersistent, // 需要用户的 cookie 
                                                                                roles, // 用户数据，这里其实就是用户的角色
                                                                                FormsAuthentication.FormsCookiePath);//cookie有效路径

       
            //使用机器码machine key加密cookie，为了安全传送
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash); //加密之后的cookie


         

            //将cookie的失效时间设置为和票据tikets的失效时间一致 
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }

            //添加cookie到页面请求响应中
            HttpContext.Current.Response.Cookies.Add(cookie);

           

        }
      
        /// <summary>
        /// 返回用户的身份
        /// </summary>
        /// <returns></returns>
        public static string GetRoles()
        {
            // 提取窗体身份验证 cookie
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[cookieName];

            if (null == authCookie)
            {
                return "false";
            }
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            if (null == authTicket)
            {
                // 无法解密 Cookie。
                return "false";
            }
            return authTicket.UserData;
        }
        /// <summary>
        /// 注销登陆
        /// </summary>
        public static void Logout()
        {
            FormsAuthentication.SignOut();
            return;
            //HttpCookie cookie = HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName];

            //if (cookie == null)
            //{
            //    cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            //    HttpContext.Current.Response.Cookies.Add(cookie);
            //}
            //cookie.Expires = DateTime.Now.AddYears(-10);
        }
    }
}
