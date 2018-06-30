using System;
using System.Web;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Security.Principal;
using System.IO;

namespace Library
{
    /// <summary>
    /// MyHttpModule 的摘要说明。
    /// </summary>
    public class MyHttpModule : IHttpModule
    {
        public void Init(HttpApplication app)
        {
          //  app.AuthenticateRequest += new EventHandler(app_AuthenticateRequest);
          //  app.EndRequest += new EventHandler(app_EndRequest);
        }

        void app_EndRequest(object sender, EventArgs e)
        {
            foreach (string key in HttpContext.Current.Response.Cookies)
            {
                HttpContext.Current.Response.Cookies[key].Domain = ConfigurationManager.AppSettings["domain"];
            }
        }

        public void Dispose() { }

        private void app_AuthenticateRequest(object sender, EventArgs e)
        {
           
            // 提取窗体身份验证 cookie
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[cookieName];

            if (null == authCookie)
            {
                // 没有身份验证 cookie。
               UserUtil.Login("未登陆来宾", "Guest", false);
                authCookie = HttpContext.Current.Request.Cookies[cookieName];
            }

            FormsAuthenticationTicket authTicket = null;
            authTicket = FormsAuthentication.Decrypt(authCookie.Value);

            if (null == authTicket)
            {
                // 无法解密 Cookie。
                return;
            }
            // 创建票证后，为 UserData 属性指定一个
            // 以管道符分隔的角色名字符串。
            string[] roles = authTicket.UserData.Split(new char[] { ',' });


            // 创建一个标识对象
            FormsIdentity id = new FormsIdentity(authTicket);

            // 该主体将通过整个请求。
            GenericPrincipal principal = new GenericPrincipal(id, roles);
            // 将新的主体对象附加到当前的 HttpContext 对象
            HttpContext.Current.User = principal;
        }
    }
}
