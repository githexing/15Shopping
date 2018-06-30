using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_systemMoney
	/// </summary>
	public partial class tb_systemMoney
	{
		public tb_systemMoney()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "tb_systemMoney"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_systemMoney");
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
		public int Add(lgk.Model.tb_systemMoney model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_systemMoney(");
			strSql.Append("MoneyAccount,AllBonusAccount,Money001,Money002)");
			strSql.Append(" values (");
			strSql.Append("@MoneyAccount,@AllBonusAccount,@Money001,@Money002)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MoneyAccount", SqlDbType.Decimal,9),
					new SqlParameter("@AllBonusAccount", SqlDbType.Decimal,9),
					new SqlParameter("@Money001", SqlDbType.Decimal,9),
					new SqlParameter("@Money002", SqlDbType.Decimal,9)};
			parameters[0].Value = model.MoneyAccount;
			parameters[1].Value = model.AllBonusAccount;
			parameters[2].Value = model.Money001;
			parameters[3].Value = model.Money002;

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
		public bool Update(lgk.Model.tb_systemMoney model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_systemMoney set ");
			strSql.Append("MoneyAccount=@MoneyAccount,");
			strSql.Append("AllBonusAccount=@AllBonusAccount,");
			strSql.Append("Money001=@Money001,");
			strSql.Append("Money002=@Money002");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@MoneyAccount", SqlDbType.Decimal,9),
					new SqlParameter("@AllBonusAccount", SqlDbType.Decimal,9),
					new SqlParameter("@Money001", SqlDbType.Decimal,9),
					new SqlParameter("@Money002", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.MoneyAccount;
			parameters[1].Value = model.AllBonusAccount;
			parameters[2].Value = model.Money001;
			parameters[3].Value = model.Money002;
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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_systemMoney ");
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
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_systemMoney ");
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
		public lgk.Model.tb_systemMoney GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,MoneyAccount,AllBonusAccount,Money001,Money002 from tb_systemMoney ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			lgk.Model.tb_systemMoney model=new lgk.Model.tb_systemMoney();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MoneyAccount"]!=null && ds.Tables[0].Rows[0]["MoneyAccount"].ToString()!="")
				{
					model.MoneyAccount=decimal.Parse(ds.Tables[0].Rows[0]["MoneyAccount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AllBonusAccount"]!=null && ds.Tables[0].Rows[0]["AllBonusAccount"].ToString()!="")
				{
					model.AllBonusAccount=decimal.Parse(ds.Tables[0].Rows[0]["AllBonusAccount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money001"]!=null && ds.Tables[0].Rows[0]["Money001"].ToString()!="")
				{
					model.Money001=decimal.Parse(ds.Tables[0].Rows[0]["Money001"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money002"]!=null && ds.Tables[0].Rows[0]["Money002"].ToString()!="")
				{
					model.Money002=decimal.Parse(ds.Tables[0].Rows[0]["Money002"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_systemMoney GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,MoneyAccount,AllBonusAccount,Money001,Money002 from tb_systemMoney ");

            lgk.Model.tb_systemMoney model = new lgk.Model.tb_systemMoney();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MoneyAccount"] != null && ds.Tables[0].Rows[0]["MoneyAccount"].ToString() != "")
                {
                    model.MoneyAccount = decimal.Parse(ds.Tables[0].Rows[0]["MoneyAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllBonusAccount"] != null && ds.Tables[0].Rows[0]["AllBonusAccount"].ToString() != "")
                {
                    model.AllBonusAccount = decimal.Parse(ds.Tables[0].Rows[0]["AllBonusAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Money001"] != null && ds.Tables[0].Rows[0]["Money001"].ToString() != "")
                {
                    model.Money001 = decimal.Parse(ds.Tables[0].Rows[0]["Money001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Money002"] != null && ds.Tables[0].Rows[0]["Money002"].ToString() != "")
                {
                    model.Money002 = decimal.Parse(ds.Tables[0].Rows[0]["Money002"].ToString());
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
			strSql.Append("select ID,MoneyAccount,AllBonusAccount,Money001,Money002 ");
			strSql.Append(" FROM tb_systemMoney ");
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
			strSql.Append(" ID,MoneyAccount,AllBonusAccount,Money001,Money002 ");
			strSql.Append(" FROM tb_systemMoney ");
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
			parameters[0].Value = "tb_systemMoney";
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

