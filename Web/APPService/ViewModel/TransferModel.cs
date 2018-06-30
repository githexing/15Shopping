using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class TransferModel
    {
        public string UserCode { set; get; }
        public string TrueName { set; get; }
        public string ChangeType { set; get; }
        public string Amount { set; get; }
        public DateTime ChangeDate { set; get; }
        public string OrderCode { set; get; }
        public string Currency { set; get; }
    }
}