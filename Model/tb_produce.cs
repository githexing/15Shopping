using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_produce:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_produce
	{
		public tb_produce()
		{}
		#region Model
		private int _procudeid;
		private string _procudecode;
		private string _procudename;
		private decimal _marketprice;
		private decimal _memberprice;
		private int _procudepv;
		private string _picture;
		private string _linkurl;
		private int _isputaway;
		private string _note;
		/// <summary>
		/// 
		/// </summary>
		public int ProcudeID
		{
			set{ _procudeid=value;}
			get{return _procudeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProcudeCode
		{
			set{ _procudecode=value;}
			get{return _procudecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string procudeName
		{
			set{ _procudename=value;}
			get{return _procudename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal MarketPrice
		{
			set{ _marketprice=value;}
			get{return _marketprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal MemberPrice
		{
			set{ _memberprice=value;}
			get{return _memberprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int procudePV
		{
			set{ _procudepv=value;}
			get{return _procudepv;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string picture
		{
			set{ _picture=value;}
			get{return _picture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LinkURL
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsPutaway
		{
			set{ _isputaway=value;}
			get{return _isputaway;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		#endregion Model

	}
}

