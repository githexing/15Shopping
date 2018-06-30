using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class AccountListModel
    {
        public string ID { set; get; }
        public string Amount { set; get; }
        public string Remark { set; get; }
        //public string ShortRemark { set; get; }
        public DateTime RecordDate { set; get; }
    }
}