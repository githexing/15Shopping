using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public class tb_OrderCallBack
    {
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_OrderCallBack");
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
        public int Add(lgk.Model.tb_OrderCallBack model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_OrderCallBack(");
            strSql.Append("OrderID,CheCi,FromStationName,FromStationCode,ToStationName,ToStationCode,TrainDate,UserOrderid,Orderamount,Ordernumber,Status,Msg,RefundMoney,Passengers)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@CheCi,@FromStationName,@FromStationCode,@ToStationName,@ToStationCode,@TrainDate,@UserOrderid,@Orderamount,@Ordernumber,@Status,@Msg,@RefundMoney,@Passengers)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.VarChar,100),
                    new SqlParameter("@CheCi", SqlDbType.VarChar,100),
                    new SqlParameter("@FromStationName", SqlDbType.VarChar,100),
                    new SqlParameter("@FromStationCode", SqlDbType.VarChar,100),
                    new SqlParameter("@ToStationName", SqlDbType.VarChar,100),
                    new SqlParameter("@ToStationCode", SqlDbType.VarChar),
                    new SqlParameter("@TrainDate", SqlDbType.DateTime),
                    new SqlParameter("@UserOrderid", SqlDbType.VarChar),
                    new SqlParameter("@Orderamount", SqlDbType.Decimal),
                    new SqlParameter("@Ordernumber", SqlDbType.VarChar),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@Msg", SqlDbType.VarChar),
                    new SqlParameter("@RefundMoney", SqlDbType.VarChar),
                    new SqlParameter("@Passengers", SqlDbType.VarChar)
            };
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.CheCi;
            parameters[2].Value = model.FromStationName;
            parameters[3].Value = model.FromStationCode;
            parameters[4].Value = model.ToStationName;
            parameters[5].Value = model.ToStationCode;
            parameters[6].Value = model.TrainDate;
            parameters[7].Value = model.UserOrderid;
            parameters[8].Value = model.Orderamount;
            parameters[9].Value = model.Ordernumber;
            parameters[10].Value = model.Status;
            parameters[11].Value = model.Msg;
            parameters[12].Value = model.RefundMoney;
            parameters[13].Value = model.Passengers;
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
        public bool Update(lgk.Model.tb_OrderCallBack model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_OrderCallBack set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("CheCi=@CheCi,");
            strSql.Append("FromStationName=@FromStationName,");
            strSql.Append("FromStationCode=@FromStationCode,");
            strSql.Append("ToStationName=@ToStationName,");
            strSql.Append("ToStationCode=@ToStationCode,");
            strSql.Append("TrainDate=@TrainDate,");
            strSql.Append("UserOrderid=@UserOrderid,");
            strSql.Append("Orderamount=@Orderamount,");
            strSql.Append("Ordernumber=@Ordernumber,");
            strSql.Append("Status=@Status,");
            strSql.Append("Msg=@Msg,");
            strSql.Append("RefundMoney=@RefundMoney,");
            strSql.Append("Passengers=@Passengers");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.VarChar,100),
                    new SqlParameter("@CheCi", SqlDbType.VarChar,100),
                    new SqlParameter("@FromStationName", SqlDbType.VarChar,100),
                    new SqlParameter("@FromStationCode", SqlDbType.VarChar,100),
                    new SqlParameter("@ToStationName", SqlDbType.VarChar,100),
                    new SqlParameter("@ToStationCode", SqlDbType.VarChar),
                    new SqlParameter("@TrainDate", SqlDbType.DateTime),
                    new SqlParameter("@UserOrderid", SqlDbType.VarChar),
                    new SqlParameter("@Orderamount", SqlDbType.Decimal),
                    new SqlParameter("@Ordernumber", SqlDbType.VarChar),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@Msg", SqlDbType.VarChar),
                    new SqlParameter("@RefundMoney", SqlDbType.Decimal),
                    new SqlParameter("@Passengers", SqlDbType.VarChar),
                    new SqlParameter("@ID", SqlDbType.Int )
            };
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.CheCi;
            parameters[2].Value = model.FromStationName;
            parameters[3].Value = model.FromStationCode;
            parameters[4].Value = model.ToStationName;
            parameters[5].Value = model.ToStationCode;
            parameters[6].Value = model.TrainDate;
            parameters[7].Value = model.UserOrderid;
            parameters[8].Value = model.Orderamount;
            parameters[9].Value = model.Ordernumber;
            parameters[10].Value = model.Status;
            parameters[11].Value = model.Msg;
            parameters[12].Value = model.RefundMoney;
            parameters[13].Value = model.Passengers;
            parameters[14].Value = model.ID;
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
            strSql.Append("delete from tb_OrderCallBack ");
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
        public lgk.Model.tb_OrderCallBack GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tb_OrderCallBack ");
            strSql.Append(" where " + where);

            lgk.Model.tb_OrderCallBack model = new lgk.Model.tb_OrderCallBack();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"] != null && ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = ds.Tables[0].Rows[0]["OrderID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CheCi"] != null && ds.Tables[0].Rows[0]["CheCi"].ToString() != "")
                {
                    model.CheCi = ds.Tables[0].Rows[0]["CheCi"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FromStationName"] != null && ds.Tables[0].Rows[0]["FromStationName"].ToString() != "")
                {
                    model.FromStationName = ds.Tables[0].Rows[0]["FromStationName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FromStationCode"] != null && ds.Tables[0].Rows[0]["FromStationCode"].ToString() != "")
                {
                    model.FromStationCode = ds.Tables[0].Rows[0]["FromStationCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ToStationName"] != null && ds.Tables[0].Rows[0]["ToStationName"].ToString() != "")
                {
                    model.ToStationName = ds.Tables[0].Rows[0]["ToStationName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ToStationCode"] != null && ds.Tables[0].Rows[0]["ToStationCode"].ToString() != "")
                {
                    model.ToStationCode = ds.Tables[0].Rows[0]["ToStationCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TrainDate"] != null && ds.Tables[0].Rows[0]["TrainDate"].ToString() != "")
                {
                    model.TrainDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["TrainDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserOrderid"] != null && ds.Tables[0].Rows[0]["UserOrderid"].ToString() != "")
                {
                    model.UserOrderid = ds.Tables[0].Rows[0]["UserOrderid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Orderamount"] != null && ds.Tables[0].Rows[0]["Orderamount"].ToString() != "")
                {
                    model.Orderamount = Convert.ToDecimal(ds.Tables[0].Rows[0]["Orderamount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Ordernumber"] != null && ds.Tables[0].Rows[0]["Ordernumber"].ToString() != "")
                {
                    model.Ordernumber = ds.Tables[0].Rows[0]["Ordernumber"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Msg"] != null && ds.Tables[0].Rows[0]["Msg"].ToString() != "")
                {
                    model.Msg = ds.Tables[0].Rows[0]["Msg"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RefundMoney"] != null && ds.Tables[0].Rows[0]["RefundMoney"].ToString() != "")
                {
                    model.RefundMoney = ds.Tables[0].Rows[0]["RefundMoney"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Passengers"] != null && ds.Tables[0].Rows[0]["Passengers"].ToString() != "")
                {
                    model.Passengers = ds.Tables[0].Rows[0]["Passengers"].ToString();
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
            strSql.Append("select * from tb_OrderCallBack");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
