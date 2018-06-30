using System.Text.RegularExpressions;
using System.Web;

namespace Library
{
    public static class SafeHelper
    {
        /// <summary>过滤SQL和HTML敏感字符
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSafeSqlandHtml(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            str = Regex.Replace(str, @"<applet[^>]*?>.*?</applet>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<body[^>]*?>.*?</body>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<embed[^>]*?>.*?</embed>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<frame[^>]*?>.*?</frame>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<frameset[^>]*?>.*?</frameset>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<html[^>]*?>.*?</html>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<style[^>]*?>.*?</style>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<layer[^>]*?>.*?</layer>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<link[^>]*?>.*?</link>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<ilayer[^>]*?>.*?</ilayer>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<meta[^>]*?>.*?</meta>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<object[^>]*?>.*?</object>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"-->", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<!--.*", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "eXeC", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "VaRcHaR", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "dEcLaRe", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "Char", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "delete", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "select", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "insert", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "update", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "truncate", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "chr", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "mid", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @";", string.Empty);
            str = Regex.Replace(str, @"'", string.Empty);
            str = Regex.Replace(str, @"&", string.Empty);
            str = Regex.Replace(str, @"%20", string.Empty);
            str = Regex.Replace(str, @"--", string.Empty);
            //str = Regex.Replace(str, @"==", string.Empty);
            str = Regex.Replace(str, @"<", string.Empty);
            str = Regex.Replace(str, @">", string.Empty);

            return str;
        }

        /// <summary>过滤SQL和HTML敏感字符
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSafeSql(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            str = Regex.Replace(str, "eXeC", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "VaRcHaR", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "dEcLaRe", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "Char", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "delete", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "select", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "insert", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "update", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "truncate", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "chr", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "mid", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @";", string.Empty);
            str = Regex.Replace(str, @"'", string.Empty);
            str = Regex.Replace(str, @"&", string.Empty);
            str = Regex.Replace(str, @"%20", string.Empty);
            str = Regex.Replace(str, @"--", string.Empty);
            //str = Regex.Replace(str, @"==", string.Empty);
            str = Regex.Replace(str, @"<", string.Empty);
            str = Regex.Replace(str, @">", string.Empty);

            return str;
        }

        public static string NoHtml(string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring))
            {
                return "";
            }
            else
            {
                //删除脚本
                Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<applet[^>]*?>.*?</applet>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<body[^>]*?>.*?</body>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<embed[^>]*?>.*?</embed>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<frame[^>]*?>.*?</frame>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<frameset[^>]*?>.*?</frameset>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<html[^>]*?>.*?</html>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<style[^>]*?>.*?</style>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<layer[^>]*?>.*?</layer>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<link[^>]*?>.*?</link>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<ilayer[^>]*?>.*?</ilayer>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<meta[^>]*?>.*?</meta>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<object[^>]*?>.*?</object>", "", RegexOptions.IgnoreCase);

                //删除HTML
                Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);

                //删除与数据库相关的词
                Htmlstring = Regex.Replace(Htmlstring, "select", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "insert", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "delete from", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "count''", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "drop table", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "truncate", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "asc", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "mid", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "char", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "exec", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "exec master", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net localgroup administrators", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "and", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net user", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "or", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net", "", RegexOptions.IgnoreCase);
                //Htmlstring = Regex.Replace(Htmlstring, "*", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "-", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "delete", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "drop", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "script", "", RegexOptions.IgnoreCase);

                //特殊的字符
                Htmlstring = Htmlstring.Replace("<", "");
                Htmlstring = Htmlstring.Replace(">", "");
                Htmlstring = Htmlstring.Replace("*", "");
                Htmlstring = Htmlstring.Replace("-", "");
                Htmlstring = Htmlstring.Replace("?", "");
                Htmlstring = Htmlstring.Replace("'", "''");
                Htmlstring = Htmlstring.Replace(",", "");
                Htmlstring = Htmlstring.Replace("/", "");
                Htmlstring = Htmlstring.Replace(";", "");
                Htmlstring = Htmlstring.Replace("*/", "");
                Htmlstring = Htmlstring.Replace("\r\n", "");
                Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

                return Htmlstring;
            }
        }

    }
}
