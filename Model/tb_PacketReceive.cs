using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    //tb_PacketReceive
    public class tb_PacketReceive
    {

        /// <summary>
        /// ReceiveID
        /// </summary>		
        private long _receiveid;
        public long ReceiveID
        {
            get { return _receiveid; }
            set { _receiveid = value; }
        }
        /// <summary>
        /// PackID
        /// </summary>		
        private long _packid;
        public long PackID
        {
            get { return _packid; }
            set { _packid = value; }
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
        /// ReceiveFlag
        /// </summary>		
        private int _receiveflag;
        public int ReceiveFlag
        {
            get { return _receiveflag; }
            set { _receiveflag = value; }
        }
        /// <summary>
        /// ReceiveUserID
        /// </summary>		
        private long _receiveuserid;
        public long ReceiveUserID
        {
            get { return _receiveuserid; }
            set { _receiveuserid = value; }
        }
        /// <summary>
        /// ReceiveTime
        /// </summary>		
        private DateTime _receivetime;
        public DateTime ReceiveTime
        {
            get { return _receivetime; }
            set { _receivetime = value; }
        }
        /// <summary>
        /// CancelTime
        /// </summary>		
        private DateTime _canceltime;
        public DateTime CancelTime
        {
            get { return _canceltime; }
            set { _canceltime = value; }
        }

    }
}

