using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService.ViewModel
{
    public class CashBuyInfoListModel
    {
        public List<CashBuyInfoModel> list { set; get; }
        public int pageindex { set; get; }  //页码
        public int pagecount { set; get; } //总页数
        public int totalcount { set; get; } //总条数
    }
    public class CashBuyInfoModel
    {
        public long OrderID { set; get; }//买入订单ID
        public string OrderCode { set; get; }//买入订单编号
        public string UserCode { set; get; }//买入用户编号
        public decimal Price { set; get; }//价格
        public int Number { set; get; }//总量
        public decimal Amount { set; get; }//价格
        public int BuyNum { set; get; }//已买得
        public int SurplusNum { set; get; }//剩余需要买入
        public int Status { set; get; }//状态
        public string StatusText { set; get; }//状态文本
        public string BuyDate { set; get; }
    }
}