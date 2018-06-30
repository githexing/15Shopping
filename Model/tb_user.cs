using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_user
	{
		public tb_user()
		{}
        #region Model
        private long _userid;
        private string _usercode;
        private int _levelid = 0;
        private long _recommendid = 0;
        private string _recommendcode;
        private string _recommendpath;
        private int _recommendgenera = 0;
        private long _parentid = 0;
        private string _parentcode;
        private string _userpath;
        private int _layer = 0;
        private int _location = 0;
        private int _isopend = 0;
        private int _islock = 0;
        private int _isagent = 0;
        private int _agentsid = 0;
        private decimal _emoney = 0M;
        private decimal _bonusaccount = 0M;
        private decimal _allbonusaccount = 0M;
        private decimal _stockaccount = 0M;
        private decimal _stockmoney = 0M;
        private int _user003 = 0;
        private decimal _shopaccount = 0M;
        private DateTime _regtime;
        private DateTime? _opentime;
        private decimal _regmoney = 0M;
        private int _billcount = 0;
        private decimal _glmoney = 0M;
        private DateTime? _addgltime;
        private string _password;
        private string _secondpassword;
        private string _threepassword;
        private string _safetycodequestion;
        private string _safetycodeanswer;
        private decimal _leftscore = 0M;
        private decimal _centerscore = 0M;
        private decimal _rightscore = 0M;
        private decimal _leftbalance = 0M;
        private decimal _centerbalance = 0M;
        private decimal _rightbalance = 0M;
        private decimal _leftnewscore = 0M;
        private decimal _centernewscore = 0M;
        private decimal _rightnewscore = 0M;
        private decimal _leftzt = 0M;
        private decimal _centerzt = 0M;
        private decimal _rightzt = 0M;
        private string _bankaccount;
        private string _bankaccountuser;
        private string _bankname;
        private string _bankbranch;
        private string _bankinprovince;
        private string _bankincity;
        private string _address;
        private string _truename;
        private string _nicename;
        private string _idencode;
        private string _phonenum;
        private int _gender = 0;
        private string _qqnumer;
        private int _user001 = 0;
        private long _user002 = 0;
        private int _user004 = 0;
        private string _user005;
        private string _user006;
        private string _user007;
        private string _user008;
        private string _user009;
        private string _user010;
        private decimal _user011 = 0M;
        private decimal _user012 = 0M;
        private decimal _user013 = 0M;
        private decimal _user014 = 0M;
        private decimal _user015 = 0M;
        private decimal _user016 = 0M;
        private decimal _user017 = 0M;
        private decimal _user018 = 0M;
        private string _email;
        private int _isout = 0;
        private int _batch = 0;
        private int _syncimstate = 0;
        private DateTime? _syncimtime;
        private int _machinenumlock = 0;
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
        public string UserCode
        {
            set { _usercode = value; }
            get { return _usercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LevelID
        {
            set { _levelid = value; }
            get { return _levelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long RecommendID
        {
            set { _recommendid = value; }
            get { return _recommendid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RecommendCode
        {
            set { _recommendcode = value; }
            get { return _recommendcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RecommendPath
        {
            set { _recommendpath = value; }
            get { return _recommendpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RecommendGenera
        {
            set { _recommendgenera = value; }
            get { return _recommendgenera; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParentCode
        {
            set { _parentcode = value; }
            get { return _parentcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserPath
        {
            set { _userpath = value; }
            get { return _userpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Layer
        {
            set { _layer = value; }
            get { return _layer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Location
        {
            set { _location = value; }
            get { return _location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsOpend
        {
            set { _isopend = value; }
            get { return _isopend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsAgent
        {
            set { _isagent = value; }
            get { return _isagent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AgentsID
        {
            set { _agentsid = value; }
            get { return _agentsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Emoney
        {
            set { _emoney = value; }
            get { return _emoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal BonusAccount
        {
            set { _bonusaccount = value; }
            get { return _bonusaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal AllBonusAccount
        {
            set { _allbonusaccount = value; }
            get { return _allbonusaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal StockAccount
        {
            set { _stockaccount = value; }
            get { return _stockaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal StockMoney
        {
            set { _stockmoney = value; }
            get { return _stockmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int User003
        {
            set { _user003 = value; }
            get { return _user003; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ShopAccount
        {
            set { _shopaccount = value; }
            get { return _shopaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RegTime
        {
            set { _regtime = value; }
            get { return _regtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OpenTime
        {
            set { _opentime = value; }
            get { return _opentime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RegMoney
        {
            set { _regmoney = value; }
            get { return _regmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BillCount
        {
            set { _billcount = value; }
            get { return _billcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal GLmoney
        {
            set { _glmoney = value; }
            get { return _glmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddGLTime
        {
            set { _addgltime = value; }
            get { return _addgltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SecondPassword
        {
            set { _secondpassword = value; }
            get { return _secondpassword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThreePassword
        {
            set { _threepassword = value; }
            get { return _threepassword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SafetyCodeQuestion
        {
            set { _safetycodequestion = value; }
            get { return _safetycodequestion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SafetyCodeAnswer
        {
            set { _safetycodeanswer = value; }
            get { return _safetycodeanswer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal LeftScore
        {
            set { _leftscore = value; }
            get { return _leftscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CenterScore
        {
            set { _centerscore = value; }
            get { return _centerscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RightScore
        {
            set { _rightscore = value; }
            get { return _rightscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal LeftBalance
        {
            set { _leftbalance = value; }
            get { return _leftbalance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CenterBalance
        {
            set { _centerbalance = value; }
            get { return _centerbalance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RightBalance
        {
            set { _rightbalance = value; }
            get { return _rightbalance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal LeftNewScore
        {
            set { _leftnewscore = value; }
            get { return _leftnewscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CenterNewScore
        {
            set { _centernewscore = value; }
            get { return _centernewscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RightNewScore
        {
            set { _rightnewscore = value; }
            get { return _rightnewscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal LeftZT
        {
            set { _leftzt = value; }
            get { return _leftzt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CenterZT
        {
            set { _centerzt = value; }
            get { return _centerzt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RightZT
        {
            set { _rightzt = value; }
            get { return _rightzt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankAccount
        {
            set { _bankaccount = value; }
            get { return _bankaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankAccountUser
        {
            set { _bankaccountuser = value; }
            get { return _bankaccountuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankBranch
        {
            set { _bankbranch = value; }
            get { return _bankbranch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankInProvince
        {
            set { _bankinprovince = value; }
            get { return _bankinprovince; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankInCity
        {
            set { _bankincity = value; }
            get { return _bankincity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrueName
        {
            set { _truename = value; }
            get { return _truename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NiceName
        {
            set { _nicename = value; }
            get { return _nicename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IdenCode
        {
            set { _idencode = value; }
            get { return _idencode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNum
        {
            set { _phonenum = value; }
            get { return _phonenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQnumer
        {
            set { _qqnumer = value; }
            get { return _qqnumer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int User001
        {
            set { _user001 = value; }
            get { return _user001; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long User002
        {
            set { _user002 = value; }
            get { return _user002; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int User004
        {
            set { _user004 = value; }
            get { return _user004; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string User005
        {
            set { _user005 = value; }
            get { return _user005; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string User006
        {
            set { _user006 = value; }
            get { return _user006; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string User007
        {
            set { _user007 = value; }
            get { return _user007; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string User008
        {
            set { _user008 = value; }
            get { return _user008; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string User009
        {
            set { _user009 = value; }
            get { return _user009; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string User010
        {
            set { _user010 = value; }
            get { return _user010; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal User011
        {
            set { _user011 = value; }
            get { return _user011; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal User012
        {
            set { _user012 = value; }
            get { return _user012; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal User013
        {
            set { _user013 = value; }
            get { return _user013; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal User014
        {
            set { _user014 = value; }
            get { return _user014; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal User015
        {
            set { _user015 = value; }
            get { return _user015; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal User016
        {
            set { _user016 = value; }
            get { return _user016; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal User017
        {
            set { _user017 = value; }
            get { return _user017; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal User018
        {
            set { _user018 = value; }
            get { return _user018; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 是否出局(0否，1是)
        /// </summary>
        public int IsOut
        {
            set { _isout = value; }
            get { return _isout; }
        }
        /// <summary>
        /// 复投次数
        /// </summary>
        public int Batch
        {
            set { _batch = value; }
            get { return _batch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SyncIMState
        {
            set { _syncimstate = value; }
            get { return _syncimstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SyncIMTime
        {
            set { _syncimtime = value; }
            get { return _syncimtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MachineNumLock
        {
            set { _machinenumlock = value; }
            get { return _machinenumlock; }
        }
        #endregion Model

    }
}

