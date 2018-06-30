using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    public class tb_TicketBack
    {
        public int ID { set; get; }//通知类型
        public string Type { set; get; }//通知类型
        public string OrderNo { set; get; }//订单号
        public string OrderStatus { set; get; }//订单状态
        public string Reason { set; get; }//说明
        public string TicketNos { set; get; }//票号参数
        public string PoundageFee { set; get; }//退票退钱手续费
        public string FefundMoney { set; get; }//退票退钱金额
        public string Sign { set; get; }
    }
}
