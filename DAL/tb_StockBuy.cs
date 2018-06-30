using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_StockBuy
    /// </summary>
    public partial class tb_StockBuy
    {
        public tb_StockBuy()
        { }
        #region Method

        public bool Exists(long StockBuyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM tb_StockBuy");
            strSql.Append(" WHERE");
            strSql.Append(" StockBuyID = @StockBuyID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockBuyID", SqlDbType.BigInt,8)};
            parameters[0].Value = StockBuyID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public long GetMaxID()
        {
            long iStockBuyID = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(StockBuyID)+1 FROM tb_StockBuy");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());

            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                iStockBuyID = 1;
            else
                iStockBuyID = long.Parse(obj.ToString());

            if (iStockBuyID <= 0)
                GetMaxID();

            return iStockBuyID;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_StockBuy model)
        {
            StringBuilder strSql = new StringBuilder();
            model.StockBuyID = GetMaxID();
            strSql.Append("insert into tb_StockBuy(");
            strSql.Append("StockBuyID,UserID,Amount,SurplusSum,BuyDate,IsBuy,Status)");
            strSql.Append(" values (@StockBuyID,@UserID,@Amount,@SurplusSum,@BuyDate,@IsBuy,@Status) ");
            SqlParameter[] parameters = {
			            new SqlParameter("@StockBuyID", SqlDbType.BigInt,8),
                        new SqlParameter("@UserID", SqlDbType.Int,4),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@SurplusSum", SqlDbType.Decimal,9),
                        new SqlParameter("@BuyDate", SqlDbType.DateTime),
                        new SqlParameter("@IsBuy", SqlDbType.Int,4),
                        new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.StockBuyID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.SurplusSum;
            parameters[4].Value = model.BuyDate;
            parameters[5].Value = model.IsBuy;
            parameters[6].Value = model.Status;

            object obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return long.Parse(obj.ToString());
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_StockBuy model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_StockBuy set");
            strSql.Append(" StockBuyID = @StockBuyID,");
            strSql.Append(" UserID = @UserID,");
            strSql.Append(" Amount = @Amount,");
            strSql.Append(" SurplusSum = @SurplusSum,");
            strSql.Append(" BuyDate = @BuyDate,");
            strSql.Append(" IsBuy = @IsBuy,");
            strSql.Append(" Status = @Status");
            strSql.Append(" where StockBuyID=@StockBuyID");
            SqlParameter[] parameters = {
			            new SqlParameter("@StockBuyID", SqlDbType.BigInt,8),
                        new SqlParameter("@UserID", SqlDbType.Int,4),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@SurplusSum", SqlDbType.Decimal,9),
                        new SqlParameter("@BuyDate", SqlDbType.DateTime),
                        new SqlParameter("@IsBuy", SqlDbType.Int,4),
                        new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.StockBuyID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.SurplusSum;
            parameters[4].Value = model.BuyDate;
            parameters[5].Value = model.IsBuy;
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
        public bool Delete(long StockBuyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_StockBuy ");
            strSql.Append(" where StockBuyID=@StockBuyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockBuyID", SqlDbType.BigInt,8)			};
            parameters[0].Value = StockBuyID;

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
        public bool Delete(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM tb_StockBuy ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }

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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string StockBuyIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_StockBuy ");
            strSql.Append(" where StockBuyID in (" + StockBuyIDlist + ")  ");
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
        public lgk.Model.tb_StockBuy GetModel(long StockBuyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 StockBuyID, UserID, Amount, SurplusSum, BuyDate, IsBuy, Status");
            strSql.Append(" from tb_StockBuy ");
            strSql.Append(" where StockBuyID=@StockBuyID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockBuyID", SqlDbType.BigInt,8)			};
            parameters[0].Value = StockBuyID;

            lgk.Model.tb_StockBuy model = new lgk.Model.tb_StockBuy();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StockBuyID"].ToString() != "")
                {
                    model.StockBuyID = long.Parse(ds.Tables[0].Rows[0]["StockBuyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SurplusSum"].ToString() != "")
                {
                    model.SurplusSum = decimal.Parse(ds.Tables[0].Rows[0]["SurplusSum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyDate"].ToString() != "")
                {
                    model.BuyDate = DateTime.Parse(ds.Tables[0].Rows[0]["BuyDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsBuy"].ToString() != "")
                {
                    model.IsBuy = int.Parse(ds.Tables[0].Rows[0]["IsBuy"].ToString());
                }
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
            strSql.Append("SELECT * ");
            strSql.Append(" FROM tb_StockBuy ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetInnerList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [tb_StockBuy].*,[tb_user].[UserCode],[tb_user].[TrueName]");
            strSql.Append(" FROM [tb_StockBuy] JOIN [tb_user] ON [tb_user].[UserID]=[tb_StockBuy].[UserID]");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }

            strSql.Append(" ORDER BY [tb_StockBuy].[BuyDate] DESC");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM tb_StockBuy ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据给定的条件，获取总的购买金额。
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public decimal GetAmountCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SUM(Amount) AS Amount");
            strSql.Append(" FROM tb_StockBuy");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }

            object obj = DbHelperSQL.GetSingle(strSql.ToString());

            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return Convert.ToDecimal(0.00);
            }
            else
            {
                return Convert.ToDecimal(obj.ToString());
            }
        }

        #endregion
    }
}
