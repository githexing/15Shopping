using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_Stock
    /// </summary>
    public partial class tb_Stock
    {
        public tb_Stock()
		{ }
        #region Method

        public bool Exists(long StockID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Stock");
            strSql.Append(" where ");
            strSql.Append(" StockID = @StockID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockID", SqlDbType.BigInt,8)};
            parameters[0].Value = StockID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据给定的条件，判断是否存在记录
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Stock");
            if (strWhere.Trim() != "")
                strSql.Append(" where " + strWhere);

            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_Stock model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Stock(");
            strSql.Append("UserID,Amount,BuyPrice,Price,Number,Surplus,SplitNum,BuyDate,IsLockIsSell");
            strSql.Append(") values (");
            strSql.Append("@UserID,@Amount,@BuyPrice,@Price,@Number,@Surplus,@SplitNum,@BuyDate,@IsLock@IsSell");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@UserID", SqlDbType.Int,4),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@BuyPrice", SqlDbType.Decimal,9),
                        new SqlParameter("@Price", SqlDbType.Decimal,9),
                        new SqlParameter("@Number", SqlDbType.Int,4),
                        new SqlParameter("@Surplus", SqlDbType.Int,4),
                        new SqlParameter("@SplitNum", SqlDbType.Int,4),
                        new SqlParameter("@BuyDate", SqlDbType.DateTime),
                        new SqlParameter("@IsLock", SqlDbType.Int,4),
                        new SqlParameter("@IsSell", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Amount;
            parameters[2].Value = model.BuyPrice;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.Number;
            parameters[5].Value = model.Surplus;
            parameters[6].Value = model.SplitNum;
            parameters[7].Value = model.BuyDate;
            parameters[8].Value = model.IsLock;
            parameters[9].Value = model.IsSell;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(lgk.Model.tb_Stock model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Stock set ");
            strSql.Append(" UserID = @UserID,");
            strSql.Append(" Amount = @Amount,");
            strSql.Append(" BuyPrice = @BuyPrice,");
            strSql.Append(" Price = @Price,");
            strSql.Append(" Number = @Number,");
            strSql.Append(" Surplus = @Surplus,");
            strSql.Append(" SplitNum = @SplitNum,");
            strSql.Append(" BuyDate = @BuyDate,");
            strSql.Append(" IsLock = @IsLock,");
            strSql.Append(" IsSell = @IsSell");
            strSql.Append(" where StockID=@StockID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@StockID", SqlDbType.BigInt,8),
                        new SqlParameter("@UserID", SqlDbType.Int,4),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@BuyPrice", SqlDbType.Decimal,9),
                        new SqlParameter("@Price", SqlDbType.Decimal,9),
                        new SqlParameter("@Number", SqlDbType.Int,4),
                        new SqlParameter("@Surplus", SqlDbType.Int,4),
                        new SqlParameter("@SplitNum", SqlDbType.Int,4),
                        new SqlParameter("@BuyDate", SqlDbType.DateTime),
                        new SqlParameter("@IsLock", SqlDbType.Int,4),
                        new SqlParameter("@IsSell", SqlDbType.Int,4)};
            parameters[0].Value = model.StockID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.BuyPrice;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.Number;
            parameters[6].Value = model.SplitNum;
            parameters[7].Value = model.Surplus;
            parameters[8].Value = model.BuyDate;
            parameters[9].Value = model.IsLock;
            parameters[10].Value = model.IsSell;

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
        public bool Delete(long StockID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Stock ");
            strSql.Append(" where StockID=@StockID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockID", SqlDbType.BigInt,8)};
            parameters[0].Value = StockID;

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
            strSql.Append("delete from tb_Stock ");

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
        public bool DeleteList(string StockIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Stock ");
            strSql.Append(" where ID in (" + StockIDlist + ")  ");
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
        public lgk.Model.tb_Stock GetModel(long StockID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StockID, UserID, Amount, BuyPrice, Price, Number, Surplus, SplitNum, BuyDate, IsLock, IsSell");
            strSql.Append(" from tb_Stock");
            strSql.Append(" where StockID=@StockID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockID", SqlDbType.BigInt,8)};
            parameters[0].Value = StockID;

            lgk.Model.tb_Stock model = new lgk.Model.tb_Stock();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StockID"].ToString() != "")
                {
                    model.StockID = long.Parse(ds.Tables[0].Rows[0]["StockID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyPrice"].ToString() != "")
                {
                    model.BuyPrice = decimal.Parse(ds.Tables[0].Rows[0]["BuyPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Number"].ToString() != "")
                {
                    model.Number = int.Parse(ds.Tables[0].Rows[0]["Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Surplus"].ToString() != "")
                {
                    model.Surplus = int.Parse(ds.Tables[0].Rows[0]["Surplus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitNum"].ToString() != "")
                {
                    model.SplitNum = int.Parse(ds.Tables[0].Rows[0]["SplitNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyDate"].ToString() != "")
                {
                    model.BuyDate = DateTime.Parse(ds.Tables[0].Rows[0]["BuyDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSell"].ToString() != "")
                {
                    model.IsSell = int.Parse(ds.Tables[0].Rows[0]["IsSell"].ToString());
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
        public lgk.Model.tb_Stock GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 StockID, UserID, Amount, BuyPrice, Price, Number, Surplus, SplitNum, BuyDate, IsLock, IsSell");
            strSql.Append(" from tb_Stock ");
            if (strWhere.Trim() != "")
                strSql.Append(" where " + strWhere);

            lgk.Model.tb_Stock model = new lgk.Model.tb_Stock();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StockID"].ToString() != "")
                {
                    model.StockID = long.Parse(ds.Tables[0].Rows[0]["StockID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyPrice"].ToString() != "")
                {
                    model.BuyPrice = decimal.Parse(ds.Tables[0].Rows[0]["BuyPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Number"].ToString() != "")
                {
                    model.Number = int.Parse(ds.Tables[0].Rows[0]["Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Surplus"].ToString() != "")
                {
                    model.Surplus = int.Parse(ds.Tables[0].Rows[0]["Surplus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitNum"].ToString() != "")
                {
                    model.SplitNum = int.Parse(ds.Tables[0].Rows[0]["SplitNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyDate"].ToString() != "")
                {
                    model.BuyDate = DateTime.Parse(ds.Tables[0].Rows[0]["BuyDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSell"].ToString() != "")
                {
                    model.IsSell = int.Parse(ds.Tables[0].Rows[0]["IsSell"].ToString());
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
            strSql.Append("SELECT * FROM tb_Stock ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 每天最大的价格
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere, string strFiledOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT convert(varchar(19),BuyDate,120) AS cd, Max(Price) AS sp FROM tb_Stock ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + strFiledOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListJoin(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM tb_Stock ");
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
            strSql.Append("SELECT [tb_Stock].*,[tb_user].[UserCode]");
            strSql.Append(" FROM [tb_Stock] JOIN [tb_user] ON [tb_user].[UserID]=[tb_Stock].[UserID]");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }

            strSql.Append(" ORDER BY [tb_Stock].[BuyDate] DESC");
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
            strSql.Append(" FROM tb_Stock ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        /// <summary>
        /// 执行股票价格上涨存储过程，并计算利润。
        /// </summary>
        /// <param name="dExtentPrice">上涨后股价</param>
        /// <returns></returns>
        public bool Proc_StockRise(decimal dExtentPrice)
        {
            int result = 0;
            string prop = "Proc_StockRise";
            SqlParameter[] para = {
                        new SqlParameter("@ExtentPrice", SqlDbType.Decimal,9)
            };
            para[0].Value = dExtentPrice;

            DbHelperSQL.RunProcedure(prop, para, out result);

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据给定的股票ID，更新A盘可提现余额(0为提现，1为取消提现)
        /// </summary>
        /// <param name="iStockID">给定的股票ID</param>
        /// <param name="dMoney">提现数额</param>
        /// <param name="dCurrentPrice">当前股价</param>
        /// <param name="iType">0为提现，1为取消提现</param>
        /// <returns></returns>
        public bool UpdateStockNumber(long iStockID, decimal dMoney, decimal dCurrentPrice, int iType)
        {
            decimal dAmount = Convert.ToDecimal("0.00");
            decimal dProfit = Convert.ToDecimal("0.00");
            
            lgk.Model.tb_Stock stockInfo = GetModel(iStockID);

            if (stockInfo != null)
            {
                dAmount = stockInfo.Number * dCurrentPrice;//股票*当前股价=当前金额

                if (iType == 0)
                    dProfit = dAmount - dMoney;
                else
                    dProfit = dAmount + dMoney;

                stockInfo.Number = Convert.ToInt32(Math.Round(dProfit / dCurrentPrice, 0));

                return Update(stockInfo);
            }
            else
            {
                return false;
            }
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
            strSql.Append(" FROM tb_Stock");
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
