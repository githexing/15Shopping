using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_StockIssue
    /// </summary>
    public partial class tb_StockIssue
    {
        public tb_StockIssue()
		{ }
        #region Method

        /// <summary>
        /// 得到最大发行期数。
        /// </summary>
        private int GetMaxPeriods()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(Periods)+1 FROM [tb_StockIssue]");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());

            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                return 1;
            else
                return Convert.ToInt32(obj.ToString());
        }

        /// <summary>
        /// 根据给定的ID，判断是否存在该记录。
        /// </summary>
        /// <param name="IssueID">给定的ID</param>
        /// <returns></returns>
        public bool Exists(int IssueID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_StockIssue");
            strSql.Append(" where ");
            strSql.Append(" IssueID = @IssueID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@IssueID", SqlDbType.Int,4)};
            parameters[0].Value = IssueID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据给定的ID，判断是否存在该记录。
        /// </summary>
        /// <param name="IssueID">给定的ID</param>
        /// <returns></returns>
        public bool Exists()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_StockIssue WHERE IsSell = 1");

            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 根据给定的条件，判断记录是否存在。
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM tb_StockIssue");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }

            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_StockIssue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_StockIssue(");
            strSql.Append("IssueAmount,SurplusAmount,IssuePrice,Periods,AddDate,IsSell");
            strSql.Append(") values (");
            strSql.Append("@IssueAmount,@SurplusAmount,@IssuePrice,@Periods,@AddDate,@IsSell");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@IssueAmount", SqlDbType.Decimal,9),
                        new SqlParameter("@SurplusAmount", SqlDbType.Decimal,9),
                        new SqlParameter("@IssuePrice", SqlDbType.Decimal,9),
                        new SqlParameter("@Periods", SqlDbType.Int,4),
                        new SqlParameter("@AddDate", SqlDbType.DateTime),
                        new SqlParameter("@IsSell", SqlDbType.Int,4)};
            parameters[0].Value = model.IssueAmount;
            parameters[1].Value = model.SurplusAmount;
            parameters[2].Value = model.IssuePrice;
            parameters[3].Value = model.Periods;
            parameters[4].Value = model.AddDate;
            parameters[5].Value = model.IsSell;

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
        public bool Update(lgk.Model.tb_StockIssue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_StockIssue set");
            strSql.Append(" IssueAmount = @IssueAmount,");
            strSql.Append(" SurplusAmount = @SurplusAmount,");
            strSql.Append(" IssuePrice = @IssuePrice,");
            strSql.Append(" Periods = @Periods,");
            strSql.Append(" AddDate = @AddDate,");
            strSql.Append(" IsSell = @IsSell ");
            strSql.Append(" where IssueID=@IssueID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@IssueID", SqlDbType.Int,4),
                        new SqlParameter("@IssueAmount", SqlDbType.Decimal,9),
                        new SqlParameter("@SurplusAmount", SqlDbType.Decimal,9),
                        new SqlParameter("@IssuePrice", SqlDbType.Decimal,9),
                        new SqlParameter("@Periods", SqlDbType.Int,4),
                        new SqlParameter("@AddDate", SqlDbType.DateTime),
                        new SqlParameter("@IsSell", SqlDbType.Int,4)};
            parameters[0].Value = model.IssueID;
            parameters[1].Value = model.IssueAmount;
            parameters[2].Value = model.SurplusAmount;
            parameters[3].Value = model.IssuePrice;
            parameters[4].Value = model.Periods;
            parameters[5].Value = model.AddDate;
            parameters[6].Value = model.IsSell;

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
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_StockIssue set ");
            strSql.Append(" IsSell = 0 ");

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public bool Delete(int IssueID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_StockIssue");
            strSql.Append(" where IssueID=@IssueID");
            SqlParameter[] parameters = {
					new SqlParameter("@IssueID", SqlDbType.Int,4)
			};
            parameters[0].Value = IssueID;

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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IssueIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_StockIssue ");
            strSql.Append(" where IssueID in (" + IssueIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public lgk.Model.tb_StockIssue GetModel(int IssueID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select IssueID, IssueAmount, SurplusAmount, IssuePrice, Periods, AddDate, IsSell");
            strSql.Append(" from tb_StockIssue ");
            strSql.Append(" where IssueID=@IssueID");
            SqlParameter[] parameters = {
					new SqlParameter("@IssueID", SqlDbType.Int,4)};
            parameters[0].Value = IssueID;

            lgk.Model.tb_StockIssue model = new lgk.Model.tb_StockIssue();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["IssueID"].ToString() != "")
                {
                    model.IssueID = int.Parse(ds.Tables[0].Rows[0]["IssueID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssueAmount"].ToString() != "")
                {
                    model.IssueAmount = decimal.Parse(ds.Tables[0].Rows[0]["IssueAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SurplusAmount"].ToString() != "")
                {
                    model.SurplusAmount = decimal.Parse(ds.Tables[0].Rows[0]["SurplusAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssuePrice"].ToString() != "")
                {
                    model.IssuePrice = decimal.Parse(ds.Tables[0].Rows[0]["IssuePrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Periods"].ToString() != "")
                {
                    model.Periods = int.Parse(ds.Tables[0].Rows[0]["Periods"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSell"].ToString() != "")
                {
                    model.IsSell = int.Parse(ds.Tables[0].Rows[0]["IsSell"].ToString());
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
        public lgk.Model.tb_StockIssue GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 IssueID, IssueAmount, SurplusAmount, IssuePrice, Periods, AddDate, IsSell");
            strSql.Append(" from tb_StockIssue ");
            if (strWhere.Trim() != "")
                strSql.Append(" where " + strWhere);

            lgk.Model.tb_StockIssue model = new lgk.Model.tb_StockIssue();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["IssueID"].ToString() != "")
                {
                    model.IssueID = int.Parse(ds.Tables[0].Rows[0]["IssueID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssueAmount"].ToString() != "")
                {
                    model.IssueAmount = decimal.Parse(ds.Tables[0].Rows[0]["IssueAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SurplusAmount"].ToString() != "")
                {
                    model.SurplusAmount = decimal.Parse(ds.Tables[0].Rows[0]["SurplusAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssuePrice"].ToString() != "")
                {
                    model.IssuePrice = decimal.Parse(ds.Tables[0].Rows[0]["IssuePrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Periods"].ToString() != "")
                {
                    model.Periods = int.Parse(ds.Tables[0].Rows[0]["Periods"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSell"].ToString() != "")
                {
                    model.IsSell = int.Parse(ds.Tables[0].Rows[0]["IsSell"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append(" FROM tb_StockIssue");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM tb_StockIssue ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取未卖出的股票数量
        /// </summary>
        public int GetSurplusAmount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SurplusAmount FROM [tb_StockIssue] WHERE IsSell=1");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());

            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj.ToString());
            }
        }

        /// <summary>
        /// 获取未卖出的股票数量
        /// </summary>
        public int GetMax(string FieldName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT " + FieldName.Trim() + " FROM [tb_StockIssue] WHERE IsSell=1");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());

            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj.ToString());
            }
        }

        #endregion
    }
}
