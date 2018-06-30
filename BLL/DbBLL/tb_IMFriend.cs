using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class tb_IMFriend
    {
        /// <summary>
        /// 得到好友ID
        /// </summary>
        public long GetID(long UserID, long FriendID)
        {
            return dal.GetID(UserID, FriendID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_IMFriend GetModel(long UserID, long FriendID)
        {
            return dal.GetModel(UserID, FriendID);
        }
        /// <summary>
        /// 好友列表
        /// </summary>
        public DataSet GetFriendList(long UserID)
        {
            return dal.GetFriendList(UserID);
        }
        /// <summary>
        /// 队友列表
        /// </summary>
        public DataSet GetTeamList(long UserID)
        {
            return dal.GetTeamList(UserID);
        }

        public DataSet GetListByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount)
        {
            return dal.GetListByPage(UserID, PageIndex, PageSize, out PageCount, out TotalCount);
        }

        public DataSet GetListPersonalByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount)
        {
            return dal.GetListPersonalByPage(UserID, PageIndex, PageSize, out PageCount, out TotalCount);
        }
        /// <summary>
        /// 评论
        /// </summary>
        /// <param name="DynamicID"></param>
        /// <returns></returns>
        public DataSet GetComment(long DynamicID)
        {
            return dal.GetComment(DynamicID);
        }
    }
}
