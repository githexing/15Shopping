using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public partial class SMS
    {
        public SMS() { }
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SMS");
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
        public long Add(lgk.Model.SMS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SMS(");
            strSql.Append("ToUserID,ToUserCode,ToPhone,SMSContent,PublishTime,SCode,ValidTime,SendNum,IsValid,IsDeleted,TypeID)");
            strSql.Append(" values (");
            strSql.Append("@ToUserID,@ToUserCode,@ToPhone,@SMSContent,@PublishTime,@SCode,@ValidTime,@SendNum,@IsValid,@IsDeleted,@TypeID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ToUserID", SqlDbType.BigInt,8),
					new SqlParameter("@ToUserCode", SqlDbType.VarChar,100),
					new SqlParameter("@ToPhone", SqlDbType.VarChar,50),
					new SqlParameter("@SMSContent", SqlDbType.VarChar,500),
					new SqlParameter("@PublishTime", SqlDbType.DateTime),
					new SqlParameter("@SCode", SqlDbType.VarChar,50),
					new SqlParameter("@ValidTime", SqlDbType.DateTime),
					new SqlParameter("@SendNum", SqlDbType.Int,4),
					new SqlParameter("@IsValid", SqlDbType.Int,4),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@TypeID", SqlDbType.Int,4)};
            parameters[0].Value = model.ToUserID;
            parameters[1].Value = model.ToUserCode;
            parameters[2].Value = model.ToPhone;
            parameters[3].Value = model.SMSContent;
            parameters[4].Value = model.PublishTime;
            parameters[5].Value = model.SCode;
            parameters[6].Value = model.ValidTime;
            parameters[7].Value = model.SendNum;
            parameters[8].Value = model.IsValid;
            parameters[9].Value = model.IsDeleted;
            parameters[10].Value = model.TypeID;

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
        public bool Update(lgk.Model.SMS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SMS set ");
            strSql.Append("ToUserID=@ToUserID,");
            strSql.Append("ToUserCode=@ToUserCode,");
            strSql.Append("ToPhone=@ToPhone,");
            strSql.Append("SMSContent=@SMSContent,");
            strSql.Append("PublishTime=@PublishTime,");
            strSql.Append("SCode=@SCode,");
            strSql.Append("ValidTime=@ValidTime,");
            strSql.Append("SendNum=@SendNum,");
            strSql.Append("IsValid=@IsValid,");
            strSql.Append("IsDeleted=@IsDeleted,");
            strSql.Append("TypeID=@TypeID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ToUserID", SqlDbType.BigInt,8),
					new SqlParameter("@ToUserCode", SqlDbType.VarChar,100),
					new SqlParameter("@ToPhone", SqlDbType.VarChar,50),
					new SqlParameter("@SMSContent", SqlDbType.VarChar,500),
					new SqlParameter("@PublishTime", SqlDbType.DateTime),
					new SqlParameter("@SCode", SqlDbType.VarChar,50),
					new SqlParameter("@ValidTime", SqlDbType.DateTime),
					new SqlParameter("@SendNum", SqlDbType.Int,4),
					new SqlParameter("@IsValid", SqlDbType.Int,4),
					new SqlParameter("@IsDeleted", SqlDbType.Int,4),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.ToUserID;
            parameters[1].Value = model.ToUserCode;
            parameters[2].Value = model.ToPhone;
            parameters[3].Value = model.SMSContent;
            parameters[4].Value = model.PublishTime;
            parameters[5].Value = model.SCode;
            parameters[6].Value = model.ValidTime;
            parameters[7].Value = model.SendNum;
            parameters[8].Value = model.IsValid;
            parameters[9].Value = model.IsDeleted;
            parameters[10].Value = model.TypeID;
            parameters[11].Value = model.ID;

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
            strSql.Append("delete from SMS ");
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
            strSql.Append("delete from SMS ");
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
        public lgk.Model.SMS GetModel(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, IsValid, IsDeleted, ToUserID, ToUserCode, ToPhone, SMSContent, PublishTime, SCode, ValidTime, SendNum, TypeID ");
            strSql.Append("  from SMS ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;


            lgk.Model.SMS model = new lgk.Model.SMS();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.SMS GetModelByPhoneAndCode(string phoneNum, string Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID, IsValid, IsDeleted, ToUserID, ToUserCode, ToPhone, SMSContent, PublishTime, SCode, ValidTime, SendNum, TypeID ");
            strSql.Append("  from SMS ");
            strSql.Append(" where ToPhone=@ToPhone and SCode=@SCode");
            SqlParameter[] parameters = {
                    new SqlParameter("@ToPhone", SqlDbType.VarChar),
                    new SqlParameter("@SCode", SqlDbType.VarChar)
            };
            parameters[0].Value = phoneNum;
            parameters[1].Value = Code;

            lgk.Model.SMS model = new lgk.Model.SMS();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public lgk.Model.SMS DataRowToModel(DataRow row)
        {
            lgk.Model.SMS model = new lgk.Model.SMS();
            if (row != null)
            {
                if (row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["IsValid"].ToString() != "")
                {
                    model.IsValid = int.Parse(row["IsValid"].ToString());
                }
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                if (row["ToUserID"].ToString() != "")
                {
                    model.ToUserID = long.Parse(row["ToUserID"].ToString());
                }
                model.ToUserCode = row["ToUserCode"].ToString();
                model.ToPhone = row["ToPhone"].ToString();
                model.SMSContent = row["SMSContent"].ToString();
                if (row["PublishTime"].ToString() != "")
                {
                    model.PublishTime = DateTime.Parse(row["PublishTime"].ToString());
                }
                model.SCode = row["SCode"].ToString();
                if (row["ValidTime"].ToString() != "")
                {
                    model.ValidTime = DateTime.Parse(row["ValidTime"].ToString());
                }
                if (row["SendNum"].ToString() != "")
                {
                    model.SendNum = int.Parse(row["SendNum"].ToString());
                }
                if (row["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(row["TypeID"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SMS ");
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
            strSql.Append(" FROM SMS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #region 更改短信状态（第三方是否通过）
        /// <summary>
        /// 更改短信状态（第三方是否通过）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="iDelete">0、有效，1、第三方验证失败</param>
        /// <returns></returns>
        public bool UpdateDelete(long id, int iDelete)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SMS set ");
            strSql.Append(" IsDeleted = @IsDeleted ");
            strSql.Append(" where ID=@ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.BigInt,8),
                        new SqlParameter("@IsDeleted", SqlDbType.Int,4)
            };

            parameters[0].Value = id;
            parameters[1].Value = iDelete;
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
        #endregion

        #region 更改短信状态（是否已验证）
        /// <summary>
        /// 更改短信状态（是否已验证）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="iValid">0、未验证，1、验证成功</param>
        /// <returns></returns>
        public bool UpdateState(long id, int iValid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SMS set ");
            strSql.Append(" IsValid = @IsValid ");
            strSql.Append(" where ID=@ID  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.BigInt,8),
                        new SqlParameter("@IsValid", SqlDbType.Int,4)
            };

            parameters[0].Value = id;
            parameters[1].Value = iValid;
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
        #endregion

    }
}
