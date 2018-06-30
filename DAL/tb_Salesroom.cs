using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_Salesroom
    /// </summary>
    public partial class tb_Salesroom
    {
        public tb_Salesroom()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("SaID", "tb_Salesroom");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SaID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Salesroom");
            strSql.Append(" where SaID=@SaID");
            SqlParameter[] parameters = {
					new SqlParameter("@SaID", SqlDbType.Int,4)
			};
            parameters[0].Value = SaID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_Salesroom model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Salesroom(");
            strSql.Append("SaPrId,SaPrName,SaPrConent,SaPrUsually,SaPrImage,SaPrice,SaNumber,SaTypeID,SaJinpaiSate,SuccessUserID,RegTime1,RegTime2,SaTargetPoint,SaWeiPoint,SaSanPoint,SaSanTargetPoint,SaWeiTargetPoint,SaState,SaBeginTime,SaTurnoverTime,SaClapTime,Sa001,Sa002,SaAddTime,SaPrName_en,SaPrConent_en)");
            strSql.Append(" values (");
            strSql.Append("@SaPrId,@SaPrName,@SaPrConent,@SaPrUsually,@SaPrImage,@SaPrice,@SaNumber,@SaTypeID,@SaJinpaiSate,@SuccessUserID,@RegTime1,@RegTime2,@SaTargetPoint,@SaWeiPoint,@SaSanPoint,@SaSanTargetPoint,@SaWeiTargetPoint,@SaState,@SaBeginTime,@SaTurnoverTime,@SaClapTime,@Sa001,@Sa002,@SaAddTime,@SaPrName_en,@SaPrConent_en)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SaPrId", SqlDbType.Int,4),
					new SqlParameter("@SaPrName", SqlDbType.VarChar,100),
					new SqlParameter("@SaPrConent", SqlDbType.Text),
					new SqlParameter("@SaPrUsually", SqlDbType.Decimal,9),
					new SqlParameter("@SaPrImage", SqlDbType.VarChar,50),
					new SqlParameter("@SaPrice", SqlDbType.Decimal,9),
					new SqlParameter("@SaNumber", SqlDbType.VarChar,50),
					new SqlParameter("@SaTypeID", SqlDbType.Int,4),
					new SqlParameter("@SaJinpaiSate", SqlDbType.Int,4),
					new SqlParameter("@SuccessUserID", SqlDbType.Int,4),
					new SqlParameter("@RegTime1", SqlDbType.DateTime),
					new SqlParameter("@RegTime2", SqlDbType.DateTime),
					new SqlParameter("@SaTargetPoint", SqlDbType.Int,4),
					new SqlParameter("@SaWeiPoint", SqlDbType.Int,4),
					new SqlParameter("@SaSanPoint", SqlDbType.Int,4),
					new SqlParameter("@SaSanTargetPoint", SqlDbType.Int,4),
					new SqlParameter("@SaWeiTargetPoint", SqlDbType.Int,4),
					new SqlParameter("@SaState", SqlDbType.Int,4),
					new SqlParameter("@SaBeginTime", SqlDbType.DateTime),
					new SqlParameter("@SaTurnoverTime", SqlDbType.DateTime),
					new SqlParameter("@SaClapTime", SqlDbType.Int,4),
					new SqlParameter("@Sa001", SqlDbType.VarChar,50),
					new SqlParameter("@Sa002", SqlDbType.Decimal,9),
					new SqlParameter("@SaAddTime", SqlDbType.DateTime),
					new SqlParameter("@SaPrName_en", SqlDbType.VarChar,100),
					new SqlParameter("@SaPrConent_en", SqlDbType.Text)};
            parameters[0].Value = model.SaPrId;
            parameters[1].Value = model.SaPrName;
            parameters[2].Value = model.SaPrConent;
            parameters[3].Value = model.SaPrUsually;
            parameters[4].Value = model.SaPrImage;
            parameters[5].Value = model.SaPrice;
            parameters[6].Value = model.SaNumber;
            parameters[7].Value = model.SaTypeID;
            parameters[8].Value = model.SaJinpaiSate;
            parameters[9].Value = model.SuccessUserID;
            parameters[10].Value = model.RegTime1;
            parameters[11].Value = model.RegTime2;
            parameters[12].Value = model.SaTargetPoint;
            parameters[13].Value = model.SaWeiPoint;
            parameters[14].Value = model.SaSanPoint;
            parameters[15].Value = model.SaSanTargetPoint;
            parameters[16].Value = model.SaWeiTargetPoint;
            parameters[17].Value = model.SaState;
            parameters[18].Value = model.SaBeginTime;
            parameters[19].Value = model.SaTurnoverTime;
            parameters[20].Value = model.SaClapTime;
            parameters[21].Value = model.Sa001;
            parameters[22].Value = model.Sa002;
            parameters[23].Value = model.SaAddTime;
            parameters[24].Value = model.SaPrName_en;
            parameters[25].Value = model.SaPrConent_en;

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
        public bool Update(lgk.Model.tb_Salesroom model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Salesroom set ");
            strSql.Append("SaPrId=@SaPrId,");
            strSql.Append("SaPrName=@SaPrName,");
            strSql.Append("SaPrConent=@SaPrConent,");
            strSql.Append("SaPrUsually=@SaPrUsually,");
            strSql.Append("SaPrImage=@SaPrImage,");
            strSql.Append("SaPrice=@SaPrice,");
            strSql.Append("SaNumber=@SaNumber,");
            strSql.Append("SaTypeID=@SaTypeID,");
            strSql.Append("SaJinpaiSate=@SaJinpaiSate,");
            strSql.Append("SuccessUserID=@SuccessUserID,");
            strSql.Append("RegTime1=@RegTime1,");
            strSql.Append("RegTime2=@RegTime2,");
            strSql.Append("SaTargetPoint=@SaTargetPoint,");
            strSql.Append("SaWeiPoint=@SaWeiPoint,");
            strSql.Append("SaSanPoint=@SaSanPoint,");
            strSql.Append("SaSanTargetPoint=@SaSanTargetPoint,");
            strSql.Append("SaWeiTargetPoint=@SaWeiTargetPoint,");
            strSql.Append("SaState=@SaState,");
            strSql.Append("SaBeginTime=@SaBeginTime,");
            strSql.Append("SaTurnoverTime=@SaTurnoverTime,");
            strSql.Append("SaClapTime=@SaClapTime,");
            strSql.Append("Sa001=@Sa001,");
            strSql.Append("Sa002=@Sa002,");
            strSql.Append("SaAddTime=@SaAddTime,");
            strSql.Append("SaPrName_en=@SaPrName_en,");
            strSql.Append("SaPrConent_en=@SaPrConent_en");
            strSql.Append(" where SaID=@SaID");
            SqlParameter[] parameters = {
					new SqlParameter("@SaPrId", SqlDbType.Int,4),
					new SqlParameter("@SaPrName", SqlDbType.VarChar,100),
					new SqlParameter("@SaPrConent", SqlDbType.Text),
					new SqlParameter("@SaPrUsually", SqlDbType.Decimal,9),
					new SqlParameter("@SaPrImage", SqlDbType.VarChar,50),
					new SqlParameter("@SaPrice", SqlDbType.Decimal,9),
					new SqlParameter("@SaNumber", SqlDbType.VarChar,50),
					new SqlParameter("@SaTypeID", SqlDbType.Int,4),
					new SqlParameter("@SaJinpaiSate", SqlDbType.Int,4),
					new SqlParameter("@SuccessUserID", SqlDbType.Int,4),
					new SqlParameter("@RegTime1", SqlDbType.DateTime),
					new SqlParameter("@RegTime2", SqlDbType.DateTime),
					new SqlParameter("@SaTargetPoint", SqlDbType.Int,4),
					new SqlParameter("@SaWeiPoint", SqlDbType.Int,4),
					new SqlParameter("@SaSanPoint", SqlDbType.Int,4),
					new SqlParameter("@SaSanTargetPoint", SqlDbType.Int,4),
					new SqlParameter("@SaWeiTargetPoint", SqlDbType.Int,4),
					new SqlParameter("@SaState", SqlDbType.Int,4),
					new SqlParameter("@SaBeginTime", SqlDbType.DateTime),
					new SqlParameter("@SaTurnoverTime", SqlDbType.DateTime),
					new SqlParameter("@SaClapTime", SqlDbType.Int,4),
					new SqlParameter("@Sa001", SqlDbType.VarChar,50),
					new SqlParameter("@Sa002", SqlDbType.Decimal,9),
					new SqlParameter("@SaAddTime", SqlDbType.DateTime),
					new SqlParameter("@SaPrName_en", SqlDbType.VarChar,100),
					new SqlParameter("@SaPrConent_en", SqlDbType.Text),
					new SqlParameter("@SaID", SqlDbType.Int,4)};
            parameters[0].Value = model.SaPrId;
            parameters[1].Value = model.SaPrName;
            parameters[2].Value = model.SaPrConent;
            parameters[3].Value = model.SaPrUsually;
            parameters[4].Value = model.SaPrImage;
            parameters[5].Value = model.SaPrice;
            parameters[6].Value = model.SaNumber;
            parameters[7].Value = model.SaTypeID;
            parameters[8].Value = model.SaJinpaiSate;
            parameters[9].Value = model.SuccessUserID;
            parameters[10].Value = model.RegTime1;
            parameters[11].Value = model.RegTime2;
            parameters[12].Value = model.SaTargetPoint;
            parameters[13].Value = model.SaWeiPoint;
            parameters[14].Value = model.SaSanPoint;
            parameters[15].Value = model.SaSanTargetPoint;
            parameters[16].Value = model.SaWeiTargetPoint;
            parameters[17].Value = model.SaState;
            parameters[18].Value = model.SaBeginTime;
            parameters[19].Value = model.SaTurnoverTime;
            parameters[20].Value = model.SaClapTime;
            parameters[21].Value = model.Sa001;
            parameters[22].Value = model.Sa002;
            parameters[23].Value = model.SaAddTime;
            parameters[24].Value = model.SaPrName_en;
            parameters[25].Value = model.SaPrConent_en;
            parameters[26].Value = model.SaID;

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
        public bool Delete(int SaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Salesroom ");
            strSql.Append(" where SaID=@SaID");
            SqlParameter[] parameters = {
					new SqlParameter("@SaID", SqlDbType.Int,4)
			};
            parameters[0].Value = SaID;

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
        public bool DeleteList(string SaIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Salesroom ");
            strSql.Append(" where SaID in (" + SaIDlist + ")  ");
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
        public lgk.Model.tb_Salesroom GetModel(int SaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SaID,SaPrId,SaPrName,SaPrConent,SaPrUsually,SaPrImage,SaPrice,SaNumber,SaTypeID,SaJinpaiSate,SuccessUserID,RegTime1,RegTime2,SaTargetPoint,SaWeiPoint,SaSanPoint,SaSanTargetPoint,SaWeiTargetPoint,SaState,SaBeginTime,SaTurnoverTime,SaClapTime,Sa001,Sa002,SaAddTime,SaPrName_en,SaPrConent_en from tb_Salesroom ");
            strSql.Append(" where SaID=@SaID");
            SqlParameter[] parameters = {
					new SqlParameter("@SaID", SqlDbType.Int,4)
			};
            parameters[0].Value = SaID;

            lgk.Model.tb_Salesroom model = new lgk.Model.tb_Salesroom();
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
        public lgk.Model.tb_Salesroom DataRowToModel(DataRow row)
        {
            lgk.Model.tb_Salesroom model = new lgk.Model.tb_Salesroom();
            if (row != null)
            {
                if (row["SaID"] != null && row["SaID"].ToString() != "")
                {
                    model.SaID = int.Parse(row["SaID"].ToString());
                }
                if (row["SaPrId"] != null && row["SaPrId"].ToString() != "")
                {
                    model.SaPrId = int.Parse(row["SaPrId"].ToString());
                }
                if (row["SaPrName"] != null)
                {
                    model.SaPrName = row["SaPrName"].ToString();
                }
                if (row["SaPrConent"] != null)
                {
                    model.SaPrConent = row["SaPrConent"].ToString();
                }
                if (row["SaPrUsually"] != null && row["SaPrUsually"].ToString() != "")
                {
                    model.SaPrUsually = decimal.Parse(row["SaPrUsually"].ToString());
                }
                if (row["SaPrImage"] != null)
                {
                    model.SaPrImage = row["SaPrImage"].ToString();
                }
                if (row["SaPrice"] != null && row["SaPrice"].ToString() != "")
                {
                    model.SaPrice = decimal.Parse(row["SaPrice"].ToString());
                }
                if (row["SaNumber"] != null)
                {
                    model.SaNumber = row["SaNumber"].ToString();
                }
                if (row["SaTypeID"] != null && row["SaTypeID"].ToString() != "")
                {
                    model.SaTypeID = int.Parse(row["SaTypeID"].ToString());
                }
                if (row["SaJinpaiSate"] != null && row["SaJinpaiSate"].ToString() != "")
                {
                    model.SaJinpaiSate = int.Parse(row["SaJinpaiSate"].ToString());
                }
                if (row["SuccessUserID"] != null && row["SuccessUserID"].ToString() != "")
                {
                    model.SuccessUserID = int.Parse(row["SuccessUserID"].ToString());
                }
                if (row["RegTime1"] != null && row["RegTime1"].ToString() != "")
                {
                    model.RegTime1 = DateTime.Parse(row["RegTime1"].ToString());
                }
                if (row["RegTime2"] != null && row["RegTime2"].ToString() != "")
                {
                    model.RegTime2 = DateTime.Parse(row["RegTime2"].ToString());
                }
                if (row["SaTargetPoint"] != null && row["SaTargetPoint"].ToString() != "")
                {
                    model.SaTargetPoint = int.Parse(row["SaTargetPoint"].ToString());
                }
                if (row["SaWeiPoint"] != null && row["SaWeiPoint"].ToString() != "")
                {
                    model.SaWeiPoint = int.Parse(row["SaWeiPoint"].ToString());
                }
                if (row["SaSanPoint"] != null && row["SaSanPoint"].ToString() != "")
                {
                    model.SaSanPoint = int.Parse(row["SaSanPoint"].ToString());
                }
                if (row["SaSanTargetPoint"] != null && row["SaSanTargetPoint"].ToString() != "")
                {
                    model.SaSanTargetPoint = int.Parse(row["SaSanTargetPoint"].ToString());
                }
                if (row["SaWeiTargetPoint"] != null && row["SaWeiTargetPoint"].ToString() != "")
                {
                    model.SaWeiTargetPoint = int.Parse(row["SaWeiTargetPoint"].ToString());
                }
                if (row["SaState"] != null && row["SaState"].ToString() != "")
                {
                    model.SaState = int.Parse(row["SaState"].ToString());
                }
                if (row["SaBeginTime"] != null && row["SaBeginTime"].ToString() != "")
                {
                    model.SaBeginTime = DateTime.Parse(row["SaBeginTime"].ToString());
                }
                if (row["SaTurnoverTime"] != null && row["SaTurnoverTime"].ToString() != "")
                {
                    model.SaTurnoverTime = DateTime.Parse(row["SaTurnoverTime"].ToString());
                }
                if (row["SaClapTime"] != null && row["SaClapTime"].ToString() != "")
                {
                    model.SaClapTime = int.Parse(row["SaClapTime"].ToString());
                }
                if (row["Sa001"] != null)
                {
                    model.Sa001 = row["Sa001"].ToString();
                }
                if (row["Sa002"] != null && row["Sa002"].ToString() != "")
                {
                    model.Sa002 = decimal.Parse(row["Sa002"].ToString());
                }
                if (row["SaAddTime"] != null && row["SaAddTime"].ToString() != "")
                {
                    model.SaAddTime = DateTime.Parse(row["SaAddTime"].ToString());
                }
                if (row["SaPrName_en"] != null)
                {
                    model.SaPrName_en = row["SaPrName_en"].ToString();
                }
                if (row["SaPrConent_en"] != null)
                {
                    model.SaPrConent_en = row["SaPrConent_en"].ToString();
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
            strSql.Append("select SaID,SaPrId,SaPrName,SaPrConent,SaPrUsually,SaPrImage,SaPrice,SaNumber,SaTypeID,SaJinpaiSate,SuccessUserID,RegTime1,RegTime2,SaTargetPoint,SaWeiPoint,SaSanPoint,SaSanTargetPoint,SaWeiTargetPoint,SaState,SaBeginTime,SaTurnoverTime,SaClapTime,Sa001,Sa002,SaAddTime,SaPrName_en,SaPrConent_en ");
            strSql.Append(" FROM tb_Salesroom ");
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
            strSql.Append(" SaID,SaPrId,SaPrName,SaPrConent,SaPrUsually,SaPrImage,SaPrice,SaNumber,SaTypeID,SaJinpaiSate,SuccessUserID,RegTime1,RegTime2,SaTargetPoint,SaWeiPoint,SaSanPoint,SaSanTargetPoint,SaWeiTargetPoint,SaState,SaBeginTime,SaTurnoverTime,SaClapTime,Sa001,Sa002,SaAddTime,SaPrName_en,SaPrConent_en ");
            strSql.Append(" FROM tb_Salesroom ");
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
            strSql.Append("select count(1) FROM tb_Salesroom ");
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
                strSql.Append("order by T.SaID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_Salesroom T ");
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
            parameters[0].Value = "tb_Salesroom";
            parameters[1].Value = "SaID";
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
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Salesroom GetModel(string strwhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SaID,SaPrId,SaPrName,SaPrConent,SaPrUsually,SaPrImage,SaPrice,SaNumber,SaTypeID,SaJinpaiSate,SuccessUserID,RegTime1,RegTime2,SaTargetPoint,SaWeiPoint,SaSanPoint,SaSanTargetPoint,SaWeiTargetPoint,SaState,SaBeginTime,SaTurnoverTime,SaClapTime,Sa001,Sa002,SaAddTime,SaPrName_en,SaPrConent_en from tb_Salesroom ");
            strSql.Append(" where " + strwhere);
            lgk.Model.tb_Salesroom model = new lgk.Model.tb_Salesroom();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetListUser(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SaID,SaPrId,SaPrName,SaPrConent,SaPrName_en,SaPrConent_en,SaPrUsually,SaPrImage,SaPrice,SaNumber,SaTypeID,SaJinpaiSate,SaTargetPoint,SaWeiPoint,SaSanPoint,SaSanTargetPoint,SaWeiTargetPoint,SaState,SaBeginTime,SaTurnoverTime,SaClapTime,Sa001,Sa002,SaAddTime,SuccessUserID,RegTime1,RegTime2,UserCode ");
            strSql.Append(" FROM tb_Salesroom s JOIN tb_user u ON s.SuccessUserID=u.UserID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}
