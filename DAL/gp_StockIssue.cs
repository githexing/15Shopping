using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:gp_StockIssue
	/// </summary>
	public partial class gp_StockIssue
	{
		public gp_StockIssue()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from gp_StockIssue");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 更新可交易股票
        /// </summary>
        /// <param name="id"></param>
        /// <param name="money"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int UpdateSurplusAmount(int id, decimal money, int where)
        {
            string sql = "";

            if (where == 0)
            {
                sql = "update gp_StockIssue set SurplusAmount=SurplusAmount-" + money + " where  ID=" + id;
            }
            else
            {
                sql = "update gp_StockIssue set SurplusAmount=SurplusAmount+" + money + " where  ID=" + id;
            }
            return DbHelperSQL.ExecuteSql(sql);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(lgk.Model.gp_StockIssue model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into gp_StockIssue(");
            strSql.Append("Issueamount,Surplusamount,Saleamount,Addtime");
            strSql.Append(") values (");
            strSql.Append("@Issueamount,@Surplusamount,@Saleamount,@Addtime");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Issueamount", SqlDbType.Decimal,9),
                        new SqlParameter("@Surplusamount", SqlDbType.Decimal,9),
                        new SqlParameter("@Saleamount", SqlDbType.Decimal,9),
                        new SqlParameter("@Addtime", SqlDbType.DateTime)
            };
            parameters[0].Value = model.IssueAmount;
            parameters[1].Value = model.SurplusAmount;
            parameters[2].Value = model.SaleAmount;
            parameters[3].Value = model.AddTime;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
		public bool Update(lgk.Model.gp_StockIssue model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update gp_StockIssue set ");
            strSql.Append(" Issueamount = @Issueamount,");
            strSql.Append(" Surplusamount = @Surplusamount,");
            strSql.Append(" Saleamount = @Saleamount,");
            strSql.Append(" Addtime = @Addtime");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4),
                        new SqlParameter("@Issueamount", SqlDbType.Decimal,9),
                        new SqlParameter("@Surplusamount", SqlDbType.Decimal,9),
                        new SqlParameter("@Saleamount", SqlDbType.Decimal,9),
                        new SqlParameter("@Addtime", SqlDbType.DateTime)
            };
            parameters[0].Value = model.Id;
            parameters[1].Value = model.IssueAmount;
            parameters[2].Value = model.SurplusAmount;
            parameters[3].Value = model.SaleAmount;
            parameters[4].Value = model.AddTime;
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
		public bool Delete(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from gp_StockIssue ");
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
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from gp_StockIssue ");
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
		public lgk.Model.gp_StockIssue GetModel(long ID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Issueamount, Surplusamount, Saleamount, Addtime  ");
            strSql.Append("  from gp_StockIssue ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            lgk.Model.gp_StockIssue model = new lgk.Model.gp_StockIssue();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Issueamount"].ToString() != "")
                {
                    model.IssueAmount = decimal.Parse(ds.Tables[0].Rows[0]["Issueamount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Surplusamount"].ToString() != "")
                {
                    model.SurplusAmount = decimal.Parse(ds.Tables[0].Rows[0]["Surplusamount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Saleamount"].ToString() != "")
                {
                    model.SaleAmount = decimal.Parse(ds.Tables[0].Rows[0]["Saleamount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Addtime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["Addtime"].ToString());
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
        public lgk.Model.gp_StockIssue GetModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Issueamount, Surplusamount, Saleamount, Addtime  ");
            strSql.Append(" from gp_StockIssue ");

            lgk.Model.gp_StockIssue model = new lgk.Model.gp_StockIssue();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Issueamount"].ToString() != "")
                {
                    model.IssueAmount = decimal.Parse(ds.Tables[0].Rows[0]["Issueamount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Surplusamount"].ToString() != "")
                {
                    model.SurplusAmount = decimal.Parse(ds.Tables[0].Rows[0]["Surplusamount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Saleamount"].ToString() != "")
                {
                    model.SaleAmount = decimal.Parse(ds.Tables[0].Rows[0]["Saleamount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Addtime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["Addtime"].ToString());
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
			strSql.Append("select ID,IssueAmount,SurplusAmount,SaleAmount,AddTime ");
			strSql.Append(" FROM gp_StockIssue ");
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
			strSql.Append(" ID,IssueAmount,SurplusAmount,SaleAmount,AddTime ");
			strSql.Append(" FROM gp_StockIssue ");
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
			parameters[0].Value = "gp_StockIssue";
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

