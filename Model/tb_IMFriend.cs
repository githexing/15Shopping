using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    //tb_IMFriend
    public class tb_IMFriend
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
        /// UserCode
        /// </summary>		
        private string _usercode;
        public string UserCode
        {
            get { return _usercode; }
            set { _usercode = value; }
        }
        /// <summary>
        /// FriendCode
        /// </summary>		
        private string _friendcode;
        public string FriendCode
        {
            get { return _friendcode; }
            set { _friendcode = value; }
        }
        /// <summary>
        /// FriendID
        /// </summary>		
        private long _friendid;
        public long FriendID
        {
            get { return _friendid; }
            set { _friendid = value; }
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

    }
}

