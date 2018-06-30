using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    /// <summary>
	/// tb_BuyMachine:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class tb_BuyMachine
    {
        public tb_BuyMachine()
        { }
        #region Model
        private long _id;
        private long _userid = 0;
        private decimal _price = 0M;
        private int _num = 0;
        private decimal _amount = 0M;
        private DateTime? _buytime;
        private decimal _calcpower = 0M;
        private int _isexpire = 0;
        private int _isactive = 0;
        private DateTime? _activetime;
        private int _surplusnum = 0;
        private int _activenum = 0;
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
        public long UserID
        {
            set { _userid = value; }
            get { return _userid; }
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
        public int Num
        {
            set { _num = value; }
            get { return _num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BuyTime
        {
            set { _buytime = value; }
            get { return _buytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CalcPower
        {
            set { _calcpower = value; }
            get { return _calcpower; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsExpire
        {
            set { _isexpire = value; }
            get { return _isexpire; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsActive
        {
            set { _isactive = value; }
            get { return _isactive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ActiveTime
        {
            set { _activetime = value; }
            get { return _activetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SurplusNum
        {
            set { _surplusnum = value; }
            get { return _surplusnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ActiveNum
        {
            set { _activenum = value; }
            get { return _activenum; }
        }
        #endregion Model

    }
}

