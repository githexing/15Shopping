using System.Linq;
using System.Web;
using Library;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Data;
using Web.APPService.Service;
using Web.APPService.ViewModel;
using System;

namespace Web.APPService
{
    /// <summary>
    /// GetMoney 的摘要说明
    /// </summary>
    public class GetMoney : ServiceHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = string.Empty;

            result = GetSuanLiList(context);
            context.Response.Write(result);
        }

        public string GetSuanLiList(HttpContext context)
        {
            //string User = context.Request["UserID"];
            string UserCode = context.Request["UserCode"]; 
            
            if (string.IsNullOrEmpty(UserCode) || UserCode.Trim() == string.Empty)
            {
                return ResultJson(ResultType.error, "请输入用户账号", "");
            }
            AllCore AC = new AllCore();
            long  UserID = AC.userBLL.GetUserID(UserCode);
            if (UserID <= 0)
            {
                return ResultJson(ResultType.error, "账号不存在!", "");
            }
            var model = AC.userBLL.GetModel(UserID);
            GetModel getModel = new GetModel();
            getModel.Emoney = model.Emoney;
            getModel.StockMoney = model.StockMoney;
            getModel.BonusAccount = model.BonusAccount;
            getModel.AllBonusAccount = model.AllBonusAccount;
            getModel.User001 = model.User001; 
            return ResultJson(ResultType.success, "", getModel);
        }
        public class GetModel
        {
            public decimal Emoney { get; set; }
            public decimal StockMoney { get; set; }
            public decimal BonusAccount { get; set; }
            public decimal AllBonusAccount { get; set; }
            public int User001 { get; set; }//运营中心
           

        }

    }
}