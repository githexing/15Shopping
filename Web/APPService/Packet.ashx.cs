using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// Packet 的摘要说明
    /// </summary>
    public class Packet : ServiceHandler
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
                case "send"://发红包
                    result = PacketSend(context);
                    break;
                case "receive"://收红包
                    result = PacketReceive(context);
                    break;
                case "list"://记录
                    result = PacketList(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常.", "Packet");
                    break;
            }
            context.Response.Write(result);
        }

        private string PacketList(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";

            if (string.IsNullOrEmpty(userid))
                return ResultJson(ResultType.error, "用户ID不能为空", "");

            long _userid = 0;
            long.TryParse(userid, out _userid);

            PacketService svc = new PacketService();
            var result = svc.PacketList(_userid);
            return ResultJson(ResultType.success, "ok", result);
        }

        private string PacketReceive(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string packetkey = context.Request["packetkey"] ?? "";
            string type = context.Request["type"] ?? "";

            string message = string.Empty;

            if (string.IsNullOrEmpty(userid))
                return ResultJson(ResultType.error, "用户ID不能为空", "");

            if (string.IsNullOrEmpty(packetkey))
                return ResultJson(ResultType.error, "请输入红包key", "");

            if (string.IsNullOrEmpty(type))
                return ResultJson(ResultType.error, "红包类型不能为空", "");

            int _type = 0;
            int.TryParse(type, out _type);

            if (!(_type == 1 || _type == 2))
                return ResultJson(ResultType.error, "红包类型无效", "");

            long _userid = 0;
            long _receiveid = 0;
            long.TryParse(userid, out _userid);

            string receiveid;

            try
            {
                receiveid = AESEncrypt.Decrypt(packetkey);
            }
            catch(Exception ex)
            {
                LogHelper.SaveLog("PacketReceive" + ex.ToString(), "packet");
                return ResultJson(ResultType.error, "红包KEY无效", "");
            }

            long.TryParse(receiveid, out _receiveid);
            LogHelper.SaveLog(string.Format("PacketReceive -> userid:{0},receiveid:{1},type:{2}", _userid, _receiveid,_type), "packet");
            PacketService svc = new PacketService();
            var result = svc.PacketReceive(_userid, _receiveid, _type, out message);

            return ResultJson(ResultType.success, "ok", result);

        }

        private string PacketSend(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string amount = context.Request["amount"] ?? "";
            string number = context.Request["number"] ?? "";
            string leave = context.Request["message"] ?? "";
            string type = context.Request["type"] ?? "";
            string paypassword = context.Request["paypassword"] ?? "";

            string message = string.Empty;

            if (string.IsNullOrEmpty(userid))
                return ResultJson(ResultType.error, "用户ID不能为空", "");

            if (string.IsNullOrEmpty(amount))
                return ResultJson(ResultType.error, "请输入红包金额", "");

            if (string.IsNullOrEmpty(number))
                return ResultJson(ResultType.error, "请输入红包个数", "");

            if (string.IsNullOrEmpty(leave))
                return ResultJson(ResultType.error, "请输入留言", "");

            if (string.IsNullOrEmpty(type))
                return ResultJson(ResultType.error, "红包类型不能为空", "");

            if (string.IsNullOrEmpty(paypassword))
                return ResultJson(ResultType.error, "请输入支付密码", "");

            long _userid = 0;
            decimal _amount = 0;
            int _number = 0;


            int _type = 0;
            int.TryParse(type, out _type);

            if (!(_type == 1 || _type == 2))
                return ResultJson(ResultType.error, "红包类型无效", "");

            long.TryParse(userid, out _userid);
            decimal.TryParse(amount, out _amount);
            int.TryParse(number, out _number);

            if (_amount <= 0)
                return ResultJson(ResultType.error, "请输入红包金额", "");

            if (_number <= 0) _number = 1;
            if(_type == 1) _number = 1;

            PacketService svc = new PacketService();
            var result = svc.PacketSend(_userid, _amount, _number, leave, _type, paypassword,out message);
            if (result)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("PacketKey", message);

                return ResultJson(ResultType.success,"发红包成功" , dic);
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
    }
}