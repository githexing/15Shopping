using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_serviceQQ:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_serviceQQ
	{
		public tb_serviceQQ()
		{}
		#region Model
		private long _id;
		private string _servicename;
		private string _qqnum;
		private string _qq001;
		private string _qq002;
		private string _qq003;
        private int _type;
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
		public string ServiceName
		{
			set{ _servicename=value;}
			get{return _servicename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQnum
		{
			set{ _qqnum=value;}
			get{return _qqnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ001
		{
			set{ _qq001=value;}
			get{return _qq001;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ002
		{
			set{ _qq002=value;}
			get{return _qq002;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ003
		{
			set{ _qq003=value;}
			get{return _qq003;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int QQType
        {
            set { _type = value; }
            get { return _type; }
        }
		#endregion Model

	}
}

