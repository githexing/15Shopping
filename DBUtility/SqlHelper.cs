using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using DataAccess;
using System.Text.RegularExpressions;

/// <summary>
/// SqlHelper 的摘要说明
/// </summary>
namespace DataAccess
{
    /// <summary>
    /// SQL帮助类(抽象类)
    /// </summary>
    public abstract class SqlHelper
    {
        #region 获取数据库连接字符串,其属于静态变量且只读,项目中所有文档可以直接使用,但不能修改
        /// <summary>
        /// 获取数据库连接字符串,其属于静态变量且只读,项目中所有文档可以直接使用,但不能修改
        /// </summary>
        public static readonly string connStrs = PubConstant.ConnectionString;
        #endregion

        #region 执行ExecuteNonQuery(),指定连接字符串,提供SqlParameter[]
        /// <summary>
        /// 执行ExecuteNonQuery(),指定连接字符串,提供SqlParameter[]
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
                int val = cmd.ExecuteNonQuery();

                //清空SqlCommand中的参数列表
                cmd.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region 执行ExecuteNonQuery(),指定SqlConnection,提供SqlParameter[] (sql)
        /// <summary>
        /// 执行ExecuteNonQuery(),指定SqlConnection,提供SqlParameter[] (sql)
        /// </summary>
        /// <param name="conn">一个现有的数据库连接</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParams);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion


        #region 执行ExecuteNonQuery()事务处理,使用事务连接字符串,提供SqlParameter[]
        /// <summary>
        /// 执行ExecuteNonQuery()事务处理,使用事务连接字符串,提供SqlParameter[]
        /// </summary>
        /// <param name="trans">SQL事务</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="cmdParams">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParams);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion

        #region 通过数据适配器（SqlDataAdapter）的UPdate方法,保存相应数据库表的DataTable数据
        /// <summary>
        /// 通过数据适配器（SqlDataAdapter）的UPdate方法，保存相应数据库表的DataTable数据
        /// </summary>
        /// <param name="connStrs">数据库连接字符串</param>
        /// <param name="tableName">数据库中数据表名</param>
        /// <param name="dataTable">要提交的Datatable</param>
        /// <returns>执行后影响的行数</returns>
        public static int UpdateDataTable(string connectionString, string tableName, DataTable dataTable)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter dap = new SqlDataAdapter("select top 1 * from " + tableName, conn);
            SqlCommandBuilder commb = new SqlCommandBuilder(dap);
            dap.UpdateCommand = commb.GetUpdateCommand();
            return dap.Update(dataTable);
        }
        #endregion

        #region 执行ExecuteTransac()事务处理,指定连接字符串,提供SQL语句(string数组),如出错一并回滚(sql)
        /// <summary>
        /// 执行ExecuteTransac()事务处理,指定连接字符串,提供SQL语句(string数组),如出错一并回滚(sql)
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="cmdText">SQL语句字符串类型的数组</param>
        /// <returns></returns>
        public static bool ExecuteTransac(string connectionString, string[] cmdText)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction transaction = null;

