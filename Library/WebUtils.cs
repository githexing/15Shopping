using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;

namespace Library
{
    /// <summary>
    /// 网络工具类。
    /// </summary>
    public sealed class WebUtils
    {
        private int _timeout = 120000;
        //private int _timeout = 60000;


        /// <summary>
        /// 请求与响应的超时时间
        /// </summary>
        public int Timeout
        {
            get { return this._timeout; }
            set { this._timeout = value; }
        }

        /// <summary>
        /// 执行HTTP GET请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>HTTP响应</returns>
        public string DoGet(string url, IDictionary<string, string> parameters, Encoding encoding, int Timeout)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters);
                }
            }

            HttpWebRequest req = GetWebRequest(url, "GET");
            req.ContentType = "application/x-www-form-urlencoded";
            req.Timeout = Timeout;
            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
            //Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
            return GetResponseAsString(rsp, encoding);
        }
        /// <summary>
        /// 执行HTTP POST请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>HTTP响应</returns>
        public string DoPost(string url, IDictionary<string, string> parameters)
        {
            var cookieContainer = new CookieContainer();
            return DoPost(url, parameters, ref cookieContainer);
        }
        public string DoPost(string url, string paramter)
        {
            HttpWebRequest req = GetWebRequest(url, "POST");
            System.Net.ServicePointManager.DefaultConnectionLimit = 200;

            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            byte[] postData = Encoding.UTF8.GetBytes(paramter);
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();

            HttpWebResponse rsp = null;
            Encoding encoding = null;
            try
            {
                rsp = (HttpWebResponse)req.GetResponse();
                encoding = Encoding.GetEncoding(rsp.CharacterSet);
            }
            catch (Exception)
            {

            }
            //垃圾回收
            // System.GC.Collect();
            return GetResponseAsString(rsp, encoding);
        }

        public string DoPost(string url, IDictionary<string, string> parameters, ref CookieContainer cookieContainer)
        {
            HttpWebRequest req = GetWebRequest(url, "POST");
            System.Net.ServicePointManager.DefaultConnectionLimit = 200;
            if (cookieContainer != null)
            {
                req.CookieContainer = cookieContainer;
            }

            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            byte[] postData = Encoding.UTF8.GetBytes(BuildQuery(parameters));
            Stream reqStream = req.GetRequestStream(); 
            reqStream.Write(postData, 0, postData.Length);
            reqStream.Close();

            HttpWebResponse rsp = null;
            Encoding encoding = null;
            try
            {
                rsp = (HttpWebResponse)req.GetResponse();
                encoding = Encoding.GetEncoding(rsp.CharacterSet);
            }
            catch (Exception)
            {

            }
            //垃圾回收
           // System.GC.Collect();
            return GetResponseAsString(rsp, encoding);
        }
        /// <summary>
        /// 有代理参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public string DoPost(string url, IDictionary<string, string> parameters, ref CookieContainer cookieContainer, IWebProxy proxy)
        {
            return DoPost(url, parameters, ref cookieContainer, proxy, "");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="proxy"></param>
        /// <param name="referer"></param>
        /// <returns></returns>
        public string DoPost(string url, IDictionary<string, string> parameters, ref CookieContainer cookieContainer, IWebProxy proxy, string referer)
        {
            HttpWebRequest req = GetWebRequest(url, "POST");
            System.Net.ServicePointManager.DefaultConnectionLimit = 200;
            if (cookieContainer != null)
            {
                req.CookieContainer = cookieContainer;
            }
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            if (proxy != null)
                req.Proxy = proxy;
            if (!string.IsNullOrEmpty(referer))
            {
                req.Referer = referer;
            }
            byte[] postData = Encoding.UTF8.GetBytes(BuildQuery(parameters));
            HttpWebResponse rsp = null;
            try
            {
                System.IO.Stream reqStream = req.GetRequestStream();
                reqStream.Write(postData,0, postData.Length);
                reqStream.Close();
                rsp = (HttpWebResponse)req.GetResponse();
                //垃圾回收
                System.GC.Collect();
            }
            catch (Exception)
            {


            }
            if (rsp != null)
            {
               // rsp = (HttpWebResponse)req.GetResponse();
                Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
                return GetResponseAsString(rsp, encoding);
            }
            else
                return string.Empty;
        }
        /// <summary>
        /// 执行HTTP GET请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>HTTP响应</returns>
        public string DoGet(string url, IDictionary<string, string> parameters)
        {
            var cookieContainer = new CookieContainer();
            return DoGet(url, parameters, ref cookieContainer);
        }

        public string DoGet(string url, IDictionary<string, string> parameters, ref CookieContainer cookieContainer)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters);
                }
            }
            HttpWebRequest req = GetWebRequest(url, "GET");
            req.CookieContainer=new CookieContainer();
            if (cookieContainer != null && cookieContainer.Count > 0)
            {
                req.CookieContainer = cookieContainer;
            }
            HttpWebResponse rsp = null;
            Encoding encoding = null;
            try
            {
                req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                req.Timeout = 60000;
                rsp = (HttpWebResponse)req.GetResponse();
                //垃圾回收
                System.GC.Collect();
                encoding = Encoding.UTF8;
            }
            catch (Exception)
            {
            }
            return GetResponseAsString(rsp, encoding);
        }



        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        { //直接确认，否则打不开
            return true;
        }

        public HttpWebRequest GetWebRequest(string url, string method)
        {
            HttpWebRequest req = null;
            if (url.Contains("https"))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            }
            else
            {
                req = (HttpWebRequest)WebRequest.Create(url);
            }

            req.ServicePoint.Expect100Continue = false;
            req.Method = method;
            //req.KeepAlive = true;
            req.Timeout = this._timeout;

            return req;
        }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        public string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            if (rsp == null)
            {
                return string.Empty;
            }
            System.IO.Stream stream = null;
            StreamReader reader = null;
            var s = string.Empty;
            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                s = reader.ReadToEnd();

            }
            catch (Exception)
            {

            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
                //垃圾回收
                System.GC.Collect();
            }
            return s;
        }

        /// <summary>
        /// 组装GET请求URL。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>带参数的GET请求URL</returns>
        public string BuildGetUrl(string url, IDictionary<string, string> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters);
                }
            }
            return url;
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        public static string BuildQuery(IDictionary<string, string> parameters)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;
            if (parameters != null)
            {
                IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
                while (dem.MoveNext())
                {
                    string name = dem.Current.Key;
                    string value = dem.Current.Value;
                   
                    if (hasParam)
                    {
                        postData.Append("&");
                    }

                    postData.Append(name);
                    postData.Append("=");
                    postData.Append(name.Equals("back_url") ? value : HttpUtility.UrlEncode(value, Encoding.UTF8));
                    hasParam = true;
                    //}
                }
            }

            return postData.ToString();
        }


        public byte[] GetImageBytes(string url, ref CookieContainer cookieContainer)
        {
            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            try
            {
                request.CookieContainer = cookieContainer;
                WebResponse webres = request.GetResponse();
                Stream stream = webres.GetResponseStream();
                //byte[] bytes = new byte[stream.Length];
                //stream.Read(bytes, 0, bytes.Length);
                //stream.Seek(0, SeekOrigin.Begin);
                //stream.Close();
                

                //return bytes;

                Image image;
                image = Image.FromStream(stream);
                stream.Close();

                MemoryStream ms = new MemoryStream();
                image.Save(ms, image.RawFormat);
                //byte[] bytes = new byte[ms.Length];  
                //ms.Read(bytes, 0, Convert.ToInt32(ms.Length));  
                //以上两句改成下面两句  
                byte[] bytes = ms.ToArray();
                ms.Close();
                return bytes;
            }
            catch
            {
                return null;
            }
          //  return image;
        }
    }
}
