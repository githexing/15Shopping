using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class tb_user
    {
        private lgk.DAL.tb_user dalUser = new DAL.tb_user();
        /// <summary>
        /// 根据编号获取ID
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        //public int GetUserID(string UserCode)
        //{
        //    return dal.GetUserID(UserCode);
        //}


        /// <summary>
        /// 根据给邀请码，获取用户ID
        /// </summary>
        /// <param name="PhoneNum"></param>
        /// <returns></returns>
        public long GetUserIDByInviteCode(string invitecode)
        {
            return dal.GetUserIDByInviteCode(invitecode);
        }
    }
}
