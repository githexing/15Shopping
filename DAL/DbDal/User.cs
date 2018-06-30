using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public partial class tb_user
    {
        /// <summary>
        /// 根据给定手机号码，获取用户ID
        /// </summary>
        /// <param name="strUserCode"></param>
        /// <returns></returns>
        public long GetUserIDByInviteCode(string inviteCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserID] FROM tb_user");
            strSql.Append(" WHERE user008=@inviteCode");
            SqlParameter[] parameters = {
                    new SqlParameter("@inviteCode", SqlDbType.VarChar,50)};
            parameters[0].Value = inviteCode;
            
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return long.Parse(obj.ToString());
            }
        }
    }

}
