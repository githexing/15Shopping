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
	/// 数据访问类:tb_SuanliJournal
	/// </summary>
	public partial class tb_SuanliJournal
    {
        public tb_SuanliJournal()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_SuanliJournal");
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
		public long Add(lgk.Model.tb_SuanliJournal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_SuanliJournal(");
            strSql.Append("UserID,ReduceAmount,AddAmount,SurplusAmount,MoneyType,Remark,RemarkEn,JoinTime,FromUserID)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@ReduceAmount,@AddAmount,@SurplusAmount,@MoneyType,@Remark,@RemarkEn,@JoinTime,@FromUserID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@ReduceAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@AddAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@SurplusAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@MoneyType", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.VarChar,500),
                    new SqlParameter("@RemarkEn", SqlDbType.VarChar,500),
                    new SqlParameter("@JoinTime", SqlDbType.DateTime),
                    new SqlParameter("@FromUserID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.ReduceAmount;
            parameters[2].Value = model.AddAmount;
            parameters[3].Value = model.SurplusAmount;
            parameters[4].Value = model.MoneyType;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.RemarkEn;
            parameters[7].Value = model.JoinTime;
            parameters[8].Value = model.FromUserID;

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
        public bool Update(lgk.Model.tb_SuanliJournal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_SuanliJournal set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("ReduceAmount=@ReduceAmount,");
            strSql.Append("AddAmount=@AddAmount,");
            strSql.Append("SurplusAmount=@SurplusAmount,");
            strSql.Append("MoneyType=@MoneyType,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("RemarkEn=@RemarkEn,");
            strSql.Append("JoinTime=@JoinTime,");
            strSql.Append("FromUserID=@FromUserID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@ReduceAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@AddAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@SurplusAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@MoneyType", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.VarChar,500),
                    new SqlParameter("@RemarkEn", SqlDbType.VarChar,500),
                    new SqlParameter("@JoinTime", SqlDbType.DateTime),
                    new SqlParameter("@FromUserID", SqlDbType.BigInt,8),
                    new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.ReduceAmount;
            parameters[2].Value = model.AddAmount;
            parameters[3].Value = model.SurplusAmount;
            parameters[4].Value = model.MoneyType;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.RemarkEn;
            parameters[7].Value = model.JoinTime;
            parameters[8].Value = model.FromUserID;
            parameters[9].Value = model.ID;

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
            strSql.Append("delete from tb_SuanliJournal ");
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
            strSql.Append("delete from tb_SuanliJournal ");
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
        public lgk.Model.tb_SuanliJournal GetModel(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,ReduceAmount,AddAmount,SurplusAmount,MoneyType,Remark,RemarkEn,JoinTime,FromUserID from tb_SuanliJournal ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt)
            };
            parameters[0].Value = ID;

            lgk.Model.tb_SuanliJournal model = new lgk.Model.tb_SuanliJournal();
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
		public lgk.Model.tb_SuanliJournal DataRowToModel(DataRow row)
        {
            lgk.Model.tb_SuanliJournal model = new lgk.Model.tb_SuanliJournal();
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
                if (row["ReduceAmount"] != null && row["ReduceAmount"].ToString() != "")
                {
                    model.ReduceAmount = decimal.Parse(row["ReduceAmount"].ToString());
                }
                if (row["AddAmount"] != null && row["AddAmount"].ToString() != "")
                {
                    model.AddAmount = decimal.Parse(row["AddAmount"].ToString());
                }
                if (row["SurplusAmount"] != null && row["SurplusAmount"].ToString() != "")
                {
                    model.SurplusAmount = decimal.Parse(row["SurplusAmount"].ToString());
                }
                if (row["MoneyType"] != null && row["MoneyType"].ToString() != "")
                {
                    model.MoneyType = int.Parse(row["MoneyType"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["RemarkEn"] != null)
                {
                    model.RemarkEn = row["RemarkEn"].ToString();
                }
                if (row["JoinTime"] != null && row["JoinTime"].ToString() != "")
                {
                    model.JoinTime = DateTime.Parse(row["JoinTime"].ToString());
                }
                if (row["FromUserID"] != null && row["FromUserID"].ToString() != "")
                {
                    model.FromUserID = long.Parse(row["FromUserID"].ToString());
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
            strSql.Append("select ID,UserID,ReduceAmount,AddAmount,SurplusAmount,MoneyType,Remark,RemarkEn,JoinTime,FromUserID ");
            strSql.Append(" FROM tb_SuanliJournal ");
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
            strSql.Append(" ID,UserID,ReduceAmount,AddAmount,SurplusAmount,MoneyType,Remark,RemarkEn,JoinTime,FromUserID ");
            strSql.Append(" FROM tb_SuanliJournal ");
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
            strSql.Append("select count(1) FROM tb_SuanliJournal ");
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
            strSql.Append(")AS Row, T.*  from tb_SuanliJournal T ");
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
			parameters[0].Value = "tb_SuanliJournal";
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

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <param name="TotalCount"></param>
        /// <param name="FindKey"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public DataSet GetListByPageProc(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount, string FindKey, int Type)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageCount", SqlDbType.Int),
                    new SqlParameter("@TotalCount", SqlDbType.Int),
                    new SqlParameter("@FindKey", SqlDbType.VarChar,30),
                    new SqlParameter("@Type", SqlDbType.Int)
            };
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;

            parameters[0].Value = UserID;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[5].Value = FindKey;
            parameters[6].Value = Type;

            string proc = "proc_Page_SuanLiList";
            DataSet ds = DbHelperSQL.RunProcedure(proc, parameters, "suanli");

            PageCount = int.Parse(parameters[3].Value.ToString());
            TotalCount = int.Parse(parameters[4].Value.ToString());

            return ds;
        }

        #endregion  ExtensionMethod
    }
}
