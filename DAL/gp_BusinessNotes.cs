using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:gp_BusinessNotes
	/// </summary>
	public partial class gp_BusinessNotes
	{
		public gp_BusinessNotes()
		{}
        /// <summary>
        /// 计算交易表中代售股票
        /// </summary>
        /// <param name="a">交易状态1 待交易，2 是已完成 3 是冻结 4 是已撤单</param>
        /// <param name="b">交易会员的类型 1 是前台会员 2 是后台会员</param>
        /// <param name="c">交易的类型1 是卖出 2是买入</param>
        /// <returns></returns>
        public object GetNum(int status, int usertype, int businesstype, int uid)
        {
            string sql = "select sum(BusinessAmount) from gp_BusinessNotes where Status = '" + status + "' and UserType = '" + usertype + "' and BusinessType = '" + businesstype + "'";
            if (uid != 0)
            {
                sql += " and UserID=" + uid;
            }
            object obj = DbHelperSQL.GetSingle(sql);
            return obj == null ? 0 : obj;
        }
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from gp_BusinessNotes");
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
		public long Add(lgk.Model.gp_BusinessNotes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into gp_BusinessNotes(");
			strSql.Append("UserID,UserCode,BusinessType,UserType,BusinessTime,BusinessAmount,BusinessPrice,SumMoney,Poundage,AmountMoney,InStockAccount,InBonusAccount,InManageAccount,FromUserID,FromUserCode,SucTime,Status,Notes01,Notes02,Notes03,Notes04,Notes05,Notes06)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@UserCode,@BusinessType,@UserType,@BusinessTime,@BusinessAmount,@BusinessPrice,@SumMoney,@Poundage,@AmountMoney,@InStockAccount,@InBonusAccount,@InManageAccount,@FromUserID,@FromUserCode,@SucTime,@Status,@Notes01,@Notes02,@Notes03,@Notes04,@Notes05,@Notes06)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@UserCode", SqlDbType.VarChar,50),
					new SqlParameter("@BusinessType", SqlDbType.Int,4),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@BusinessTime", SqlDbType.DateTime),
					new SqlParameter("@BusinessAmount", SqlDbType.Decimal,9),
					new SqlParameter("@BusinessPrice", SqlDbType.Decimal,9),
					new SqlParameter("@SumMoney", SqlDbType.Decimal,9),
					new SqlParameter("@Poundage", SqlDbType.Decimal,9),
					new SqlParameter("@AmountMoney", SqlDbType.Decimal,9),
					new SqlParameter("@InStockAccount", SqlDbType.Decimal,9),
					new SqlParameter("@InBonusAccount", SqlDbType.Decimal,9),
					new SqlParameter("@InManageAccount", SqlDbType.Decimal,9),
					new SqlParameter("@FromUserID", SqlDbType.BigInt,8),
					new SqlParameter("@FromUserCode", SqlDbType.VarChar,50),
					new SqlParameter("@SucTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Notes01", SqlDbType.Int,4),
					new SqlParameter("@Notes02", SqlDbType.Int,4),
					new SqlParameter("@Notes03", SqlDbType.Decimal,9),
					new SqlParameter("@Notes04", SqlDbType.Decimal,9),
					new SqlParameter("@Notes05", SqlDbType.VarChar,50),
					new SqlParameter("@Notes06", SqlDbType.VarChar,50)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.UserCode;
			parameters[2].Value = model.BusinessType;
			parameters[3].Value = model.UserType;
			parameters[4].Value = model.BusinessTime;
			parameters[5].Value = model.BusinessAmount;
			parameters[6].Value = model.BusinessPrice;
			parameters[7].Value = model.SumMoney;
			parameters[8].Value = model.Poundage;
			parameters[9].Value = model.AmountMoney;
			parameters[10].Value = model.InStockAccount;
			parameters[11].Value = model.InBonusAccount;
			parameters[12].Value = model.InManageAccount;
			parameters[13].Value = model.FromUserID;
			parameters[14].Value = model.FromUserCode;
			parameters[15].Value = model.SucTime;
			parameters[16].Value = model.Status;
			parameters[17].Value = model.Notes01;
			parameters[18].Value = model.Notes02;
			parameters[19].Value = model.Notes03;
			parameters[20].Value = model.Notes04;
			parameters[21].Value = model.Notes05;
			parameters[22].Value = model.Notes06;

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
		public bool Update(lgk.Model.gp_BusinessNotes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update gp_BusinessNotes set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserCode=@UserCode,");
			strSql.Append("BusinessType=@BusinessType,");
			strSql.Append("UserType=@UserType,");
			strSql.Append("BusinessTime=@BusinessTime,");
			strSql.Append("BusinessAmount=@BusinessAmount,");
			strSql.Append("BusinessPrice=@BusinessPrice,");
			strSql.Append("SumMoney=@SumMoney,");
			strSql.Append("Poundage=@Poundage,");
			strSql.Append("AmountMoney=@AmountMoney,");
			strSql.Append("InStockAccount=@InStockAccount,");
			strSql.Append("InBonusAccount=@InBonusAccount,");
			strSql.Append("InManageAccount=@InManageAccount,");
			strSql.Append("FromUserID=@FromUserID,");
			strSql.Append("FromUserCode=@FromUserCode,");
			strSql.Append("SucTime=@SucTime,");
			strSql.Append("Status=@Status,");
			strSql.Append("Notes01=@Notes01,");
			strSql.Append("Notes02=@Notes02,");
			strSql.Append("Notes03=@Notes03,");
			strSql.Append("Notes04=@Notes04,");
			strSql.Append("Notes05=@Notes05,");
			strSql.Append("Notes06=@Notes06");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@UserCode", SqlDbType.VarChar,50),
					new SqlParameter("@BusinessType", SqlDbType.Int,4),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@BusinessTime", SqlDbType.DateTime),
					new SqlParameter("@BusinessAmount", SqlDbType.Decimal,9),
					new SqlParameter("@BusinessPrice", SqlDbType.Decimal,9),
					new SqlParameter("@SumMoney", SqlDbType.Decimal,9),
					new SqlParameter("@Poundage", SqlDbType.Decimal,9),
					new SqlParameter("@AmountMoney", SqlDbType.Decimal,9),
					new SqlParameter("@InStockAccount", SqlDbType.Decimal,9),
					new SqlParameter("@InBonusAccount", SqlDbType.Decimal,9),
					new SqlParameter("@InManageAccount", SqlDbType.Decimal,9),
					new SqlParameter("@FromUserID", SqlDbType.BigInt,8),
					new SqlParameter("@FromUserCode", SqlDbType.VarChar,50),
					new SqlParameter("@SucTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Notes01", SqlDbType.Int,4),
					new SqlParameter("@Notes02", SqlDbType.Int,4),
					new SqlParameter("@Notes03", SqlDbType.Decimal,9),
					new SqlParameter("@Notes04", SqlDbType.Decimal,9),
					new SqlParameter("@Notes05", SqlDbType.VarChar,50),
					new SqlParameter("@Notes06", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.UserCode;
			parameters[2].Value = model.BusinessType;
			parameters[3].Value = model.UserType;
			parameters[4].Value = model.BusinessTime;
			parameters[5].Value = model.BusinessAmount;
			parameters[6].Value = model.BusinessPrice;
			parameters[7].Value = model.SumMoney;
			parameters[8].Value = model.Poundage;
			parameters[9].Value = model.AmountMoney;
			parameters[10].Value = model.InStockAccount;
			parameters[11].Value = model.InBonusAccount;
			parameters[12].Value = model.InManageAccount;
			parameters[13].Value = model.FromUserID;
			parameters[14].Value = model.FromUserCode;
			parameters[15].Value = model.SucTime;
			parameters[16].Value = model.Status;
			parameters[17].Value = model.Notes01;
			parameters[18].Value = model.Notes02;
			parameters[19].Value = model.Notes03;
			parameters[20].Value = model.Notes04;
			parameters[21].Value = model.Notes05;
			parameters[22].Value = model.Notes06;
			parameters[23].Value = model.ID;

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
			strSql.Append("delete from gp_BusinessNotes ");
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
			strSql.Append("delete from gp_BusinessNotes ");
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
		public lgk.Model.gp_BusinessNotes GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,UserCode,BusinessType,UserType,BusinessTime,BusinessAmount,BusinessPrice,SumMoney,Poundage,AmountMoney,InStockAccount,InBonusAccount,InManageAccount,FromUserID,FromUserCode,SucTime,Status,Notes01,Notes02,Notes03,Notes04,Notes05,Notes06 from gp_BusinessNotes ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			lgk.Model.gp_BusinessNotes model=new lgk.Model.gp_BusinessNotes();
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
				if(ds.Tables[0].Rows[0]["BusinessType"]!=null && ds.Tables[0].Rows[0]["BusinessType"].ToString()!="")
				{
					model.BusinessType=int.Parse(ds.Tables[0].Rows[0]["BusinessType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserType"]!=null && ds.Tables[0].Rows[0]["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BusinessTime"]!=null && ds.Tables[0].Rows[0]["BusinessTime"].ToString()!="")
				{
					model.BusinessTime=DateTime.Parse(ds.Tables[0].Rows[0]["BusinessTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BusinessAmount"]!=null && ds.Tables[0].Rows[0]["BusinessAmount"].ToString()!="")
				{
					model.BusinessAmount=decimal.Parse(ds.Tables[0].Rows[0]["BusinessAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BusinessPrice"]!=null && ds.Tables[0].Rows[0]["BusinessPrice"].ToString()!="")
				{
					model.BusinessPrice=decimal.Parse(ds.Tables[0].Rows[0]["BusinessPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SumMoney"]!=null && ds.Tables[0].Rows[0]["SumMoney"].ToString()!="")
				{
					model.SumMoney=decimal.Parse(ds.Tables[0].Rows[0]["SumMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Poundage"]!=null && ds.Tables[0].Rows[0]["Poundage"].ToString()!="")
				{
					model.Poundage=decimal.Parse(ds.Tables[0].Rows[0]["Poundage"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AmountMoney"]!=null && ds.Tables[0].Rows[0]["AmountMoney"].ToString()!="")
				{
					model.AmountMoney=decimal.Parse(ds.Tables[0].Rows[0]["AmountMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InStockAccount"]!=null && ds.Tables[0].Rows[0]["InStockAccount"].ToString()!="")
				{
					model.InStockAccount=decimal.Parse(ds.Tables[0].Rows[0]["InStockAccount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InBonusAccount"]!=null && ds.Tables[0].Rows[0]["InBonusAccount"].ToString()!="")
				{
					model.InBonusAccount=decimal.Parse(ds.Tables[0].Rows[0]["InBonusAccount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InManageAccount"]!=null && ds.Tables[0].Rows[0]["InManageAccount"].ToString()!="")
				{
					model.InManageAccount=decimal.Parse(ds.Tables[0].Rows[0]["InManageAccount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FromUserID"]!=null && ds.Tables[0].Rows[0]["FromUserID"].ToString()!="")
				{
					model.FromUserID=long.Parse(ds.Tables[0].Rows[0]["FromUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FromUserCode"]!=null && ds.Tables[0].Rows[0]["FromUserCode"].ToString()!="")
				{
					model.FromUserCode=ds.Tables[0].Rows[0]["FromUserCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SucTime"]!=null && ds.Tables[0].Rows[0]["SucTime"].ToString()!="")
				{
					model.SucTime=DateTime.Parse(ds.Tables[0].Rows[0]["SucTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Notes01"]!=null && ds.Tables[0].Rows[0]["Notes01"].ToString()!="")
				{
					model.Notes01=int.Parse(ds.Tables[0].Rows[0]["Notes01"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Notes02"]!=null && ds.Tables[0].Rows[0]["Notes02"].ToString()!="")
				{
					model.Notes02=int.Parse(ds.Tables[0].Rows[0]["Notes02"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Notes03"]!=null && ds.Tables[0].Rows[0]["Notes03"].ToString()!="")
				{
					model.Notes03=decimal.Parse(ds.Tables[0].Rows[0]["Notes03"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Notes04"]!=null && ds.Tables[0].Rows[0]["Notes04"].ToString()!="")
				{
					model.Notes04=decimal.Parse(ds.Tables[0].Rows[0]["Notes04"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Notes05"]!=null && ds.Tables[0].Rows[0]["Notes05"].ToString()!="")
				{
					model.Notes05=ds.Tables[0].Rows[0]["Notes05"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Notes06"]!=null && ds.Tables[0].Rows[0]["Notes06"].ToString()!="")
				{
					model.Notes06=ds.Tables[0].Rows[0]["Notes06"].ToString();
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
			strSql.Append("select ID,UserID,UserCode,BusinessType,UserType,BusinessTime,BusinessAmount,BusinessPrice,SumMoney,Poundage,AmountMoney,InStockAccount,InBonusAccount,InManageAccount,FromUserID,FromUserCode,SucTime,Status,Notes01,Notes02,Notes03,Notes04,Notes05,Notes06 ");
			strSql.Append(" FROM gp_BusinessNotes ");
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
			strSql.Append(" ID,UserID,UserCode,BusinessType,UserType,BusinessTime,BusinessAmount,BusinessPrice,SumMoney,Poundage,AmountMoney,InStockAccount,InBonusAccount,InManageAccount,FromUserID,FromUserCode,SucTime,Status,Notes01,Notes02,Notes03,Notes04,Notes05,Notes06 ");
			strSql.Append(" FROM gp_BusinessNotes ");
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
			parameters[0].Value = "gp_BusinessNotes";
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

