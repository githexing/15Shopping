using System;
namespace lgk.Model
{
    /// <summary>
    /// tb_OrderDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_OrderDetail
    {
        public tb_OrderDetail()
        { }
        #region Model
        private long _id;
        private string _ordercode = "";
        private long _procudeid = 0;
        private string _procudename;
        private decimal _price = 0M;
        private int _pv = 0;
        private int _ordersum = 0;
        private decimal _ordertotal = 0M;
        private int _pvtotal = 0;
        private DateTime _orderdate;
        private string _gcolor;
        private string _gsize;
        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
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
        public long ProcudeID
        {
            set { _procudeid = value; }
            get { return _procudeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProcudeName
        {
            set { _procudename = value; }
            get { return _procudename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PV
        {
            set { _pv = value; }
            get { return _pv; }
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
        public int PVTotal
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
        public string gColor
        {
            set { _gcolor = value; }
            get { return _gcolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gSize
        {
            set { _gsize = value; }
            get { return _gsize; }
        }
        #endregion Model

    }
}

