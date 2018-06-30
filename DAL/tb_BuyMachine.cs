using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DataAccess;

namespace lgk.DAL
{
    //tb_BuyMachine
    public partial class tb_BuyMachine
    {
        public tb_BuyMachine()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_BuyMachine");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt)
            };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_BuyMachine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_BuyMachine(");
            strSql.Append("UserID,Price,Num,Amount,BuyTime,CalcPower,IsExpire,IsActive,ActiveTime,SurplusNum,ActiveNum)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@Price,@Num,@Amount,@BuyTime,@CalcPower,@IsExpire,@IsActive,@ActiveTime,@SurplusNum,@ActiveNum)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@Num", SqlDbType.Int,4),
                    new SqlParameter("@Amount", SqlDbType.Decimal,9),
                    new SqlParameter("@BuyTime", SqlDbType.DateTime),
                    new SqlParameter("@CalcPower", SqlDbType.Decimal,9),
                    new SqlParameter("@IsExpire", SqlDbType.Int,4),
                    new SqlParameter("@IsActive", SqlDbType.Int,4),
                    new SqlParameter("@ActiveTime", SqlDbType.DateTime),
                    new SqlParameter("@SurplusNum", SqlDbType.Int,4),
                    new SqlParameter("@ActiveNum", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Price;
            parameters[2].Value = model.Num;
            parameters[3].Value = model.Amount;
            parameters[4].Value = model.BuyTime;
            parameters[5].Value = model.CalcPower;
            parameters[6].Value = model.IsExpire;
            parameters[7].Value = model.IsActive;
            parameters[8].Value = model.ActiveTime;
            parameters[9].Value = model.SurplusNum;
            parameters[10].Value = model.ActiveNum;

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
        public bool Update(lgk.Model.tb_BuyMachine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_BuyMachine set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Price=@Price,");
            strSql.Append("Num=@Num,");
            strSql.Append("Amount=@Amount,");
            strSql.Append("BuyTime=@BuyTime,");
            strSql.Append("CalcPower=@CalcPower,");
            strSql.Append("IsExpire=@IsExpire,");
            strSql.Append("IsActive=@IsActive,");
            strSql.Append("ActiveTime=@ActiveTime,");
            strSql.Append("SurplusNum=@SurplusNum,");
            strSql.Append("ActiveNum=@ActiveNum");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@Num", SqlDbType.Int,4),
                    new SqlParameter("@Amount", SqlDbType.Decimal,9),
                    new SqlParameter("@BuyTime", SqlDbType.DateTime),
                    new SqlParameter("@CalcPower", SqlDbType.Decimal,9),
                    new SqlParameter("@IsExpire", SqlDbType.Int,4),
                    new SqlParameter("@IsActive", SqlDbType.Int,4),
                    new SqlParameter("@ActiveTime", SqlDbType.DateTime),
                    new SqlParameter("@SurplusNum", SqlDbType.Int,4),
                    new SqlParameter("@ActiveNum", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Price;
            parameters[2].Value = model.Num;
            parameters[3].Value = model.Amount;
            parameters[4].Value = model.BuyTime;
            parameters[5].Value = model.CalcPower;
            parameters[6].Value = model.IsExpire;
            parameters[7].Value = model.IsActive;
            parameters[8].Value = model.ActiveTime;
            parameters[9].Value = model.SurplusNum;
            parameters[10].Value = model.ActiveNum;
            parameters[11].Value = model.ID;

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
        public bool Delete(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_BuyMachine ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt)
            };
            parameters[0].Value = ID;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_BuyMachine ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public lgk.Model.tb_BuyMachine GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,Price,Num,Amount,BuyTime,CalcPower,IsExpire,IsActive,ActiveTime,SurplusNum,ActiveNum from tb_BuyMachine ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt)
            };
            parameters[0].Value = ID;

            lgk.Model.tb_BuyMachine model = new lgk.Model.tb_BuyMachine();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_BuyMachine DataRowToModel(DataRow row)
        {
            lgk.Model.tb_BuyMachine model = new lgk.Model.tb_BuyMachine();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(row["UserID"].ToString());
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["Num"] != null && row["Num"].ToString() != "")
                {
                    model.Num = int.Parse(row["Num"].ToString());
                }
                if (row["Amount"] != null && row["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(row["Amount"].ToString());
                }
                if (row["BuyTime"] != null && row["BuyTime"].ToString() != "")
                {
                    model.BuyTime = DateTime.Parse(row["BuyTime"].ToString());
                }
                if (row["CalcPower"] != null && row["CalcPower"].ToString() != "")
                {
                    model.CalcPower = decimal.Parse(row["CalcPower"].ToString());
                }
                if (row["IsExpire"] != null && row["IsExpire"].ToString() != "")
                {
                    model.IsExpire = int.Parse(row["IsExpire"].ToString());
                }
                if (row["IsActive"] != null && row["IsActive"].ToString() != "")
                {
                    model.IsActive = int.Parse(row["IsActive"].ToString());
                }
                if (row["ActiveTime"] != null && row["ActiveTime"].ToString() != "")
                {
                    model.ActiveTime = DateTime.Parse(row["ActiveTime"].ToString());
                }
                if (row["SurplusNum"] != null && row["SurplusNum"].ToString() != "")
                {
                    model.SurplusNum = int.Parse(row["SurplusNum"].ToString());
                }
                if (row["ActiveNum"] != null && row["ActiveNum"].ToString() != "")
                {
                    model.ActiveNum = int.Parse(row["ActiveNum"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserID,Price,Num,Amount,BuyTime,CalcPower,IsExpire,IsActive,ActiveTime,SurplusNum,ActiveNum ");
            strSql.Append(" FROM tb_BuyMachine ");
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
            strSql.Append(" ID,UserID,Price,Num,Amount,BuyTime,CalcPower,IsExpire,IsActive,ActiveTime,SurplusNum,ActiveNum ");
            strSql.Append(" FROM tb_BuyMachine ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_BuyMachine ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_BuyMachine T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_BuyMachine";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

    }
}

