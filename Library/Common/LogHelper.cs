using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Library
{
    public class LogHelper
    {
        /// <summary>
        /// 保存日志,按月分文件夹，按日分文本文件。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="context"></param>
        public static void SaveLog(string text, string logType) 
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                string pathDic =  SysKeys.SYSTEM_LOG_SAVEPATH+ "\\" + DateTime.Now.ToString("yyyyMM");
                if (!Directory.Exists(pathDic))
                {
                    Directory.CreateDirectory(pathDic);
                }
                string path = pathDic + "\\" + logType + DateTime.Now.ToString("yyyyMMdd") + ".log";
                //XmlSerializer 
                //如果文件txt存在就打开，不存在就新建 .append 是追加写。
                fs = new FileStream(path, FileMode.Append);
                //写数据到txt
                sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("utf-8"));

                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"));
                sw.WriteLine(text);
                sw.WriteLine("");
            }
            catch (Exception )
            {
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }

            }
        }
        /// <summary>
        /// 保存字符串到文件
        /// </summary>
        /// <param name="text"></param>
        /// <param name="context"></param>
        public static void SaveTxt(string text)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                //XmlSerializer 
                //如果文件txt存在就打开，不存在就新建 .append 是追加写。
                fs = new FileStream(path, FileMode.Append);
                //写数据到txt
                sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("utf-8"));

                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"));
                sw.WriteLine(text);
                sw.WriteLine("");
            }
            catch (Exception e)
            {
                SaveLog("WxAPI.WxUtil.SaveTxt(string text)[" + e.Message + "]" + e.StackTrace, "Wx");
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }

            }
        }
        /// <summary>
        /// 保存字符串到文件
        /// </summary>
        /// <param name="text"></param>
        /// <param name="context"></param>
        public static void SaveTxt(string text, string filePath)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                //XmlSerializer 
                //如果文件txt存在就打开，不存在就新建 .append 是追加写。
                fs = new FileStream(filePath, FileMode.Append);
                //写数据到txt
                sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("utf-8"));

                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"));
                sw.WriteLine(text);
                sw.WriteLine("");
            }
            catch (Exception e)
            {
                SaveLog("WxAPI.WxUtil.SaveTxt(string text, string filePath)" + e.Message, "Wx");
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }

            }
        }
        /// <summary>
        /// 从文件中获取字符串
        /// </summary>
        /// <param name="text"></param>
        /// <param name="context"></param>
        public static List<string> getTxt()
        {
            List<string> strlist = new List<string>();
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                //XmlSerializer 
                //如果文件txt存在就打开，不存在就新建 .append 是追加写
                fs = new FileStream(path, FileMode.OpenOrCreate);
                //写数据到txt
                sr = new StreamReader(fs, System.Text.Encoding.GetEncoding("utf-8"));
                string temp = "";
                //读出
                while ((temp = sr.ReadLine()) != null)
                {
                    strlist.Add(temp);
                }
            }
            catch
            {
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return strlist;
        }
        /// <summary>
        /// 从文件中获取字符串
        /// </summary>
        /// <param name="text"></param>
        /// <param name="context"></param>
        public static List<string> getTxt(string filePath)
        {
            List<string> strlist = new List<string>();
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                //XmlSerializer 
                //如果文件txt存在就打开，不存在就新建 .append 是追加写
                fs = new FileStream(filePath, FileMode.OpenOrCreate);
                //写数据到txt
                sr = new StreamReader(fs, System.Text.Encoding.GetEncoding("utf-8"));
                string temp = "";
                //读出
                while ((temp = sr.ReadLine()) != null)
                {
                    strlist.Add(temp);
                }
            }
            catch
            {
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return strlist;
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        public static void deleteTxtFile()
        {
            //XmlSerializer 


            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// 文件路劲
        /// </summary>
        private static string path = AppDomain.CurrentDomain.BaseDirectory + "Log\\test.txt";
    }
}
