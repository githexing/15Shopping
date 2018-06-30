using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    //tb_MachineDetail
    public class tb_MachineDetail
    {

        /// <summary>
        /// ID
        /// </summary>		
        private long _id;
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private long _userID;
        public long UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        /// <summary>
        /// BuyMachineID
        /// </summary>		
        private long _buymachineid;
        public long BuyMachineID
        {
            get { return _buymachineid; }
            set { _buymachineid = value; }
        }
        /// <summary>
        /// MachineNo
        /// </summary>		
        private string _machineno;
        public string MachineNo
        {
            get { return _machineno; }
            set { _machineno = value; }
        }
        /// <summary>
        /// BuyTime
        /// </summary>		
        private DateTime _buytime;
        public DateTime BuyTime
        {
            get { return _buytime; }
            set { _buytime = value; }
        }
        /// <summary>
        /// ActiveTime
        /// </summary>		
        private DateTime? _activetime;
        public DateTime? ActiveTime
        {
            get { return _activetime; }
            set { _activetime = value; }
        }
        /// <summary>
        /// IsActive
        /// </summary>		
        private int _isactive;
        public int IsActive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }
        /// <summary>
        /// TransferTime
        /// </summary>		
        private DateTime? _transfertime;
        public DateTime? TransferTime
        {
            get { return _transfertime; }
            set { _transfertime = value; }
        }
        /// <summary>
        /// IsTransfer
        /// </summary>		
        private int _istransfer;
        public int IsTransfer
        {
            get { return _istransfer; }
            set { _istransfer = value; }
        }

    }
}

