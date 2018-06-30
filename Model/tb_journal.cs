using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_journal:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_journal
	{
		public tb_journal()
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
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// RemarkEn
        /// </summary>		
        private string _remarken;
        public string RemarkEn
        {
            get { return _remarken; }
            set { _remarken = value; }
        }
        /// <summary>
        /// InAmount
        /// </summary>		
        private decimal _inamount;
        public decimal InAmount
        {
            get { return _inamount; }
            set { _inamount = value; }
        }
        /// <summary>
        /// OutAmount
        /// </summary>		
        private decimal _outamount;
        public decimal OutAmount
        {
            get { return _outamount; }
            set { _outamount = value; }
        }
        /// <summary>
        /// BalanceAmount
        /// </summary>		
        private decimal _balanceamount;
        public decimal BalanceAmount
        {
            get { return _balanceamount; }
            set { _balanceamount = value; }
        }
        /// <summary>
        /// JournalDate
        /// </summary>		
        private DateTime _journaldate;
        public DateTime JournalDate
        {
            get { return _journaldate; }
            set { _journaldate = value; }
        }
        /// <summary>
        /// JournalType
        /// </summary>		
        private int _journaltype;
        public int JournalType
        {
            get { return _journaltype; }
            set { _journaltype = value; }
        }
        /// <summary>
        /// Journal01
        /// </summary>		
        private long _journal01;
        public long Journal01
        {
            get { return _journal01; }
            set { _journal01 = value; }
        }
        /// <summary>
        /// Journal02
        /// </summary>		
        private int _journal02;
        public int Journal02
        {
            get { return _journal02; }
            set { _journal02 = value; }
        }
        /// <summary>
        /// Journal03
        /// </summary>		
        private string _journal03;
        public string Journal03
        {
            get { return _journal03; }
            set { _journal03 = value; }
        }
        /// <summary>
        /// Journal04
        /// </summary>		
        private string _journal04;
        public string Journal04
        {
            get { return _journal04; }
            set { _journal04 = value; }
        }
        /// <summary>
        /// Journal05
        /// </summary>		
        private decimal _journal05;
        public decimal Journal05
        {
            get { return _journal05; }
            set { _journal05 = value; }
        }
        /// <summary>
        /// Journal06
        /// </summary>		
        private decimal _journal06;
        public decimal Journal06
        {
            get { return _journal06; }
            set { _journal06 = value; }
        }
        /// <summary>
        /// Journal07
        /// </summary>		
        private DateTime? _journal07;
        public DateTime? Journal07
        {
            get { return _journal07; }
            set { _journal07 = value; }
        }

		#endregion Model

	}
}

