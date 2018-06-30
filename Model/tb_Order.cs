using System;
namespace lgk.Model
{
    /// <summary>
    /// tb_Order:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_Order
    {
        public tb_Order()
        { }
        #region Model
        private long _orderid;
        private long _userid = 0;
        private string _ordercode;
        private string _useraddr;
        private int _ordersum = 0;
        private decimal _ordertotal = 0M;
        private decimal _pvtotal = 0M;
        private DateTime _orderdate;
        private int _issend = 0;
        private int _paymethod = 0;
        private int _ordertype = 0;
        private decimal _order1 = 0M;
        private decimal _order2 = 0M;
        private string _order3;
        private string _order4;
        private string _order5;
        private string _order6;
        private string _order7;
        private int _typeid = 0;
        private string _paretopchild;
        private int _baodanorder = 0;
        private int _isdel = 0;
        private DateTime? _senddate;
        /// <summary>
        /// 
        /// </summary>
        public long OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderCode
        {
            set { _ordercode = value; }
            get { return _ordercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserAddr
        {
            set { _useraddr = value; }
            get { return _useraddr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderSum
        {
            set { _ordersum = value; }
            get { return _ordersum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OrderTotal
        {
            set { _ordertotal = value; }
            get { return _ordertotal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal PVTotal
        {
            set { _pvtotal = value; }
            get { return _pvtotal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsSend
        {
            set { _issend = value; }
            get { return _issend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PayMethod
        {
            set { _paymethod = value; }
            get { return _paymethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Order1
        {
            set { _order1 = value; }
            get { return _order1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Order2
        {
            set { _order2 = value; }
            get { return _order2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Order3
        {
            set { _order3 = value; }
            get { return _order3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Order4
        {
            set { _order4 = value; }
            get { return _order4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Order5
        {
            set { _order5 = value; }
            get { return _order5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Order6
        {
            set { _order6 = value; }
            get { return _order6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Order7
        {
            set { _order7 = value; }
            get { return _order7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PareTopChild
        {
            set { _paretopchild = value; }
            get { return _paretopchild; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BaodanOrder
        {
            set { _baodanorder = value; }
            get { return _baodanorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SendDate
        {
            set { _senddate = value; }
            get { return _senddate; }
        }
        #endregion Model

    }
}

