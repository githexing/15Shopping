using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class BankModel
    {
        public string BankID { set; get; }
        public string BankName { set; get; }
        public string BankAccount { set; get; }
        public string BankAccountUser { set; get; }
        public string BankAddress { set; get; }
        public string MasterType { set; get; }
        public string AccountType { set; get; }
        public string Pic { set; get; }
    }
    
    #region 银行类别
    public class BankTypeListModel
    {
        public List<BankTypeModel> list { get; set; }
        public List<lgk.Model.tb_bankName> bankList { get; set; }
        public List<lgk.Model.tb_province> provinceList { get; set; }
        public List<BankModel> userbankList { get; set; }
    }

    public class BankTypeModel
    {
        public int AccountType { get; set; }
        public string AccountTypeName { get; set; }
    } 
    #endregion
    
}