using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataAccess {
    public class MSMDataConn {
        /// <summary>
        /// 获取Access数据库的连接
        /// </summary>
        /// <returns></returns>
        protected SqlConnection GetConn() {
            string strConn = ConfigurationManager.AppSettings["ConnectionMsg"];
            //string strConn = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["DBConn"]);
            return new SqlConnection(strConn);
        }

        /// <summary>
        /// 执行对Access数据库的编录操作，成功返回true,失败为false
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteSqlNoneQuery(string sql) {
            SqlConnection conn = null;
            try {
                conn = GetConn();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            } catch (Exception ex) {
                throw ex;
            } finally {
                if (conn != null) {
                    conn.Close();
                }
            }
        }

        public DataSet ExecuteQuery(string sql) {
            SqlConnection conn = null;
            DataSet dsResult = new DataSet();
            SqlDataAdapter sda = null;
            try {
                conn = GetConn();
                conn.Open();
                sda = new SqlDataAdapter(sql, conn);
                sda.Fill(dsResult);
            } catch (Exception) {
                return null;
            } finally {
                sda.Dispose();
                conn.Close();
                conn.Dispose();
            }
            return dsResult;
        }

        /// <summary>
        /// 执行对MsSql数据库的查询操作，成功返回包含数据的DataTable,数据不存在则返回null
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Query(string sql) {
            SqlConnection conn = null;
            try {
                conn = GetConn();
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            } catch (Exception ex) {
                throw ex;
            } finally {
                if (conn != null) {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 账户可用短信数量
        /// </summary>
        /// <param name="uCode"></param>
        /// <returns>0短信数量为0，-1短信账号不存在，其它为短信数量</returns>
        public int getAvCount(string uCode) {
            int count = 0;
            string sql = string.Format("select * from users where usersID like '{0}'", uCode);
            DataTable dt = Query(sql);
            if (dt.Rows.Count > 0) {
                count = int.Parse(dt.Rows[0]["Acount"].ToString());
                sql = string.Format("select count(*) as num from Mssage where Status=0 and usersID like '{0}'", uCode);
                DataSet ds = ExecuteQuery(sql);
                if (ds.Tables[0].Rows.Count > 0) {
                    count = count - int.Parse(ds.Tables[0].Rows[0]["num"].ToString());
                }
            } else {
                count = -1;
            }
            return count;
        }

        /// <summary>
        /// 已发短信数量
        /// </summary>
        /// <param name="uCode"></param>
        /// <returns>0短信数量为0，-1短信账号不存在，其它为短信数量</returns>
        public int getAvCounted(string uCode) {
            int count = 0;
            string sql = string.Format("select (total-Acount)as vCount from users where usersID like '{0}'", uCode);
            DataTable dt = Query(sql);
            if (dt.Rows.Count > 0) {
                count = int.Parse(dt.Rows[0]["vCount"].ToString());
            } else {
                count = -1;
            }
            return count;
        }

        /// <summary>
        /// 发送手机短信类
        /// </summary>
        /// <param name="sendPhone">手机号</param>
        /// <param name="SMSContent">内容</param>
        /// <param name="uCode">账号</param>
        /// <returns>0短信数量为0，-1账号不存在，1发送成功，-2发送失败</returns>
        public int sendMsg(string sendPhone, string SMSContent, string uCode) {
            int intCount = 0;
            int type = 0;
            string sendTime = DateTime.Now.ToString();
            string strSql = string.Format("insert into Mssage(sendMsg,usersID,toPhone,type,status,sendTime)values('{0}','{1}','{2}',{3},0,'{4}')", SMSContent, uCode, sendPhone, type, sendTime);
            int nowCount = getAvCount(uCode);
            if (nowCount == 0 || nowCount == -1) {
                intCount = nowCount;
            } else {
                if (ExecuteSqlNoneQuery(strSql)) {
                    intCount = 1;//发送成功
                } else {
                    intCount = -2;//发送失败
                }
            }
            return intCount;
        }
    }
}
