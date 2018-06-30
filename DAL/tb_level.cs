using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_level
	/// </summary>
	public partial class tb_level
	{
		public tb_level()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("LevelID", "tb_level"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LevelID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_level");
			strSql.Append(" where LevelID=@LevelID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4)};
			parameters[0].Value = LevelID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(lgk.Model.tb_level model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_level(");
			strSql.Append("LevelID,LevelName,RegMoney,level01,level02,level03,level04,level05,level06,level07,level08)");
			strSql.Append(" values (");
			strSql.Append("@LevelID,@LevelName,@RegMoney,@level01,@level02,@level03,@level04,@level05,@level06,@level07,@level08)");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4),
					new SqlParameter("@LevelName", SqlDbType.VarChar,50),
					new SqlParameter("@RegMoney", SqlDbType.Decimal,9),
					new SqlParameter("@level01", SqlDbType.Int,4),
					new SqlParameter("@level02", SqlDbType.Int,4),
					new SqlParameter("@level03", SqlDbType.VarChar,50),
					new SqlParameter("@level04", SqlDbType.VarChar,50),
					new SqlParameter("@level05", SqlDbType.Decimal,9),
					new SqlParameter("@level06", SqlDbType.Decimal,9),
					new SqlParameter("@level07", SqlDbType.Decimal,9),
					new SqlParameter("@level08", SqlDbType.Decimal,9)};
			parameters[0].Value = model.LevelID;
			parameters[1].Value = model.LevelName;
			parameters[2].Value = model.RegMoney;
			parameters[3].Value = model.level01;
			parameters[4].Value = model.level02;
			parameters[5].Value = model.level03;
			parameters[6].Value = model.level04;
			parameters[7].Value = model.level05;
			parameters[8].Value = model.level06;
			parameters[9].Value = model.level07;
			parameters[10].Value = model.level08;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_level model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_level set ");
			strSql.Append("LevelName=@LevelName,");
			strSql.Append("RegMoney=@RegMoney,");
			strSql.Append("level01=@level01,");
			strSql.Append("level02=@level02,");
			strSql.Append("level03=@level03,");
			strSql.Append("level04=@level04,");
			strSql.Append("level05=@level05,");
			strSql.Append("level06=@level06,");
			strSql.Append("level07=@level07,");
			strSql.Append("level08=@level08");
			strSql.Append(" where LevelID=@LevelID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelName", SqlDbType.VarChar,50),
					new SqlParameter("@RegMoney", SqlDbType.Decimal,9),
					new SqlParameter("@level01", SqlDbType.Int,4),
					new SqlParameter("@level02", SqlDbType.Int,4),
					new SqlParameter("@level03", SqlDbType.VarChar,50),
					new SqlParameter("@level04", SqlDbType.VarChar,50),
					new SqlParameter("@level05", SqlDbType.Decimal,9),
					new SqlParameter("@level06", SqlDbType.Decimal,9),
					new SqlParameter("@level07", SqlDbType.Decimal,9),
					new SqlParameter("@level08", SqlDbType.Decimal,9),
					new SqlParameter("@LevelID", SqlDbType.Int,4)};
			parameters[0].Value = model.LevelName;
			parameters[1].Value = model.RegMoney;
			parameters[2].Value = model.level01;
			parameters[3].Value = model.level02;
			parameters[4].Value = model.level03;
			parameters[5].Value = model.level04;
			parameters[6].Value = model.level05;
			parameters[7].Value = model.level06;
			parameters[8].Value = model.level07;
			parameters[9].Value = model.level08;
			parameters[10].Value = model.LevelID;

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
		public bool Delete(int LevelID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_level ");
			strSql.Append(" where LevelID=@LevelID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4)};
			parameters[0].Value = LevelID;

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
		public bool DeleteList(string LevelIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_level ");
			strSql.Append(" where LevelID in ("+LevelIDlist + ")  ");
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
		public lgk.Model.tb_level GetModel(int LevelID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LevelID,LevelName,RegMoney,level01,level02,level03,level04,level05,level06,level07,level08 from tb_level ");
			strSql.Append(" where LevelID=@LevelID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4)};
			parameters[0].Value = LevelID;

			lgk.Model.tb_level model=new lgk.Model.tb_level();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["LevelID"]!=null && ds.Tables[0].Rows[0]["LevelID"].ToString()!="")
				{
					model.LevelID=int.Parse(ds.Tables[0].Rows[0]["LevelID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LevelName"]!=null && ds.Tables[0].Rows[0]["LevelName"].ToString()!="")
				{
					model.LevelName=ds.Tables[0].Rows[0]["LevelName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RegMoney"]!=null && ds.Tables[0].Rows[0]["RegMoney"].ToString()!="")
				{
					model.RegMoney=decimal.Parse(ds.Tables[0].Rows[0]["RegMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["level01"]!=null && ds.Tables[0].Rows[0]["level01"].ToString()!="")
				{
					model.level01=int.Parse(ds.Tables[0].Rows[0]["level01"].ToString());
				}
				if(ds.Tables[0].Rows[0]["level02"]!=null && ds.Tables[0].Rows[0]["level02"].ToString()!="")
				{
					model.level02=int.Parse(ds.Tables[0].Rows[0]["level02"].ToString());
				}
				if(ds.Tables[0].Rows[0]["level03"]!=null && ds.Tables[0].Rows[0]["level03"].ToString()!="")
				{
					model.level03=ds.Tables[0].Rows[0]["level03"].ToString();
				}
				if(ds.Tables[0].Rows[0]["level04"]!=null && ds.Tables[0].Rows[0]["level04"].ToString()!="")
				{
					model.level04=ds.Tables[0].Rows[0]["level04"].ToString();
				}
				if(ds.Tables[0].Rows[0]["level05"]!=null && ds.Tables[0].Rows[0]["level05"].ToString()!="")
				{
					model.level05=decimal.Parse(ds.Tables[0].Rows[0]["level05"].ToString());
				}
				if(ds.Tables[0].Rows[0]["level06"]!=null && ds.Tables[0].Rows[0]["level06"].ToString()!="")
				{
					model.level06=decimal.Parse(ds.Tables[0].Rows[0]["level06"].ToString());
				}
				if(ds.Tables[0].Rows[0]["level07"]!=null && ds.Tables[0].Rows[0]["level07"].ToString()!="")
				{
					model.level07=decimal.Parse(ds.Tables[0].Rows[0]["level07"].ToString());
				}
				if(ds.Tables[0].Rows[0]["level08"]!=null && ds.Tables[0].Rows[0]["level08"].ToString()!="")
				{
					model.level08=decimal.Parse(ds.Tables[0].Rows[0]["level08"].ToString());
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
			strSql.Append("select LevelID,LevelName,RegMoney,level01,level02,level03,level04,level05,level06,level07,level08 ");
			strSql.Append(" FROM tb_level ");
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
			strSql.Append(" LevelID,LevelName,RegMoney,level01,level02,level03,level04,level05,level06,level07,level08 ");
			strSql.Append(" FROM tb_level ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 根据给定的等级ID，获取会员等级名称en-us。
        /// </summary>
        /// <param name="iLevelID"></param>
        /// <param name="strLanguage"></param>
        /// <returns></returns>
        public string GetLevelName(int iLevelID, string strLanguage)
        {
            StringBuilder strSql = new StringBuilder();
            if (strLanguage == "en-us")
                strSql.Append("SELECT [level03] FROM tb_level");
            else
                strSql.Append("SELECT [LevelName] FROM tb_level");
            strSql.Append(" WHERE LevelID=@LevelID");
            SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4)};
            parameters[0].Value = iLevelID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string GetLevelName(int LevelID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 LevelName from tb_level");
            strSql.Append(" where LevelID=@LevelID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4)};
            parameters[0].Value = LevelID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
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
			parameters[0].Value = "tb_level";
			parameters[1].Value = "LevelID";
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

