using System;

namespace lgk.Model
{
    /// <summary>
    /// tb_StockDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_StockDetail
    {
        public tb_StockDetail()
		{}
        #region Model

        /// <summary>
        /// 编号
        /// </summary>		
        private long _stockdetailid;
        public long StockDetailID
        {
            get { return _stockdetailid; }
            set { _stockdetailid = value; }
        }
        /// <summary>
        /// 股票ID
        /// </summary>		
        private long _stockid;
        public long StockID
        {
            get { return _stockid; }
            set { _stockid = value; }
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
        /// 当前持股数
        /// </summary>		
        private int _number;
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        /// <summary>
        /// 发行期数
        /// </summary>		
        private int _periods;
        public int Periods
        {
            get { return _periods; }
            set { _periods = value; }
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

        #endregion
    }
}
