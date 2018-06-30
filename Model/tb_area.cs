using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_area:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_area
	{
		public tb_area()
		{}
		#region Model
		private int _id;
		private string _areaid;
		private string _area;
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
		public string areaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string area
		{
			set{ _area=value;}
			get{return _area;}
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

