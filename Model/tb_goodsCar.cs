using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
 
    /// <summary>
    /// tb_goods:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_goodsCar
    {
        public tb_goodsCar()
        { }
        #region Model
        private long _id;
        private long _goodsid = 0;
        private string _goodscode = "";
        private string _goodsname = "";
        private decimal _price = 0M;
        private decimal _realityprice = 0M;
        private int _typeid = 0;
        private string _typeidname = "";
        private int _goodstype = 0;
        private string _goodstypename = "";
        private string _pic1 = "";
        private string _remarks = "";
        private DateTime _addtime;
        private int _goods002 = 0;
        private decimal _goods005 = 0M;
        private int _goods006 = 0;
        private long _buyuser = 0;
        private decimal _totalmoney;
        private int _totalgoods006;
        private decimal _shopprice = 0M;
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
        public long GoodsID
        {
            set { _goodsid = value; }
            get { return _goodsid; }
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
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeIDName
        {
            set { _typeidname = value; }
            get { return _typeidname; }
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
        public string GoodsTypeName
        {
            set { _goodstypename = value; }
            get { return _goodstypename; }
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
        public int Goods002
        {
            set { _goods002 = value; }
            get { return _goods002; }
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
        public int Goods006
        {
            set { _goods006 = value; }
            get { return _goods006; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long BuyUser
        {
            set { _buyuser = value; }
            get { return _buyuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalMoney
        {
            set { _totalmoney = value; }
            get { return _totalmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TotalGoods006
        {
            set { _totalgoods006 = value; }
            get { return _totalgoods006; }
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
