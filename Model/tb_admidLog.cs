using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_admidLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_admidLog
	{
		public tb_admidLog()
		{}
		#region Model
		private int _id;
		private string _username;
		private DateTime _logtime;
		private string _logcontent;
		private string _logip;
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
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LogTime
		{
			set{ _logtime=value;}
			get{return _logtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LogContent
		{
			set{ _logcontent=value;}
			get{return _logcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LogIP
		{
			set{ _logip=value;}
			get{return _logip;}
		}
		#endregion Model

	}
}

