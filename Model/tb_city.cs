using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_city:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_city
	{
		public tb_city()
		{}
		#region Model
		private int _id;
		private string _cityid;
		private string _city;
		private string _father;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string father
		{
			set{ _father=value;}
			get{return _father;}
		}
		#endregion Model

	}
}

