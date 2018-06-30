using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_leaveReMsg:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_leaveReMsg
	{
		public tb_leaveReMsg()
		{}
		#region Model
		private long _id;
		private long _leaveid;
		private string _recontent;
		private DateTime _retime;
		private int _usertype;
		private long _userid;
		private string _usercode;
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
		public long LeaveID
		{
			set{ _leaveid=value;}
			get{return _leaveid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReContent
		{
			set{ _recontent=value;}
			get{return _recontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ReTime
		{
			set{ _retime=value;}
			get{return _retime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserCode
		{
			set{ _usercode=value;}
			get{return _usercode;}
		}
		#endregion Model

	}
}

