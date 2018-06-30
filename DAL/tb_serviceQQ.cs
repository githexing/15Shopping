using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_serviceQQ
	/// </summary>
	public partial class tb_serviceQQ
	{
		public tb_serviceQQ()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_serviceQQ");
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
		public long Add(lgk.Model.tb_serviceQQ model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_serviceQQ(");
            strSql.Append("ServiceName,QQnum,QQ001,QQ002,QQ003,QQType)");
			strSql.Append(" values (");
            strSql.Append("@ServiceName,@QQnum,@QQ001,@QQ002,@QQ003,@QQType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ServiceName", SqlDbType.VarChar,50),
					new SqlParameter("@QQnum", SqlDbType.VarChar,50),
					new SqlParameter("@QQ001", SqlDbType.VarChar,100),
					new SqlParameter("@QQ002", SqlDbType.VarChar,50),
					new SqlParameter("@QQ003", SqlDbType.VarChar,50),
                    new SqlParameter("@QQType", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ServiceName;
			parameters[1].Value = model.QQnum;
			parameters[2].Value = model.QQ001;
			parameters[3].Value = model.QQ002;
			parameters[4].Value = model.QQ003;
            parameters[5].Value = model.QQType;

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
		public bool Update(lgk.Model.tb_serviceQQ model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_serviceQQ set ");
			strSql.Append("ServiceName=@ServiceName,");
			strSql.Append("QQnum=@QQnum,");
			strSql.Append("QQ001=@QQ001,");
			strSql.Append("QQ002=@QQ002,");
			strSql.Append("QQ003=@QQ003,");
            strSql.Append("QQType=@QQType");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ServiceName", SqlDbType.VarChar,50),
					new SqlParameter("@QQnum", SqlDbType.VarChar,50),
					new SqlParameter("@QQ001", SqlDbType.VarChar,100),
					new SqlParameter("@QQ002", SqlDbType.VarChar,50),
					new SqlParameter("@QQ003", SqlDbType.VarChar,50),
                    new SqlParameter("@QQType", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.ServiceName;
			parameters[1].Value = model.QQnum;
			parameters[2].Value = model.QQ001;
			parameters[3].Value = model.QQ002;
			parameters[4].Value = model.QQ003;
            parameters[5].Value = model.QQType;
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
			strSql.Append("delete from tb_serviceQQ ");
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
			strSql.Append("delete from tb_serviceQQ ");
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
		public lgk.Model.tb_serviceQQ GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ID,ServiceName,QQnum,QQ001,QQ002,QQ003,QQType from tb_serviceQQ ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			lgk.Model.tb_serviceQQ model=new lgk.Model.tb_serviceQQ();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ServiceName"]!=null && ds.Tables[0].Rows[0]["ServiceName"].ToString()!="")
				{
					model.ServiceName=ds.Tables[0].Rows[0]["ServiceName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["QQnum"]!=null && ds.Tables[0].Rows[0]["QQnum"].ToString()!="")
				{
					model.QQnum=ds.Tables[0].Rows[0]["QQnum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["QQ001"]!=null && ds.Tables[0].Rows[0]["QQ001"].ToString()!="")
				{
					model.QQ001=ds.Tables[0].Rows[0]["QQ001"].ToString();
				}
				if(ds.Tables[0].Rows[0]["QQ002"]!=null && ds.Tables[0].Rows[0]["QQ002"].ToString()!="")
				{
					model.QQ002=ds.Tables[0].Rows[0]["QQ002"].ToString();
				}
				if(ds.Tables[0].Rows[0]["QQ003"]!=null && ds.Tables[0].Rows[0]["QQ003"].ToString()!="")
				{
					model.QQ003=ds.Tables[0].Rows[0]["QQ003"].ToString();
				}
                if (ds.Tables[0].Rows[0]["QQType"] != null && ds.Tables[0].Rows[0]["QQType"].ToString() != "")
                {
                    model.QQType = int.Parse(ds.Tables[0].Rows[0]["QQType"].ToString());
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
            strSql.Append("select ID,ServiceName,QQnum,QQ001,QQ002,QQ003,QQType ");
			strSql.Append(" FROM tb_serviceQQ ");
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
            strSql.Append(" ID,ServiceName,QQnum,QQ001,QQ002,QQ003,QQType ");
			strSql.Append(" FROM tb_serviceQQ ");
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
			parameters[0].Value = "tb_serviceQQ";
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

