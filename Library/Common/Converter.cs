using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    /// <summary>
    /// 各种值类型转换
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// 小数转整数，类似四舍五入
        /// </summary>
        /// <param name="value">小数</param>
        /// <returns>整数</returns>
        public static int ToInt(this decimal value)
        {
            var decimalNum = value - (int)value;
            if (decimalNum >= 0.5m)
                return ((int)value) + 1;
            else
                return (int)value;
        }

        /// <summary>
        /// double转整数，类似四舍五入
        /// </summary>
        /// <param name="value">double</param>
        /// <returns>整数</returns>
        public static int ToInt(this double value)
        {
            return ((decimal)value).ToInt();
        }


        #region Convert string type to other types
        /// <summary>
        /// 字符串转int
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static int ToInt(this string s, int defalut = 0)
        {
            int result = defalut;
            if (int.TryParse(s, out result))
                return result;
            else
                return defalut;
        }
        /// <summary>
        /// 字符串转int
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static long ToLong(this string s, int defalut = 0)
        {
            long result = defalut;
            if (long.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        /// <summary>
        /// 字符串转bool
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static bool ToBool(this string s, bool defalut = false)
        {
            bool result = defalut;
            if (bool.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        /// <summary>
        /// 字符串转double
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static double ToDouble(this string s, double defalut = 0)
        {
            double result = defalut;
            if (double.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        /// <summary>
        /// 字符串转decimal
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string s, decimal defalut = 0)
        {
            decimal result = defalut;
            if (decimal.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        /// <summary>
        /// 字符串转日期
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string s, DateTime defalut = new DateTime())
        {
            DateTime result = defalut;
            if (DateTime.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        #endregion
    }
}
