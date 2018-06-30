using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_takeMoney:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_takeMoney
	{
		public tb_takeMoney()
		{}
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
        /// TakeTime
        /// </summary>		
        private DateTime _taketime;
        public DateTime TakeTime
        {
            get { return _taketime; }
            set { _taketime = value; }
        }
        /// <summary>
        /// TakeMoney
        /// </summary>		
        private decimal _takemoney;
        public decimal TakeMoney
        {
            get { return _takemoney; }
            set { _takemoney = value; }
        }
        /// <summary>
        /// TakePoundage
        /// </summary>		
        private decimal _takepoundage;
        public decimal TakePoundage
        {
            get { return _takepoundage; }
            set { _takepoundage = value; }
        }
        /// <summary>
        /// RealityMoney
        /// </summary>		
        private decimal _realitymoney;
        public decimal RealityMoney
        {
            get { return _realitymoney; }
            set { _realitymoney = value; }
        }
        /// <summary>
        /// BonusBalance
        /// </summary>		
        private decimal _bonusbalance;
        public decimal BonusBalance
        {
            get { return _bonusbalance; }
            set { _bonusbalance = value; }
        }
        /// <summary>
        /// Flag
        /// </summary>		
        private int _flag;
        public int Flag
        {
            get { return _flag; }
            set { _flag = value; }
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
        /// BankDian
        /// </summary>		
        private string _bankdian;
        public string BankDian
        {
            get { return _bankdian; }
            set { _bankdian = value; }
        }
        /// <summary>
        /// Take001
        /// </summary>		
        private int _take001;
        public int Take001
        {
            get { return _take001; }
            set { _take001 = value; }
        }
        /// <summary>
        /// Take002
        /// </summary>		
        private int _take002;
        public int Take002
        {
            get { return _take002; }
            set { _take002 = value; }
        }
        /// <summary>
        /// Take003
        /// </summary>		
        private string _take003;
        public string Take003
        {
            get { return _take003; }
            set { _take003 = value; }
        }
        /// <summary>
        /// Take004
        /// </summary>		
        private string _take004;
        public string Take004
        {
            get { return _take004; }
            set { _take004 = value; }
        }
        /// <summary>
        /// Take005
        /// </summary>		
        private decimal _take005;
        public decimal Take005
        {
            get { return _take005; }
            set { _take005 = value; }
        }
        /// <summary>
        /// Take006
        /// </summary>		
        private DateTime? _take006;
        public DateTime? Take006
        {
            get { return _take006; }
            set { _take006 = value; }
        }

		#endregion Model

	}
}

