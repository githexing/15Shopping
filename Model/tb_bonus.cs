using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_bonus:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_bonus
	{
		public tb_bonus()
		{}
        #region Model
        private long _id;
        private long _userid = 0;
        private int _typeid = 0;
        private decimal _amount = 0M;
        private decimal _revenue = 0M;
        private decimal _sf = 0M;
        private DateTime _addtime;
        private int _issettled = 0;
        private string _source;
        private string _sourceen;
        private DateTime? _sttletime;
        private long? _fromuserid;
        private int _bonus001 = 0;
        private int _bonus002 = 0;
        private string _bonus003;
        private string _bonus004;
        private decimal _bonus005 = 0M;
        private decimal _bonus006 = 0M;
        private DateTime? _bonus007;
        private int _batch = 0;
        /// <summary>
        /// 
        /// </summary>
        public long ID
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
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Revenue
        {
            set { _revenue = value; }
            get { return _revenue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal sf
        {
            set { _sf = value; }
            get { return _sf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsSettled
        {
            set { _issettled = value; }
            get { return _issettled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SourceEn
        {
            set { _sourceen = value; }
            get { return _sourceen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SttleTime
        {
            set { _sttletime = value; }
            get { return _sttletime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? FromUserID
        {
            set { _fromuserid = value; }
            get { return _fromuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Bonus001
        {
            set { _bonus001 = value; }
            get { return _bonus001; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Bonus002
        {
            set { _bonus002 = value; }
            get { return _bonus002; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Bonus003
        {
            set { _bonus003 = value; }
            get { return _bonus003; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Bonus004
        {
            set { _bonus004 = value; }
            get { return _bonus004; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Bonus005
        {
            set { _bonus005 = value; }
            get { return _bonus005; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Bonus006
        {
            set { _bonus006 = value; }
            get { return _bonus006; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Bonus007
        {
            set { _bonus007 = value; }
            get { return _bonus007; }
        }
        /// <summary>
        /// 获奖批次
        /// </summary>
        public int Batch
        {
            set { _batch = value; }
            get { return _batch; }
        }
        #endregion Model

    }
}

