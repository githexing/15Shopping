using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DataAccess;

namespace lgk.DAL
{
    //AppLog
    public partial class AppLog
    {

        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AppLog");
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
        public long Add(lgk.Model.AppLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AppLog(");
            strSql.Append("AddTime,OpType,Msg,UserID,UserCode,UserName,Longitude,MAC,PhoneVersion,PhoneBrand,PhoneSystem,Mobile");
            strSql.Append(") values (");
            strSql.Append("@AddTime,@OpType,@Msg,@UserID,@UserCode,@UserName,@Longitude,@MAC,@PhoneVersion,@PhoneBrand,@PhoneSystem,@Mobile");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,
                        new SqlParameter("@OpType", SqlDbType.Int,4) ,
                        new SqlParameter("@Msg", SqlDbType.VarChar,50) ,
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@UserCode", SqlDbType.VarChar,30) ,
                        new SqlParameter("@UserName", SqlDbType.VarChar,30) ,
                        new SqlParameter("@Longitude", SqlDbType.VarChar,100) ,
                        new SqlParameter("@MAC", SqlDbType.VarChar,50) ,
                        new SqlParameter("@PhoneVersion", SqlDbType.VarChar,50) ,
                        new SqlParameter("@PhoneBrand", SqlDbType.VarChar,50) ,
                        new SqlParameter("@PhoneSystem", SqlDbType.VarChar,50),
                        new SqlParameter("@Mobile", SqlDbType.VarChar,15)

            };

            parameters[0].Value = model.AddTime;
            parameters[1].Value = model.OpType;
            parameters[2].Value = model.Msg;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.UserCode;
            parameters[5].Value = model.UserName;
            parameters[6].Value = model.Longitude;
            parameters[7].Value = model.MAC;
            parameters[8].Value = model.PhoneVersion;
            parameters[9].Value = model.PhoneBrand;
            parameters[10].Value = model.PhoneSystem;
            parameters[11].Value = model.Mobile;

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
        public bool Update(lgk.Model.AppLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AppLog set ");

            strSql.Append(" AddTime = @AddTime , ");
            strSql.Append(" OpType = @OpType , ");
            strSql.Append(" Msg = @Msg , ");
            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" UserCode = @UserCode , ");
            strSql.Append(" UserName = @UserName , ");
            strSql.Append(" Longitude = @Longitude , ");
            strSql.Append(" MAC = @MAC , ");
            strSql.Append(" PhoneVersion = @PhoneVersion , ");
            strSql.Append(" PhoneBrand = @PhoneBrand , ");
            strSql.Append(" PhoneSystem = @PhoneSystem , ");
            strSql.Append(" Mobile = @Mobile  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,
                        new SqlParameter("@OpType", SqlDbType.Int,4) ,
                        new SqlParameter("@Msg", SqlDbType.VarChar,50) ,
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@UserCode", SqlDbType.VarChar,30) ,
                        new SqlParameter("@UserName", SqlDbType.VarChar,30) ,
                        new SqlParameter("@Longitude", SqlDbType.VarChar,50) ,
                        new SqlParameter("@MAC", SqlDbType.VarChar,50) ,
                        new SqlParameter("@PhoneVersion", SqlDbType.VarChar,50) ,
                        new SqlParameter("@PhoneBrand", SqlDbType.VarChar,50) ,
                        new SqlParameter("@PhoneSystem", SqlDbType.VarChar,50),
                        new SqlParameter("@Mobile", SqlDbType.VarChar,15)

            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.AddTime;
            parameters[2].Value = model.OpType;
            parameters[3].Value = model.Msg;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.UserCode;
            parameters[6].Value = model.UserName;
            parameters[7].Value = model.Longitude;
            parameters[8].Value = model.MAC;
            parameters[9].Value = model.PhoneVersion;
            parameters[10].Value = model.PhoneBrand;
            parameters[11].Value = model.PhoneSystem;
            parameters[12].Value = model.Mobile;
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
            strSql.Append("delete from AppLog ");
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
            strSql.Append("delete from AppLog ");
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
        public lgk.Model.AppLog GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AddTime, OpType, Msg, UserID, UserCode, UserName, Longitude, MAC, PhoneVersion, PhoneBrand, PhoneSystem,Mobile  ");
            strSql.Append("  from AppLog ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt)
            };
            parameters[0].Value = ID;


            lgk.Model.AppLog model = new lgk.Model.AppLog();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OpType"].ToString() != "")
                {
                    model.OpType = int.Parse(ds.Tables[0].Rows[0]["OpType"].ToString());
                }
                model.Msg = ds.Tables[0].Rows[0]["Msg"].ToString();
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserCode = ds.Tables[0].Rows[0]["UserCode"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Longitude = ds.Tables[0].Rows[0]["Longitude"].ToString();
                model.MAC = ds.Tables[0].Rows[0]["MAC"].ToString();
                model.PhoneVersion = ds.Tables[0].Rows[0]["PhoneVersion"].ToString();
                model.PhoneBrand = ds.Tables[0].Rows[0]["PhoneBrand"].ToString();
                model.PhoneSystem = ds.Tables[0].Rows[0]["PhoneSystem"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();

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
            strSql.Append(" FROM AppLog ");
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
            strSql.Append(" FROM AppLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

