using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Web
{
    public class RegexR
    {
        //公共检测方法
        private bool PublicFunction(string account, string regextext)
        {
            if (Regex.IsMatch(account, regextext) == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 手机号码，只匹配1开头，共11为数字1[0-9]{10}
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool isPhones(string phone)
        {
            return PublicFunction(phone, @"1[0-9]{10}");
        }

        /// <summary>
        /// 替换手机号码
        /// </summary>
        /// <param name="phoneNum"></param>
        /// <returns></returns>
        public long PhoneNum(string phoneNum)
        {
            string[] strs = Regex.Replace(phoneNum, "[^0-9]", ",").Split(',');
            foreach (string str in strs)
            {
                if (isPhones(str))
                    return long.Parse(Regex.Replace(str, "[^0-9]", ""));
            }
            return 0;
        }
    }
}