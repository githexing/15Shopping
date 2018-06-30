using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;
using System.Web.Script.Serialization;

namespace Library
{
    public class Util
    {
        /// <summary>
        /// 自动生成编号  201008251145409865
        /// </summary>
        /// <returns></returns>
        public static string CreateNo()
        {
            Random random = new Random();
            string strRandom = random.Next(1000, 10000).ToString(); //生成编号 
            string code = DateTime.Now.ToString("yyyyMMddHHmmss") + strRandom;//形如
            return code;
        }
        /// <summary>
        /// 生成随机订单号
        /// </summary>
        /// <returns></returns>
        public static string BuildOuterOrderNumber(int UserID)
        {
            lgk.BLL.tb_remit remitbll = new lgk.BLL.tb_remit();
            string payId = "1"; //支付编号
            var len = 20 - 15 - payId.ToString().Length;

            var orderNumber = GetUniqueIndentifier(len) + payId + DateTime.Now.ToString("yyMMddHHmmssfff");
            lgk.Model.tb_remit me = remitbll.GetModel(" UserID=" + UserID + " and Remit004='"+ orderNumber+"'");
            if (me!=null)
                return BuildOuterOrderNumber(UserID);
            else
                return orderNumber;
        }
        public static string GetUniqueIndentifier(int length)
        {
            if (length <= 0)
                return string.Empty;
            int maxSize = length;
            char[] chars = new char[62];
            string a = "abcdefghijklmnopqrstuvwxyz1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            rng.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder();
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            if (result[0] >= '0' && result[0] <= '9')
            {
                return GetUniqueIndentifier(length);
            }
            return result.ToString();
        }
        
        ///// <summary>
        ///// AES加密
        ///// </summary>
        ///// <param name="encryptString">要加密的字符串</param>
        ///// <param name="encryptKey">Key</param>
        ///// <param name="encryptIv">iv</param>
        ///// <returns></returns>
        //public static string AESEncode(string encryptString, string encryptKey, string encryptIv)
        //{
        //    RijndaelManaged rijndaelProvider = new RijndaelManaged();
        //    rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey);
        //    rijndaelProvider.IV = Encoding.UTF8.GetBytes(encryptIv);
        //    ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

        //    byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
        //    byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

        //    return Convert.ToBase64String(encryptedData);
        //}
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="encryptString">要解密的字符串</param>
        /// <param name="encryptKey">Key</param>
        /// <param name="encryptIv">iv</param>
        /// <returns></returns>
        //public static string AESDecode(string decryptString, string decryptKey, string encryptIv)
        //{
        //    try
        //    {
        //        RijndaelManaged rijndaelProvider = new RijndaelManaged();
        //        rijndaelProvider.Key = Encoding.UTF8.GetBytes(decryptKey);
        //        rijndaelProvider.IV = Encoding.UTF8.GetBytes(encryptIv);
        //        ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

        //        byte[] inputData = Convert.FromBase64String(decryptString);
        //        byte[] decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

        //        return Encoding.UTF8.GetString(decryptedData);
        //    }
        //    catch { return string.Empty; }
        //}
        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int ConvertDateTimeUnix(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// MD5签名
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public string SignTopRequest(IDictionary<string, string> parameters ,string key)
        {
            // 第一步：把字典按Key的字母顺序排序
            //IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            //StringBuilder query = new StringBuilder();
            string parameter = string.Empty;
            //while (dem.MoveNext())
            //{
            //    string key = dem.Current.Key;
            //    string value = dem.Current.Value;
            //    //if(dem.MoveNext)
            //    query.Append(key).Append("=>'").Append(value).Append("'&'");
            //}
            //query.Append("key").Append("=").Append(secret);
            parameter = BuildQuery(parameters)+ "&key="+ key; //query.ToString();

            // 第三步：使用MD5加密
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(parameter));

            // 第四步：把二进制转化为大写的十六进制
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                string hex = bytes[i].ToString("X");
                if (hex.Length == 1)
                {
                    result.Append("0");
                }
                result.Append(hex);
            }

            return result.ToString();
        }
        /// <summary>
        /// 参数转换字符串
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string PrintDic(Dictionary<string, string> dic)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in dic)
            {
                sb.Append(item.Key + "=" + item.Value + "&");
            }

            string str = sb.ToString();
            str = str.Substring(0, str.Length - 1);

            return str;
        }
        /// <summary>  
        /// 将Dictionary序列化为json数据  
        /// </summary>  
        /// <param name="jsonData">json数据</param>  
        /// <returns></returns>  
        public static string DictionaryToJson(Dictionary<string, object> dic)
        {
            //实例化JavaScriptSerializer类的新实例  
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象  
                return jss.Serialize(dic);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 本接口特定加密
        /// </summary>
        /// <param name="parameters">参数字典</param>
        /// <param name="secret">密钥</param>
        /// <param name="client_id">客户Id</param>
        /// <param name="ts">时间戳</param>
        /// <returns></returns>
        public string SignMd5(IDictionary<string, string> parameters)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            //把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder();
            string parameter = string.Empty;
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                query.Append(value).Append("=>");
            }
           // query.Append(secret);

            var result = getMd5Hash(query.ToString()).ToLower();
            return result;
        }
        private static string getMd5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            char[] temp = input.ToCharArray();
            byte[] buf = new byte[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                buf[i] = (byte)temp[i];
            }
            byte[] data = md5Hasher.ComputeHash(buf);
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }  

        /// <summary>
        ///对字符串加密
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static string SignTopRequest(string par)
        {
            MD5 md5 = MD5.Create();

            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(par));
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                string hex = bytes[i].ToString("X");
                if (hex.Length == 1)
                {
                    result.Append("0");
                }
                result.Append(hex);
            }

            return result.ToString();
        }

        public static string GetMD5(string s)
        {
            return GetMD5ByEncoding(s, Encoding.GetEncoding("utf-8"));
        }
        /// <summary>
        /// 组装需要的参数
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string BuildQuery(IDictionary<string, string> parameters)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;

            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数

                if (hasParam)
                {
                    postData.Append("&");
                }

                postData.Append(name);
                postData.Append("=>");
                postData.Append(value);
              
                hasParam = true;

            }
            
            return postData.ToString();
        }

        public static string GetMD5ByEncoding(string s, Encoding en)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(en.GetBytes(s));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }


        /// <summary>
        /// 将json数据反序列化为Dictionary
        /// </summary>
        /// <param name="jsonData">json数据</param>
        /// <returns></returns>
        public static Dictionary<string, object> JsonToDictionary(string jsonData)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                return jss.Deserialize<Dictionary<string, object>>(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 将json数据反序列化为Dictionary
        /// </summary>
        /// <param name="jsonData">json数据</param>
        /// <returns></returns>
        public static List<Dictionary<string, object>> JsonToDictionaryList(string jsonData)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                return jss.Deserialize<List<Dictionary<string, object>>>(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
