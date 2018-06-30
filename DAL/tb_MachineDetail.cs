using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DataAccess;

namespace lgk.DAL
{
    //tb_MachineDetail
    public partial class tb_MachineDetail
    {

        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_MachineDetail");
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
        public long Add(lgk.Model.tb_MachineDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_MachineDetail(");
            strSql.Append("BuyMachineID,MachineNo,BuyTime,ActiveTime,IsActive,TransferTime,IsTransfer,UserID");
            strSql.Append(") values (");
            strSql.Append("@BuyMachineID,@MachineNo,@BuyTime,@ActiveTime,@IsActive,@TransferTime,@IsTransfer,@UserID");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@BuyMachineID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@MachineNo", SqlDbType.VarChar,20) ,
                        new SqlParameter("@BuyTime", SqlDbType.DateTime) ,
                        new SqlParameter("@ActiveTime", SqlDbType.DateTime) ,
                        new SqlParameter("@IsActive", SqlDbType.Int,4) ,
                        new SqlParameter("@TransferTime", SqlDbType.DateTime) ,
                        new SqlParameter("@IsTransfer", SqlDbType.Int,4),
                        new SqlParameter("@UserID", SqlDbType.BigInt,8)

            };

            parameters[0].Value = model.BuyMachineID;
            parameters[1].Value = model.MachineNo;
            parameters[2].Value = model.BuyTime;
            parameters[3].Value = model.ActiveTime;
            parameters[4].Value = model.IsActive;
            parameters[5].Value = model.TransferTime;
            parameters[6].Value = model.IsTransfer;
            parameters[7].Value = model.UserID;

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
        public bool Update(lgk.Model.tb_MachineDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_MachineDetail set ");

            strSql.Append(" BuyMachineID = @BuyMachineID , ");
            strSql.Append(" MachineNo = @MachineNo , ");
            strSql.Append(" BuyTime = @BuyTime , ");
            strSql.Append(" ActiveTime = @ActiveTime , ");
            strSql.Append(" IsActive = @IsActive , ");
            strSql.Append(" TransferTime = @TransferTime , ");
            strSql.Append(" IsTransfer = @IsTransfer , ");
            strSql.Append(" UserID = @UserID  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@BuyMachineID", SqlDbType.BigInt,8) ,
                        new SqlParameter("@MachineNo", SqlDbType.VarChar,20) ,
                        new SqlParameter("@BuyTime", SqlDbType.DateTime) ,
                        new SqlParameter("@ActiveTime", SqlDbType.DateTime) ,
                        new SqlParameter("@IsActive", SqlDbType.Int,4) ,
                        new SqlParameter("@TransferTime", SqlDbType.DateTime) ,
                        new SqlParameter("@IsTransfer", SqlDbType.Int,4),
                        new SqlParameter("@UserID", SqlDbType.BigInt,8)

            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.BuyMachineID;
            parameters[2].Value = model.MachineNo;
            parameters[3].Value = model.BuyTime;
            parameters[4].Value = model.ActiveTime;
            parameters[5].Value = model.IsActive;
            parameters[6].Value = model.TransferTime;
            parameters[7].Value = model.IsTransfer;
            parameters[8].Value = model.UserID;
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
            strSql.Append("delete from tb_MachineDetail ");
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
            strSql.Append("delete from tb_MachineDetail ");
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
        public lgk.Model.tb_MachineDetail GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, UserID,BuyMachineID, MachineNo, BuyTime, ActiveTime, IsActive, TransferTime, IsTransfer  ");
            strSql.Append("  from tb_MachineDetail ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt)
            };
            parameters[0].Value = ID;


            lgk.Model.tb_MachineDetail model = new lgk.Model.tb_MachineDetail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BuyMachineID"].ToString() != "")
                {
                    model.BuyMachineID = long.Parse(ds.Tables[0].Rows[0]["BuyMachineID"].ToString());
                }
                model.MachineNo = ds.Tables[0].Rows[0]["MachineNo"].ToString();
                if (ds.Tables[0].Rows[0]["BuyTime"].ToString() != "")
                {
                    model.BuyTime = DateTime.Parse(ds.Tables[0].Rows[0]["BuyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ActiveTime"].ToString() != "")
                {
                    model.ActiveTime = DateTime.Parse(ds.Tables[0].Rows[0]["ActiveTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsActive"].ToString() != "")
                {
                    model.IsActive = int.Parse(ds.Tables[0].Rows[0]["IsActive"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TransferTime"].ToString() != "")
                {
                    model.TransferTime = DateTime.Parse(ds.Tables[0].Rows[0]["TransferTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsTransfer"].ToString() != "")
                {
                    model.IsTransfer = int.Parse(ds.Tables[0].Rows[0]["IsTransfer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
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
            strSql.Append(" FROM tb_MachineDetail ");
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
            strSql.Append(" FROM tb_MachineDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 激活
        /// </summary>
        /// <param name="MachineID"></param>
        /// <returns>返回 2 是成功</returns>
        public int proc_MachineActive(long MachineID)
        {
            int result = 0;
            int rowsAffected;
            SqlParameter[] parameters = {
                          new SqlParameter("@MachineID", SqlDbType.BigInt,8)
                          };
            parameters[0].Value = MachineID;
            result = DbHelperSQL.RunProcedure("proc_MachineActive", parameters, out rowsAffected);

            return result;
        }

    }
}

