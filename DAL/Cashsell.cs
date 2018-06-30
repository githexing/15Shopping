using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:Cashbuy
    /// </summary>
    public partial class Cashsell
    {
        public Cashsell()
		{ }
        #region Method

        public bool Exists(long CashsellID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cashsell where CashsellID = @CashsellID");
            SqlParameter[] parameters = {
					new SqlParameter("@CashsellID", SqlDbType.BigInt,8)};
            parameters[0].Value = CashsellID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.Cashsell model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cashsell(");
            strSql.Append("Title,UserID,Amount,Price,Number,UnitNum,SaleNum,Charge,SellDate,Remark,IsSell,IsUndo,PurchaseID,Phone)");
            strSql.Append(" values (");
            strSql.Append("@Title,@UserID,@Amount,@Price,@Number,@UnitNum,@SaleNum,@Charge,@SellDate,@Remark,@IsSell,@IsUndo,@PurchaseID,@Phone)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@Title", SqlDbType.VarChar,60),
                        new SqlParameter("@UserID", SqlDbType.BigInt,8),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@Price", SqlDbType.Decimal,9),
                        new SqlParameter("@Number", SqlDbType.Int,4),
                        new SqlParameter("@UnitNum", SqlDbType.Decimal,4),
                        new SqlParameter("@SaleNum", SqlDbType.Decimal,4),
                        new SqlParameter("@Charge", SqlDbType.Decimal,9),
                        new SqlParameter("@SellDate", SqlDbType.DateTime),
                        new SqlParameter("@Remark", SqlDbType.VarChar,500),
                        new SqlParameter("@IsSell", SqlDbType.Int,4),
                        new SqlParameter("@IsUndo", SqlDbType.Int,4),
                        new SqlParameter("@PurchaseID", SqlDbType.BigInt,8),
            new SqlParameter("@Phone", SqlDbType.VarChar,20)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.Number;
            parameters[5].Value = model.UnitNum;
            parameters[6].Value = model.SaleNum;
            parameters[7].Value = model.Charge;
            parameters[8].Value = model.SellDate;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.IsSell;
            parameters[11].Value = model.IsUndo;
            parameters[12].Value = model.PurchaseID;
            parameters[13].Value = model.Phone;

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
        public bool Update(lgk.Model.Cashsell model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cashsell set ");
            strSql.Append(" Title = @Title,");
            strSql.Append(" UserID = @UserID,");
            strSql.Append(" Amount = @Amount,");
            strSql.Append(" Price = @Price,");
            strSql.Append(" Number = @Number,");
            strSql.Append(" UnitNum = @UnitNum,");
            strSql.Append(" SaleNum = @SaleNum,");
            strSql.Append(" Charge = @Charge,");
            strSql.Append(" SellDate = @SellDate,");
            strSql.Append(" Remark = @Remark,");
            strSql.Append(" IsSell = @IsSell,");
            strSql.Append(" IsUndo = @IsUndo,");
            strSql.Append(" PurchaseID = @PurchaseID");
            strSql.Append(" where CashsellID=@CashsellID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@CashsellID", SqlDbType.BigInt,8),
                        new SqlParameter("@Title", SqlDbType.VarChar,60),
                        new SqlParameter("@UserID", SqlDbType.BigInt,8),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@Price", SqlDbType.Decimal,9),
                        new SqlParameter("@Number", SqlDbType.Int,4),
                        new SqlParameter("@UnitNum", SqlDbType.Decimal,4),
                        new SqlParameter("@SaleNum", SqlDbType.Decimal,4),
                        new SqlParameter("@Charge", SqlDbType.Decimal,9),
                        new SqlParameter("@SellDate", SqlDbType.DateTime),
                        new SqlParameter("@Remark", SqlDbType.VarChar,500),
                        new SqlParameter("@IsSell", SqlDbType.Int,4),
                        new SqlParameter("@IsUndo", SqlDbType.Int,4),
                        new SqlParameter("@PurchaseID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.CashsellID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.Amount;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.Number;
            parameters[6].Value = model.UnitNum;
            parameters[7].Value = model.SaleNum;
            parameters[8].Value = model.Charge;
            parameters[9].Value = model.SellDate;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.IsSell;
            parameters[12].Value = model.IsUndo;
            parameters[13].Value = model.PurchaseID;

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
        /// 更新一条数据
        /// </summary>
        public bool UpdateUndo(long iCashsellID, int iIsUndo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cashsell set ");
            strSql.Append(" IsUndo = @IsUndo");
            strSql.Append(" where CashsellID=@CashsellID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@CashsellID", SqlDbType.BigInt,8),
                        new SqlParameter("@IsUndo", SqlDbType.Int,4)};
            parameters[0].Value = iCashsellID;
            parameters[1].Value = iIsUndo;

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
        public bool Delete(long CashsellID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashsell");
            strSql.Append(" where CashsellID=@CashsellID");
            SqlParameter[] parameters = {
					new SqlParameter("@CashsellID", SqlDbType.BigInt,8)};
            parameters[0].Value = CashsellID;

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
        public bool DeleteList(string CashsellIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cashsell");
            strSql.Append(" where ID in (" + CashsellIDlist + ")  ");
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
        public lgk.Model.Cashsell GetModel(long CashsellID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Cashsell");
            strSql.Append(" where CashsellID=@CashsellID");
            SqlParameter[] parameters = {
					new SqlParameter("@CashsellID", SqlDbType.BigInt,8)};
            parameters[0].Value = CashsellID;

            lgk.Model.Cashsell model = new lgk.Model.Cashsell();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CashsellID"].ToString() != "")
                {
                    model.CashsellID = long.Parse(ds.Tables[0].Rows[0]["CashsellID"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
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
                if (ds.Tables[0].Rows[0]["UnitNum"].ToString() != "")
                {
                    model.UnitNum = decimal.Parse(ds.Tables[0].Rows[0]["UnitNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SaleNum"].ToString() != "")
                {
                    model.SaleNum = decimal.Parse(ds.Tables[0].Rows[0]["SaleNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Charge"].ToString() != "")
                {
                    model.Charge = decimal.Parse(ds.Tables[0].Rows[0]["Charge"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SellDate"].ToString() != "")
                {
                    model.SellDate = DateTime.Parse(ds.Tables[0].Rows[0]["SellDate"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["IsSell"].ToString() != "")
                {
                    model.IsSell = int.Parse(ds.Tables[0].Rows[0]["IsSell"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsUndo"].ToString() != "")
                {
                    model.IsUndo = int.Parse(ds.Tables[0].Rows[0]["IsUndo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PurchaseID"].ToString() != "")
                {
                    model.PurchaseID = long.Parse(ds.Tables[0].Rows[0]["PurchaseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
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
        public lgk.Model.Cashsell GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 CashsellID, Title, UserID, Amount, Price, Number, UnitNum, SaleNum, Charge, SellDate, Remark, IsSell, IsUndo, PurchaseID,Phone");
            strSql.Append(" from Cashsell");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            lgk.Model.Cashsell model = new lgk.Model.Cashsell();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CashsellID"].ToString() != "")
                {
                    model.CashsellID = long.Parse(ds.Tables[0].Rows[0]["CashsellID"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
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
                if (ds.Tables[0].Rows[0]["UnitNum"].ToString() != "")
                {
                    model.UnitNum = decimal.Parse(ds.Tables[0].Rows[0]["UnitNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SaleNum"].ToString() != "")
                {
                    model.SaleNum = decimal.Parse(ds.Tables[0].Rows[0]["SaleNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Charge"].ToString() != "")
                {
                    model.Charge = decimal.Parse(ds.Tables[0].Rows[0]["Charge"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SellDate"].ToString() != "")
                {
                    model.SellDate = DateTime.Parse(ds.Tables[0].Rows[0]["SellDate"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["IsSell"].ToString() != "")
                {
                    model.IsSell = int.Parse(ds.Tables[0].Rows[0]["IsSell"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsUndo"].ToString() != "")
                {
                    model.IsUndo = int.Parse(ds.Tables[0].Rows[0]["IsUndo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PurchaseID"].ToString() != "")
                {
                    model.PurchaseID = long.Parse(ds.Tables[0].Rows[0]["PurchaseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 今日已挂卖数量
        /// </summary>
        public decimal GetAlready(long iUserID)
        {
            decimal dEMoney = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ISNULL(SUM([Number]),0) FROM Cashsell");
            strSql.Append(" WHERE UserID=@UserID");
            strSql.Append(" AND IsUndo=@IsUndo");
            strSql.Append(" AND DATEDIFF (DAY , SellDate, GETDATE()) = 0");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@IsUndo", SqlDbType.Int,4)};
            parameters[0].Value = iUserID;
            parameters[1].Value = 0;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            if (obj != null)
            {
                dEMoney = decimal.Parse(obj.ToString());
            }

            return dEMoney;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Cashsell");
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
            strSql.Append("SELECT [Cashsell].*,Number - SaleNum as Balance,[tb_user].[UserCode]");
            strSql.Append(" FROM [Cashsell] JOIN [tb_user] ON [tb_user].[UserID]=[Cashsell].[UserID]");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }

            strSql.Append(" ORDER BY [Cashsell].[Price] ASC");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Cashsell ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion
    }
}
