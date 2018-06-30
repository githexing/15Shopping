using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;
namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_agent1
    /// </summary>
    public partial class tb_agent1
    {
        public tb_agent1()
        { }
        /// <summary>
        /// 验证报单中心名是否可用 
        /// </summary>
        /// <param name="users02"></param>
        /// <returns></returns>
        public bool isExistByName(string AgentCode)
        {
            string sqlstr1 = "select count(*) from tb_agent1 where  AgentCode='" + AgentCode + "' and Flag  = 1";
            if (int.Parse(DataAccess.DbHelperSQL.GetSingle(sqlstr1).ToString()) > 0)
            {
                return true;
            }
            else
            { return false; }
        }
        public int GetAgentsID(string AgentCode)
        {
            string strSQL = "select ID FROM tb_agent1 WHERE AgentCode='" + AgentCode + "'";
            object oj = DbHelperSQL.GetSingle(strSQL);
            if (oj != null)
            {
                return int.Parse(oj.ToString());
            }
            else
            { return 0; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AgentCode"></param>
        /// <returns></returns>
        public int GetAgentsIDByUserCode(string AgentCode)
        {
            string strSQL = string.Format("SELECT ID FROM tb_agent1 where UserID=(select top 1 UserID from tb_user where UserCode='{0}')", AgentCode);
            object oj = DbHelperSQL.GetSingle(strSQL);
            if (oj != null)
            {
                return int.Parse(oj.ToString());
            }
            else
            { return 0; }
        }

        public long GetUserIDByAgentCode(string AgentCode)
        {
            string strSQL = "SELECT UserID FROM tb_agent1 WHERE AgentCode='" + AgentCode + "'";
            object oj = DbHelperSQL.GetSingle(strSQL);
            if (oj != null)
                return long.Parse(oj.ToString());
            else
                return 0;
        }

        public long GetUserIDByAgentID(long iAgentID)
        {
            string strSQL = "SELECT UserID FROM tb_agent1 WHERE ID=" + iAgentID + "";
            object oj = DbHelperSQL.GetSingle(strSQL);
            if (oj != null)
                return long.Parse(oj.ToString());
            else
                return 0;
        }

        public int GetIDByIDUser(long iUserID)
        {
            string strSQL = "SELECT ID FROM tb_agent1 WHERE UserID=" + iUserID;
            object oj = DbHelperSQL.GetSingle(strSQL);
            if (oj != null)
            {
                return int.Parse(oj.ToString());
            }
            else
            { return 0; }
        }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_agent1");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt)
};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_agent1 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_agent1(");
            strSql.Append("AgentCode,Flag,UserID,AgentType,AppliTime,JoinMoney,OpenTime,PicLink,AgentInProvince,AgentInCity,AgentAddress,Agent001,Agent002,Agent003,Agent004,Agent005,Agent006)");
            strSql.Append(" values (");
            strSql.Append("@AgentCode,@Flag,@UserID,@AgentType,@AppliTime,@JoinMoney,@OpenTime,@PicLink,@AgentInProvince,@AgentInCity,@AgentAddress,@Agent001,@Agent002,@Agent003,@Agent004,@Agent005,@Agent006)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@AgentCode", SqlDbType.VarChar,50),
                    new SqlParameter("@Flag", SqlDbType.Int,4),
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@AgentType", SqlDbType.Int,4),
                    new SqlParameter("@AppliTime", SqlDbType.DateTime),
                    new SqlParameter("@JoinMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@OpenTime", SqlDbType.DateTime),
                    new SqlParameter("@PicLink", SqlDbType.VarChar,50),
                    new SqlParameter("@AgentInProvince", SqlDbType.VarChar,50),
                    new SqlParameter("@AgentInCity", SqlDbType.VarChar,50),
                    new SqlParameter("@AgentAddress", SqlDbType.VarChar,50),
                    new SqlParameter("@Agent001", SqlDbType.Int,4),
                    new SqlParameter("@Agent002", SqlDbType.Int,4),
                    new SqlParameter("@Agent003", SqlDbType.VarChar,50),
                    new SqlParameter("@Agent004", SqlDbType.VarChar,50),
                    new SqlParameter("@Agent005", SqlDbType.Decimal,9),
                    new SqlParameter("@Agent006", SqlDbType.Decimal,9)};
            parameters[0].Value = model.AgentCode;
            parameters[1].Value = model.Flag;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.AgentType;
            parameters[4].Value = model.AppliTime;
            parameters[5].Value = model.JoinMoney;
            parameters[6].Value = model.OpenTime;
            parameters[7].Value = model.PicLink;
            parameters[8].Value = model.AgentInProvince;
            parameters[9].Value = model.AgentInCity;
            parameters[10].Value = model.AgentAddress;
            parameters[11].Value = model.Agent001;
            parameters[12].Value = model.Agent002;
            parameters[13].Value = model.Agent003;
            parameters[14].Value = model.Agent004;
            parameters[15].Value = model.Agent005;
            parameters[16].Value = model.Agent006;

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
        public bool Update(lgk.Model.tb_agent1 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_agent1 set ");
            strSql.Append("AgentCode=@AgentCode,");
            strSql.Append("Flag=@Flag,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("AgentType=@AgentType,");
            strSql.Append("AppliTime=@AppliTime,");
            strSql.Append("JoinMoney=@JoinMoney,");
            strSql.Append("OpenTime=@OpenTime,");
            strSql.Append("PicLink=@PicLink,");
            strSql.Append("AgentInProvince=@AgentInProvince,");
            strSql.Append("AgentInCity=@AgentInCity,");
            strSql.Append("AgentAddress=@AgentAddress,");
            strSql.Append("Agent001=@Agent001,");
            strSql.Append("Agent002=@Agent002,");
            strSql.Append("Agent003=@Agent003,");
            strSql.Append("Agent004=@Agent004,");
            strSql.Append("Agent005=@Agent005,");
            strSql.Append("Agent006=@Agent006");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@AgentCode", SqlDbType.VarChar,50),
                    new SqlParameter("@Flag", SqlDbType.Int,4),
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@AgentType", SqlDbType.Int,4),
                    new SqlParameter("@AppliTime", SqlDbType.DateTime),
                    new SqlParameter("@JoinMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@OpenTime", SqlDbType.DateTime),
                    new SqlParameter("@PicLink", SqlDbType.VarChar,50),
                    new SqlParameter("@AgentInProvince", SqlDbType.VarChar,50),
                    new SqlParameter("@AgentInCity", SqlDbType.VarChar,50),
                    new SqlParameter("@AgentAddress", SqlDbType.VarChar,50),
                    new SqlParameter("@Agent001", SqlDbType.Int,4),
                    new SqlParameter("@Agent002", SqlDbType.Int,4),
                    new SqlParameter("@Agent003", SqlDbType.VarChar,50),
                    new SqlParameter("@Agent004", SqlDbType.VarChar,50),
                    new SqlParameter("@Agent005", SqlDbType.Decimal,9),
                    new SqlParameter("@Agent006", SqlDbType.Decimal,9),
                    new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.AgentCode;
            parameters[1].Value = model.Flag;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.AgentType;
            parameters[4].Value = model.AppliTime;
            parameters[5].Value = model.JoinMoney;
            parameters[6].Value = model.OpenTime;
            parameters[7].Value = model.PicLink;
            parameters[8].Value = model.AgentInProvince;
            parameters[9].Value = model.AgentInCity;
            parameters[10].Value = model.AgentAddress;
            parameters[11].Value = model.Agent001;
            parameters[12].Value = model.Agent002;
            parameters[13].Value = model.Agent003;
            parameters[14].Value = model.Agent004;
            parameters[15].Value = model.Agent005;
            parameters[16].Value = model.Agent006;
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
            strSql.Append("delete from tb_agent1 ");
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
            strSql.Append("delete from tb_agent1 ");
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
        public lgk.Model.tb_agent1 GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,AgentCode,Flag,UserID,AgentType,AppliTime,JoinMoney,OpenTime,PicLink,AgentInProvince,AgentInCity,AgentAddress,Agent001,Agent002,Agent003,Agent004,Agent005,Agent006 from tb_agent1 ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt)
            };
            parameters[0].Value = ID;

            lgk.Model.tb_agent1 model = new lgk.Model.tb_agent1();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AgentCode"] != null && ds.Tables[0].Rows[0]["AgentCode"].ToString() != "")
                {
                    model.AgentCode = ds.Tables[0].Rows[0]["AgentCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Flag"] != null && ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AgentType"] != null && ds.Tables[0].Rows[0]["AgentType"].ToString() != "")
                {
                    model.AgentType = int.Parse(ds.Tables[0].Rows[0]["AgentType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AppliTime"] != null && ds.Tables[0].Rows[0]["AppliTime"].ToString() != "")
                {
                    model.AppliTime = DateTime.Parse(ds.Tables[0].Rows[0]["AppliTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["JoinMoney"] != null && ds.Tables[0].Rows[0]["JoinMoney"].ToString() != "")
                {
                    model.JoinMoney = decimal.Parse(ds.Tables[0].Rows[0]["JoinMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OpenTime"] != null && ds.Tables[0].Rows[0]["OpenTime"].ToString() != "")
                {
                    model.OpenTime = DateTime.Parse(ds.Tables[0].Rows[0]["OpenTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PicLink"] != null && ds.Tables[0].Rows[0]["PicLink"].ToString() != "")
                {
                    model.PicLink = ds.Tables[0].Rows[0]["PicLink"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AgentInProvince"] != null && ds.Tables[0].Rows[0]["AgentInProvince"].ToString() != "")
                {
                    model.AgentInProvince = ds.Tables[0].Rows[0]["AgentInProvince"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AgentInCity"] != null && ds.Tables[0].Rows[0]["AgentInCity"].ToString() != "")
                {
                    model.AgentInCity = ds.Tables[0].Rows[0]["AgentInCity"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AgentAddress"] != null && ds.Tables[0].Rows[0]["AgentAddress"].ToString() != "")
                {
                    model.AgentAddress = ds.Tables[0].Rows[0]["AgentAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Agent001"] != null && ds.Tables[0].Rows[0]["Agent001"].ToString() != "")
                {
                    model.Agent001 = int.Parse(ds.Tables[0].Rows[0]["Agent001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Agent002"] != null && ds.Tables[0].Rows[0]["Agent002"].ToString() != "")
                {
                    model.Agent002 = int.Parse(ds.Tables[0].Rows[0]["Agent002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Agent003"] != null && ds.Tables[0].Rows[0]["Agent003"].ToString() != "")
                {
                    model.Agent003 = ds.Tables[0].Rows[0]["Agent003"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Agent004"] != null && ds.Tables[0].Rows[0]["Agent004"].ToString() != "")
                {
                    model.Agent004 = ds.Tables[0].Rows[0]["Agent004"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Agent005"] != null && ds.Tables[0].Rows[0]["Agent005"].ToString() != "")
                {
                    model.Agent005 = decimal.Parse(ds.Tables[0].Rows[0]["Agent005"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Agent006"] != null && ds.Tables[0].Rows[0]["Agent006"].ToString() != "")
                {
                    model.Agent006 = decimal.Parse(ds.Tables[0].Rows[0]["Agent006"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得服务中心
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public lgk.Model.tb_agent1 GetModel(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,AgentCode,Flag,UserID,AgentType,AppliTime,JoinMoney,OpenTime,PicLink,AgentInProvince,AgentInCity,AgentAddress,Agent001,Agent002,Agent003,Agent004,Agent005,Agent006 from tb_agent1 ");
            strSql.Append(" where " + where);
            lgk.Model.tb_agent1 model = new lgk.Model.tb_agent1();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AgentCode"] != null && ds.Tables[0].Rows[0]["AgentCode"].ToString() != "")
                {
                    model.AgentCode = ds.Tables[0].Rows[0]["AgentCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Flag"] != null && ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AgentType"] != null && ds.Tables[0].Rows[0]["AgentType"].ToString() != "")
                {
                    model.AgentType = int.Parse(ds.Tables[0].Rows[0]["AgentType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AppliTime"] != null && ds.Tables[0].Rows[0]["AppliTime"].ToString() != "")
                {
                    model.AppliTime = DateTime.Parse(ds.Tables[0].Rows[0]["AppliTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["JoinMoney"] != null && ds.Tables[0].Rows[0]["JoinMoney"].ToString() != "")
                {
                    model.JoinMoney = decimal.Parse(ds.Tables[0].Rows[0]["JoinMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OpenTime"] != null && ds.Tables[0].Rows[0]["OpenTime"].ToString() != "")
                {
                    model.OpenTime = DateTime.Parse(ds.Tables[0].Rows[0]["OpenTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PicLink"] != null && ds.Tables[0].Rows[0]["PicLink"].ToString() != "")
                {
                    model.PicLink = ds.Tables[0].Rows[0]["PicLink"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AgentInProvince"] != null && ds.Tables[0].Rows[0]["AgentInProvince"].ToString() != "")
                {
                    model.AgentInProvince = ds.Tables[0].Rows[0]["AgentInProvince"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AgentInCity"] != null && ds.Tables[0].Rows[0]["AgentInCity"].ToString() != "")
                {
                    model.AgentInCity = ds.Tables[0].Rows[0]["AgentInCity"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AgentAddress"] != null && ds.Tables[0].Rows[0]["AgentAddress"].ToString() != "")
                {
                    model.AgentAddress = ds.Tables[0].Rows[0]["AgentAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Agent001"] != null && ds.Tables[0].Rows[0]["Agent001"].ToString() != "")
                {
                    model.Agent001 = int.Parse(ds.Tables[0].Rows[0]["Agent001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Agent002"] != null && ds.Tables[0].Rows[0]["Agent002"].ToString() != "")
                {
                    model.Agent002 = int.Parse(ds.Tables[0].Rows[0]["Agent002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Agent003"] != null && ds.Tables[0].Rows[0]["Agent003"].ToString() != "")
                {
                    model.Agent003 = ds.Tables[0].Rows[0]["Agent003"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Agent004"] != null && ds.Tables[0].Rows[0]["Agent004"].ToString() != "")
                {
                    model.Agent004 = ds.Tables[0].Rows[0]["Agent004"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Agent005"] != null && ds.Tables[0].Rows[0]["Agent005"].ToString() != "")
                {
                    model.Agent005 = decimal.Parse(ds.Tables[0].Rows[0]["Agent005"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Agent006"] != null && ds.Tables[0].Rows[0]["Agent006"].ToString() != "")
                {
                    model.Agent006 = decimal.Parse(ds.Tables[0].Rows[0]["Agent006"].ToString());
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
            strSql.Append("select ID,AgentCode,Flag,UserID,AgentType,AppliTime,JoinMoney,OpenTime,PicLink,AgentInProvince,AgentInCity,AgentAddress,Agent001,Agent002,Agent003,Agent004,Agent005,Agent006 ");
            strSql.Append(" FROM tb_agent1 ");
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
            strSql.Append(" ID,AgentCode,Flag,UserID,AgentType,AppliTime,JoinMoney,OpenTime,PicLink,AgentInProvince,AgentInCity,AgentAddress,Agent001,Agent002,Agent003,Agent004,Agent005,Agent006 ");
            strSql.Append(" FROM tb_agent1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "tb_agent1";
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

