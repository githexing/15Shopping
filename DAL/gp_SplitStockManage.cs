using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:gp_SplitStockManage
	/// </summary>
	public partial class gp_SplitStockManage
	{
		public gp_SplitStockManage()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from gp_SplitStockManage");
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
		public long Add(lgk.Model.gp_SplitStockManage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into gp_SplitStockManage(");
			strSql.Append("UserID,UserCode,SplitQStock,SplitSStock,SplitHStock,SplitStockTime,SplitRate,OpenMoney,Split01,Split02,Split03,Split04,Split05,Split06)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@UserCode,@SplitQStock,@SplitSStock,@SplitHStock,@SplitStockTime,@SplitRate,@OpenMoney,@Split01,@Split02,@Split03,@Split04,@Split05,@Split06)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@UserCode", SqlDbType.VarChar,50),
					new SqlParameter("@SplitQStock", SqlDbType.Decimal,9),
					new SqlParameter("@SplitSStock", SqlDbType.Decimal,9),
					new SqlParameter("@SplitHStock", SqlDbType.Decimal,9),
					new SqlParameter("@SplitStockTime", SqlDbType.DateTime),
					new SqlParameter("@SplitRate", SqlDbType.Decimal,9),
					new SqlParameter("@OpenMoney", SqlDbType.Decimal,9),
					new SqlParameter("@Split01", SqlDbType.Int,4),
					new SqlParameter("@Split02", SqlDbType.Int,4),
					new SqlParameter("@Split03", SqlDbType.Decimal,9),
					new SqlParameter("@Split04", SqlDbType.Decimal,9),
					new SqlParameter("@Split05", SqlDbType.DateTime),
					new SqlParameter("@Split06", SqlDbType.VarChar,50)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.UserCode;
			parameters[2].Value = model.SplitQStock;
			parameters[3].Value = model.SplitSStock;
			parameters[4].Value = model.SplitHStock;
			parameters[5].Value = model.SplitStockTime;
			parameters[6].Value = model.SplitRate;
			parameters[7].Value = model.OpenMoney;
			parameters[8].Value = model.Split01;
			parameters[9].Value = model.Split02;
			parameters[10].Value = model.Split03;
			parameters[11].Value = model.Split04;
			parameters[12].Value = model.Split05;
			parameters[13].Value = model.Split06;

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
		public bool Update(lgk.Model.gp_SplitStockManage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update gp_SplitStockManage set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserCode=@UserCode,");
			strSql.Append("SplitQStock=@SplitQStock,");
			strSql.Append("SplitSStock=@SplitSStock,");
			strSql.Append("SplitHStock=@SplitHStock,");
			strSql.Append("SplitStockTime=@SplitStockTime,");
			strSql.Append("SplitRate=@SplitRate,");
			strSql.Append("OpenMoney=@OpenMoney,");
			strSql.Append("Split01=@Split01,");
			strSql.Append("Split02=@Split02,");
			strSql.Append("Split03=@Split03,");
			strSql.Append("Split04=@Split04,");
			strSql.Append("Split05=@Split05,");
			strSql.Append("Split06=@Split06");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@UserCode", SqlDbType.VarChar,50),
					new SqlParameter("@SplitQStock", SqlDbType.Decimal,9),
					new SqlParameter("@SplitSStock", SqlDbType.Decimal,9),
					new SqlParameter("@SplitHStock", SqlDbType.Decimal,9),
					new SqlParameter("@SplitStockTime", SqlDbType.DateTime),
					new SqlParameter("@SplitRate", SqlDbType.Decimal,9),
					new SqlParameter("@OpenMoney", SqlDbType.Decimal,9),
					new SqlParameter("@Split01", SqlDbType.Int,4),
					new SqlParameter("@Split02", SqlDbType.Int,4),
					new SqlParameter("@Split03", SqlDbType.Decimal,9),
					new SqlParameter("@Split04", SqlDbType.Decimal,9),
					new SqlParameter("@Split05", SqlDbType.DateTime),
					new SqlParameter("@Split06", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.UserCode;
			parameters[2].Value = model.SplitQStock;
			parameters[3].Value = model.SplitSStock;
			parameters[4].Value = model.SplitHStock;
			parameters[5].Value = model.SplitStockTime;
			parameters[6].Value = model.SplitRate;
			parameters[7].Value = model.OpenMoney;
			parameters[8].Value = model.Split01;
			parameters[9].Value = model.Split02;
			parameters[10].Value = model.Split03;
			parameters[11].Value = model.Split04;
			parameters[12].Value = model.Split05;
			parameters[13].Value = model.Split06;
			parameters[14].Value = model.ID;

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
			strSql.Append("delete from gp_SplitStockManage ");
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
			strSql.Append("delete from gp_SplitStockManage ");
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
		public lgk.Model.gp_SplitStockManage GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,UserCode,SplitQStock,SplitSStock,SplitHStock,SplitStockTime,SplitRate,OpenMoney,Split01,Split02,Split03,Split04,Split05,Split06 from gp_SplitStockManage ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			lgk.Model.gp_SplitStockManage model=new lgk.Model.gp_SplitStockManage();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserID"]!=null && ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserCode"]!=null && ds.Tables[0].Rows[0]["UserCode"].ToString()!="")
				{
					model.UserCode=ds.Tables[0].Rows[0]["UserCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SplitQStock"]!=null && ds.Tables[0].Rows[0]["SplitQStock"].ToString()!="")
				{
					model.SplitQStock=decimal.Parse(ds.Tables[0].Rows[0]["SplitQStock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SplitSStock"]!=null && ds.Tables[0].Rows[0]["SplitSStock"].ToString()!="")
				{
					model.SplitSStock=decimal.Parse(ds.Tables[0].Rows[0]["SplitSStock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SplitHStock"]!=null && ds.Tables[0].Rows[0]["SplitHStock"].ToString()!="")
				{
					model.SplitHStock=decimal.Parse(ds.Tables[0].Rows[0]["SplitHStock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SplitStockTime"]!=null && ds.Tables[0].Rows[0]["SplitStockTime"].ToString()!="")
				{
					model.SplitStockTime=DateTime.Parse(ds.Tables[0].Rows[0]["SplitStockTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SplitRate"]!=null && ds.Tables[0].Rows[0]["SplitRate"].ToString()!="")
				{
					model.SplitRate=decimal.Parse(ds.Tables[0].Rows[0]["SplitRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OpenMoney"]!=null && ds.Tables[0].Rows[0]["OpenMoney"].ToString()!="")
				{
					model.OpenMoney=decimal.Parse(ds.Tables[0].Rows[0]["OpenMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Split01"]!=null && ds.Tables[0].Rows[0]["Split01"].ToString()!="")
				{
					model.Split01=int.Parse(ds.Tables[0].Rows[0]["Split01"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Split02"]!=null && ds.Tables[0].Rows[0]["Split02"].ToString()!="")
				{
					model.Split02=int.Parse(ds.Tables[0].Rows[0]["Split02"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Split03"]!=null && ds.Tables[0].Rows[0]["Split03"].ToString()!="")
				{
					model.Split03=decimal.Parse(ds.Tables[0].Rows[0]["Split03"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Split04"]!=null && ds.Tables[0].Rows[0]["Split04"].ToString()!="")
				{
					model.Split04=decimal.Parse(ds.Tables[0].Rows[0]["Split04"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Split05"]!=null && ds.Tables[0].Rows[0]["Split05"].ToString()!="")
				{
					model.Split05=DateTime.Parse(ds.Tables[0].Rows[0]["Split05"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Split06"]!=null && ds.Tables[0].Rows[0]["Split06"].ToString()!="")
				{
					model.Split06=ds.Tables[0].Rows[0]["Split06"].ToString();
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
			strSql.Append("select ID,UserID,UserCode,SplitQStock,SplitSStock,SplitHStock,SplitStockTime,SplitRate,OpenMoney,Split01,Split02,Split03,Split04,Split05,Split06 ");
			strSql.Append(" FROM gp_SplitStockManage ");
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
			strSql.Append(" ID,UserID,UserCode,SplitQStock,SplitSStock,SplitHStock,SplitStockTime,SplitRate,OpenMoney,Split01,Split02,Split03,Split04,Split05,Split06 ");
			strSql.Append(" FROM gp_SplitStockManage ");
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
			parameters[0].Value = "gp_SplitStockManage";
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

