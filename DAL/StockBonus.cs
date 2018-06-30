using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:StockBonus
    /// </summary>
    public partial class StockBonus
    {
        public StockBonus()
		{ }
        #region Method

        public bool Exists(int BonusID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StockBonus");
            strSql.Append(" where ");
            strSql.Append(" BonusID = @BonusID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@BonusID", SqlDbType.Int,4)
			};
            parameters[0].Value = BonusID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.StockBonus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StockBonus(");
            strSql.Append("StockID,UserID,TypeID,Amount,Bonus,BuyPrice,CurrentPrice,AddDate,IsSettled,Remark,Bonus001,Bonus002,Bonus003");
            strSql.Append(") values (");
            strSql.Append("@StockID,@UserID,@TypeID,@Amount,@Bonus,@BuyPrice,@CurrentPrice,@AddDate,@IsSettled,@Remark,@Bonus001,@Bonus002,@Bonus003");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@StockID", SqlDbType.Int,4),
                        new SqlParameter("@UserID", SqlDbType.Int,4),
                        new SqlParameter("@TypeID", SqlDbType.Int,4),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@Bonus", SqlDbType.Decimal,9),
                        new SqlParameter("@BuyPrice", SqlDbType.Decimal,9),
                        new SqlParameter("@CurrentPrice", SqlDbType.Decimal,9),
                        new SqlParameter("@AddDate", SqlDbType.DateTime),
                        new SqlParameter("@IsSettled", SqlDbType.Int,4),
                        new SqlParameter("@Remark", SqlDbType.VarChar,500),
                        new SqlParameter("@Bonus001", SqlDbType.Int,4),
                        new SqlParameter("@Bonus002", SqlDbType.Decimal,9),
                        new SqlParameter("@Bonus003", SqlDbType.VarChar,500)
            };
            parameters[5].Value = model.StockID;
            parameters[6].Value = model.UserID;
            parameters[7].Value = model.TypeID;
            parameters[8].Value = model.Amount;
            parameters[9].Value = model.Bonus;
            parameters[10].Value = model.BuyPrice;
            parameters[11].Value = model.CurrentPrice;
            parameters[12].Value = model.AddDate;
            parameters[0].Value = model.IsSettled;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.Bonus001;
            parameters[3].Value = model.Bonus002;
            parameters[4].Value = model.Bonus003;

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
        public bool Update(lgk.Model.StockBonus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StockBonus set ");
            strSql.Append(" StockID = @StockID,");
            strSql.Append(" UserID = @UserID,");
            strSql.Append(" TypeID = @TypeID,");
            strSql.Append(" Amount = @Amount,");
            strSql.Append(" Bonus = @Bonus,");
            strSql.Append(" BuyPrice = @BuyPrice,");
            strSql.Append(" CurrentPrice = @CurrentPrice,");
            strSql.Append(" AddDate = @AddDate,");
            strSql.Append(" IsSettled = @IsSettled,");
            strSql.Append(" Remark = @Remark,");
            strSql.Append(" Bonus001 = @Bonus001,");
            strSql.Append(" Bonus002 = @Bonus002,");
            strSql.Append(" Bonus003 = @Bonus003,");
            strSql.Append(" where BonusID=@BonusID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@BonusID", SqlDbType.Int,4),
                        new SqlParameter("@StockID", SqlDbType.Int,4),
                        new SqlParameter("@UserID", SqlDbType.Int,4),
                        new SqlParameter("@TypeID", SqlDbType.Int,4),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@Bonus", SqlDbType.Decimal,9),
                        new SqlParameter("@BuyPrice", SqlDbType.Decimal,9),
                        new SqlParameter("@CurrentPrice", SqlDbType.Decimal,9),
                        new SqlParameter("@AddDate", SqlDbType.DateTime),
                        new SqlParameter("@IsSettled", SqlDbType.Int,4),
                        new SqlParameter("@Remark", SqlDbType.VarChar,500),
                        new SqlParameter("@Bonus001", SqlDbType.Int,4),
                        new SqlParameter("@Bonus002", SqlDbType.Decimal,9),
                        new SqlParameter("@Bonus003", SqlDbType.VarChar,500)};
            parameters[0].Value = model.BonusID;
            parameters[6].Value = model.StockID;
            parameters[7].Value = model.UserID;
            parameters[8].Value = model.TypeID;
            parameters[9].Value = model.Amount;
            parameters[10].Value = model.Bonus;
            parameters[11].Value = model.BuyPrice;
            parameters[12].Value = model.CurrentPrice;
            parameters[13].Value = model.AddDate;
            parameters[1].Value = model.IsSettled;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.Bonus001;
            parameters[4].Value = model.Bonus002;
            parameters[5].Value = model.Bonus003;

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
        public bool Delete(int BonusID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockBonus ");
            strSql.Append(" where BonusID=@BonusID");
            SqlParameter[] parameters = {
					new SqlParameter("@BonusID", SqlDbType.Int,4)
			};
            parameters[0].Value = BonusID;

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
        public bool DeleteList(string BonusIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockBonus ");
            strSql.Append(" where BonusID in (" + BonusIDlist + ")  ");
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
        public lgk.Model.StockBonus GetModel(int BonusID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BonusID, StockID, UserID, TypeID, Amount, Bonus, BuyPrice, CurrentPrice, AddDate, IsSettled, Remark, Bonus001, Bonus002, Bonus003");
            strSql.Append(" from StockBonus ");
            strSql.Append(" where BonusID=@BonusID");
            SqlParameter[] parameters = {
					new SqlParameter("@BonusID", SqlDbType.Int,4)
			};
            parameters[0].Value = BonusID;

            lgk.Model.StockBonus model = new lgk.Model.StockBonus();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BonusID"].ToString() != "")
                {
                    model.BonusID = int.Parse(ds.Tables[0].Rows[0]["BonusID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StockID"].ToString() != "")
                {
                    model.StockID = int.Parse(ds.Tables[0].Rows[0]["StockID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Bonus"].ToString() != "")
                {
                    model.Bonus = decimal.Parse(ds.Tables[0].Rows[0]["Bonus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyPrice"].ToString() != "")
                {
                    model.BuyPrice = decimal.Parse(ds.Tables[0].Rows[0]["BuyPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CurrentPrice"].ToString() != "")
                {
                    model.CurrentPrice = decimal.Parse(ds.Tables[0].Rows[0]["CurrentPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSettled"].ToString() != "")
                {
                    model.IsSettled = int.Parse(ds.Tables[0].Rows[0]["IsSettled"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["Bonus001"].ToString() != "")
                {
                    model.Bonus001 = int.Parse(ds.Tables[0].Rows[0]["Bonus001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Bonus002"].ToString() != "")
                {
                    model.Bonus002 = decimal.Parse(ds.Tables[0].Rows[0]["Bonus002"].ToString());
                }
                model.Bonus003 = ds.Tables[0].Rows[0]["Bonus003"].ToString();

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
        public lgk.Model.StockBonus GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 BonusID, StockID, UserID, TypeID, Amount, Bonus, BuyPrice, CurrentPrice, AddDate, IsSettled, Remark, Bonus001, Bonus002, Bonus003");
            strSql.Append(" from StockBonus ");
            if (strWhere.Trim() != "")
                strSql.Append(" where " + strWhere + "");

            lgk.Model.StockBonus model = new lgk.Model.StockBonus();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BonusID"].ToString() != "")
                {
                    model.BonusID = int.Parse(ds.Tables[0].Rows[0]["BonusID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StockID"].ToString() != "")
                {
                    model.StockID = int.Parse(ds.Tables[0].Rows[0]["StockID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Bonus"].ToString() != "")
                {
                    model.Bonus = decimal.Parse(ds.Tables[0].Rows[0]["Bonus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyPrice"].ToString() != "")
                {
                    model.BuyPrice = decimal.Parse(ds.Tables[0].Rows[0]["BuyPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CurrentPrice"].ToString() != "")
                {
                    model.CurrentPrice = decimal.Parse(ds.Tables[0].Rows[0]["CurrentPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSettled"].ToString() != "")
                {
                    model.IsSettled = int.Parse(ds.Tables[0].Rows[0]["IsSettled"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["Bonus001"].ToString() != "")
                {
                    model.Bonus001 = int.Parse(ds.Tables[0].Rows[0]["Bonus001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Bonus002"].ToString() != "")
                {
                    model.Bonus002 = decimal.Parse(ds.Tables[0].Rows[0]["Bonus002"].ToString());
                }
                model.Bonus003 = ds.Tables[0].Rows[0]["Bonus003"].ToString();

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
            strSql.Append(" FROM StockBonus ");
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
            strSql.Append(" FROM StockBonus ");
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
