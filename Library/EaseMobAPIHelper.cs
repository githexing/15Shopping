using HXComm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public class EaseMobAPIHelper
    {
        private EaseMobAPI _myEaseMobApi;

        public EaseMobAPIHelper()
        {
            string appClientID = ConfigHelper.GetConfigString("appClientID");
            string appClientSecret = ConfigHelper.GetConfigString("appClientSecret");
            string appName = ConfigHelper.GetConfigString("appName");
            string orgName = ConfigHelper.GetConfigString("orgName");
            _myEaseMobApi = new EaseMobAPI(appClientID, appClientSecret, appName, orgName);
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="password">密码</param>
        /// <returns>创建成功的用户JSON</returns>
        public string AccountCreate(string userName, string password,out int statusCode)
        {
            return _myEaseMobApi.AccountCreate(userName, password, out  statusCode);
        }
        /// <summary>
        /// 获取 IM 用户
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="password">密码</param>
        /// <returns>创建成功的用户JSON</returns>
        public string AccountGetList(string userName, string password, out int statusCode)
        {
            return _myEaseMobApi.AccountList(userName, password, out statusCode);
        }
        /// <summary>
        /// 添加 IM 用户的好友关系
        /// </summary>
        /// <param name="userName">要添加好友的用户名</param>
        /// <param name="friend_username">被添加好友的用户名</param>
        /// <returns>成功返回会员JSON详细信息，失败直接返回：系统错误信息</returns>
        public string AccountAddFriend(string userName, string friend_username, out int statusCode)
        {
            return _myEaseMobApi.AccountAddFriend(userName, friend_username, out  statusCode);
        }

        /// <summary>
        /// 解除 IM 用户的好友关系
        /// </summary>
        /// <param name="userName">要删除好友的用户名</param>
        /// <param name="friend_username">被删除好友的用户名</param>
        /// <returns>成功返回会员JSON详细信息，失败直接返回：系统错误信息</returns>
        public string AccountDelFriend(string userName, string friend_username, out int statusCode)
        {
            return _myEaseMobApi.AccountDelFriend(userName, friend_username, out  statusCode);
        }

        /// <summary>
        /// 获取 IM 用户的好友关系
        /// </summary>
        /// <param name="userName">要添加好友的用户名</param>
        /// <param name="friend_username">被添加好友的用户名</param>
        /// <returns>成功返回会员JSON详细信息，失败直接返回：系统错误信息</returns>
        public string AccountGetFriend(string userName, out int statusCode)
        {
            return _myEaseMobApi.AccountGetFriend(userName, out statusCode);
        }

        /// <summary>
        /// 批量删除用户
        /// </summary>
        public string AccountDelUser(int limit, out int statusCode)
        {
            return _myEaseMobApi.AccountDelUser(limit, out statusCode);
        }
    }

}
