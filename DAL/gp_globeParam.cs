using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:gp_globeParam
	/// </summary>
	public partial class gp_globeParam
	{
		public gp_globeParam()
		{}
		#region  Method

        public bool Exists(long Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from gp_globeParam");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.BigInt)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.gp_globeParam model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into gp_globeParam(");
            strSql.Append("ParamName,ParamAmount,ParamInt,ParamVarchar,Remark,ParamType,EndRemark,IsEdit");
            strSql.Append(") values (");
            strSql.Append("@ParamName,@ParamAmount,@ParamInt,@ParamVarchar,@Remark,@ParamType,@EndRemark,@IsEdit");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ParamName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ParamAmount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ParamInt", SqlDbType.Int,4) ,            
                        new SqlParameter("@ParamVarchar", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@ParamType", SqlDbType.Int,4) ,            
                        new SqlParameter("@EndRemark", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@IsEdit", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.ParamName;
            parameters[1].Value = model.ParamAmount;
            parameters[2].Value = model.ParamInt;
            parameters[3].Value = model.ParamVarchar;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.ParamType;
            parameters[6].Value = model.EndRemark;
            parameters[7].Value = model.IsEdit;

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
        public bool Update(lgk.Model.gp_globeParam model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update gp_globeParam set ");

            strSql.Append(" ParamName = @ParamName , ");
            strSql.Append(" ParamAmount = @ParamAmount , ");
            strSql.Append(" ParamInt = @ParamInt , ");
            strSql.Append(" ParamVarchar = @ParamVarchar , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" ParamType = @ParamType , ");
            strSql.Append(" EndRemark = @EndRemark , ");
            strSql.Append(" IsEdit = @IsEdit  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@ParamName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ParamAmount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ParamInt", SqlDbType.Int,4) ,            
                        new SqlParameter("@ParamVarchar", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@ParamType", SqlDbType.Int,4) ,            
                        new SqlParameter("@EndRemark", SqlDbType.VarChar,-1) ,            
                        new SqlParameter("@IsEdit", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.ParamName;
            parameters[2].Value = model.ParamAmount;
            parameters[3].Value = model.ParamInt;
            parameters[4].Value = model.ParamVarchar;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.ParamType;
            parameters[7].Value = model.EndRemark;
            parameters[8].Value = model.IsEdit;
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
        public bool Delete(long Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from gp_globeParam ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.BigInt)
			};
            parameters[0].Value = Id;


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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from gp_globeParam ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
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
        public lgk.Model.gp_globeParam GetModel(long Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, ParamName, ParamAmount, ParamInt, ParamVarchar, Remark, ParamType, EndRemark, IsEdit  ");
            strSql.Append("  from gp_globeParam ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.BigInt)
			};
            parameters[0].Value = Id;

            lgk.Model.gp_globeParam model = new lgk.Model.gp_globeParam();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = long.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.ParamName = ds.Tables[0].Rows[0]["ParamName"].ToString();
                if (ds.Tables[0].Rows[0]["ParamAmount"].ToString() != "")
                {
                    model.ParamAmount = decimal.Parse(ds.Tables[0].Rows[0]["ParamAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParamInt"].ToString() != "")
                {
                    model.ParamInt = int.Parse(ds.Tables[0].Rows[0]["ParamInt"].ToString());
                }
                model.ParamVarchar = ds.Tables[0].Rows[0]["ParamVarchar"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["ParamType"].ToString() != "")
                {
                    model.ParamType = int.Parse(ds.Tables[0].Rows[0]["ParamType"].ToString());
                }
                model.EndRemark = ds.Tables[0].Rows[0]["EndRemark"].ToString();
                if (ds.Tables[0].Rows[0]["IsEdit"].ToString() != "")
                {
                    model.IsEdit = int.Parse(ds.Tables[0].Rows[0]["IsEdit"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.gp_globeParam GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, ParamName, ParamAmount, ParamInt, ParamVarchar, Remark, ParamType, EndRemark, IsEdit  ");
            strSql.Append(" from gp_globeParam ");
            if (strWhere.Trim() == "")
            {
                strSql.Append(" where " + strWhere);
            }

            lgk.Model.gp_globeParam model = new lgk.Model.gp_globeParam();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = long.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.ParamName = ds.Tables[0].Rows[0]["ParamName"].ToString();
                if (ds.Tables[0].Rows[0]["ParamAmount"].ToString() != "")
                {
                    model.ParamAmount = decimal.Parse(ds.Tables[0].Rows[0]["ParamAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParamInt"].ToString() != "")
                {
                    model.ParamInt = int.Parse(ds.Tables[0].Rows[0]["ParamInt"].ToString());
                }
                model.ParamVarchar = ds.Tables[0].Rows[0]["ParamVarchar"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["ParamType"].ToString() != "")
                {
                    model.ParamType = int.Parse(ds.Tables[0].Rows[0]["ParamType"].ToString());
                }
                model.EndRemark = ds.Tables[0].Rows[0]["EndRemark"].ToString();
                if (ds.Tables[0].Rows[0]["IsEdit"].ToString() != "")
                {
                    model.IsEdit = int.Parse(ds.Tables[0].Rows[0]["IsEdit"].ToString());
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
            strSql.Append(" FROM gp_globeParam ");
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
            strSql.Append(" FROM gp_globeParam ");
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

