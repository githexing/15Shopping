using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_StockSplit
    /// </summary>
    public partial class tb_StockSplit
    {
        public tb_StockSplit()
        { }
        #region Method

        public bool Exists(long SplitID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_StockSplit");
            strSql.Append(" where ");
            strSql.Append(" SplitID = @SplitID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@SplitID", SqlDbType.BigInt,8)};
            parameters[0].Value = SplitID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_StockSplit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_StockSplit(");
            strSql.Append("SplitPrice,SplitPriceB,SplitPriceL,SplitRate,SplitTimes,SplitDate");
            strSql.Append(") values (");
            strSql.Append("@SplitPrice,@SplitPriceB,@SplitPriceL,@SplitRate,@SplitTimes,@SplitDate");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@SplitPrice", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitPriceB", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitPriceL", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitRate", SqlDbType.VarChar,50),
                        new SqlParameter("@SplitTimes", SqlDbType.Int,4),
                        new SqlParameter("@SplitDate", SqlDbType.DateTime)};
            parameters[0].Value = model.SplitPrice;
            parameters[1].Value = model.SplitPriceB;
            parameters[2].Value = model.SplitPriceL;
            parameters[3].Value = model.SplitRate;
            parameters[4].Value = model.SplitTimes;
            parameters[5].Value = model.SplitDate;

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
        public bool Update(lgk.Model.tb_StockSplit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_StockSplit set ");
            strSql.Append(" SplitPrice = @SplitPrice,");
            strSql.Append(" SplitPriceB = @SplitPriceB,");
            strSql.Append(" SplitPriceL = @SplitPriceL,");
            strSql.Append(" SplitRate = @SplitRate,");
            strSql.Append(" SplitTimes = @SplitTimes,");
            strSql.Append(" SplitDate = @SplitDate ");
            strSql.Append(" where SplitID=@SplitID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@SplitID", SqlDbType.BigInt,8),
                        new SqlParameter("@SplitPrice", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitPriceB", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitPriceL", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitRate", SqlDbType.VarChar,50),
                        new SqlParameter("@SplitTimes", SqlDbType.Int,4),
                        new SqlParameter("@SplitDate", SqlDbType.DateTime)};
            parameters[0].Value = model.SplitID;
            parameters[1].Value = model.SplitPrice;
            parameters[2].Value = model.SplitPriceB;
            parameters[3].Value = model.SplitPriceL;
            parameters[4].Value = model.SplitRate;
            parameters[5].Value = model.SplitTimes;
            parameters[6].Value = model.SplitDate;

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
        public bool Delete(long SplitID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_StockSplit ");
            strSql.Append(" where SplitID=@SplitID");
            SqlParameter[] parameters = {
					new SqlParameter("@SplitID", SqlDbType.BigInt,8)};
            parameters[0].Value = SplitID;

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
        public bool DeleteList(string SplitIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_StockSplit ");
            strSql.Append(" where SplitID in (" + SplitIDlist + ") ");
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
        public lgk.Model.tb_StockSplit GetModel(long SplitID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SplitID, SplitPrice, SplitPriceB, SplitPriceL, SplitRate, SplitTimes, SplitDate");
            strSql.Append(" from tb_StockSplit ");
            strSql.Append(" where SplitID=@SplitID");
            SqlParameter[] parameters = {
					new SqlParameter("@SplitID", SqlDbType.BigInt,8)};
            parameters[0].Value = SplitID;

            lgk.Model.tb_StockSplit model = new lgk.Model.tb_StockSplit();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SplitID"].ToString() != "")
                {
                    model.SplitID = long.Parse(ds.Tables[0].Rows[0]["SplitID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitPrice"].ToString() != "")
                {
                    model.SplitPrice = decimal.Parse(ds.Tables[0].Rows[0]["SplitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitPriceB"].ToString() != "")
                {
                    model.SplitPriceB = decimal.Parse(ds.Tables[0].Rows[0]["SplitPriceB"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitPriceL"].ToString() != "")
                {
                    model.SplitPriceL = decimal.Parse(ds.Tables[0].Rows[0]["SplitPriceL"].ToString());
                }
                model.SplitRate = ds.Tables[0].Rows[0]["SplitRate"].ToString();
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
        public lgk.Model.tb_StockSplit GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 SplitID, SplitPrice, SplitPriceB, SplitPriceL, SplitRate, SplitTimes, SplitDate");
            strSql.Append(" from tb_StockSplit ");
            if (strWhere.Trim() != "")
                strSql.Append(" where " + strWhere);

            lgk.Model.tb_StockSplit model = new lgk.Model.tb_StockSplit();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SplitID"].ToString() != "")
                {
                    model.SplitID = long.Parse(ds.Tables[0].Rows[0]["SplitID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitPrice"].ToString() != "")
                {
                    model.SplitPrice = decimal.Parse(ds.Tables[0].Rows[0]["SplitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitPriceB"].ToString() != "")
                {
                    model.SplitPriceB = decimal.Parse(ds.Tables[0].Rows[0]["SplitPriceB"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SplitPriceL"].ToString() != "")
                {
                    model.SplitPriceL = decimal.Parse(ds.Tables[0].Rows[0]["SplitPriceL"].ToString());
                }
                model.SplitRate = ds.Tables[0].Rows[0]["SplitRate"].ToString();
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
            strSql.Append(" FROM tb_StockSplit ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            strSql.Append(" FROM tb_StockSplit ");
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
        /// <param name="dSplitPriceB">当前股价</param>
        /// <param name="dSplitPriceL">原始股价</param>
        /// <returns></returns>
        public bool SplitProc(lgk.Model.tb_StockSplit model)
        {
            int result = 0;
            string prop = "Proc_StockSplit";
            SqlParameter[] para = {
                        new SqlParameter("@SplitPrice", SqlDbType.Decimal,9),
			            new SqlParameter("@SplitPriceB", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitPriceL", SqlDbType.Decimal,9),
                        new SqlParameter("@SplitRate", SqlDbType.VarChar,50),
                        new SqlParameter("@SplitTimes", SqlDbType.Int,4),
                        new SqlParameter("@SplitDate", SqlDbType.DateTime)
            };
            para[0].Value = model.SplitPrice;
            para[1].Value = model.SplitPriceB;
            para[2].Value = model.SplitPriceL;
            para[3].Value = model.SplitRate;
            para[4].Value = model.SplitTimes;
            para[5].Value = model.SplitDate;

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
