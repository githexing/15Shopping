using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_news:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_news
	{
		public tb_news()
		{}
		#region Model
		private long _id;
		private string _newstitle;
		private string _newscontent;
		private int _newstype;
		private DateTime _publishtime;
		private string _publisher;
		private string _imageurl;
		private int? _newtype;
		private string _classify;
		private string _tags;
		private int? _click;
		private int? _new01;
		private int? _new02;
		private decimal? _new03;
		private decimal? _new04;
		private string _new05;
		private string _new06;
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
		public string NewsTitle
		{
			set{ _newstitle=value;}
			get{return _newstitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsContent
		{
			set{ _newscontent=value;}
			get{return _newscontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int NewsType
		{
			set{ _newstype=value;}
			get{return _newstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime PublishTime
		{
			set{ _publishtime=value;}
			get{return _publishtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Publisher
		{
			set{ _publisher=value;}
			get{return _publisher;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImageURL
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NewType
		{
			set{ _newtype=value;}
			get{return _newtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Classify
		{
			set{ _classify=value;}
			get{return _classify;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tags
		{
			set{ _tags=value;}
			get{return _tags;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Click
		{
			set{ _click=value;}
			get{return _click;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? New01
		{
			set{ _new01=value;}
			get{return _new01;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? New02
		{
			set{ _new02=value;}
			get{return _new02;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? New03
		{
			set{ _new03=value;}
			get{return _new03;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? New04
		{
			set{ _new04=value;}
			get{return _new04;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string New05
		{
			set{ _new05=value;}
			get{return _new05;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string New06
		{
			set{ _new06=value;}
			get{return _new06;}
		}
		#endregion Model

	}
}

