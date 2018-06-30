using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_leaveReMsg
	/// </summary>
	public partial class tb_leaveReMsg
	{
		public tb_leaveReMsg()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_leaveReMsg");
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
		public long Add(lgk.Model.tb_leaveReMsg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_leaveReMsg(");
			strSql.Append("LeaveID,ReContent,ReTime,UserType,UserID,UserCode)");
			strSql.Append(" values (");
			strSql.Append("@LeaveID,@ReContent,@ReTime,@UserType,@UserID,@UserCode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LeaveID", SqlDbType.BigInt,8),
					new SqlParameter("@ReContent", SqlDbType.Text),
					new SqlParameter("@ReTime", SqlDbType.DateTime),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@UserCode", SqlDbType.VarChar,20)};
			parameters[0].Value = model.LeaveID;
			parameters[1].Value = model.ReContent;
			parameters[2].Value = model.ReTime;
			parameters[3].Value = model.UserType;
			parameters[4].Value = model.UserID;
			parameters[5].Value = model.UserCode;

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
		public bool Update(lgk.Model.tb_leaveReMsg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_leaveReMsg set ");
			strSql.Append("LeaveID=@LeaveID,");
			strSql.Append("ReContent=@ReContent,");
			strSql.Append("ReTime=@ReTime,");
			strSql.Append("UserType=@UserType,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserCode=@UserCode");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@LeaveID", SqlDbType.BigInt,8),
					new SqlParameter("@ReContent", SqlDbType.Text),
					new SqlParameter("@ReTime", SqlDbType.DateTime),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@UserCode", SqlDbType.VarChar,20),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.LeaveID;
			parameters[1].Value = model.ReContent;
			parameters[2].Value = model.ReTime;
			parameters[3].Value = model.UserType;
			parameters[4].Value = model.UserID;
			parameters[5].Value = model.UserCode;
			parameters[6].Value = model.ID;

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
			strSql.Append("delete from tb_leaveReMsg ");
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
			strSql.Append("delete from tb_leaveReMsg ");
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
		public lgk.Model.tb_leaveReMsg GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,LeaveID,ReContent,ReTime,UserType,UserID,UserCode from tb_leaveReMsg ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			lgk.Model.tb_leaveReMsg model=new lgk.Model.tb_leaveReMsg();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LeaveID"]!=null && ds.Tables[0].Rows[0]["LeaveID"].ToString()!="")
				{
					model.LeaveID=long.Parse(ds.Tables[0].Rows[0]["LeaveID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReContent"]!=null && ds.Tables[0].Rows[0]["ReContent"].ToString()!="")
				{
					model.ReContent=ds.Tables[0].Rows[0]["ReContent"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ReTime"]!=null && ds.Tables[0].Rows[0]["ReTime"].ToString()!="")
				{
					model.ReTime=DateTime.Parse(ds.Tables[0].Rows[0]["ReTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserType"]!=null && ds.Tables[0].Rows[0]["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserID"]!=null && ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserCode"]!=null && ds.Tables[0].Rows[0]["UserCode"].ToString()!="")
				{
					model.UserCode=ds.Tables[0].Rows[0]["UserCode"].ToString();
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
			strSql.Append("select ID,LeaveID,ReContent,ReTime,UserType,UserID,UserCode ");
			strSql.Append(" FROM tb_leaveReMsg ");
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
			strSql.Append(" ID,LeaveID,ReContent,ReTime,UserType,UserID,UserCode ");
			strSql.Append(" FROM tb_leaveReMsg ");
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
			parameters[0].Value = "tb_leaveReMsg";
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

