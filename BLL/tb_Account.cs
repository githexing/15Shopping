using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
   public  class tb_Account
    {
        lgk.DAL.tb_Account dal = new DAL.tb_Account();
        public decimal BanlceAcount(string fildname)
        {
            return dal.BanlceAcount(fildname);
        }
        /// <summary>
        /// 更新账户
        /// </summary>
        /// <param name="fildname">账户字段</param>
        /// <param name="money">值</param>
        /// <param name="type">类型（1-减少 2-增加）</param>
        /// <returns></returns>
        public bool UpdateBanlcen(string fildname, decimal money,int type)
        {
            return dal.UpdateBanlcen(fildname, money, type);
        }
    }
}
