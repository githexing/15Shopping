using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.UI;

namespace Library
{
    public class BrowserHelper
    {
        //获取客户端电脑名 1
        public static string UserHostName(Page page)
        {
            return page.Request.UserHostName;
        }
        //获取客户端电脑名 2
        public static string UserHostName()
        {
            return Dns.GetHostName();
        }
        //获取客户端Mac
        public static string UserHostMac()
        {
            IPAddress mac = Dns.GetHostAddresses(Environment.MachineName)[0];
            return mac.ToString() ;
        }
        //获取客户端IP
        public static string UserHostIP(Page page)
        {
            return page.Request.UserHostAddress;
        }
        
    }
}
