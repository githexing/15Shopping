using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class MsgRecordModel
    {
        public string UserID { set; get; }
        public string MsgContent { set; get; }
        public string ReContent { set; get; }
        public string ReTime { set; get; }
        public DateTime LeaveTime { set; get; }
    }
}