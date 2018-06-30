using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public class tb_TicketOrder
    {
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TicketOrder");
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
        public int Add(lgk.Model.tb_TicketOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_TicketOrder(");
            strSql.Append("OrdeID,UserID,AddDate,Status,PayPrice,Totaltax,TicketPrice,PolicyNum,PostPrice,InsurancePrice,CouponPrice,LinkMan,LinkMobile,Address,Needsheet,Aircode,DepCity,ArrCity,Flight,FlightModel,Cabin,DepDate,DepTime,ArrTime,YPrice,Discount,Depterminal,Arrterminal,Airportfee,Fuelfee,Staynum,AirName,DepcityName,ArrcityName)");
            strSql.Append(" values (");
            strSql.Append("@OrdeID,@UserID,@AddDate,@Status,@PayPrice,@Totaltax,@TicketPrice,@PolicyNum,@PostPrice,@InsurancePrice,@CouponPrice,@LinkMan,@LinkMobile,@Address,@Needsheet,@Aircode,@DepCity,@ArrCity,@Flight,@FlightModel,@Cabin,@DepDate,@DepTime,@ArrTime,@YPrice,@Discount,@Depterminal,@Arrterminal,@Airportfee,@Fuelfee,@Staynum,@AirName,@DepcityName,@ArrcityName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrdeID", SqlDbType.VarChar,100),
                    new SqlParameter("@UserID", SqlDbType.Int),
                    new SqlParameter("@AddDate", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@PayPrice", SqlDbType.Decimal),
                    new SqlParameter("@Totaltax", SqlDbType.Decimal),
                    new SqlParameter("@TicketPrice", SqlDbType.Decimal),
                    new SqlParameter("@PolicyNum", SqlDbType.VarChar),
                    new SqlParameter("@PostPrice", SqlDbType.Decimal),
                    new SqlParameter("@InsurancePrice", SqlDbType.Decimal),
                    new SqlParameter("@CouponPrice", SqlDbType.Decimal),
                    new SqlParameter("@LinkMan", SqlDbType.VarChar),
                    new SqlParameter("@LinkMobile", SqlDbType.VarChar),
                    new SqlParameter("@Address", SqlDbType.VarChar),
                    new SqlParameter("@Needsheet", SqlDbType.VarChar),
                    new SqlParameter("@Aircode", SqlDbType.VarChar),
                    new SqlParameter("@DepCity", SqlDbType.VarChar),
                    new SqlParameter("@ArrCity", SqlDbType.VarChar),
                    new SqlParameter("@Flight", SqlDbType.VarChar),
                    new SqlParameter("@FlightModel", SqlDbType.VarChar),
                    new SqlParameter("@Cabin", SqlDbType.VarChar),
                    new SqlParameter("@DepDate", SqlDbType.DateTime),
                    new SqlParameter("@DepTime", SqlDbType.DateTime),
                    new SqlParameter("@ArrTime", SqlDbType.DateTime),
                    new SqlParameter("@YPrice", SqlDbType.Decimal),
                    new SqlParameter("@Discount", SqlDbType.Decimal),
                    new SqlParameter("@Depterminal", SqlDbType.VarChar),
                    new SqlParameter("@Arrterminal", SqlDbType.VarChar),
                    new SqlParameter("@Airportfee", SqlDbType.Decimal),
                    new SqlParameter("@Fuelfee", SqlDbType.Decimal),
                    new SqlParameter("@Staynum", SqlDbType.Decimal),
                    new SqlParameter("@AirName", SqlDbType.VarChar),
                    new SqlParameter("@DepcityName", SqlDbType.VarChar),
                    new SqlParameter("@ArrcityName", SqlDbType.VarChar)
            };
            parameters[0].Value = model.OrdeID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.AddDate;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.PayPrice;
            parameters[5].Value = model.Totaltax;
            parameters[6].Value = model.TicketPrice;
            parameters[7].Value = model.PolicyNum;
            parameters[8].Value = model.PostPrice;
            parameters[9].Value = model.InsurancePrice;
            parameters[10].Value = model.CouponPrice;
            parameters[11].Value = model.LinkMan;
            parameters[12].Value = model.LinkMobile;
            parameters[13].Value = model.Address;
            parameters[14].Value = model.Needsheet;
            parameters[15].Value = model.Aircode;
            parameters[16].Value = model.DepCity;
            parameters[17].Value = model.ArrCity;
            parameters[18].Value = model.Flight;
            parameters[19].Value = model.FlightModel;
            parameters[20].Value = model.Cabin;
            parameters[21].Value = model.DepDate;
            parameters[22].Value = model.DepTime;
            parameters[23].Value = model.ArrTime;
            parameters[24].Value = model.YPrice;
            parameters[25].Value = model.Discount;
            parameters[26].Value = model.Depterminal;
            parameters[27].Value = model.Arrterminal;
            parameters[28].Value = model.Airportfee;
            parameters[29].Value = model.Fuelfee;
            parameters[30].Value = model.Staynum;
            parameters[31].Value = model.AirName;
            parameters[32].Value = model.DepcityName;
            parameters[33].Value = model.ArrcityName;
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
        public bool Update(lgk.Model.tb_TicketOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TicketOrder set ");
            strSql.Append("OrdeID=@OrdeID,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("AddDate=@AddDate,");
            strSql.Append("Status=@Status,");
            strSql.Append("PayPrice=@PayPrice,");
            strSql.Append("Totaltax=@Totaltax,");
            strSql.Append("TicketPrice=@TicketPrice,");
            strSql.Append("PolicyNum=@PolicyNum,");
            strSql.Append("PostPrice=@PostPrice,");
            strSql.Append("InsurancePrice=@InsurancePrice,");
            strSql.Append("CouponPrice=@CouponPrice,");
            strSql.Append("LinkMan=@LinkMan,");
            strSql.Append("LinkMobile=@LinkMobile,");
            strSql.Append("Address=@Address,");
            strSql.Append("Needsheet=@Needsheet,");
            strSql.Append("Aircode=@Aircode,");
            strSql.Append("DepCity=@DepCity,");
            strSql.Append("ArrCity=@ArrCity,");
            strSql.Append("Flight=@Flight,");
            strSql.Append("FlightModel=@FlightModel,");
            strSql.Append("Cabin=@Cabin,");
            strSql.Append("DepDate=@DepDate,");
            strSql.Append("DepTime=@DepTime,");
            strSql.Append("ArrTime=@ArrTime,");
            strSql.Append("YPrice=@YPrice,");
            strSql.Append("Discount=@Discount,");
            strSql.Append("Depterminal=@Depterminal,");
            strSql.Append("Arrterminal=@Arrterminal,");
            strSql.Append("Airportfee=@Airportfee,");
            strSql.Append("Fuelfee=@Fuelfee,");
            strSql.Append("Staynum=@Staynum,");
            strSql.Append("AirName=@AirName,");
            strSql.Append("DepcityName=@DepcityName,");
            strSql.Append("ArrcityName=@ArrcityName");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrdeID", SqlDbType.VarChar,100),
                    new SqlParameter("@UserID", SqlDbType.Int),
                    new SqlParameter("@AddDate", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.Int),
                    new SqlParameter("@PayPrice", SqlDbType.Decimal),
                    new SqlParameter("@Totaltax", SqlDbType.Decimal),
                    new SqlParameter("@TicketPrice", SqlDbType.Decimal),
                    new SqlParameter("@PolicyNum", SqlDbType.VarChar),
                    new SqlParameter("@PostPrice", SqlDbType.Decimal),
                    new SqlParameter("@InsurancePrice", SqlDbType.Decimal),
                    new SqlParameter("@CouponPrice", SqlDbType.Decimal),
                    new SqlParameter("@LinkMan", SqlDbType.VarChar),
                    new SqlParameter("@LinkMobile", SqlDbType.VarChar),
                    new SqlParameter("@Address", SqlDbType.VarChar),
                    new SqlParameter("@Needsheet", SqlDbType.VarChar),
                    new SqlParameter("@Aircode", SqlDbType.VarChar),
                    new SqlParameter("@DepCity", SqlDbType.VarChar),
                    new SqlParameter("@ArrCity", SqlDbType.VarChar),
                    new SqlParameter("@Flight", SqlDbType.VarChar),
                    new SqlParameter("@FlightModel", SqlDbType.VarChar),
                    new SqlParameter("@Cabin", SqlDbType.VarChar),
                    new SqlParameter("@DepDate", SqlDbType.DateTime),
                    new SqlParameter("@DepTime", SqlDbType.DateTime),
                    new SqlParameter("@ArrTime", SqlDbType.DateTime),
                    new SqlParameter("@YPrice", SqlDbType.Decimal),
                    new SqlParameter("@Discount", SqlDbType.Decimal),
                    new SqlParameter("@Depterminal", SqlDbType.VarChar),
                    new SqlParameter("@Arrterminal", SqlDbType.VarChar),
                    new SqlParameter("@Airportfee", SqlDbType.Decimal),
                    new SqlParameter("@Fuelfee", SqlDbType.Decimal),
                    new SqlParameter("@Staynum", SqlDbType.Decimal),
                    new SqlParameter("@AirName", SqlDbType.VarChar),
                    new SqlParameter("@DepcityName", SqlDbType.VarChar),
                    new SqlParameter("@ArrcityName", SqlDbType.VarChar),
                    new SqlParameter("@ID", SqlDbType.Int)
            };
            parameters[0].Value = model.OrdeID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.AddDate;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.PayPrice;
            parameters[5].Value = model.Totaltax;
            parameters[6].Value = model.TicketPrice;
            parameters[7].Value = model.PolicyNum;
            parameters[8].Value = model.PostPrice;
            parameters[9].Value = model.InsurancePrice;
            parameters[10].Value = model.CouponPrice;
            parameters[11].Value = model.LinkMan;
            parameters[12].Value = model.LinkMobile;
            parameters[13].Value = model.Address;
            parameters[14].Value = model.Needsheet;
            parameters[15].Value = model.Aircode;
            parameters[16].Value = model.DepCity;
            parameters[17].Value = model.ArrCity;
            parameters[18].Value = model.Flight;
            parameters[19].Value = model.FlightModel;
            parameters[20].Value = model.Cabin;
            parameters[21].Value = model.DepDate;
            parameters[22].Value = model.DepTime;
            parameters[23].Value = model.ArrTime;
            parameters[24].Value = model.YPrice;
            parameters[25].Value = model.Discount;
            parameters[26].Value = model.Depterminal;
            parameters[27].Value = model.Arrterminal;
            parameters[28].Value = model.Airportfee;
            parameters[29].Value = model.Fuelfee;
            parameters[30].Value = model.Staynum;
            parameters[31].Value = model.AirName;
            parameters[32].Value = model.DepcityName;
            parameters[33].Value = model.ArrcityName;
            parameters[34].Value = model.ID;
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
            strSql.Append("delete from tb_TicketOrder ");
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
        /// <summary>
        /// 更新订单状态
        /// </summary>
        public bool UpdateStatus(int status,int paystatus,string orderno)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TicketOrder set Status=@Status,PayStatus=@PayStatus ");
            strSql.Append(" where OrdeID=@OrdeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@PayStatus", SqlDbType.Int,4),
                    new SqlParameter("@OrdeID", SqlDbType.VarChar)};
            parameters[0].Value = status;
            parameters[1].Value = paystatus;
            parameters[2].Value = orderno;
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
        public lgk.Model.tb_TicketOrder GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tb_TicketOrder ");
            strSql.Append(" where " + where);

            lgk.Model.tb_TicketOrder model = new lgk.Model.tb_TicketOrder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrdeID"] != null && ds.Tables[0].Rows[0]["OrdeID"].ToString() != "")
                {
                    model.OrdeID = ds.Tables[0].Rows[0]["OrdeID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"] != null && ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayPrice"] != null && ds.Tables[0].Rows[0]["PayPrice"].ToString() != "")
                {
                    model.PayPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["PayPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Totaltax"] != null && ds.Tables[0].Rows[0]["Totaltax"].ToString() != "")
                {
                    model.Totaltax = Convert.ToDecimal(ds.Tables[0].Rows[0]["Totaltax"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TicketPrice"] != null && ds.Tables[0].Rows[0]["TicketPrice"].ToString() != "")
                {
                    model.TicketPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["TicketPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PolicyNum"] != null && ds.Tables[0].Rows[0]["PolicyNum"].ToString() != "")
                {
                    model.PolicyNum = ds.Tables[0].Rows[0]["PolicyNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PostPrice"] != null && ds.Tables[0].Rows[0]["PostPrice"].ToString() != "")
                {
                    model.PostPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["PostPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InsurancePrice"] != null && ds.Tables[0].Rows[0]["InsurancePrice"].ToString() != "")
                {
                    model.InsurancePrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["InsurancePrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CouponPrice"] != null && ds.Tables[0].Rows[0]["CouponPrice"].ToString() != "")
                {
                    model.CouponPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["CouponPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LinkMan"] != null && ds.Tables[0].Rows[0]["LinkMan"].ToString() != "")
                {
                    model.LinkMan = ds.Tables[0].Rows[0]["LinkMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LinkMobile"] != null && ds.Tables[0].Rows[0]["LinkMobile"].ToString() != "")
                {
                    model.LinkMobile = ds.Tables[0].Rows[0]["LinkMobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Needsheet"] != null && ds.Tables[0].Rows[0]["Needsheet"].ToString() != "")
                {
                    model.Needsheet = ds.Tables[0].Rows[0]["Needsheet"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Aircode"] != null && ds.Tables[0].Rows[0]["Aircode"].ToString() != "")
                {
                    model.Aircode = ds.Tables[0].Rows[0]["Aircode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DepCity"] != null && ds.Tables[0].Rows[0]["DepCity"].ToString() != "")
                {
                    model.DepCity = ds.Tables[0].Rows[0]["DepCity"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ArrCity"] != null && ds.Tables[0].Rows[0]["ArrCity"].ToString() != "")
                {
                    model.ArrCity = ds.Tables[0].Rows[0]["ArrCity"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Flight"] != null && ds.Tables[0].Rows[0]["Flight"].ToString() != "")
                {
                    model.Flight = ds.Tables[0].Rows[0]["Flight"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FlightModel"] != null && ds.Tables[0].Rows[0]["FlightModel"].ToString() != "")
                {
                    model.FlightModel = ds.Tables[0].Rows[0]["FlightModel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Cabin"] != null && ds.Tables[0].Rows[0]["Cabin"].ToString() != "")
                {
                    model.Cabin = ds.Tables[0].Rows[0]["Cabin"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DepDate"] != null && ds.Tables[0].Rows[0]["DepDate"].ToString() != "")
                {
                    model.DepDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["DepDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DepTime"] != null && ds.Tables[0].Rows[0]["DepTime"].ToString() != "")
                {
                    model.DepTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["DepTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ArrTime"] != null && ds.Tables[0].Rows[0]["LinkMobile"].ToString() != "")
                {
                    model.ArrTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["ArrTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["YPrice"] != null && ds.Tables[0].Rows[0]["YPrice"].ToString() != "")
                {
                    model.YPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["YPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Discount"] != null && ds.Tables[0].Rows[0]["Discount"].ToString() != "")
                {
                    model.Discount = Convert.ToDecimal(ds.Tables[0].Rows[0]["Discount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Depterminal"] != null && ds.Tables[0].Rows[0]["Depterminal"].ToString() != "")
                {
                    model.Depterminal = ds.Tables[0].Rows[0]["Depterminal"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Arrterminal"] != null && ds.Tables[0].Rows[0]["Arrterminal"].ToString() != "")
                {
                    model.Arrterminal = ds.Tables[0].Rows[0]["Arrterminal"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Airportfee"] != null && ds.Tables[0].Rows[0]["Airportfee"].ToString() != "")
                {
                    model.Airportfee = Convert.ToDecimal(ds.Tables[0].Rows[0]["Airportfee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Fuelfee"] != null && ds.Tables[0].Rows[0]["Fuelfee"].ToString() != "")
                {
                    model.Fuelfee = Convert.ToDecimal(ds.Tables[0].Rows[0]["Fuelfee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Staynum"] != null && ds.Tables[0].Rows[0]["Staynum"].ToString() != "")
                {
                    model.Staynum = Convert.ToDecimal(ds.Tables[0].Rows[0]["Staynum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AirName"] != null && ds.Tables[0].Rows[0]["AirName"].ToString() != "")
                {
                    model.AirName = ds.Tables[0].Rows[0]["AirName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DepcityName"] != null && ds.Tables[0].Rows[0]["DepcityName"].ToString() != "")
                {
                    model.DepcityName = ds.Tables[0].Rows[0]["DepcityName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ArrcityName"] != null && ds.Tables[0].Rows[0]["ArrcityName"].ToString() != "")
                {
                    model.ArrcityName = ds.Tables[0].Rows[0]["ArrcityName"].ToString();
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
            strSql.Append("select (select UserCode from tb_user u where u.UserID=t.UserID ) as UserCode,* from tb_TicketOrder t");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by AddDate desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
