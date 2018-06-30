namespace HXComm
{
    using System;
    using System.Text;
    using System.IO;
    using System.Net;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// 环信服务器端会员访问接口 
    /// </summary>
    public class EaseMobAPI
    {
        string reqUrlFormat = "https://a1.easemob.com/{0}/{1}/";
        public string clientID { get; set; }
        public string clientSecret { get; set; }
        public string appName { get; set; }
        public string orgName { get; set; }
        public string token { get; set; }
        public string easeMobUrl { get { return string.Format(reqUrlFormat, orgName, appName); } }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="easeAppClientID">client_id</param>
        /// <param name="easeAppClientSecret">client_secret</param>
        /// <param name="easeAppName">应用标识之应用名称</param>
        /// <param name="easeAppOrgName">应用标识之登录账号</param>
        public EaseMobAPI(string easeAppClientID, string easeAppClientSecret, string easeAppName, string easeAppOrgName)
        {
            this.clientID = easeAppClientID;
            this.clientSecret = easeAppClientSecret;
            this.appName = easeAppName;
            this.orgName = easeAppOrgName;
            this.token = QueryToken();
        }

        /// <summary>
        /// 使用app的client_id 和 client_secret登陆并获取授权token
        /// </summary>
        /// <returns></returns>
        string QueryToken()
        {
            if (string.IsNullOrEmpty(clientID) || string.IsNullOrEmpty(clientSecret)) { return string.Empty; }
            string cacheKey = clientID + clientSecret;
            if (System.Web.HttpRuntime.Cache.Get(cacheKey) != null &&
                System.Web.HttpRuntime.Cache.Get(cacheKey).ToString().Length > 0)
            {
                return System.Web.HttpRuntime.Cache.Get(cacheKey).ToString();
            }

            string postUrl = easeMobUrl + "token";
            StringBuilder _build = new StringBuilder();
            _build.Append("{");
            _build.AppendFormat("\"grant_type\": \"client_credentials\",\"client_id\": \"{0}\",\"client_secret\": \"{1}\"", clientID, clientSecret);
            _build.Append("}");

            int statusCode;
            string postResultStr = ReqUrl(postUrl, "POST", _build.ToString(), string.Empty, out statusCode);
            string token = string.Empty;
            int expireSeconds = 0;
            try
            {
                JObject jo = JObject.Parse(postResultStr);
                token = jo.GetValue("access_token").ToString();
                int.TryParse(jo.GetValue("expires_in").ToString(), out expireSeconds);
                //设置缓存
                if (!string.IsNullOrEmpty(token) && token.Length > 0 && expireSeconds > 0)
                {
                    System.Web.HttpRuntime.Cache.Insert(cacheKey, token, null, DateTime.Now.AddSeconds(expireSeconds), System.TimeSpan.Zero);
                }
            }
            catch { return postResultStr; }
            return token;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="password">密码</param>
        /// <returns>创建成功的用户JSON</returns>
        public string AccountCreate(string userName, string password, out int statusCode)
        {
            StringBuilder _build = new StringBuilder();
            _build.Append("{");
            _build.AppendFormat("\"username\": \"{0}\",\"password\": \"{1}\"", userName, password);
            _build.Append("}");

            return AccountCreate(_build.ToString(), out statusCode);
        }

        /// <summary>
        /// 创建用户(可以批量创建)
        /// </summary>
        /// <param name="postData">创建账号JSON数组--可以一个，也可以多个</param>
        /// <returns>创建成功的用户JSON</returns>
        public string AccountCreate(string postData, out int statusCode) { return ReqUrl(easeMobUrl + "users", "POST", postData, token, out statusCode); }

        /// <summary>
        /// 获取 IM 用户[批量
        /// </summary>
        /// <param name="limit">获取用户的数量</param>
        /// <param name="cursor">游标，上一次分页查询之后返回的cursor值</param>
        /// <returns>创建成功的用户JSON</returns>
        public string AccountList(string limit,string cursor, out int statusCode) { return ReqUrl(easeMobUrl + "users?limit="+limit+ "&cursor="+ cursor, "GET", string.Empty, token, out statusCode); }


        /// <summary>
        /// 获取指定用户详情
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns>会员JSON</returns>
        public string AccountGet(string userName, out int statusCode) { return ReqUrl(easeMobUrl + "users/" + userName, "GET", string.Empty, token, out statusCode); }

        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>重置结果JSON(如：{ "action" : "set user password",  "timestamp" : 1404802674401,  "duration" : 90})</returns>
        public string AccountResetPwd(string userName, string newPassword, out int statusCode) { return ReqUrl(easeMobUrl + "users/" + userName + "/password", "PUT", "{\"newpassword\" : \"" + newPassword + "\"}", token, out statusCode); }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns>成功返回会员JSON详细信息，失败直接返回：系统错误信息</returns>
        public string AccountDel(string userName, out int statusCode) { return ReqUrl(easeMobUrl + "users/" + userName, "DELETE", string.Empty, token, out statusCode); }
        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="limit">指定删除数据的最大条数</param>
        /// <returns>成功返回会员JSON详细信息，失败直接返回：系统错误信息</returns>
        public string AccountDelUser(int limit, out int statusCode) { return ReqUrl(easeMobUrl + "users?limit="+ limit, "DELETE", string.Empty, token, out statusCode); }

        /// <summary>
        /// 添加 IM 用户的好友关系
        /// </summary>
        /// <param name="userName">要添加好友的用户名</param>
        /// <param name="friend_username">被添加好友的用户名</param>
        /// <returns>成功返回会员JSON详细信息，失败直接返回：系统错误信息</returns>
        public string AccountAddFriend(string userName, string friend_username, out int statusCode) { return ReqUrl(easeMobUrl + "users/" + userName + "/contacts/users/" + friend_username, "POST", string.Empty, token, out statusCode); }

        /// <summary>
        /// 解除 IM 用户的好友关系
        /// </summary>
        /// <param name="userName">要删除好友的用户名</param>
        /// <param name="friend_username">被删除好友的用户名</param>
        /// <returns>成功返回会员JSON详细信息，失败直接返回：系统错误信息</returns>
        public string AccountDelFriend(string userName,string friend_username, out int statusCode) { return ReqUrl(easeMobUrl + "users/" + userName+ "/contacts/users/"+ friend_username, "DELETE", string.Empty, token,out statusCode); }
        
        /// <summary>
        /// 获取 IM 用户的好友关系
        /// </summary>
        /// <param name="userName">要添加好友的用户名</param>
        /// <param name="friend_username">被添加好友的用户名</param>
        /// <returns>成功返回会员JSON详细信息，失败直接返回：系统错误信息</returns>
        public string AccountGetFriend(string userName,out int statusCode) { return ReqUrl(easeMobUrl + "users/" + userName + "/contacts/users/", "GET", string.Empty, token, out statusCode); }

        public string ReqUrl(string reqUrl, string method, string paramData, string token,out int statusCode)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(reqUrl) as HttpWebRequest;
                request.Method = method.ToUpperInvariant();

                if (!string.IsNullOrEmpty(token) && token.Length > 1) { request.Headers.Add("Authorization", "Bearer " + token); }
                if (request.Method.ToString() != "GET" && !string.IsNullOrEmpty(paramData) && paramData.Length > 0)
                {
                    request.ContentType = "application/json";
                    byte[] buffer = Encoding.UTF8.GetBytes(paramData);
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                }

                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    {
                        statusCode = (int)resp.StatusCode;
                        string result = stream.ReadToEnd();
                        return result;
                    }
                }
            }
            catch (Exception ex) { statusCode = -1; return ex.ToString(); }
        }
    }

    //public class SampleUse
    //{
    //    /// <summary>
    //    /// 使用范例
    //    /// HXComm.SampleUse mySample = new HXComm.SampleUse();
    //    /// mySample.Test(appClientID, appClientSecret, appName, orgName);
    //    /// </summary>
    //    /// <param name="appClientID"></param>
    //    /// <param name="appClientSecret"></param>
    //    /// <param name="appName"></param>
    //    /// <param name="orgName"></param>
    //    public void Test(string appClientID, string appClientSecret, string appName, string orgName)
    //    {
    //        EaseMobAPI myEaseMobDemo = new EaseMobAPI(appClientID, appClientSecret, appName, orgName);
    //        string userName = "a001", password = "a001", newPassword = "a000000";//此处我们要进行加密处理，如果在实际项目中，建议加密

    //        Console.WriteLine("{0}", myEaseMobDemo.AccountCreate(userName, password));
    //        Console.WriteLine("{0}", myEaseMobDemo.AccountGet(password));
    //        Console.WriteLine("{0}", myEaseMobDemo.AccountResetPwd(userName, newPassword));
    //        Console.WriteLine("{0}", myEaseMobDemo.AccountDel(password));
    //    }

     
    //}
}