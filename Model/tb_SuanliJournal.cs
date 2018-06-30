using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    /// <summary>
	/// tb_SuanliJournal:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class tb_SuanliJournal
    {
        public tb_SuanliJournal()
        { }
        #region Model
        private long _id;
        private long _userid = 0;
        private decimal _reduceamount = 0M;
        private decimal _addamount = 0M;
        private decimal _surplusamount = 0M;
        private int _moneytype = 0;
        private string _remark;
        private string _remarken;
        private DateTime _jointime = DateTime.Now;
        private long _fromuserid = 0;
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
        public decimal ReduceAmount
        {
            set { _reduceamount = value; }
            get { return _reduceamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal AddAmount
        {
            set { _addamount = value; }
            get { return _addamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SurplusAmount
        {
            set { _surplusamount = value; }
            get { return _surplusamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MoneyType
        {
            set { _moneytype = value; }
            get { return _moneytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RemarkEn
        {
            set { _remarken = value; }
            get { return _remarken; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime JoinTime
        {
            set { _jointime = value; }
            get { return _jointime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long FromUserID
        {
            set { _fromuserid = value; }
            get { return _fromuserid; }
        }
        #endregion Model

    }
}
