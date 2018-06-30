using DataAccess;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace lgk.DAL
{
    public partial class tb_PacketReceive
    {
        public DataSet GetReceiveList(long UserID,long PackID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select r.Amount,r.ReceiveTime,u.UserCode as ReceiveUserCode,u.NiceName as ReceiveNiceName,u.user009 as headpic from tb_PacketReceive r   ");
            strSql.Append(" left join tb_user u on u.UserID = r.ReceiveUserID ");
            strSql.Append(" where r.ReceiveFlag = 1 ");
            //strSql.Append(" and r.ReceiveUserID = @ReceiveUserID ");
            strSql.Append(" and r.PackID = @PackID");
            SqlParameter[] parameters = {
                    //new SqlParameter("@ReceiveUserID", SqlDbType.BigInt),
                    new SqlParameter("@PackID", SqlDbType.BigInt)
            };
           // parameters[0].Value = UserID;
            parameters[0].Value = PackID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }
    }
}
