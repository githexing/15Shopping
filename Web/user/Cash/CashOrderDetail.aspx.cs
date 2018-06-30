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
    public partial class CashOrderDetail : PageCore
    {
        /// <summary>
        /// 登录用户编号
        /// </summary>
        private long iUserID = 0;

        /// <summary>
        /// 订单编号
        /// </summary>
        private long iOrderID = 0;
        public string BagAddress { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
         

            iUserID = getLoginID();

            if (Request["OrderID"] != null && Request["OrderID"].Length > 0)
            {
                if (PageValidate.IsLong(Request["OrderID"]))
                {
                    iOrderID = Convert.ToInt64(Request["OrderID"].ToString());
                }
            }
            else
            {
                iOrderID = 0;
            }

            btnBack.Text = GetLanguage("Return");//返 回

            if (!IsPostBack)
            {
                ShowData();
            }
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        private void ShowData()
        {
            lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(iOrderID);

            if (cashorderInfo != null)
            {
                var cashsellInfo = cashsellBLL.GetModel(cashorderInfo.CashsellID);

                #region 订单信息
                lblOrderCode.Text = cashorderInfo.OrderCode;
                lbOrderDate.Text = cashorderInfo.OrderDate.ToString();
                ltBRemark.Text = cashorderInfo.BRemark;
                ltSRemark.Text = cashorderInfo.SRemark;
                #endregion

                #region 商品信息
                
                lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);
                ltAmount.Text = cashbuyInfo.Amount.ToString("0.0000");//支付金额
                ltBuyNumber.Text = (cashbuyInfo.BuyNum).ToString("0"); //购买数量
                ltSellNumber.Text = (cashsellInfo.Number).ToString("0");//售卖数量
                //ltPayment.Text = cashbuyInfo.Number.ToString();
                //ltArrival.Text = (cashbuyInfo.Number + cashbuyInfo.Number * getParamAmount("Gold3") / 100).ToString();
                //ltPrice.Text = cashbuyInfo.Price.ToString("0.00");
                //ltBuyNum.Text = cashbuyInfo.BuyNum.ToString();
                #endregion

                #region 卖家信息
             //   var cashsellInfo = cashsellBLL.GetModel(cashorderInfo.CashsellID);
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
                        BagAddress = bank.BankAccount;
                    }

                }

                lgk.Model.tb_user userInfo = userBLL.GetModel(cashorderInfo.SUserID);
                ltUserCode.Text = userInfo.UserCode;//会员编号

                ltPhoneNum.Text = userInfo.PhoneNum;//卖家手机号码
                #endregion

                #region 买家信息
                lgk.Model.tb_user buserInfo = userBLL.GetModel(cashorderInfo.BUserID);

                ltBUserCode.Text = buserInfo.NiceName;//会员编号
                
                ltBPhoneNum.Text = buserInfo.PhoneNum;//卖家手机号码
                #endregion

                if (cashorderInfo.IsFeedback == 1)
                {
                    divFeedback.Visible = true;
                    ltReason.Text = cashorderInfo.Feedback;
                    ltFeedbackDate.Text = cashorderInfo.FeedbackDate.ToString();
                }
                else
                    divFeedback.Visible = false;

                //#region 信用等级
                //int iBValues = cashcreditBLL.GetValues(cashorderInfo.SUserID, "BValues");
                //if (iBValues > 0)
                //{
                //    for (int i = 0; i < iBValues; i++)
                //    {
                //        ltSGrade.Text += "<img alt='' src='../../images/start.png' />";
                //    }
                //}

                //int iSValues = cashcreditBLL.GetValues(cashorderInfo.BUserID, "SValues");
                //if (iSValues > 0)
                //{
                //    for (int i = 0; i < iSValues; i++)
                //    {
                //        ltBGrade.Text += "<img alt='' src='../../images/start.png' />";
                //    }
                //}
                //#endregion
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CashOrderList.aspx");
        }
    }
}