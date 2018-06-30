using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_wealth:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_wealth
	{
		public tb_wealth()
		{}
		#region Model
		private long _id;
		private string _wealthcontent;
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
		public string WealthContent
		{
			set{ _wealthcontent=value;}
			get{return _wealthcontent;}
		}
		#endregion Model

	}
}

