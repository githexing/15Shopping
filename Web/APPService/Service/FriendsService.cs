using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Web.APPService.Service
{
    public class FriendsService : AllCore
    {
        //发表动态
        public bool Friends(long userid, string dynamic, string path,  out string message)
        {
            if (FriendsValidate(userid, dynamic, path, out message))
            {

                lgk.Model.tb_user userInfo = userBLL.GetModel(userid);

                lgk.Model.tb_FriendDynamic friend = new lgk.Model.tb_FriendDynamic()

                {
                    UserID = userid,
                    Content = dynamic.Trim(),
                    Pic = path.Trim(),
                    AddTime = DateTime.Now,
                    GoodNum = 0,
                    CommentNum = 0,
                };
               
                if (friendBLL.Add(friend) > 0)
                {
                    
                    message = "发送成功";
                    return true;
                }
                else
                {
                    message = "发送失败";
                    return false;
                }
            }
            else
                return false;
        }

        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        private bool FriendsValidate(long userid, string dynamic, string path,  out string message)
        {
            lgk.Model.tb_FriendDynamic friendsInfo = new lgk.Model.tb_FriendDynamic();
            if (dynamic.Trim() == "")
            {
                message = "动态内容不能为空";
                return false;
            }

            message = "";
            return true;
        }
        //删除发布动态
        public bool DeleteDynamic(long id, out string message)
        {
            friendBLL.Delete(id);
            message = "删除发布动态";
            return true;

        }
        //发表动态列表
        public List<FriendsModel>DynamicList(long  userid)
        {
            string strWhere1 = "userid =" + userid;

            var dt = friendBLL.GetList(strWhere1);

            return FriendsList(dt.Tables[0]);
        }

        //我的朋友动态
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public Dictionary<string, object> MyDynamicList(long UserID, int PageIndex, int PageSize )
        {
            int PageCount;
            int TotalCount;

            lgk.BLL.tb_IMFriend dynamicBll = new lgk.BLL.tb_IMFriend();

            //PageCount 总页数
            //TotalCount 总记录数
            var ds = dynamicBll.GetListByPage(UserID, PageIndex, PageSize, out PageCount, out TotalCount);

            //动态列表
            var dynamicList = FriendsList(ds.Tables[0]);
 
            //添加评论
            foreach(var item in dynamicList)
            {
                item.Comment = CommentList(long.Parse(item.ID));
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("pagecount", PageCount.ToString());
            dic.Add("totalcount", TotalCount.ToString());
            dic.Add("list", dynamicList);

            return dic;
        }
        //
        /// <summary>
        /// 个人动态列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public Dictionary<string, object> PersonalDynamicList(long UserID, int PageIndex, int PageSize)
        {
            int PageCount;
            int TotalCount;

            lgk.BLL.tb_IMFriend dynamicBll = new lgk.BLL.tb_IMFriend();

            //PageCount 总页数
            //TotalCount 总记录数
            var ds = dynamicBll.GetListPersonalByPage(UserID, PageIndex, PageSize, out PageCount, out TotalCount);

            //动态列表
            var dynamicList = FriendsList(ds.Tables[0]);

            //添加评论
            foreach (var item in dynamicList)
            {
                item.Comment = CommentList(long.Parse(item.ID));
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("pagecount", PageCount.ToString());
            dic.Add("totalcount", TotalCount.ToString());
            dic.Add("list", dynamicList);

            return dic;
        }
        public List<FriendsCommentModel> CommentList(long dynamicID)
        {
            lgk.BLL.tb_IMFriend dynamicBll = new lgk.BLL.tb_IMFriend();

            var dt = dynamicBll.GetComment(dynamicID);

            return CommentList(dt.Tables[0]);
        }

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FriendsModel> FriendsList(DataTable dt)
        {
            List<FriendsModel> modelList = new List<FriendsModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FriendsModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new FriendsModel();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = dt.Rows[n]["ID"].ToString();
                    }
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = dt.Rows[n]["UserID"].ToString();
                    }
                    if (dt.Rows[n]["UserCode"] != null && dt.Rows[n]["UserCode"].ToString() != "")
                    {
                        model.UserCode = dt.Rows[n]["UserCode"].ToString();
                    }
                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = HttpUtility.UrlDecode(dt.Rows[n]["Content"].ToString(), System.Text.Encoding.UTF8);
                    }
                    model.Name = dt.Rows[n]["NiceName"] == null || dt.Rows[n]["NiceName"].ToString() == "" ? "" : dt.Rows[n]["NiceName"].ToString();
                    model.HeadPic = dt.Rows[n]["HeadPic"] == null || dt.Rows[n]["HeadPic"].ToString() == "" ? "" : WebHelper.HttpDomain + dt.Rows[n]["HeadPic"].ToString();
                    model.Pic = dt.Rows[n]["Pic"] == null || dt.Rows[n]["Pic"].ToString() == "" ? "" : WebHelper.HttpDomain + dt.Rows[n]["Pic"].ToString();

                    if (dt.Rows[n]["AddTime"] != null && dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = dt.Rows[n]["AddTime"].ToString();
                    }
                    if (dt.Rows[n]["GoodNum"] != null && dt.Rows[n]["GoodNum"].ToString() != "")
                    {
                        model.GoodNum = dt.Rows[n]["GoodNum"].ToString();
                    }
                    if (dt.Rows[n]["CommentNum"] != null && dt.Rows[n]["CommentNum"].ToString() != "")
                    {
                        model.CommentNum = dt.Rows[n]["CommentNum"].ToString();
                    }
                    if (dt.Rows[n]["Good"] != null && dt.Rows[n]["Good"].ToString() != "")
                    {
                        model.Good = dt.Rows[n]["Good"].ToString();
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FriendsCommentModel> CommentList(DataTable dt)
        {
            List<FriendsCommentModel> modelList = new List<FriendsCommentModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FriendsCommentModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new FriendsCommentModel();
                    
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.CommentID = dt.Rows[n]["ID"].ToString();
                    }
                    if (dt.Rows[n]["ReName"] != null && dt.Rows[n]["ReName"].ToString() != "")
                    {
                        model.ReName = dt.Rows[n]["ReName"].ToString();
                    }
                    else
                        model.ReName = dt.Rows[n]["ReUserCode"].ToString();

                    model.ReUserID = dt.Rows[n]["ReUserID"] == null ? "" : dt.Rows[n]["ReUserID"].ToString();
                    model.ToUserID = dt.Rows[n]["ToUserID"] == null ? "" : dt.Rows[n]["ToUserID"].ToString();
                    model.ToName = dt.Rows[n]["ToName"] == null ? "" : dt.Rows[n]["ToName"].ToString();

                    if (dt.Rows[n]["Content"] != null && dt.Rows[n]["Content"].ToString() != "")
                    {
                        model.Content = HttpUtility.UrlDecode(dt.Rows[n]["Content"].ToString(), System.Text.Encoding.UTF8); 
                    }
                  
                    if (dt.Rows[n]["AddTime"] != null && dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = dt.Rows[n]["AddTime"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        //评论动态
        public bool ReviewTrends(long userid,long touserid, long dynamicid, string content,out long commenID, out string message)
        {
            commenID = 0;
            if (ReviewTrendsValidate(userid, dynamicid, content, out message))
            {

                var userModel = userBLL.GetModel(userid);
                var frienddynamic = friendBLL.GetModel(dynamicid);
                if (userModel == null)
                {
                    message = "用户ID不存在";
                    return false;
                }
                if (frienddynamic == null)
                {

                    message = "评论用户ID不存在";
                    return false;
                }

                lgk.Model.tb_FriendDynamicComment friendDynam = new lgk.Model.tb_FriendDynamicComment()
                {
                    UserID = userid,
                    DynamicID = dynamicid,
                    Content = content.Trim(),
                    AddTime = DateTime.Now,
                    ToUserID = touserid
                };
                commenID = friendDynamicCommenBLL.Add(friendDynam);
                if (commenID > 0)
                {
                    UpdateFriendDynamic("CommentNum", dynamicid, 1, 1);
                    message = "评论成功";
                    return true;
                }
                else
                {
                    message = "评论失败";
                    return false;
                }
            }

            else
                return false;
        }
        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        private bool ReviewTrendsValidate(long userid, long dynamicid, string content, out string message)
        {
           
            if (content.Trim() == "")
            {
                message = "请输入评论内容";
                return false;
            }

            message = "";
            return true;
        }
        //删除评论动态
        public bool DeleteReviewTrends(long id, long userid, out string message)
        {
            //lgk.Model.tb_FriendDynamic frienddynamic = friendBLL.GetModel(userid);
            var commenList = friendDynamicCommenBLL.GetModelList("userid = " + userid + " and id=" + id);

            if (commenList.Count == 0)
            {
                message = "评论不存在";
                return false;
            }

            friendDynamicCommenBLL.Delete(id);
            UpdateFriendDynamic("CommentNum", commenList.First().DynamicID, 1, 0);
            message = "删除评论成功";
            return true;

        }
        //点赞动态
        public bool PointDynamicNum(long userid, long dynamicid,  out string message)
        {
            var dygoodList = FriendDynamicGoodBLL.GetModelList("userid = " + userid + " and dynamicid=" + dynamicid);

            if (dygoodList.Count > 0)
            {
                FriendDynamicGoodBLL.Delete(dygoodList.First().ID);
                UpdateFriendDynamic("GoodNum", dygoodList.First().DynamicID, 1, 0);
                message = "取消点赞";
                return true;
            }

            lgk.Model.tb_FriendDynamicGood friendDynamGood = new lgk.Model.tb_FriendDynamicGood()
            {
                UserID = userid,
                DynamicID = dynamicid,
                AddTime = DateTime.Now,

            };

            if (FriendDynamicGoodBLL.Add(friendDynamGood) > 0)
            {
                UpdateFriendDynamic("GoodNum", dynamicid, 1, 1);
                message = "点赞成功";
                return true;
            }
            else
            {
                message = "点赞失败";
                return false;
            }

        }
       
    }
}