using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_recharge
	/// </summary>
	public partial class tb_recharge
	{
		public tb_recharge()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_recharge");
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
		public long Add(lgk.Model.tb_recharge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_recharge(");
			strSql.Append("UserID,RechargeableMoney,RechargeStyle,Flag,RechargeDate,YuAmount,RechargeType,AgentID,Recharge001,Recharge002,Recharge003,Recharge004,Recharge005,Recharge006)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@RechargeableMoney,@RechargeStyle,@Flag,@RechargeDate,@YuAmount,@RechargeType,@AgentID,@Recharge001,@Recharge002,@Recharge003,@Recharge004,@Recharge005,@Recharge006)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@RechargeableMoney", SqlDbType.Decimal,9),
					new SqlParameter("@RechargeStyle", SqlDbType.Int,4),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@RechargeDate", SqlDbType.DateTime),
					new SqlParameter("@YuAmount", SqlDbType.Decimal,9),
					new SqlParameter("@RechargeType", SqlDbType.Int,4),
					new SqlParameter("@AgentID", SqlDbType.Int,4),
					new SqlParameter("@Recharge001", SqlDbType.Int,4),
					new SqlParameter("@Recharge002", SqlDbType.Int,4),
					new SqlParameter("@Recharge003", SqlDbType.VarChar,50),
					new SqlParameter("@Recharge004", SqlDbType.VarChar,50),
					new SqlParameter("@Recharge005", SqlDbType.Decimal,9),
					new SqlParameter("@Recharge006", SqlDbType.Decimal,9)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.RechargeableMoney;
			parameters[2].Value = model.RechargeStyle;
			parameters[3].Value = model.Flag;
			parameters[4].Value = model.RechargeDate;
			parameters[5].Value = model.YuAmount;
			parameters[6].Value = model.RechargeType;
			parameters[7].Value = model.AgentID;
			parameters[8].Value = model.Recharge001;
			parameters[9].Value = model.Recharge002;
			parameters[10].Value = model.Recharge003;
			parameters[11].Value = model.Recharge004;
			parameters[12].Value = model.Recharge005;
			parameters[13].Value = model.Recharge006;

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
		public bool Update(lgk.Model.tb_recharge model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_recharge set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("RechargeableMoney=@RechargeableMoney,");
			strSql.Append("RechargeStyle=@RechargeStyle,");
			strSql.Append("Flag=@Flag,");
			strSql.Append("RechargeDate=@RechargeDate,");
			strSql.Append("YuAmount=@YuAmount,");
			strSql.Append("RechargeType=@RechargeType,");
			strSql.Append("AgentID=@AgentID,");
			strSql.Append("Recharge001=@Recharge001,");
			strSql.Append("Recharge002=@Recharge002,");
			strSql.Append("Recharge003=@Recharge003,");
			strSql.Append("Recharge004=@Recharge004,");
			strSql.Append("Recharge005=@Recharge005,");
			strSql.Append("Recharge006=@Recharge006");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@RechargeableMoney", SqlDbType.Decimal,9),
					new SqlParameter("@RechargeStyle", SqlDbType.Int,4),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@RechargeDate", SqlDbType.DateTime),
					new SqlParameter("@YuAmount", SqlDbType.Decimal,9),
					new SqlParameter("@RechargeType", SqlDbType.Int,4),
					new SqlParameter("@AgentID", SqlDbType.Int,4),
					new SqlParameter("@Recharge001", SqlDbType.Int,4),
					new SqlParameter("@Recharge002", SqlDbType.Int,4),
					new SqlParameter("@Recharge003", SqlDbType.VarChar,50),
					new SqlParameter("@Recharge004", SqlDbType.VarChar,50),
					new SqlParameter("@Recharge005", SqlDbType.Decimal,9),
					new SqlParameter("@Recharge006", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.RechargeableMoney;
			parameters[2].Value = model.RechargeStyle;
			parameters[3].Value = model.Flag;
			parameters[4].Value = model.RechargeDate;
			parameters[5].Value = model.YuAmount;
			parameters[6].Value = model.RechargeType;
			parameters[7].Value = model.AgentID;
			parameters[8].Value = model.Recharge001;
			parameters[9].Value = model.Recharge002;
			parameters[10].Value = model.Recharge003;
			parameters[11].Value = model.Recharge004;
			parameters[12].Value = model.Recharge005;
			parameters[13].Value = model.Recharge006;
			parameters[14].Value = model.ID;

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
			strSql.Append("delete from tb_recharge ");
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
			strSql.Append("delete from tb_recharge ");
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


        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_recharge GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,RechargeableMoney,RechargeStyle,Flag,RechargeDate,YuAmount,RechargeType,AgentID,Recharge001,Recharge002,Recharge003,Recharge004,Recharge005,Recharge006 from tb_recharge ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
            parameters[0].Value = ID;

            lgk.Model.tb_recharge model = new lgk.Model.tb_recharge();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RechargeableMoney"] != null && ds.Tables[0].Rows[0]["RechargeableMoney"].ToString() != "")
                {
                    model.RechargeableMoney = decimal.Parse(ds.Tables[0].Rows[0]["RechargeableMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RechargeStyle"] != null && ds.Tables[0].Rows[0]["RechargeStyle"].ToString() != "")
                {
                    model.RechargeStyle = int.Parse(ds.Tables[0].Rows[0]["RechargeStyle"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag"] != null && ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RechargeDate"] != null && ds.Tables[0].Rows[0]["RechargeDate"].ToString() != "")
                {
                    model.RechargeDate = DateTime.Parse(ds.Tables[0].Rows[0]["RechargeDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["YuAmount"] != null && ds.Tables[0].Rows[0]["YuAmount"].ToString() != "")
                {
                    model.YuAmount = decimal.Parse(ds.Tables[0].Rows[0]["YuAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RechargeType"] != null && ds.Tables[0].Rows[0]["RechargeType"].ToString() != "")
                {
                    model.RechargeType = int.Parse(ds.Tables[0].Rows[0]["RechargeType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AgentID"] != null && ds.Tables[0].Rows[0]["AgentID"].ToString() != "")
                {
                    model.AgentID = int.Parse(ds.Tables[0].Rows[0]["AgentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Recharge001"] != null && ds.Tables[0].Rows[0]["Recharge001"].ToString() != "")
                {
                    model.Recharge001 = int.Parse(ds.Tables[0].Rows[0]["Recharge001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Recharge002"] != null && ds.Tables[0].Rows[0]["Recharge002"].ToString() != "")
                {
                    model.Recharge002 = int.Parse(ds.Tables[0].Rows[0]["Recharge002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Recharge003"] != null && ds.Tables[0].Rows[0]["Recharge003"].ToString() != "")
                {
                    model.Recharge003 = ds.Tables[0].Rows[0]["Recharge003"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Recharge004"] != null && ds.Tables[0].Rows[0]["Recharge004"].ToString() != "")
                {
                    model.Recharge004 = ds.Tables[0].Rows[0]["Recharge004"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Recharge005"] != null && ds.Tables[0].Rows[0]["Recharge005"].ToString() != "")
                {
                    model.Recharge005 = decimal.Parse(ds.Tables[0].Rows[0]["Recharge005"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Recharge006"] != null && ds.Tables[0].Rows[0]["Recharge006"].ToString() != "")
                {
                    model.Recharge006 = decimal.Parse(ds.Tables[0].Rows[0]["Recharge006"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        } 
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_recharge GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,RechargeableMoney,RechargeStyle,Flag,RechargeDate,YuAmount,RechargeType,AgentID,Recharge001,Recharge002,Recharge003,Recharge004,Recharge005,Recharge006 from tb_recharge ");
            if (strWhere.Trim() == "")
            {
                strSql.Append(" where " + strWhere);
            }
            
            lgk.Model.tb_recharge model = new lgk.Model.tb_recharge();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RechargeableMoney"] != null && ds.Tables[0].Rows[0]["RechargeableMoney"].ToString() != "")
                {
                    model.RechargeableMoney = decimal.Parse(ds.Tables[0].Rows[0]["RechargeableMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RechargeStyle"] != null && ds.Tables[0].Rows[0]["RechargeStyle"].ToString() != "")
                {
                    model.RechargeStyle = int.Parse(ds.Tables[0].Rows[0]["RechargeStyle"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag"] != null && ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RechargeDate"] != null && ds.Tables[0].Rows[0]["RechargeDate"].ToString() != "")
                {
                    model.RechargeDate = DateTime.Parse(ds.Tables[0].Rows[0]["RechargeDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["YuAmount"] != null && ds.Tables[0].Rows[0]["YuAmount"].ToString() != "")
                {
                    model.YuAmount = decimal.Parse(ds.Tables[0].Rows[0]["YuAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RechargeType"] != null && ds.Tables[0].Rows[0]["RechargeType"].ToString() != "")
                {
                    model.RechargeType = int.Parse(ds.Tables[0].Rows[0]["RechargeType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AgentID"] != null && ds.Tables[0].Rows[0]["AgentID"].ToString() != "")
                {
                    model.AgentID = int.Parse(ds.Tables[0].Rows[0]["AgentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Recharge001"] != null && ds.Tables[0].Rows[0]["Recharge001"].ToString() != "")
                {
                    model.Recharge001 = int.Parse(ds.Tables[0].Rows[0]["Recharge001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Recharge002"] != null && ds.Tables[0].Rows[0]["Recharge002"].ToString() != "")
                {
                    model.Recharge002 = int.Parse(ds.Tables[0].Rows[0]["Recharge002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Recharge003"] != null && ds.Tables[0].Rows[0]["Recharge003"].ToString() != "")
                {
                    model.Recharge003 = ds.Tables[0].Rows[0]["Recharge003"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Recharge004"] != null && ds.Tables[0].Rows[0]["Recharge004"].ToString() != "")
                {
                    model.Recharge004 = ds.Tables[0].Rows[0]["Recharge004"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Recharge005"] != null && ds.Tables[0].Rows[0]["Recharge005"].ToString() != "")
                {
                    model.Recharge005 = decimal.Parse(ds.Tables[0].Rows[0]["Recharge005"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Recharge006"] != null && ds.Tables[0].Rows[0]["Recharge006"].ToString() != "")
                {
                    model.Recharge006 = decimal.Parse(ds.Tables[0].Rows[0]["Recharge006"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserID,RechargeableMoney,RechargeStyle,Flag,RechargeDate,YuAmount,RechargeType,AgentID,Recharge001,Recharge002,Recharge003,Recharge004,Recharge005,Recharge006 ");
			strSql.Append(" FROM tb_recharge ");
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
			strSql.Append(" ID,UserID,RechargeableMoney,RechargeStyle,Flag,RechargeDate,YuAmount,RechargeType,AgentID,Recharge001,Recharge002,Recharge003,Recharge004,Recharge005,Recharge006 ");
			strSql.Append(" FROM tb_recharge ");
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
			parameters[0].Value = "tb_recharge";
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

