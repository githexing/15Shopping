using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_mix
	/// </summary>
	public partial class tb_mix
	{
		public tb_mix()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_mix");
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
		public long Add(lgk.Model.tb_mix model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_mix(");
			strSql.Append("UserID,BonusID,Amount,AddTime,Source,FromUserID,Mix001,Mix002,Mix003,Mix004,Mix005,Mix006,Mix007)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@BonusID,@Amount,@AddTime,@Source,@FromUserID,@Mix001,@Mix002,@Mix003,@Mix004,@Mix005,@Mix006,@Mix007)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@BonusID", SqlDbType.Int,4),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Source", SqlDbType.VarChar,50),
					new SqlParameter("@FromUserID", SqlDbType.Int,4),
					new SqlParameter("@Mix001", SqlDbType.Int,4),
					new SqlParameter("@Mix002", SqlDbType.Int,4),
					new SqlParameter("@Mix003", SqlDbType.VarChar,50),
					new SqlParameter("@Mix004", SqlDbType.VarChar,50),
					new SqlParameter("@Mix005", SqlDbType.Decimal,9),
					new SqlParameter("@Mix006", SqlDbType.Decimal,9),
					new SqlParameter("@Mix007", SqlDbType.DateTime)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.BonusID;
			parameters[2].Value = model.Amount;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.Source;
			parameters[5].Value = model.FromUserID;
			parameters[6].Value = model.Mix001;
			parameters[7].Value = model.Mix002;
			parameters[8].Value = model.Mix003;
			parameters[9].Value = model.Mix004;
			parameters[10].Value = model.Mix005;
			parameters[11].Value = model.Mix006;
			parameters[12].Value = model.Mix007;

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
		public bool Update(lgk.Model.tb_mix model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_mix set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("BonusID=@BonusID,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("Source=@Source,");
			strSql.Append("FromUserID=@FromUserID,");
			strSql.Append("Mix001=@Mix001,");
			strSql.Append("Mix002=@Mix002,");
			strSql.Append("Mix003=@Mix003,");
			strSql.Append("Mix004=@Mix004,");
			strSql.Append("Mix005=@Mix005,");
			strSql.Append("Mix006=@Mix006,");
			strSql.Append("Mix007=@Mix007");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@BonusID", SqlDbType.Int,4),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Source", SqlDbType.VarChar,50),
					new SqlParameter("@FromUserID", SqlDbType.Int,4),
					new SqlParameter("@Mix001", SqlDbType.Int,4),
					new SqlParameter("@Mix002", SqlDbType.Int,4),
					new SqlParameter("@Mix003", SqlDbType.VarChar,50),
					new SqlParameter("@Mix004", SqlDbType.VarChar,50),
					new SqlParameter("@Mix005", SqlDbType.Decimal,9),
					new SqlParameter("@Mix006", SqlDbType.Decimal,9),
					new SqlParameter("@Mix007", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.BonusID;
			parameters[2].Value = model.Amount;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.Source;
			parameters[5].Value = model.FromUserID;
			parameters[6].Value = model.Mix001;
			parameters[7].Value = model.Mix002;
			parameters[8].Value = model.Mix003;
			parameters[9].Value = model.Mix004;
			parameters[10].Value = model.Mix005;
			parameters[11].Value = model.Mix006;
			parameters[12].Value = model.Mix007;
			parameters[13].Value = model.ID;

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
			strSql.Append("delete from tb_mix ");
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
			strSql.Append("delete from tb_mix ");
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
		public lgk.Model.tb_mix GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,BonusID,Amount,AddTime,Source,FromUserID,Mix001,Mix002,Mix003,Mix004,Mix005,Mix006,Mix007 from tb_mix ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			lgk.Model.tb_mix model=new lgk.Model.tb_mix();
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
				if(ds.Tables[0].Rows[0]["BonusID"]!=null && ds.Tables[0].Rows[0]["BonusID"].ToString()!="")
				{
					model.BonusID=int.Parse(ds.Tables[0].Rows[0]["BonusID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Amount"]!=null && ds.Tables[0].Rows[0]["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddTime"]!=null && ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Source"]!=null && ds.Tables[0].Rows[0]["Source"].ToString()!="")
				{
					model.Source=ds.Tables[0].Rows[0]["Source"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FromUserID"]!=null && ds.Tables[0].Rows[0]["FromUserID"].ToString()!="")
				{
					model.FromUserID=int.Parse(ds.Tables[0].Rows[0]["FromUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Mix001"]!=null && ds.Tables[0].Rows[0]["Mix001"].ToString()!="")
				{
					model.Mix001=int.Parse(ds.Tables[0].Rows[0]["Mix001"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Mix002"]!=null && ds.Tables[0].Rows[0]["Mix002"].ToString()!="")
				{
					model.Mix002=int.Parse(ds.Tables[0].Rows[0]["Mix002"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Mix003"]!=null && ds.Tables[0].Rows[0]["Mix003"].ToString()!="")
				{
					model.Mix003=ds.Tables[0].Rows[0]["Mix003"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Mix004"]!=null && ds.Tables[0].Rows[0]["Mix004"].ToString()!="")
				{
					model.Mix004=ds.Tables[0].Rows[0]["Mix004"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Mix005"]!=null && ds.Tables[0].Rows[0]["Mix005"].ToString()!="")
				{
					model.Mix005=decimal.Parse(ds.Tables[0].Rows[0]["Mix005"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Mix006"]!=null && ds.Tables[0].Rows[0]["Mix006"].ToString()!="")
				{
					model.Mix006=decimal.Parse(ds.Tables[0].Rows[0]["Mix006"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Mix007"]!=null && ds.Tables[0].Rows[0]["Mix007"].ToString()!="")
				{
					model.Mix007=DateTime.Parse(ds.Tables[0].Rows[0]["Mix007"].ToString());
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
			strSql.Append("select ID,UserID,BonusID,Amount,AddTime,Source,FromUserID,Mix001,Mix002,Mix003,Mix004,Mix005,Mix006,Mix007 ");
			strSql.Append(" FROM tb_mix ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetJoinList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select tb_mix.*,tb_user.UserCode,tb_user.TrueName,tb_user.AgentsID,tb_user.User006 
from tb_mix join tb_user on tb_mix.UserID=tb_user.UserID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
			strSql.Append(" ID,UserID,BonusID,Amount,AddTime,Source,FromUserID,Mix001,Mix002,Mix003,Mix004,Mix005,Mix006,Mix007 ");
			strSql.Append(" FROM tb_mix ");
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
			parameters[0].Value = "tb_mix";
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

