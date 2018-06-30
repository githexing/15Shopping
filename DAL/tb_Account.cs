using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public class tb_Account
    {
        public decimal BanlceAcount( string fildname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select "+ fildname + " from tb_Account ");
            decimal obj =Convert.ToDecimal(DbHelperSQL.GetSingle(strSql.ToString()));
            if (obj == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }
        /// <summary>
        /// 更新账户
        /// </summary>
        /// <param name="fildname">账户字段</param>
        /// <param name="money">值</param>
        /// <param name="type">类型（1-减少 2-增加）</param>
        /// <returns></returns>
        public bool UpdateBanlcen(string fildname,decimal money,int type)
        {
            StringBuilder strSql = new StringBuilder();
            if (type == 1)
            {
                strSql.Append("update tb_Account set " + fildname + "=" + fildname + "-" + money);
            }
            else if (type == 2)
            {
                strSql.Append("update tb_Account set " + fildname + "=" + fildname + "+" + money);
            }
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
    }
}
