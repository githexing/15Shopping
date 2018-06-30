using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    //tb_FriendDynamic
    public class tb_FriendDynamic
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
        /// Content
        /// </summary>		
        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// Pic
        /// </summary>		
        private string _pic;
        public string Pic
        {
            get { return _pic; }
            set { _pic = value; }
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
        /// GoodNum
        /// </summary>		
        private int _goodnum;
        public int GoodNum
        {
            get { return _goodnum; }
            set { _goodnum = value; }
        }
        /// <summary>
        /// CommentNum
        /// </summary>		
        private int _commentnum;
        public int CommentNum
        {
            get { return _commentnum; }
            set { _commentnum = value; }
        }

    }
}

