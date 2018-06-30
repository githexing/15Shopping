using System;

namespace lgk.Model
{
    /// <summary>
    /// tb_StockBuy:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_StockBuy
    {
        public tb_StockBuy()
        { }

        #region Model

        /// <summary>
        /// 编号
        /// </summary>		
        private long _stockbuyid;
        public long StockBuyID
        {
            get { return _stockbuyid; }
            set { _stockbuyid = value; }
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
        /// 总购买金额
        /// </summary>		
        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        /// <summary>
        /// 未购买金额
        /// </summary>		
        private decimal _surplussum;
        public decimal SurplusSum
        {
            get { return _surplussum; }
            set { _surplussum = value; }
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
        /// 购买状态(0等待买入，1购买中,2购买完毕)
        /// </summary>		
        private int _isbuy;
        public int IsBuy
        {
            get { return _isbuy; }
            set { _isbuy = value; }
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
        #endregion
    }
}
