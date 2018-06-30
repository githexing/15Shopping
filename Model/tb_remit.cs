using System;
namespace lgk.Model
{
    /// <summary>
    /// tb_remit:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_remit
    {
        public tb_remit()
        { }
        #region Model
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
        /// BankName
        /// </summary>		
        private string _bankname;
        public string BankName
        {
            get { return _bankname; }
            set { _bankname = value; }
        }
        /// <summary>
        /// BankAccount
        /// </summary>		
        private string _bankaccount;
        public string BankAccount
        {
            get { return _bankaccount; }
            set { _bankaccount = value; }
        }
        /// <summary>
        /// BankAccountUser
        /// </summary>		
        private string _bankaccountuser;
        public string BankAccountUser
        {
            get { return _bankaccountuser; }
            set { _bankaccountuser = value; }
        }
        /// <summary>
        /// RechargeableDate
        /// </summary>		
        private DateTime _rechargeabledate;
        public DateTime RechargeableDate
        {
            get { return _rechargeabledate; }
            set { _rechargeabledate = value; }
        }
        /// <summary>
        /// AddDate
        /// </summary>		
        private DateTime _adddate;
        public DateTime AddDate
        {
            get { return _adddate; }
            set { _adddate = value; }
        }
        /// <summary>
        /// State
        /// </summary>		
        private int _state;
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// RemitMoney
        /// </summary>		
        private decimal _remitmoney;
        public decimal RemitMoney
        {
            get { return _remitmoney; }
            set { _remitmoney = value; }
        }
        /// <summary>
        /// YuAmount
        /// </summary>		
        private decimal _yuamount;
        public decimal YuAmount
        {
            get { return _yuamount; }
            set { _yuamount = value; }
        }
        /// <summary>
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// UserID
        /// </summary>		
        private long _userid;
        public long UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// PassDate
        /// </summary>		
        private DateTime _passdate;
        public DateTime PassDate
        {
            get { return _passdate; }
            set { _passdate = value; }
        }
        /// <summary>
        /// Remit001
        /// </summary>		
        private int _remit001;
        public int Remit001
        {
            get { return _remit001; }
            set { _remit001 = value; }
        }
        /// <summary>
        /// Remit002
        /// </summary>		
        private int _remit002;
        public int Remit002
        {
            get { return _remit002; }
            set { _remit002 = value; }
        }
        /// <summary>
        /// Remit003
        /// </summary>		
        private string _remit003;
        public string Remit003
        {
            get { return _remit003; }
            set { _remit003 = value; }
        }
        /// <summary>
        /// Remit004
        /// </summary>		
        private string _remit004;
        public string Remit004
        {
            get { return _remit004; }
            set { _remit004 = value; }
        }
        /// <summary>
        /// Remit005
        /// </summary>		
        private string _remit005;
        public string Remit005
        {
            get { return _remit005; }
            set { _remit005 = value; }
        }
        /// <summary>
        /// Remit006
        /// </summary>		
        private decimal _remit006;
        public decimal Remit006
        {
            get { return _remit006; }
            set { _remit006 = value; }
        }
        public int Remit007 { set; get; }
        #endregion Model

    }
}

