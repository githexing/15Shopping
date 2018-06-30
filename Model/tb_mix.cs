using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_mix:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_mix
	{
		public tb_mix()
		{}
		#region Model
		private long _id;
		private long _userid;
		private int _bonusid;
		private decimal _amount;
		private DateTime _addtime;
		private string _source;
		private int? _fromuserid;
		private int? _mix001;
		private int? _mix002;
		private string _mix003;
		private string _mix004;
		private decimal? _mix005;
		private decimal? _mix006;
		private DateTime? _mix007;
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
		public long UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int BonusID
		{
			set{ _bonusid=value;}
			get{return _bonusid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Source
		{
			set{ _source=value;}
			get{return _source;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FromUserID
		{
			set{ _fromuserid=value;}
			get{return _fromuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Mix001
		{
			set{ _mix001=value;}
			get{return _mix001;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Mix002
		{
			set{ _mix002=value;}
			get{return _mix002;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mix003
		{
			set{ _mix003=value;}
			get{return _mix003;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mix004
		{
			set{ _mix004=value;}
			get{return _mix004;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Mix005
		{
			set{ _mix005=value;}
			get{return _mix005;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Mix006
		{
			set{ _mix006=value;}
			get{return _mix006;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Mix007
		{
			set{ _mix007=value;}
			get{return _mix007;}
		}
		#endregion Model

	}
}

