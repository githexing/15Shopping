using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService.ViewModel
{
    public class TakeMoneyModel
    {
        public string TakeID { set; get; }
        public string TakeMoney { set; get; }
        public string TakePoundage { set; get; }
        public string RealityMoney { set; get; }
        public DateTime TakeTime { set; get; }
        public string Flag { set; get; }
        public string AccountType { set; get; }
    }
}