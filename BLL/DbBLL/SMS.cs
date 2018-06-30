using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class SMS
    {
        /// <summary>
        /// 获取当天发短信数量
        /// </summary>
        public long GetSendCountOfDay(string phone)
        {
            return dal.GetSendCountOfDay(phone);
        }

        /// <summary>
        /// 获取设定的分钟数内发短信数量
        /// </summary>
        public long GetSendCountOfMinute(string phone, int minute)
        {
            return dal.GetSendCountOfMinute(phone, minute);
        }
    }
}
