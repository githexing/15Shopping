using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class FriendsModel
    {
        public string ID { set; get; }
        public string UserID { set; get; }
        public string UserCode { set; get; }
        public string Name { set; get; }
        public string HeadPic { set; get; }
        public string Content { set; get; }
        public string Pic { set; get; }
        public string AddTime { set; get; }
        public string GoodNum { set; get; }
        public string CommentNum { set; get; }
        public string Good { set; get; }
        public List<FriendsCommentModel> Comment { set; get; }
    }

    public class FriendsCommentModel
    {
        public string CommentID { set; get; }
        public string ReName { set; get; }
        public string ReUserID { set; get; }
        public string ToName { set; get; }
        public string ToUserID { set; get; }
        public string Content { set; get; }
        public string AddTime { set; get; }
    }
}