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
    public partial class CheckOrder : PageCore
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
        private int iActionID = 0;

        public string BagAddress { set; get; }

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

                    if (PageValidate.IsInteger(sArray[1]))
                        iActionID = Convert.ToInt32(sArray[1]);
                }
            }
            else
            {
                strAction = "";
                iOrderID = 0;
                iActionID = 0;
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
                        // ltBagAddress.Text = bank.BankAccount;
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
                //#region 信用等级
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
                //#endregion
                 divBuyerInfo.Visible = true;
                divUploadImage.Visible = false;
                if (cashorderInfo.BUserID == iUserID && cashorderInfo.SStatus == 0 && cashorderInfo.BStatus == 0 && iActionID == 1)
                {
                    btnCheck.Text = GetLanguage("Payment");//"付 款";
                    divBuyerInfo.Visible = true;
                    divUploadImage.Visible = true;
                }
                else if (cashorderInfo.SUserID == iUserID && cashorderInfo.BStatus == 1 && cashorderInfo.SStatus == 0 && iActionID == 2)
                {
                    btnCheck.Text = GetLanguage("ConfirmPayment");//"确认已付款"
                    previewImage.Src = cashorderInfo.Pic;
                }
                else
                {
                    btnCheck.Visible = false;
                    previewImage.Src = cashorderInfo.Pic;
                }
            }
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            //if (!SysTradeIsOpen())
            //{
            //    MessageBox.ShowBox(this.Page,string.Format(GetLanguage("TradingReminder"),getParamVarchar("GoldTradingTime")), Library.Enums.ModalTypes.warning);//请选择投资积分
            //    return;
            //}
            lgk.BLL.SMS smsBLL = new lgk.BLL.SMS();
            lgk.Model.SMS smsModel = new lgk.Model.SMS();

            lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(iOrderID);

            if (cashorderInfo.BUserID == iUserID && cashorderInfo.SStatus == 0 && cashorderInfo.BStatus == 0 && iActionID == 1)
            {
                string pic = Request.Form["hiddenupimage"] == null
                   || Request.Form["hiddenupimage"].ToString() == "" ? "" : Request.Form["hiddenupimage"].ToString();
                if(string.IsNullOrEmpty(pic))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请上传图片凭证。');window.location.href='CashOrderList.aspx';", true);
                    return;
                }
                cashorderBLL.Update(iUserID, cashorderInfo.OrderID, DateTime.Now, pic, "", 1);//付款
                #region 短信通知
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
                smsModel.SCode = "2";
                smsModel.TypeID = 0;
                smsBLL.Add(smsModel);
                #endregion
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');window.location.href='CashOrderList.aspx';", true);
            }
            else if (cashorderInfo.SUserID == iUserID && cashorderInfo.BStatus == 1 && cashorderInfo.SStatus == 0 && iActionID == 2)
            {
                cashorderBLL.Update(iUserID, cashorderInfo.OrderID, DateTime.Now,"","", 2);//确认已付款

                cashorderBLL.Update(cashorderInfo.SUserID, iOrderID, DateTime.Now, "","",3);//发货

                lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);

                lgk.Model.Cashsell CashsellInfo = cashsellBLL.GetModel(cashbuyInfo.CashsellID);

                decimal dNumber = cashbuyInfo.Amount;
                //decimal dCharge = CashsellInfo.Charge;//总手续费
                //decimal dMTaxRate = dNumber * getParamAmount("Gold3") / 100;//买家获得手续费
                //decimal dCTaxRate = dNumber * getParamAmount("Gold4") / 100;//公司获得手续费

                //decimal dTNumber = dNumber - dCharge + dMTaxRate;
                decimal dTNumber = dNumber;// + dMTaxRate;
              //  decimal give = dTNumber * getParamAmount("Gold10") / 100; //买入获得系统赠送
               // dTNumber += give; //买入获得系统赠送2018-3-15
                //买家得到的是投资积分 StockMoney
                UpdateAccount("ShopAccount", cashorderInfo.BUserID, dTNumber, 1);//发货给购买者

                //UpdateSystemAccount("MoneyAccount", dCTaxRate, 1);

                ////SetAccount(iUserID, dAccount, "EP币发货！", 1);
                SetAccount(cashorderInfo.BUserID, dTNumber, "金币发货！", cashorderInfo.SUserID, (int)Library.AccountType.交易钱包);

                #region 短信通知
                //给卖家发短信通知已付款
                //	SCode --1:出局短信 2:买家点击已付款 3：卖家点击已收款 4：卖家点击未收款 
                var user = userBLL.GetModel(cashorderInfo.BUserID);
                smsModel.ToUserID = cashorderInfo.BUserID;
                smsModel.ToUserCode = user.UserCode;
                smsModel.ToPhone = user.PhoneNum;
                smsModel.PublishTime = DateTime.Now;
                smsModel.ValidTime = DateTime.Now.AddMinutes(5);
                smsModel.SendNum = 0;
                smsModel.SMSContent = cashorderInfo.OrderCode;
                smsModel.IsValid = 1;
                smsModel.IsDeleted = 0;
                smsModel.SCode = "3";
                smsModel.TypeID = 0;
                smsBLL.Add(smsModel); 
                #endregion

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');window.location.href='CashOrderList.aspx';", true);
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OperationFailed") + "');window.location.href='CashOrderList.aspx';", true);
        }

        /// <summary>
        /// 加入流水账表
        /// </summary>
        /// <param name="iUserID">用户编号</param>
        /// <param name="dAccount">收发货数量</param>
        /// <param name="strRemark">备注</param>
        private void SetAccount(long iBUserID, decimal dAccount, string strRemark, long iSUserID,int JournalType)
        {
            #region 加入流水账表

            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            lgk.Model.tb_user userInfo = userBLL.GetModel(iBUserID);
            journalInfo.UserID = iBUserID;
            journalInfo.Remark = strRemark;//"EP币发货";
            journalInfo.RemarkEn = "Gold coin receipt!";
            journalInfo.InAmount = dAccount;
            journalInfo.OutAmount = 0;
            journalInfo.BalanceAmount = userInfo.ShopAccount;//EP币收货！
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = JournalType;
            journalInfo.Journal01 = iSUserID;

            #endregion

            journalBLL.Add(journalInfo);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CashOrderList.aspx");
        }
    }
}