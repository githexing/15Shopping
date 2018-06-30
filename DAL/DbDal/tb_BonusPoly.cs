using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public partial class tb_BonusPoly
    {
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lgk.Model.tb_BonusPoly GetTask(long UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID, SettleTime, TaskCompletedFlag, TaskCompletedTime, UserID, InvestOrderID, Bonus, ShareDay, ShareDate, ShowDate, Flag  ");
            strSql.Append("  from tb_BonusPoly ");
            strSql.Append(" where UserID=@UserID");
            strSql.Append(" and ShareDate > GETDATE()");
            strSql.Append(" and Flag = 0");
            strSql.Append(" order by ShareDate asc");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt)
            };
            parameters[0].Value = UserID;


            lgk.Model.tb_BonusPoly model = new lgk.Model.tb_BonusPoly();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SettleTime"].ToString() != "")
                {
                    model.SettleTime = DateTime.Parse(ds.Tables[0].Rows[0]["SettleTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TaskCompletedFlag"].ToString() != "")
                {
                    model.TaskCompletedFlag = int.Parse(ds.Tables[0].Rows[0]["TaskCompletedFlag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TaskCompletedTime"].ToString() != "")
                {
                    model.TaskCompletedTime = DateTime.Parse(ds.Tables[0].Rows[0]["TaskCompletedTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InvestOrderID"].ToString() != "")
                {
                    model.InvestOrderID = long.Parse(ds.Tables[0].Rows[0]["InvestOrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Bonus"].ToString() != "")
                {
                    model.Bonus = decimal.Parse(ds.Tables[0].Rows[0]["Bonus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShareDay"].ToString() != "")
                {
                    model.ShareDay = int.Parse(ds.Tables[0].Rows[0]["ShareDay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShareDate"].ToString() != "")
                {
                    model.ShareDate = DateTime.Parse(ds.Tables[0].Rows[0]["ShareDate"].ToString());
                }
                model.ShowDate = ds.Tables[0].Rows[0]["ShowDate"].ToString();
                if (ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

 
    }
}
