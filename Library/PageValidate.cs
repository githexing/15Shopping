using System;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Library
{
	public class PageValidate
	{
        private static Regex RegNumberOrDecimal = new Regex("^[1|2|3|4|5|6|7|8|9]{1,}[0]*[.]*[0-9]{0,3}$");//判断是否是数字。可含小数
		private static Regex RegNumber = new Regex("^[0-9]+$");
		private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
		private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
		private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
		private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
        private static Regex RegCHZN = new Regex("^[\\u4E00-\\u9FA5\\uF900-\\uFA2D]+$");
        private static Regex RegInt = new Regex("^[0-9]\\d*$"); //匹配大于零的正整数^[1-9]+[0-9]*$
        private static Regex RegDecimalTwo = new Regex("^[0-9]+[.]?[0-9]{0,2}$"); //判断是否正整数和带两位小数的浮点数
        private static Regex RegYhm = new Regex("^[a-zA-Z0-9]{1}[a-zA-Z0-9]{2,10}$");//登录名验证
        //private static Regex RegYhm = new Regex("^[a-zA-Z0-9]{1}([a-zA-Z0-9]|[_]){5,9}$");//登录名验证
        private static Regex regTrueName = new Regex(@"^(?!^\d+$)[a-zA-Z_@\.\u4e00-\u9fa5]{2,30}$");//姓名必须为2-30位字母、中文!
        private static Regex regIdend = new Regex(@"\d{17}[\dXx]");//身份证
        private static Regex regPhone = new Regex(@"^1\d{10}$");//电话号码
        private static Regex regbank = new Regex(@"[0-9]{16}|[0-9]{19}");//卡号
        //private static Regex regbank1 = new Regex(@"[0-9]{16}");//卡号
        public PageValidate()
		{
		}

        /// <summary>
        /// 验证姓名
        /// </summary>
        /// <param name="trueName"></param>
        /// <returns></returns>
        public static bool RegexTrueName(string trueName)
        {
            Match m = regTrueName.Match(trueName);
            return m.Success;
        }

        /// <summary>
        /// 验证卡号
        /// </summary>
        /// <param name="trueName"></param>
        /// <returns></returns>
        public static bool RegexTrueBank(string truegbank)
        {
            Match m = regbank.Match(truegbank);
            return m.Success;
        }
        //public static bool RegexTrueBank1(string truegbank)
        //{
        //    Match m = regbank1.Match(truegbank);
        //    return m.Success;
        //}

        /// <summary>
        /// 验证身份
        /// </summary>
        /// <param name="iden"></param>
        /// <returns></returns>
        public static bool RegexIden(string iden)
        {
            if (iden.Length != 18)
            {
                return false;
            }
            Match m = regIdend.Match(iden);
            return m.Success;
        }

        /// <summary>
        /// 验证手机号
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool RegexPhone(string phone)
        {
            Match m = regPhone.Match(phone);
            return m.Success;
        }

		#region 数字字符串检查		
        /// <summary>
        ///  验证大于0的整数
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsInt(string inputData)
        {
            Match m = RegInt.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 判断给定的字符是否为大于0整数。
        /// </summary>
        /// <param name="str">给定的字符</param>
        /// <returns></returns>
        public static bool IsInteger(string str)
        {
            try
            {
                if (Convert.ToInt32(str) > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 判断给定的字符是否为大于0整数。
        /// </summary>
        /// <param name="str">给定的字符</param>
        /// <returns></returns>
        public static bool IsInteger(object str)
        {
            try
            {
                if (Convert.ToInt32(str) > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 判断给定的字符是否为大于0整数。
        /// </summary>
        /// <param name="str">给定的字符</param>
        /// <returns></returns>
        public static bool IsLong(string str)
        {
            try
            {
                if (Convert.ToInt64(str) > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 判断给定的字符是否为大于0整数。
        /// </summary>
        /// <param name="str">给定的字符</param>
        /// <returns></returns>
        public static bool IsLong(object str)
        {
            try
            {
                if (Convert.ToInt64(str) > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 验证正数和浮点数
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsDecimalTwo(string inputData)
        {
            Match m = RegDecimalTwo.Match(inputData);
            return m.Success;
        }
		/// <summary>
		/// 检查Request查询字符串的键值，是否是数字，最大长度限制
		/// </summary>
		/// <param name="req">Request</param>
		/// <param name="inputKey">Request的键值</param>
		/// <param name="maxLen">最大长度</param>
		/// <returns>返回Request查询字符串</returns>
		public static string FetchInputDigit(HttpRequest req, string inputKey, int maxLen)
		{
			string retVal = string.Empty;
			if(inputKey != null && inputKey != string.Empty)
			{
				retVal = req.QueryString[inputKey];
				if(null == retVal)
					retVal = req.Form[inputKey];
				if(null != retVal)
				{
					retVal = SqlText(retVal, maxLen);
					if(!IsNumber(retVal))
						retVal = string.Empty;
				}
			}
			if(retVal == null)
				retVal = string.Empty;
			return retVal;
		}
        /// <summary>
        /// 是否数字字符串可含小数
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumberOrDecimal(string inputData)
        {
            Match m = RegNumberOrDecimal.Match(inputData);
            return m.Success;
        }
		/// <summary>
		/// 是否数字字符串
		/// </summary>
		/// <param name="inputData">输入字符串</param>
		/// <returns></returns>
		public static bool IsNumber(string inputData)
		{
			Match m = RegNumber.Match(inputData);
			return m.Success;
		}		
		/// <summary>
		/// 是否数字字符串 可带正负号
		/// </summary>
		/// <param name="inputData">输入字符串</param>
		/// <returns></returns>
		public static bool IsNumberSign(string inputData)
		{
			Match m = RegNumberSign.Match(inputData);
			return m.Success;
		}		
		/// <summary>
		/// 是否是浮点数
		/// </summary>
		/// <param name="inputData">输入字符串</param>
		/// <returns></returns>
		public static bool IsDecimal(string inputData)
		{
			Match m = RegDecimal.Match(inputData);
			return m.Success;
		}		
		/// <summary>
		/// 是否是浮点数 可带正负号
		/// </summary>
		/// <param name="inputData">输入字符串</param>
		/// <returns></returns>
		public static bool IsDecimalSign(string inputData)
		{
			Match m = RegDecimalSign.Match(inputData);
			return m.Success;
		}		

		#endregion

		#region 中文检测

		/// <summary>
		/// 检测是否有中文字符
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsHasCHZN(string inputData)
		{
			Match m = RegCHZN.Match(inputData);
			return m.Success;
        }
        public static bool checkUserCode(string inputData)
        {
            Match m = RegYhm.Match(inputData);
            return m.Success;
        }	

		#endregion

		#region 邮件地址
		/// <summary>
		/// 是否是浮点数 可带正负号
		/// </summary>
		/// <param name="inputData">输入字符串</param>
		/// <returns></returns>
		public static bool IsEmail(string inputData)
		{
			Match m = RegEmail.Match(inputData);
			return m.Success;
		}		

		#endregion

        #region 是否是时间格式
        /// <summary>
        /// 判断一个字符串是否时间格式
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDateTime(string inputData)
        {
            try
            {
                Convert.ToDateTime(inputData);
                return true;//是   
            }
            catch
            {
                return false;//不是   
            }
        }

        #endregion

		#region 其他

		/// <summary>
		/// 检查字符串最大长度，返回指定长度的串
		/// </summary>
		/// <param name="sqlInput">输入字符串</param>
		/// <param name="maxLength">最大长度</param>
		/// <returns></returns>			
		public static string SqlText(string sqlInput, int maxLength)
		{			
			if(sqlInput != null && sqlInput != string.Empty)
			{
				sqlInput = sqlInput.Trim();							
				if(sqlInput.Length > maxLength)//按最大长度截取字符串
					sqlInput = sqlInput.Substring(0, maxLength);
			}
			return sqlInput;
		}		
		/// <summary>
		/// 字符串编码
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static string HtmlEncode(string inputData)
		{
			return HttpUtility.HtmlEncode(inputData);
		}
		/// <summary>
		/// 设置Label显示Encode的字符串
		/// </summary>
		/// <param name="lbl"></param>
		/// <param name="txtInput"></param>
		public static void SetLabel(Label lbl, string txtInput)
		{
			lbl.Text = HtmlEncode(txtInput);
		}
		public static void SetLabel(Label lbl, object inputObj)
		{
			SetLabel(lbl, inputObj.ToString());
		}		
		//字符串清理
		public static string InputText(string inputString, int maxLength) 
		{			
			StringBuilder retVal = new StringBuilder();

			// 检查是否为空
			if ((inputString != null) && (inputString != String.Empty)) 
			{
				inputString = inputString.Trim();
				
				//检查长度
				if (inputString.Length > maxLength)
					inputString = inputString.Substring(0, maxLength);
				
				//替换危险字符
				for (int i = 0; i < inputString.Length; i++) 
				{
					switch (inputString[i]) 
					{
						case '"':
							retVal.Append("&quot;");
							break;
						case '<':
							retVal.Append("&lt;");
							break;
						case '>':
							retVal.Append("&gt;");
							break;
						default:
							retVal.Append(inputString[i]);
							break;
					}
				}				
				retVal.Replace("'", " ");// 替换单引号
			}
			return retVal.ToString();
			
		}
		/// <summary>
		/// 转换成 HTML code
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>string</returns>
		public static string Encode(string str)
		{			
			str = str.Replace("&","&amp;");
			str = str.Replace("'","''");
			str = str.Replace("\"","&quot;");
			str = str.Replace(" ","&nbsp;");
			str = str.Replace("<","&lt;");
			str = str.Replace(">","&gt;");
			str = str.Replace("\n","<br>");
			return str;
		}
		/// <summary>
		///解析html成 普通文本
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>string</returns>
		public static string Decode(string str)
		{			
			str = str.Replace("<br>","\n");
			str = str.Replace("&gt;",">");
			str = str.Replace("&lt;","<");
			str = str.Replace("&nbsp;"," ");
			str = str.Replace("&quot;","\"");
			return str;
		}
        public static string GetMd5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
        }

        #endregion
        /// <summary>
        /// 是否Ip
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsIp(string s)
        {
            string text1 = @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$";
            return Regex.IsMatch(s, text1);
        }

    }
}
