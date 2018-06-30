using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_remit
	/// </summary>
	public partial class tb_remit
	{
		public tb_remit()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_remit");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(lgk.Model.tb_remit model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_remit(");
            strSql.Append("BankName,BankAccount,BankAccountUser,RechargeableDate,AddDate,State,RemitMoney,YuAmount,Remark,UserID,Remit001,Remit002,Remit003,Remit004,Remit005,Remit006,Remit007");
            strSql.Append(") values (");
            strSql.Append("@BankName,@BankAccount,@BankAccountUser,@RechargeableDate,@AddDate,@State,@RemitMoney,@YuAmount,@Remark,@UserID,@Remit001,@Remit002,@Remit003,@Remit004,@Remit005,@Remit006,@Remit007");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@BankName", SqlDbType.VarChar,50),
                        new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
                        new SqlParameter("@BankAccountUser", SqlDbType.VarChar,50),
                        new SqlParameter("@RechargeableDate", SqlDbType.DateTime),
                        new SqlParameter("@AddDate", SqlDbType.DateTime),
                        new SqlParameter("@State", SqlDbType.Int,4),
                        new SqlParameter("@RemitMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@YuAmount", SqlDbType.Decimal,9),
                        new SqlParameter("@Remark", SqlDbType.VarChar,500),
                        new SqlParameter("@UserID", SqlDbType.BigInt,8),
                        new SqlParameter("@Remit001", SqlDbType.Int,4),
                        new SqlParameter("@Remit002", SqlDbType.Int,4),
                        new SqlParameter("@Remit003", SqlDbType.VarChar,50),
                        new SqlParameter("@Remit004", SqlDbType.VarChar,200),
                        new SqlParameter("@Remit005", SqlDbType.VarChar,500),
                        new SqlParameter("@Remit006", SqlDbType.Decimal,9),
                        new SqlParameter("@Remit007", SqlDbType.Int,4)
            };
            parameters[0].Value = model.BankName;
            parameters[1].Value = model.BankAccount;
            parameters[2].Value = model.BankAccountUser;
            parameters[3].Value = model.RechargeableDate;
            parameters[4].Value = model.AddDate;
            parameters[5].Value = model.State;
            parameters[6].Value = model.RemitMoney;
            parameters[7].Value = model.YuAmount;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.UserID;
            parameters[10].Value = model.Remit001;
            parameters[11].Value = model.Remit002;
            parameters[12].Value = model.Remit003;
            parameters[13].Value = model.Remit004;
            parameters[14].Value = model.Remit005;
            parameters[15].Value = model.Remit006;
            parameters[16].Value = model.Remit007;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return long.Parse(obj.ToString());
            }
		}
        public int AddBack(lgk.Model.tb_remitBack model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_remitBack(");
            strSql.Append("MemberID,OrderCode,Sign,Amount,ReturnCode,AddTime");
            strSql.Append(") values (");
            strSql.Append("@MemberID,@OrderCode,@Sign,@Amount,@ReturnCode,@AddTime");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@MemberID", SqlDbType.Int),
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,50),
                        new SqlParameter("@Sign", SqlDbType.VarChar,50),
                        new SqlParameter("@Amount", SqlDbType.Decimal),
                        new SqlParameter("@ReturnCode", SqlDbType.VarChar,50),
                        new SqlParameter("@AddTime", SqlDbType.DateTime)
            };
            parameters[0].Value = model.MemberID;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.Sign;
            parameters[3].Value = model.Amount;
            parameters[4].Value = model.ReturnCode;
            parameters[5].Value = model.AddTime;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj.ToString());
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_remit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_remit set ");
			strSql.Append("BankName=@BankName,");
			strSql.Append("BankAccount=@BankAccount,");
			strSql.Append("BankAccountUser=@BankAccountUser,");
			strSql.Append("RechargeableDate=@RechargeableDate,");
			strSql.Append("AddDate=@AddDate,");
			strSql.Append("State=@State,");
			strSql.Append("RemitMoney=@RemitMoney,");
			strSql.Append("YuAmount=@YuAmount,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("PassDate=@PassDate,");
			strSql.Append("Remit001=@Remit001,");
			strSql.Append("Remit002=@Remit002,");
			strSql.Append("Remit003=@Remit003,");
			strSql.Append("Remit004=@Remit004,");
			strSql.Append("Remit005=@Remit005,");
			strSql.Append("Remit006=@Remit006,");
            strSql.Append("Remit007=@Remit007");
            strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@BankName", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccountUser", SqlDbType.VarChar,50),
					new SqlParameter("@RechargeableDate", SqlDbType.DateTime),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@RemitMoney", SqlDbType.Decimal,9),
					new SqlParameter("@YuAmount", SqlDbType.Decimal,9),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@PassDate", SqlDbType.DateTime),
					new SqlParameter("@Remit001", SqlDbType.Int,4),
					new SqlParameter("@Remit002", SqlDbType.Int,4),
					new SqlParameter("@Remit003", SqlDbType.VarChar,50),
					new SqlParameter("@Remit004", SqlDbType.VarChar,200),
					new SqlParameter("@Remit005", SqlDbType.VarChar,500),
					new SqlParameter("@Remit006", SqlDbType.Decimal,9),
                    new SqlParameter("@Remit007", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.BankName;
			parameters[1].Value = model.BankAccount;
			parameters[2].Value = model.BankAccountUser;
			parameters[3].Value = model.RechargeableDate;
			parameters[4].Value = model.AddDate;
			parameters[5].Value = model.State;
			parameters[6].Value = model.RemitMoney;
			parameters[7].Value = model.YuAmount;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.UserID;
			parameters[10].Value = model.PassDate;
			parameters[11].Value = model.Remit001;
			parameters[12].Value = model.Remit002;
			parameters[13].Value = model.Remit003;
			parameters[14].Value = model.Remit004;
			parameters[15].Value = model.Remit005;
			parameters[16].Value = model.Remit006;
            parameters[17].Value = model.Remit007;
            parameters[18].Value = model.ID;

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
			strSql.Append("delete from tb_remit ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
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
        /// 撤销一条数据
        /// </summary>
        public bool Cancel(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_remit set State = -1");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt)};
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
			strSql.Append("delete from tb_remit ");
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
		public lgk.Model.tb_remit GetModel(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BankName,BankAccount,BankAccountUser,RechargeableDate,AddDate,State,RemitMoney,YuAmount,Remark,UserID,PassDate,Remit001,Remit002,Remit003,Remit004,Remit005,Remit006,Remit007 from tb_remit ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
			parameters[0].Value = ID;

			lgk.Model.tb_remit model=new lgk.Model.tb_remit();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BankName"]!=null && ds.Tables[0].Rows[0]["BankName"].ToString()!="")
				{
					model.BankName=ds.Tables[0].Rows[0]["BankName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankAccount"]!=null && ds.Tables[0].Rows[0]["BankAccount"].ToString()!="")
				{
					model.BankAccount=ds.Tables[0].Rows[0]["BankAccount"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankAccountUser"]!=null && ds.Tables[0].Rows[0]["BankAccountUser"].ToString()!="")
				{
					model.BankAccountUser=ds.Tables[0].Rows[0]["BankAccountUser"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RechargeableDate"]!=null && ds.Tables[0].Rows[0]["RechargeableDate"].ToString()!="")
				{
					model.RechargeableDate=DateTime.Parse(ds.Tables[0].Rows[0]["RechargeableDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddDate"]!=null && ds.Tables[0].Rows[0]["AddDate"].ToString()!="")
				{
					model.AddDate=DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["State"]!=null && ds.Tables[0].Rows[0]["State"].ToString()!="")
				{
					model.State=int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RemitMoney"]!=null && ds.Tables[0].Rows[0]["RemitMoney"].ToString()!="")
				{
					model.RemitMoney=decimal.Parse(ds.Tables[0].Rows[0]["RemitMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["YuAmount"]!=null && ds.Tables[0].Rows[0]["YuAmount"].ToString()!="")
				{
					model.YuAmount=decimal.Parse(ds.Tables[0].Rows[0]["YuAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UserID"]!=null && ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PassDate"]!=null && ds.Tables[0].Rows[0]["PassDate"].ToString()!="")
				{
					model.PassDate=DateTime.Parse(ds.Tables[0].Rows[0]["PassDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Remit001"]!=null && ds.Tables[0].Rows[0]["Remit001"].ToString()!="")
				{
					model.Remit001=int.Parse(ds.Tables[0].Rows[0]["Remit001"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Remit002"]!=null && ds.Tables[0].Rows[0]["Remit002"].ToString()!="")
				{
					model.Remit002=int.Parse(ds.Tables[0].Rows[0]["Remit002"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Remit003"]!=null && ds.Tables[0].Rows[0]["Remit003"].ToString()!="")
				{
					model.Remit003=ds.Tables[0].Rows[0]["Remit003"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Remit004"]!=null && ds.Tables[0].Rows[0]["Remit004"].ToString()!="")
				{
					model.Remit004=ds.Tables[0].Rows[0]["Remit004"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Remit005"]!=null && ds.Tables[0].Rows[0]["Remit005"].ToString()!="")
				{
					model.Remit005=ds.Tables[0].Rows[0]["Remit005"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Remit006"]!=null && ds.Tables[0].Rows[0]["Remit006"].ToString()!="")
				{
					model.Remit006=decimal.Parse(ds.Tables[0].Rows[0]["Remit006"].ToString());
				}
                if (ds.Tables[0].Rows[0]["Remit007"] != null && ds.Tables[0].Rows[0]["Remit007"].ToString() != "")
                {
                    model.Remit007 = int.Parse(ds.Tables[0].Rows[0]["Remit007"].ToString());
                }
                return model;
			}
			else
			{
				return null;
			}
		}
        public lgk.Model.tb_remitBack GetBack(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,MemberID,OrderCode,Sign,Amount,ReturnCode,AddTime from tb_remitBack ");
            if (where != "")
            {
                strSql.Append(" where " + where);

            }
            lgk.Model.tb_remitBack model = new lgk.Model.tb_remitBack();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MemberID"] != null && ds.Tables[0].Rows[0]["MemberID"].ToString() != "")
                {
                    model.MemberID = Convert.ToInt32(ds.Tables[0].Rows[0]["MemberID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderCode"] != null && ds.Tables[0].Rows[0]["OrderCode"].ToString() != "")
                {
                    model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sign"] != null && ds.Tables[0].Rows[0]["Sign"].ToString() != "")
                {
                    model.Sign = ds.Tables[0].Rows[0]["Sign"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Amount"] != null && ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = Convert.ToDecimal(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReturnCode"] != null && ds.Tables[0].Rows[0]["ReturnCode"].ToString() != "")
                {
                    model.ReturnCode = ds.Tables[0].Rows[0]["ReturnCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public lgk.Model.tb_remit GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,BankName,BankAccount,BankAccountUser,RechargeableDate,AddDate,State,RemitMoney,YuAmount,Remark,UserID,PassDate,Remit001,Remit002,Remit003,Remit004,Remit005,Remit006,Remit007 from tb_remit ");
            if (where != "")
            {
                strSql.Append(" where "+ where);
               
            }
            lgk.Model.tb_remit model = new lgk.Model.tb_remit();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankName"] != null && ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                {
                    model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccount"] != null && ds.Tables[0].Rows[0]["BankAccount"].ToString() != "")
                {
                    model.BankAccount = ds.Tables[0].Rows[0]["BankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccountUser"] != null && ds.Tables[0].Rows[0]["BankAccountUser"].ToString() != "")
                {
                    model.BankAccountUser = ds.Tables[0].Rows[0]["BankAccountUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RechargeableDate"] != null && ds.Tables[0].Rows[0]["RechargeableDate"].ToString() != "")
                {
                    model.RechargeableDate = DateTime.Parse(ds.Tables[0].Rows[0]["RechargeableDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"] != null && ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RemitMoney"] != null && ds.Tables[0].Rows[0]["RemitMoney"].ToString() != "")
                {
                    model.RemitMoney = decimal.Parse(ds.Tables[0].Rows[0]["RemitMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["YuAmount"] != null && ds.Tables[0].Rows[0]["YuAmount"].ToString() != "")
                {
                    model.YuAmount = decimal.Parse(ds.Tables[0].Rows[0]["YuAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PassDate"] != null && ds.Tables[0].Rows[0]["PassDate"].ToString() != "")
                {
                    model.PassDate = DateTime.Parse(ds.Tables[0].Rows[0]["PassDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remit001"] != null && ds.Tables[0].Rows[0]["Remit001"].ToString() != "")
                {
                    model.Remit001 = int.Parse(ds.Tables[0].Rows[0]["Remit001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remit002"] != null && ds.Tables[0].Rows[0]["Remit002"].ToString() != "")
                {
                    model.Remit002 = int.Parse(ds.Tables[0].Rows[0]["Remit002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remit003"] != null && ds.Tables[0].Rows[0]["Remit003"].ToString() != "")
                {
                    model.Remit003 = ds.Tables[0].Rows[0]["Remit003"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remit004"] != null && ds.Tables[0].Rows[0]["Remit004"].ToString() != "")
                {
                    model.Remit004 = ds.Tables[0].Rows[0]["Remit004"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remit005"] != null && ds.Tables[0].Rows[0]["Remit005"].ToString() != "")
                {
                    model.Remit005 = ds.Tables[0].Rows[0]["Remit005"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remit006"] != null && ds.Tables[0].Rows[0]["Remit006"].ToString() != "")
                {
                    model.Remit006 = decimal.Parse(ds.Tables[0].Rows[0]["Remit006"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remit007"] != null && ds.Tables[0].Rows[0]["Remit007"].ToString() != "")
                {
                    model.Remit007 = int.Parse(ds.Tables[0].Rows[0]["Remit007"].ToString());
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
			strSql.Append("select ID,BankName,BankAccount,BankAccountUser,RechargeableDate,AddDate,State,RemitMoney,YuAmount,Remark,UserID,PassDate,Remit001,Remit002,Remit003,Remit004,Remit005,Remit006,Remit007 ");
			strSql.Append(" FROM tb_remit ");
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
			strSql.Append(" ID,BankName,BankAccount,BankAccountUser,RechargeableDate,AddDate,State,RemitMoney,YuAmount,Remark,UserID,PassDate,Remit001,Remit002,Remit003,Remit004,Remit005,Remit006,Remit007 ");
			strSql.Append(" FROM tb_remit ");
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
			parameters[0].Value = "tb_remit";
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

