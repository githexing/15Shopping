using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public partial class tb_PacketSend
    {
        public int PacketSend(long UserID, decimal Amount, int Number, string LeaveMessage,int type)
        {
            int rowsAffected;

            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@Amount", SqlDbType.Decimal),
                    new SqlParameter("@Number", SqlDbType.Int),
                    new SqlParameter("@LeaveMessage", SqlDbType.VarChar,100),
                    new SqlParameter("@Type", SqlDbType.Int)
            };

            parameters[0].Value = UserID;
            parameters[1].Value = Amount;
            parameters[2].Value = Number;
            parameters[3].Value = LeaveMessage;
            parameters[4].Value = type;

            string proc = "proc_PacketSend";
            return DbHelperSQL.RunProcedure(proc, parameters, out rowsAffected);
        }
        public int PacketReceive(long UserID, long PicketID)
        {
            int rowsAffected;

            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@PicketID", SqlDbType.BigInt)
            };

            parameters[0].Value = UserID;
            parameters[1].Value = PicketID;

            string proc = "proc_PacketReceive";
            return DbHelperSQL.RunProcedure(proc, parameters, out rowsAffected);
        }
    }
}
