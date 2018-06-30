using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_UserBank
    /// </summary>
    public partial class tb_UserBank
    {
        public tb_UserBank()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_UserBank");
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
        public int Add(lgk.Model.tb_UserBank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_UserBank(");
            strSql.Append("UserID,BankName,BankAccount,BankAccountUser,BankAddress,MasterType,Bank001,Bank002,Bank003,Bank004)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@BankName,@BankAccount,@BankAccountUser,@BankAddress,@MasterType,@Bank001,@Bank002,@Bank003,@Bank004)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@BankName", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccountUser", SqlDbType.VarChar,50),
					new SqlParameter("@BankAddress", SqlDbType.VarChar,100),
					new SqlParameter("@MasterType", SqlDbType.Int,4),
					new SqlParameter("@Bank001", SqlDbType.VarChar,50),
					new SqlParameter("@Bank002", SqlDbType.VarChar,50),
					new SqlParameter("@Bank003", SqlDbType.Int,4),
					new SqlParameter("@Bank004", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.BankName;
            parameters[2].Value = model.BankAccount;
            parameters[3].Value = model.BankAccountUser;
            parameters[4].Value = model.BankAddress;
            parameters[5].Value = model.MasterType;
            parameters[6].Value = model.Bank001;
            parameters[7].Value = model.Bank002;
            parameters[8].Value = model.Bank003;
            parameters[9].Value = model.Bank004;

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
        public bool Update(lgk.Model.tb_UserBank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_UserBank set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BankAccount=@BankAccount,");
            strSql.Append("BankAccountUser=@BankAccountUser,");
            strSql.Append("BankAddress=@BankAddress,");
            strSql.Append("MasterType=@MasterType,");
            strSql.Append("Bank001=@Bank001,");
            strSql.Append("Bank002=@Bank002,");
            strSql.Append("Bank003=@Bank003,");
            strSql.Append("Bank004=@Bank004");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@BankName", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccountUser", SqlDbType.VarChar,50),
					new SqlParameter("@BankAddress", SqlDbType.VarChar,100),
					new SqlParameter("@MasterType", SqlDbType.Int,4),
					new SqlParameter("@Bank001", SqlDbType.VarChar,50),
					new SqlParameter("@Bank002", SqlDbType.VarChar,50),
					new SqlParameter("@Bank003", SqlDbType.Int,4),
					new SqlParameter("@Bank004", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.BankName;
            parameters[2].Value = model.BankAccount;
            parameters[3].Value = model.BankAccountUser;
            parameters[4].Value = model.BankAddress;
            parameters[5].Value = model.MasterType;
            parameters[6].Value = model.Bank001;
            parameters[7].Value = model.Bank002;
            parameters[8].Value = model.Bank003;
            parameters[9].Value = model.Bank004;
            parameters[10].Value = model.ID;

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
            strSql.Append("delete from tb_UserBank ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_UserBank ");
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
        public lgk.Model.tb_UserBank GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,BankName,BankAccount,BankAccountUser,BankAddress,MasterType,Bank001,Bank002,Bank003,Bank004 from tb_UserBank ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            lgk.Model.tb_UserBank model = new lgk.Model.tb_UserBank();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_UserBank GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,BankName,BankAccount,BankAccountUser,BankAddress,MasterType,Bank001,Bank002,Bank003,Bank004 from tb_UserBank");
            strSql.Append(" where " + strWhere);
            strSql.Append(" order by ID asc ");
            lgk.Model.tb_UserBank model = new lgk.Model.tb_UserBank();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 更改默认值
        /// </summary>
        /// <param name="UserID">理财者ID</param>
      
        /// <returns></returns>
        public int UpdateDefaults(long UserID)
        {
            string sql = "update tb_UserBank set MasterType=0 where MasterType =1 and UserID=" + UserID;
                
            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 删除标记
        /// </summary>
        /// <param name="UserID">理财者ID</param>

        /// <returns></returns>
        public int UpdateBank(long UserID, long ID)
        {
            string sql = "update tb_UserBank set Bank004=-1 where Bank004 =0 and UserID =" + UserID + " and  ID =" + ID;

            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 自动设置默认
        /// </summary>
        /// <param name="UserID">理财者ID</param>
        /// <returns></returns>
        public int AutoSetDefault(long UserID)
        {
            string sql = "update tb_UserBank set MasterType = 1 where id = (select max(ID) from tb_UserBank where Bank004 = 0 and UserID = " + UserID + ")";
            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 设置默认
        /// </summary>
        /// <param name="UserID">理财者ID</param>
        /// <returns></returns>
        public int SetDefault(long UserID, long ID)
        {
            string sql = "update tb_UserBank set MasterType = 0 where UserID = " + UserID + ";";
            sql += "update tb_UserBank set MasterType = 1 where UserID = " + UserID + " and ID = "+ ID;
            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_UserBank DataRowToModel(DataRow row)
        {
            lgk.Model.tb_UserBank model = new lgk.Model.tb_UserBank();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(row["UserID"].ToString());
                }
                if (row["BankName"] != null)
                {
                    model.BankName = row["BankName"].ToString();
                }
                if (row["BankAccount"] != null)
                {
                    model.BankAccount = row["BankAccount"].ToString();
                }
                if (row["BankAccountUser"] != null)
                {
                    model.BankAccountUser = row["BankAccountUser"].ToString();
                }
                if (row["BankAddress"] != null)
                {
                    model.BankAddress = row["BankAddress"].ToString();
                }
                if (row["MasterType"] != null && row["MasterType"].ToString() != "")
                {
                    model.MasterType = int.Parse(row["MasterType"].ToString());
                }
                if (row["Bank001"] != null)
                {
                    model.Bank001 = row["Bank001"].ToString();
                }
                if (row["Bank002"] != null)
                {
                    model.Bank002 = row["Bank002"].ToString();
                }
                if (row["Bank003"] != null && row["Bank003"].ToString() != "")
                {
                    model.Bank003 = int.Parse(row["Bank003"].ToString());
                }
                if (row["Bank004"] != null && row["Bank004"].ToString() != "")
                {
                    model.Bank004 = int.Parse(row["Bank004"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserID,BankName,BankAccount,BankAccountUser,BankAddress,MasterType,Bank001,Bank002,Bank003,Bank004 ");
            strSql.Append(" FROM tb_UserBank ");
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
            strSql.Append(" ID,UserID,BankName,BankAccount,BankAccountUser,BankAddress,MasterType,Bank001,Bank002,Bank003,Bank004 ");
            strSql.Append(" FROM tb_UserBank ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_UserBank ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_UserBank T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
            parameters[0].Value = "tb_UserBank";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

