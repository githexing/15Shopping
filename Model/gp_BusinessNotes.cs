using System;
namespace lgk.Model
{
	/// <summary>
	/// gp_BusinessNotes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class gp_BusinessNotes
	{
		public gp_BusinessNotes()
		{}
		#region Model
		private long _id;
		private long _userid;
		private string _usercode;
		private int _businesstype;
		private int _usertype;
		private DateTime _businesstime;
		private decimal _businessamount;
		private decimal _businessprice;
		private decimal _summoney;
		private decimal? _poundage;
		private decimal _amountmoney;
		private decimal _instockaccount;
		private decimal _inbonusaccount;
		private decimal _inmanageaccount;
		private long? _fromuserid;
		private string _fromusercode;
		private DateTime? _suctime;
		private int _status;
		private int? _notes01;
		private int? _notes02;
		private decimal? _notes03;
		private decimal? _notes04;
		private string _notes05;
		private string _notes06;
		/// <summary>
		/// 
		/// </summary>
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserCode
		{
			set{ _usercode=value;}
			get{return _usercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int BusinessType
		{
			set{ _businesstype=value;}
			get{return _businesstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime BusinessTime
		{
			set{ _businesstime=value;}
			get{return _businesstime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal BusinessAmount
		{
			set{ _businessamount=value;}
			get{return _businessamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal BusinessPrice
		{
			set{ _businessprice=value;}
			get{return _businessprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal SumMoney
		{
			set{ _summoney=value;}
			get{return _summoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Poundage
		{
			set{ _poundage=value;}
			get{return _poundage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal AmountMoney
		{
			set{ _amountmoney=value;}
			get{return _amountmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal InStockAccount
		{
			set{ _instockaccount=value;}
			get{return _instockaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal InBonusAccount
		{
			set{ _inbonusaccount=value;}
			get{return _inbonusaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal InManageAccount
		{
			set{ _inmanageaccount=value;}
			get{return _inmanageaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? FromUserID
		{
			set{ _fromuserid=value;}
			get{return _fromuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FromUserCode
		{
			set{ _fromusercode=value;}
			get{return _fromusercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SucTime
		{
			set{ _suctime=value;}
			get{return _suctime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Notes01
		{
			set{ _notes01=value;}
			get{return _notes01;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Notes02
		{
			set{ _notes02=value;}
			get{return _notes02;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Notes03
		{
			set{ _notes03=value;}
			get{return _notes03;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Notes04
		{
			set{ _notes04=value;}
			get{return _notes04;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Notes05
		{
			set{ _notes05=value;}
			get{return _notes05;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Notes06
		{
			set{ _notes06=value;}
			get{return _notes06;}
		}
		#endregion Model

	}
}

