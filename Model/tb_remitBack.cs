using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    public class tb_remitBack
    {
        public int ID { set; get; }
        public int MemberID { set; get; }
        public string OrderCode { set; get; }
        public string Sign { set; get; }
        public decimal Amount { set; get; }
        public string ReturnCode { set; get; }
        public DateTime AddTime { set; get; }
    }
}
