using System;

namespace lgk.Model
{
    /// <summary>
    /// tb_StockSplitDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_StockSplitDetail
    {
        public tb_StockSplitDetail()
		{}
        #region Model

        /// <summary>
        /// 编号
        /// </summary>		
        private long _splitdetailid;
        public long SplitDetailID
        {
            get { return _splitdetailid; }
            set { _splitdetailid = value; }
        }
        /// <summary>
        /// 股票拆分表ID
        /// </summary>		
        private long _splitid;
        public long SplitID
        {
            get { return _splitid; }
            set { _splitid = value; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>		
        private long _userid;
        public long UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>		
        private string _usercode;
        public string UserCode
        {
            get { return _usercode; }
            set { _usercode = value; }
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
        /// 拆分前持股数
        /// </summary>		
        private decimal _splitstockb;
        public decimal SplitStockB
        {
            get { return _splitstockb; }
            set { _splitstockb = value; }
        }
        /// <summary>
        /// 拆分后持股数
        /// </summary>		
        private decimal _splitstockl;
        public decimal SplitStockL
        {
            get { return _splitstockl; }
            set { _splitstockl = value; }
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

        #endregion
    }
}
