using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class CashSellInfoModel
    {
        public string OrderID { set; get; }//卖出订单ID
        public string OrderCode { set; get; }//卖出订单编号
        public string Total { set; get; }//总量
        public string SaleNum { set; get; }//已卖
        public string FrozenNum { set; get; }//被冻结
        public string BanlanceNum { set; get; }//剩余
        public string TotalBond { set; get; }//保证金总量
        public string BalanceBond { set; get; }//剩余保证金
        public string Status { set; get; }//状态
        public string StatusText { set; get; }//状态文本
        public DateTime SellDate { set; get; }
        
    }
}