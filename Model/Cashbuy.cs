using System;

namespace lgk.Model
{
    /// <summary>
    /// Cashbuy:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
    public partial class Cashbuy
    {
        public Cashbuy()
        { }
        #region Model

        /// <summary>
        /// 编号
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
        /// 会员编号
        /// </summary>
        private long _userid;
        public long UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 购买金额
        /// </summary>
        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        /// <summary>
        /// 购进价格
        /// </summary>
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        /// <summary>
        /// 购进数量
        /// </summary>
        private int _number;
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        /// <summary>
        /// 购进件数
        /// </summary>		
        private decimal _buynum;
        public decimal BuyNum
        {
            get { return _buynum; }
            set { _buynum = value; }
        }
        /// <summary>
        /// 购买时间
        /// </summary>
        private DateTime _buydate;
        public DateTime BuyDate
        {
            get { return _buydate; }
            set { _buydate = value; }
        }
        /// <summary>
        /// 是否已购买完成（0下单，1发货中，2完成）
        /// </summary>
        private int _isbuy;
        public int IsBuy
        {
            get { return _isbuy; }
            set { _isbuy = value; }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        #endregion
    }
}
