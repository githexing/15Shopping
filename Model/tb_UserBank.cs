using System;
namespace lgk.Model
{
    /// <summary>
    /// tb_UserBank:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_UserBank
    {
        public tb_UserBank()
        { }
        #region Model
        private int _id;
        private long _userid;
        private string _bankname;
        private string _bankaccount;
        private string _bankaccountuser;
        private string _bankaddress;
        private int? _mastertype;
        private string _bank001;
        private string _bank002;
        private int? _bank003;
        private int? _bank004;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankAccount
        {
            set { _bankaccount = value; }
            get { return _bankaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankAccountUser
        {
            set { _bankaccountuser = value; }
            get { return _bankaccountuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankAddress
        {
            set { _bankaddress = value; }
            get { return _bankaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MasterType
        {
            set { _mastertype = value; }
            get { return _mastertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Bank001
        {
            set { _bank001 = value; }
            get { return _bank001; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Bank002
        {
            set { _bank002 = value; }
            get { return _bank002; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Bank003
        {
            set { _bank003 = value; }
            get { return _bank003; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Bank004
        {
            set { _bank004 = value; }
            get { return _bank004; }
        }
        #endregion Model

    }
}

