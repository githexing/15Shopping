using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_setSystem:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_setSystem
	{
		public tb_setSystem()
		{}
		#region Model
		private int _id;
		private int _isopenweb;
		private string _closewebremark;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsOpenWeb
		{
			set{ _isopenweb=value;}
			get{return _isopenweb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CloseWebRemark
		{
			set{ _closewebremark=value;}
			get{return _closewebremark;}
		}
		#endregion Model

	}
}

