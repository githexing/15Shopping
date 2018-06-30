using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public partial class tb_UserOrder
    {
        public tb_UserOrder()
		{ }

        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_UserOrder");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_UserOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_UserOrder(");
            strSql.Append("Status,Flag,UserID,OrderCode,IntegralAmount,PurchaseAmount,SellAmount,BuyTime,order001,IsSettle,ReceivieAddress,Province,City,Country");
            strSql.Append(") values (");
            strSql.Append("@Status,@Flag,@UserID,@OrderCode,@IntegralAmount,@PurchaseAmount,@SellAmount,@BuyTime,@order001,@IsSettle,@ReceivieAddress,@Province,@City,@Country");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Flag", SqlDbType.Int,4) ,           
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@IntegralAmount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@PurchaseAmount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SellAmount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@BuyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@order001", SqlDbType.Int,4),          
                        new SqlParameter("@IsSettle", SqlDbType.Int,4),
                        new SqlParameter("@ReceivieAddress", SqlDbType.VarChar,500),
                        new SqlParameter("@Province", SqlDbType.VarChar,50),
                        new SqlParameter("@City", SqlDbType.VarChar,50),
                        new SqlParameter("@Country", SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.Status;
            parameters[1].Value = model.Flag;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.OrderCode;
            parameters[4].Value = model.IntegralAmount;
            parameters[5].Value = model.PurchaseAmount;
            parameters[6].Value = model.SellAmount;
            parameters[7].Value = model.BuyTime;
            parameters[8].Value = model.order001;
            parameters[9].Value = model.IsSettle;
            parameters[10].Value = model.ReceivieAddress;
            parameters[11].Value = model.Province;
            parameters[12].Value = model.City;
            parameters[13].Value = model.Country;

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
        public bool Update(lgk.Model.tb_UserOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_UserOrder set ");

            strSql.Append(" Status = @Status , ");
            strSql.Append(" Flag = @Flag , ");
            strSql.Append(" SendTime = @SendTime , ");
            strSql.Append(" ReceiveTime = @ReceiveTime , ");
            strSql.Append(" ApplyTime = @ApplyTime , ");
            strSql.Append(" FinishTime = @FinishTime , ");
            strSql.Append(" IsSettle = @IsSettle , ");
            strSql.Append(" SettleTime = @SettleTime , ");
            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" OrderCode = @OrderCode , ");
            strSql.Append(" IntegralAmount = @IntegralAmount , ");
            strSql.Append(" PurchaseAmount = @PurchaseAmount , ");
            strSql.Append(" SellAmount = @SellAmount , ");
            strSql.Append(" BuyTime = @BuyTime , ");
            strSql.Append(" order001 = @order001 , ");//
            strSql.Append(" order002 = @order002 , ");
            strSql.Append(" ReceivieAddress = @ReceivieAddress , ");
            strSql.Append(" Province = @Province , ");
            strSql.Append(" City = @City , ");
            strSql.Append(" Country = @Country  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Flag", SqlDbType.Int,4) ,            
                        new SqlParameter("@SendTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ReceiveTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ApplyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FinishTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@IsSettle", SqlDbType.Int,4) ,            
                        new SqlParameter("@SettleTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@IntegralAmount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@PurchaseAmount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SellAmount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@BuyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@order001", SqlDbType.Int,4) ,            
                        new SqlParameter("@order002", SqlDbType.Decimal,9),          
                        new SqlParameter("@ReceivieAddress", SqlDbType.VarChar,500),
                        new SqlParameter("@Province", SqlDbType.VarChar,50),
                        new SqlParameter("@City", SqlDbType.VarChar,50),
                        new SqlParameter("@Country", SqlDbType.VarChar,50)
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.Flag;
            parameters[3].Value = model.SendTime;
            parameters[4].Value = model.ReceiveTime;
            parameters[5].Value = model.ApplyTime;
            parameters[6].Value = model.FinishTime;
            parameters[7].Value = model.IsSettle;
            parameters[8].Value = model.SettleTime;
            parameters[9].Value = model.UserID;
            parameters[10].Value = model.OrderCode;
            parameters[11].Value = model.IntegralAmount;
            parameters[12].Value = model.PurchaseAmount;
            parameters[13].Value = model.SellAmount;
            parameters[14].Value = model.BuyTime;
            parameters[15].Value = model.order001;
            parameters[16].Value = model.order002;
            parameters[17].Value = model.ReceivieAddress;
            parameters[18].Value = model.Province;
            parameters[19].Value = model.City;
            parameters[20].Value = model.Country;
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
            strSql.Append("delete from tb_UserOrder ");
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
            strSql.Append("delete from tb_UserOrder ");
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
        public lgk.Model.tb_UserOrder GetModel(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, Status, Flag, SendTime, ReceiveTime, ApplyTime, FinishTime, IsSettle, SettleTime, UserID, OrderCode, IntegralAmount, PurchaseAmount, SellAmount, BuyTime, order001, order002, ReceivieAddress, Province, City, Country  ");
            strSql.Append("  from tb_UserOrder ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;


            lgk.Model.tb_UserOrder model = new lgk.Model.tb_UserOrder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SendTime"].ToString() != "")
                {
                    model.SendTime = DateTime.Parse(ds.Tables[0].Rows[0]["SendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceiveTime"].ToString() != "")
                {
                    model.ReceiveTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReceiveTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ApplyTime"].ToString() != "")
                {
                    model.ApplyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ApplyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FinishTime"].ToString() != "")
                {
                    model.FinishTime = DateTime.Parse(ds.Tables[0].Rows[0]["FinishTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSettle"].ToString() != "")
                {
                    model.IsSettle = int.Parse(ds.Tables[0].Rows[0]["IsSettle"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SettleTime"].ToString() != "")
                {
                    model.SettleTime = DateTime.Parse(ds.Tables[0].Rows[0]["SettleTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                if (ds.Tables[0].Rows[0]["IntegralAmount"].ToString() != "")
                {
                    model.IntegralAmount = decimal.Parse(ds.Tables[0].Rows[0]["IntegralAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PurchaseAmount"].ToString() != "")
                {
                    model.PurchaseAmount = decimal.Parse(ds.Tables[0].Rows[0]["PurchaseAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SellAmount"].ToString() != "")
                {
                    model.SellAmount = decimal.Parse(ds.Tables[0].Rows[0]["SellAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyTime"].ToString() != "")
                {
                    model.BuyTime = DateTime.Parse(ds.Tables[0].Rows[0]["BuyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order001"].ToString() != "")
                {
                    model.order001 = int.Parse(ds.Tables[0].Rows[0]["order001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order002"].ToString() != "")
                {
                    model.order002 = decimal.Parse(ds.Tables[0].Rows[0]["order002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceivieAddress"].ToString() != "")
                {
                    model.ReceivieAddress = ds.Tables[0].Rows[0]["ReceivieAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Province"].ToString() != "")
                {
                    model.Province = ds.Tables[0].Rows[0]["Province"].ToString();
                }
                if (ds.Tables[0].Rows[0]["City"].ToString() != "")
                {
                    model.City = ds.Tables[0].Rows[0]["City"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Country"].ToString() != "")
                {
                    model.Country = ds.Tables[0].Rows[0]["Country"].ToString();
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
        public lgk.Model.tb_UserOrder GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, Status, Flag, SendTime, ReceiveTime, ApplyTime, FinishTime, IsSettle, SettleTime, UserID, OrderCode, IntegralAmount, PurchaseAmount, SellAmount, BuyTime, order001, order002, ReceivieAddress, Province, City, Country  ");
            strSql.Append("  from tb_UserOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            
            lgk.Model.tb_UserOrder model = new lgk.Model.tb_UserOrder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SendTime"].ToString() != "")
                {
                    model.SendTime = DateTime.Parse(ds.Tables[0].Rows[0]["SendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceiveTime"].ToString() != "")
                {
                    model.ReceiveTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReceiveTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ApplyTime"].ToString() != "")
                {
                    model.ApplyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ApplyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FinishTime"].ToString() != "")
                {
                    model.FinishTime = DateTime.Parse(ds.Tables[0].Rows[0]["FinishTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSettle"].ToString() != "")
                {
                    model.IsSettle = int.Parse(ds.Tables[0].Rows[0]["IsSettle"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SettleTime"].ToString() != "")
                {
                    model.SettleTime = DateTime.Parse(ds.Tables[0].Rows[0]["SettleTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                if (ds.Tables[0].Rows[0]["IntegralAmount"].ToString() != "")
                {
                    model.IntegralAmount = decimal.Parse(ds.Tables[0].Rows[0]["IntegralAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PurchaseAmount"].ToString() != "")
                {
                    model.PurchaseAmount = decimal.Parse(ds.Tables[0].Rows[0]["PurchaseAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SellAmount"].ToString() != "")
                {
                    model.SellAmount = decimal.Parse(ds.Tables[0].Rows[0]["SellAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyTime"].ToString() != "")
                {
                    model.BuyTime = DateTime.Parse(ds.Tables[0].Rows[0]["BuyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order001"].ToString() != "")
                {
                    model.order001 = int.Parse(ds.Tables[0].Rows[0]["order001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order002"].ToString() != "")
                {
                    model.order002 = decimal.Parse(ds.Tables[0].Rows[0]["order002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceivieAddress"].ToString() != "")
                {
                    model.ReceivieAddress = ds.Tables[0].Rows[0]["ReceivieAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Province"].ToString() != "")
                {
                    model.Province = ds.Tables[0].Rows[0]["Province"].ToString();
                }
                if (ds.Tables[0].Rows[0]["City"].ToString() != "")
                {
                    model.City = ds.Tables[0].Rows[0]["City"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Country"].ToString() != "")
                {
                    model.Country = ds.Tables[0].Rows[0]["Country"].ToString();
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
            strSql.Append("select o.*,u.UserCode,u.TrueName ");
            strSql.Append(" FROM tb_UserOrder as o inner join tb_user as u on o.UserID=u.UserID ");
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
            strSql.Append(" FROM tb_UserOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
