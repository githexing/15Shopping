using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    /// <summary>
	/// 数据访问类:tb_LoginToken
	/// </summary>
	public partial class tb_LoginToken
    {
        public tb_LoginToken()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_LoginToken");
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
        public long Add(lgk.Model.tb_LoginToken model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_LoginToken(");
            strSql.Append("UserID,SmsCode,TokenCode,AddTime,EndTime,IsValid)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@SmsCode,@TokenCode,@AddTime,@EndTime,@IsValid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@SmsCode", SqlDbType.VarChar,20),
                    new SqlParameter("@TokenCode", SqlDbType.VarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@EndTime", SqlDbType.DateTime),
                    new SqlParameter("@IsValid", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.SmsCode;
            parameters[2].Value = model.TokenCode;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.EndTime;
            parameters[5].Value = model.IsValid;

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
        public bool Update(lgk.Model.tb_LoginToken model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_LoginToken set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("SmsCode=@SmsCode,");
            strSql.Append("TokenCode=@TokenCode,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("IsValid=@IsValid");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@SmsCode", SqlDbType.VarChar,20),
                    new SqlParameter("@TokenCode", SqlDbType.VarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@EndTime", SqlDbType.DateTime),
                    new SqlParameter("@IsValid", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.SmsCode;
            parameters[2].Value = model.TokenCode;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.EndTime;
            parameters[5].Value = model.IsValid;
            parameters[6].Value = model.ID;

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
            strSql.Append("delete from tb_LoginToken ");
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
            strSql.Append("delete from tb_LoginToken ");
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
        public lgk.Model.tb_LoginToken GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,SmsCode,TokenCode,AddTime,EndTime,IsValid from tb_LoginToken ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt)
            };
            parameters[0].Value = ID;

            lgk.Model.tb_LoginToken model = new lgk.Model.tb_LoginToken();
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
        public lgk.Model.tb_LoginToken GetModelBySmsCode(string SmsCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,SmsCode,TokenCode,AddTime,EndTime,IsValid from tb_LoginToken ");
            strSql.Append(" where SmsCode=@SmsCode");
            SqlParameter[] parameters = {
                    new SqlParameter("@SmsCode", SqlDbType.VarChar, 50)
            };
            parameters[0].Value = SmsCode;

            lgk.Model.tb_LoginToken model = new lgk.Model.tb_LoginToken();
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
        public lgk.Model.tb_LoginToken GetModelByToken(string TokenCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,SmsCode,TokenCode,AddTime,EndTime,IsValid from tb_LoginToken ");
            strSql.Append(" where TokenCode=@TokenCode");
            SqlParameter[] parameters = {
                    new SqlParameter("@TokenCode", SqlDbType.VarChar, 50)
            };
            parameters[0].Value = TokenCode;

            lgk.Model.tb_LoginToken model = new lgk.Model.tb_LoginToken();
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
        public lgk.Model.tb_LoginToken GetModelByUserIDAndIsValid(long UserID, int IsValid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,SmsCode,TokenCode,AddTime,EndTime,IsValid from tb_LoginToken ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt),
                    new SqlParameter("@IsValid", SqlDbType.Int)
            };
            parameters[0].Value = UserID;
            parameters[1].Value = IsValid;

            lgk.Model.tb_LoginToken model = new lgk.Model.tb_LoginToken();
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
        public lgk.Model.tb_LoginToken DataRowToModel(DataRow row)
        {
            lgk.Model.tb_LoginToken model = new lgk.Model.tb_LoginToken();
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
                if (row["SmsCode"] != null)
                {
                    model.SmsCode = row["SmsCode"].ToString();
                }
                if (row["TokenCode"] != null)
                {
                    model.TokenCode = row["TokenCode"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["EndTime"] != null && row["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(row["EndTime"].ToString());
                }
                if (row["IsValid"] != null && row["IsValid"].ToString() != "")
                {
                    model.IsValid = int.Parse(row["IsValid"].ToString());
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
            strSql.Append("select ID,UserID,SmsCode,TokenCode,AddTime,EndTime,IsValid ");
            strSql.Append(" FROM tb_LoginToken ");
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
            strSql.Append(" ID,UserID,SmsCode,TokenCode,AddTime,EndTime,IsValid ");
            strSql.Append(" FROM tb_LoginToken ");
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
            strSql.Append("select count(1) FROM tb_LoginToken ");
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
            strSql.Append(")AS Row, T.*  from tb_LoginToken T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        public bool UpdateIsValid(long UserID, int OldIsValid, int NewIsValid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_LoginToken set ");
            strSql.Append("IsValid=@NewIsValid");
            strSql.Append(" where UserID=@UserID and IsValid=@OldIsValid");
            SqlParameter[] parameters = {
                    new SqlParameter("@NewIsValid", SqlDbType.Int,4),
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@OldIsValid", SqlDbType.Int,4)
            };
            parameters[0].Value = NewIsValid;
            parameters[1].Value = UserID;
            parameters[2].Value = OldIsValid;

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
			parameters[0].Value = "tb_LoginToken";
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
