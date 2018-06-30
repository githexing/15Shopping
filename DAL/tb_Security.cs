using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_Security
    /// </summary>
    public partial class tb_Security
    {
        public tb_Security()
		{ }
        #region Method

        public bool Exists(int SecurityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Security");
            strSql.Append(" where ");
            strSql.Append(" SecurityID = @SecurityID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@SecurityID", SqlDbType.Int,4)
			};
            parameters[0].Value = SecurityID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_Security model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Security(");
            strSql.Append("Question,AddUserID,AddDate,EditUserID,EditDate,Status");
            strSql.Append(") values (");
            strSql.Append("@Question,@AddUserID,@AddDate,@EditUserID,@EditDate,@Status");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Question", SqlDbType.VarChar,50),
                        new SqlParameter("@AddUserID", SqlDbType.Int,4),
                        new SqlParameter("@AddDate", SqlDbType.DateTime),
                        new SqlParameter("@EditUserID", SqlDbType.Int,4),
                        new SqlParameter("@EditDate", SqlDbType.DateTime),
                        new SqlParameter("@Status", SqlDbType.Int,4)
            };
            parameters[0].Value = model.Question;
            parameters[1].Value = model.AddUserID;
            parameters[2].Value = model.AddDate;
            parameters[3].Value = model.EditUserID;
            parameters[4].Value = DBNull.Value;
            parameters[5].Value = model.Status;

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
        public bool Update(lgk.Model.tb_Security model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Security set ");
            strSql.Append(" Question = @Question,");
            strSql.Append(" AddUserID = @AddUserID,");
            strSql.Append(" AddDate = @AddDate,");
            strSql.Append(" EditUserID = @EditUserID,");
            strSql.Append(" EditDate = @EditDate,");
            strSql.Append(" Status = @Status  ");
            strSql.Append(" where SecurityID=@SecurityID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@SecurityID", SqlDbType.Int,4),
                        new SqlParameter("@Question", SqlDbType.VarChar,50),
                        new SqlParameter("@AddUserID", SqlDbType.Int,4),
                        new SqlParameter("@AddDate", SqlDbType.DateTime),
                        new SqlParameter("@EditUserID", SqlDbType.Int,4),
                        new SqlParameter("@EditDate", SqlDbType.DateTime),
                        new SqlParameter("@Status", SqlDbType.Int,4)
            };
            parameters[0].Value = model.SecurityID;
            parameters[1].Value = model.Question;
            parameters[2].Value = model.AddUserID;
            parameters[3].Value = model.AddDate;
            parameters[4].Value = model.EditUserID;
            parameters[5].Value = model.EditDate;
            parameters[6].Value = model.Status;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(int SecurityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Security set ");
            strSql.Append(" Status = 1");
            strSql.Append(" where SecurityID=" + SecurityID + "");

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SecurityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Security ");
            strSql.Append(" where SecurityID=@SecurityID");
            SqlParameter[] parameters = {
					new SqlParameter("@SecurityID", SqlDbType.Int,4)
			};
            parameters[0].Value = SecurityID;

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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string SecurityIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Security ");
            strSql.Append(" where ID in (" + SecurityIDlist + ")  ");
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
        public lgk.Model.tb_Security GetModel(int SecurityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SecurityID, Question, AddUserID, AddDate, EditUserID, EditDate, Status");
            strSql.Append(" from tb_Security ");
            strSql.Append(" where SecurityID=@SecurityID");
            SqlParameter[] parameters = {
					new SqlParameter("@SecurityID", SqlDbType.Int,4)
			};
            parameters[0].Value = SecurityID;

            lgk.Model.tb_Security model = new lgk.Model.tb_Security();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SecurityID"].ToString() != "")
                {
                    model.SecurityID = int.Parse(ds.Tables[0].Rows[0]["SecurityID"].ToString());
                }
                model.Question = ds.Tables[0].Rows[0]["Question"].ToString();
                if (ds.Tables[0].Rows[0]["AddUserID"].ToString() != "")
                {
                    model.AddUserID = int.Parse(ds.Tables[0].Rows[0]["AddUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EditUserID"].ToString() != "")
                {
                    model.EditUserID = int.Parse(ds.Tables[0].Rows[0]["EditUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EditDate"].ToString() != "")
                {
                    model.EditDate = DateTime.Parse(ds.Tables[0].Rows[0]["EditDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }

                return model;
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
            strSql.Append("select * ");
            strSql.Append(" FROM tb_Security ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM tb_Security ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion
    }
}
