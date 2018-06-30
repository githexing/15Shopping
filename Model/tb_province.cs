using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_province:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_province
	{
		public tb_province()
		{}
		#region Model
		private int _id;
		private string _provinceid;
		private string _province;
        private string _provinceen;
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
		public string provinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string province
		{
			set{ _province=value;}
			get{return _province;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string provinceen
        {
            set { _provinceen = value; }
            get { return _provinceen; }
        }
		#endregion Model

	}
}

