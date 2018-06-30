using System;

namespace lgk.Model
{
    /// <summary>
    /// tb_StockSplit:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_StockSplit
    {
        public tb_StockSplit()
		{}
        #region Model

        /// <summary>
        /// 编号
        /// </summary>		
        private long _splitid;
        public long SplitID
        {
            get { return _splitid; }
            set { _splitid = value; }
        }
        /// <summary>
        /// 股票拆分价格(系统拆分价格)
        /// </summary>		
        private decimal _splitprice;
        public decimal SplitPrice
        {
            get { return _splitprice; }
            set { _splitprice = value; }
        }
        /// <summary>
        /// 拆分前股价
        /// </summary>		
        private decimal _splitpriceb;
        public decimal SplitPriceB
        {
            get { return _splitpriceb; }
            set { _splitpriceb = value; }
        }
        /// <summary>
        /// 拆分后股价
        /// </summary>		
        private decimal _splitpricel;
        public decimal SplitPriceL
        {
            get { return _splitpricel; }
            set { _splitpricel = value; }
        }
        /// <summary>
        /// 拆分比例
        /// </summary>		
        private string _splitrate;
        public string SplitRate
        {
            get { return _splitrate; }
            set { _splitrate = value; }
        }
        /// <summary>
        /// 拆分次数
        /// </summary>		
        private int _splittimes;
        public int SplitTimes
        {
            get { return _splittimes; }
            set { _splittimes = value; }
        }
        /// <summary>
        /// 拆分时间
        /// </summary>		
        private DateTime _splitdate;
        public DateTime SplitDate
        {
            get { return _splitdate; }
            set { _splitdate = value; }
        }

        #endregion Model
    }
}