            try
            {
                cnn.Open();

                transaction = cnn.BeginTransaction();
                cmd.Transaction = transaction;
                cmd.Connection = cnn;

                for (int i = 0; i < cmdText.Length; i++)
                {
                    if (cmdText[i] == null) continue;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = cmdText[i];
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }
        #endregion

        #region 执行AccessExecuteTransac()事务处理,指定连接字符串,提供SQL语句(string数组),如出错一并回滚(access)
        /// <summary>
        /// 执行AccessExecuteTransac()事务处理,指定连接字符串,提供SQL语句数组(string数组),如出错一并回滚
        /// </summary>
        /// <param name="cmdText">SQL语句字符串类型的数组</param>
        /// <returns></returns>
        public static bool AccessExecuteTransac(string connectionString, string[] cmdText)
        {
            OleDbConnection cnn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            OleDbTransaction transaction = null;

            try
            {
                cnn.Open();

                transaction = cnn.BeginTransaction();
                cmd.Transaction = transaction;
                cmd.Connection = cnn;

                for (int i = 0; i < cmdText.Length; i++)
                {
                    if (cmdText[i] == null) continue;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = cmdText[i];
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }
        #endregion

        #region 执行ExecuteTransac()事务处理,指定连接字符串,提供SQL语句(ArrayList数组),如出错一并回滚(重载1)
        /// <summary>
        /// 执行ExecuteTransac()事务处理,指定连接字符串,提供SQL语句(ArrayList数组),如出错一并回滚(重载1)
        /// </summary>
        /// <param name="array">动态数组</param>
        /// <returns></returns>
        public static bool ExecuteTransac(string connectionString, ArrayList array)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction transaction = null;

            try
            {
                cnn.Open();

                transaction = cnn.BeginTransaction();
                cmd.Transaction = transaction;
                cmd.Connection = cnn;

                for (int i = 0; i < array.Count; i++)
                {
                    if (array[i] == null) continue;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = array[i].ToString();
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }
        #endregion

        #region 执行ExecuteTransac()事务处理,指定连接字符串,提供SQL语句(string数组),SqlParameter[][]数组,如出错一并回滚(重载2)
        /// <summary>
        /// 执行ExecuteTransac()事务处理,指定连接字符串,提供SQL语句(string数组),SqlParameter[][]数组,如出错一并回滚(重载2)
        /// </summary>
        /// <param name="cmdText">字符串类型的数组</param>
        /// <param name="cmdParams">SqlParameters[][]数组</param>
        /// <returns></returns>
        public static bool ExecuteTransac(string connectionString, string[] cmdText, SqlParameter[][] cmdParams)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction transaction = null;

            try
            {
                cnn.Open();

                transaction = cnn.BeginTransaction();
                cmd.Transaction = transaction;
                cmd.Connection = cnn;

                for (int i = 0; i < cmdText.Length; i++)
                {
                    if (cmdText[i] == null) continue;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = cmdText[i].ToString();
                    SqlParameter[] p = cmdParams[i];
                    if (p != null && p.Length > 0)
                    {
                        cmd.Parameters.AddRange(p);
                    }
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;//test
                //return false;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }
        #endregion

        #region 执行ExecuteTransac()事务处理,指定连接字符串,提供SQL语句(ArrayList数组),SqlParameter[][]数组,如出错一并回滚(重载3)
        /// <summary>
        /// 执行ExecuteTransac()事务处理,指定连接字符串,提供SQL语句(ArrayList数组),SqlParameter[][]数组,如出错一并回滚(重载3)
        /// </summary>
        /// <param name="cmdText">字符串类型的数组</param>
        /// <param name="cmdParams">SqlParameters[][]数组</param>
        /// <returns></returns>
        public static bool ExecuteTransac(string connectionString, ArrayList cmdText, SqlParameter[][] cmdParams)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction transaction = null;

            try
            {
                cnn.Open();

                transaction = cnn.BeginTransaction();
                cmd.Transaction = transaction;
                cmd.Connection = cnn;

                for (int i = 0; i < cmdText.Count; i++)
                {
                    if (cmdText[i] == null) continue;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = cmdText[i].ToString();
                    SqlParameter[] p = cmdParams[i];
                    if (p != null && p.Length > 0)
                    {
                        cmd.Parameters.AddRange(p);
                    }
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }
        #endregion

        #region 执行ExecuteTransac()事务处理,指定连接字符串,提供SQL语句,SqlParameter[]数组,如出错一并回滚(重载4)
        /// <summary>
        /// 执行ExecuteTransac()事务处理,指定连接字符串,提供SQL语句,SqlParameter[]数组,如出错一并回滚(重载4)
        /// </summary>
        /// <param name="cmdText">字符串</param>
        /// <param name="cmdParams">SqlParameters[]数组</param>
        /// <returns></returns>
        public static bool ExecuteTransac(string connectionString, string cmdText, SqlParameter[] cmdParams)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction transaction = null;

            try
            {
                cnn.Open();

                transaction = cnn.BeginTransaction();
                cmd.Transaction = transaction;
                cmd.Connection = cnn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdText;
                if (cmdParams != null && cmdParams.Length > 0)
                {
                    cmd.Parameters.AddRange(cmdParams);
                }
                cmd.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch
            {
                //transaction.Rollback();
                //return false;
                throw;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }
        #endregion

        #region 执行ExecuteTransac()事务处理,指定连接字符串,调用存储过程,如出错一并回滚(重载5)
        /// <summary>
        /// 执行ExecuteTransac()事务处理,指定连接字符串,调用存储过程,如出错一并回滚(重载5)
        /// </summary>
        /// <param name="spText">字符串</param>
        /// <param name="cmdParams">SqlParameters[]数组</param>
        /// <returns></returns>
        public static bool ExecuteTransac(string connectionString, SqlParameter[] cmdParams, string spText)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction transaction = null;

            try
            {
                cnn.Open();

                transaction = cnn.BeginTransaction();
                cmd.Transaction = transaction;
                cmd.Connection = cnn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spText;
                if (cmdParams != null && cmdParams.Length > 0)
                {
                    cmd.Parameters.AddRange(cmdParams);
                }
                cmd.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }
        #endregion



        #region 执行ExecuteReader()，指定连接字符串,提供SqlParameter[]数组
        /// <summary>
        /// 执行ExecuteReader()，指定连接字符串,提供SqlParameter[]数组
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="cmdParams">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个包含结果的SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            // 在这里使用try/catch处理是因为如果方法出现异常，则SqlDataReader就不存在，
            //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
            //关闭数据库连接，并通过throw再次引发捕捉到的异常。
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw;
            }
        }
        #endregion

        #region 执行ExecuteDataTable(),指定连接字符串,提供SqlParameter[]数组
        /// <summary>
        ///  执行ExecuteDataTable(),指定连接字符串,提供SqlParameter[]数组
        /// </summary>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="cmdParams">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数据表</returns>
        public static DataTable ExecuteDataTable(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();

            // 在这里使用try/catch处理是因为如果方法出现异常，则SqlDataReader就不存在，
            //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
            //关闭数据库连接，并通过throw再次引发捕捉到的异常。
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.Parameters.Clear();
                return dt;
            }
            catch
            {
                conn.Close();
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region 执行ExecuteDataSet(),指定连接字符串,提供SqlParameter[]数组
        /// <summary>
        ///  执行ExecuteDataSet(),指定连接字符串,提供SqlParameter[]数组
        /// </summary>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="cmdParams">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数据集</returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();

            // 在这里使用try/catch处理是因为如果方法出现异常，则SqlDataReader就不存在，
            //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
            //关闭数据库连接，并通过throw再次引发捕捉到的异常。
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
            catch
            {
                conn.Close();
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region 执行ExecuteScalar(),指定连接字符串,提供SqlParameter[]数组
        /// <summary>
        /// 执行ExecuteScalar(),指定连接字符串,提供SqlParameter[]数组
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="cmdParams">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParams);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();

                return val;
            }
        }
        #endregion

        #region 执行ExecuteScalar(),指定SqlConnection,提供SqlParameter[]数组
        /// <summary>
        /// 执行ExecuteScalar(),指定SqlConnection,提供SqlParameter[]数组
        /// </summary>
        /// <param name="conn">数据库连接</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="cmdParams">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParams);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion

        #region 哈希表用来存储缓存的参数信息,哈希表可以存储任意类型的参数.
        /// <summary>
        /// 哈希表用来存储缓存的参数信息,哈希表可以存储任意类型的参数.
        /// </summary>
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        #endregion

        #region 缓存参数数组
        /// <summary>
        /// 缓存参数数组
        /// </summary>
        /// <param name="cacheKey">参数缓存的键值</param>
        /// <param name="cmdParms">被缓存的参数列表</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }
        #endregion

        #region 获取被缓存的参数
        /// <summary>
        /// 获取被缓存的参数
        /// </summary>
        /// <param name="cacheKey">用于查找参数的KEY值</param>
        /// <returns>返回缓存的参数数组</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            //新建一个参数的克隆列表
            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            //通过循环为克隆参数列表赋值
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                //使用clone方法复制参数列表中的参数
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }
        #endregion

        #region 为执行SqlCommand准备SqlParameter(sql）
        /// <summary>
        /// 为执行SqlCommand准备SqlParameter(sql）
        /// </summary>
        /// <param name="cmd">SqlCommand 命令</param>
        /// <param name="conn">已经存在的数据库连接</param>
        /// <param name="trans">数据库事物处理</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
        /// <param name="cmdParams">返回带参数的命令</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParams)
        {

            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParams != null)
            {
                foreach (SqlParameter parm in cmdParams)
                {
                    if (null != parm)
                    {
                        cmd.Parameters.Add(parm);
                    }
                }

            }
        }
        #endregion

        #region 执行ExecuteDataPage()
        public static DataSet ExecuteDataPage(int currentPage, int pagesize, out int recordcount, string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();

            // 在这里使用try/catch处理是因为如果方法出现异常，则SqlDataReader就不存在，
            //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
            //关闭数据库连接，并通过throw再次引发捕捉到的异常。
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
                da.SelectCommand = cmd;

                DataSet ds = new DataSet();
                int startRow = (currentPage - 1) * pagesize;
                da.Fill(ds, startRow, pagesize, "table");
                cmd.Parameters.Clear();
                recordcount = GetPageRecord(connectionString, CommandType.Text, cmdText, cmdParams);
                return ds;
            }
            catch
            {
                conn.Close();
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// 取记录总数
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static int GetPageRecord(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
        {
            //cmdText = System.Text.RegularExpressions.Regex.Replace(cmdText.ToLower(), "order by.*", "");

            string a = "order by";
            Regex reg = new Regex(a);
            Match m = reg.Match(cmdText.ToLower());
            if (m.Success)
            {
                cmdText = cmdText.Substring(0, m.Index);
            }

            cmdText = "select count(*) from (" + cmdText + ") as temp";

            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, cmdParams);
                int count = (int)cmd.ExecuteScalar();
                cmd.Parameters.Clear();

                return count;
            }
        }

        #endregion
    }
}
