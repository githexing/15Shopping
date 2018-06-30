using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    public class tb_TrainTicketsOrder
    {
        public int ID { set; get; }
        public string OrderCode { set; get; }
        public string ISAcceptStanding { set; get; }
        public string FromStationCode { set; get; }
        public string ToStationCode { set; get; }
        public string CheCi { set; get; }
        public DateTime TrainDate { set; get; }
        public int UserID { set; get; }
        public string OrderID { set; get; }
        public int State { set; get; }
        public string FromStationName { set; get; }
        public string ToStationName { set; get; }
        public string FromStationDate { set; get; }
        public string ToStationDate { set; get; }
        public decimal OrderPrice { set; get; }
        public string LinkMan { set; get; }
        public string LinkPhone { set; get; }
    }
}
