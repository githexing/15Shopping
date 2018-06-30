using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Library
{
    public class WebHelper
    {
        /// <summary>
        /// 获取当前页面的域名，如www.xxx.com
        /// </summary>
        public static string ServerCurrentDomain
        {
            get
            {
                string urlHost = HttpContext.Current.Request.Url.Host.ToLower();
                string[] urlHostArray = urlHost.Split(new char[] { '.' });
                if ((urlHostArray.Length < 3) || PageValidate.IsIp(urlHost))
                {
                    return urlHost;
                }
                string urlHost2 = urlHost;//.Remove(0, urlHost.IndexOf(".") + 1);
                if ((urlHost2.StartsWith("com.") || urlHost2.StartsWith("net.")) || (urlHost2.StartsWith("org.") || urlHost2.StartsWith("gov.")))
                {
                    return urlHost;
                }
                return urlHost2;
            }
        }
        /// <summary>
        /// 获取当前页面的域名, IP:端口，如http://www.xxx.com，https://www.xxx.com,http://192.168.0.1:8888
        /// </summary>
        public static string HttpDomain
        {
            get
            {
                string url = HttpContext.Current.Request.Url.ToString();
                string query = HttpContext.Current.Request.Url.PathAndQuery;

                return url.Replace(query, "");
            }
        }
    }
}
