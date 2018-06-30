using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_journal
    /// </summary>
    public partial class tb_journal
    {
        public tb_journal()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_journal");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_journal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_journal(");
            strSql.Append("UserID,Remark,RemarkEn,InAmount,OutAmount,BalanceAmount,JournalDate,JournalType,Journal01,Journal02,Journal03,Journal04,Journal05,Journal06,Journal07)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@Remark,@RemarkEn,@InAmount,@OutAmount,@BalanceAmount,@JournalDate,@JournalType,@Journal01,@Journal02,@Journal03,@Journal04,@Journal05,@Journal06,@Journal07)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@Remark", SqlDbType.VarChar,500),
					new SqlParameter("@RemarkEn", SqlDbType.VarChar,500),
                    new SqlParameter("@InAmount", SqlDbType.Decimal,9),
					new SqlParameter("@OutAmount", SqlDbType.Decimal,9),
					new SqlParameter("@BalanceAmount", SqlDbType.Decimal,9),
					new SqlParameter("@JournalDate", SqlDbType.DateTime),
					new SqlParameter("@JournalType", SqlDbType.Int,4),
					new SqlParameter("@Journal01", SqlDbType.BigInt,8),
					new SqlParameter("@Journal02", SqlDbType.Int,4),
					new SqlParameter("@Journal03", SqlDbType.VarChar,50),
					new SqlParameter("@Journal04", SqlDbType.VarChar,50),
					new SqlParameter("@Journal05", SqlDbType.Decimal,9),
					new SqlParameter("@Journal06", SqlDbType.Decimal,9),
					new SqlParameter("@Journal07", SqlDbType.DateTime)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.RemarkEn;
            parameters[3].Value = model.InAmount;
            parameters[4].Value = model.OutAmount;
            parameters[5].Value = model.BalanceAmount;
            parameters[6].Value = model.JournalDate;
            parameters[7].Value = model.JournalType;
            parameters[8].Value = model.Journal01;
            parameters[9].Value = model.Journal02;
            parameters[10].Value = model.Journal03;
            parameters[11].Value = model.Journal04;
            parameters[12].Value = model.Journal05;
            parameters[13].Value = model.Journal06;
            parameters[14].Value = model.Journal07;

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
        public bool Update(lgk.Model.tb_journal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_journal set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("InAmount=@InAmount,");
            strSql.Append("OutAmount=@OutAmount,");
            strSql.Append("BalanceAmount=@BalanceAmount,");
            strSql.Append("JournalDate=@JournalDate,");
            strSql.Append("JournalType=@JournalType,");
            strSql.Append("Journal01=@Journal01,");
            strSql.Append("Journal02=@Journal02,");
            strSql.Append("Journal03=@Journal03,");
            strSql.Append("Journal04=@Journal04,");
            strSql.Append("Journal05=@Journal05,");
            strSql.Append("Journal06=@Journal06,");
            strSql.Append("Journal07=@Journal07");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@InAmount", SqlDbType.Decimal,9),
					new SqlParameter("@OutAmount", SqlDbType.Decimal,9),
					new SqlParameter("@BalanceAmount", SqlDbType.Decimal,9),
					new SqlParameter("@JournalDate", SqlDbType.DateTime),
					new SqlParameter("@JournalType", SqlDbType.Int,4),
					new SqlParameter("@Journal01", SqlDbType.BigInt,8),
					new SqlParameter("@Journal02", SqlDbType.Int,4),
					new SqlParameter("@Journal03", SqlDbType.VarChar,50),
					new SqlParameter("@Journal04", SqlDbType.VarChar,50),
					new SqlParameter("@Journal05", SqlDbType.Decimal,9),
					new SqlParameter("@Journal06", SqlDbType.Decimal,9),
					new SqlParameter("@Journal07", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.InAmount;
            parameters[3].Value = model.OutAmount;
            parameters[4].Value = model.BalanceAmount;
            parameters[5].Value = model.JournalDate;
            parameters[6].Value = model.JournalType;
            parameters[7].Value = model.Journal01;
            parameters[8].Value = model.Journal02;
            parameters[9].Value = model.Journal03;
            parameters[10].Value = model.Journal04;
            parameters[11].Value = model.Journal05;
            parameters[12].Value = model.Journal06;
            parameters[13].Value = model.Journal07;
            parameters[14].Value = model.ID;

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
            strSql.Append("delete from tb_journal ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
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
            strSql.Append("delete from tb_journal ");
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
        public lgk.Model.tb_journal GetModel(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,Remark,Remarken,InAmount,OutAmount,BalanceAmount,JournalDate,JournalType,Journal01,Journal02,Journal03,Journal04,Journal05,Journal06,Journal07,TakeType from tb_journal ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = ID;

            lgk.Model.tb_journal model = new lgk.Model.tb_journal();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["InAmount"] != null && ds.Tables[0].Rows[0]["InAmount"].ToString() != "")
                {
                    model.InAmount = decimal.Parse(ds.Tables[0].Rows[0]["InAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutAmount"] != null && ds.Tables[0].Rows[0]["OutAmount"].ToString() != "")
                {
                    model.OutAmount = decimal.Parse(ds.Tables[0].Rows[0]["OutAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BalanceAmount"] != null && ds.Tables[0].Rows[0]["BalanceAmount"].ToString() != "")
                {
                    model.BalanceAmount = decimal.Parse(ds.Tables[0].Rows[0]["BalanceAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["JournalDate"] != null && ds.Tables[0].Rows[0]["JournalDate"].ToString() != "")
                {
                    model.JournalDate = DateTime.Parse(ds.Tables[0].Rows[0]["JournalDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["JournalType"] != null && ds.Tables[0].Rows[0]["JournalType"].ToString() != "")
                {
                    model.JournalType = int.Parse(ds.Tables[0].Rows[0]["JournalType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Journal01"] != null && ds.Tables[0].Rows[0]["Journal01"].ToString() != "")
                {
                    model.Journal01 = long.Parse(ds.Tables[0].Rows[0]["Journal01"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Journal02"] != null && ds.Tables[0].Rows[0]["Journal02"].ToString() != "")
                {
                    model.Journal02 = int.Parse(ds.Tables[0].Rows[0]["Journal02"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Journal03"] != null && ds.Tables[0].Rows[0]["Journal03"].ToString() != "")
                {
                    model.Journal03 = ds.Tables[0].Rows[0]["Journal03"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Journal04"] != null && ds.Tables[0].Rows[0]["Journal04"].ToString() != "")
                {
                    model.Journal04 = ds.Tables[0].Rows[0]["Journal04"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Journal05"] != null && ds.Tables[0].Rows[0]["Journal05"].ToString() != "")
                {
                    model.Journal05 = decimal.Parse(ds.Tables[0].Rows[0]["Journal05"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Journal06"] != null && ds.Tables[0].Rows[0]["Journal06"].ToString() != "")
                {
                    model.Journal06 = decimal.Parse(ds.Tables[0].Rows[0]["Journal06"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Journal07"] != null && ds.Tables[0].Rows[0]["Journal07"].ToString() != "")
                {
                    model.Journal07 = DateTime.Parse(ds.Tables[0].Rows[0]["Journal07"].ToString());
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
            strSql.Append("SELECT ID,j.UserID,UserCode,Remark,Remarken,InAmount,OutAmount,BalanceAmount,JournalDate,JournalType,Journal01,Journal02,Journal03,Journal04,Journal05,Journal06,Journal07");
            strSql.Append(" FROM tb_journal j JOIN tb_user u ON j.UserID=u.UserID ");
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
            strSql.Append(" ID,UserID,Remark,Remarken,InAmount,OutAmount,BalanceAmount,JournalDate,JournalType,Journal01,Journal02,Journal03,Journal04,Journal05,Journal06,Journal07");
            strSql.Append(" FROM tb_journal ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ISNULL(COUNT(*),0) From tb_journal ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
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
            parameters[0].Value = "tb_journal";
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

