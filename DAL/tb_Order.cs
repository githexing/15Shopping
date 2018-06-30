using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_Order
    /// </summary>
    public partial class tb_Order
    {
        public tb_Order()
        { }

        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Order");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.BigInt)
            };
            parameters[0].Value = OrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Order(");
            strSql.Append("UserID,OrderCode,UserAddr,OrderSum,OrderTotal,PVTotal,OrderDate,IsSend,PayMethod,OrderType,Order1,Order2,Order3,Order4,Order5,Order6,Order7,TypeID,PareTopChild,BaodanOrder,IsDel,SendDate)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@OrderCode,@UserAddr,@OrderSum,@OrderTotal,@PVTotal,@OrderDate,@IsSend,@PayMethod,@OrderType,@Order1,@Order2,@Order3,@Order4,@Order5,@Order6,@Order7,@TypeID,@PareTopChild,@BaodanOrder,@IsDel,@SendDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
                    new SqlParameter("@UserAddr", SqlDbType.VarChar,100),
                    new SqlParameter("@OrderSum", SqlDbType.Int,4),
                    new SqlParameter("@OrderTotal", SqlDbType.Decimal,9),
                    new SqlParameter("@PVTotal", SqlDbType.Decimal,9),
                    new SqlParameter("@OrderDate", SqlDbType.DateTime),
                    new SqlParameter("@IsSend", SqlDbType.Int,4),
                    new SqlParameter("@PayMethod", SqlDbType.Int,4),
                    new SqlParameter("@OrderType", SqlDbType.Int,4),
                    new SqlParameter("@Order1", SqlDbType.Decimal,9),
                    new SqlParameter("@Order2", SqlDbType.Decimal,9),
                    new SqlParameter("@Order3", SqlDbType.VarChar,100),
                    new SqlParameter("@Order4", SqlDbType.VarChar,100),
                    new SqlParameter("@Order5", SqlDbType.VarChar,100),
                    new SqlParameter("@Order6", SqlDbType.VarChar,100),
                    new SqlParameter("@Order7", SqlDbType.VarChar,100),
                    new SqlParameter("@TypeID", SqlDbType.Int,4),
                    new SqlParameter("@PareTopChild", SqlDbType.VarChar,100),
                    new SqlParameter("@BaodanOrder", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Int,4),
                    new SqlParameter("@SendDate", SqlDbType.DateTime)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.UserAddr;
            parameters[3].Value = model.OrderSum;
            parameters[4].Value = model.OrderTotal;
            parameters[5].Value = model.PVTotal;
            parameters[6].Value = model.OrderDate;
            parameters[7].Value = model.IsSend;
            parameters[8].Value = model.PayMethod;
            parameters[9].Value = model.OrderType;
            parameters[10].Value = model.Order1;
            parameters[11].Value = model.Order2;
            parameters[12].Value = model.Order3;
            parameters[13].Value = model.Order4;
            parameters[14].Value = model.Order5;
            parameters[15].Value = model.Order6;
            parameters[16].Value = model.Order7;
            parameters[17].Value = model.TypeID;
            parameters[18].Value = model.PareTopChild;
            parameters[19].Value = model.BaodanOrder;
            parameters[20].Value = model.IsDel;
            parameters[21].Value = model.SendDate;

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
        public bool Update(lgk.Model.tb_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Order set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("OrderCode=@OrderCode,");
            strSql.Append("UserAddr=@UserAddr,");
            strSql.Append("OrderSum=@OrderSum,");
            strSql.Append("OrderTotal=@OrderTotal,");
            strSql.Append("PVTotal=@PVTotal,");
            strSql.Append("OrderDate=@OrderDate,");
            strSql.Append("IsSend=@IsSend,");
            strSql.Append("PayMethod=@PayMethod,");
            strSql.Append("OrderType=@OrderType,");
            strSql.Append("Order1=@Order1,");
            strSql.Append("Order2=@Order2,");
            strSql.Append("Order3=@Order3,");
            strSql.Append("Order4=@Order4,");
            strSql.Append("Order5=@Order5,");
            strSql.Append("Order6=@Order6,");
            strSql.Append("Order7=@Order7,");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("PareTopChild=@PareTopChild,");
            strSql.Append("BaodanOrder=@BaodanOrder,");
            strSql.Append("IsDel=@IsDel,");
            strSql.Append("SendDate=@SendDate");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
                    new SqlParameter("@UserAddr", SqlDbType.VarChar,100),
                    new SqlParameter("@OrderSum", SqlDbType.Int,4),
                    new SqlParameter("@OrderTotal", SqlDbType.Decimal,9),
                    new SqlParameter("@PVTotal", SqlDbType.Decimal,9),
                    new SqlParameter("@OrderDate", SqlDbType.DateTime),
                    new SqlParameter("@IsSend", SqlDbType.Int,4),
                    new SqlParameter("@PayMethod", SqlDbType.Int,4),
                    new SqlParameter("@OrderType", SqlDbType.Int,4),
                    new SqlParameter("@Order1", SqlDbType.Decimal,9),
                    new SqlParameter("@Order2", SqlDbType.Decimal,9),
                    new SqlParameter("@Order3", SqlDbType.VarChar,100),
                    new SqlParameter("@Order4", SqlDbType.VarChar,100),
                    new SqlParameter("@Order5", SqlDbType.VarChar,100),
                    new SqlParameter("@Order6", SqlDbType.VarChar,100),
                    new SqlParameter("@Order7", SqlDbType.VarChar,100),
                    new SqlParameter("@TypeID", SqlDbType.Int,4),
                    new SqlParameter("@PareTopChild", SqlDbType.VarChar,100),
                    new SqlParameter("@BaodanOrder", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Int,4),
                    new SqlParameter("@SendDate", SqlDbType.DateTime),
                    new SqlParameter("@OrderID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.UserAddr;
            parameters[3].Value = model.OrderSum;
            parameters[4].Value = model.OrderTotal;
            parameters[5].Value = model.PVTotal;
            parameters[6].Value = model.OrderDate;
            parameters[7].Value = model.IsSend;
            parameters[8].Value = model.PayMethod;
            parameters[9].Value = model.OrderType;
            parameters[10].Value = model.Order1;
            parameters[11].Value = model.Order2;
            parameters[12].Value = model.Order3;
            parameters[13].Value = model.Order4;
            parameters[14].Value = model.Order5;
            parameters[15].Value = model.Order6;
            parameters[16].Value = model.Order7;
            parameters[17].Value = model.TypeID;
            parameters[18].Value = model.PareTopChild;
            parameters[19].Value = model.BaodanOrder;
            parameters[20].Value = model.IsDel;
            parameters[21].Value = model.SendDate;
            parameters[22].Value = model.OrderID;

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
        public bool Delete(long OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Order ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.BigInt,8)};
            parameters[0].Value = OrderID;

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
        public bool Delete(string strOrderCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Order ");
            strSql.Append(" where OrderCode=@OrderCode");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderCode", SqlDbType.VarChar,50)};
            parameters[0].Value = strOrderCode;

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
        public bool DeleteList(string OrderIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Order ");
            strSql.Append(" where OrderID in (" + OrderIDlist + ") ");
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
		public lgk.Model.tb_Order GetModel(long OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderID,UserID,OrderCode,UserAddr,OrderSum,OrderTotal,PVTotal,OrderDate,IsSend,PayMethod,OrderType,Order1,Order2,Order3,Order4,Order5,Order6,Order7,TypeID,PareTopChild,BaodanOrder,IsDel,SendDate from tb_Order ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.BigInt)
            };
            parameters[0].Value = OrderID;

            lgk.Model.tb_Order model = new lgk.Model.tb_Order();
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
        public lgk.Model.tb_Order DataRowToModel(DataRow row)
        {
            lgk.Model.tb_Order model = new lgk.Model.tb_Order();
            if (row != null)
            {
                if (row["OrderID"] != null && row["OrderID"].ToString() != "")
                {
                    model.OrderID = long.Parse(row["OrderID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(row["UserID"].ToString());
                }
                if (row["OrderCode"] != null)
                {
                    model.OrderCode = row["OrderCode"].ToString();
                }
                if (row["UserAddr"] != null)
                {
                    model.UserAddr = row["UserAddr"].ToString();
                }
                if (row["OrderSum"] != null && row["OrderSum"].ToString() != "")
                {
                    model.OrderSum = int.Parse(row["OrderSum"].ToString());
                }
                if (row["OrderTotal"] != null && row["OrderTotal"].ToString() != "")
                {
                    model.OrderTotal = decimal.Parse(row["OrderTotal"].ToString());
                }
                if (row["PVTotal"] != null && row["PVTotal"].ToString() != "")
                {
                    model.PVTotal = decimal.Parse(row["PVTotal"].ToString());
                }
                if (row["OrderDate"] != null && row["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(row["OrderDate"].ToString());
                }
                if (row["IsSend"] != null && row["IsSend"].ToString() != "")
                {
                    model.IsSend = int.Parse(row["IsSend"].ToString());
                }
                if (row["PayMethod"] != null && row["PayMethod"].ToString() != "")
                {
                    model.PayMethod = int.Parse(row["PayMethod"].ToString());
                }
                if (row["OrderType"] != null && row["OrderType"].ToString() != "")
                {
                    model.OrderType = int.Parse(row["OrderType"].ToString());
                }
                if (row["Order1"] != null && row["Order1"].ToString() != "")
                {
                    model.Order1 = decimal.Parse(row["Order1"].ToString());
                }
                if (row["Order2"] != null && row["Order2"].ToString() != "")
                {
                    model.Order2 = decimal.Parse(row["Order2"].ToString());
                }
                if (row["Order3"] != null)
                {
                    model.Order3 = row["Order3"].ToString();
                }
                if (row["Order4"] != null)
                {
                    model.Order4 = row["Order4"].ToString();
                }
                if (row["Order5"] != null)
                {
                    model.Order5 = row["Order5"].ToString();
                }
                if (row["Order6"] != null)
                {
                    model.Order6 = row["Order6"].ToString();
                }
                if (row["Order7"] != null)
                {
                    model.Order7 = row["Order7"].ToString();
                }
                if (row["TypeID"] != null && row["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(row["TypeID"].ToString());
                }
                if (row["PareTopChild"] != null)
                {
                    model.PareTopChild = row["PareTopChild"].ToString();
                }
                if (row["BaodanOrder"] != null && row["BaodanOrder"].ToString() != "")
                {
                    model.BaodanOrder = int.Parse(row["BaodanOrder"].ToString());
                }
                if (row["IsDel"] != null && row["IsDel"].ToString() != "")
                {
                    model.IsDel = int.Parse(row["IsDel"].ToString());
                }
                if (row["SendDate"] != null && row["SendDate"].ToString() != "")
                {
                    model.SendDate = DateTime.Parse(row["SendDate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Order GetModelByCode(string strOrderCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from tb_Order ");
            strSql.Append(" where OrderCode=@OrderCode");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderCode", SqlDbType.VarChar,50)};
            parameters[0].Value = strOrderCode;

            lgk.Model.tb_Order model = new lgk.Model.tb_Order();
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM tb_Order ");
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
            strSql.Append(" * FROM tb_Order ");
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
            strSql.Append("select count(1) FROM tb_Order ");
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
                strSql.Append("order by T.OrderID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_Order T ");
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
            parameters[0].Value = "tb_Order";
            parameters[1].Value = "OrderID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Order GetModel(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from tb_Order ");
            if (strwhere != null)
            {
                strSql.Append(" where " + strwhere);
            }

            lgk.Model.tb_Order model = new lgk.Model.tb_Order();
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
    }
}

