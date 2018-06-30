using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class RegisterModel
    {
        public string userid { set; get; }
        public string username { set; get; }
        public string invitecode { set; get; }
        public string password { set; get; }
        public string paypassword { set; get; }
        public string phone { set; get; }
        public string sex { set; get; }
        public string idencode { set; get; }
        public string idenname { set; get; }
        public string nickname { set; get; }
        public string smsValid { set; get; }
        public string smscode { set; get; }
    }
}