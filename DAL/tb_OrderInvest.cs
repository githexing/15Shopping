using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DataAccess;

namespace lgk.DAL
{
    //tb_OrderInvest
    public partial class tb_OrderInvest
    {

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_OrderInvest");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_OrderInvest model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_OrderInvest(");
            strSql.Append("GetDays,GetInterest,UserID,OrderCode,AccountType,InvestType,Amount,AddTime,OutType");
            strSql.Append(") values (");
            strSql.Append("@GetDays,@GetInterest,@UserID,@OrderCode,@AccountType,@InvestType,@Amount,@AddTime,@OutType");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@GetDays", SqlDbType.Int,4) ,
                        new SqlParameter("@GetInterest", SqlDbType.Money,8) ,
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,30) ,
                        new SqlParameter("@AccountType", SqlDbType.Int,4) ,
                        new SqlParameter("@InvestType", SqlDbType.Int,4) ,
                        new SqlParameter("@Amount", SqlDbType.Money,8) ,
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,
                        new SqlParameter("@OutType", SqlDbType.Int,4) 

            };

            parameters[0].Value = model.GetDays;
            parameters[1].Value = model.GetInterest;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.OrderCode;
            parameters[4].Value = model.AccountType;
            parameters[5].Value = model.InvestType;
            parameters[6].Value = model.Amount;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.OutType;

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
        public bool Update(lgk.Model.tb_OrderInvest model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_OrderInvest set ");

            strSql.Append(" GetDays = @GetDays , ");
            strSql.Append(" GetInterest = @GetInterest , ");
            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" OrderCode = @OrderCode , ");
            strSql.Append(" AccountType = @AccountType , ");
            strSql.Append(" InvestType = @InvestType , ");
            strSql.Append(" Amount = @Amount , ");
            strSql.Append(" AddTime = @AddTime , ");
            strSql.Append(" OutType = @OutType , ");
            strSql.Append(" OutTime = @OutTime  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.Int,4) ,
                        new SqlParameter("@GetDays", SqlDbType.Int,4) ,
                        new SqlParameter("@GetInterest", SqlDbType.Money,8) ,
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,30) ,
                        new SqlParameter("@AccountType", SqlDbType.Int,4) ,
                        new SqlParameter("@InvestType", SqlDbType.Int,4) ,
                        new SqlParameter("@Amount", SqlDbType.Money,8) ,
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,
                        new SqlParameter("@OutType", SqlDbType.Int,4) ,
                        new SqlParameter("@OutTime", SqlDbType.DateTime)

            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.GetDays;
            parameters[2].Value = model.GetInterest;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.OrderCode;
            parameters[5].Value = model.AccountType;
            parameters[6].Value = model.InvestType;
            parameters[7].Value = model.Amount;
            parameters[8].Value = model.AddTime;
            parameters[9].Value = model.OutType;
            parameters[10].Value = model.OutTime;
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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_OrderInvest ");
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_OrderInvest ");
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_OrderInvest GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, GetDays, GetInterest, UserID, OrderCode, AccountType, InvestType, Amount, AddTime, OutType, OutTime  ");
            strSql.Append("  from tb_OrderInvest ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;


            lgk.Model.tb_OrderInvest model = new lgk.Model.tb_OrderInvest();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GetDays"].ToString() != "")
                {
                    model.GetDays = int.Parse(ds.Tables[0].Rows[0]["GetDays"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GetInterest"].ToString() != "")
                {
                    model.GetInterest = decimal.Parse(ds.Tables[0].Rows[0]["GetInterest"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                if (ds.Tables[0].Rows[0]["AccountType"].ToString() != "")
                {
                    model.AccountType = int.Parse(ds.Tables[0].Rows[0]["AccountType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InvestType"].ToString() != "")
                {
                    model.InvestType = int.Parse(ds.Tables[0].Rows[0]["InvestType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutType"].ToString() != "")
                {
                    model.OutType = int.Parse(ds.Tables[0].Rows[0]["OutType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutTime"].ToString() != "")
                {
                    model.OutTime = DateTime.Parse(ds.Tables[0].Rows[0]["OutTime"].ToString());
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
            strSql.Append(" FROM tb_OrderInvest ");
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
            strSql.Append(" FROM tb_OrderInvest ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

