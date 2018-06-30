using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user.Cash
{
    public partial class Feedback : PageCore
    {        
        /// <summary>
        /// 登录用户编号
        /// </summary>
        private long iUserID = 0;

        /// <summary>
        /// 操作字符
        /// </summary>
        private string strAction = "";

        /// <summary>
        /// 订单编号
        /// </summary>
        private long iOrderID = 0;

        /// <summary>
        /// 操作方式
        /// </summary>
        //private int iActionID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            iUserID = getLoginID();

            if (Request["Action"] != null && Request["Action"].Length > 0)
            {
                strAction = Request["Action"].ToString();

                string[] sArray = strAction.Split(',');

                if (sArray.Length == 2)
                {
                    if (PageValidate.IsLong(sArray[0]))
                        iOrderID = Convert.ToInt64(sArray[0]);

                    //if (PageValidate.IsInteger(sArray[1]))
                        //iActionID = Convert.ToInt32(sArray[1]);
                }
            }
            else
            {
                strAction = "";
                iOrderID = 0;
                //iActionID = 0;
            }

            if (!IsPostBack)
            {
                ShowData();
                btnSubmit.Text = GetLanguage("NoGetPay");//"未收到付款";
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
                ltOrderCode.Text = cashorderInfo.OrderCode;
                ltOrderDate.Text = cashorderInfo.OrderDate.ToString();
                #endregion

                #region 商品信息
                lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);
                ltAmount.Text = cashbuyInfo.Amount.ToString("0.0000");//支付金额
                ltBuyNumber.Text = (cashbuyInfo.BuyNum).ToString("0"); //购买数量
                ltSellNumber.Text = (cashsellInfo.Number).ToString("0");//售卖数量

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
                        ltBagAddress.Text = bank.BankAccount;
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
                previewImage.Src = cashorderInfo.Pic;
                #endregion
                #region 信用等级
                //if (iUserID == cashorderInfo.SUserID)
                //{
                //    ltCredit.Text = GetLanguage("BuyersRating");
                //    int iSValues = cashcreditBLL.GetValues(cashorderInfo.SUserID, "SValues");
                //    if (iSValues > 0)
                //    {
                //        for (int i = 0; i < iSValues; i++)
                //        {
                //            ltGrade.Text += "<img alt='' src='../../images/start.png' />";
                //        }
                //    }
                //}
                //else if (iUserID == cashorderInfo.BUserID)
                //{
                //    ltCredit.Text = GetLanguage("SellersRating");
                //    int iBValues = cashcreditBLL.GetValues(cashorderInfo.SUserID, "SValues");
                //    if (iBValues > 0)
                //    {
                //        for (int i = 0; i < iBValues; i++)
                //        {
                //            ltGrade.Text += "<img alt='' src='../../images/start.png' />";
                //        }
                //    }
                //}
                #endregion

                //if (cashorderInfo.BUserID == iUserID && cashorderInfo.SStatus == 0 && cashorderInfo.BStatus == 0 && iActionID == 1)
                //    btnSubmit.Text = GetLanguage("Payment");//"付 款";
                //else if (cashorderInfo.SUserID == iUserID && cashorderInfo.BStatus == 1 && cashorderInfo.SStatus == 0 && iActionID == 2)
                //    btnSubmit.Text = GetLanguage("ConfirmPayment");//"确认已付款"
                //else
                //    btnSubmit.Visible = false;

                if (cashorderInfo.IsFeedback == 1)
                {
                    btnSubmit.Visible = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(iOrderID);
            if (cashorderInfo.SUserID == iUserID && cashorderInfo.SStatus == 0 && cashorderInfo.BStatus == 1 && cashorderInfo.IsFeedback == 0)
            {
                cashorderBLL.Feedback(cashorderInfo.OrderID,SafeHelper.GetSafeSqlandHtml(txtReason.Text.Trim()), DateTime.Now);//反馈

                #region 短信通知
                lgk.BLL.SMS smsBLL = new lgk.BLL.SMS();
                lgk.Model.SMS smsModel = new lgk.Model.SMS();
                //给卖家发短信通知已付款
                //	SCode --1:出局短信 2:买家点击已付款 3：卖家点击已收款 4：卖家点击未收款 
                var user = userBLL.GetModel(cashorderInfo.SUserID);
                smsModel.ToUserID = cashorderInfo.SUserID;
                smsModel.ToUserCode = user.UserCode;
                smsModel.ToPhone = user.PhoneNum;
                smsModel.PublishTime = DateTime.Now;
                smsModel.ValidTime = DateTime.Now.AddMinutes(5);
                smsModel.SendNum = 0;
                smsModel.SMSContent = cashorderInfo.OrderCode;
                smsModel.IsValid = 1;
                smsModel.IsDeleted = 0;
                smsModel.SCode = "4";
                smsModel.TypeID = 0;
                smsBLL.Add(smsModel);
                #endregion
                MessageBox.ShowBox(this.Page, GetLanguage("FeedbackSuccess"), Library.Enums.ModalTypes.success, "CashOrderList.aspx");//反馈成功
            }
        }
    }
}