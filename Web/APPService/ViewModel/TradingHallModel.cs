using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    #region 交易大厅
    public class TradingHallModel
    {
        public List<NowHallData> BuyList { get; set; }
        public List<NowHallData> SellList { get; set; }
        public decimal LatestPrice { get; set; }
        public decimal YT { get; set; }
        public decimal YD { get; set; }
    }

    public class NowHallData
    {
        public string UserCode { get; set; }//编号
        public string Price { get; set; }//价格
        public string SurplusNum { get; set; }//剩余数量
    }
    #endregion

    #region 买入/卖出
    public class TradingBuyAndSellListModel
    {
        public List<TradingBuyAndSellModel> list { set; get; }
        public int pageindex { set; get; }  //页码
        public int pagecount { set; get; } //总页数
        public int totalcount { set; get; } //总条数
    }

    public class TradingBuyAndSellModel
    {
        public long OrderID { set; get; }//订单ID
        public string OrderCode { set; get; }//订单编号
        public decimal Price { set; get; }//价格
        public int Number { set; get; }//总量
        public decimal Amount { set; get; }//总额
        public int SurplusNum { set; get; }//剩余
        public int TypeID { set; get; }//状态（1：买入；2：卖出）
        public int Status { set; get; }//状态（-1：已撤销；0：交易中；1：已完成）
        public string StatusText { set; get; }//状态文本
        public string OrderDate { set; get; }
    } 
    #endregion


}