using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public class tb_TrainTicketsOrder
    {
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TrainTicketsOrder");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_TrainTicketsOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_TrainTicketsOrder(");
            strSql.Append("OrderCode,ISAcceptStanding,FromStationCode,ToStationCode,CheCi,TrainDate,UserID,OrderID,State,FromStationName,ToStationName,FromStationDate,ToStationDate,OrderPrice,LinkMan,LinkPhone)");
            strSql.Append(" values (");
            strSql.Append("@OrderCode,@ISAcceptStanding,@FromStationCode,@ToStationCode,@CheCi,@TrainDate,@UserID,@OrderID,@State,@FromStationName,@ToStationName,@FromStationDate,@ToStationDate,@OrderPrice,@LinkMan,@LinkPhone)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderCode", SqlDbType.VarChar,100),
                    new SqlParameter("@ISAcceptStanding", SqlDbType.VarChar,100),
                    new SqlParameter("@FromStationCode", SqlDbType.VarChar,100),
                    new SqlParameter("@ToStationCode", SqlDbType.VarChar,100),
                    new SqlParameter("@CheCi", SqlDbType.VarChar,100),
                    new SqlParameter("@TrainDate", SqlDbType.DateTime),
                    new SqlParameter("@UserID", SqlDbType.Int),
                    new SqlParameter("@OrderID", SqlDbType.VarChar),
                    new SqlParameter("@State", SqlDbType.Int),
                    new SqlParameter("@FromStationName", SqlDbType.VarChar),
                    new SqlParameter("@ToStationName", SqlDbType.VarChar),
                    new SqlParameter("@FromStationDate", SqlDbType.VarChar),
                    new SqlParameter("@ToStationDate", SqlDbType.VarChar),
                    new SqlParameter("@OrderPrice", SqlDbType.Decimal),
                    new SqlParameter("@LinkMan", SqlDbType.VarChar),
                    new SqlParameter("@LinkPhone", SqlDbType.VarChar)
            };
            parameters[0].Value = model.OrderCode;
            parameters[1].Value = model.ISAcceptStanding;
            parameters[2].Value = model.FromStationCode;
            parameters[3].Value = model.ToStationCode;
            parameters[4].Value = model.CheCi;
            parameters[5].Value = model.TrainDate;
            parameters[6].Value = model.UserID;
            parameters[7].Value = model.OrderID;
            parameters[8].Value = model.State;
            parameters[9].Value = model.FromStationName;
            parameters[10].Value = model.ToStationName;
            parameters[11].Value = model.FromStationDate;
            parameters[12].Value = model.ToStationDate;
            parameters[13].Value = model.OrderPrice;
            parameters[14].Value = model.LinkMan;
            parameters[15].Value = model.LinkPhone;
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
        public bool Update(lgk.Model.tb_TrainTicketsOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TrainTicketsOrder set ");
            strSql.Append("OrderCode=@OrderCode,");
            strSql.Append("ISAcceptStanding=@ISAcceptStanding,");
            strSql.Append("FromStationCode=@FromStationCode,");
            strSql.Append("ToStationCode=@ToStationCode,");
            strSql.Append("CheCi=@CheCi,");
            strSql.Append("TrainDate=@TrainDate,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("State=@State,");
            strSql.Append("FromStationName=@FromStationName,");
            strSql.Append("ToStationName=@ToStationName,");
            strSql.Append("FromStationDate=@FromStationDate,");
            strSql.Append("ToStationDate=@ToStationDate,");
            strSql.Append("OrderPrice=@OrderPrice,");
            strSql.Append("LinkMan=@LinkMan,");
            strSql.Append("LinkPhone=@LinkPhone");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderCode", SqlDbType.VarChar,100),
                    new SqlParameter("@ISAcceptStanding", SqlDbType.VarChar,100),
                    new SqlParameter("@FromStationCode", SqlDbType.VarChar,100),
                    new SqlParameter("@ToStationCode", SqlDbType.VarChar,100),
                    new SqlParameter("@CheCi", SqlDbType.VarChar,100),
                    new SqlParameter("@TrainDate", SqlDbType.DateTime),
                    new SqlParameter("@OrderID", SqlDbType.VarChar),
                    new SqlParameter("@State", SqlDbType.Int),
                    new SqlParameter("@FromStationName", SqlDbType.VarChar),
                    new SqlParameter("@ToStationName", SqlDbType.VarChar),
                    new SqlParameter("@FromStationDate", SqlDbType.VarChar),
                    new SqlParameter("@ToStationDate", SqlDbType.VarChar),
                    new SqlParameter("@OrderPrice", SqlDbType.Decimal),
                    new SqlParameter("@LinkMan", SqlDbType.VarChar),
                    new SqlParameter("@LinkPhone", SqlDbType.VarChar),
                    new SqlParameter("@ID", SqlDbType.Int)
            };
            parameters[0].Value = model.OrderCode;
            parameters[1].Value = model.ISAcceptStanding;
            parameters[2].Value = model.FromStationCode;
            parameters[3].Value = model.ToStationCode;
            parameters[4].Value = model.CheCi;
            parameters[5].Value = model.TrainDate;
            parameters[6].Value = model.OrderID;
            parameters[7].Value = model.State;
            parameters[8].Value = model.FromStationName;
            parameters[9].Value = model.ToStationName;
            parameters[10].Value = model.FromStationDate;
            parameters[11].Value = model.ToStationDate;
            parameters[12].Value = model.OrderPrice;
            parameters[13].Value = model.LinkMan;
            parameters[14].Value = model.LinkPhone;
            parameters[15].Value = model.ID;
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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TrainTicketsOrder ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)};
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
        public lgk.Model.tb_TrainTicketsOrder GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,OrderCode,ISAcceptStanding,FromStationCode,ToStationCode,CheCi,TrainDate,UserID,OrderID,State,FromStationName,ToStationName,FromStationDate,ToStationDate,OrderPrice,LinkMan,LinkPhone from tb_TrainTicketsOrder t ");
            strSql.Append(" where " + where);

            lgk.Model.tb_TrainTicketsOrder model = new lgk.Model.tb_TrainTicketsOrder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderCode"] != null && ds.Tables[0].Rows[0]["OrderCode"].ToString() != "")
                {
                    model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ISAcceptStanding"] != null && ds.Tables[0].Rows[0]["ISAcceptStanding"].ToString() != "")
                {
                    model.ISAcceptStanding = ds.Tables[0].Rows[0]["ISAcceptStanding"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FromStationCode"] != null && ds.Tables[0].Rows[0]["FromStationCode"].ToString() != "")
                {
                    model.FromStationCode = ds.Tables[0].Rows[0]["FromStationCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ToStationCode"] != null && ds.Tables[0].Rows[0]["ToStationCode"].ToString() != "")
                {
                    model.ToStationCode = ds.Tables[0].Rows[0]["ToStationCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CheCi"] != null && ds.Tables[0].Rows[0]["CheCi"].ToString() != "")
                {
                    model.CheCi = ds.Tables[0].Rows[0]["CheCi"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TrainDate"] != null && ds.Tables[0].Rows[0]["TrainDate"].ToString() != "")
                {
                    model.TrainDate = DateTime.Parse(ds.Tables[0].Rows[0]["TrainDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"] != null && ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = ds.Tables[0].Rows[0]["OrderID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = Convert.ToInt32(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FromStationName"] != null && ds.Tables[0].Rows[0]["FromStationName"].ToString() != "")
                {
                    model.FromStationName = ds.Tables[0].Rows[0]["FromStationName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ToStationName"] != null && ds.Tables[0].Rows[0]["ToStationName"].ToString() != "")
                {
                    model.ToStationName = ds.Tables[0].Rows[0]["ToStationName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FromStationDate"] != null && ds.Tables[0].Rows[0]["FromStationDate"].ToString() != "")
                {
                    model.FromStationDate = ds.Tables[0].Rows[0]["FromStationDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ToStationDate"] != null && ds.Tables[0].Rows[0]["ToStationDate"].ToString() != "")
                {
                    model.ToStationDate = ds.Tables[0].Rows[0]["ToStationDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderPrice"] != null && ds.Tables[0].Rows[0]["OrderPrice"].ToString() != "")
                {
                    model.OrderPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["OrderPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LinkMan"] != null && ds.Tables[0].Rows[0]["LinkMan"].ToString() != "")
                {
                    model.LinkMan = ds.Tables[0].Rows[0]["LinkMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LinkPhone"] != null && ds.Tables[0].Rows[0]["LinkPhone"].ToString() != "")
                {
                    model.LinkPhone = ds.Tables[0].Rows[0]["LinkPhone"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,OrderCode,ISAcceptStanding,FromStationCode,ToStationCode,CheCi,TrainDate,UserID,(select UserCode from tb_user u where u.UserID=t.UserID ) as UserCode,OrderID,State,FromStationName,ToStationName,FromStationDate,ToStationDate,OrderPrice,LinkMan,LinkPhone  from tb_TrainTicketsOrder t");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by TrainDate desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
