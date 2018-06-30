using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    public class tb_PhoneOrder
    {
        public int ID { set; get; }
        public string PhoneNO { set; get; }//充值电话号码
        public int CardNum { set; get; }//数量
        public string UorderID { set; get; }//商户自定的订单号
        public string CardID { set; get; }//充值的卡类ID
        public string OrderCash { set; get; }//进货价格
        public string CardName { set; get; }//充值名称
        public string SporderID { set; get; }//聚合订单号
        public int State { set; get; }//充值状态:0充值中 1成功 9撤销，刚提交都返回0
        public DateTime AddDate { set; get; }
        public int UserID { set; get; }
    }
}
