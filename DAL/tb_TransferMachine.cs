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
	/// 数据访问类:tb_TransferMachine
	/// </summary>
	public partial class tb_TransferMachine
    {
        public tb_TransferMachine()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TransferMachine");
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
        public long Add(lgk.Model.tb_TransferMachine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_TransferMachine(");
            strSql.Append("UserID,ToUserID,TransferNum,TransferTime,TransferType,Remark,RemarkEn,ToRemark,ToRemarkEn)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@ToUserID,@TransferNum,@TransferTime,@TransferType,@Remark,@RemarkEn,@ToRemark,@ToRemarkEn)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@ToUserID", SqlDbType.BigInt,8),
                    new SqlParameter("@TransferNum", SqlDbType.Int,4),
                    new SqlParameter("@TransferTime", SqlDbType.DateTime),
                    new SqlParameter("@TransferType", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.VarChar,200),
                    new SqlParameter("@RemarkEn", SqlDbType.VarChar,200),
                    new SqlParameter("@ToRemark", SqlDbType.VarChar,200),
                    new SqlParameter("@ToRemarkEn", SqlDbType.VarChar,200)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.ToUserID;
            parameters[2].Value = model.TransferNum;
            parameters[3].Value = model.TransferTime;
            parameters[4].Value = model.TransferType;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.RemarkEn;
            parameters[7].Value = model.ToRemark;
            parameters[8].Value = model.ToRemarkEn;

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
        public bool Update(lgk.Model.tb_TransferMachine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TransferMachine set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("ToUserID=@ToUserID,");
            strSql.Append("TransferNum=@TransferNum,");
            strSql.Append("TransferTime=@TransferTime,");
            strSql.Append("TransferType=@TransferType,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("RemarkEn=@RemarkEn,");
            strSql.Append("ToRemark=@ToRemark,");
            strSql.Append("ToRemarkEn=@ToRemarkEn");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@ToUserID", SqlDbType.BigInt,8),
                    new SqlParameter("@TransferNum", SqlDbType.Int,4),
                    new SqlParameter("@TransferTime", SqlDbType.DateTime),
                    new SqlParameter("@TransferType", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.VarChar,200),
                    new SqlParameter("@RemarkEn", SqlDbType.VarChar,200),
                    new SqlParameter("@ToRemark", SqlDbType.VarChar,200),
                    new SqlParameter("@ToRemarkEn", SqlDbType.VarChar,200),
                    new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.ToUserID;
            parameters[2].Value = model.TransferNum;
            parameters[3].Value = model.TransferTime;
            parameters[4].Value = model.TransferType;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.RemarkEn;
            parameters[7].Value = model.ToRemark;
            parameters[8].Value = model.ToRemarkEn;
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
            strSql.Append("delete from tb_TransferMachine ");
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
            strSql.Append("delete from tb_TransferMachine ");
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
        public lgk.Model.tb_TransferMachine GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,ToUserID,TransferNum,TransferTime,TransferType,Remark,RemarkEn,ToRemark,ToRemarkEn from tb_TransferMachine ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt)
            };
            parameters[0].Value = ID;

            lgk.Model.tb_TransferMachine model = new lgk.Model.tb_TransferMachine();
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
        public lgk.Model.tb_TransferMachine DataRowToModel(DataRow row)
        {
            lgk.Model.tb_TransferMachine model = new lgk.Model.tb_TransferMachine();
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
                if (row["ToUserID"] != null && row["ToUserID"].ToString() != "")
                {
                    model.ToUserID = long.Parse(row["ToUserID"].ToString());
                }
                if (row["TransferNum"] != null && row["TransferNum"].ToString() != "")
                {
                    model.TransferNum = int.Parse(row["TransferNum"].ToString());
                }
                if (row["TransferTime"] != null && row["TransferTime"].ToString() != "")
                {
                    model.TransferTime = DateTime.Parse(row["TransferTime"].ToString());
                }
                if (row["TransferType"] != null && row["TransferType"].ToString() != "")
                {
                    model.TransferType = int.Parse(row["TransferType"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["RemarkEn"] != null)
                {
                    model.RemarkEn = row["RemarkEn"].ToString();
                }
                if (row["ToRemark"] != null)
                {
                    model.ToRemark = row["ToRemark"].ToString();
                }
                if (row["ToRemarkEn"] != null)
                {
                    model.ToRemarkEn = row["ToRemarkEn"].ToString();
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
            strSql.Append("select ID,UserID,ToUserID,TransferNum,TransferTime,TransferType,Remark,RemarkEn,ToRemark,ToRemarkEn ");
            strSql.Append(" FROM tb_TransferMachine ");
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
            strSql.Append(" ID,UserID,ToUserID,TransferNum,TransferTime,TransferType,Remark,RemarkEn,ToRemark,ToRemarkEn ");
            strSql.Append(" FROM tb_TransferMachine ");
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
            strSql.Append("select count(1) FROM tb_TransferMachine ");
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
            strSql.Append(")AS Row, T.*  from tb_TransferMachine T ");
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
			parameters[0].Value = "tb_TransferMachine";
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

        #region 转移矿机
        /// <summary>
        /// 转移矿机
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="BuyNum"></param>
        /// <returns></returns>
        public string proc_Transfer_Machine(long UserID, long ToUserID, int BuyNum)
        {
            object[] obj = DbHelperSQLP.ExecuteSP_Param_Object("proc_Transfer_Machine", UserID, ToUserID, BuyNum, "");
            if (obj != null && obj[1] != null)
            {
                return obj[1].ToString();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 分页
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <param name="TotalCount"></param>
        /// <param name="FindKey"></param>
        /// <returns></returns>
        public DataSet GetListByPageProc(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount, string FindKey)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageCount", SqlDbType.Int),
                    new SqlParameter("@TotalCount", SqlDbType.Int),
                    new SqlParameter("@FindKey", SqlDbType.VarChar,30)
            };
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;

            parameters[0].Value = UserID;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[5].Value = FindKey;

            string proc = "proc_Page_TransferMachine";
            DataSet ds = DbHelperSQL.RunProcedure(proc, parameters, "machine");

            PageCount = int.Parse(parameters[3].Value.ToString());
            TotalCount = int.Parse(parameters[4].Value.ToString());

            return ds;
        }
        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetInnerList(long UserID, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TransferNum,TransferTime, u.UserCode, tu.UserCode as ToUserCode,");
            strSql.Append("case when t.UserID="+ UserID + " then '转出' else '转入' end as TypeName, ");
            strSql.Append("case when t.UserID=" + UserID + " then Remark else ToRemark end as Remark ");
            strSql.Append("from tb_TransferMachine as t ");
            strSql.Append("inner join tb_user as u on t.UserID=u.UserID ");
            strSql.Append("inner join tb_user as tu on t.ToUserID=tu.UserID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}
