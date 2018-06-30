using System;
namespace lgk.Model
{
    //tb_OrderInvest
    public class tb_OrderInvest
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
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
        /// OrderCode
        /// </summary>		
        private string _ordercode;
        public string OrderCode
        {
            get { return _ordercode; }
            set { _ordercode = value; }
        }
        /// <summary>
        /// AccountType
        /// </summary>		
        private int _accounttype;
        public int AccountType
        {
            get { return _accounttype; }
            set { _accounttype = value; }
        }
        /// <summary>
        /// InvestType
        /// </summary>		
        private int _investtype;
        public int InvestType
        {
            get { return _investtype; }
            set { _investtype = value; }
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
        /// AddTime
        /// </summary>		
        private DateTime _addtime;
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// OutType
        /// </summary>		
        private int _outtype;
        public int OutType
        {
            get { return _outtype; }
            set { _outtype = value; }
        }
        /// <summary>
        /// OutTime
        /// </summary>		
        private DateTime _outtime;
        public DateTime OutTime
        {
            get { return _outtime; }
            set { _outtime = value; }
        }
        /// <summary>
        /// GetDays
        /// </summary>		
        private int _getdays;
        public int GetDays
        {
            get { return _getdays; }
            set { _getdays = value; }
        }
        /// <summary>
        /// GetInterest
        /// </summary>		
        private decimal _getinterest;
        public decimal GetInterest
        {
            get { return _getinterest; }
            set { _getinterest = value; }
        }
        /// <summary>
        /// GetInterest
        /// </summary>		
        private decimal _releasedPhase;
        public decimal ReleasedPhase
        {
            get { return _releasedPhase; }
            set { _releasedPhase = value; }
        }
    }
}

