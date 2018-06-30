using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_change
	/// </summary>
	public partial class tb_change
	{
		public tb_change()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_change");
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
		public long  Add(lgk.Model.tb_change model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_change(");
			strSql.Append("UserID,ToUserType,ToUserID,ChangeType,MoneyType,Amount,ChangeDate,Change001,Change002,Change003,Change004,Change005,Change006)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@ToUserType,@ToUserID,@ChangeType,@MoneyType,@Amount,@ChangeDate,@Change001,@Change002,@Change003,@Change004,@Change005,@Change006)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@ToUserType", SqlDbType.Int,4),
					new SqlParameter("@ToUserID", SqlDbType.Int,4),
					new SqlParameter("@ChangeType", SqlDbType.Int,4),
					new SqlParameter("@MoneyType", SqlDbType.Int,4),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@ChangeDate", SqlDbType.DateTime),
					new SqlParameter("@Change001", SqlDbType.Int,4),
					new SqlParameter("@Change002", SqlDbType.Int,4),
					new SqlParameter("@Change003", SqlDbType.VarChar,50),
					new SqlParameter("@Change004", SqlDbType.VarChar,50),
					new SqlParameter("@Change005", SqlDbType.Decimal,9),
					new SqlParameter("@Change006", SqlDbType.Decimal,9)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.ToUserType;
			parameters[2].Value = model.ToUserID;
			parameters[3].Value = model.ChangeType;
			parameters[4].Value = model.MoneyType;
			parameters[5].Value = model.Amount;
			parameters[6].Value = model.ChangeDate;
			parameters[7].Value = model.Change001;
			parameters[8].Value = model.Change002;
			parameters[9].Value = model.Change003;
			parameters[10].Value = model.Change004;
			parameters[11].Value = model.Change005;
			parameters[12].Value = model.Change006;

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
		public bool Update(lgk.Model.tb_change model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_change set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("ToUserType=@ToUserType,");
			strSql.Append("ToUserID=@ToUserID,");
			strSql.Append("ChangeType=@ChangeType,");
			strSql.Append("MoneyType=@MoneyType,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("ChangeDate=@ChangeDate,");
			strSql.Append("Change001=@Change001,");
			strSql.Append("Change002=@Change002,");
			strSql.Append("Change003=@Change003,");
			strSql.Append("Change004=@Change004,");
			strSql.Append("Change005=@Change005,");
			strSql.Append("Change006=@Change006");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@ToUserType", SqlDbType.Int,4),
					new SqlParameter("@ToUserID", SqlDbType.Int,4),
					new SqlParameter("@ChangeType", SqlDbType.Int,4),
					new SqlParameter("@MoneyType", SqlDbType.Int,4),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@ChangeDate", SqlDbType.DateTime),
					new SqlParameter("@Change001", SqlDbType.Int,4),
					new SqlParameter("@Change002", SqlDbType.Int,4),
					new SqlParameter("@Change003", SqlDbType.VarChar,50),
					new SqlParameter("@Change004", SqlDbType.VarChar,50),
					new SqlParameter("@Change005", SqlDbType.Decimal,9),
					new SqlParameter("@Change006", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.ToUserType;
			parameters[2].Value = model.ToUserID;
			parameters[3].Value = model.ChangeType;
			parameters[4].Value = model.MoneyType;
			parameters[5].Value = model.Amount;
			parameters[6].Value = model.ChangeDate;
			parameters[7].Value = model.Change001;
			parameters[8].Value = model.Change002;
			parameters[9].Value = model.Change003;
			parameters[10].Value = model.Change004;
			parameters[11].Value = model.Change005;
			parameters[12].Value = model.Change006;
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
			strSql.Append("delete from tb_change ");
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
			strSql.Append("delete from tb_change ");
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
		public lgk.Model.tb_change GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,ToUserType,ToUserID,ChangeType,MoneyType,Amount,ChangeDate,Change001,Change002,Change003,Change004,Change005,Change006 from tb_change ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			lgk.Model.tb_change model=new lgk.Model.tb_change();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserID"]!=null && ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ToUserType"]!=null && ds.Tables[0].Rows[0]["ToUserType"].ToString()!="")
				{
					model.ToUserType=int.Parse(ds.Tables[0].Rows[0]["ToUserType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ToUserID"]!=null && ds.Tables[0].Rows[0]["ToUserID"].ToString()!="")
				{
					model.ToUserID=int.Parse(ds.Tables[0].Rows[0]["ToUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ChangeType"]!=null && ds.Tables[0].Rows[0]["ChangeType"].ToString()!="")
				{
					model.ChangeType=int.Parse(ds.Tables[0].Rows[0]["ChangeType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MoneyType"]!=null && ds.Tables[0].Rows[0]["MoneyType"].ToString()!="")
				{
					model.MoneyType=int.Parse(ds.Tables[0].Rows[0]["MoneyType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Amount"]!=null && ds.Tables[0].Rows[0]["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ChangeDate"]!=null && ds.Tables[0].Rows[0]["ChangeDate"].ToString()!="")
				{
					model.ChangeDate=DateTime.Parse(ds.Tables[0].Rows[0]["ChangeDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Change001"]!=null && ds.Tables[0].Rows[0]["Change001"].ToString()!="")
				{
					model.Change001=int.Parse(ds.Tables[0].Rows[0]["Change001"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Change002"]!=null && ds.Tables[0].Rows[0]["Change002"].ToString()!="")
				{
					model.Change002=int.Parse(ds.Tables[0].Rows[0]["Change002"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Change003"]!=null && ds.Tables[0].Rows[0]["Change003"].ToString()!="")
				{
					model.Change003=ds.Tables[0].Rows[0]["Change003"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Change004"]!=null && ds.Tables[0].Rows[0]["Change004"].ToString()!="")
				{
					model.Change004=ds.Tables[0].Rows[0]["Change004"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Change005"]!=null && ds.Tables[0].Rows[0]["Change005"].ToString()!="")
				{
					model.Change005=decimal.Parse(ds.Tables[0].Rows[0]["Change005"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Change006"]!=null && ds.Tables[0].Rows[0]["Change006"].ToString()!="")
				{
					model.Change006=decimal.Parse(ds.Tables[0].Rows[0]["Change006"].ToString());
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
			strSql.Append("select ID,UserID,ToUserType,ToUserID,ChangeType,MoneyType,Amount,ChangeDate,Change001,Change002,Change003,Change004,Change005,Change006 ");
			strSql.Append(" FROM tb_change ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// --1：原始币转给其他会员
        /// --2：释放币转给其他会员 
        /// --3：智能钱包转给其他会员
        /// </summary>
        public DataSet GetDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select c.*,u.UserCode,u.TrueName ");
            //strSql.Append(" FROM tb_change c,tb_user u WHERE c.ToUserID=u.UserID ");
            strSql.Append("SELECT c.UserID,u.UserCode,0 - Amount as Amount,ChangeDate,Change003,Change005,ChangeType,TrueName, case when ChangeType = 1 then '原始币' when ChangeType = 2 then  '余额' else  '锁仓' end as Currency  ");
            strSql.Append("FROM [tb_change] c ,tb_user u where c.toUserID = u.UserID ");
            strSql.Append("and c.UserID = " + strWhere);
            strSql.Append("union  ");
            strSql.Append("SELECT c.ToUserID,u.UserCode,Amount,ChangeDate,Change003,Change005,ChangeType,TrueName,case when ChangeType = 1 then '原始币' when ChangeType = 2 then  '余额' else  '锁仓' end as Currency  ");
            strSql.Append("FROM [tb_change] c ,tb_user u where c.UserID = u.UserID  ");
            strSql.Append("and c.ToUserID = " + strWhere);

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDataSet2(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c.*,u.UserCode,u.TrueName,u.NiceName ,t.TrueName toTrueName,t.UserCode toUserCode,t.nicename toNiceName ");
            strSql.Append(" FROM tb_change c,tb_user u  ");
            strSql.Append(" ,tb_user t WHERE c.UserID=u.UserID  and c.ToUserID = t.UserID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
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
			strSql.Append(" ID,UserID,ToUserType,ToUserID,ChangeType,MoneyType,Amount,ChangeDate,Change001,Change002,Change003,Change004,Change005,Change006 ");
			strSql.Append(" FROM tb_change ");
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
			parameters[0].Value = "tb_change";
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

