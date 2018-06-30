using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Library
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
        /// 检测输入汉字是否匹配
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public bool Texts(string txt)
        {
            return PublicFunction(txt, @"^[\u4e00-\u9fa5]{2,6}$");
        }

        /// <summary>
        /// 检测输入的正整数是否匹配
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Nums(string num)
        {
            return PublicFunction(num, @"^[1-9]\d{0,8}$");
        }

        /// <summary>
        /// 检测输入的年份是否匹配
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Year(string num)
        {
            return PublicFunction(num, @"^[1-9]\d\d\d");
        }

        /// <summary>
        /// 检测输入的电话号码是否匹配
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool Phones(string phone)
        {
            return PublicFunction(phone, @"^\d{3,4}-\d{7,10}$");
        }

        /// <summary>
        /// ^[1-9]d*$　 　 //匹配正整数
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool PositiveInteger(string number)
        {
            return PublicFunction(number, @"^[1-9]d*$");
        }

        /// <summary>
        /// ^[1-9]d*|0$　 匹配非负整数（正整数 + 0）
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool PositiveIntAndZero(string number)
        {
            return PublicFunction(number, @"^[1-9]d*|0$");
        }

        /// <summary>
        /// 匹配所有都是数字0 - 9
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool AllNumber(string number)
        {
            return PublicFunction(number, @"^[0-9]*$");
        }

        /// <summary>
        /// 检测输入的字符是否匹配为正浮点数(精确到小数点后2位),包括正整数
        /// </summary>
        /// <param name="anynum"></param>
        /// <returns></returns>
        public bool AnyNums(string anynum)
        {
            string anynumpp = @"^[1-9]\d{0,7}\.\d{1,2}$";//匹配除0.12形式的小数
            string xnumpp = @"^[0]\.\d{1,2}$";//匹配0.12形式的小数
            if (PublicFunction(anynum, xnumpp) == true || PublicFunction(anynum, anynumpp) == true || Nums(anynum) == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 匹配非负浮点数,例如: 0.1/0.12/0/12
        /// </summary>
        /// <param name="anynum"></param>
        /// <returns></returns>
        public bool NotFuFudian(string anynum)
        {
            if (AnyNums(anynum) == true || anynum == "0")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 检测输入的字符是否匹配为浮点数,包括正、负数
        /// </summary>
        /// <param name="anynum"></param>
        /// <returns></returns>
        public bool AnyDoubleNums(string anynum)
        {
            string anynumpp = @"^-|[1-9]\d{0,7}\.\d{1,2}$";//匹配除0.12形式的小数
            string xnumpp = @"^-|[0]\.\d{1,2}$";//匹配0.12形式的小数
            if (PublicFunction(anynum, xnumpp) == true || PublicFunction(anynum, anynumpp) == true || Nums(anynum) == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 检测输入的正整数是否匹配条形码13位
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool TxmNums(string num)
        {
            return PublicFunction(num, @"^[0-9]\d{12}$");
        }

        /// <summary>
        /// 匹配帐号是否合法(字母开头,允许10-20字符,允许字母数字下划线):^[a-zA-Z][a-zA-Z0-9_]{9,19}$
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool Account(string account)
        {
            return PublicFunction(account, @"^[a-zA-Z][a-zA-Z0-9_]{5,19}$");
        }

        /// <summary>
        /// 验证用户密码:“^[a-zA-Z][a-zA-Z0-9]{7,14}$”正确格式为:以字母开头,长度在8-15之间,只能包含字母、数字
        /// </summary>
        /// <param name="psw"></param>
        /// <returns></returns>
        public bool PassWord(string psw)
        {
            return PublicFunction(psw, @"^[a-zA-Z][a-zA-Z0-9]{7,14}$");
        }

        /// <summary>
        /// 匹配腾讯QQ号:[1-9][0-9]{4,}从10000号开始
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool QQ(string number)
        {
            return PublicFunction(number, @"[1-9][0-9]{4,}");
        }

        /// <summary>
        /// 匹配中国邮政编码:[1-9]d{5}(?!d) 评注:中国邮政编码为6位数字
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool Post(string number)
        {
            return PublicFunction(number, @"[1-9]d{5}(?!d)");
        }

        /// <summary>
        /// 匹配身份证:d{15}|d{18} 评注:中国的身份证为15位或18位
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool IdCard(string number)
        {
            return PublicFunction(number, @"d{15}|d{18}");
        }

        /// <summary>
        /// 匹配Email地址的正则表达式:w+([-+.]w+)*@w+([-.]w+)*.w+([-.]w+)*
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public bool Email(string mail)
        {
            return PublicFunction(mail, @"w+([-+.]w+)*@w+([-.]w+)*.w+([-.]w+)*");
        }

        /// <summary>
        /// 匹配网址URL的正则表达式:[a-zA-z]+://[^s]* 评注:网上流传的版本功能很有限,上面这个基本可以满足需求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool Url(string url)
        {
            return PublicFunction(url, @"[a-zA-z]+://[^s]*");
        }

        /// <summary>
        /// 匹配ip地址:d+.d+.d+.d+ 评注:提取ip地址时有用
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool Ip(string ip)
        {
            return PublicFunction(ip, @"d+.d+.d+.d+");
        }


        private bool HasChar(string input, string pattern)
        {
            int len = input.Length;
            for (int i = 0; i < len; i++)
            {
                if (pattern.Contains(input[i].ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 验证是否含有^%&#038;&#8217;,;=?$&#8221;等特殊字符
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool SpecialCharacter(string input)
        {
            return HasChar(input, @"[~`!#$%^&*()-+={}:;'<>,/?\|]");
        }

        /// <summary>
        /// 专门检查email中是否含有特殊字符(必须包含@ .)
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool EmailSpecialCharacter(string email)
        {
            return HasChar(email, @"[~`!#$%^&*()-+={}:;'<>,/?\|]");
        }
    }
}