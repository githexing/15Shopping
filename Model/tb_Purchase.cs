using System;

namespace lgk.Model
{
    /// <summary>
    /// Purchase:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_Purchase
    {
        public tb_Purchase()
        { }
        #region Model

        /// <summary>
        /// 编号
        /// </summary>		
        private long _purchaseid;
        public long PurchaseID
        {
            get { return _purchaseid; }
            set { _purchaseid = value; }
        }
        /// <summary>
        /// 销售标题
        /// </summary>		
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
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
        /// 销售金额
        /// </summary>		
        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        /// <summary>
        /// 销售价格
        /// </summary>		
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        /// <summary>
        /// 求购数量
        /// </summary>		
        private int _number;
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        /// <summary>
        /// 已购数量
        /// </summary>		
        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        /// <summary>
        /// 发布件数
        /// </summary>		
        private int _unitnum;
        public int UnitNum
        {
            get { return _unitnum; }
            set { _unitnum = value; }
        }
        /// <summary>
        /// 已购件数
        /// </summary>		
        private int _salenum;
        public int SaleNum
        {
            get { return _salenum; }
            set { _salenum = value; }
        }
        /// <summary>
        /// 每件所需手续费
        /// </summary>		
        private decimal _charge;
        public decimal Charge
        {
            get { return _charge; }
            set { _charge = value; }
        }
        /// <summary>
        /// 提交时间
        /// </summary>		
        private DateTime _purchasedate;
        public DateTime PurchaseDate
        {
            get { return _purchasedate; }
            set { _purchasedate = value; }
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
        /// 求购状态（0申请，1已打钱，2已完成）
        /// </summary>		
        private int _ispur;
        public int IsPur
        {
            get { return _ispur; }
            set { _ispur = value; }
        }
        /// <summary>
        /// 是否撤销销售（0否，1是）
        /// </summary>		
        private int _isundo;
        public int IsUndo
        {
            get { return _isundo; }
            set { _isundo = value; }
        }
        #endregion
    }
}
