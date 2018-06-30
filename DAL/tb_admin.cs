using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_admin
	/// </summary>
	public partial class tb_admin
	{
		public tb_admin()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "tb_admin"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_admin");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(lgk.Model.tb_admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_admin(");
			strSql.Append("UserName,TrueName,Password,SecondPassword,ThirdPassword,Limits,AddDate)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@TrueName,@Password,@SecondPassword,@ThirdPassword,@Limits,@AddDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@SecondPassword", SqlDbType.VarChar,50),
					new SqlParameter("@ThirdPassword", SqlDbType.VarChar,50),
					new SqlParameter("@Limits", SqlDbType.VarChar),
					new SqlParameter("@AddDate", SqlDbType.DateTime)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.TrueName;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.SecondPassword;
			parameters[4].Value = model.ThirdPassword;
			parameters[5].Value = model.Limits;
			parameters[6].Value = model.AddDate;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(lgk.Model.tb_admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_admin set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("TrueName=@TrueName,");
			strSql.Append("Password=@Password,");
			strSql.Append("SecondPassword=@SecondPassword,");
			strSql.Append("ThirdPassword=@ThirdPassword,");
			strSql.Append("Limits=@Limits,");
			strSql.Append("AddDate=@AddDate");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@SecondPassword", SqlDbType.VarChar,50),
					new SqlParameter("@ThirdPassword", SqlDbType.VarChar,50),
					new SqlParameter("@Limits", SqlDbType.VarChar),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.TrueName;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.SecondPassword;
			parameters[4].Value = model.ThirdPassword;
			parameters[5].Value = model.Limits;
			parameters[6].Value = model.AddDate;
			parameters[7].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_admin ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_admin ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public lgk.Model.tb_admin GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserName,TrueName,Password,SecondPassword,ThirdPassword,Limits,AddDate from tb_admin ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			lgk.Model.tb_admin model=new lgk.Model.tb_admin();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserName"]!=null && ds.Tables[0].Rows[0]["UserName"].ToString()!="")
				{
					model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TrueName"]!=null && ds.Tables[0].Rows[0]["TrueName"].ToString()!="")
				{
					model.TrueName=ds.Tables[0].Rows[0]["TrueName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Password"]!=null && ds.Tables[0].Rows[0]["Password"].ToString()!="")
				{
					model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SecondPassword"]!=null && ds.Tables[0].Rows[0]["SecondPassword"].ToString()!="")
				{
					model.SecondPassword=ds.Tables[0].Rows[0]["SecondPassword"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ThirdPassword"]!=null && ds.Tables[0].Rows[0]["ThirdPassword"].ToString()!="")
				{
					model.ThirdPassword=ds.Tables[0].Rows[0]["ThirdPassword"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Limits"]!=null && ds.Tables[0].Rows[0]["Limits"].ToString()!="")
				{
					model.Limits=ds.Tables[0].Rows[0]["Limits"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AddDate"]!=null && ds.Tables[0].Rows[0]["AddDate"].ToString()!="")
				{
					model.AddDate=DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
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
        public lgk.Model.tb_admin GetModel(string code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserName,TrueName,Password,SecondPassword,ThirdPassword,Limits,AddDate from tb_admin ");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50)
};
            parameters[0].Value = code;

            lgk.Model.tb_admin model = new lgk.Model.tb_admin();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TrueName"] != null && ds.Tables[0].Rows[0]["TrueName"].ToString() != "")
                {
                    model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SecondPassword"] != null && ds.Tables[0].Rows[0]["SecondPassword"].ToString() != "")
                {
                    model.SecondPassword = ds.Tables[0].Rows[0]["SecondPassword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ThirdPassword"] != null && ds.Tables[0].Rows[0]["ThirdPassword"].ToString() != "")
                {
                    model.ThirdPassword = ds.Tables[0].Rows[0]["ThirdPassword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Limits"] != null && ds.Tables[0].Rows[0]["Limits"].ToString() != "")
                {
                    model.Limits = ds.Tables[0].Rows[0]["Limits"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddDate"] != null && ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserName,TrueName,Password,SecondPassword,ThirdPassword,Limits,AddDate ");
			strSql.Append(" FROM tb_admin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,UserName,TrueName,Password,SecondPassword,ThirdPassword,Limits,AddDate ");
			strSql.Append(" FROM tb_admin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_admin";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

