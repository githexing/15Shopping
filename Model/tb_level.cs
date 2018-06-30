using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_level:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_level
	{
		public tb_level()
		{}
		#region Model
		private int _levelid;
		private string _levelname;
		private decimal _regmoney;
		private int? _level01;
		private int? _level02;
		private string _level03;
		private string _level04;
		private decimal? _level05;
		private decimal? _level06;
		private decimal? _level07;
		private decimal? _level08;
		/// <summary>
		/// 
		/// </summary>
		public int LevelID
		{
			set{ _levelid=value;}
			get{return _levelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LevelName
		{
			set{ _levelname=value;}
			get{return _levelname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal RegMoney
		{
			set{ _regmoney=value;}
			get{return _regmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? level01
		{
			set{ _level01=value;}
			get{return _level01;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? level02
		{
			set{ _level02=value;}
			get{return _level02;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string level03
		{
			set{ _level03=value;}
			get{return _level03;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string level04
		{
			set{ _level04=value;}
			get{return _level04;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? level05
		{
			set{ _level05=value;}
			get{return _level05;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? level06
		{
			set{ _level06=value;}
			get{return _level06;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? level07
		{
			set{ _level07=value;}
			get{return _level07;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? level08
		{
			set{ _level08=value;}
			get{return _level08;}
		}
		#endregion Model

	}
}

