using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    public class tb_TicketOrder
    {
        public int ID { set; get; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrdeID { set; get; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { set; get; }
        /// <summary>
        /// 订单时间
        /// </summary>
        public DateTime AddDate { set; get; }
        /// <summary>
        /// 订单状态(0-待确认 1-等待支付 2-等待出票 3-出票完成 10-订单关闭 16-暂不能出票 19-已拒单 31-退款中 32-退款失败 33-退款成功)
        /// </summary>
        public int Status { set; get; }
        /// <summary>
        /// 支付价格
        /// </summary>
        public decimal PayPrice { set; get; }
        /// <summary>
        /// 税费合计
        /// </summary>
        public decimal Totaltax { set; get; }
        /// <summary>
        /// 票价合计
        /// </summary>
        public decimal TicketPrice { set; get; }
        /// <summary>
        /// 返点
        /// </summary>
        public string PolicyNum { set; get; }
        /// <summary>
        /// 邮寄费用
        /// </summary>
        public decimal PostPrice { set; get; }
        /// <summary>
        /// 保费合计
        /// </summary>
        public decimal InsurancePrice { set; get; }
        /// <summary>
        /// 优惠抵扣金额
        /// </summary>
        public decimal CouponPrice { set; get; }
        /// <summary>
        /// 收件人
        /// </summary>
        public string LinkMan { set;get;}
        /// <summary>
        /// 收件人手机号
        /// </summary>
        public string LinkMobile { set;get;}
        /// <summary>
        /// 收件人详细地址
        /// </summary>
        public string Address { set;get;}
        /// <summary>
        /// 是否需要行程单
        /// </summary>
        public string Needsheet { set;get;}
        /// <summary>
        /// 航司代码
        /// </summary>
        public string Aircode { set;get;}
        /// <summary>
        /// 出发机场三字码
        /// </summary>
        public string DepCity { set;get;}
        /// <summary>
        /// 到达机场三字码
        /// </summary>
        public string ArrCity { set;get;}
        /// <summary>
        /// 航班号
        /// </summary>
        public string Flight { set;get;}
        /// <summary>
        /// 机型
        /// </summary>
        public string FlightModel { set;get;}
        /// <summary>
        /// 舱位代码
        /// </summary>
        public string Cabin { set; get; }
        /// <summary>
        /// 起飞日期"(格式yyyy-MM-dd)
        /// </summary>
        public DateTime DepDate { set;get;}
        /// <summary>
        /// 起飞时间"(格式 HH:mm)
        /// </summary>
        public DateTime DepTime { set; get; }
        /// <summary>
        /// 到达时间(格式 HH:mm)
        /// </summary>
        public DateTime ArrTime { set; get; }
        /// <summary>
        /// "Y 舱价格
        /// </summary>
        public decimal YPrice { set; get; }
        /// <summary>
        /// 舱位折扣
        /// </summary>
        public decimal Discount { set; get; }
        /// <summary>
        /// 起飞航站楼
        /// </summary>
        public string Depterminal { set; get; }
        /// <summary>
        /// 到达航站楼
        /// </summary>
        public string Arrterminal { set; get; }
        /// <summary>
        /// 机建费
        /// </summary>
        public decimal Airportfee { set; get; }
        /// <summary>
        /// 燃油费
        /// </summary>
        public decimal Fuelfee { set; get; }
        /// <summary>
        /// 返点费
        /// </summary>
        public decimal Staynum { set; get; }

        /// <summary>
        /// 航班名称
        /// </summary>
        public string AirName { set; get; }
        /// <summary>
        /// 起飞机场名称
        /// </summary>
        public string DepcityName { set; get; }
        /// <summary>
        /// 达到机场名称
        /// </summary>
        public string ArrcityName { set; get; }
        /// <summary>
        /// 支付状态(0-未支付 1-支付成功 2-支付失败)
        /// </summary>
        public int PayStatus { set; get; }
    }
}
