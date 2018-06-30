using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    //tb_PacketSend
    public class tb_PacketSend
    {

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
        /// UserID
        /// </summary>		
        private long _userid;
        public long UserID
        {
            get { return _userid; }
            set { _userid = value; }
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
        /// Number
        /// </summary>		
        private int _number;
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        /// <summary>
        /// LeaveMessage
        /// </summary>		
        private string _leavemessage;
        public string LeaveMessage
        {
            get { return _leavemessage; }
            set { _leavemessage = value; }
        }
        /// <summary>
        /// SendTime
        /// </summary>		
        private DateTime _sendtime;
        public DateTime SendTime
        {
            get { return _sendtime; }
            set { _sendtime = value; }
        }
        /// <summary>
        /// ReceiveNum
        /// </summary>		
        private int _receivenum;
        public int ReceiveNum
        {
            get { return _receivenum; }
            set { _receivenum = value; }
        }
        /// <summary>
        /// ReceiveMoney
        /// </summary>		
        private decimal _receivemoney;
        public decimal ReceiveMoney
        {
            get { return _receivemoney; }
            set { _receivemoney = value; }
        }
        /// <summary>
        /// OrderCode
        /// </summary>		
        private string _orderCode;
        public string OrderCode
        {
            get { return _orderCode; }
            set { _orderCode = value; }
        }

    }
}

