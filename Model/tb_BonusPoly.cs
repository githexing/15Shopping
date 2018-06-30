using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace lgk.Model{
	 	//tb_BonusPoly
		public class tb_BonusPoly
	{
   		     
      	/// <summary>
		/// ID
        /// </summary>		
		private long _id;
        public long ID
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// UserID
        /// </summary>		
		private long _userid;
        public long UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
		/// <summary>
		/// InvestOrderID
        /// </summary>		
		private long _investorderid;
        public long InvestOrderID
        {
            get{ return _investorderid; }
            set{ _investorderid = value; }
        }        
		/// <summary>
		/// Bonus
        /// </summary>		
		private decimal _bonus;
        public decimal Bonus
        {
            get{ return _bonus; }
            set{ _bonus = value; }
        }        
		/// <summary>
		/// ShareDay
        /// </summary>		
		private int _shareday;
        public int ShareDay
        {
            get{ return _shareday; }
            set{ _shareday = value; }
        }        
		/// <summary>
		/// ShareDate
        /// </summary>		
		private DateTime _sharedate;
        public DateTime ShareDate
        {
            get{ return _sharedate; }
            set{ _sharedate = value; }
        }        
		/// <summary>
		/// ShowDate
        /// </summary>		
		private string _showdate;
        public string ShowDate
        {
            get{ return _showdate; }
            set{ _showdate = value; }
        }        
		/// <summary>
		/// Flag
        /// </summary>		
		private int _flag;
        public int Flag
        {
            get{ return _flag; }
            set{ _flag = value; }
        }        
		/// <summary>
		/// SettleTime
        /// </summary>		
		private DateTime _settletime;
        public DateTime SettleTime
        {
            get{ return _settletime; }
            set{ _settletime = value; }
        }        
		/// <summary>
		/// TaskCompletedFlag
        /// </summary>		
		private int _taskcompletedflag;
        public int TaskCompletedFlag
        {
            get{ return _taskcompletedflag; }
            set{ _taskcompletedflag = value; }
        }        
		/// <summary>
		/// TaskCompletedTime
        /// </summary>		
		private DateTime _taskcompletedtime;
        public DateTime TaskCompletedTime
        {
            get{ return _taskcompletedtime; }
            set{ _taskcompletedtime = value; }
        }
        /// <summary>
        /// TaskCompletedTime
        /// </summary>		
        private decimal _taskBonus;
        public decimal TaskBonus
        {
            get { return _taskBonus; }
            set { _taskBonus = value; }
        }
    }
}

