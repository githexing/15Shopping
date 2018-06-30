using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_leaveMsg:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_leaveMsg
	{
		public tb_leaveMsg()
		{}
		#region Model
		private long _id;
		private string _msgtitle;
		private string _msgcontent;
		private DateTime _leavetime;
		private int _isread;
		private int _isreply;
		private int _fromusertype;
		private long? _userid;
		private string _usercode;
		private int? _fromidisdel;
		private int _tousertype;
		private long? _touserid;
		private string _tousercode;
		private int? _toidisdel;
        private int _msgType;
        private string _pic;
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
		public string MsgTitle
		{
			set{ _msgtitle=value;}
			get{return _msgtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgContent
		{
			set{ _msgcontent=value;}
			get{return _msgcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LeaveTime
		{
			set{ _leavetime=value;}
			get{return _leavetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsReply
		{
			set{ _isreply=value;}
			get{return _isreply;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FromUserType
		{
			set{ _fromusertype=value;}
			get{return _fromusertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? UserID
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
		/// <summary>
		/// 
		/// </summary>
		public int? FromIDIsDel
		{
			set{ _fromidisdel=value;}
			get{return _fromidisdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ToUserType
		{
			set{ _tousertype=value;}
			get{return _tousertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? ToUserID
		{
			set{ _touserid=value;}
			get{return _touserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ToUserCode
		{
			set{ _tousercode=value;}
			get{return _tousercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ToIDIsDel
		{
			set{ _toidisdel=value;}
			get{return _toidisdel;}
		}

        public int MsgType
        {
            set { _msgType = value; }
            get { return _msgType; }
        }

        public string Pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        #endregion Model

    }
}

