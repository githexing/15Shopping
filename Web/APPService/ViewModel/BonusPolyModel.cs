using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class BonusPolyModel
    {
        public string Phase { set; get; }
        public string TotalBonus { set; get; }
        public BonusPolyListModel List { set; get; }
    }

    public class BonusPolyListModel
    {
        public string Bonus { set; get; }
        public string ShareDay { set; get; }
        public string ShowDate { set; get; }
        public string ShowTotalHour { set; get; }
        public int Flag { set; get; }
    }

    public class BonusPolyAlreadyListModel
    {
        public string Bonus { set; get; }
        public string Source { set; get; }
        public string ShowDate { set; get; }
    }
}