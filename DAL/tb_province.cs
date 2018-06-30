using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_province
	/// </summary>
	public partial class tb_province
	{
		public tb_province()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(lgk.Model.tb_province model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_province(");
			strSql.Append("id,provinceID,province)");
			strSql.Append(" values (");
			strSql.Append("@id,@provinceID,@province)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@provinceID", SqlDbType.NVarChar,6),
					new SqlParameter("@province", SqlDbType.NVarChar,40)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.provinceID;
			parameters[2].Value = model.province;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_province model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_province set ");
			strSql.Append("id=@id,");
			strSql.Append("provinceID=@provinceID,");
			strSql.Append("province=@province");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@provinceID", SqlDbType.NVarChar,6),
					new SqlParameter("@province", SqlDbType.NVarChar,40)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.provinceID;
			parameters[2].Value = model.province;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_province ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

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
		/// 得到一个对象实体
		/// </summary>
		public lgk.Model.tb_province GetModel(string strWhere)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 id,provinceID,province,provinceen from tb_province ");
            if (strWhere.Trim() != "") 
            {
                strSql.Append(" where " + strWhere);
            }
			
			lgk.Model.tb_province model=new lgk.Model.tb_province();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["provinceID"]!=null && ds.Tables[0].Rows[0]["provinceID"].ToString()!="")
				{
					model.provinceID=ds.Tables[0].Rows[0]["provinceID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["province"]!=null && ds.Tables[0].Rows[0]["province"].ToString()!="")
				{
					model.province=ds.Tables[0].Rows[0]["province"].ToString();
				}
                if (ds.Tables[0].Rows[0]["provinceen"] != null && ds.Tables[0].Rows[0]["provinceen"].ToString() != "")
                {
                    model.provinceen = ds.Tables[0].Rows[0]["provinceen"].ToString();
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
            strSql.Append("select id,provinceID,province ,provinceen");
			strSql.Append(" FROM tb_province ");
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
			strSql.Append(" id,provinceID,province ");
			strSql.Append(" FROM tb_province ");
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
			parameters[0].Value = "tb_province";
			parameters[1].Value = "UserID";
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

