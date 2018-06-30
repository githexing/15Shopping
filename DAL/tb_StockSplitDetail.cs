using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_StockSplitDetail
    /// </summary>
    public partial class tb_StockSplitDetail
    {
        public tb_StockSplitDetail()
        { }
        #region Method

        /// <summary>
        /// 根据给定的编号，查询是否存在该记录。
        /// </summary>
        /// <param name="SplitDetailID"></param>
        /// <returns></returns>
        public bool Exists(long SplitDetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_StockSplitDetail");
            strSql.Append(" where ");
            strSql.Append(" SplitDetailID = @SplitDetailID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SplitDetailID", SqlDbType.BigInt,8)};
            parameters[0].Value = SplitDetailID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_StockSplitDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_StockSplitDetail(");
            strSql.Append("SplitID,UserID,UserCode,StockID,SplitStockB,SplitStockL,SplitTimes,SplitDate");
            strSql.Append(") values (");
            strSql.Append("@SplitID,@UserID,@UserCode,@StockID,@SplitStockB,@SplitStockL,@SplitTimes,@SplitDate");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@SplitID", SqlDbType.BigInt,8),
                        new SqlParameter("@UserID", SqlDbType.BigInt,8),
                        new SqlParameter("@UserCode", SqlDbType.VarChar,50),
                        new SqlParameter("@StockID", SqlDbType.Int,4),
                        new SqlParameter("@SplitStockB", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitStockL", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitTimes", SqlDbType.Int,4),
                        new SqlParameter("@SplitDate", SqlDbType.DateTime)};
            parameters[0].Value = model.SplitID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserCode;
            parameters[3].Value = model.StockID;
            parameters[4].Value = model.SplitStockB;
            parameters[5].Value = model.SplitStockL;
            parameters[6].Value = model.SplitTimes;
            parameters[7].Value = model.SplitDate;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(lgk.Model.tb_StockSplitDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_StockSplitDetail set ");
            strSql.Append(" SplitID = @SplitID,");
            strSql.Append(" UserID = @UserID,");
            strSql.Append(" UserCode = @UserCode,");
            strSql.Append(" StockID = @StockID,");
            strSql.Append(" SplitStockB = @SplitStockB,");
            strSql.Append(" SplitStockL = @SplitStockL,");
            strSql.Append(" SplitTimes = @SplitTimes,");
            strSql.Append(" SplitDate = @SplitDate ");
            strSql.Append(" where SplitDetailID=@SplitDetailID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@SplitDetailID", SqlDbType.BigInt,8),
                        new SqlParameter("@SplitID", SqlDbType.BigInt,8),
                        new SqlParameter("@UserID", SqlDbType.BigInt,8),
                        new SqlParameter("@UserCode", SqlDbType.VarChar,50),
                        new SqlParameter("@StockID", SqlDbType.Int,4),
                        new SqlParameter("@SplitStockB", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitStockL", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitTimes", SqlDbType.Int,4),
                        new SqlParameter("@SplitDate", SqlDbType.DateTime)};
            parameters[0].Value = model.SplitDetailID;
            parameters[1].Value = model.SplitID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserCode;
            parameters[4].Value = model.StockID;
            parameters[5].Value = model.SplitStockB;
            parameters[6].Value = model.SplitStockL;
            parameters[7].Value = model.SplitTimes;
            parameters[8].Value = model.SplitDate;

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
        public bool Delete(long SplitDetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_StockSplitDetail ");
            strSql.Append(" where SplitDetailID=@SplitDetailID");
            SqlParameter[] parameters = {
					new SqlParameter("@SplitDetailID", SqlDbType.BigInt,8)};
            parameters[0].Value = SplitDetailID;

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
        public bool DeleteList(string SplitDetailIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_StockSplitDetail ");
            strSql.Append(" where SplitDetailID in (" + SplitDetailIDlist + ") ");
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
        public lgk.Model.tb_StockSplitDetail GetModel(long SplitDetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SplitDetailID, SplitID, UserID, UserCode, StockID, SplitStockB, SplitStockL, SplitTimes, SplitDate");
            strSql.Append(" from tb_StockSplitDetail ");
            strSql.Append(" where SplitDetailID=@SplitDetailID");
            SqlParameter[] parameters = {
					new SqlParameter("@SplitDetailID", SqlDbType.BigInt,8)};
            parameters[0].Value = SplitDetailID;


            lgk.Model.tb_StockSplitDetail model = new lgk.Model.tb_StockSplitDetail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SplitDetailID"].ToString() != "")
                {
                    model.SplitDetailID = long.Parse(ds.Tables[0].Rows[0]["SplitDetailID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitID"].ToString() != "")
                {
                    model.SplitID = long.Parse(ds.Tables[0].Rows[0]["SplitID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserCode = ds.Tables[0].Rows[0]["UserCode"].ToString();
                if (ds.Tables[0].Rows[0]["StockID"].ToString() != "")
                {
                    model.StockID = long.Parse(ds.Tables[0].Rows[0]["StockID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitStockB"].ToString() != "")
                {
                    model.SplitStockB = decimal.Parse(ds.Tables[0].Rows[0]["SplitStockB"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitStockL"].ToString() != "")
                {
                    model.SplitStockL = decimal.Parse(ds.Tables[0].Rows[0]["SplitStockL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitTimes"].ToString() != "")
                {
                    model.SplitTimes = int.Parse(ds.Tables[0].Rows[0]["SplitTimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitDate"].ToString() != "")
                {
                    model.SplitDate = DateTime.Parse(ds.Tables[0].Rows[0]["SplitDate"].ToString());
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
        public lgk.Model.tb_StockSplitDetail GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SplitDetailID, SplitID, UserID, UserCode, StockID, SplitStockB, SplitStockL, SplitTimes, SplitDate");
            strSql.Append(" from tb_StockSplitDetail ");

            if(strWhere.Trim() !="")
                strSql.Append(" where " + strWhere);

            lgk.Model.tb_StockSplitDetail model = new lgk.Model.tb_StockSplitDetail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SplitDetailID"].ToString() != "")
                {
                    model.SplitDetailID = long.Parse(ds.Tables[0].Rows[0]["SplitDetailID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitID"].ToString() != "")
                {
                    model.SplitID = long.Parse(ds.Tables[0].Rows[0]["SplitID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserCode = ds.Tables[0].Rows[0]["UserCode"].ToString();
                if (ds.Tables[0].Rows[0]["StockID"].ToString() != "")
                {
                    model.StockID = long.Parse(ds.Tables[0].Rows[0]["StockID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitStockB"].ToString() != "")
                {
                    model.SplitStockB = decimal.Parse(ds.Tables[0].Rows[0]["SplitStockB"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitStockL"].ToString() != "")
                {
                    model.SplitStockL = decimal.Parse(ds.Tables[0].Rows[0]["SplitStockL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitTimes"].ToString() != "")
                {
                    model.SplitTimes = int.Parse(ds.Tables[0].Rows[0]["SplitTimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitDate"].ToString() != "")
                {
                    model.SplitDate = DateTime.Parse(ds.Tables[0].Rows[0]["SplitDate"].ToString());
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
            strSql.Append("select * ");
            strSql.Append(" FROM tb_StockSplitDetail ");
            if (strWhere.Trim() != "")
                strSql.Append(" where " + strWhere);

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM tb_StockSplitDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 执行股票拆分存储过程
        /// </summary>
        /// <param name="model">拆分主表实体</param>
        /// <returns></returns>
        public bool SplitProcDetail(lgk.Model.tb_StockSplit model)
        {
            int result = 0;
            string prop = "Proc_StockSplitDetail";
            SqlParameter[] para = {
                        new SqlParameter("@SplitID", SqlDbType.Int,4),
			            new SqlParameter("@SplitPriceB", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitPriceL", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitTimes", SqlDbType.Int,4),
                        new SqlParameter("@SplitDate", SqlDbType.DateTime)
            };
            para[0].Value = model.SplitID;
            para[1].Value = model.SplitPriceB;
            para[2].Value = model.SplitPriceL;
            para[3].Value = model.SplitTimes;
            para[4].Value = model.SplitDate;

            DbHelperSQL.RunProcedure(prop, para, out result);

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
