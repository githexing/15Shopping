using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService.ViewModel
{
    public class TransferMachineListModel
    {
        public List<TransferMachineModel> list { set; get; }
        public int pageindex { set; get; }  //页码
        public int pagecount { set; get; } //总页数
        public int totalcount { set; get; } //总条数
    }

    public class TransferMachineModel
    {
        public long ID { get; set; }
        public int Number { get; set; }
        public string Remark { get; set; }
        public string TypeName { get; set; }
        public string TransferTime { get; set; }

    }
}