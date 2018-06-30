using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_admin
	{
		public tb_admin()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _truename;
		private string _password;
		private string _secondpassword;
		private string _thirdpassword;
		private string _limits;
		private DateTime? _adddate;
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
		public string TrueName
		{
			set{ _truename=value;}
			get{return _truename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SecondPassword
		{
			set{ _secondpassword=value;}
			get{return _secondpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ThirdPassword
		{
			set{ _thirdpassword=value;}
			get{return _thirdpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Limits
		{
			set{ _limits=value;}
			get{return _limits;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddDate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		#endregion Model

	}
}

