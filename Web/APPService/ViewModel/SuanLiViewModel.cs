using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService.ViewModel
{
    public class SuanLiListModel
    {
        public List<SuanLiModel> NotesList { get; set; }
        public int CountPage { get; set; }
    }
    public class SuanLiModel
    {
        public decimal SuanLi { get; set; }
        public decimal Total { get; set; }
        public string Suanli_Type { get; set; }
        public string Remark { get; set; }
        public string Time { get; set; }
    }
}