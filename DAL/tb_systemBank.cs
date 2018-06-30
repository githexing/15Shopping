using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_systemBank
	/// </summary>
	public partial class tb_systemBank
	{
		public tb_systemBank()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "tb_systemBank"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_systemBank");
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
		public int Add(lgk.Model.tb_systemBank model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_systemBank set IsMor=0 ; insert into tb_systemBank(");
			strSql.Append("BankName,BankAddress,BankAccount,BankAccountUser,BankType,IsMor)");
			strSql.Append(" values (");
			strSql.Append("@BankName,@BankAddress,@BankAccount,@BankAccountUser,@BankType,@IsMor)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BankName", SqlDbType.VarChar,50),
					new SqlParameter("@BankAddress", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccountUser", SqlDbType.VarChar,50),
					new SqlParameter("@BankType", SqlDbType.Int,4),
                    new SqlParameter("@IsMor", SqlDbType.Int,4)
            };
			parameters[0].Value = model.BankName;
			parameters[1].Value = model.BankAddress;
			parameters[2].Value = model.BankAccount;
			parameters[3].Value = model.BankAccountUser;
			parameters[4].Value = model.BankType;
            parameters[5].Value = model.IsMor;
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
		public bool Update(lgk.Model.tb_systemBank model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_systemBank set ");
			strSql.Append("BankName=@BankName,");
			strSql.Append("BankAddress=@BankAddress,");
			strSql.Append("BankAccount=@BankAccount,");
			strSql.Append("BankAccountUser=@BankAccountUser,");
            strSql.Append("BankType=@BankType,");
            strSql.Append("Flag=@Flag");
            strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@BankName", SqlDbType.VarChar,50),
					new SqlParameter("@BankAddress", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccountUser", SqlDbType.VarChar,50),
                    new SqlParameter("@BankType", SqlDbType.Int,4),
                    new SqlParameter("@Flag", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.BankName;
			parameters[1].Value = model.BankAddress;
			parameters[2].Value = model.BankAccount;
			parameters[3].Value = model.BankAccountUser;
			parameters[4].Value = model.BankType;
            parameters[5].Value = model.Flag;
            parameters[6].Value = model.ID;

            int rows =DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			strSql.Append("delete from tb_systemBank ");
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
        /// 停用一条数据
        /// </summary>
        public bool Cancel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_systemBank set flag = 1 ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
			strSql.Append("delete from tb_systemBank ");
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
		public lgk.Model.tb_systemBank GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BankName,BankAddress,BankAccount,BankAccountUser,BankType,Flag from tb_systemBank ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			lgk.Model.tb_systemBank model=new lgk.Model.tb_systemBank();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BankName"]!=null && ds.Tables[0].Rows[0]["BankName"].ToString()!="")
				{
					model.BankName=ds.Tables[0].Rows[0]["BankName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankAddress"]!=null && ds.Tables[0].Rows[0]["BankAddress"].ToString()!="")
				{
					model.BankAddress=ds.Tables[0].Rows[0]["BankAddress"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankAccount"]!=null && ds.Tables[0].Rows[0]["BankAccount"].ToString()!="")
				{
					model.BankAccount=ds.Tables[0].Rows[0]["BankAccount"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankAccountUser"]!=null && ds.Tables[0].Rows[0]["BankAccountUser"].ToString()!="")
				{
					model.BankAccountUser=ds.Tables[0].Rows[0]["BankAccountUser"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankType"]!=null && ds.Tables[0].Rows[0]["BankType"].ToString()!="")
				{
					model.BankType=int.Parse(ds.Tables[0].Rows[0]["BankType"].ToString());
				}
                if (ds.Tables[0].Rows[0]["Flag"] != null && ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
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
        public lgk.Model.tb_systemBank GetModel(string bankname)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,BankName,BankAddress,BankAccount,BankAccountUser,BankType from tb_systemBank ");
            strSql.Append(" where BankName=@bankname");
            SqlParameter[] parameters = {
					new SqlParameter("@bankname", SqlDbType.VarChar,50)
};
            parameters[0].Value = bankname;

            lgk.Model.tb_systemBank model = new lgk.Model.tb_systemBank();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankName"] != null && ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                {
                    model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAddress"] != null && ds.Tables[0].Rows[0]["BankAddress"].ToString() != "")
                {
                    model.BankAddress = ds.Tables[0].Rows[0]["BankAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccount"] != null && ds.Tables[0].Rows[0]["BankAccount"].ToString() != "")
                {
                    model.BankAccount = ds.Tables[0].Rows[0]["BankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccountUser"] != null && ds.Tables[0].Rows[0]["BankAccountUser"].ToString() != "")
                {
                    model.BankAccountUser = ds.Tables[0].Rows[0]["BankAccountUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankType"] != null && ds.Tables[0].Rows[0]["BankType"].ToString() != "")
                {
                    model.BankType = int.Parse(ds.Tables[0].Rows[0]["BankType"].ToString());
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
        public lgk.Model.tb_systemBank GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,BankName,BankAddress,BankAccount,BankAccountUser,BankType from tb_systemBank ");
            strSql.Append(" order by ID desc");
            lgk.Model.tb_systemBank model = new lgk.Model.tb_systemBank();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankName"] != null && ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                {
                    model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAddress"] != null && ds.Tables[0].Rows[0]["BankAddress"].ToString() != "")
                {
                    model.BankAddress = ds.Tables[0].Rows[0]["BankAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccount"] != null && ds.Tables[0].Rows[0]["BankAccount"].ToString() != "")
                {
                    model.BankAccount = ds.Tables[0].Rows[0]["BankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccountUser"] != null && ds.Tables[0].Rows[0]["BankAccountUser"].ToString() != "")
                {
                    model.BankAccountUser = ds.Tables[0].Rows[0]["BankAccountUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankType"] != null && ds.Tables[0].Rows[0]["BankType"].ToString() != "")
                {
                    model.BankType = int.Parse(ds.Tables[0].Rows[0]["BankType"].ToString());
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
		public lgk.Model.tb_systemBank strGetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,BankName,BankAddress,BankAccount,BankAccountUser,BankType ");
			strSql.Append(" FROM tb_systemBank ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            lgk.Model.tb_systemBank model = new lgk.Model.tb_systemBank();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankName"] != null && ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                {
                    model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAddress"] != null && ds.Tables[0].Rows[0]["BankAddress"].ToString() != "")
                {
                    model.BankAddress = ds.Tables[0].Rows[0]["BankAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccount"] != null && ds.Tables[0].Rows[0]["BankAccount"].ToString() != "")
                {
                    model.BankAccount = ds.Tables[0].Rows[0]["BankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccountUser"] != null && ds.Tables[0].Rows[0]["BankAccountUser"].ToString() != "")
                {
                    model.BankAccountUser = ds.Tables[0].Rows[0]["BankAccountUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankType"] != null && ds.Tables[0].Rows[0]["BankType"].ToString() != "")
                {
                    model.BankType = int.Parse(ds.Tables[0].Rows[0]["BankType"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,BankName,BankAddress,BankAccount,BankAccountUser,BankType,IsMor ");
            strSql.Append(" FROM tb_systemBank ");
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
			strSql.Append(" ID,BankName,BankAddress,BankAccount,BankAccountUser,BankType ");
			strSql.Append(" FROM tb_systemBank ");
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
			parameters[0].Value = "tb_systemBank";
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

