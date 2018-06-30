using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public partial class Cashsell
    {
        /// <summary>
        /// 根据给定的条件，获取订单列表
        /// Status
        // -1:已取消
        //0:挂单中
        //1:交易中
        //2:已完成
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public DataSet GetOrderList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CashsellID as OrderID,Title as OrderCode,Number as Total,SaleNum,0 as FrozenNum, Number - SaleNum as SurplusNum, Charge as TotalBond, ROUND(Charge - SaleNum * UnitNum / 100, 2) as BalanceBond ,");
            strSql.Append(" case when IsUndo = 1 then -1 when SaleNum = 0 then 0 when Number > SaleNum then 1 ");
            strSql.Append(" when Number = SaleNum then 2 end as [Status],SellDate  ");
            strSql.Append("  from Cashsell");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
