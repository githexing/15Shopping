using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class RemitModel
    {
        public string RemitID { set; get; }
        public string AddDate { set; get; }
        public string RemitMoney { set; get; }
        public string PayMoney { set; get; }
        public string State { set; get; }
    }
    public class RemitInfoModel
    {
        public string ID { set; get; }
        public string Remit001 { set; get; }
        public string Remit002 { set; get; }
        public string RemitMoney { set; get; }
    }
}