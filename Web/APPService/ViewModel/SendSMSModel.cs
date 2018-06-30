using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class SendSMSModel
    {
        public string phone { set; get; }
        public string usercode { set; get; }
        public string userid { set; get; }
        public string type { set; get; }
    }
}