using System;

namespace lgk.Model
{
    /// <summary>
    /// StockBonus:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StockBonus
    {
        public StockBonus()
		{ }

        #region Model
        /// <summary>
        /// 编号
        /// </summary>		
        private int _bonusid;
        public int BonusID
        {
            get { return _bonusid; }
            set { _bonusid = value; }
        }
        /// <summary>
        /// A盘编号
        /// </summary>		
        private int _stockid;
        public int StockID
        {
            get { return _stockid; }
            set { _stockid = value; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>		
        private int _userid;
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 类型
        /// </summary>		
        private int _typeid;
        public int TypeID
        {
            get { return _typeid; }
            set { _typeid = value; }
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
        /// 奖金数额
        /// </summary>		
        private decimal _bonus;
        public decimal Bonus
        {
            get { return _bonus; }
            set { _bonus = value; }
        }
        /// <summary>
        /// 购买价格
        /// </summary>		
        private decimal _buyprice;
        public decimal BuyPrice
        {
            get { return _buyprice; }
            set { _buyprice = value; }
        }
        /// <summary>
        /// 当前股价
        /// </summary>		
        private decimal _currentprice;
        public decimal CurrentPrice
        {
            get { return _currentprice; }
            set { _currentprice = value; }
        }
        /// <summary>
        /// 时间
        /// </summary>		
        private DateTime _adddate;
        public DateTime AddDate
        {
            get { return _adddate; }
            set { _adddate = value; }
        }
        /// <summary>
        /// 是否结算（0未结算，1已结算）
        /// </summary>		
        private int _issettled;
        public int IsSettled
        {
            get { return _issettled; }
            set { _issettled = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// 备用字段1
        /// </summary>		
        private int _bonus001;
        public int Bonus001
        {
            get { return _bonus001; }
            set { _bonus001 = value; }
        }
        /// <summary>
        /// 备用字段2
        /// </summary>		
        private decimal _bonus002;
        public decimal Bonus002
        {
            get { return _bonus002; }
            set { _bonus002 = value; }
        }
        /// <summary>
        /// 备用字段3
        /// </summary>		
        private string _bonus003;
        public string Bonus003
        {
            get { return _bonus003; }
            set { _bonus003 = value; }
        }
        #endregion Model
    }
}
