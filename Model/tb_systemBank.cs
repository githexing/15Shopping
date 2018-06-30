using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_systemBank:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_systemBank
	{
		public tb_systemBank()
		{}
		#region Model
		private int _id;
		private string _bankname;
		private string _bankaddress;
		private string _bankaccount;
		private string _bankaccountuser;
		private int _banktype;
        private int _flag;
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
		/// <summary>
		/// 
		/// </summary>
		public string BankAddress
		{
			set{ _bankaddress=value;}
			get{return _bankaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BankAccount
		{
			set{ _bankaccount=value;}
			get{return _bankaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BankAccountUser
		{
			set{ _bankaccountuser=value;}
			get{return _bankaccountuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int BankType
		{
			set{ _banktype=value;}
			get{return _banktype;}
        }       
        /// <summary>
        /// 
        /// </summary>
        public int Flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        #endregion Model
        public int IsMor { set; get; }
    }
}

