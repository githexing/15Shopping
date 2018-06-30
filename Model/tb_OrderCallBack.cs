using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    public class tb_OrderCallBack
    {
        public int ID { set; get; }
        public string OrderID { set; get; }
        public string CheCi { set; get; }
        public string FromStationName { set; get; }
        public string FromStationCode { set; get; }
        public string ToStationName { set; get; }
        public string ToStationCode { set; get; }
        public DateTime TrainDate { set; get; }
        public string UserOrderid { set; get; }
        public decimal Orderamount { set; get; }
        public string Ordernumber { set; get; }
        public int Status { set; get; }
        public string Msg { set; get; }
        public string RefundMoney { set; get; }
        public string Passengers { set; get; }
    }
}
