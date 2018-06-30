using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    public class tb_TrainTicketsOrderDetail
    {
        public int ID { set; get; }
        public int OrderID { set; get; }
        public string PassengerseName { set; get; }
        public int PiaoType { set; get; }
        public string PiaotypeName { set; get; }
        public int Passporttypeseid { set; get; }
        public string PassporttypeseidName { set; get; }
        public string PassportseNO { set; get; }
        public decimal Price { set; get; }
        public string ZWCode { set; get; }
        public string ZWName { set; get; }
        public int InsuranceID { set; get; }
        public string Cxin { set; get; }
        public int State { set; get; }
        public int PassengerId { set; get; }
        public decimal Disacount { set; get; }
    }
}
