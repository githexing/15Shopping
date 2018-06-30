using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
   public  class tb_Insurance
    {
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Insurance");
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
        public int Add(lgk.Model.tb_Insurance model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Insurance(");
            strSql.Append("Name,Mobile,Gender,Birth,City,Idcard)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Mobile,@Gender,@Birth,@City,@Idcard)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.VarChar,100),
                    new SqlParameter("@Mobile", SqlDbType.VarChar,100),
                    new SqlParameter("@Gender", SqlDbType.VarChar,100),
                    new SqlParameter("@Birth", SqlDbType.Date),
                    new SqlParameter("@City", SqlDbType.VarChar,100),
                    new SqlParameter("@Idcard", SqlDbType.VarChar)
            };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Mobile;
            parameters[2].Value = model.Gender;
            parameters[3].Value = model.Birth;
            parameters[4].Value = model.City;
            parameters[5].Value = model.Idcard;
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
        public bool Update(lgk.Model.tb_Insurance model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TrainTicketsOrder set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("Gender=@Gender,");
            strSql.Append("Birth=@Birth,");
            strSql.Append("City=@City,");
            strSql.Append("Idcard=@Idcard");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.VarChar,100),
                    new SqlParameter("@Mobile", SqlDbType.VarChar,100),
                    new SqlParameter("@Gender", SqlDbType.VarChar,100),
                    new SqlParameter("@Birth", SqlDbType.Date),
                    new SqlParameter("@City", SqlDbType.VarChar,100),
                    new SqlParameter("@Idcard", SqlDbType.VarChar),
                    new SqlParameter("@ID", SqlDbType.Int),
            };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Mobile;
            parameters[2].Value = model.Gender;
            parameters[3].Value = model.Birth;
            parameters[4].Value = model.City;
            parameters[5].Value = model.Idcard;
            parameters[6].Value = model.ID;
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
            strSql.Append("delete from tb_Insurance ");
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
        public lgk.Model.tb_Insurance GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Mobile,Gender,Birth,City,Idcard from tb_Insurance ");
            strSql.Append(" where " + where);

            lgk.Model.tb_Insurance model = new lgk.Model.tb_Insurance();
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
                if (ds.Tables[0].Rows[0]["Mobile"] != null && ds.Tables[0].Rows[0]["Mobile"].ToString() != "")
                {
                    model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Gender"] != null && ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                {
                    model.Gender = ds.Tables[0].Rows[0]["Gender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Birth"] != null && ds.Tables[0].Rows[0]["Birth"].ToString() != "")
                {
                    model.Birth = Convert.ToDateTime(ds.Tables[0].Rows[0]["Birth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["City"] != null && ds.Tables[0].Rows[0]["City"].ToString() != "")
                {
                    model.City = ds.Tables[0].Rows[0]["City"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Idcard"] != null && ds.Tables[0].Rows[0]["Idcard"].ToString() != "")
                {
                    model.Idcard = ds.Tables[0].Rows[0]["Idcard"].ToString();
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
            strSql.Append("select * from tb_Insurance");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
