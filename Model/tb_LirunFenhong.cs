using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_LirunFenhong:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_LirunFenhong
	{
		public tb_LirunFenhong()
		{}
		#region Model
		private int _lrfhid;
		private decimal? _bonusmoney;
		private decimal? _fhrate;
		private DateTime? _fhtime;
		/// <summary>
		/// 
		/// </summary>
		public int LrfhID
		{
			set{ _lrfhid=value;}
			get{return _lrfhid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? BonusMoney
		{
			set{ _bonusmoney=value;}
			get{return _bonusmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FhRate
		{
			set{ _fhrate=value;}
			get{return _fhrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FhTime
		{
			set{ _fhtime=value;}
			get{return _fhtime;}
		}
		#endregion Model

	}
}

