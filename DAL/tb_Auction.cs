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
    /// 数据访问类:tb_Auction
    /// </summary>
    public partial class tb_Auction
    {
        public tb_Auction()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Auction");
            strSql.Append(" where AID=@AID");
            SqlParameter[] parameters = {
					new SqlParameter("@AID", SqlDbType.Int,4)
			};
            parameters[0].Value = AID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_Auction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Auction(");
            strSql.Append("userId,SaId,Atype,SaPrName,SaNumber,AuctionTime,AuctionPrice,Auction001,Auction002,Auction003,Auction004,Auction005,Auction006)");
            strSql.Append(" values (");
            strSql.Append("@userId,@SaId,@Atype,@SaPrName,@SaNumber,@AuctionTime,@AuctionPrice,@Auction001,@Auction002,@Auction003,@Auction004,@Auction005,@Auction006)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@SaId", SqlDbType.Int,4),
					new SqlParameter("@Atype", SqlDbType.Int,4),
					new SqlParameter("@SaPrName", SqlDbType.VarChar,50),
					new SqlParameter("@SaNumber", SqlDbType.VarChar,50),
					new SqlParameter("@AuctionTime", SqlDbType.DateTime),
					new SqlParameter("@AuctionPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Auction001", SqlDbType.Int,4),
					new SqlParameter("@Auction002", SqlDbType.Int,4),
					new SqlParameter("@Auction003", SqlDbType.VarChar,50),
					new SqlParameter("@Auction004", SqlDbType.VarChar,50),
					new SqlParameter("@Auction005", SqlDbType.Decimal,9),
					new SqlParameter("@Auction006", SqlDbType.Decimal,9)};
            parameters[0].Value = model.userId;
            parameters[1].Value = model.SaId;
            parameters[2].Value = model.Atype;
            parameters[3].Value = model.SaPrName;
            parameters[4].Value = model.SaNumber;
            parameters[5].Value = model.AuctionTime;
            parameters[6].Value = model.AuctionPrice;
            parameters[7].Value = model.Auction001;
            parameters[8].Value = model.Auction002;
            parameters[9].Value = model.Auction003;
            parameters[10].Value = model.Auction004;
            parameters[11].Value = model.Auction005;
            parameters[12].Value = model.Auction006;

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
        public bool Update(lgk.Model.tb_Auction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Auction set ");
            strSql.Append("userId=@userId,");
            strSql.Append("SaId=@SaId,");
            strSql.Append("Atype=@Atype,");
            strSql.Append("SaPrName=@SaPrName,");
            strSql.Append("SaNumber=@SaNumber,");
            strSql.Append("AuctionTime=@AuctionTime,");
            strSql.Append("AuctionPrice=@AuctionPrice,");
            strSql.Append("Auction001=@Auction001,");
            strSql.Append("Auction002=@Auction002,");
            strSql.Append("Auction003=@Auction003,");
            strSql.Append("Auction004=@Auction004,");
            strSql.Append("Auction005=@Auction005,");
            strSql.Append("Auction006=@Auction006");
            strSql.Append(" where AID=@AID");
            SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@SaId", SqlDbType.Int,4),
					new SqlParameter("@Atype", SqlDbType.Int,4),
					new SqlParameter("@SaPrName", SqlDbType.VarChar,50),
					new SqlParameter("@SaNumber", SqlDbType.VarChar,50),
					new SqlParameter("@AuctionTime", SqlDbType.DateTime),
					new SqlParameter("@AuctionPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Auction001", SqlDbType.Int,4),
					new SqlParameter("@Auction002", SqlDbType.Int,4),
					new SqlParameter("@Auction003", SqlDbType.VarChar,50),
					new SqlParameter("@Auction004", SqlDbType.VarChar,50),
					new SqlParameter("@Auction005", SqlDbType.Decimal,9),
					new SqlParameter("@Auction006", SqlDbType.Decimal,9),
					new SqlParameter("@AID", SqlDbType.Int,4)};
            parameters[0].Value = model.userId;
            parameters[1].Value = model.SaId;
            parameters[2].Value = model.Atype;
            parameters[3].Value = model.SaPrName;
            parameters[4].Value = model.SaNumber;
            parameters[5].Value = model.AuctionTime;
            parameters[6].Value = model.AuctionPrice;
            parameters[7].Value = model.Auction001;
            parameters[8].Value = model.Auction002;
            parameters[9].Value = model.Auction003;
            parameters[10].Value = model.Auction004;
            parameters[11].Value = model.Auction005;
            parameters[12].Value = model.Auction006;
            parameters[13].Value = model.AID;

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
        public bool Delete(int AID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Auction ");
            strSql.Append(" where AID=@AID");
            SqlParameter[] parameters = {
					new SqlParameter("@AID", SqlDbType.Int,4)
			};
            parameters[0].Value = AID;

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
        public bool DeleteList(string AIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Auction ");
            strSql.Append(" where AID in (" + AIDlist + ")  ");
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
        public lgk.Model.tb_Auction GetModel(int AID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AID,userId,SaId,Atype,SaPrName,SaNumber,AuctionTime,AuctionPrice,Auction001,Auction002,Auction003,Auction004,Auction005,Auction006 from tb_Auction ");
            strSql.Append(" where AID=@AID");
            SqlParameter[] parameters = {
					new SqlParameter("@AID", SqlDbType.Int,4)
			};
            parameters[0].Value = AID;

            lgk.Model.tb_Auction model = new lgk.Model.tb_Auction();
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
        public lgk.Model.tb_Auction DataRowToModel(DataRow row)
        {
            lgk.Model.tb_Auction model = new lgk.Model.tb_Auction();
            if (row != null)
            {
                if (row["AID"] != null && row["AID"].ToString() != "")
                {
                    model.AID = int.Parse(row["AID"].ToString());
                }
                if (row["userId"] != null && row["userId"].ToString() != "")
                {
                    model.userId = int.Parse(row["userId"].ToString());
                }
                if (row["SaId"] != null && row["SaId"].ToString() != "")
                {
                    model.SaId = int.Parse(row["SaId"].ToString());
                }
                if (row["Atype"] != null && row["Atype"].ToString() != "")
                {
                    model.Atype = int.Parse(row["Atype"].ToString());
                }
                if (row["SaPrName"] != null)
                {
                    model.SaPrName = row["SaPrName"].ToString();
                }
                if (row["SaNumber"] != null)
                {
                    model.SaNumber = row["SaNumber"].ToString();
                }
                if (row["AuctionTime"] != null && row["AuctionTime"].ToString() != "")
                {
                    model.AuctionTime = DateTime.Parse(row["AuctionTime"].ToString());
                }
                if (row["AuctionPrice"] != null && row["AuctionPrice"].ToString() != "")
                {
                    model.AuctionPrice = decimal.Parse(row["AuctionPrice"].ToString());
                }
                if (row["Auction001"] != null && row["Auction001"].ToString() != "")
                {
                    model.Auction001 = int.Parse(row["Auction001"].ToString());
                }
                if (row["Auction002"] != null && row["Auction002"].ToString() != "")
                {
                    model.Auction002 = int.Parse(row["Auction002"].ToString());
                }
                if (row["Auction003"] != null)
                {
                    model.Auction003 = row["Auction003"].ToString();
                }
                if (row["Auction004"] != null)
                {
                    model.Auction004 = row["Auction004"].ToString();
                }
                if (row["Auction005"] != null && row["Auction005"].ToString() != "")
                {
                    model.Auction005 = decimal.Parse(row["Auction005"].ToString());
                }
                if (row["Auction006"] != null && row["Auction006"].ToString() != "")
                {
                    model.Auction006 = decimal.Parse(row["Auction006"].ToString());
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
            strSql.Append("select AID,UserCode,a.userId,SaId,Atype,SaPrName,SaNumber,AuctionTime,AuctionPrice,Auction001,Auction002,Auction003,Auction004,Auction005,Auction006 ");
            strSql.Append(" FROM tb_Auction a JOIN tb_user u ON a.userId=u.UserID");
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
            strSql.Append(" AID,userId,SaId,Atype,SaPrName,SaNumber,AuctionTime,AuctionPrice,Auction001,Auction002,Auction003,Auction004,Auction005,Auction006 ");
            strSql.Append(" FROM tb_Auction ");
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
            strSql.Append("select count(1) FROM tb_Auction ");
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
                strSql.Append("order by T.AID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_Auction T ");
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
            parameters[0].Value = "tb_Auction";
            parameters[1].Value = "AID";
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByUser(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" AID,userId,SaId,Atype,SaPrName,SaNumber,AuctionTime,AuctionPrice,Auction001,Auction002,Auction003,Auction004,Auction005,Auction006 ");
            strSql.Append(" FROM tb_Auction ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListWithSalesroom(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select s.SaID,SaPrId,s.SaPrName,SaPrConent,SaPrUsually,SaPrImage,SaPrice,s.SaNumber,SaTypeID,SaJinpaiSate,SuccessUserID,RegTime1,RegTime2,SaTargetPoint,SaWeiPoint,SaSanPoint,SaSanTargetPoint,SaWeiTargetPoint,SaState,SaBeginTime,SaTurnoverTime,SaClapTime,Sa001,Sa002,SaAddTime,SaPrName_en,SaPrConent_en,a.userId,u.UserCode,AuctionTime,AuctionPrice,Atype ");
            strSql.Append(" FROM tb_Salesroom s LEFT JOIN [tb_Auction] a ON a.SaId=s.SaID LEFT JOIN tb_user u ON u.UserID=a.userId");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}
