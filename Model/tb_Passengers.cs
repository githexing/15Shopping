using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
   public class tb_Passengers
    {
        public int ID { set; get; }
        /// <summary>
        /// 订单编号ID
        /// </summary>
        public int OrderID { set; get; }
        /// <summary>
        /// 乘机人姓名
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string Cardno { set; get; }
        /// <summary>
        /// 证件类型(NI 身份证,PP护照,ID 其它),
        /// </summary>
        public string Cardtype { set; get; }
        /// <summary>
        /// 乘客类型”(ADT 成人,CHD儿童,INF 婴儿)
        /// </summary>
        public string Mantype { set; get; }
        /// <summary>
        /// 出生年月
        /// </summary>
        public string Birthday { set; get; }
        /// <summary>
        /// 性别(F 女,M 男)
        /// </summary>
        public string Sex { set; get; }
        /// <summary>
        /// 保险价格
        /// </summary>
        public decimal InsurancePrice { set; get; }
        /// <summary>
        /// 保险份数
        /// </summary>
        public int InsuranceNum { set; get; }
       
    }
}
