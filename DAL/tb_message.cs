using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_message
    /// </summary>
    public partial class tb_message
    {
        public tb_message()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_message");
            strSql.Append(" where MID=@MID");
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.Int,4)
			};
            parameters[0].Value = MID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_message(");
            strSql.Append("Userid,MobileNum,Mcontent,Flag)");
            strSql.Append(" values (");
            strSql.Append("@Userid,@MobileNum,@Mcontent,@Flag)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Userid", SqlDbType.Int,4),
					new SqlParameter("@MobileNum", SqlDbType.VarChar,50),
					new SqlParameter("@Mcontent", SqlDbType.VarChar,500),
					new SqlParameter("@Flag", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Userid;
            parameters[1].Value = model.MobileNum;
            parameters[2].Value = model.Mcontent;
            parameters[3].Value = model.Flag;

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
        public bool Update(lgk.Model.tb_message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_message set ");
            strSql.Append("Userid=@Userid,");
            strSql.Append("MobileNum=@MobileNum,");
            strSql.Append("Mcontent=@Mcontent,");
            strSql.Append("Flag=@Flag");
            strSql.Append(" where MID=@MID");
            SqlParameter[] parameters = {
					new SqlParameter("@Userid", SqlDbType.Int,4),
					new SqlParameter("@MobileNum", SqlDbType.VarChar,50),
					new SqlParameter("@Mcontent", SqlDbType.VarChar,500),
					new SqlParameter("@Flag", SqlDbType.VarChar,50),
					new SqlParameter("@MID", SqlDbType.Int,4)};
            parameters[0].Value = model.Userid;
            parameters[1].Value = model.MobileNum;
            parameters[2].Value = model.Mcontent;
            parameters[3].Value = model.Flag;
            parameters[4].Value = model.MID;

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
        public bool Delete(int MID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_message ");
            strSql.Append(" where MID=@MID");
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.Int,4)
			};
            parameters[0].Value = MID;

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
        public bool DeleteList(string MIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_message ");
            strSql.Append(" where MID in (" + MIDlist + ")  ");
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
        public lgk.Model.tb_message GetModel(int MID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MID,Userid,MobileNum,Mcontent,Flag from tb_message ");
            strSql.Append(" where MID=@MID");
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.Int,4)
			};
            parameters[0].Value = MID;

            lgk.Model.tb_message model = new lgk.Model.tb_message();
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
        public lgk.Model.tb_message DataRowToModel(DataRow row)
        {
            lgk.Model.tb_message model = new lgk.Model.tb_message();
            if (row != null)
            {
                if (row["MID"] != null && row["MID"].ToString() != "")
                {
                    model.MID = int.Parse(row["MID"].ToString());
                }
                if (row["Userid"] != null && row["Userid"].ToString() != "")
                {
                    model.Userid = int.Parse(row["Userid"].ToString());
                }
                if (row["MobileNum"] != null)
                {
                    model.MobileNum = row["MobileNum"].ToString();
                }
                if (row["Mcontent"] != null)
                {
                    model.Mcontent = row["Mcontent"].ToString();
                }
                if (row["Flag"] != null && row["Flag"].ToString() != "")
                {
                    model.Flag = row["Flag"].ToString();
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
            strSql.Append("select MID,m.Userid,MobileNum,Mcontent,m.SendTime,Flag,UserCode ");
            strSql.Append("FROM tb_message m left JOIN tb_user ON  tb_user.UserID=m.Userid ");
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
            strSql.Append(" MID,Userid,MobileNum,Mcontent,Flag ");
            strSql.Append(" FROM tb_message ");
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
            strSql.Append("select count(1) FROM tb_message ");
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
                strSql.Append("order by T.MID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_message T ");
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
            parameters[0].Value = "tb_message";
            parameters[1].Value = "MID";
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
