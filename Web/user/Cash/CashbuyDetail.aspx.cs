using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.user.Cash
{
    public partial class CashbuyDetail : PageCore
    {
        /// <summary>
        /// 登录用户编号
        /// </summary>
        private long iUserID = 0;

        /// <summary>
        /// EP币销售ID
        /// </summary>
        private long iCashsellID = 0;
        private long iCashbuyID = 0;
        public string BagAddress { set; get; }

        protected void Page_Load(object sender, EventArgs e)
        {
          

            iUserID = getLoginID();

            //btnBack.Text = GetLanguage("Return");//返 回

            if (Request["CashsellID"] != null && Request["CashsellID"].Length > 0)
            {
                if (PageValidate.IsLong(Request["CashsellID"]))
                {
                    iCashsellID = Convert.ToInt64(Request["CashsellID"].ToString());
                }
            }
            else
            {
                iCashsellID = 0;
            }

            if (Request["CashbuyID"] != null && Request["CashbuyID"].Length > 0)
            {
                if (PageValidate.IsLong(Request["CashbuyID"]))
                {
                    iCashbuyID = Convert.ToInt64(Request["CashbuyID"].ToString());
                }
            }
            else
            {
                iCashbuyID = 0;
            }

            if (!IsPostBack)
            {
                ShowData();

                //btnBack.Text = GetLanguage("Back");//返回
            }
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        private void ShowData()
        {
            lgk.Model.Cashsell cashsellInfo = cashsellBLL.GetModel(iCashsellID);
            lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(iCashbuyID);

            if(cashbuyInfo != null)
                ltAmount.Text = cashbuyInfo.Amount.ToString("0.00");
            if (cashsellInfo != null)
            {
                #region 商品信息
               // ltTitle.Text = "";// cashsellInfo.Title;
               
                ltNumber.Text = (cashsellInfo.Number).ToString("0");
               // ltPayment.Text = cashsellInfo.Number.ToString();
                //ltArrival.Text = (cashsellInfo.Number).ToString();// + cashsellInfo.Number * getParamAmount("Gold3") / 100).ToString();
                ltPrice.Text = cashsellInfo.Price.ToString();
                ltBalanceNumber.Text = (cashsellInfo.Number - cashsellInfo.SaleNum).ToString("0");
                ltAmount.Text = cashsellInfo.Amount.ToString();
                #endregion

                #region 卖家信息
                var bank = userBankBLL.GetModel(cashsellInfo.PurchaseID);
                if (bank != null)
                {
                    int bankType = (int)bank.Bank003;
                    ltReceiveAccount.Text = bank.BankName;

                    ltBankAccount.Text = bank.BankAccount;
                    imgOutQRCode.ImageUrl = bank.Bank001;
                    ltBankAccountUser.Text = bank.BankAccountUser;
                    divBankAccount.Visible = false;
                    divBankAccountUser.Visible = false;
                    divBagAddress.Visible = false;
                    divOutQrCode.Visible = false;
                    divBagAddress.Visible = false;
                    divQRNiceName.Visible = false;

                    if (bankType == 1) //银行卡
                    {
                        divBankAccount.Visible = true;
                        divBankAccountUser.Visible = true;
                    }
                    else if (bankType == 2)//微信
                    {
                        divQRNiceName.Visible = true;
                        divOutQrCode.Visible = true;
                        ltQRNiceName.Text = bank.BankAccount;
                    }
                    else if (bankType == 3) //支付宝
                    {
                        divQRNiceName.Visible = true;
                        divOutQrCode.Visible = true;
                        ltQRNiceName.Text = bank.BankAccount;
                    }
                    else if (bankType == 4)  //数字货币钱包
                    {
                        divBagAddress.Visible = true;
                        // ltBagAddress.Text = bank.BankAccount;
                        BagAddress = bank.BankAccount;
                    }

                }

                lgk.Model.tb_user userInfo = userBLL.GetModel(cashsellInfo.UserID);
                ltUserCode.Text = userInfo.UserCode;//会员编号

                ltPhoneNum.Text = userInfo.PhoneNum;//卖家手机号码
                #endregion

                //#region 信用等级
                //lgk.Model.Cashcredit cashcreditInfo = cashcreditBLL.GetModel("UserID=" + cashsellInfo.UserID + "");
                //if (cashcreditInfo != null)
                //    ltGrade.Text = cashcreditInfo.BValues.ToString();
                //#endregion
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cashbuy.aspx");
        }
    }
}