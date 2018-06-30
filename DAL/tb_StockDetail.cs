using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_StockDetail
    /// </summary>
    public partial class tb_StockDetail
    {
        public tb_StockDetail()
        { }
        #region Method

        public bool Exists(long StockDetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_StockDetail");
            strSql.Append(" where ");
            strSql.Append(" StockDetailID = @StockDetailID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockDetailID", SqlDbType.BigInt,8)};
            parameters[0].Value = StockDetailID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_StockDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_StockDetail(");
            strSql.Append("StockID,Amount,Price,Number,Periods,BuyDate");
            strSql.Append(") values (");
            strSql.Append("@StockID,@Amount,@Price,@Number,@Periods,@BuyDate");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@StockID", SqlDbType.BigInt,8),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@Price", SqlDbType.Decimal,9),
                        new SqlParameter("@Number", SqlDbType.Int,4),
                        new SqlParameter("@Periods", SqlDbType.Int,4),
                        new SqlParameter("@BuyDate", SqlDbType.DateTime)};
            parameters[0].Value = model.StockID;
            parameters[1].Value = model.Amount;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.Number;
            parameters[4].Value = model.Periods;
            parameters[5].Value = model.BuyDate;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_StockDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_StockDetail set");
            strSql.Append(" StockID = @StockID,");
            strSql.Append(" Amount = @Amount,");
            strSql.Append(" Price = @Price,");
            strSql.Append(" Number = @Number,");
            strSql.Append(" Periods = @Periods,");
            strSql.Append(" BuyDate = @BuyDate");
            strSql.Append(" where StockDetailID=@StockDetailID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@StockDetailID", SqlDbType.BigInt,8),
                        new SqlParameter("@StockID", SqlDbType.BigInt,8),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@Price", SqlDbType.Decimal,9),
                        new SqlParameter("@Number", SqlDbType.Int,4),
                        new SqlParameter("@Periods", SqlDbType.Int,4),
                        new SqlParameter("@BuyDate", SqlDbType.DateTime)};
            parameters[0].Value = model.StockDetailID;
            parameters[1].Value = model.StockID;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.Number;
            parameters[5].Value = model.Periods;
            parameters[6].Value = model.BuyDate;

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
        public bool Delete(long StockDetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_StockDetail ");
            strSql.Append(" where StockDetailID=@StockDetailID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockDetailID", SqlDbType.BigInt,8)};
            parameters[0].Value = StockDetailID;


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
        public bool DeleteList(string StockDetailIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_StockDetail ");
            strSql.Append(" where StockDetailID in (" + StockDetailIDlist + ")  ");
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
        public lgk.Model.tb_StockDetail GetModel(long StockDetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StockDetailID, StockID, Amount, Price, Number, Periods, BuyDate");
            strSql.Append(" from tb_StockDetail ");
            strSql.Append(" where StockDetailID=@StockDetailID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockDetailID", SqlDbType.BigInt,8)};
            parameters[0].Value = StockDetailID;

            lgk.Model.tb_StockDetail model = new lgk.Model.tb_StockDetail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StockDetailID"].ToString() != "")
                {
                    model.StockDetailID = long.Parse(ds.Tables[0].Rows[0]["StockDetailID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StockID"].ToString() != "")
                {
                    model.StockID = long.Parse(ds.Tables[0].Rows[0]["StockID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Number"].ToString() != "")
                {
                    model.Number = int.Parse(ds.Tables[0].Rows[0]["Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Periods"].ToString() != "")
                {
                    model.Periods = int.Parse(ds.Tables[0].Rows[0]["Periods"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyDate"].ToString() != "")
                {
                    model.BuyDate = DateTime.Parse(ds.Tables[0].Rows[0]["BuyDate"].ToString());
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
        public lgk.Model.tb_StockDetail GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StockDetailID, StockID, Amount, Price, Number, Periods, BuyDate");
            strSql.Append(" from tb_StockDetail");
            if (strWhere.Trim() != "")
                strSql.Append(" where " + strWhere);

            lgk.Model.tb_StockDetail model = new lgk.Model.tb_StockDetail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StockDetailID"].ToString() != "")
                {
                    model.StockDetailID = long.Parse(ds.Tables[0].Rows[0]["StockDetailID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StockID"].ToString() != "")
                {
                    model.StockID = long.Parse(ds.Tables[0].Rows[0]["StockID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Number"].ToString() != "")
                {
                    model.Number = int.Parse(ds.Tables[0].Rows[0]["Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Periods"].ToString() != "")
                {
                    model.Periods = int.Parse(ds.Tables[0].Rows[0]["Periods"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyDate"].ToString() != "")
                {
                    model.BuyDate = DateTime.Parse(ds.Tables[0].Rows[0]["BuyDate"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据主表编号，获取购买的股票金额。
        /// </summary>
        /// <param name="iStockID">主表编号</param>
        /// <returns></returns>
        public decimal GetCountAmount(int iStockID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ISNULL(SUM(Amount),0) AS Amount");
            strSql.Append(" FROM [tb_StockDetail]");
            strSql.Append(" WHERE ");
            strSql.Append(" StockID = @StockID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockID", SqlDbType.Int,4)
			};
            parameters[0].Value = iStockID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            if (obj != null)
                return Convert.ToDecimal(obj);
            else
                return Convert.ToDecimal(0.00);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM tb_StockDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
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
            strSql.Append(" FROM tb_StockDetail ");
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
