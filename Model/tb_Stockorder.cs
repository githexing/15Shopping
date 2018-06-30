using System;

namespace lgk.Model
{
    /// <summary>
    /// tb_Stockorder:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_Stockorder
    {
        public tb_Stockorder()
		{}
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
        /// 股票编号
        /// </summary>		
        private long _stockid;
        public long StockID
        {
            get { return _stockid; }
            set { _stockid = value; }
        }
        /// <summary>
        /// 出售者编号
        /// </summary>		
        private long _userid;
        public long UserID
        {
            get { return _userid; }
            set { _userid = value; }
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
        /// 销售备注
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// 状态(0已挂单，1卖出中，2已卖出)
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
