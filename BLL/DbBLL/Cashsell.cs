using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class Cashsell
    {
        /// <summary>
        /// 根据给定的条件，获取订单列表
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public DataSet GetOrderList(string strWhere)
        {
            return dal.GetOrderList(strWhere);
        }

    }
}
