using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public class tb_TicketBack
    {
       
            public bool Exists(int ID)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from tb_TicketBack");
                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
                };
                parameters[0].Value = ID;

                return DbHelperSQL.Exists(strSql.ToString(), parameters);
            }


            /// <summary>
            /// 增加一条数据
            /// </summary>
            public int Add(lgk.Model.tb_TicketBack model)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into tb_TicketBack(");
                strSql.Append("Type,OrderNo,OrderStatus,Reason,TicketNos,FefundMoney,PoundageFee,Sign)");
                strSql.Append(" values (");
                strSql.Append("@Type,@OrderNo,@OrderStatus,@Reason,@TicketNos,@FefundMoney,@PoundageFee,@Sign)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@Type", SqlDbType.Int),
                    new SqlParameter("@OrderNo", SqlDbType.VarChar,100),
                    new SqlParameter("@OrderStatus", SqlDbType.VarChar),
                    new SqlParameter("@Reason", SqlDbType.VarChar,100),
                    new SqlParameter("@TicketNos", SqlDbType.VarChar,100),
                    new SqlParameter("@FefundMoney", SqlDbType.VarChar,100),
                    new SqlParameter("@PoundageFee", SqlDbType.VarChar,100),
                    new SqlParameter("@Sign", SqlDbType.VarChar,100)
            };
                parameters[0].Value = model.Type;
                parameters[1].Value = model.OrderNo;
                parameters[2].Value = model.OrderStatus;
                parameters[3].Value = model.Reason;
                parameters[4].Value = model.TicketNos;
                parameters[5].Value = model.FefundMoney;
                parameters[6].Value = model.PoundageFee;
                parameters[7].Value = model.Sign;

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
            public bool Update(lgk.Model.tb_TicketBack model)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update tb_TicketBack set ");
                strSql.Append("Type=@Type,");
                strSql.Append("OrderStatus=@OrderStatus,");
                strSql.Append("Reason=@Reason,");
                strSql.Append("TicketNos=@TicketNos,");
                strSql.Append("Sign=@Sign");
                strSql.Append(" where OrderNo=@OrderNo");
            SqlParameter[] parameters = {
                    new SqlParameter("@Type", SqlDbType.Int),
                 
                    new SqlParameter("@OrderStatus", SqlDbType.VarChar),
                    new SqlParameter("@Reason", SqlDbType.VarChar,100),
                    new SqlParameter("@TicketNos", SqlDbType.VarChar,100),
                    new SqlParameter("@Sign", SqlDbType.VarChar,100),
                    new SqlParameter("@OrderNo", SqlDbType.VarChar,100)
            };
            parameters[0].Value = model.Type;
            parameters[1].Value = model.OrderStatus;
            parameters[2].Value = model.Reason;
            parameters[3].Value = model.TicketNos;
            parameters[4].Value = model.Sign;
            parameters[5].Value = model.OrderNo;
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
                strSql.Append("delete from tb_TicketBack ");
                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)};
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
            public lgk.Model.tb_TicketBack GetModel(string where)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  top 1 * from tb_TicketBack ");
                strSql.Append(" where " + where);

                lgk.Model.tb_TicketBack model = new lgk.Model.tb_TicketBack();
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["Type"] != null && ds.Tables[0].Rows[0]["Type"].ToString() != "")
                    {
                        model.Type = ds.Tables[0].Rows[0]["Type"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["OrderNo"] != null && ds.Tables[0].Rows[0]["OrderNo"].ToString() != "")
                    {
                        model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["OrderStatus"] != null && ds.Tables[0].Rows[0]["OrderStatus"].ToString() != "")
                    {
                        model.OrderStatus =ds.Tables[0].Rows[0]["OrderStatus"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Reason"] != null && ds.Tables[0].Rows[0]["Reason"].ToString() != "")
                    {
                        model.Reason = ds.Tables[0].Rows[0]["Reason"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["TicketNos"] != null && ds.Tables[0].Rows[0]["TicketNos"].ToString() != "")
                    {
                        model.TicketNos = ds.Tables[0].Rows[0]["TicketNos"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Sign"] != null && ds.Tables[0].Rows[0]["Sign"].ToString() != "")
                    {
                        model.Sign = ds.Tables[0].Rows[0]["Sign"].ToString();
                    }
                    
                    return model;
                }
                else
                {
                    return null;
                }
            }
            public DataSet GetList(string strWhere)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from tb_OrderCallBack");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                return DbHelperSQL.Query(strSql.ToString());
            }
        }
}
