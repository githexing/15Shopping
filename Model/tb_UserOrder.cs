using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    [Serializable]
    public partial class tb_UserOrder
    {
        public tb_UserOrder()
		{}

        #region Model
        /// <summary>
        /// ID
        /// </summary>		
        private long _id;
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// UserID
        /// </summary>		
        private long _userid;
        public long UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// OrderCode
        /// </summary>		
        private string _ordercode;
        public string OrderCode
        {
            get { return _ordercode; }
            set { _ordercode = value; }
        }
        /// <summary>
        /// IntegralAmount
        /// </summary>		
        private decimal _integralamount;
        public decimal IntegralAmount
        {
            get { return _integralamount; }
            set { _integralamount = value; }
        }
        /// <summary>
        /// PurchaseAmount
        /// </summary>		
        private decimal _purchaseamount;
        public decimal PurchaseAmount
        {
            get { return _purchaseamount; }
            set { _purchaseamount = value; }
        }
        /// <summary>
        /// SellAmount
        /// </summary>		
        private decimal _sellamount;
        public decimal SellAmount
        {
            get { return _sellamount; }
            set { _sellamount = value; }
        }
        /// <summary>
        /// BuyTime
        /// </summary>		
        private DateTime _buytime;
        public DateTime BuyTime
        {
            get { return _buytime; }
            set { _buytime = value; }
        }
        /// <summary>
        /// order001
        /// </summary>		
        private int _order001;
        public int order001
        {
            get { return _order001; }
            set { _order001 = value; }
        }
        /// <summary>
        /// order002
        /// </summary>		
        private decimal _order002;
        public decimal order002
        {
            get { return _order002; }
            set { _order002 = value; }
        }
        /// <summary>
        /// 订单状态（0：未支付；1：未发货；2：已发货；3：已收货）
        /// </summary>		
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 退款/退货 （成功失败标识，0：无；1：申请；2：成功；3失败）
        /// </summary>		
        private int _flag;
        public int Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        /// <summary>
        /// 发货时间
        /// </summary>		
        private DateTime? _sendtime;
        public DateTime? SendTime
        {
            get { return _sendtime; }
            set { _sendtime = value; }
        }
        /// <summary>
        /// 收货时间
        /// </summary>		
        private DateTime? _receivetime;
        public DateTime? ReceiveTime
        {
            get { return _receivetime; }
            set { _receivetime = value; }
        }
        /// <summary>
        /// 退款申请时间
        /// </summary>		
        private DateTime? _applytime;
        public DateTime? ApplyTime
        {
            get { return _applytime; }
            set { _applytime = value; }
        }
        /// <summary>
        /// 退款完成时间
        /// </summary>		
        private DateTime? _finishtime;
        public DateTime? FinishTime
        {
            get { return _finishtime; }
            set { _finishtime = value; }
        }
        /// <summary>
        /// 是否已结算
        /// </summary>		
        private int _issettle;
        public int IsSettle
        {
            get { return _issettle; }
            set { _issettle = value; }
        }
        /// <summary>
        /// 结算时间
        /// </summary>		
        private DateTime? _settletime;
        public DateTime? SettleTime
        {
            get { return _settletime; }
            set { _settletime = value; }
        }

        private string _receivieAddress;
        public string ReceivieAddress
        {
            get { return _receivieAddress; }
            set { _receivieAddress = value; }
        }

        private string _province;
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        } 
        #endregion
    }
}
