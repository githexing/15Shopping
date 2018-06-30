using System;
namespace lgk.Model
{
	/// <summary>
	/// gp_BusinessAmount:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class gp_BusinessAmount
	{
		public gp_BusinessAmount()
		{}
		#region Model
		private long _id;
		private DateTime _businesstime;
		private decimal _businessamount;
		private int? _by01;
		private decimal? _by02;
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
		public int? by01
		{
			set{ _by01=value;}
			get{return _by01;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? by02
		{
			set{ _by02=value;}
			get{return _by02;}
		}
		#endregion Model

	}
}

