using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_agent:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_agent
	{
		public tb_agent()
		{}
		#region Model
		private long _id;
		private string _agentcode;
		private int _flag;
		private long _userid;
		private int _agenttype;
		private DateTime _applitime;
		private decimal? _joinmoney;
		private DateTime? _opentime;
		private string _piclink;
		private string _agentinprovince;
		private string _agentincity;
		private string _agentaddress;
		private int? _agent001;
		private int? _agent002;
		private string _agent003;
		private string _agent004;
		private decimal? _agent005;
		private decimal? _agent006;
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
		public string AgentCode
		{
			set{ _agentcode=value;}
			get{return _agentcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Flag
		{
			set{ _flag=value;}
			get{return _flag;}
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
		public int AgentType
		{
			set{ _agenttype=value;}
			get{return _agenttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AppliTime
		{
			set{ _applitime=value;}
			get{return _applitime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? JoinMoney
		{
			set{ _joinmoney=value;}
			get{return _joinmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OpenTime
		{
			set{ _opentime=value;}
			get{return _opentime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PicLink
		{
			set{ _piclink=value;}
			get{return _piclink;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AgentInProvince
		{
			set{ _agentinprovince=value;}
			get{return _agentinprovince;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AgentInCity
		{
			set{ _agentincity=value;}
			get{return _agentincity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AgentAddress
		{
			set{ _agentaddress=value;}
			get{return _agentaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Agent001
		{
			set{ _agent001=value;}
			get{return _agent001;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Agent002
		{
			set{ _agent002=value;}
			get{return _agent002;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Agent003
		{
			set{ _agent003=value;}
			get{return _agent003;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Agent004
		{
			set{ _agent004=value;}
			get{return _agent004;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Agent005
		{
			set{ _agent005=value;}
			get{return _agent005;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Agent006
		{
			set{ _agent006=value;}
			get{return _agent006;}
		}
		#endregion Model

	}
}

