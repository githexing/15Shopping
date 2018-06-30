using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    [Serializable]
    public partial class tb_UserOrderDetail
    {
        public tb_UserOrderDetail()
        {}

        /// <summary>
        /// ID
        /// </summary>		
        private long _id;
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// OrderCode
        /// </summary>		
        private string _ordercode;
        public string OrderCode
        {
            get { return _ordercode; }
            set { _ordercode = value; }
        }
        /// <summary>
        /// SellerCode
        /// </summary>		
        private string _sellercode;
        public string SellerCode
        {
            get { return _sellercode; }
            set { _sellercode = value; }
        }
        /// <summary>
        /// Integral
        /// </summary>		
        private decimal _integral;
        public decimal Integral
        {
            get { return _integral; }
            set { _integral = value; }
        }
        /// <summary>
        /// Purchase
        /// </summary>		
        private decimal _purchase;
        public decimal Purchase
        {
            get { return _purchase; }
            set { _purchase = value; }
        }
        /// <summary>
        /// Sale
        /// </summary>		
        private decimal _sale;
        public decimal Sale
        {
            get { return _sale; }
            set { _sale = value; }
        }
        /// <summary>
        /// Quantity
        /// </summary>		
        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        /// <summary>
        /// d001
        /// </summary>		
        private int _d001;
        public int d001
        {
            get { return _d001; }
            set { _d001 = value; }
        }
        /// <summary>
        /// d002
        /// </summary>		
        private decimal _d002;
        public decimal d002
        {
            get { return _d002; }
            set { _d002 = value; }
        }
        /// <summary>
        /// d003
        /// </summary>		
        private string _d003;
        public string d003
        {
            get { return _d003; }
            set { _d003 = value; }
        }
        /// <summary>
        /// Equity
        /// </summary>		
        private decimal _equity;
        public decimal Equity
        {
            get { return _equity; }
            set { _equity = value; }
        }
        /// <summary>
        /// Equity
        /// </summary>		
        private decimal _equitytop;
        public decimal EquityTop
        {
            get { return _equitytop; }
            set { _equitytop = value; }
        }
    }
}
