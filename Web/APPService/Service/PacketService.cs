using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library;
using System.Data;

namespace Web.APPService.Service
{
    public class PacketService :AllCore
    {
        private lgk.BLL.tb_PacketSend packSendBll = new lgk.BLL.tb_PacketSend();

        public bool PacketSend(long UserID, decimal Amount, int Number, string LeaveMessage,int type,string paypassword, out string message)
        {
            var user = userBLL.GetModel(UserID);
            if (user == null)
            {
                message = "账号不存在";
                return false;
            }
            
            if (!ValidPassword(user.SecondPassword, paypassword))
            {
                message = "支付密码错误";
                return false;
            }

            if (user.IsLock == 1)
            {
                message = "账户已冻结，发红包失败";
                return false;
            }
            int result = packSendBll.PacketSend(UserID, Amount, Number, LeaveMessage,type);

            if (result > 0)
            {
                string strSendID = result.ToString();
                decimal len = result.ToString().Length;
                
                if ((len % 16) != 0)
                {
                    decimal y = len / 16;
                    decimal b = Math.Ceiling(y);
                    int p = Convert.ToInt32(b * 16);
                    strSendID = result.ToString().PadRight(p);
                }
                message = AESEncrypt.Encrypt(strSendID);
                return true;
            }
            if (result == -1)
            {
                message = "账户余额不足";
                return false;
            }
            else if (result == -2)
            {
                message = "红包金额太小了";
                return false;
            }
            else
            {
                message = "发红包失败";
                return false;
            }
        }

        public object PacketReceive(long UserID,long PacketID,int type, out string message)
        {
            message = "已过期";
            int result = -1;
            var model = packSendBll.GetModel(PacketID);

            if (type == 2 || model.UserID != UserID)//群聊
            {
                result = packSendBll.PacketReceive(UserID, PacketID);

                if (result == 0)
                {
                    message = "已获取";
                }
                else if (result == 1)
                {
                    message = "已被抢完";
                }
                else if (result == 2)
                {
                    message = "领取成功";
                }
                else
                {
                    message = "领取红包失败";
                }
            }

            
            if(type == 1 && model.UserID == UserID)
            {
                if(model.Amount - model.ReceiveMoney  == 0)
                {
                    result = 0;
                    message = "已获取";
                }
                else
                {
                    result = 4;
                    message = "未领取";
                }
            }
            var user = userBLL.GetModel(model.UserID);
            if (user.IsLock == 1)
            {
                message = "账户已冻结，收红包失败";
                return false;
            }

            ReceivePacketModel packetModel = new ReceivePacketModel();
            packetModel.OrderCode = model.OrderCode;
            packetModel.SendNiceName = user.NiceName;
            packetModel.SendUserCode = user.UserCode;
            packetModel.Amount = model.Amount.ToString();
            packetModel.LeaveMessage = model.LeaveMessage;
            packetModel.SendHeadPic = user.User009 == null || user.User009 == ""? "":WebHelper.HttpDomain + user.User009;
            packetModel.ReceiveList = GetReceiveLsit(UserID, PacketID);

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("state", result);
            dic.Add("message", message);
            dic.Add("packetinfo", packetModel);

            return dic;
        }

        private List<ReceivePacketListModel> GetReceiveLsit(long UserID,long PacketID)
        {
            lgk.BLL.tb_PacketReceive recBll = new lgk.BLL.tb_PacketReceive();
            DataSet ds = recBll.GetReceiveList(UserID, PacketID);
            return ReceivePacketList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ReceivePacketListModel> ReceivePacketList(DataTable dt)
        {
            List<ReceivePacketListModel> modelList = new List<ReceivePacketListModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ReceivePacketListModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ReceivePacketListModel();
                    if (dt.Rows[n]["ReceiveUserCode"] != null && dt.Rows[n]["ReceiveUserCode"].ToString() != "")
                    {
                        model.ReceiveUserCode = dt.Rows[n]["ReceiveUserCode"].ToString();
                    }
                    if (dt.Rows[n]["ReceiveNiceName"] != null && dt.Rows[n]["ReceiveNiceName"].ToString() != "")
                    {
                        model.ReceiveNiceName = dt.Rows[n]["ReceiveNiceName"].ToString();
                    }
                    if (dt.Rows[n]["Amount"] != null && dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = dt.Rows[n]["Amount"].ToString();
                    }
                    if (dt.Rows[n]["ReceiveTime"] != null && dt.Rows[n]["ReceiveTime"].ToString() != "")
                    {
                        model.ReceiveTime = DateTime.Parse(dt.Rows[n]["ReceiveTime"].ToString()).ToString("hh:mm");
                    }
                    model.ReceiveHeadPic = dt.Rows[n]["HeadPic"] == null || dt.Rows[n]["HeadPic"].ToString() == "" ? "" : WebHelper.HttpDomain + dt.Rows[n]["HeadPic"].ToString();

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public object PacketList(long UserID)
        {
            //Journal02 ，1：红包类别标识
            var list = journalBLL.GetModelList(string.Format("j.userid={0} and JournalType = 1 and Journal02 = 1",  UserID ));

            return list.Select(s => new {
                Explain = s.InAmount > 0 ? "收红包" : "发红包",
                Amount = s.InAmount > 0 ? s.InAmount : 0 - s.OutAmount,
                PacketTime = s.JournalDate.ToString("yyyy-MM-dd HH:mm")
            }).OrderByDescending(o=>o.PacketTime).ToList();
        }
    }
}