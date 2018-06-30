using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
   public class tb_TrainBackUrl
    {
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TrainBackUrl");
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
        public int Add(lgk.Model.tb_TrainBackUrl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_TrainBackUrl(");
            strSql.Append("SubmitCallback,CompanName,PayCallback,RefundCallback)");
            strSql.Append(" values (");
            strSql.Append("@SubmitCallback,@CompanName,@PayCallback,@RefundCallback)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@SubmitCallback", SqlDbType.VarChar,100),
                    new SqlParameter("@CompanName", SqlDbType.VarChar,100),
                    new SqlParameter("@PayCallback", SqlDbType.VarChar,100),
                    new SqlParameter("@RefundCallback", SqlDbType.VarChar,100)
            };
            parameters[0].Value = model.SubmitCallback;
            parameters[1].Value = model.CompanName;
            parameters[2].Value = model.PayCallback;
            parameters[3].Value = model.RefundCallback;
           
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
        public bool Update(lgk.Model.tb_TrainBackUrl model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TrainBackUrl set ");
            strSql.Append("SubmitCallback=@SubmitCallback,");
            strSql.Append("CompanName=@CompanName,");
            strSql.Append("PayCallback=@PayCallback,");
            strSql.Append("RefundCallback=@RefundCallback");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@SubmitCallback", SqlDbType.VarChar,100),
                    new SqlParameter("@CompanName", SqlDbType.VarChar,100),
                    new SqlParameter("@PayCallback", SqlDbType.VarChar,100),
                    new SqlParameter("@RefundCallback", SqlDbType.VarChar,100),
                    new SqlParameter("@ID", SqlDbType.Int)
            };
            parameters[0].Value = model.SubmitCallback;
            parameters[1].Value = model.CompanName;
            parameters[2].Value = model.PayCallback;
            parameters[3].Value = model.RefundCallback;
            parameters[4].Value = model.ID;
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
            strSql.Append("delete from tb_TrainBackUrl ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TrainBackUrl ");
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
        public lgk.Model.tb_TrainBackUrl GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tb_TrainBackUrl t ");
            if (where != "")
            {
                strSql.Append(" where " + where);
            }
            lgk.Model.tb_TrainBackUrl model = new lgk.Model.tb_TrainBackUrl();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SubmitCallback"] != null && ds.Tables[0].Rows[0]["SubmitCallback"].ToString() != "")
                {
                    model.SubmitCallback = ds.Tables[0].Rows[0]["SubmitCallback"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CompanName"] != null && ds.Tables[0].Rows[0]["CompanName"].ToString() != "")
                {
                    model.CompanName = ds.Tables[0].Rows[0]["CompanName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PayCallback"] != null && ds.Tables[0].Rows[0]["PayCallback"].ToString() != "")
                {
                    model.PayCallback = ds.Tables[0].Rows[0]["PayCallback"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RefundCallback"] != null && ds.Tables[0].Rows[0]["RefundCallback"].ToString() != "")
                {
                    model.RefundCallback = ds.Tables[0].Rows[0]["RefundCallback"].ToString();
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
            strSql.Append("select * from tb_TrainBackUrl t");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
