using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService.Service
{
    public class LogService
    {
        //经纬度，mac，手机版本，手机品牌，手机系统
        public bool Record(long _userid, string longitude, string mac, string version, string brand, string system)
        {
            lgk.BLL.tb_user userbll = new lgk.BLL.tb_user();
            var user = userbll.GetModel(_userid);
            if(user == null)
            {
                LogHelper.SaveLog("userid:"+ _userid +" 不存在", "applog");
                return false;
            }

            lgk.Model.AppLog model = new lgk.Model.AppLog()
            {
                UserID = _userid,
                UserCode = user.UserCode,
                UserName = user.NiceName,
                Mobile = user.PhoneNum,
                Longitude = longitude,
                MAC = mac,
                PhoneVersion = version,
                PhoneBrand = brand,
                PhoneSystem = system,
                AddTime = DateTime.Now
            };

            lgk.BLL.AppLog logbll = new lgk.BLL.AppLog();
            logbll.Add(model);

            return true;
        }
    }
}