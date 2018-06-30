using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public partial class tb_journal
    {
        public DataSet GetListByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount,string FindKey,int _type)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageCount", SqlDbType.Int),
                    new SqlParameter("@TotalCount", SqlDbType.Int),
                    new SqlParameter("@FindKey", SqlDbType.VarChar,30),
                    new SqlParameter("@Type", SqlDbType.Int)
            };
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;

            parameters[0].Value = UserID;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[5].Value = FindKey;
            parameters[6].Value = _type;

            string proc = "proc_Page_Journal";
            DataSet ds = DbHelperSQL.RunProcedure(proc, parameters, "journal");

            PageCount = int.Parse(parameters[3].Value.ToString());
            TotalCount = int.Parse(parameters[4].Value.ToString());

            return ds;
        }
        public DataSet GetListYTByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount, string FindKey, int _type)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageCount", SqlDbType.Int),
                    new SqlParameter("@TotalCount", SqlDbType.Int),
                    new SqlParameter("@FindKey", SqlDbType.VarChar,30),
                    new SqlParameter("@Type", SqlDbType.Int)
            };
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;

            parameters[0].Value = UserID;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[5].Value = FindKey;
            parameters[6].Value = _type;

            string proc = "proc_Page_JournalYT";
            DataSet ds = DbHelperSQL.RunProcedure(proc, parameters, "journal");

            PageCount = int.Parse(parameters[3].Value.ToString());
            TotalCount = int.Parse(parameters[4].Value.ToString());

            return ds;
        }


    }
}
