using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public partial class tb_BuyMachine
    {
        public DataSet GetListByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount, string FindKey)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageCount", SqlDbType.Int),
                    new SqlParameter("@TotalCount", SqlDbType.Int),
                    new SqlParameter("@FindKey", SqlDbType.VarChar,30)
            };
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;

            parameters[0].Value = UserID;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[5].Value = FindKey;

            string proc = "proc_Page_BuyMachine";
            DataSet ds = DbHelperSQL.RunProcedure(proc, parameters, "journal");

            PageCount = int.Parse(parameters[3].Value.ToString());
            TotalCount = int.Parse(parameters[4].Value.ToString());

            return ds;
        }

        public DataSet GetListActiveByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount, string FindKey)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageCount", SqlDbType.Int),
                    new SqlParameter("@TotalCount", SqlDbType.Int),
                    new SqlParameter("@FindKey", SqlDbType.VarChar,30)
            };
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;

            parameters[0].Value = UserID;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[5].Value = FindKey;

            string proc = "proc_Page_BuyMachineActive";
            DataSet ds = DbHelperSQL.RunProcedure(proc, parameters, "journal");

            PageCount = int.Parse(parameters[3].Value.ToString());
            TotalCount = int.Parse(parameters[4].Value.ToString());

            return ds;
        }

        public void GetInfo(long UserID,out string ActiveNum ,out string NotActiveNum)
        {
            ActiveNum = "0";
            NotActiveNum = "0";

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  @NotActiveNum = sum(surplusnum) , @ActiveNum = sum(ActiveNum)   FROM [tb_BuyMachine]");
            strSql.Append(" where UserID=@UserID ");

            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@ActiveNum", SqlDbType.Int),
                    new SqlParameter("@NotActiveNum", SqlDbType.Int)
                  
            };
            parameters[0].Value = UserID;

            parameters[1].Direction = ParameterDirection.Output;
            parameters[2].Direction = ParameterDirection.Output;

            object obj = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (obj != null)
            {
                ActiveNum = parameters[1].Value.ToString();
                NotActiveNum = parameters[2].Value.ToString();
            }
        }
    }
}
