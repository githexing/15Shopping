using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Library;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //// 在应用程序启动时运行的代码
            //QuartzStart.Start();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
            Exception ex = Server.GetLastError().GetBaseException();
            if (ex != null)
            {
                string s = "\r\n" + "\r\n" + "\r\n" + "\r\n" + "出错时间" + DateTime.Now.ToString() + "\r\n";
                // 错误的信息
                s = s + "错误的信息:" + ex.ToString() + "\r\n";
                // 出错的方法名
                s = s + "出错的方法名:" + ex.TargetSite.Name + "\r\n";
                // 出错的类名
                s = s + "出错的类名:" + ex.TargetSite.DeclaringType.FullName + "\r\n";
                System.IO.File.AppendAllText(Server.MapPath("~/log/log.log"), s);
            }

            // 清空最后的错误
            //Server.ClearError();
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}