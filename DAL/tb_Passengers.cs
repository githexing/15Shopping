using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public class tb_Passengers
    {
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Passengers");
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
        public int Add(lgk.Model.tb_Passengers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Passengers(");
            strSql.Append("OrderID,Name,Cardno,Cardtype,Mantype,Birthday,Sex,InsurancePrice,InsuranceNum)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@Name,@Cardno,@Cardtype,@Mantype,@Birthday,@Sex,@InsurancePrice,@InsuranceNum)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.Int),
                    new SqlParameter("@Name", SqlDbType.VarChar,100),
                    new SqlParameter("@Cardno", SqlDbType.VarChar,100),
                    new SqlParameter("@Cardtype", SqlDbType.VarChar,100),
                    new SqlParameter("@Mantype", SqlDbType.VarChar,100),
                    new SqlParameter("@Birthday", SqlDbType.DateTime),
                    new SqlParameter("@Sex", SqlDbType.VarChar),
                    new SqlParameter("@InsurancePrice", SqlDbType.Decimal),
                    new SqlParameter("@InsuranceNum", SqlDbType.Int)
            };
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Cardno;
            parameters[3].Value = model.Cardtype;
            parameters[4].Value = model.Mantype;
            parameters[5].Value = model.Birthday;
            parameters[6].Value = model.Sex;
            parameters[7].Value = model.InsurancePrice;
            parameters[8].Value = model.InsuranceNum;
            
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
        public bool Update(lgk.Model.tb_Passengers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Passengers set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("Name=@Name,");
            strSql.Append("Cardno=@Cardno,");
            strSql.Append("Cardtype=@Cardtype,");
            strSql.Append("Mantype=@Mantype,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("InsurancePrice=@InsurancePrice,");
            strSql.Append("InsuranceNum=@InsuranceNum");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.Int),
                    new SqlParameter("@Name", SqlDbType.VarChar,100),
                    new SqlParameter("@Cardno", SqlDbType.VarChar,100),
                    new SqlParameter("@Cardtype", SqlDbType.VarChar,100),
                    new SqlParameter("@Mantype", SqlDbType.VarChar,100),
                    new SqlParameter("@Birthday", SqlDbType.DateTime),
                    new SqlParameter("@Sex", SqlDbType.VarChar),
                    new SqlParameter("@InsurancePrice", SqlDbType.Decimal),
                    new SqlParameter("@InsuranceNum", SqlDbType.Int),
                    new SqlParameter("@ID", SqlDbType.Int)
            };
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Cardno;
            parameters[3].Value = model.Cardtype;
            parameters[4].Value = model.Mantype;
            parameters[5].Value = model.Birthday;
            parameters[6].Value = model.Sex;
            parameters[7].Value = model.InsurancePrice;
            parameters[8].Value = model.InsuranceNum;
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
            strSql.Append("delete from tb_Passengers ");
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
        public lgk.Model.tb_Passengers GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,OrderID,Name,Cardno,Cardtype,Mantype,Birthday,Sex,InsurancePrice,InsuranceNum from tb_Passengers ");
            strSql.Append(" where " + where);

            lgk.Model.tb_Passengers model = new lgk.Model.tb_Passengers();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Cardno"] != null && ds.Tables[0].Rows[0]["Cardno"].ToString() != "")
                {
                    model.Cardno = ds.Tables[0].Rows[0]["Cardno"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Cardtype"] != null && ds.Tables[0].Rows[0]["FromStationCode"].ToString() != "")
                {
                    model.Cardtype = ds.Tables[0].Rows[0]["Cardtype"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Mantype"] != null && ds.Tables[0].Rows[0]["Mantype"].ToString() != "")
                {
                    model.Mantype = ds.Tables[0].Rows[0]["Mantype"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Birthday"] != null && ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = ds.Tables[0].Rows[0]["Birthday"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["InsurancePrice"] != null && ds.Tables[0].Rows[0]["InsurancePrice"].ToString() != "")
                {
                    model.InsurancePrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["InsurancePrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InsuranceNum"] != null && ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.InsuranceNum =Convert.ToInt32( ds.Tables[0].Rows[0]["InsuranceNum"].ToString());
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
            strSql.Append("select * from tb_Passengers t");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public bool UpdateStatus(string TicketsNo, string Cardno)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Passengers set TicketsNo=@TicketsNo ");
            strSql.Append(" where Cardno=@Cardno");
            SqlParameter[] parameters = {
                    new SqlParameter("@TicketsNo", SqlDbType.VarChar),
                    new SqlParameter("@Cardno", SqlDbType.VarChar)
                                        };
            parameters[0].Value = TicketsNo;
            parameters[1].Value = Cardno;
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
