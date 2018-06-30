using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:gp_BusinessAmount
	/// </summary>
	public partial class gp_BusinessAmount
	{
		public gp_BusinessAmount()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(DateTime date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from gp_BusinessAmount");
            strSql.Append(" where BusinessTime=@date");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.DateTime)
};
            parameters[0].Value = date;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from gp_BusinessAmount");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(lgk.Model.gp_BusinessAmount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into gp_BusinessAmount(");
			strSql.Append("BusinessTime,BusinessAmount,by01,by02)");
			strSql.Append(" values (");
			strSql.Append("@BusinessTime,@BusinessAmount,@by01,@by02)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BusinessTime", SqlDbType.DateTime),
					new SqlParameter("@BusinessAmount", SqlDbType.Decimal,9),
					new SqlParameter("@by01", SqlDbType.Int,4),
					new SqlParameter("@by02", SqlDbType.Decimal,9)};
			parameters[0].Value = model.BusinessTime;
			parameters[1].Value = model.BusinessAmount;
			parameters[2].Value = model.by01;
			parameters[3].Value = model.by02;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(lgk.Model.gp_BusinessAmount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update gp_BusinessAmount set ");
			strSql.Append("BusinessTime=@BusinessTime,");
			strSql.Append("BusinessAmount=@BusinessAmount,");
			strSql.Append("by01=@by01,");
			strSql.Append("by02=@by02");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@BusinessTime", SqlDbType.DateTime),
					new SqlParameter("@BusinessAmount", SqlDbType.Decimal,9),
					new SqlParameter("@by01", SqlDbType.Int,4),
					new SqlParameter("@by02", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.BusinessTime;
			parameters[1].Value = model.BusinessAmount;
			parameters[2].Value = model.by01;
			parameters[3].Value = model.by02;
			parameters[4].Value = model.ID;

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
		public bool Delete(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from gp_BusinessAmount ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
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
			strSql.Append("delete from gp_BusinessAmount ");
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
		public lgk.Model.gp_BusinessAmount GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BusinessTime,BusinessAmount,by01,by02 from gp_BusinessAmount ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			lgk.Model.gp_BusinessAmount model=new lgk.Model.gp_BusinessAmount();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BusinessTime"]!=null && ds.Tables[0].Rows[0]["BusinessTime"].ToString()!="")
				{
					model.BusinessTime=DateTime.Parse(ds.Tables[0].Rows[0]["BusinessTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BusinessAmount"]!=null && ds.Tables[0].Rows[0]["BusinessAmount"].ToString()!="")
				{
					model.BusinessAmount=decimal.Parse(ds.Tables[0].Rows[0]["BusinessAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["by01"]!=null && ds.Tables[0].Rows[0]["by01"].ToString()!="")
				{
					model.by01=int.Parse(ds.Tables[0].Rows[0]["by01"].ToString());
				}
				if(ds.Tables[0].Rows[0]["by02"]!=null && ds.Tables[0].Rows[0]["by02"].ToString()!="")
				{
					model.by02=decimal.Parse(ds.Tables[0].Rows[0]["by02"].ToString());
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
			strSql.Append("select ID,BusinessTime,BusinessAmount,by01,by02 ");
			strSql.Append(" FROM gp_BusinessAmount ");
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
			strSql.Append(" ID,BusinessTime,BusinessAmount,by01,by02 ");
			strSql.Append(" FROM gp_BusinessAmount ");
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
			parameters[0].Value = "gp_BusinessAmount";
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

