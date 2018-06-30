using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    //tb_FriendDynamicComment
    public class tb_FriendDynamicComment
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
        private long _touserid;
        public long ToUserID
        {
            get { return _touserid; }
            set { _touserid = value; }
        }
        /// <summary>
        /// DynamicID
        /// </summary>		
        private long _dynamicid;
        public long DynamicID
        {
            get { return _dynamicid; }
            set { _dynamicid = value; }
        }
        /// <summary>
        /// Content
        /// </summary>		
        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
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

