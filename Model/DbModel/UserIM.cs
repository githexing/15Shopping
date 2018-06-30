using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    public class UserIM
    {
        public long UserID { set; get; }
        public string UserCode { set; get; }
        public string RecommendCode { set; get; }
        public string Password { set; get; }
        public string Name { set; get; }
        public int SyncIMState { set; get; }
    }
}
