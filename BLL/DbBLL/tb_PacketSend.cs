using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class tb_PacketSend
    {

        public int PacketSend(long UserID, decimal Amount, int Number, string LeaveMessage,int type)
        {
            return dal.PacketSend(UserID, Amount, Number, LeaveMessage,type);
        }
        public int PacketReceive(long UserID, long ReceiveID)
        {
            return dal.PacketReceive(UserID, ReceiveID);
        }
    }
}
