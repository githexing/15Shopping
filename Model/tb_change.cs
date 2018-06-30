using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_change:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_change
	{
		public tb_change()
		{}
		#region Model

        /// <summary>
        /// ID
        /// </summary>		
        private long _id;
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// UserID
        /// </summary>		
        private long _userid;
        public long UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// ToUserType
        /// </summary>		
        private int _tousertype;
        public int ToUserType
        {
            get { return _tousertype; }
            set { _tousertype = value; }
        }
        /// <summary>
        /// ToUserID
        /// </summary>		
        private long _touserid;
        public long ToUserID
        {
            get { return _touserid; }
            set { _touserid = value; }
        }
        /// <summary>
        /// ChangeType
        /// </summary>		
        private int _changetype;
        public int ChangeType
        {
            get { return _changetype; }
            set { _changetype = value; }
        }
        /// <summary>
        /// MoneyType
        /// </summary>		
        private int _moneytype;
        public int MoneyType
        {
            get { return _moneytype; }
            set { _moneytype = value; }
        }
        /// <summary>
        /// Amount
        /// </summary>		
        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        /// <summary>
        /// ChangeDate
        /// </summary>		
        private DateTime _changedate;
        public DateTime ChangeDate
        {
            get { return _changedate; }
            set { _changedate = value; }
        }
        /// <summary>
        /// Change001
        /// </summary>		
        private int _change001;
        public int Change001
        {
            get { return _change001; }
            set { _change001 = value; }
        }
        /// <summary>
        /// Change002
        /// </summary>		
        private int _change002;
        public int Change002
        {
            get { return _change002; }
            set { _change002 = value; }
        }
        /// <summary>
        /// Change003
        /// </summary>		
        private string _change003;
        public string Change003
        {
            get { return _change003; }
            set { _change003 = value; }
        }
        /// <summary>
        /// Change004
        /// </summary>		
        private string _change004;
        public string Change004
        {
            get { return _change004; }
            set { _change004 = value; }
        }
        /// <summary>
        /// Change005
        /// </summary>		
        private decimal _change005;
        public decimal Change005
        {
            get { return _change005; }
            set { _change005 = value; }
        }
        /// <summary>
        /// Change006
        /// </summary>		
        private decimal _change006;
        public decimal Change006
        {
            get { return _change006; }
            set { _change006 = value; }
        }

		#endregion Model

	}
}

