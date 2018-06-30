using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class TradingFloorModel
    {
        public string UserCode { set; get; }
        public string OrderID { set; get; }
        public string OrderCode { set; get; }
        public string Total { set; get; }
        public string Balance { set; get; }
        public string Price { set; get; }
    }
}