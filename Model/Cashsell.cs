using System;

namespace lgk.Model
{
    /// <summary>
    /// Cashsell:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cashsell
    {
        public Cashsell()
        { }
        #region Model

        /// <summary>
        /// 编号
        /// </summary>		
        private long _cashsellid;
        public long CashsellID
        {
            get { return _cashsellid; }
            set { _cashsellid = value; }
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
        /// 销售数量
        /// </summary>		
        private int _number;
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        /// <summary>
        /// 发布件数
        /// </summary>		
        private decimal _unitnum;
        public decimal UnitNum
        {
            get { return _unitnum; }
            set { _unitnum = value; }
        }
        /// <summary>
        /// 已卖件数
        /// </summary>		
        private decimal _salenum;
        public decimal SaleNum
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
        private DateTime _selldate;
        public DateTime SellDate
        {
            get { return _selldate; }
            set { _selldate = value; }
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
        /// 销售状态（0未销售，1未发货，2已发货，3已完成）
        /// </summary>		
        private int _issell;
        public int IsSell
        {
            get { return _issell; }
            set { _issell = value; }
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
        /// <summary>
        /// --求购编号
        /// 收款账户ID
        /// </summary>		
        private long _purchaseid;
        public long PurchaseID
        {
            get { return _purchaseid; }
            set { _purchaseid = value; }
        }
        /// <summary>
        /// 手机号
        /// </summary>		
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        #endregion
    }
}
