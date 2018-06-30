using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_takeMoney
    /// </summary>
    public partial class tb_takeMoney
    {
        public tb_takeMoney()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "tb_takeMoney");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_takeMoney");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_takeMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_takeMoney(");
            strSql.Append("TakeTime,TakeMoney,TakePoundage,RealityMoney,BonusBalance,Flag,UserID,BankName,BankAccount,BankAccountUser,BankDian,Take001,Take002,Take003,Take004,Take005,Take006)");
            strSql.Append(" values (");
            strSql.Append("@TakeTime,@TakeMoney,@TakePoundage,@RealityMoney,@BonusBalance,@Flag,@UserID,@BankName,@BankAccount,@BankAccountUser,@BankDian,@Take001,@Take002,@Take003,@Take004,@Take005,@Take006)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TakeTime", SqlDbType.DateTime),
					new SqlParameter("@TakeMoney", SqlDbType.Decimal,9),
					new SqlParameter("@TakePoundage", SqlDbType.Decimal,9),
					new SqlParameter("@RealityMoney", SqlDbType.Decimal,9),
					new SqlParameter("@BonusBalance", SqlDbType.Decimal,9),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.VarChar,100),
					new SqlParameter("@BankAccount", SqlDbType.VarChar,100),
					new SqlParameter("@BankAccountUser", SqlDbType.VarChar,100),
					new SqlParameter("@BankDian", SqlDbType.VarChar,100),
					new SqlParameter("@Take001", SqlDbType.Int,4),
					new SqlParameter("@Take002", SqlDbType.Int,4),
					new SqlParameter("@Take003", SqlDbType.VarChar,100),
					new SqlParameter("@Take004", SqlDbType.VarChar,100),
					new SqlParameter("@Take005", SqlDbType.Decimal,9),
					new SqlParameter("@Take006", SqlDbType.DateTime,9)};
            parameters[0].Value = model.TakeTime;
            parameters[1].Value = model.TakeMoney;
            parameters[2].Value = model.TakePoundage;
            parameters[3].Value = model.RealityMoney;
            parameters[4].Value = model.BonusBalance;
            parameters[5].Value = model.Flag;
            parameters[6].Value = model.UserID;
            parameters[7].Value = model.BankName;
            parameters[8].Value = model.BankAccount;
            parameters[9].Value = model.BankAccountUser;
            parameters[10].Value = model.BankDian;
            parameters[11].Value = model.Take001;
            parameters[12].Value = model.Take002;
            parameters[13].Value = model.Take003;
            parameters[14].Value = model.Take004;
            parameters[15].Value = model.Take005;
            parameters[16].Value = model.Take006;

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
        public bool Update(lgk.Model.tb_takeMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_takeMoney set ");
            strSql.Append("TakeTime=@TakeTime,");
            strSql.Append("TakeMoney=@TakeMoney,");
            strSql.Append("TakePoundage=@TakePoundage,");
            strSql.Append("RealityMoney=@RealityMoney,");
            strSql.Append("BonusBalance=@BonusBalance,");
            strSql.Append("Flag=@Flag,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BankAccount=@BankAccount,");
            strSql.Append("BankAccountUser=@BankAccountUser,");
            strSql.Append("BankDian=@BankDian,");
            strSql.Append("Take001=@Take001,");
            strSql.Append("Take002=@Take002,");
            strSql.Append("Take003=@Take003,");
            strSql.Append("Take004=@Take004,");
            strSql.Append("Take005=@Take005,");
            strSql.Append("Take006=@Take006");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@TakeTime", SqlDbType.DateTime),
					new SqlParameter("@TakeMoney", SqlDbType.Decimal,9),
					new SqlParameter("@TakePoundage", SqlDbType.Decimal,9),
					new SqlParameter("@RealityMoney", SqlDbType.Decimal,9),
					new SqlParameter("@BonusBalance", SqlDbType.Decimal,9),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.VarChar,100),
					new SqlParameter("@BankAccount", SqlDbType.VarChar,100),
					new SqlParameter("@BankAccountUser", SqlDbType.VarChar,100),
					new SqlParameter("@BankDian", SqlDbType.VarChar,100),
					new SqlParameter("@Take001", SqlDbType.Int,4),
					new SqlParameter("@Take002", SqlDbType.Int,4),
					new SqlParameter("@Take003", SqlDbType.VarChar,100),
					new SqlParameter("@Take004", SqlDbType.VarChar,100),
					new SqlParameter("@Take005", SqlDbType.Decimal,9),
					new SqlParameter("@Take006", SqlDbType.DateTime,9),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.TakeTime;
            parameters[1].Value = model.TakeMoney;
            parameters[2].Value = model.TakePoundage;
            parameters[3].Value = model.RealityMoney;
            parameters[4].Value = model.BonusBalance;
            parameters[5].Value = model.Flag;
            parameters[6].Value = model.UserID;
            parameters[7].Value = model.BankName;
            parameters[8].Value = model.BankAccount;
            parameters[9].Value = model.BankAccountUser;
            parameters[10].Value = model.BankDian;
            parameters[11].Value = model.Take001;
            parameters[12].Value = model.Take002;
            parameters[13].Value = model.Take003;
            parameters[14].Value = model.Take004;
            parameters[15].Value = model.Take005;
            parameters[16].Value = model.Take006;
            parameters[17].Value = model.ID;

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
            strSql.Append("delete from tb_takeMoney ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_takeMoney ");
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
        /// 更改
        /// </summary>
        /// <param name="UserID">理财者ID</param>

        /// <returns></returns>
        public int UpdateFlag(long UserID,long ID)
        {
            string sql = "update tb_takeMoney set Flag=-1 where Flag =0 and UserID =" + UserID + " and  ID =" + ID;

            return DbHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_takeMoney GetModel(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,TakeTime,TakeMoney,TakePoundage,RealityMoney,BonusBalance,Flag,UserID,BankName,BankAccount,BankAccountUser,BankDian,Take001,Take002,Take003,Take004,Take005,Take006 from tb_takeMoney ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = ID;

            lgk.Model.tb_takeMoney model = new lgk.Model.tb_takeMoney();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TakeTime"] != null && ds.Tables[0].Rows[0]["TakeTime"].ToString() != "")
                {
                    model.TakeTime = DateTime.Parse(ds.Tables[0].Rows[0]["TakeTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TakeMoney"] != null && ds.Tables[0].Rows[0]["TakeMoney"].ToString() != "")
                {
                    model.TakeMoney = decimal.Parse(ds.Tables[0].Rows[0]["TakeMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TakePoundage"] != null && ds.Tables[0].Rows[0]["TakePoundage"].ToString() != "")
                {
                    model.TakePoundage = decimal.Parse(ds.Tables[0].Rows[0]["TakePoundage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RealityMoney"] != null && ds.Tables[0].Rows[0]["RealityMoney"].ToString() != "")
                {
                    model.RealityMoney = decimal.Parse(ds.Tables[0].Rows[0]["RealityMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BonusBalance"] != null && ds.Tables[0].Rows[0]["BonusBalance"].ToString() != "")
                {
                    model.BonusBalance = decimal.Parse(ds.Tables[0].Rows[0]["BonusBalance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag"] != null && ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankName"] != null && ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                {
                    model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccount"] != null && ds.Tables[0].Rows[0]["BankAccount"].ToString() != "")
                {
                    model.BankAccount = ds.Tables[0].Rows[0]["BankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccountUser"] != null && ds.Tables[0].Rows[0]["BankAccountUser"].ToString() != "")
                {
                    model.BankAccountUser = ds.Tables[0].Rows[0]["BankAccountUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankDian"] != null && ds.Tables[0].Rows[0]["BankDian"].ToString() != "")
                {
                    model.BankDian = ds.Tables[0].Rows[0]["BankDian"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Take001"] != null && ds.Tables[0].Rows[0]["Take001"].ToString() != "")
                {
                    model.Take001 = int.Parse(ds.Tables[0].Rows[0]["Take001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Take002"] != null && ds.Tables[0].Rows[0]["Take002"].ToString() != "")
                {
                    model.Take002 = int.Parse(ds.Tables[0].Rows[0]["Take002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Take003"] != null && ds.Tables[0].Rows[0]["Take003"].ToString() != "")
                {
                    model.Take003 = ds.Tables[0].Rows[0]["Take003"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Take004"] != null && ds.Tables[0].Rows[0]["Take004"].ToString() != "")
                {
                    model.Take004 = ds.Tables[0].Rows[0]["Take004"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Take005"] != null && ds.Tables[0].Rows[0]["Take005"].ToString() != "")
                {
                    model.Take005 = decimal.Parse(ds.Tables[0].Rows[0]["Take005"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Take006"] != null && ds.Tables[0].Rows[0]["Take006"].ToString() != "")
                {
                    model.Take006 = DateTime.Parse(ds.Tables[0].Rows[0]["Take006"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public lgk.Model.tb_takeMoney GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,TakeTime,TakeMoney,TakePoundage,RealityMoney,BonusBalance,Flag,UserID,BankName,BankAccount,BankAccountUser,BankDian,Take001,Take002,Take003,Take004,Take005,Take006 from tb_takeMoney ");
            if (where != "")
            {
                strSql.Append(" where "+ where);
            }
            lgk.Model.tb_takeMoney model = new lgk.Model.tb_takeMoney();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TakeTime"] != null && ds.Tables[0].Rows[0]["TakeTime"].ToString() != "")
                {
                    model.TakeTime = DateTime.Parse(ds.Tables[0].Rows[0]["TakeTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TakeMoney"] != null && ds.Tables[0].Rows[0]["TakeMoney"].ToString() != "")
                {
                    model.TakeMoney = decimal.Parse(ds.Tables[0].Rows[0]["TakeMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TakePoundage"] != null && ds.Tables[0].Rows[0]["TakePoundage"].ToString() != "")
                {
                    model.TakePoundage = decimal.Parse(ds.Tables[0].Rows[0]["TakePoundage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RealityMoney"] != null && ds.Tables[0].Rows[0]["RealityMoney"].ToString() != "")
                {
                    model.RealityMoney = decimal.Parse(ds.Tables[0].Rows[0]["RealityMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BonusBalance"] != null && ds.Tables[0].Rows[0]["BonusBalance"].ToString() != "")
                {
                    model.BonusBalance = decimal.Parse(ds.Tables[0].Rows[0]["BonusBalance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag"] != null && ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BankName"] != null && ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                {
                    model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccount"] != null && ds.Tables[0].Rows[0]["BankAccount"].ToString() != "")
                {
                    model.BankAccount = ds.Tables[0].Rows[0]["BankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccountUser"] != null && ds.Tables[0].Rows[0]["BankAccountUser"].ToString() != "")
                {
                    model.BankAccountUser = ds.Tables[0].Rows[0]["BankAccountUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankDian"] != null && ds.Tables[0].Rows[0]["BankDian"].ToString() != "")
                {
                    model.BankDian = ds.Tables[0].Rows[0]["BankDian"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Take001"] != null && ds.Tables[0].Rows[0]["Take001"].ToString() != "")
                {
                    model.Take001 = int.Parse(ds.Tables[0].Rows[0]["Take001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Take002"] != null && ds.Tables[0].Rows[0]["Take002"].ToString() != "")
                {
                    model.Take002 = int.Parse(ds.Tables[0].Rows[0]["Take002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Take003"] != null && ds.Tables[0].Rows[0]["Take003"].ToString() != "")
                {
                    model.Take003 = ds.Tables[0].Rows[0]["Take003"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Take004"] != null && ds.Tables[0].Rows[0]["Take004"].ToString() != "")
                {
                    model.Take004 = ds.Tables[0].Rows[0]["Take004"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Take005"] != null && ds.Tables[0].Rows[0]["Take005"].ToString() != "")
                {
                    model.Take005 = decimal.Parse(ds.Tables[0].Rows[0]["Take005"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Take006"] != null && ds.Tables[0].Rows[0]["Take006"].ToString() != "")
                {
                    model.Take006 = DateTime.Parse(ds.Tables[0].Rows[0]["Take006"].ToString());
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
            strSql.Append("SELECT ID,TakeTime,TakeMoney,TakePoundage,RealityMoney,BonusBalance,Flag,UserID,BankName,BankAccount,BankAccountUser,BankDian,Take001,Take002,Take003,Take004,Take005,Take006");
            strSql.Append(" FROM tb_takeMoney ");
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
            strSql.Append("SELECT ");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString());
            }
            strSql.Append(" ID,TakeTime,TakeMoney,TakePoundage,RealityMoney,BonusBalance,Flag,UserID,BankName,BankAccount,BankAccountUser,BankDian,Take001,Take002,Take003,Take004,Take005,Take006,TakeType ");
            strSql.Append(" FROM tb_takeMoney ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tb_takeMoney";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}

