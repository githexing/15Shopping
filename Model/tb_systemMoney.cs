using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_systemMoney:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_systemMoney
	{
		public tb_systemMoney()
		{}
		#region Model
		private int _id;
		private decimal _moneyaccount;
		private decimal _allbonusaccount;
		private decimal? _money001;
		private decimal? _money002;
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
		public decimal MoneyAccount
		{
			set{ _moneyaccount=value;}
			get{return _moneyaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal AllBonusAccount
		{
			set{ _allbonusaccount=value;}
			get{return _allbonusaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Money001
		{
			set{ _money001=value;}
			get{return _money001;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Money002
		{
			set{ _money002=value;}
			get{return _money002;}
		}
		#endregion Model

	}
}

