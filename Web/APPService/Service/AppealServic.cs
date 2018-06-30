using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Web.APPService.Service
{
    public class AppealServic : AllCore
    {
        public bool Appeal(long userid, int type, string content, string picpath, out string message)
        {
            lgk.Model.tb_user userInfo = userBLL.GetModel(userid);
            lgk.Model.tb_leaveMsg leaveMsg = new lgk.Model.tb_leaveMsg()
            {
                MsgTitle = "",
                MsgContent = content.Trim(),
                LeaveTime = DateTime.Now,
                IsRead = 0,
                IsReply = 0,
                FromUserType = 1,
                UserID = userid,
                UserCode = userInfo.UserCode,
                FromIDIsDel = 0,
                ToIDIsDel = 0,
                ToUserID = 1,
                ToUserType = 2,
                ToUserCode = "admin",
                MsgType = type,
                Pic = picpath
            };
            if (leaveMsgBLL.Add(leaveMsg) > 0)
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
        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        private bool AppealValidate(long userid, string usercode, string content, out string message)
        {

            if (content.Trim() == "")
            {
                message = "申诉内容不能为空";
            }
            message = "";
            return true;
        }

        public List<MsgRecordModel> AppealList(long userid,int _type)
        {
            var ds = leaveMsgBLL.GetRecordList("userid = " + userid +" and msgtype = "+ _type);
            return DataTableToList(ds.Tables[0]);
        }

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MsgRecordModel> DataTableToList(DataTable dt)
        {
            List<MsgRecordModel> modelList = new List<MsgRecordModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MsgRecordModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new MsgRecordModel();
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = dt.Rows[n]["UserID"].ToString();
                    }
                    if (dt.Rows[n]["MsgContent"] != null && dt.Rows[n]["MsgContent"].ToString() != "")
                    {
                        model.MsgContent = dt.Rows[n]["MsgContent"].ToString();
                    }
                    model.ReContent = dt.Rows[n]["ReContent"].ToString();
                    model.ReTime = dt.Rows[n]["ReTime"].ToString();

                    if (dt.Rows[n]["LeaveTime"] != null && dt.Rows[n]["LeaveTime"].ToString() != "")
                    {
                        model.LeaveTime = DateTime.Parse(dt.Rows[n]["LeaveTime"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
    }
}