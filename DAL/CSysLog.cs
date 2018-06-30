using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// </summary> 
	public partial class CSysLog   
	{
		#region  Method

        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SysLog");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.SysLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysLog(");
            strSql.Append("Log2,Log3,Log4,IsDeleted,LogType,LogLeve,LogCode,DataInt,DataStr,LogMsg,Log1");
            strSql.Append(") values (");
            strSql.Append("@Log2,@Log3,@Log4,@IsDeleted,@LogType,@LogLeve,@LogCode,@DataInt,@DataStr,@LogMsg,@Log1");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Log2", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Log3", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Log4", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@IsDeleted", SqlDbType.Int,4) ,            
                        new SqlParameter("@LogType", SqlDbType.Int,4) ,            
                        new SqlParameter("@LogLeve", SqlDbType.Int,4) ,            
                        new SqlParameter("@LogCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@DataInt", SqlDbType.Money,8) ,            
                        new SqlParameter("@DataStr", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@LogMsg", SqlDbType.Text) ,            
                        new SqlParameter("@Log1", SqlDbType.VarChar,100)             
              
            };

            parameters[0].Value = model.Log2;
            parameters[1].Value = model.Log3;
            parameters[2].Value = model.Log4;
            parameters[3].Value = model.IsDeleted;
            parameters[4].Value = model.LogType;
            parameters[5].Value = model.LogLeve;
            parameters[6].Value = model.LogCode;
            parameters[7].Value = model.DataInt;
            parameters[8].Value = model.DataStr;
            parameters[9].Value = model.LogMsg;
            parameters[10].Value = model.Log1;

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
        public bool Update(lgk.Model.SysLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysLog set ");

            strSql.Append(" Log2 = @Log2 , ");
            strSql.Append(" Log3 = @Log3 , ");
            strSql.Append(" Log4 = @Log4 , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" LogType = @LogType , ");
            strSql.Append(" LogLeve = @LogLeve , ");
            strSql.Append(" LogCode = @LogCode , ");
            strSql.Append(" DataInt = @DataInt , ");
            strSql.Append(" DataStr = @DataStr , ");
            strSql.Append(" LogMsg = @LogMsg , ");
            strSql.Append(" LogDate = @LogDate , ");
            strSql.Append(" Log1 = @Log1  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Log2", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Log3", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Log4", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@IsDeleted", SqlDbType.Int,4) ,            
                        new SqlParameter("@LogType", SqlDbType.Int,4) ,            
                        new SqlParameter("@LogLeve", SqlDbType.Int,4) ,            
                        new SqlParameter("@LogCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@DataInt", SqlDbType.Money,8) ,            
                        new SqlParameter("@DataStr", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@LogMsg", SqlDbType.Text) ,            
                        new SqlParameter("@LogDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@Log1", SqlDbType.VarChar,100)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Log2;
            parameters[2].Value = model.Log3;
            parameters[3].Value = model.Log4;
            parameters[4].Value = model.IsDeleted;
            parameters[5].Value = model.LogType;
            parameters[6].Value = model.LogLeve;
            parameters[7].Value = model.LogCode;
            parameters[8].Value = model.DataInt;
            parameters[9].Value = model.DataStr;
            parameters[10].Value = model.LogMsg;
            parameters[11].Value = model.LogDate;
            parameters[12].Value = model.Log1;
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
        public bool Delete(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysLog ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysLog ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public lgk.Model.SysLog GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, Log2, Log3, Log4, IsDeleted, LogType, LogLeve, LogCode, DataInt, DataStr, LogMsg, LogDate, Log1  ");
            strSql.Append("  from SysLog ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;


            lgk.Model.SysLog model = new lgk.Model.SysLog();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Log2 = ds.Tables[0].Rows[0]["Log2"].ToString();
                model.Log3 = ds.Tables[0].Rows[0]["Log3"].ToString();
                model.Log4 = ds.Tables[0].Rows[0]["Log4"].ToString();
                if (ds.Tables[0].Rows[0]["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(ds.Tables[0].Rows[0]["IsDeleted"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LogType"].ToString() != "")
                {
                    model.LogType = int.Parse(ds.Tables[0].Rows[0]["LogType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LogLeve"].ToString() != "")
                {
                    model.LogLeve = int.Parse(ds.Tables[0].Rows[0]["LogLeve"].ToString());
                }
                model.LogCode = ds.Tables[0].Rows[0]["LogCode"].ToString();
                if (ds.Tables[0].Rows[0]["DataInt"].ToString() != "")
                {
                    model.DataInt = decimal.Parse(ds.Tables[0].Rows[0]["DataInt"].ToString());
                }
                model.DataStr = ds.Tables[0].Rows[0]["DataStr"].ToString();
                model.LogMsg = ds.Tables[0].Rows[0]["LogMsg"].ToString();
                if (ds.Tables[0].Rows[0]["LogDate"].ToString() != "")
                {
                    model.LogDate = DateTime.Parse(ds.Tables[0].Rows[0]["LogDate"].ToString());
                }
                model.Log1 = ds.Tables[0].Rows[0]["Log1"].ToString();

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
            strSql.Append(" FROM SysLog ");
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
            strSql.Append(" FROM SysLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
		
		#endregion  Method
	}
}

