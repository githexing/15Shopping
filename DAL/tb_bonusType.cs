using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_bonusType
	/// </summary>
	public partial class tb_bonusType
	{
		public tb_bonusType()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TypeID", "tb_bonusType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_bonusType");
			strSql.Append(" where TypeID=@TypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int,4)};
			parameters[0].Value = TypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(lgk.Model.tb_bonusType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_bonusType(");
			strSql.Append("TypeID,TypeName)");
			strSql.Append(" values (");
			strSql.Append("@TypeID,@TypeName)");
			SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.TypeID;
			parameters[1].Value = model.TypeName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_bonusType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_bonusType set ");
			strSql.Append("TypeName=@TypeName");
			strSql.Append(" where TypeID=@TypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TypeName", SqlDbType.VarChar,50),
					new SqlParameter("@TypeID", SqlDbType.Int,4)};
			parameters[0].Value = model.TypeName;
			parameters[1].Value = model.TypeID;

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
		public bool Delete(int TypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_bonusType ");
			strSql.Append(" where TypeID=@TypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int,4)};
			parameters[0].Value = TypeID;

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
		public bool DeleteList(string TypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_bonusType ");
			strSql.Append(" where TypeID in ("+TypeIDlist + ")  ");
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
		public lgk.Model.tb_bonusType GetModel(int TypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TypeID,TypeName from tb_bonusType ");
			strSql.Append(" where TypeID=@TypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int,4)};
			parameters[0].Value = TypeID;

			lgk.Model.tb_bonusType model=new lgk.Model.tb_bonusType();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["TypeID"]!=null && ds.Tables[0].Rows[0]["TypeID"].ToString()!="")
				{
					model.TypeID=int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TypeName"]!=null && ds.Tables[0].Rows[0]["TypeName"].ToString()!="")
				{
					model.TypeName=ds.Tables[0].Rows[0]["TypeName"].ToString();
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
            strSql.Append("select TypeID,TypeName,TypeNameEn ");
			strSql.Append(" FROM tb_bonusType ");
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
			strSql.Append(" TypeID,TypeName ");
			strSql.Append(" FROM tb_bonusType ");
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
			parameters[0].Value = "tb_bonusType";
			parameters[1].Value = "TypeID";
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

