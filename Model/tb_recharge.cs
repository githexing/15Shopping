using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_recharge:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_recharge
	{
		public tb_recharge()
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
        /// RechargeableMoney
        /// </summary>		
        private decimal _rechargeablemoney;
        public decimal RechargeableMoney
        {
            get { return _rechargeablemoney; }
            set { _rechargeablemoney = value; }
        }
        /// <summary>
        /// RechargeStyle
        /// </summary>		
        private int _rechargestyle;
        public int RechargeStyle
        {
            get { return _rechargestyle; }
            set { _rechargestyle = value; }
        }
        /// <summary>
        /// Flag
        /// </summary>		
        private int _flag;
        public int Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        /// <summary>
        /// RechargeDate
        /// </summary>		
        private DateTime _rechargedate;
        public DateTime RechargeDate
        {
            get { return _rechargedate; }
            set { _rechargedate = value; }
        }
        /// <summary>
        /// YuAmount
        /// </summary>		
        private decimal _yuamount;
        public decimal YuAmount
        {
            get { return _yuamount; }
            set { _yuamount = value; }
        }
        /// <summary>
        /// RechargeType
        /// </summary>		
        private int _rechargetype;
        public int RechargeType
        {
            get { return _rechargetype; }
            set { _rechargetype = value; }
        }
        /// <summary>
        /// AgentID
        /// </summary>		
        private int _agentid;
        public int AgentID
        {
            get { return _agentid; }
            set { _agentid = value; }
        }
        /// <summary>
        /// Recharge001
        /// </summary>		
        private int _recharge001;
        public int Recharge001
        {
            get { return _recharge001; }
            set { _recharge001 = value; }
        }
        /// <summary>
        /// Recharge002
        /// </summary>		
        private int _recharge002;
        public int Recharge002
        {
            get { return _recharge002; }
            set { _recharge002 = value; }
        }
        /// <summary>
        /// Recharge003
        /// </summary>		
        private string _recharge003;
        public string Recharge003
        {
            get { return _recharge003; }
            set { _recharge003 = value; }
        }
        /// <summary>
        /// Recharge004
        /// </summary>		
        private string _recharge004;
        public string Recharge004
        {
            get { return _recharge004; }
            set { _recharge004 = value; }
        }
        /// <summary>
        /// Recharge005
        /// </summary>		
        private decimal _recharge005;
        public decimal Recharge005
        {
            get { return _recharge005; }
            set { _recharge005 = value; }
        }
        /// <summary>
        /// Recharge006
        /// </summary>		
        private decimal _recharge006;
        public decimal Recharge006
        {
            get { return _recharge006; }
            set { _recharge006 = value; }
        }

		#endregion Model

	}
}

