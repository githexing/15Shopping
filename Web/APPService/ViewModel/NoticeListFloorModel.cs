using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class NoticeModel
    {
        public string ID { set; get; }
        public string NewsContent { set; get; }
        public string NewsTitle { set; get; }
        public string PublishTime { set; get; }
        public string Publisher { set; get; }
    }
}