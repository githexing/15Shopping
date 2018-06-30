using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class BuyMachineListModel
    {
        public string Price { set; get; }
        public string Num { set; get; }
        public string Amount { set; get; }
        public string BuyTime { set; get; }
        public string CalcPower { set; get; }
    }

    public class BuyMachineActiveListModel
    {
        public string ID { set; get; }
        public string BuyTime { set; get; }
        public string ActiveTime { set; get; }
        public string IsActive { set; get; }
        public string StateText { set; get; }
    }
}