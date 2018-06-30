using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_userPro
	/// </summary>
	public partial class tb_userPro
	{
		public tb_userPro()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "tb_userPro"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_userPro");
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
		public int Add(lgk.Model.tb_userPro model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_userPro(");
			strSql.Append("UserID,LastLevel,EndLevel,ProMoney,AddDate,FlagDate,Remark,Flag,Pro001,Pro002,Pro003,Pro004,Pro005,Pro006,Pro007,Pro008)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@LastLevel,@EndLevel,@ProMoney,@AddDate,@FlagDate,@Remark,@Flag,@Pro001,@Pro002,@Pro003,@Pro004,@Pro005,@Pro006,@Pro007,@Pro008)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@LastLevel", SqlDbType.Int,4),
					new SqlParameter("@EndLevel", SqlDbType.Int,4),
					new SqlParameter("@ProMoney", SqlDbType.Decimal,9),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@FlagDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,100),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@Pro001", SqlDbType.Int,4),
					new SqlParameter("@Pro002", SqlDbType.Int,4),
					new SqlParameter("@Pro003", SqlDbType.Decimal,9),
					new SqlParameter("@Pro004", SqlDbType.Decimal,9),
					new SqlParameter("@Pro005", SqlDbType.Decimal,9),
					new SqlParameter("@Pro006", SqlDbType.VarChar,50),
					new SqlParameter("@Pro007", SqlDbType.VarChar,50),
					new SqlParameter("@Pro008", SqlDbType.VarChar,50)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.LastLevel;
			parameters[2].Value = model.EndLevel;
			parameters[3].Value = model.ProMoney;
			parameters[4].Value = model.AddDate;
			parameters[5].Value = model.FlagDate;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.Flag;
			parameters[8].Value = model.Pro001;
			parameters[9].Value = model.Pro002;
			parameters[10].Value = model.Pro003;
			parameters[11].Value = model.Pro004;
			parameters[12].Value = model.Pro005;
			parameters[13].Value = model.Pro006;
			parameters[14].Value = model.Pro007;
			parameters[15].Value = model.Pro008;

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
		public bool Update(lgk.Model.tb_userPro model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_userPro set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("LastLevel=@LastLevel,");
			strSql.Append("EndLevel=@EndLevel,");
			strSql.Append("ProMoney=@ProMoney,");
			strSql.Append("AddDate=@AddDate,");
			strSql.Append("FlagDate=@FlagDate,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("Flag=@Flag,");
			strSql.Append("Pro001=@Pro001,");
			strSql.Append("Pro002=@Pro002,");
			strSql.Append("Pro003=@Pro003,");
			strSql.Append("Pro004=@Pro004,");
			strSql.Append("Pro005=@Pro005,");
			strSql.Append("Pro006=@Pro006,");
			strSql.Append("Pro007=@Pro007,");
			strSql.Append("Pro008=@Pro008");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@LastLevel", SqlDbType.Int,4),
					new SqlParameter("@EndLevel", SqlDbType.Int,4),
					new SqlParameter("@ProMoney", SqlDbType.Decimal,9),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@FlagDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,100),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@Pro001", SqlDbType.Int,4),
					new SqlParameter("@Pro002", SqlDbType.Int,4),
					new SqlParameter("@Pro003", SqlDbType.Decimal,9),
					new SqlParameter("@Pro004", SqlDbType.Decimal,9),
					new SqlParameter("@Pro005", SqlDbType.Decimal,9),
					new SqlParameter("@Pro006", SqlDbType.VarChar,50),
					new SqlParameter("@Pro007", SqlDbType.VarChar,50),
					new SqlParameter("@Pro008", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.LastLevel;
			parameters[2].Value = model.EndLevel;
			parameters[3].Value = model.ProMoney;
			parameters[4].Value = model.AddDate;
			parameters[5].Value = model.FlagDate;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.Flag;
			parameters[8].Value = model.Pro001;
			parameters[9].Value = model.Pro002;
			parameters[10].Value = model.Pro003;
			parameters[11].Value = model.Pro004;
			parameters[12].Value = model.Pro005;
			parameters[13].Value = model.Pro006;
			parameters[14].Value = model.Pro007;
			parameters[15].Value = model.Pro008;
			parameters[16].Value = model.ID;

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
			strSql.Append("delete from tb_userPro ");
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
			strSql.Append("delete from tb_userPro ");
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
		public lgk.Model.tb_userPro GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,LastLevel,EndLevel,ProMoney,AddDate,FlagDate,Remark,Flag,Pro001,Pro002,Pro003,Pro004,Pro005,Pro006,Pro007,Pro008 from tb_userPro ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			lgk.Model.tb_userPro model=new lgk.Model.tb_userPro();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserID"]!=null && ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LastLevel"]!=null && ds.Tables[0].Rows[0]["LastLevel"].ToString()!="")
				{
					model.LastLevel=int.Parse(ds.Tables[0].Rows[0]["LastLevel"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndLevel"]!=null && ds.Tables[0].Rows[0]["EndLevel"].ToString()!="")
				{
					model.EndLevel=int.Parse(ds.Tables[0].Rows[0]["EndLevel"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProMoney"]!=null && ds.Tables[0].Rows[0]["ProMoney"].ToString()!="")
				{
					model.ProMoney=decimal.Parse(ds.Tables[0].Rows[0]["ProMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddDate"]!=null && ds.Tables[0].Rows[0]["AddDate"].ToString()!="")
				{
					model.AddDate=DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FlagDate"]!=null && ds.Tables[0].Rows[0]["FlagDate"].ToString()!="")
				{
					model.FlagDate=DateTime.Parse(ds.Tables[0].Rows[0]["FlagDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Flag"]!=null && ds.Tables[0].Rows[0]["Flag"].ToString()!="")
				{
					model.Flag=int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro001"]!=null && ds.Tables[0].Rows[0]["Pro001"].ToString()!="")
				{
					model.Pro001=int.Parse(ds.Tables[0].Rows[0]["Pro001"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro002"]!=null && ds.Tables[0].Rows[0]["Pro002"].ToString()!="")
				{
					model.Pro002=int.Parse(ds.Tables[0].Rows[0]["Pro002"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro003"]!=null && ds.Tables[0].Rows[0]["Pro003"].ToString()!="")
				{
					model.Pro003=decimal.Parse(ds.Tables[0].Rows[0]["Pro003"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro004"]!=null && ds.Tables[0].Rows[0]["Pro004"].ToString()!="")
				{
					model.Pro004=decimal.Parse(ds.Tables[0].Rows[0]["Pro004"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro005"]!=null && ds.Tables[0].Rows[0]["Pro005"].ToString()!="")
				{
					model.Pro005=decimal.Parse(ds.Tables[0].Rows[0]["Pro005"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro006"]!=null && ds.Tables[0].Rows[0]["Pro006"].ToString()!="")
				{
					model.Pro006=ds.Tables[0].Rows[0]["Pro006"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Pro007"]!=null && ds.Tables[0].Rows[0]["Pro007"].ToString()!="")
				{
					model.Pro007=ds.Tables[0].Rows[0]["Pro007"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Pro008"]!=null && ds.Tables[0].Rows[0]["Pro008"].ToString()!="")
				{
					model.Pro008=ds.Tables[0].Rows[0]["Pro008"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}
        public lgk.Model.tb_userPro GetModel(string strwhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,LastLevel,EndLevel,ProMoney,AddDate,FlagDate,Remark,Flag,Pro001,Pro002,Pro003,Pro004,Pro005,Pro006,Pro007,Pro008 from tb_userPro ");
            if (strwhere != "")
            {
                strSql.Append(" where "+ strwhere);
            }
            lgk.Model.tb_userPro model = new lgk.Model.tb_userPro();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLevel"] != null && ds.Tables[0].Rows[0]["LastLevel"].ToString() != "")
                {
                    model.LastLevel = int.Parse(ds.Tables[0].Rows[0]["LastLevel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndLevel"] != null && ds.Tables[0].Rows[0]["EndLevel"].ToString() != "")
                {
                    model.EndLevel = int.Parse(ds.Tables[0].Rows[0]["EndLevel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProMoney"] != null && ds.Tables[0].Rows[0]["ProMoney"].ToString() != "")
                {
                    model.ProMoney = decimal.Parse(ds.Tables[0].Rows[0]["ProMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"] != null && ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FlagDate"] != null && ds.Tables[0].Rows[0]["FlagDate"].ToString() != "")
                {
                    model.FlagDate = DateTime.Parse(ds.Tables[0].Rows[0]["FlagDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Flag"] != null && ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pro001"] != null && ds.Tables[0].Rows[0]["Pro001"].ToString() != "")
                {
                    model.Pro001 = int.Parse(ds.Tables[0].Rows[0]["Pro001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pro002"] != null && ds.Tables[0].Rows[0]["Pro002"].ToString() != "")
                {
                    model.Pro002 = int.Parse(ds.Tables[0].Rows[0]["Pro002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pro003"] != null && ds.Tables[0].Rows[0]["Pro003"].ToString() != "")
                {
                    model.Pro003 = decimal.Parse(ds.Tables[0].Rows[0]["Pro003"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pro004"] != null && ds.Tables[0].Rows[0]["Pro004"].ToString() != "")
                {
                    model.Pro004 = decimal.Parse(ds.Tables[0].Rows[0]["Pro004"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pro005"] != null && ds.Tables[0].Rows[0]["Pro005"].ToString() != "")
                {
                    model.Pro005 = decimal.Parse(ds.Tables[0].Rows[0]["Pro005"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pro006"] != null && ds.Tables[0].Rows[0]["Pro006"].ToString() != "")
                {
                    model.Pro006 = ds.Tables[0].Rows[0]["Pro006"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pro007"] != null && ds.Tables[0].Rows[0]["Pro007"].ToString() != "")
                {
                    model.Pro007 = ds.Tables[0].Rows[0]["Pro007"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pro008"] != null && ds.Tables[0].Rows[0]["Pro008"].ToString() != "")
                {
                    model.Pro008 = ds.Tables[0].Rows[0]["Pro008"].ToString();
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
        public lgk.Model.tb_userPro GetModelByUserID(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,LastLevel,EndLevel,ProMoney,AddDate,FlagDate,Remark,Flag,Pro001,Pro002,Pro003,Pro004,Pro005,Pro006,Pro007,Pro008 from tb_userPro");
            strSql.Append(" where UserID=@UserID order by ID desc");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
};
            parameters[0].Value = UserID;

            lgk.Model.tb_userPro model = new lgk.Model.tb_userPro();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLevel"] != null && ds.Tables[0].Rows[0]["LastLevel"].ToString() != "")
                {
                    model.LastLevel = int.Parse(ds.Tables[0].Rows[0]["LastLevel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndLevel"] != null && ds.Tables[0].Rows[0]["EndLevel"].ToString() != "")
                {
                    model.EndLevel = int.Parse(ds.Tables[0].Rows[0]["EndLevel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProMoney"] != null && ds.Tables[0].Rows[0]["ProMoney"].ToString() != "")
                {
                    model.ProMoney = decimal.Parse(ds.Tables[0].Rows[0]["ProMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"] != null && ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FlagDate"] != null && ds.Tables[0].Rows[0]["FlagDate"].ToString() != "")
                {
                    model.FlagDate = DateTime.Parse(ds.Tables[0].Rows[0]["FlagDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Flag"] != null && ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pro001"] != null && ds.Tables[0].Rows[0]["Pro001"].ToString() != "")
                {
                    model.Pro001 = int.Parse(ds.Tables[0].Rows[0]["Pro001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pro002"] != null && ds.Tables[0].Rows[0]["Pro002"].ToString() != "")
                {
                    model.Pro002 = int.Parse(ds.Tables[0].Rows[0]["Pro002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pro003"] != null && ds.Tables[0].Rows[0]["Pro003"].ToString() != "")
                {
                    model.Pro003 = decimal.Parse(ds.Tables[0].Rows[0]["Pro003"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pro004"] != null && ds.Tables[0].Rows[0]["Pro004"].ToString() != "")
                {
                    model.Pro004 = decimal.Parse(ds.Tables[0].Rows[0]["Pro004"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pro005"] != null && ds.Tables[0].Rows[0]["Pro005"].ToString() != "")
                {
                    model.Pro005 = decimal.Parse(ds.Tables[0].Rows[0]["Pro005"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pro006"] != null && ds.Tables[0].Rows[0]["Pro006"].ToString() != "")
                {
                    model.Pro006 = ds.Tables[0].Rows[0]["Pro006"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pro007"] != null && ds.Tables[0].Rows[0]["Pro007"].ToString() != "")
                {
                    model.Pro007 = ds.Tables[0].Rows[0]["Pro007"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pro008"] != null && ds.Tables[0].Rows[0]["Pro008"].ToString() != "")
                {
                    model.Pro008 = ds.Tables[0].Rows[0]["Pro008"].ToString();
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
			strSql.Append("select ID,UserID,LastLevel,EndLevel,ProMoney,AddDate,FlagDate,Remark,Flag,Pro001,Pro002,Pro003,Pro004,Pro005,Pro006,Pro007,Pro008 ");
			strSql.Append(" FROM tb_userPro ");
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
			strSql.Append(" ID,UserID,LastLevel,EndLevel,ProMoney,AddDate,FlagDate,Remark,Flag,Pro001,Pro002,Pro003,Pro004,Pro005,Pro006,Pro007,Pro008 ");
			strSql.Append(" FROM tb_userPro ");
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
			parameters[0].Value = "tb_userPro";
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

