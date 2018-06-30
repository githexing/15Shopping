using System;
namespace lgk.Model
{
	/// <summary>
	/// gp_SplitStockManage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class gp_SplitStockManage
	{
		public gp_SplitStockManage()
		{}
		#region Model
		private long _id;
		private long _userid;
		private string _usercode;
		private decimal? _splitqstock;
		private decimal? _splitsstock;
		private decimal? _splithstock;
		private DateTime _splitstocktime;
		private decimal _splitrate;
		private decimal _openmoney;
		private int? _split01;
		private int? _split02;
		private decimal? _split03;
		private decimal? _split04;
		private DateTime? _split05;
		private string _split06;
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
		public decimal? SplitQStock
		{
			set{ _splitqstock=value;}
			get{return _splitqstock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SplitSStock
		{
			set{ _splitsstock=value;}
			get{return _splitsstock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SplitHStock
		{
			set{ _splithstock=value;}
			get{return _splithstock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime SplitStockTime
		{
			set{ _splitstocktime=value;}
			get{return _splitstocktime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal SplitRate
		{
			set{ _splitrate=value;}
			get{return _splitrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal OpenMoney
		{
			set{ _openmoney=value;}
			get{return _openmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Split01
		{
			set{ _split01=value;}
			get{return _split01;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Split02
		{
			set{ _split02=value;}
			get{return _split02;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Split03
		{
			set{ _split03=value;}
			get{return _split03;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Split04
		{
			set{ _split04=value;}
			get{return _split04;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Split05
		{
			set{ _split05=value;}
			get{return _split05;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Split06
		{
			set{ _split06=value;}
			get{return _split06;}
		}
		#endregion Model

	}
}

