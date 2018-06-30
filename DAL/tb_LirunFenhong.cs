using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using lgk.Model;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_LirunFenhong
	/// </summary>
	public partial class tb_LirunFenhong
	{
		public tb_LirunFenhong()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("LrfhID", "tb_LirunFenhong"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LrfhID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_LirunFenhong");
			strSql.Append(" where LrfhID=@LrfhID");
			SqlParameter[] parameters = {
					new SqlParameter("@LrfhID", SqlDbType.Int,4)
			};
			parameters[0].Value = LrfhID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(lgk.Model.tb_LirunFenhong model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_LirunFenhong(");
			strSql.Append("BonusMoney,FhRate,FhTime)");
			strSql.Append(" values (");
			strSql.Append("@BonusMoney,@FhRate,@FhTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BonusMoney", SqlDbType.Decimal,9),
					new SqlParameter("@FhRate", SqlDbType.Decimal,9),
					new SqlParameter("@FhTime", SqlDbType.DateTime)};
			parameters[0].Value = model.BonusMoney;
			parameters[1].Value = model.FhRate;
			parameters[2].Value = model.FhTime;

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
		public bool Update(lgk.Model.tb_LirunFenhong model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_LirunFenhong set ");
			strSql.Append("BonusMoney=@BonusMoney,");
			strSql.Append("FhRate=@FhRate,");
			strSql.Append("FhTime=@FhTime");
			strSql.Append(" where LrfhID=@LrfhID");
			SqlParameter[] parameters = {
					new SqlParameter("@BonusMoney", SqlDbType.Decimal,9),
					new SqlParameter("@FhRate", SqlDbType.Decimal,9),
					new SqlParameter("@FhTime", SqlDbType.DateTime),
					new SqlParameter("@LrfhID", SqlDbType.Int,4)};
			parameters[0].Value = model.BonusMoney;
			parameters[1].Value = model.FhRate;
			parameters[2].Value = model.FhTime;
			parameters[3].Value = model.LrfhID;

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
		public bool Delete(int LrfhID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_LirunFenhong ");
			strSql.Append(" where LrfhID=@LrfhID");
			SqlParameter[] parameters = {
					new SqlParameter("@LrfhID", SqlDbType.Int,4)
			};
			parameters[0].Value = LrfhID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string LrfhIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_LirunFenhong ");
			strSql.Append(" where LrfhID in ("+LrfhIDlist + ")  ");
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
		public lgk.Model.tb_LirunFenhong GetModel(int LrfhID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LrfhID,BonusMoney,FhRate,FhTime from tb_LirunFenhong ");
			strSql.Append(" where LrfhID=@LrfhID");
			SqlParameter[] parameters = {
					new SqlParameter("@LrfhID", SqlDbType.Int,4)
			};
			parameters[0].Value = LrfhID;

			lgk.Model.tb_LirunFenhong model=new lgk.Model.tb_LirunFenhong();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public lgk.Model.tb_LirunFenhong DataRowToModel(DataRow row)
		{
			lgk.Model.tb_LirunFenhong model=new lgk.Model.tb_LirunFenhong();
			if (row != null)
			{
				if(row["LrfhID"]!=null && row["LrfhID"].ToString()!="")
				{
					model.LrfhID=int.Parse(row["LrfhID"].ToString());
				}
				if(row["BonusMoney"]!=null && row["BonusMoney"].ToString()!="")
				{
					model.BonusMoney=decimal.Parse(row["BonusMoney"].ToString());
				}
				if(row["FhRate"]!=null && row["FhRate"].ToString()!="")
				{
					model.FhRate=decimal.Parse(row["FhRate"].ToString());
				}
				if(row["FhTime"]!=null && row["FhTime"].ToString()!="")
				{
					model.FhTime=DateTime.Parse(row["FhTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LrfhID,BonusMoney,FhRate,FhTime ");
			strSql.Append(" FROM tb_LirunFenhong ");
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
			strSql.Append(" LrfhID,BonusMoney,FhRate,FhTime ");
			strSql.Append(" FROM tb_LirunFenhong ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_LirunFenhong ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.LrfhID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_LirunFenhong T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			parameters[0].Value = "tb_LirunFenhong";
			parameters[1].Value = "LrfhID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

