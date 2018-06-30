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
    public partial class Cashsell : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divBankAccount.Visible = false;
                divBankAccountUser.Visible = false;
                divBagAddress.Visible = false;
                divOutQrCode.Visible = false;
                divBagAddress.Visible = false;
                divQRNiceName.Visible = false;

                ShowData();
                BindReceiveAccount();
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        private void ShowData()
        {
            #region 用户信息
            ltUserCode.Text = LoginUser.UserCode;//会员编号

            //ltBankName.Text = LoginUser.BankName;//开户银行

            //ltTrueName.Text = LoginUser.TrueName;//银行姓名

            //ltBankAccount.Text = LoginUser.BankAccount;//银行帐号

            //ltBankAccountUser.Text = LoginUser.BankAccountUser;//银行姓名

            //ltBankBranch.Text = LoginUser.BankBranch;//开户网点

            //ltAliPay.Text = LoginUser.User005;//卖家QQ号码

            ltPhoneNum.Text = LoginUser.PhoneNum;//卖家手机号码
            ltNiceName.Text = LoginUser.NiceName;
            #endregion

            decimal dBonus = LoginUser.ShopAccount;
            ltNumber.Text = Math.Round(dBonus, 0).ToString();

            if (dBonus < 1)
            {
                btnSubmit.Visible = false;
                if (currentCulture == "en-us")
                    ltWarning.Text = GetLanguage("AvailableGold");
                else
                    ltWarning.Text = GetLanguage("AvailableGold");
            }

            if (LoginUser.IsOpend == 1)
            {
                btnSubmit.Visible = false;
                if (currentCulture == "en-us")
                    ltWarning.Text = GetLanguage("CanORNo");
                else
                    ltWarning.Text = GetLanguage("CanORNo");
            }
        }
        /// <summary>
        /// 收款账户列表
        /// </summary>
        private void BindReceiveAccount()
        {
            IList<lgk.Model.tb_UserBank> ddlList = new lgk.BLL.tb_UserBank().GetModelList("Bank004 >= 0 and userid=" + LoginUser.UserID);
            dorpReceiveAccount.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = GetLanguage("PleaseSselect");//"-请选择-";
            dorpReceiveAccount.Items.Add(li);
            foreach (lgk.Model.tb_UserBank item in ddlList)
            {
                ListItem items = new ListItem();
                string bankname = item.BankName;
                items.Value = item.ID.ToString();
                items.Text = bankname;
                items.Attributes["BankType"] = item.Bank003.ToString();
                items.Attributes["BankAccount"] = item.BankAccount.ToString();
                items.Attributes["QRCode"] = item.Bank001.ToString();
                dorpReceiveAccount.Items.Add(items);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (getParamInt("Gold1") == 0)
            {
                MessageBox.Show(this, GetLanguage("Feature"));//该功能未开放
                return;
            }
            
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
            int receivaAccount = dorpReceiveAccount.SelectedValue.ToInt();
            if (receivaAccount == 0)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("SelectReceiveAccount"), Library.Enums.ModalTypes.error);//请选择收款账户
                return;
            }

            #region 金额验证
            if (txtNumber.Text.Trim() == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("AmountNoEmpty"), Library.Enums.ModalTypes.warning);//卖出金额不能为空
                return;
            }
            decimal dNumber = 0;
            if (decimal.TryParse(txtNumber.Text.Trim(), out dNumber))
            {
                decimal dGold1 = getParamAmount("Gold1");
                if (dNumber < dGold1)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("Minimum"), Library.Enums.ModalTypes.warning);//最小交易额
                    return;
                }
            }
            else
            {
                MessageBox.ShowBox(this.Page, GetLanguage("NumberThanZero"), Library.Enums.ModalTypes.error);//金额格式输入错误
                return;
            }

            int mul = getParamInt("Gold7");
            if (dNumber % mul != 0)
            {
                MessageBox.ShowBox(this.Page, string.Format(GetLanguage("CashSellMul"), mul), Library.Enums.ModalTypes.warning);//出售金额必须为 7 的整数倍
                return;
            }

            decimal dMaxNumber = 0;//每日最大挂卖数量
            decimal dBNumber = 0, dBaseNumber = 0;//每日挂卖基数
            decimal dANumber = 0;//今日已挂卖数量

            dBaseNumber = getParamAmount("Gold6");
            // dBNumber = getParamAmount("Gold7");
            dMaxNumber = dBaseNumber;// dBaseNumber + dBNumber * userBLL.GetCount("RecommendID = " + LoginUser.UserID + " AND IsOpend = 2");//每日挂卖基数
            dANumber = cashsellBLL.GetAlready(LoginUser.UserID) + dNumber;

            if (dANumber > dMaxNumber)
            {
                MessageBox.ShowBox(this.Page,GetLanguage("ConsignmentOver"), Library.Enums.ModalTypes.warning);// 寄售数量已超额
                return;
            }

            //if (txtPrice.Text.Trim() == "")
            //{
            //    MessageBox.MyShow(this, GetLanguage("PriceEmpty"));//价格不能为空
            //    return;
            //}
            decimal dPrice = 1;
            //if (decimal.TryParse(txtPrice.Text.Trim(), out dPrice))
            //{
            //    decimal dGoldMin = getParamAmount("GoldMin");//最低价格
            //    decimal dGoldMax = getParamAmount("GoldMax");//最高价格

            //    if (dPrice < dGoldMin)
            //    {
            //        MessageBox.MyShow(this, GetLanguage("PriceBetween"));
            //        return;
            //    }
            //    else if (dPrice > dGoldMax)
            //    {
            //        MessageBox.MyShow(this, GetLanguage("PriceBetween"));
            //        return;
            //    }
            //}
            //else
            //{
            //    MessageBox.MyShow(this, GetLanguage("PriceFormat"));//价格格式错误
            //    return;
            //}

            #endregion

            if (txtThreePassword.Value.Trim() == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("Pleasepassword"), Library.Enums.ModalTypes.warning);// 请输入二级密码
                return;
            }

            string strPassword = PageValidate.GetMd5(txtThreePassword.Value.Trim());
            int re = spd.findSecondpws(strPassword, 1, getLoginID());
            if (re == 0)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("PasswordError"), Library.Enums.ModalTypes.error);// >密码输入错误!
                return;
            }

            // int iUnitNum = Convert.ToInt32(txtUnitNum.Value.Trim());//发布件数1
            decimal dFactorage = dNumber * getParamAmount("Gold2") / 100;//保证金

            lgk.Model.tb_user userInfo = new lgk.Model.tb_user();
            lgk.Model.Cashsell cashsellInfo = new lgk.Model.Cashsell();

            decimal dAmount = dNumber * dPrice;

            userInfo = userBLL.GetModel(getLoginID());

            #region 赋值给金币销售表实体
            cashsellInfo.Title = Util.CreateNo();
            cashsellInfo.UserID = getLoginID();
            cashsellInfo.Amount = dAmount;//商品价格
            cashsellInfo.Number = Convert.ToInt32(dNumber);//单件数量
            cashsellInfo.Price = dPrice;//商品单价
            cashsellInfo.UnitNum = getParamAmount("Gold2");//手续费率
            cashsellInfo.SaleNum = 0;//已卖件数
            cashsellInfo.Charge = dFactorage;//每件所需手续费
            cashsellInfo.SellDate = DateTime.Now;//提交时间
            cashsellInfo.Remark = "";
            cashsellInfo.PurchaseID = receivaAccount;//收款账户ID
            cashsellInfo.IsSell = 1;
            #endregion

            #region 加入流水账表
            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            journalInfo.UserID = cashsellInfo.UserID;
            journalInfo.Remark = "卖出交易币";
            journalInfo.RemarkEn = "Sell Circulating gold";
            journalInfo.InAmount = 0;
            journalInfo.OutAmount = cashsellInfo.Number;// cashsellInfo.Number * iUnitNum + dFactorage;
            journalInfo.BalanceAmount = userInfo.ShopAccount - dNumber;// userInfo.BonusAccount - dNumber - dFactorage;
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = (int)Library.AccountType.交易钱包;
            journalInfo.Journal01 = cashsellInfo.UserID;
            #endregion

            #region 保证金 加入流水账表
            lgk.Model.tb_journal journalInfoTrans = new lgk.Model.tb_journal()
            {
                UserID = cashsellInfo.UserID,
                Remark = "卖出交易币,扣除保证金",
                RemarkEn = "Sell gold points, consumption code",
                InAmount = 0,
                OutAmount = dFactorage,// cashsellInfo.Number * iUnitNum + dFactorage;
                BalanceAmount = userInfo.ShopAccount - dNumber - dFactorage,// userInfo.BonusAccount - dNumber - dFactorage;
                JournalDate = DateTime.Now,
                JournalType = (int)Library.AccountType.交易钱包,
                Journal01 = cashsellInfo.UserID
            };

            #endregion

            decimal dBonusAccount = dNumber;// + dFactorage;

            if (userInfo.ShopAccount < dBonusAccount + dFactorage)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("GoldInsufficient"), Library.Enums.ModalTypes.warning);// 金币不足，请重新填写数据之后再试！!
                return;
            }
            
            //if (userInfo.ShopAccount < dFactorage)
            //{
            //    MessageBox.ShowBox(this.Page, GetLanguage("GoldTransInsufficient"), Library.Enums.ModalTypes.warning);//交易码不足！

            //    return;
            //}

           
           // UpdateAccount("ShopAccount", getLoginID(), dFactorage, 0);

            if (cashsellBLL.Add(cashsellInfo) > 0 && journalBLL.Add(journalInfoTrans)>0 && journalBLL.Add(journalInfo) > 0 && UpdateAccount("ShopAccount", getLoginID(), dBonusAccount + dFactorage, 0) > 0)
            {
                SetCashcredit();
                MessageBox.ShowBox(this.Page, GetLanguage("Successful"), Library.Enums.ModalTypes.success, "CashsellList.aspx");//注册成功!

            }
            else
                MessageBox.ShowBox(this.Page, GetLanguage("OperationFailed"), Library.Enums.ModalTypes.error);//操作失败!

        }

        /// <summary>
        /// 设置销售信用度
        /// </summary>
        private void SetCashcredit()
        {
            lgk.Model.Cashcredit cashcreditInfo = new lgk.Model.Cashcredit();

            if (cashcreditBLL.Exists("UserID=" + LoginUser.UserID + ""))
            {
                cashcreditInfo = cashcreditBLL.GetModel("UserID=" + LoginUser.UserID + "");

                cashcreditInfo.SNumber = cashcreditInfo.SNumber + 1;
                if (cashcreditInfo.SValues == 0)
                    cashcreditInfo.SValues = 0;

                cashcreditBLL.Update(cashcreditInfo);
            }
            else
            {
                cashcreditInfo.UserID = getLoginID();
                cashcreditInfo.BNumber = 0;
                cashcreditInfo.BTradeNum = 0;
                cashcreditInfo.BEndNum = 0;
                cashcreditInfo.BValues = 5;
                cashcreditInfo.SNumber = 1;
                cashcreditInfo.STradeNum = 0;
                cashcreditInfo.SEndNum = 0;
                cashcreditInfo.SValues = 5;

                cashcreditBLL.Add(cashcreditInfo);
            }
        }

        protected void txtNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text.Trim() != "" && PageValidate.IsNumberOrDecimal(txtNumber.Text.Trim()))
            {
                decimal dNumber = Convert.ToDecimal(txtNumber.Text.Trim());//单件数量

                txtFactorage.Value = (dNumber * getParamAmount("Gold2") / 100).ToString();
            }
        }

        protected void dorpReceiveAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strName = dorpReceiveAccount.SelectedValue;
            if (strName == "0")
            {
                ltBankAccount.Text = "";
                imgOutQRCode.ImageUrl = "";
            }
            else
            {
                lgk.Model.tb_UserBank model = userBankBLL.GetModel(strName.ToInt());
                ltBankAccount.Text = model.BankAccount;
                imgOutQRCode.ImageUrl = model.Bank001;
                ltBankAccountUser.Text = model.BankAccountUser;
                divBankAccount.Visible = false;
                divBankAccountUser.Visible = false;
                divBagAddress.Visible = false;
                divOutQrCode.Visible = false;
                divBagAddress.Visible = false;
                divQRNiceName.Visible = false;

                if (model.Bank003 == 1) //银行卡
                {
                    divBankAccount.Visible = true;
                    divBankAccountUser.Visible = true;
                }
                else if (model.Bank003 == 2)//微信
                {
                    divQRNiceName.Visible = true;
                    divOutQrCode.Visible = true;
                    ltQRNiceName.Text = model.BankAccount;
                }
                else if (model.Bank003 == 3) //支付宝
                {
                    divQRNiceName.Visible = true;
                    divOutQrCode.Visible = true;
                    ltQRNiceName.Text = model.BankAccount;
                }
                else if (model.Bank003 == 4)  //数字货币钱包
                {
                    divBagAddress.Visible = true;
                    ltBagAddress.Text = model.BankAccount;
                }
            }
        }
    }
}