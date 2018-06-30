using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_Link:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_Link
	{
		public tb_Link()
		{}
		#region Model
		private int _id;
		private string _linkimage=" ";
		private string _linkname=" ";
		private string _linkurl=" ";
		private int? _status=0;
		private string _link001=" ";
		private string _link002=" ";
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string LinkImage
		{
			set{ _linkimage=value;}
			get{return _linkimage;}
		}
		/// <summary>
		/// 链接名称
		/// </summary>
		public string LinkName
		{
			set{ _linkname=value;}
			get{return _linkname;}
		}
		/// <summary>
		/// 链接地址
		/// </summary>
		public string LinkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 排序号，倒序
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 链接类型1为友情链接，2为网站首页图片，3为商品首页图片
		/// </summary>
		public string Link001
		{
			set{ _link001=value;}
			get{return _link001;}
		}
		/// <summary>
		/// 备用字段2
		/// </summary>
		public string Link002
		{
			set{ _link002=value;}
			get{return _link002;}
		}
		#endregion Model

	}
}

