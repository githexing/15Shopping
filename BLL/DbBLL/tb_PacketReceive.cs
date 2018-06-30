using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class tb_PacketReceive
    {
        public DataSet GetReceiveList(long UserID, long PackID)
        {
            return dal.GetReceiveList(UserID, PackID);
        }

    }
}
