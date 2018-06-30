using System;

namespace lgk.Model
{
    /// <summary>
    /// Cashorder:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cashorder
    {
        public Cashorder()
        { }
        #region Model

        /// <summary>
        /// 编号
        /// </summary>		
        private long _orderid;
        public long OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        /// <summary>
        /// 购买编号
        /// </summary>		
        private long _cashbuyid;
        public long CashbuyID
        {
            get { return _cashbuyid; }
            set { _cashbuyid = value; }
        }
        /// <summary>
        /// 销售编号
        /// </summary>		
        private long _cashsellid;
        public long CashsellID
        {
            get { return _cashsellid; }
            set { _cashsellid = value; }
        }
        /// <summary>
        /// 购买者编号
        /// </summary>		
        private long _buserid;
        public long BUserID
        {
            get { return _buserid; }
            set { _buserid = value; }
        }
        /// <summary>
        /// 出售者编号
        /// </summary>		
        private long _suserid;
        public long SUserID
        {
            get { return _suserid; }
            set { _suserid = value; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>		
        private string _ordercode;
        public string OrderCode
        {
            get { return _ordercode; }
            set { _ordercode = value; }
        }
        /// <summary>
        /// 订单时间
        /// </summary>		
        private DateTime _orderdate;
        public DateTime OrderDate
        {
            get { return _orderdate; }
            set { _orderdate = value; }
        }
        /// <summary>
        /// 购买状态(0未付款，1已付款，2已完成，3已终止)
        /// </summary>		
        private int _bstatus;
        public int BStatus
        {
            get { return _bstatus; }
            set { _bstatus = value; }
        }
        /// <summary>
        /// 付款时间
        /// </summary>		
        private DateTime _paydate;
        public DateTime PayDate
        {
            get { return _paydate; }
            set { _paydate = value; }
        }
        /// <summary>
        /// 购买备注
        /// </summary>		
        private string _bremark;
        public string BRemark
        {
            get { return _bremark; }
            set { _bremark = value; }
        }
        /// <summary>
        /// 销售状态(0未发货，1已发货，2已完成，3已终止)
        /// </summary>		
        private int _sstatus;
        public int SStatus
        {
            get { return _sstatus; }
            set { _sstatus = value; }
        }
        /// <summary>
        /// 发货时间
        /// </summary>		
        private DateTime _senddate;
        public DateTime SendDate
        {
            get { return _senddate; }
            set { _senddate = value; }
        }
        /// <summary>
        /// 销售备注
        /// </summary>		
        private string _sremark;
        public string SRemark
        {
            get { return _sremark; }
            set { _sremark = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>		
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 反馈
        /// </summary>		
        private int _isFeedback;
        public int IsFeedback
        {
            get { return _isFeedback; }
            set { _isFeedback = value; }
        }
        /// <summary>
        /// 反馈信息
        /// </summary>		
        private string _feedback;
        public string Feedback
        {
            get { return _feedback; }
            set { _feedback = value; }
        }
        /// <summary>
        /// 反馈时间 
        /// </summary>		
        private DateTime? _feedbackDate;
        public DateTime? FeedbackDate
        {
            get { return _feedbackDate; }
            set { _feedbackDate = value; }
        }

        /// <summary>
        /// 订单金额 
        /// </summary>	
        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private string _pic;
        public string Pic
        {
            get { return _pic; }
            set { _pic = value; }
        }
        #endregion
    }
}
