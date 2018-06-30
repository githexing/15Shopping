using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DataAccess;

namespace lgk.DAL
{
    //tb_PacketSend
    public partial class tb_PacketSend
    {

        public bool Exists(long PackID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_PacketSend");
            strSql.Append(" where ");
            strSql.Append(" PackID = @PackID  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@PackID", SqlDbType.BigInt)
            };
            parameters[0].Value = PackID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_PacketSend model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_PacketSend(");
            strSql.Append("UserID,Amount,Number,LeaveMessage,SendTime,ReceiveNum,ReceiveMoney");
            strSql.Append(") values (");
            strSql.Append("@UserID,@Amount,@Number,@LeaveMessage,@SendTime,@ReceiveNum,@ReceiveMoney");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@Amount", SqlDbType.Decimal,9) ,
                        new SqlParameter("@Number", SqlDbType.Int,4) ,
                        new SqlParameter("@LeaveMessage", SqlDbType.VarChar,100) ,
                        new SqlParameter("@SendTime", SqlDbType.DateTime) ,
                        new SqlParameter("@ReceiveNum", SqlDbType.Int,4) ,
                        new SqlParameter("@ReceiveMoney", SqlDbType.Decimal,9)

            };

            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Amount;
            parameters[2].Value = model.Number;
            parameters[3].Value = model.LeaveMessage;
            parameters[4].Value = model.SendTime;
            parameters[5].Value = model.ReceiveNum;
            parameters[6].Value = model.ReceiveMoney;

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
        public bool Update(lgk.Model.tb_PacketSend model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_PacketSend set ");

            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" Amount = @Amount , ");
            strSql.Append(" Number = @Number , ");
            strSql.Append(" LeaveMessage = @LeaveMessage , ");
            strSql.Append(" SendTime = @SendTime , ");
            strSql.Append(" ReceiveNum = @ReceiveNum , ");
            strSql.Append(" ReceiveMoney = @ReceiveMoney  ");
            strSql.Append(" where PackID=@PackID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@PackID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@Amount", SqlDbType.Decimal,9) ,
                        new SqlParameter("@Number", SqlDbType.Int,4) ,
                        new SqlParameter("@LeaveMessage", SqlDbType.VarChar,100) ,
                        new SqlParameter("@SendTime", SqlDbType.DateTime) ,
                        new SqlParameter("@ReceiveNum", SqlDbType.Int,4) ,
                        new SqlParameter("@ReceiveMoney", SqlDbType.Decimal,9)

            };

            parameters[0].Value = model.PackID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.Number;
            parameters[4].Value = model.LeaveMessage;
            parameters[5].Value = model.SendTime;
            parameters[6].Value = model.ReceiveNum;
            parameters[7].Value = model.ReceiveMoney;
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
        public bool Delete(long PackID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_PacketSend ");
            strSql.Append(" where PackID=@PackID");
            SqlParameter[] parameters = {
                    new SqlParameter("@PackID", SqlDbType.BigInt)
            };
            parameters[0].Value = PackID;


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
        public bool DeleteList(string PackIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_PacketSend ");
            strSql.Append(" where ID in (" + PackIDlist + ")  ");
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
        public lgk.Model.tb_PacketSend GetModel(long PackID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PackID, UserID, Amount, Number, LeaveMessage, SendTime, ReceiveNum, ReceiveMoney,OrderCode  ");
            strSql.Append("  from tb_PacketSend ");
            strSql.Append(" where PackID=@PackID");
            SqlParameter[] parameters = {
                    new SqlParameter("@PackID", SqlDbType.BigInt)
            };
            parameters[0].Value = PackID;


            lgk.Model.tb_PacketSend model = new lgk.Model.tb_PacketSend();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PackID"].ToString() != "")
                {
                    model.PackID = long.Parse(ds.Tables[0].Rows[0]["PackID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Number"].ToString() != "")
                {
                    model.Number = int.Parse(ds.Tables[0].Rows[0]["Number"].ToString());
                }
                model.LeaveMessage = ds.Tables[0].Rows[0]["LeaveMessage"].ToString();
                if (ds.Tables[0].Rows[0]["SendTime"].ToString() != "")
                {
                    model.SendTime = DateTime.Parse(ds.Tables[0].Rows[0]["SendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceiveNum"].ToString() != "")
                {
                    model.ReceiveNum = int.Parse(ds.Tables[0].Rows[0]["ReceiveNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceiveMoney"].ToString() != "")
                {
                    model.ReceiveMoney = decimal.Parse(ds.Tables[0].Rows[0]["ReceiveMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderCode"].ToString() != "")
                {
                    model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
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
            strSql.Append(" FROM tb_PacketSend ");
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
            strSql.Append(" FROM tb_PacketSend ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

