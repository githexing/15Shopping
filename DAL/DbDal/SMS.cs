using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public partial class SMS
    {
        /// <summary>
        /// 获取当天发短信数量
        /// </summary>
        public long GetSendCountOfDay(string phone)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Count(1) ct FROM SMS");
            strSql.Append(" where (ToPhone=@phone)");
            strSql.Append(" and datediff(day,PublishTime,getdate()) = 0");
            SqlParameter[] parameters = {
                    new SqlParameter("@phone", SqlDbType.VarChar,20)
            };
            parameters[0].Value = phone;

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

        /// <summary>
        /// 获取设定的分钟数内发短信数量
        /// </summary>
        public long GetSendCountOfMinute(string phone,int minute)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Count(1) ct FROM SMS");
            strSql.Append(" where (ToPhone=@phone)");
            strSql.Append(" and datediff(day,PublishTime,getdate()) = 0");
            strSql.Append(" and datediff(minute,PublishTime,getdate()) <= @minute");

            SqlParameter[] parameters = {
                    new SqlParameter("@phone", SqlDbType.VarChar,20),
                    new SqlParameter("@minute", SqlDbType.Int)
            };
            parameters[0].Value = phone;
            parameters[1].Value = minute;

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
