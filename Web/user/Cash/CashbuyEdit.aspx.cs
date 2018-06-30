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
    public partial class CashbuyEdit : PageCore
    {
        long iCashsellID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {


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

            btnSubmit.Text = GetLanguage("Submit");//提交

            if (!IsPostBack)
            {
                ShowData();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void ShowData()
        {
            lgk.Model.Cashsell cashsellInfo = cashsellBLL.GetModel(iCashsellID);
            #region 商品信息
            ltAmount.Text = cashsellInfo.Amount.ToString("0.00");
            ltResidualAmount.Text = (cashsellInfo.Number - cashsellInfo.SaleNum).ToString("0");
            txtUnitNum.Value = ltResidualAmount.Text;
            // ltNumber.Text = (cashsellInfo.Number + cashsellInfo.Charge).ToString();
            // ltPayment.Text = cashsellInfo.Number.ToString();
            // ltArrival.Text = (cashsellInfo.Number + cashsellInfo.Number * getParamAmount("Gold3") / 100).ToString();
            //ltPrice.Text = cashsellInfo.Price.ToString("0.00");
            #endregion

            #region 用户信息
            var bank = userBankBLL.GetModel(cashsellInfo.PurchaseID);
            if(bank != null)
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

            lgk.Model.tb_user userInfo = userBLL.GetModel(cashsellInfo.UserID);
            ltUserCode.Text = userInfo.UserCode;//会员编号

            ltPhoneNum.Text = userInfo.PhoneNum;//卖家手机号码

            //ltGrade.Text = cashcreditBLL.GetValues(cashsellInfo.UserID, "SValues").ToString();//卖家信誉等级
            #endregion
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lgk.Model.Cashbuy cashbuyInfo = new lgk.Model.Cashbuy();
            lgk.Model.Cashsell cashsellInfo = new lgk.Model.Cashsell();
            lgk.Model.Cashorder cashorderInfo = new lgk.Model.Cashorder();


            if (getParamInt("Gold1") == 0)
            {
                MessageBox.Show(this, GetLanguage("Feature"));//该功能未开放
                return;
            }

            //if (!SysTradeIsOpen())
            //{
            //    MessageBox.ShowBox(this.Page, GetLanguage("TradingReminderTitle"), string.Format(GetLanguage("TradingReminder"), getParamVarchar("GoldTradingTime")), Library.Enums.ModalTypes.warning);//请选择投资积分
            //    return;
            //}

            if (LoginUser.IsOpend == 0)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("AccountNoActiveInfo"), Library.Enums.ModalTypes.error);//您的帐号未激活
                return;
            }

            if (LoginUser.IsLock == 1)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("AccountLock"), GetLanguage("AccountLockInfo"), Library.Enums.ModalTypes.error);//您的帐号已冻结，不能进行操作
                return;
            }

            decimal iBuyNum = 0;
            decimal.TryParse(txtUnitNum.Value.Trim(),out iBuyNum);//购买件数

            if (iBuyNum <= 0)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("NumberThanZero"), Library.Enums.ModalTypes.error);//数量必须大于零
                return;
            }

            cashsellInfo = cashsellBLL.GetModel(iCashsellID);
            decimal iUnitNum = cashsellInfo.Number;//发布件数
            decimal iSaleNum = cashsellInfo.SaleNum;//已卖件数

            decimal iSurplus = iUnitNum - iSaleNum;//剩余件数

            if (iBuyNum > iSurplus)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("BuyAmountMust"), Library.Enums.ModalTypes.error);//数量必须大于零
                return;
            }

            cashsellInfo.SaleNum = iSaleNum + iBuyNum;

            #region EP币购买表
            cashbuyInfo.CashsellID = cashsellInfo.CashsellID;
            cashbuyInfo.UserID = getLoginID();
            cashbuyInfo.Amount = iBuyNum;
            cashbuyInfo.Price = cashsellInfo.Price;
            cashbuyInfo.Number = cashsellInfo.Number;
            cashbuyInfo.BuyNum = iBuyNum;
            cashbuyInfo.BuyDate = DateTime.Now;
            cashbuyInfo.IsBuy = 0;
            #endregion

            #region EP币订单表
            cashorderInfo.CashsellID = cashsellInfo.CashsellID;
            cashorderInfo.BUserID = cashbuyInfo.UserID;
            cashorderInfo.SUserID = cashsellInfo.UserID;
           // string strOrderCode = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            //strOrderCode = strOrderCode + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            cashorderInfo.OrderCode = Library.Util.CreateNo();// strOrderCode + GetRandom();
            cashorderInfo.OrderDate = DateTime.Now;
            cashorderInfo.BStatus = 0;
            cashorderInfo.BRemark = "";
            cashorderInfo.SStatus = 0;
            cashorderInfo.SRemark = "";
            cashorderInfo.Status = 0;
            #endregion

            long iCashbuyID = cashbuyBLL.Add(cashbuyInfo);

            if (iCashbuyID > 0)
            {
                cashsellBLL.Update(cashsellInfo);
                cashorderInfo.CashbuyID = iCashbuyID;
                cashorderBLL.Add(cashorderInfo);

                SetCashcredit();

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "，" + GetLanguage("OrderNumber") + "：" + cashorderInfo.OrderCode + "');window.location.href='CashOrderList.aspx';", true);
            }
        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <returns></returns>
        //private string GetRandom()
        //{
        //    Random ran = new Random();
        //    return ran.Next(0, 99).ToString();
        //}

        /// <summary>
        /// 设置购买信用度
        /// </summary>
        private void SetCashcredit()
        {
            lgk.Model.Cashcredit cashcreditInfo = new lgk.Model.Cashcredit();

            if (cashcreditBLL.Exists("UserID=" + getLoginID() + ""))
            {
                cashcreditInfo = cashcreditBLL.GetModel("UserID=" + getLoginID() + "");

                cashcreditInfo.BNumber = cashcreditInfo.BNumber + 1;
                if (cashcreditInfo.BValues == 0)
                    cashcreditInfo.BValues = 0;

                cashcreditBLL.Update(cashcreditInfo);
            }
            else
            {
                cashcreditInfo.UserID = getLoginID();
                cashcreditInfo.BNumber = 1;
                cashcreditInfo.BTradeNum = 0;
                cashcreditInfo.BEndNum = 0;
                cashcreditInfo.BValues = 5;
                cashcreditInfo.SNumber = 0;
                cashcreditInfo.STradeNum = 0;
                cashcreditInfo.SEndNum = 0;
                cashcreditInfo.SValues = 5;

                cashcreditBLL.Add(cashcreditInfo);
            }
        }
    }
}