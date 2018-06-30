using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:Cashcredit
    /// </summary>
    public partial class Cashcredit
    {
        public Cashcredit()
		{ }
        #region Method

        /// <summary>
        /// 根据给定的编号，判断是否已存在记录。
        /// </summary>
        /// <param name="CreditID">给定的编号</param>
        /// <returns></returns>
        public bool Exists(long CreditID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [Cashcredit]");
            strSql.Append(" WHERE");;
            strSql.Append(" CreditID = @CreditID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@CreditID", SqlDbType.BigInt,8)};
            parameters[0].Value = CreditID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据给定的条件，判断是否存在记录。
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [Cashcredit]");
            if (strWhere.Trim() != "")
                strSql.Append(" WHERE " + strWhere);

            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 根据会员ID获取给定的会员评分。
        /// </summary>
        /// <param name="iUserID">会员ID</param>
        /// <param name="strFiledName">会员评分字段</param>
        /// <returns></returns>
        public int GetValues(long iUserID, string strFiledName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [" + strFiledName + "] FROM Cashcredit");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.Cashcredit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cashcredit(");
            strSql.Append("SValues,UserID,BNumber,BTradeNum,BEndNum,BValues,SNumber,STradeNum,SEndNum");
            strSql.Append(") values (");
            strSql.Append("@SValues,@UserID,@BNumber,@BTradeNum,@BEndNum,@BValues,@SNumber,@STradeNum,@SEndNum");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@UserID", SqlDbType.BigInt,8),
                        new SqlParameter("@BNumber", SqlDbType.Int,4),
                        new SqlParameter("@BTradeNum", SqlDbType.Int,4),
                        new SqlParameter("@BEndNum", SqlDbType.Int,4),
                        new SqlParameter("@BValues", SqlDbType.Int,4),
                        new SqlParameter("@SNumber", SqlDbType.Int,4),
                        new SqlParameter("@STradeNum", SqlDbType.Int,4),
                        new SqlParameter("@SEndNum", SqlDbType.Int,4),
                        new SqlParameter("@SValues", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.BNumber;
            parameters[2].Value = model.BTradeNum;
            parameters[3].Value = model.BEndNum;
            parameters[4].Value = model.BValues;
            parameters[5].Value = model.SNumber;
            parameters[6].Value = model.STradeNum;
            parameters[7].Value = model.SEndNum;
            parameters[8].Value = model.SValues;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.Cashcredit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cashcredit set ");
            strSql.Append(" UserID = @UserID,");
            strSql.Append(" BNumber = @BNumber,");
            strSql.Append(" BTradeNum = @BTradeNum,");
            strSql.Append(" BEndNum = @BEndNum,");
            strSql.Append(" BValues = @BValues,");
            strSql.Append(" SNumber = @SNumber,");
            strSql.Append(" STradeNum = @STradeNum,");
            strSql.Append(" SEndNum = @SEndNum,");
            strSql.Append(" SValues = @SValues");
            strSql.Append(" where CreditID=@CreditID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@CreditID", SqlDbType.BigInt,8),
                        new SqlParameter("@UserID", SqlDbType.BigInt,8),
                        new SqlParameter("@BNumber", SqlDbType.Int,4),
                        new SqlParameter("@BTradeNum", SqlDbType.Int,4),
                        new SqlParameter("@BEndNum", SqlDbType.Int,4),
                        new SqlParameter("@BValues", SqlDbType.Int,4),
                        new SqlParameter("@SNumber", SqlDbType.Int,4),
                        new SqlParameter("@STradeNum", SqlDbType.Int,4),
                        new SqlParameter("@SEndNum", SqlDbType.Int,4),
                        new SqlParameter("@SValues", SqlDbType.Int,4)};
            parameters[0].Value = model.CreditID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.BNumber;
            parameters[3].Value = model.BTradeNum;
            parameters[4].Value = model.BEndNum;
            parameters[5].Value = model.BValues;
            parameters[6].Value = model.SNumber;
            parameters[7].Value = model.STradeNum;
            parameters[8].Value = model.SEndNum;
            parameters[9].Value = model.SValues;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long CreditID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashcredit ");
            strSql.Append(" where CreditID=@CreditID");
            SqlParameter[] parameters = {
					new SqlParameter("@CreditID", SqlDbType.BigInt,8)};
            parameters[0].Value = CreditID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string CreditIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashcredit ");
            strSql.Append(" where ID in (" + CreditIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashcredit GetModel(long CreditID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CreditID, UserID, BNumber, BTradeNum, BEndNum, BValues, SNumber, STradeNum, SEndNum, SValues");
            strSql.Append(" from Cashcredit ");
            strSql.Append(" where CreditID=@CreditID");
            SqlParameter[] parameters = {
					new SqlParameter("@CreditID", SqlDbType.BigInt,8)};
            parameters[0].Value = CreditID;

            lgk.Model.Cashcredit model = new lgk.Model.Cashcredit();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CreditID"].ToString() != "")
                {
                    model.CreditID = long.Parse(ds.Tables[0].Rows[0]["CreditID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BNumber"].ToString() != "")
                {
                    model.BNumber = int.Parse(ds.Tables[0].Rows[0]["BNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BTradeNum"].ToString() != "")
                {
                    model.BTradeNum = int.Parse(ds.Tables[0].Rows[0]["BTradeNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BEndNum"].ToString() != "")
                {
                    model.BEndNum = int.Parse(ds.Tables[0].Rows[0]["BEndNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BValues"].ToString() != "")
                {
                    model.BValues = int.Parse(ds.Tables[0].Rows[0]["BValues"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SNumber"].ToString() != "")
                {
                    model.SNumber = int.Parse(ds.Tables[0].Rows[0]["SNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STradeNum"].ToString() != "")
                {
                    model.STradeNum = int.Parse(ds.Tables[0].Rows[0]["STradeNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEndNum"].ToString() != "")
                {
                    model.SEndNum = int.Parse(ds.Tables[0].Rows[0]["SEndNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SValues"].ToString() != "")
                {
                    model.SValues = int.Parse(ds.Tables[0].Rows[0]["SValues"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashcredit GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 CreditID, UserID, BNumber, BTradeNum, BEndNum, BValues, SNumber, STradeNum, SEndNum, SValues");
            strSql.Append(" from Cashcredit ");
            if (strWhere.Trim() != "")
                strSql.Append(" where " + strWhere);

            lgk.Model.Cashcredit model = new lgk.Model.Cashcredit();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CreditID"].ToString() != "")
                {
                    model.CreditID = long.Parse(ds.Tables[0].Rows[0]["CreditID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BNumber"].ToString() != "")
                {
                    model.BNumber = int.Parse(ds.Tables[0].Rows[0]["BNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BTradeNum"].ToString() != "")
                {
                    model.BTradeNum = int.Parse(ds.Tables[0].Rows[0]["BTradeNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BEndNum"].ToString() != "")
                {
                    model.BEndNum = int.Parse(ds.Tables[0].Rows[0]["BEndNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BValues"].ToString() != "")
                {
                    model.BValues = int.Parse(ds.Tables[0].Rows[0]["BValues"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SNumber"].ToString() != "")
                {
                    model.SNumber = int.Parse(ds.Tables[0].Rows[0]["SNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STradeNum"].ToString() != "")
                {
                    model.STradeNum = int.Parse(ds.Tables[0].Rows[0]["STradeNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEndNum"].ToString() != "")
                {
                    model.SEndNum = int.Parse(ds.Tables[0].Rows[0]["SEndNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SValues"].ToString() != "")
                {
                    model.SValues = int.Parse(ds.Tables[0].Rows[0]["SValues"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Cashcredit ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Cashcredit ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion
    }
}
