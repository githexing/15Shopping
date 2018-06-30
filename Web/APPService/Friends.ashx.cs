using Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// Friends 的摘要说明
    /// </summary>
    public class Friends : ServiceHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = string.Empty;

            string act = context.Request["act"];
            if (string.IsNullOrEmpty(act) || act.Trim() == string.Empty)
            {
                return;
            }
            switch (act.ToLower())
            {
                case "adddynamic"://发布动态
                    result = CircleFriends(context);
                    break;
                case "deldynamic"://删除发布动态
                    result = DeleteFriends(context);
                    break;
                case "dynamiclist"://朋友动态列表
                    result = Friendslist(context);
                    break;
                case "personallist"://个人动态列表
                    result = PersonalDynamicList(context);
                    break;
                case "review"://评论动态
                    result = ReviewFriends(context);
                    break;
                case "delreview"://删除评论动态
                    result = DeleteReviewFriends(context);
                    break;
                case "point"://点赞动态
                    result = PointDynamic(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常.", "Friends");
                    break;
            }
            context.Response.Write(result);
        }

        //朋友圈
        private string CircleFriends(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string dynamic = context.Request["dynamic"] ?? "";

            string dynamiccontext = HttpUtility.UrlEncode(dynamic);

            //LogHelper.SaveLog("dynamic:" + dynamic + ",stream:" + builder.ToString(), "dynamic");          
            
            string message = string.Empty;
            int _userid = 0;
            int.TryParse(userid,out _userid);
            string path;
            upload(context, "dynamic", out path);

            FriendsService svc = new FriendsService();
            var result = svc.Friends(_userid, dynamiccontext, path, out message);
            if (result)
            {
                return ResultJson(ResultType.success, "发送成功", "");
            }
            else
                return ResultJson(ResultType.error, "发送失败", "");
        }
        //朋友圈列表
        private string Friendslist(HttpContext context)
        {
            int pageSize = 10; //默认每页返回记录数
            int _pageindex;
            string message = string.Empty;

            string userid = context.Request["userid"] ?? "";
            string pageindex = context.Request["pageindex"] ?? "";//页索引
            //  string userid = context.Request["pagesize"] ?? "";//每页显示数

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "用户ID不能为空", "");
            }

            if (string.IsNullOrEmpty(pageindex))
            {
                return ResultJson(ResultType.error, "页索引不能为空","");
            }

            long _userid = 0;
            long.TryParse(userid, out _userid);
            int.TryParse(pageindex, out _pageindex);

            if (_pageindex <= 0) _pageindex = 1;

            LogHelper.SaveLog("开始获取朋友圈列表"+ userid, "dynamic");

            FriendsService svc = new FriendsService();
            var list = svc.MyDynamicList(_userid, _pageindex, pageSize);//我朋友的动态列表

            LogHelper.SaveLog("获取朋友圈列表完成"+ userid, "dynamic");
            return ResultJson(ResultType.success, message, list);
        }
        //个人动态列表
        private string PersonalDynamicList(HttpContext context)
        {
            int pageSize = 10; //默认每页返回记录数
            int _pageindex;
            string message = string.Empty;

            string userid = context.Request["userid"] ?? "";
            string pageindex = context.Request["pageindex"] ?? "";//页索引
            //  string userid = context.Request["pagesize"] ?? "";//每页显示数

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "用户ID不能为空", "");
            }

            if (string.IsNullOrEmpty(pageindex))
            {
                return ResultJson(ResultType.error, "页索引不能为空", "");
            }

            long _userid = 0;
            long.TryParse(userid, out _userid);
            int.TryParse(pageindex, out _pageindex);

            if (_pageindex <= 0) _pageindex = 1;

            FriendsService svc = new FriendsService();
            var list = svc.PersonalDynamicList(_userid, _pageindex, pageSize);//我朋友的动态列表

            return ResultJson(ResultType.success, message, list);
        }
        //删除发布动态
        private string DeleteFriends(HttpContext context)
        {
            string id = context.Request["dynamicid"] ?? "";
            string message = string.Empty;
            int _id = 0;
            int.TryParse(id, out _id);
         

            FriendsService FriendsSvc = new FriendsService();
            var Friends = FriendsSvc.DeleteDynamic(_id, out message);
            if (Friends)
            {
                return ResultJson(ResultType.success, "删除发布动态", "");
            }
            else
                return ResultJson(ResultType.error, message, "");

        }
        //评论动态
        private string ReviewFriends(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string touserid = context.Request["touserid"] ?? "";
            string dynamicid = context.Request["dynamicid"] ?? "";
            string content = context.Request["content"] ?? "";
            string message = string.Empty;
            long _userid = 0;
            long _touserid;
            int _dynamicid = 0;
            long commenID;

            long.TryParse(userid, out _userid);
            int.TryParse(dynamicid, out _dynamicid);
            long.TryParse(touserid, out _touserid);

            string dynamiccontext = HttpUtility.UrlEncode(content);

            //LogHelper.SaveLog("content:" + content + ",stream:" + builder.ToString(), "ReviewFriends");

            FriendsService svc = new FriendsService();
            var result = svc.ReviewTrends(_userid, _touserid,_dynamicid, dynamiccontext, out commenID, out message);
            if (result)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("commenID", commenID.ToString());
                return ResultJson(ResultType.success, "评论成功", dic);
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
        //删除评论动态
        private string DeleteReviewFriends(HttpContext context)
        {
            string id = context.Request["id"] ?? "";
            string userid = context.Request["userid"] ?? "";
            string message = string.Empty;
            int _id = 0;
            int.TryParse(id, out _id);
            int _userid = 0;
            int.TryParse(userid, out _userid);
           
            FriendsService FriendsSvc = new FriendsService();
            var Friends = FriendsSvc.DeleteReviewTrends(_id, _userid, out message);
            if (Friends)
            {
                return ResultJson(ResultType.success, "删除评论成功", "");
            }
            else
                return ResultJson(ResultType.error, message, "");

        }
        //点赞动态
        private string PointDynamic(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string dynamicid = context.Request["dynamicid"] ?? "";
            string message = string.Empty;
            int _userid = 0;
            int.TryParse(userid, out _userid);
            int _dynamicid = 0;
            int.TryParse(dynamicid, out _dynamicid);

            FriendsService FriendsSvc = new FriendsService();
            var Friends = FriendsSvc.PointDynamicNum(_userid, _dynamicid, out message);
            if (Friends)
            {
                return ResultJson(ResultType.success, message, "");
            }
            else
                return ResultJson(ResultType.error, message, "");

        }
    }
}