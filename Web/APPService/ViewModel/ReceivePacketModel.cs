using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
//    发红包人账号，总金额，留言
//SendUserCode, SendNiceName, Amount, LeaveMessage

//获得红包账号，时间，金额
//ReceiveUserCode, ReceiveNiceName, Amount, ReceiveTime

    public class ReceivePacketModel
    {
        public string OrderCode { set; get; }
        public string SendUserCode { set; get; }
        public string SendNiceName { set; get; }
        public string SendHeadPic { set; get; }
        public string Amount { set; get; }
        public string LeaveMessage { set; get; }
        public List<ReceivePacketListModel> ReceiveList { set; get; }
    }

    public class ReceivePacketListModel
    {
        public string ReceiveUserCode { set; get; }
        public string ReceiveNiceName { set; get; }
        public string ReceiveHeadPic { set; get; }
        public string Amount { set; get; }
        public string ReceiveTime { set; get; }
    }
}