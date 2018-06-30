using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService.ViewModel
{
    public class UserViewModel
    {
    }

    public class UserTokenModel
    {
        public long UserID { get; set; }
        public string Token { get; set; }
        public string UserCode { get; set; }
        public string Hx_password { get; set; }
        public int IsCardValid { get; set; }
    }

}