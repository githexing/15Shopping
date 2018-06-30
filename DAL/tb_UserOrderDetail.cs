using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public partial class tb_UserOrderDetail
    {
        public tb_UserOrderDetail()
        { }

        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_UserOrderDetail");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Add(lgk.Model.tb_UserOrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_UserOrderDetail(");
            strSql.Append("d003,OrderCode,SellerCode,Integral,Purchase,Sale,Quantity,d001,d002,Equity,EquityTop");
            strSql.Append(") values (");
            strSql.Append("@d003,@OrderCode,@SellerCode,@Integral,@Purchase,@Sale,@Quantity,@d001,@d002,@Equity,@EquityTop");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@d003", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SellerCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Integral", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Purchase", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Sale", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Quantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@d001", SqlDbType.Int,4) ,            
                        new SqlParameter("@d002", SqlDbType.Decimal,9),
                        new SqlParameter("@Equity", SqlDbType.Decimal,9),
                        new SqlParameter("@EquityTop", SqlDbType.Decimal,9)
            };

            parameters[0].Value = model.d003;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.SellerCode;
            parameters[3].Value = model.Integral;
            parameters[4].Value = model.Purchase;
            parameters[5].Value = model.Sale;
            parameters[6].Value = model.Quantity;
            parameters[7].Value = model.d001;
            parameters[8].Value = model.d002;
            parameters[9].Value = model.Equity;
            parameters[10].Value = model.EquityTop;

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
        #endregion

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_UserOrderDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_UserOrderDetail set ");

            strSql.Append(" d003 = @d003 , ");
            strSql.Append(" OrderCode = @OrderCode , ");
            strSql.Append(" SellerCode = @SellerCode , ");
            strSql.Append(" Integral = @Integral , ");
            strSql.Append(" Purchase = @Purchase , ");
            strSql.Append(" Sale = @Sale , ");
            strSql.Append(" Quantity = @Quantity , ");
            strSql.Append(" d001 = @d001 , ");
            strSql.Append(" d002 = @d002 , ");
            strSql.Append(" Equity = @Equity , ");
            strSql.Append(" EquityTop = @EquityTop ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@d003", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SellerCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Integral", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Purchase", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Sale", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Quantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@d001", SqlDbType.Int,4) ,            
                        new SqlParameter("@d002", SqlDbType.Decimal,9),
                        new SqlParameter("@Equity", SqlDbType.Decimal,9),
                        new SqlParameter("@EquityTop", SqlDbType.Decimal,9)
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.d003;
            parameters[2].Value = model.OrderCode;
            parameters[3].Value = model.SellerCode;
            parameters[4].Value = model.Integral;
            parameters[5].Value = model.Purchase;
            parameters[6].Value = model.Sale;
            parameters[7].Value = model.Quantity;
            parameters[8].Value = model.d001;
            parameters[9].Value = model.d002;
            parameters[10].Value = model.Equity;
            parameters[11].Value = model.EquityTop;
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_UserOrderDetail ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_UserOrderDetail ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public lgk.Model.tb_UserOrderDetail GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, d003, OrderCode, SellerCode, Integral, Purchase, Sale, Quantity, d001, d002, Equity, EquityTop  ");
            strSql.Append("  from tb_UserOrderDetail ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;


            lgk.Model.tb_UserOrderDetail model = new lgk.Model.tb_UserOrderDetail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.d003 = ds.Tables[0].Rows[0]["d003"].ToString();
                model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                model.SellerCode = ds.Tables[0].Rows[0]["SellerCode"].ToString();
                if (ds.Tables[0].Rows[0]["Integral"].ToString() != "")
                {
                    model.Integral = decimal.Parse(ds.Tables[0].Rows[0]["Integral"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Purchase"].ToString() != "")
                {
                    model.Purchase = decimal.Parse(ds.Tables[0].Rows[0]["Purchase"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sale"].ToString() != "")
                {
                    model.Sale = decimal.Parse(ds.Tables[0].Rows[0]["Sale"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Quantity"].ToString() != "")
                {
                    model.Quantity = int.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["d001"].ToString() != "")
                {
                    model.d001 = int.Parse(ds.Tables[0].Rows[0]["d001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["d002"].ToString() != "")
                {
                    model.d002 = decimal.Parse(ds.Tables[0].Rows[0]["d002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Equity"].ToString() != "")
                {
                    model.Equity = decimal.Parse(ds.Tables[0].Rows[0]["Equity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EquityTop"].ToString() != "")
                {
                    model.EquityTop = decimal.Parse(ds.Tables[0].Rows[0]["EquityTop"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tb_UserOrderDetail ");
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
            strSql.Append(" FROM tb_UserOrderDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
