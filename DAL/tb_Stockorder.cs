using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_Stockorder
    /// </summary>
    public partial class tb_Stockorder
    {
        public tb_Stockorder()
		{ }
        #region Method

        public bool Exists(long OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Stockorder");
            strSql.Append(" where ");
            strSql.Append(" OrderID = @OrderID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.BigInt,8)};
            parameters[0].Value = OrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_Stockorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Stockorder(");
            strSql.Append("StockID,UserID,OrderCode,OrderDate,Remark,Status");
            strSql.Append(") values (");
            strSql.Append("@StockID,@UserID,@OrderCode,@OrderDate,@Remark,@Status");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@StockID", SqlDbType.BigInt,8),
                        new SqlParameter("@UserID", SqlDbType.BigInt,8),
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
                        new SqlParameter("@OrderDate", SqlDbType.DateTime),
                        new SqlParameter("@Remark", SqlDbType.VarChar,500),
                        new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.StockID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.OrderCode;
            parameters[3].Value = model.OrderDate;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.Status;

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
        public bool Update(lgk.Model.tb_Stockorder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Stockorder set ");
            strSql.Append(" StockID = @StockID,");
            strSql.Append(" UserID = @UserID,");
            strSql.Append(" OrderCode = @OrderCode,");
            strSql.Append(" OrderDate = @OrderDate,");
            strSql.Append(" Remark = @Remark,");
            strSql.Append(" Status = @Status");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@OrderID", SqlDbType.BigInt,8),
                        new SqlParameter("@StockID", SqlDbType.BigInt,8),
                        new SqlParameter("@UserID", SqlDbType.Int,4),
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
                        new SqlParameter("@OrderDate", SqlDbType.DateTime),
                        new SqlParameter("@Remark", SqlDbType.VarChar,500),
                        new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.StockID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.OrderCode;
            parameters[4].Value = model.OrderDate;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.Status;

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
        public bool Delete(long OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Stockorder ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.BigInt,8)};
            parameters[0].Value = OrderID;

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
        public bool DeleteList(string OrderIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Stockorder ");
            strSql.Append(" where ID in (" + OrderIDlist + ")  ");
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
        public lgk.Model.tb_Stockorder GetModel(long OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderID, StockID, UserID, OrderCode, OrderDate, Remark, Status");
            strSql.Append(" from tb_Stockorder");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.BigInt,8)};
            parameters[0].Value = OrderID;

            lgk.Model.tb_Stockorder model = new lgk.Model.tb_Stockorder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = long.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StockID"].ToString() != "")
                {
                    model.StockID = long.Parse(ds.Tables[0].Rows[0]["StockID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                if (ds.Tables[0].Rows[0]["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
            strSql.Append(" FROM tb_Stockorder");
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
            strSql.Append(" FROM tb_Stockorder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取未卖出的股票数量
        /// </summary>
        public long GetSurplusAmount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT OrderID FROM [tb_Stockorder] WHERE Status=0 OR Status=1");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());

            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj.ToString());
            }
        }

        #endregion
    }
}
