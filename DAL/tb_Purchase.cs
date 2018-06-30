using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_Purchase
    /// </summary>
    public partial class tb_Purchase
    {
        public tb_Purchase()
		{ }
        #region Method

        public bool Exists(long PurchaseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Purchase where PurchaseID = @PurchaseID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@PurchaseID", SqlDbType.BigInt,8)};
            parameters[0].Value = PurchaseID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_Purchase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Purchase(");
            strSql.Append("Title,UserID,Amount,Price,Number,Quantity,UnitNum,SaleNum,Charge,PurchaseDate,Remark,IsPur,IsUndo) ");
            strSql.Append("values (");
            strSql.Append("@Title,@UserID,@Amount,@Price,@Number,@Quantity,@UnitNum,@SaleNum,@Charge,@PurchaseDate,@Remark,@IsPur,@IsUndo) ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@Title", SqlDbType.VarChar,60),
                        new SqlParameter("@UserID", SqlDbType.BigInt,8),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@Price", SqlDbType.Decimal,9),
                        new SqlParameter("@Number", SqlDbType.Int,4),
                        new SqlParameter("@Quantity", SqlDbType.Int,4),
                        new SqlParameter("@UnitNum", SqlDbType.Int,4),
                        new SqlParameter("@SaleNum", SqlDbType.Int,4),
                        new SqlParameter("@Charge", SqlDbType.Decimal,9),
                        new SqlParameter("@PurchaseDate", SqlDbType.DateTime),
                        new SqlParameter("@Remark", SqlDbType.VarChar,500),
                        new SqlParameter("@IsPur", SqlDbType.Int,4),
                        new SqlParameter("@IsUndo", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.Number;
            parameters[5].Value = model.Quantity;
            parameters[6].Value = model.UnitNum;
            parameters[7].Value = model.SaleNum;
            parameters[8].Value = model.Charge;
            parameters[9].Value = model.PurchaseDate;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.IsPur;
            parameters[12].Value = model.IsUndo;

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
        public bool Update(lgk.Model.tb_Purchase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Purchase set ");
            strSql.Append(" Title = @Title,");
            strSql.Append(" UserID = @UserID,");
            strSql.Append(" Amount = @Amount,");
            strSql.Append(" Price = @Price,");
            strSql.Append(" Number = @Number,");
            strSql.Append(" Quantity = @Quantity,");
            strSql.Append(" UnitNum = @UnitNum,");
            strSql.Append(" SaleNum = @SaleNum,");
            strSql.Append(" Charge = @Charge,");
            strSql.Append(" PurchaseDate = @PurchaseDate,");
            strSql.Append(" Remark = @Remark,");
            strSql.Append(" IsPur = @IsPur,");
            strSql.Append(" IsUndo = @IsUndo");
            strSql.Append(" where PurchaseID=@PurchaseID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@PurchaseID", SqlDbType.BigInt,8),
                        new SqlParameter("@Title", SqlDbType.VarChar,60),
                        new SqlParameter("@UserID", SqlDbType.BigInt,8),
                        new SqlParameter("@Amount", SqlDbType.Decimal,9),
                        new SqlParameter("@Price", SqlDbType.Decimal,9),
                        new SqlParameter("@Number", SqlDbType.Int,4),
                        new SqlParameter("@Quantity", SqlDbType.Int,4),
                        new SqlParameter("@UnitNum", SqlDbType.Int,4),
                        new SqlParameter("@SaleNum", SqlDbType.Int,4),
                        new SqlParameter("@Charge", SqlDbType.Decimal,9),
                        new SqlParameter("@PurchaseDate", SqlDbType.DateTime),
                        new SqlParameter("@Remark", SqlDbType.VarChar,500),
                        new SqlParameter("@IsPur", SqlDbType.Int,4),
                        new SqlParameter("@IsUndo", SqlDbType.Int,4)};
            parameters[0].Value = model.PurchaseID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.Amount;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.Number;
            parameters[6].Value = model.Quantity;
            parameters[7].Value = model.UnitNum;
            parameters[8].Value = model.SaleNum;
            parameters[9].Value = model.Charge;
            parameters[10].Value = model.PurchaseDate;
            parameters[11].Value = model.Remark;
            parameters[12].Value = model.IsPur;
            parameters[13].Value = model.IsUndo;

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
        public bool UpdatePur(long iPurchaseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Purchase set ");
            strSql.Append(" IsPur = @IsPur");
            strSql.Append(" where PurchaseID=@PurchaseID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@PurchaseID", SqlDbType.BigInt,8),
                        new SqlParameter("@IsPur", SqlDbType.Int,4)};

            parameters[0].Value = iPurchaseID;
            parameters[1].Value = 3;

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
        public bool Delete(long PurchaseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Purchase");
            strSql.Append(" where PurchaseID=@PurchaseID");
            SqlParameter[] parameters = {
					new SqlParameter("@PurchaseID", SqlDbType.Int,4)};
            parameters[0].Value = PurchaseID;

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
        public bool DeleteList(string PurchaseIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Purchase");
            strSql.Append(" where ID in (" + PurchaseIDlist + ") ");
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
        public lgk.Model.tb_Purchase GetModel(long PurchaseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PurchaseID, Title, UserID, Amount, Price, Number, Quantity, UnitNum, SaleNum, Charge, PurchaseDate, Remark, IsPur, IsUndo");
            strSql.Append(" from tb_Purchase");
            strSql.Append(" where PurchaseID=@PurchaseID");
            SqlParameter[] parameters = {
					new SqlParameter("@PurchaseID", SqlDbType.BigInt,8)};
            parameters[0].Value = PurchaseID;

            lgk.Model.tb_Purchase model = new lgk.Model.tb_Purchase();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PurchaseID"].ToString() != "")
                {
                    model.PurchaseID = long.Parse(ds.Tables[0].Rows[0]["PurchaseID"].ToString());
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
                if (ds.Tables[0].Rows[0]["Quantity"].ToString() != "")
                {
                    model.Quantity = int.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UnitNum"].ToString() != "")
                {
                    model.UnitNum = int.Parse(ds.Tables[0].Rows[0]["UnitNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SaleNum"].ToString() != "")
                {
                    model.SaleNum = int.Parse(ds.Tables[0].Rows[0]["SaleNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Charge"].ToString() != "")
                {
                    model.Charge = decimal.Parse(ds.Tables[0].Rows[0]["Charge"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PurchaseDate"].ToString() != "")
                {
                    model.PurchaseDate = DateTime.Parse(ds.Tables[0].Rows[0]["PurchaseDate"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["IsPur"].ToString() != "")
                {
                    model.IsPur = int.Parse(ds.Tables[0].Rows[0]["IsPur"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsUndo"].ToString() != "")
                {
                    model.IsUndo = int.Parse(ds.Tables[0].Rows[0]["IsUndo"].ToString());
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
        public lgk.Model.tb_Purchase GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 PurchaseID, Title, UserID, Amount, Price, Number, Quantity, UnitNum, SaleNum, Charge, PurchaseDate, Remark, IsPur, IsUndo");
            strSql.Append(" from tb_Purchase");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            lgk.Model.tb_Purchase model = new lgk.Model.tb_Purchase();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PurchaseID"].ToString() != "")
                {
                    model.PurchaseID = long.Parse(ds.Tables[0].Rows[0]["PurchaseID"].ToString());
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
                if (ds.Tables[0].Rows[0]["Quantity"].ToString() != "")
                {
                    model.Quantity = int.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UnitNum"].ToString() != "")
                {
                    model.UnitNum = int.Parse(ds.Tables[0].Rows[0]["UnitNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SaleNum"].ToString() != "")
                {
                    model.SaleNum = int.Parse(ds.Tables[0].Rows[0]["SaleNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Charge"].ToString() != "")
                {
                    model.Charge = decimal.Parse(ds.Tables[0].Rows[0]["Charge"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PurchaseDate"].ToString() != "")
                {
                    model.PurchaseDate = DateTime.Parse(ds.Tables[0].Rows[0]["PurchaseDate"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["IsPur"].ToString() != "")
                {
                    model.IsPur = int.Parse(ds.Tables[0].Rows[0]["IsPur"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsUndo"].ToString() != "")
                {
                    model.IsUndo = int.Parse(ds.Tables[0].Rows[0]["IsUndo"].ToString());
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
            strSql.Append("SELECT * FROM tb_Purchase");
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
            strSql.Append("SELECT [tb_Purchase].*,[tb_user].[UserCode]");
            strSql.Append(" FROM [tb_Purchase] JOIN [tb_user] ON [tb_user].[UserID]=[tb_Purchase].[UserID]");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }

            strSql.Append(" ORDER BY [tb_Purchase].[Price] DESC");
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
            strSql.Append(" FROM tb_Purchase ");
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
