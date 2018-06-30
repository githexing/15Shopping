using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_Link
	/// </summary>
	public partial class tb_Link
	{
		public tb_Link()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "tb_Link"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Link");
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
		public int Add(lgk.Model.tb_Link model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Link(");
			strSql.Append("LinkImage,LinkName,LinkUrl,Status,Link001,Link002)");
			strSql.Append(" values (");
			strSql.Append("@LinkImage,@LinkName,@LinkUrl,@Status,@Link001,@Link002)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LinkImage", SqlDbType.VarChar,100),
					new SqlParameter("@LinkName", SqlDbType.VarChar,50),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,100),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Link001", SqlDbType.VarChar,50),
					new SqlParameter("@Link002", SqlDbType.VarChar,50)};
			parameters[0].Value = model.LinkImage;
			parameters[1].Value = model.LinkName;
			parameters[2].Value = model.LinkUrl;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.Link001;
			parameters[5].Value = model.Link002;

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
		public bool Update(lgk.Model.tb_Link model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Link set ");
			strSql.Append("LinkImage=@LinkImage,");
			strSql.Append("LinkName=@LinkName,");
			strSql.Append("LinkUrl=@LinkUrl,");
			strSql.Append("Status=@Status,");
			strSql.Append("Link001=@Link001,");
			strSql.Append("Link002=@Link002");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@LinkImage", SqlDbType.VarChar,100),
					new SqlParameter("@LinkName", SqlDbType.VarChar,50),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,100),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Link001", SqlDbType.VarChar,50),
					new SqlParameter("@Link002", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.LinkImage;
			parameters[1].Value = model.LinkName;
			parameters[2].Value = model.LinkUrl;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.Link001;
			parameters[5].Value = model.Link002;
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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Link ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Link ");
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
		public lgk.Model.tb_Link GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,LinkImage,LinkName,LinkUrl,Status,Link001,Link002 from tb_Link ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			lgk.Model.tb_Link model=new lgk.Model.tb_Link();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LinkImage"]!=null && ds.Tables[0].Rows[0]["LinkImage"].ToString()!="")
				{
					model.LinkImage=ds.Tables[0].Rows[0]["LinkImage"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LinkName"]!=null && ds.Tables[0].Rows[0]["LinkName"].ToString()!="")
				{
					model.LinkName=ds.Tables[0].Rows[0]["LinkName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LinkUrl"]!=null && ds.Tables[0].Rows[0]["LinkUrl"].ToString()!="")
				{
					model.LinkUrl=ds.Tables[0].Rows[0]["LinkUrl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Link001"]!=null && ds.Tables[0].Rows[0]["Link001"].ToString()!="")
				{
					model.Link001=ds.Tables[0].Rows[0]["Link001"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Link002"]!=null && ds.Tables[0].Rows[0]["Link002"].ToString()!="")
				{
					model.Link002=ds.Tables[0].Rows[0]["Link002"].ToString();
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
			strSql.Append("select ID,LinkImage,LinkName,LinkUrl,Status,Link001,Link002 ");
			strSql.Append(" FROM tb_Link ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
		/// 获得数据
		/// </summary>
		public DataSet GetList( string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,LinkUrl,LinkImage ");
            strSql.Append(" FROM tb_Link ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
			strSql.Append(" ID,LinkImage,LinkName,LinkUrl,Status,Link001,Link002 ");
			strSql.Append(" FROM tb_Link ");
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
			strSql.Append("select count(1) FROM tb_Link ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Link T ");
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
			parameters[0].Value = "tb_Link";
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

