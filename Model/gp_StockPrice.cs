using System;
namespace lgk.Model
{
	/// <summary>
	/// gp_StockPrice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class gp_StockPrice
	{
		public gp_StockPrice()
		{}
		#region Model
		private long _id;
		private int _pricetype;
		private DateTime _businesstime;
		private decimal _upprice;
		private decimal _openmoney;
		private decimal? _price;
		private int? _up_dropdaynumber;
		private decimal? _lastopenmoney;
		private DateTime? _lastup_dropdaynumber;
		private DateTime _addtime;
		private int? _price01;
		private int? _price02;
		private int? _price03;
		private DateTime? _price04;
		private DateTime? _price05;
		private decimal? _price06;
		private decimal? _price07;
		private decimal? _price08;
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
		public int PriceType
		{
			set{ _pricetype=value;}
			get{return _pricetype;}
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
		public decimal UpPrice
		{
			set{ _upprice=value;}
			get{return _upprice;}
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
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Up_DropDayNumber
		{
			set{ _up_dropdaynumber=value;}
			get{return _up_dropdaynumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LastOpenMoney
		{
			set{ _lastopenmoney=value;}
			get{return _lastopenmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastUp_DropDayNumber
		{
			set{ _lastup_dropdaynumber=value;}
			get{return _lastup_dropdaynumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Price01
		{
			set{ _price01=value;}
			get{return _price01;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Price02
		{
			set{ _price02=value;}
			get{return _price02;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Price03
		{
			set{ _price03=value;}
			get{return _price03;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Price04
		{
			set{ _price04=value;}
			get{return _price04;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Price05
		{
			set{ _price05=value;}
			get{return _price05;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price06
		{
			set{ _price06=value;}
			get{return _price06;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price07
		{
			set{ _price07=value;}
			get{return _price07;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price08
		{
			set{ _price08=value;}
			get{return _price08;}
		}
		#endregion Model

	}
}

