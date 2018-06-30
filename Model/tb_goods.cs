using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_goods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_goods
	{
		public tb_goods()
		{}
        #region Model
        private long _id;
        private string _goodscode = "";
        private string _goodsname = "";
        private decimal _price = 0M;
        private decimal _realityprice = 0M;
        private string _standard = "";
        private int _ishave = 0;
        private int _typeid = 0;
        private int _goodstype = 0;
        private string _pic1 = "";
        private string _pic2 = "";
        private string _pic3 = "";
        private string _pic4 = "";
        private string _pic5 = "";
        private string _summary = "";
        private string _remarks = "";
        private DateTime _addtime;
        private int _goods001 = 0;
        private int _goods002 = 0;
        private string _goods003 = "";
        private string _goods004 = "";
        private decimal _goods005 = 0M;
        private decimal _goods006 = 0M;
        private DateTime? _goods007;
        private DateTime? _goods008;
        private string _goodsname_en = "";
        private string _remarks_en = "";
        private int _statetype = 0;
        private string _city = "";
        private decimal _shopprice = 0M;
        private int _inventory = 0;
        private int _salenum = 0;
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
        public string GoodsCode
        {
            set { _goodscode = value; }
            get { return _goodscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsName
        {
            set { _goodsname = value; }
            get { return _goodsname; }
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
        public decimal RealityPrice
        {
            set { _realityprice = value; }
            get { return _realityprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Standard
        {
            set { _standard = value; }
            get { return _standard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsHave
        {
            set { _ishave = value; }
            get { return _ishave; }
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
        public int GoodsType
        {
            set { _goodstype = value; }
            get { return _goodstype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pic1
        {
            set { _pic1 = value; }
            get { return _pic1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pic2
        {
            set { _pic2 = value; }
            get { return _pic2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pic3
        {
            set { _pic3 = value; }
            get { return _pic3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pic4
        {
            set { _pic4 = value; }
            get { return _pic4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pic5
        {
            set { _pic5 = value; }
            get { return _pic5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Summary
        {
            set { _summary = value; }
            get { return _summary; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Goods001
        {
            set { _goods001 = value; }
            get { return _goods001; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Goods002
        {
            set { _goods002 = value; }
            get { return _goods002; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Goods003
        {
            set { _goods003 = value; }
            get { return _goods003; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Goods004
        {
            set { _goods004 = value; }
            get { return _goods004; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Goods005
        {
            set { _goods005 = value; }
            get { return _goods005; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Goods006
        {
            set { _goods006 = value; }
            get { return _goods006; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Goods007
        {
            set { _goods007 = value; }
            get { return _goods007; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Goods008
        {
            set { _goods008 = value; }
            get { return _goods008; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsName_en
        {
            set { _goodsname_en = value; }
            get { return _goodsname_en; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks_en
        {
            set { _remarks_en = value; }
            get { return _remarks_en; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int StateType
        {
            set { _statetype = value; }
            get { return _statetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ShopPrice
        {
            set { _shopprice = value; }
            get { return _shopprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Inventory
        {
            set { _inventory = value; }
            get { return _inventory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SaleNum
        {
            set { _salenum = value; }
            get { return _salenum; }
        }
        #endregion Model

	}
}

