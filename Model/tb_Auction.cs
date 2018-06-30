using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    /// <summary>
    /// tb_Auction:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_Auction
    {
        public tb_Auction()
        { }
        #region Model
        private int _aid;
        private int? _userid;
        private int? _said;
        private int? _atype;
        private string _saprname;
        private string _sanumber;
        private DateTime? _auctiontime = DateTime.Now;
        private decimal? _auctionprice;
        private int? _auction001;
        private int? _auction002;
        private string _auction003;
        private string _auction004;
        private decimal? _auction005;
        private decimal? _auction006;
        /// <summary>
        /// 
        /// </summary>
        public int AID
        {
            set { _aid = value; }
            get { return _aid; }
        }
        /// <summary>
        /// 会员id
        /// </summary>
        public int? userId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 拍场id
        /// </summary>
        public int? SaId
        {
            set { _said = value; }
            get { return _said; }
        }
        /// <summary>
        /// 竞拍方式
        /// </summary>
        public int? Atype
        {
            set { _atype = value; }
            get { return _atype; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string SaPrName
        {
            set { _saprname = value; }
            get { return _saprname; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string SaNumber
        {
            set { _sanumber = value; }
            get { return _sanumber; }
        }
        /// <summary>
        /// 竞拍时间
        /// </summary>
        public DateTime? AuctionTime
        {
            set { _auctiontime = value; }
            get { return _auctiontime; }
        }
        /// <summary>
        /// 竞拍价格
        /// </summary>
        public decimal? AuctionPrice
        {
            set { _auctionprice = value; }
            get { return _auctionprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Auction001
        {
            set { _auction001 = value; }
            get { return _auction001; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Auction002
        {
            set { _auction002 = value; }
            get { return _auction002; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Auction003
        {
            set { _auction003 = value; }
            get { return _auction003; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Auction004
        {
            set { _auction004 = value; }
            get { return _auction004; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Auction005
        {
            set { _auction005 = value; }
            get { return _auction005; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Auction006
        {
            set { _auction006 = value; }
            get { return _auction006; }
        }
        #endregion Model

    }
}
