using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class CashOrderModel
    {
        public string TransOrderID { set; get; }
        public string SellUserCode { set; get; }
        public string SellOrderID { set; get; }
        public string SellOrderCode { set; get; }
        public string BuyOrderID { set; get; }
        public string BuyOrderCode { set; get; }
        public string Number { set; get; }
        public string Price { set; get; }
        public string Status { set; get; }
        public string SellerPhone { set; get; }
        public DateTime? OrderDate { set; get; }
        public DateTime? ExpireDate { set; get; }  //过期时间
        public long BankID { set; get; }
        public string BuyUserCode { set; get; }
        public string BuyerPhone { set; get; }
        public string BuyNiceName { set; get; }
        public string StatusText { set; get; }
        public string BuyerRemark { set; get; }
        public string SellerRemark { set; get; }
        public string Pic { set; get; }
    }
}