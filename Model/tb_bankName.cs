using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_bankName:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_bankName
	{
		public tb_bankName()
		{}
		#region Model
		private int _id;
		private string _bankname;
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
		public string BankName
		{
			set{ _bankname=value;}
			get{return _bankname;}
		}
		#endregion Model

	}
}

