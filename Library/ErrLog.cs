using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace Library
{
    public class ErrLog
    {
        public static string ErrPath = System.Configuration.ConfigurationManager.AppSettings["ErrLogPath"].ToString();
        public static void WriteLog(System.Web.UI.Page page, ArrayList strLog)
        {
            string strPath;
            ErrPath = page.Server.MapPath("") + ErrPath;

            strPath = string.Format("{0}\\{1}.log", ErrPath, DateTime.Now.ToString("yyyy年MM月dd日"));
            //throw (new Exception(strPath));
            using (FileStream fs = new FileStream(strPath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter m_streamWriter = new StreamWriter(fs))
                {
                    m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    foreach (string log in strLog)
                    {
                        m_streamWriter.WriteLine(log);
                    }
                    m_streamWriter.Flush();
                    m_streamWriter.Close();
                }
                fs.Close();
            }
        }
    }
}
