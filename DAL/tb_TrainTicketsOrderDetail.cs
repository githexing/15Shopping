using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public class tb_TrainTicketsOrderDetail
    {
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TrainTicketsOrderDetail");
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
        public int Add(lgk.Model.tb_TrainTicketsOrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_TrainTicketsOrderDetail(");
            strSql.Append("OrderID,PassengerseName,PiaoType,PiaotypeName,Passporttypeseid,PassporttypeseidName,PassportseNO,Price,ZWCode,ZWName,InsuranceID,Cxin,State,PassengerId,Disacount)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@PassengerseName,@PiaoType,@PiaotypeName,@Passporttypeseid,@PassporttypeseidName,@PassportseNO,@Price,@ZWCode,@ZWName,@InsuranceID,@Cxin,@State,@PassengerId,@Disacount)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.Int),
                    new SqlParameter("@PassengerseName", SqlDbType.VarChar,100),
                    new SqlParameter("@PiaoType", SqlDbType.Int),
                    new SqlParameter("@PiaotypeName", SqlDbType.VarChar,100),
                    new SqlParameter("@Passporttypeseid", SqlDbType.Int),
                    new SqlParameter("@PassporttypeseidName", SqlDbType.VarChar,100),
                    new SqlParameter("@PassportseNO", SqlDbType.VarChar,100),
                    new SqlParameter("@Price", SqlDbType.Decimal),
                    new SqlParameter("@ZWCode", SqlDbType.VarChar,100),
                    new SqlParameter("@ZWName", SqlDbType.VarChar,100),
                    new SqlParameter("@InsuranceID", SqlDbType.Int),
                    new SqlParameter("@Cxin", SqlDbType.VarChar,100),
                    new SqlParameter("@State", SqlDbType.Int),
                    new SqlParameter("@PassengerId", SqlDbType.Int),
                    new SqlParameter("@Disacount", SqlDbType.Decimal)
            };
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.PassengerseName;
            parameters[2].Value = model.PiaoType;
            parameters[3].Value = model.PiaotypeName;
            parameters[4].Value = model.Passporttypeseid;
            parameters[5].Value = model.PassporttypeseidName;
            parameters[6].Value = model.PassportseNO;
            parameters[7].Value = model.Price;
            parameters[8].Value = model.ZWCode;
            parameters[9].Value = model.ZWName;
            parameters[10].Value = model.InsuranceID;
            parameters[11].Value = model.Cxin;
            parameters[12].Value = model.State;
            parameters[13].Value = model.PassengerId;
            parameters[14].Value = model.Disacount;
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
        public bool Update(lgk.Model.tb_TrainTicketsOrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TrainTicketsOrderDetail set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("PassengerseName=@PassengerseName,");
            strSql.Append("PiaoType=@PiaoType,");
            strSql.Append("PiaotypeName=@PiaotypeName,");
            strSql.Append("Passporttypeseid=@Passporttypeseid,");
            strSql.Append("PassporttypeseidName=@PassporttypeseidName,");
            strSql.Append("PassportseNO=@PassportseNO,");
            strSql.Append("Price=@Price,");
            strSql.Append("ZWCode=@ZWCode,");
            strSql.Append("ZWName=@ZWName,");
            strSql.Append("InsuranceID=@InsuranceID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.Int),
                    new SqlParameter("@PassengerseName", SqlDbType.VarChar,100),
                    new SqlParameter("@PiaoType", SqlDbType.Int),
                    new SqlParameter("@PiaotypeName", SqlDbType.VarChar,100),
                    new SqlParameter("@Passporttypeseid", SqlDbType.Int),
                    new SqlParameter("@PassporttypeseidName", SqlDbType.VarChar,100),
                    new SqlParameter("@PassportseNO", SqlDbType.VarChar,100),
                    new SqlParameter("@Price", SqlDbType.Decimal),
                    new SqlParameter("@ZWCode", SqlDbType.VarChar,100),
                    new SqlParameter("@ZWName", SqlDbType.VarChar,100),
                    new SqlParameter("@InsuranceID", SqlDbType.Int),
                    new SqlParameter("@Cxin", SqlDbType.VarChar,100),
                    new SqlParameter("@State", SqlDbType.Int),
                    new SqlParameter("@ID", SqlDbType.Int)
            };
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.PassengerseName;
            parameters[2].Value = model.PiaoType;
            parameters[3].Value = model.PiaotypeName;
            parameters[4].Value = model.Passporttypeseid;
            parameters[5].Value = model.PassporttypeseidName;
            parameters[6].Value = model.PassportseNO;
            parameters[7].Value = model.Price;
            parameters[8].Value = model.ZWCode;
            parameters[9].Value = model.ZWName;
            parameters[10].Value = model.InsuranceID;
            parameters[11].Value = model.Cxin;
            parameters[12].Value = model.State;
            parameters[13].Value = model.ID;
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
            strSql.Append("delete from tb_TrainTicketsOrderDetail ");
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
        public lgk.Model.tb_TrainTicketsOrderDetail GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,OrderID,PassengerseName,PiaoType,PiaotypeName,Passporttypeseid,PassporttypeseidName,PassportseNO,Price,ZWCode,ZWName,InsuranceID,Cxin,State,PassengerId,Disacount from tb_TrainTicketsOrderDetail ");
            strSql.Append(" where " + where);

            lgk.Model.tb_TrainTicketsOrderDetail model = new lgk.Model.tb_TrainTicketsOrderDetail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"] != null && ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = Convert.ToInt32(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PassengerseName"] != null && ds.Tables[0].Rows[0]["PassengerseName"].ToString() != "")
                {
                    model.PassengerseName = ds.Tables[0].Rows[0]["PassengerseName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PiaoType"] != null && ds.Tables[0].Rows[0]["PiaoType"].ToString() != "")
                {
                    model.PiaoType = Convert.ToInt32(ds.Tables[0].Rows[0]["PiaoType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PiaotypeName"] != null && ds.Tables[0].Rows[0]["PiaotypeName"].ToString() != "")
                {
                    model.PiaotypeName = ds.Tables[0].Rows[0]["PiaotypeName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Passporttypeseid"] != null && ds.Tables[0].Rows[0]["Passporttypeseid"].ToString() != "")
                {
                    model.Passporttypeseid = Convert.ToInt32(ds.Tables[0].Rows[0]["Passporttypeseid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PassporttypeseidName"] != null && ds.Tables[0].Rows[0]["PassporttypeseidName"].ToString() != "")
                {
                    model.PassporttypeseidName = ds.Tables[0].Rows[0]["PassporttypeseidName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PassportseNO"] != null && ds.Tables[0].Rows[0]["PassportseNO"].ToString() != "")
                {
                    model.PassportseNO = ds.Tables[0].Rows[0]["PassportseNO"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price =Convert.ToDecimal( ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ZWCode"] != null && ds.Tables[0].Rows[0]["ZWCode"].ToString() != "")
                {
                    model.ZWCode = ds.Tables[0].Rows[0]["ZWCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZWName"] != null && ds.Tables[0].Rows[0]["ZWName"].ToString() != "")
                {
                    model.ZWName = ds.Tables[0].Rows[0]["ZWName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["InsuranceID"] != null && ds.Tables[0].Rows[0]["InsuranceID"].ToString() != "")
                {
                    model.InsuranceID = Convert.ToInt32(ds.Tables[0].Rows[0]["InsuranceID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Cxin"] != null && ds.Tables[0].Rows[0]["Cxin"].ToString() != "")
                {
                    model.Cxin = ds.Tables[0].Rows[0]["Cxin"].ToString();
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = Convert.ToInt32(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PassengerId"] != null && ds.Tables[0].Rows[0]["PassengerId"].ToString() != "")
                {
                    model.PassengerId = Convert.ToInt32(ds.Tables[0].Rows[0]["PassengerId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Disacount"] != null && ds.Tables[0].Rows[0]["Disacount"].ToString() != "")
                {
                    model.Disacount = Convert.ToDecimal(ds.Tables[0].Rows[0]["Disacount"].ToString());
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
            strSql.Append("select * from tb_TrainTicketsOrderDetail");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public bool UpdateStatus(string Cxin,int State,int OrderID, int PassengerId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TrainTicketsOrderDetail set Cxin=@Cxin,State=@State");
            strSql.Append(" where  OrderID=@OrderID and PassengerId=@PassengerId");
            SqlParameter[] parameters = {
                    new SqlParameter("@Cxin", SqlDbType.VarChar),
                    new SqlParameter("@State", SqlDbType.Int,4),
                    new SqlParameter("@OrderID", SqlDbType.Int,4),
                    new SqlParameter("@PassengerId", SqlDbType.Int,4)};
            parameters[0].Value = Cxin;
            parameters[1].Value = State;
            parameters[2].Value = OrderID;
            parameters[3].Value = PassengerId;
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
    }
}
