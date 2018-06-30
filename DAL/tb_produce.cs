using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_produce
	/// </summary>
	public partial class tb_produce
	{
		public tb_produce()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ProcudeID", "tb_produce"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProcudeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_produce");
			strSql.Append(" where ProcudeID=@ProcudeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProcudeID", SqlDbType.Int,4)
};
			parameters[0].Value = ProcudeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(lgk.Model.tb_produce model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_produce(");
			strSql.Append("ProcudeCode,procudeName,MarketPrice,MemberPrice,procudePV,picture,LinkURL,IsPutaway,Note)");
			strSql.Append(" values (");
			strSql.Append("@ProcudeCode,@procudeName,@MarketPrice,@MemberPrice,@procudePV,@picture,@LinkURL,@IsPutaway,@Note)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProcudeCode", SqlDbType.VarChar,50),
					new SqlParameter("@procudeName", SqlDbType.VarChar,50),
					new SqlParameter("@MarketPrice", SqlDbType.Decimal,9),
					new SqlParameter("@MemberPrice", SqlDbType.Decimal,9),
					new SqlParameter("@procudePV", SqlDbType.Int,4),
					new SqlParameter("@picture", SqlDbType.VarChar,100),
					new SqlParameter("@LinkURL", SqlDbType.VarChar,100),
					new SqlParameter("@IsPutaway", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.Text)};
			parameters[0].Value = model.ProcudeCode;
			parameters[1].Value = model.procudeName;
			parameters[2].Value = model.MarketPrice;
			parameters[3].Value = model.MemberPrice;
			parameters[4].Value = model.procudePV;
			parameters[5].Value = model.picture;
			parameters[6].Value = model.LinkURL;
			parameters[7].Value = model.IsPutaway;
			parameters[8].Value = model.Note;

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
		public bool Update(lgk.Model.tb_produce model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_produce set ");
			strSql.Append("ProcudeCode=@ProcudeCode,");
			strSql.Append("procudeName=@procudeName,");
			strSql.Append("MarketPrice=@MarketPrice,");
			strSql.Append("MemberPrice=@MemberPrice,");
			strSql.Append("procudePV=@procudePV,");
			strSql.Append("picture=@picture,");
			strSql.Append("LinkURL=@LinkURL,");
			strSql.Append("IsPutaway=@IsPutaway,");
			strSql.Append("Note=@Note");
			strSql.Append(" where ProcudeID=@ProcudeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProcudeCode", SqlDbType.VarChar,50),
					new SqlParameter("@procudeName", SqlDbType.VarChar,50),
					new SqlParameter("@MarketPrice", SqlDbType.Decimal,9),
					new SqlParameter("@MemberPrice", SqlDbType.Decimal,9),
					new SqlParameter("@procudePV", SqlDbType.Int,4),
					new SqlParameter("@picture", SqlDbType.VarChar,100),
					new SqlParameter("@LinkURL", SqlDbType.VarChar,100),
					new SqlParameter("@IsPutaway", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.Text),
					new SqlParameter("@ProcudeID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProcudeCode;
			parameters[1].Value = model.procudeName;
			parameters[2].Value = model.MarketPrice;
			parameters[3].Value = model.MemberPrice;
			parameters[4].Value = model.procudePV;
			parameters[5].Value = model.picture;
			parameters[6].Value = model.LinkURL;
			parameters[7].Value = model.IsPutaway;
			parameters[8].Value = model.Note;
			parameters[9].Value = model.ProcudeID;

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
		public bool Delete(int ProcudeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_produce ");
			strSql.Append(" where ProcudeID=@ProcudeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProcudeID", SqlDbType.Int,4)
};
			parameters[0].Value = ProcudeID;

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
		public bool DeleteList(string ProcudeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_produce ");
			strSql.Append(" where ProcudeID in ("+ProcudeIDlist + ")  ");
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
		public lgk.Model.tb_produce GetModel(int ProcudeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProcudeID,ProcudeCode,procudeName,MarketPrice,MemberPrice,procudePV,picture,LinkURL,IsPutaway,Note from tb_produce ");
			strSql.Append(" where ProcudeID=@ProcudeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProcudeID", SqlDbType.Int,4)
};
			parameters[0].Value = ProcudeID;

			lgk.Model.tb_produce model=new lgk.Model.tb_produce();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProcudeID"]!=null && ds.Tables[0].Rows[0]["ProcudeID"].ToString()!="")
				{
					model.ProcudeID=int.Parse(ds.Tables[0].Rows[0]["ProcudeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProcudeCode"]!=null && ds.Tables[0].Rows[0]["ProcudeCode"].ToString()!="")
				{
					model.ProcudeCode=ds.Tables[0].Rows[0]["ProcudeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["procudeName"]!=null && ds.Tables[0].Rows[0]["procudeName"].ToString()!="")
				{
					model.procudeName=ds.Tables[0].Rows[0]["procudeName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MarketPrice"]!=null && ds.Tables[0].Rows[0]["MarketPrice"].ToString()!="")
				{
					model.MarketPrice=decimal.Parse(ds.Tables[0].Rows[0]["MarketPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberPrice"]!=null && ds.Tables[0].Rows[0]["MemberPrice"].ToString()!="")
				{
					model.MemberPrice=decimal.Parse(ds.Tables[0].Rows[0]["MemberPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["procudePV"]!=null && ds.Tables[0].Rows[0]["procudePV"].ToString()!="")
				{
					model.procudePV=int.Parse(ds.Tables[0].Rows[0]["procudePV"].ToString());
				}
				if(ds.Tables[0].Rows[0]["picture"]!=null && ds.Tables[0].Rows[0]["picture"].ToString()!="")
				{
					model.picture=ds.Tables[0].Rows[0]["picture"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LinkURL"]!=null && ds.Tables[0].Rows[0]["LinkURL"].ToString()!="")
				{
					model.LinkURL=ds.Tables[0].Rows[0]["LinkURL"].ToString();
				}
				if(ds.Tables[0].Rows[0]["IsPutaway"]!=null && ds.Tables[0].Rows[0]["IsPutaway"].ToString()!="")
				{
					model.IsPutaway=int.Parse(ds.Tables[0].Rows[0]["IsPutaway"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
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
			strSql.Append("select ProcudeID,ProcudeCode,procudeName,MarketPrice,MemberPrice,procudePV,picture,LinkURL,IsPutaway,Note ");
			strSql.Append(" FROM tb_produce ");
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
			strSql.Append(" ProcudeID,ProcudeCode,procudeName,MarketPrice,MemberPrice,procudePV,picture,LinkURL,IsPutaway,Note ");
			strSql.Append(" FROM tb_produce ");
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
			parameters[0].Value = "tb_produce";
			parameters[1].Value = "ProcudeID";
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

