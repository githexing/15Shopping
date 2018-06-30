using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DataAccess;

namespace lgk.DAL
{
    //tb_PacketReceive
    public partial class tb_PacketReceive
    {

        public bool Exists(long ReceiveID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_PacketReceive");
            strSql.Append(" where ");
            strSql.Append(" ReceiveID = @ReceiveID  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ReceiveID", SqlDbType.BigInt)
            };
            parameters[0].Value = ReceiveID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_PacketReceive model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_PacketReceive(");
            strSql.Append("PackID,Amount,ReceiveFlag,ReceiveUserID,ReceiveTime,CancelTime");
            strSql.Append(") values (");
            strSql.Append("@PackID,@Amount,@ReceiveFlag,@ReceiveUserID,@ReceiveTime,@CancelTime");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@PackID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@Amount", SqlDbType.Decimal,9) ,
                        new SqlParameter("@ReceiveFlag", SqlDbType.Int,4) ,
                        new SqlParameter("@ReceiveUserID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@ReceiveTime", SqlDbType.DateTime) ,
                        new SqlParameter("@CancelTime", SqlDbType.DateTime)

            };

            parameters[0].Value = model.PackID;
            parameters[1].Value = model.Amount;
            parameters[2].Value = model.ReceiveFlag;
            parameters[3].Value = model.ReceiveUserID;
            parameters[4].Value = model.ReceiveTime;
            parameters[5].Value = model.CancelTime;

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
        public bool Update(lgk.Model.tb_PacketReceive model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_PacketReceive set ");

            strSql.Append(" PackID = @PackID , ");
            strSql.Append(" Amount = @Amount , ");
            strSql.Append(" ReceiveFlag = @ReceiveFlag , ");
            strSql.Append(" ReceiveUserID = @ReceiveUserID , ");
            strSql.Append(" ReceiveTime = @ReceiveTime , ");
            strSql.Append(" CancelTime = @CancelTime  ");
            strSql.Append(" where ReceiveID=@ReceiveID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ReceiveID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@PackID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@Amount", SqlDbType.Decimal,9) ,
                        new SqlParameter("@ReceiveFlag", SqlDbType.Int,4) ,
                        new SqlParameter("@ReceiveUserID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@ReceiveTime", SqlDbType.DateTime) ,
                        new SqlParameter("@CancelTime", SqlDbType.DateTime)

            };

            parameters[0].Value = model.ReceiveID;
            parameters[1].Value = model.PackID;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.ReceiveFlag;
            parameters[4].Value = model.ReceiveUserID;
            parameters[5].Value = model.ReceiveTime;
            parameters[6].Value = model.CancelTime;
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
        public bool Delete(long ReceiveID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_PacketReceive ");
            strSql.Append(" where ReceiveID=@ReceiveID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ReceiveID", SqlDbType.BigInt)
            };
            parameters[0].Value = ReceiveID;


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
        public bool DeleteList(string ReceiveIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_PacketReceive ");
            strSql.Append(" where ID in (" + ReceiveIDlist + ")  ");
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
        public lgk.Model.tb_PacketReceive GetModel(long ReceiveID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ReceiveID, PackID, Amount, ReceiveFlag, ReceiveUserID, ReceiveTime, CancelTime  ");
            strSql.Append("  from tb_PacketReceive ");
            strSql.Append(" where ReceiveID=@ReceiveID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ReceiveID", SqlDbType.BigInt)
            };
            parameters[0].Value = ReceiveID;


            lgk.Model.tb_PacketReceive model = new lgk.Model.tb_PacketReceive();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ReceiveID"].ToString() != "")
                {
                    model.ReceiveID = long.Parse(ds.Tables[0].Rows[0]["ReceiveID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PackID"].ToString() != "")
                {
                    model.PackID = long.Parse(ds.Tables[0].Rows[0]["PackID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceiveFlag"].ToString() != "")
                {
                    model.ReceiveFlag = int.Parse(ds.Tables[0].Rows[0]["ReceiveFlag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceiveUserID"].ToString() != "")
                {
                    model.ReceiveUserID = long.Parse(ds.Tables[0].Rows[0]["ReceiveUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceiveTime"].ToString() != "")
                {
                    model.ReceiveTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReceiveTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CancelTime"].ToString() != "")
                {
                    model.CancelTime = DateTime.Parse(ds.Tables[0].Rows[0]["CancelTime"].ToString());
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
            strSql.Append(" FROM tb_PacketReceive ");
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
            strSql.Append(" FROM tb_PacketReceive ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

