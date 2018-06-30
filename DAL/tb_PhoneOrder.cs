using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public class tb_PhoneOrder
    {
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_PhoneOrder");
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
        public int Add(lgk.Model.tb_PhoneOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_PhoneOrder(");
            strSql.Append("PhoneNO,CardNum,UorderID,CardID,OrderCash,CardName,SporderID,State,AddDate,UserID)");
            strSql.Append(" values (");
            strSql.Append("@PhoneNO,@CardNum,@UorderID,@CardID,@OrderCash,@CardName,@SporderID,@State,@AddDate,@UserID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@PhoneNO", SqlDbType.VarChar,100),
                    new SqlParameter("@CardNum", SqlDbType.Int),
                    new SqlParameter("@UorderID", SqlDbType.VarChar,100),
                    new SqlParameter("@CardID", SqlDbType.VarChar,100),
                    new SqlParameter("@OrderCash", SqlDbType.VarChar,100),
                    new SqlParameter("@CardName", SqlDbType.VarChar),
                    new SqlParameter("@SporderID", SqlDbType.VarChar),
                    new SqlParameter("@State", SqlDbType.Int),
                    new SqlParameter("@AddDate", SqlDbType.DateTime),
                    new SqlParameter("@UserID", SqlDbType.Int)
            };
            parameters[0].Value = model.PhoneNO;
            parameters[1].Value = model.CardNum;
            parameters[2].Value = model.UorderID;
            parameters[3].Value = model.CardID;
            parameters[4].Value = model.OrderCash;
            parameters[5].Value = model.CardName;
            parameters[6].Value = model.SporderID;
            parameters[7].Value = model.State;
            parameters[8].Value = model.AddDate;
            parameters[9].Value = model.UserID;
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
        public bool Update(lgk.Model.tb_PhoneOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_PhoneOrder set ");
            strSql.Append("PhoneNO=@PhoneNO,");
            strSql.Append("CardNum=@CardNum,");
            strSql.Append("UorderID=@UorderID,");
            strSql.Append("CardID=@CardID,");
            strSql.Append("OrderCash=@OrderCash,");
            strSql.Append("CardName=@CardName,");
            strSql.Append("SporderID=@SporderID,");
            strSql.Append("State=@State,");
            strSql.Append("AddDate=@AddDate");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@PhoneNO", SqlDbType.VarChar,100),
                    new SqlParameter("@CardNum", SqlDbType.Int),
                    new SqlParameter("@UorderID", SqlDbType.VarChar,100),
                    new SqlParameter("@CardID", SqlDbType.VarChar,100),
                    new SqlParameter("@OrderCash", SqlDbType.VarChar,100),
                    new SqlParameter("@CardName", SqlDbType.VarChar),
                    new SqlParameter("@SporderID", SqlDbType.VarChar),
                    new SqlParameter("@State", SqlDbType.Int),
                    new SqlParameter("@AddDate", SqlDbType.DateTime),
                    new SqlParameter("@ID", SqlDbType.Int)
            };
            parameters[0].Value = model.PhoneNO;
            parameters[1].Value = model.CardNum;
            parameters[2].Value = model.UorderID;
            parameters[3].Value = model.CardID;
            parameters[4].Value = model.OrderCash;
            parameters[5].Value = model.CardName;
            parameters[6].Value = model.SporderID;
            parameters[7].Value = model.State;
            parameters[8].Value = model.AddDate;
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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_PhoneOrder ");
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
        public lgk.Model.tb_PhoneOrder GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tb_PhoneOrder ");
            strSql.Append(" where " + where);

            lgk.Model.tb_PhoneOrder model = new lgk.Model.tb_PhoneOrder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PhoneNO"] != null && ds.Tables[0].Rows[0]["PhoneNO"].ToString() != "")
                {
                    model.PhoneNO = ds.Tables[0].Rows[0]["PhoneNO"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CardNum"] != null && ds.Tables[0].Rows[0]["CardNum"].ToString() != "")
                {
                    model.CardNum = Convert.ToInt32(ds.Tables[0].Rows[0]["CardNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UorderID"] != null && ds.Tables[0].Rows[0]["UorderID"].ToString() != "")
                {
                    model.UorderID = ds.Tables[0].Rows[0]["UorderID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CardID"] != null && ds.Tables[0].Rows[0]["CardID"].ToString() != "")
                {
                    model.CardID = ds.Tables[0].Rows[0]["CardID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderCash"] != null && ds.Tables[0].Rows[0]["OrderCash"].ToString() != "")
                {
                    model.OrderCash = ds.Tables[0].Rows[0]["OrderCash"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CardName"] != null && ds.Tables[0].Rows[0]["CardName"].ToString() != "")
                {
                    model.CardName = ds.Tables[0].Rows[0]["CardName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SporderID"] != null && ds.Tables[0].Rows[0]["SporderID"].ToString() != "")
                {
                    model.SporderID = ds.Tables[0].Rows[0]["SporderID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = Convert.ToInt32(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"] != null && ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"].ToString());
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
            strSql.Append("select (select UserCode from tb_user u where p.UserID=u.UserID) as UserCode,* from tb_PhoneOrder p");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
