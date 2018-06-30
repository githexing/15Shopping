using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Collections;
using DataAccess;

namespace Library
{
    public class BackUpSystem
    {
        /// <summary>
        ///  因为DataReader独占连接，本程序需要两个Connection,并且连接的数据库是master,所以要初始化新的连接字符串
        /// </summary>
        public static string connectionString = System.Configuration.ConfigurationManager.AppSettings["DBmaster"].ToString();
        public static string DBpath = System.Configuration.ConfigurationManager.AppSettings["DBpath"].ToString();
        public static string DBName = System.Configuration.ConfigurationManager.AppSettings["DBName"].ToString();
        public static SqlConnection sc = new SqlConnection(connectionString);
        #region 备份整个数据库
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string BackUp(System.Web.UI.Page page)
        {

            string newname = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒") + ".bak";
            StringBuilder sb = new StringBuilder();
            string path = page.Server.MapPath("") + @"\";
            sb.Append(page.Server.MapPath("") + @"\");
            sb.Append(DBpath);
            if (!Directory.Exists(sb.ToString()))
            {
                Directory.CreateDirectory(sb.ToString());
            }
            sb.Append(@"\");
            sb.Append(newname);
            string sql = "BACKUP DATABASE @DBName to DISK =@DISK";
            try
            {
                SqlParameter[] sp ={
                new SqlParameter("@DBName", SqlDbType.NVarChar,50),
                new SqlParameter("@DISK", SqlDbType.NVarChar,200)};
                sp[0].Value = DBName;
                sp[1].Value = sb.ToString();
                OLDSqlHelper.ExecuteNonQuery(sc, CommandType.Text, sql, sp);
                return newname;
            }
            catch (Exception ex)
            {
                ArrayList al = new ArrayList();
                al.Add("--------------------------数据备份错误---------------------------------");
                al.Add(ex.ToString());
                ErrLog.WriteLog(page, al);
                return null;
            }
        }
        #endregion

        #region 根据时间自动备份整个数据库
        /// <summary>
        /// 根据时间自动备份整个数据库
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string BackUpByday(string path)
        {
            string date = DataAccess.DbHelperSQL.GetSingle(" select getdate()").ToString();
            string newname = Convert.ToDateTime(date).ToString("yyyy年MM月dd日") + ".bak";
            StringBuilder sb = new StringBuilder();
            sb.Append(path + @"\");
            sb.Append(DBpath);
            if (!Directory.Exists(sb.ToString()))
            {
                Directory.CreateDirectory(sb.ToString());
            }
            sb.Append(@"\");
            sb.Append(newname);
            if (File.Exists(sb.ToString()))
            {
                return "";
            }
            string sql = "BACKUP DATABASE @DBName to DISK =@DISK";
            try
            {
                SqlParameter[] sp ={
                new SqlParameter("@DBName", SqlDbType.NVarChar,50),
                new SqlParameter("@DISK", SqlDbType.NVarChar,200)};
                sp[0].Value = DBName;
                sp[1].Value = sb.ToString();
                OLDSqlHelper.ExecuteNonQuery(sc, CommandType.Text, sql, sp);
                return newname;
            }
            catch (Exception ex)
            {
                ArrayList al = new ArrayList();
                al.Add("--------------------------数据备份错误---------------------------------");
                al.Add(ex.ToString());
                //ErrLog.WriteLog(page,al);
                return null;
            }
        }
        #endregion

        #region 还原整个数据库
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathBack">还原文件的路径</param>
        /// <param name="strDBName">数据库名</param>
        /// <returns></returns>
        public static bool SQLBack(System.Web.UI.Page page, string pathBack)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            KillSPID(page, DBName);
            bool IsBack = false;
            try
            {

                if (!pathBack.EndsWith(".bak"))
                {
                    throw new Exception("请选择正确的备份设备！");
                }
                string logicalName = pathBack.Substring(pathBack.LastIndexOf('\\') + 1).TrimEnd(new char[] { 'b', 'a', 'k', '.' });
                string cmdText = "use master restore database " + DBName + " from disk = '" + pathBack + "' WITH   REPLACE use "+DBName;
                SqlParameter[] sp ={ };
                OLDSqlHelper.ExecuteNonQuery(sc, CommandType.Text, cmdText, sp);
                IsBack = true;
            }
            catch (Exception ex)
            {
                ArrayList al = new ArrayList();
                al.Add("--------------------------数据库还原错误---------------------------------");
                al.Add(ex.ToString());
                ErrLog.WriteLog(page, al);
            }
            return IsBack;
        }


        /// <summary>
        /// 关闭当前连接数据库的连接进程
        /// </summary>
        /// <param name="DBName">要关闭进程的数据库名称</param>
        public static void KillSPID(System.Web.UI.Page page, string DBName)
        {
            string strDBName = DBName;
            string strSQL = String.Empty, strSQLKill = String.Empty;
            try
            {

                //读取连接当前数据库的进程
                strSQL = "select spid from master..sysprocesses where dbid=db_id('" + strDBName + "')";
                SqlParameter[] sp ={ };
                using (SqlDataReader mydr = OLDSqlHelper.ExecuteReader(connectionString, CommandType.Text, strSQL, sp))
                {
                    //开取杀进程的数据连接
                    while (mydr.Read())
                    {
                        strSQLKill = "kill " + mydr["spid"].ToString();
                        SqlParameter[] sps ={ };
                        OLDSqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, strSQLKill, sps);
                    }
                    mydr.Close();
                }
            }
            catch (Exception ex)
            {
                ArrayList al = new ArrayList();
                al.Add("--------------------------清除数据库" + DBName + "进程错误错误---------------------------------");
                al.Add(ex.ToString());
                ErrLog.WriteLog(page, al);
            }
        }
        #endregion
        #region 获得备份文件列表
        /// <summary>
        /// 获得备份文件列表
        /// </summary>
        /// <returns></returns>
        public static List<BackModel> BackList(string dbpath)
        {
            if (!Directory.Exists(dbpath))
            {
                Directory.CreateDirectory(dbpath);
            }
            FileInfo[] fi = new DirectoryInfo(dbpath).GetFiles();
            List<BackModel> blist = new List<BackModel>();
            foreach (FileInfo fiTemp in fi)
            {
                if (fiTemp.Name.Contains(".bak"))
                {
                    BackModel bm = new BackModel();
                    bm.CreationTime = fiTemp.CreationTime;
                    bm.fileName = fiTemp.Name;
                    blist.Add(bm);
                }
            }
            return blist;
        }
        #endregion
        #region 删除备份文件
        public static bool DelBackUp(System.Web.UI.Page page, string Xpath)
        {
            try
            {
                File.Delete(Xpath);
                return true;
            }
            catch (Exception ex)
            {
                ArrayList al = new ArrayList();
                al.Add("-------------------------删除数据库备份错误---------------------------------");
                al.Add(ex.ToString());
                ErrLog.WriteLog(page, al);
                return false;
            }
        }
        #endregion
    }
    public class BackModel
    {
        private string _fileName;
        private DateTime _CreationTime;
        public string fileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        public DateTime CreationTime
        {
            get { return _CreationTime; }
            set { _CreationTime = value; }
        }

    }
}
