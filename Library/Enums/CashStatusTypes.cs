using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Enums
{
    /// <summary>
    /// 购买状态 0未付款，1已付款，2已完成，3已终止
    /// </summary>
    public enum CashStatusTypes
    {
        未付款 = 0,
        已付款 = 1,
        已完成 = 2,
        已终止 = 3
    };

    /// <summary>
    /// 挂卖订单状态  -1:已取消 ,0:挂单中,1:交易中,2:已完成
    /// </summary>
    public enum CashSellStatusTypes
    {
        已取消 = -1,
        挂单中 = 0,
        交易中 = 1,
        已完成 = 2
    };
}
