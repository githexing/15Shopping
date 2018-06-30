using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using lgk.Model;

namespace Web.user.finance
{
    public partial class TransferToEmoney : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // txtBonusAccount.Value = LoginUser.BonusAccount.ToString();//佣金币余额
                //txtEmoney.Value = LoginUser.Emoney.ToString();//现金币余额
                // txtStockMoney.Value = LoginUser.GLmoney.ToString();//购物币余额

                BindCurrency();
                BindData();
                btnSubmit.Text = GetLanguage("Submit");//提交
                btnSubmit.OnClientClick = "javascript:return confirm('" + GetLanguage("TransferConfirm") + "')";
                btnSearch.Text = GetLanguage("Search");//搜索

            }
        }

        private void BindCurrency()
        {
            dropCurrency.Items.Add(new ListItem("-请选择-", "0"));
            dropCurrency.Items.Add(new ListItem("报单积分互转", "1"));
            dropCurrency.Items.Add(new ListItem("电子积分互转", "2"));
            dropCurrency.Items.Add(new ListItem("报单积分转电子积分", "3"));
            dropCurrency.Items.Add(new ListItem("奖金积分转电子积分", "4"));
            dropCurrency.Items.Add(new ListItem("电子积分转消费积分", "5"));
        
            //dropCurrency.Items.Add(new ListItem("智能钱包转交易钱包", "2"));
            //dropCurrency.Items.Add(new ListItem("链接钱包转交易钱包", "3"));

            dropType.Items.Add(new ListItem("-请选择-", "0"));
            dropType.Items.Add(new ListItem("报单积分互转", "1"));
            dropType.Items.Add(new ListItem("电子积分互转", "2"));
            dropType.Items.Add(new ListItem("报单积分转电子积分", "3"));
            dropType.Items.Add(new ListItem("奖金积分转电子积分", "4"));
            dropType.Items.Add(new ListItem("电子积分转消费积分", "5"));

            //dropType.Items.Add(new ListItem("智能钱包转交易钱包", "2"));
            //dropType.Items.Add(new ListItem("链接钱包转交易钱包", "3"));
        }
       
        private bool CheckOpen(int value)
        {
            switch (value)
            {
                case 1://原始币转其他会员
                    var iOpen1 = getParamInt("Transfer_1");
                    if (iOpen1 != 1)
                    {
                        MessageBox.ShowBox(this.Page, GetLanguage("Feature"), Library.Enums.ModalTypes.none);//该功能未开放
                        return false;
                    }
                    break;
                case 2://释放币转其他会员
                    var iOpen2 = getParamAmount("Transfer_2");
                    if (iOpen2 != 1)
                    {
                        MessageBox.ShowBox(this.Page, GetLanguage("Feature"), Library.Enums.ModalTypes.none);//该功能未开放
                        return false;
                    }
                    break;
                case 3://释放币转其他会员
                    var iOpen3 = getParamAmount("Transfer_3");
                    if (iOpen3 != 1)
                    {
                        MessageBox.ShowBox(this.Page, GetLanguage("Feature"), Library.Enums.ModalTypes.none);//该功能未开放
                        return false;
                    }
                    break;
                case 4://释放币转其他会员
                    var iOpen4 = getParamAmount("Transfer_4");
                    if (iOpen4 != 1)
                    {
                        MessageBox.ShowBox(this.Page, GetLanguage("Feature"), Library.Enums.ModalTypes.none);//该功能未开放
                        return false;
                    }
                    break;
                case 5://释放币转其他会员
                    var iOpen5 = getParamAmount("Transfer_5");
                    if (iOpen5 != 1)
                    {
                        MessageBox.ShowBox(this.Page, GetLanguage("Feature"), Library.Enums.ModalTypes.none);//该功能未开放
                        return false;
                    }
                    break;
                default://请选择转账类型
                    MessageBox.ShowBox(this.Page, GetLanguage("ChooseTransfer"), Library.Enums.ModalTypes.warning);//请选择转账类型
                    return false;
            }
            return true;
        }

        protected void txtUserCode_TextChanged(object sender, EventArgs e)
        {
            string strUserCode = txtUserCode.Text.Trim();
            var user = userBLL.GetModelByUserCode(strUserCode);
            if (user != null)
            {
                txtTrueName.Text = user.NiceName;
            }
            else
            {
                txtTrueName.Text = string.Empty;
                MessageBox.ShowBox(this.Page, GetLanguage("numberIsExist"), Library.Enums.ModalTypes.warning);//会员编号不存在
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long toUserID = 0;
            lgk.Model.tb_user userInfo = userBLL.GetModel(getLoginID());
            lgk.Model.tb_change changeInfo = new lgk.Model.tb_change();

            int iTypeID = int.Parse(dropCurrency.SelectedValue);
            if (iTypeID == 0)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("ChooseTransfer"), Library.Enums.ModalTypes.warning);//请选择转账类型
                return;
            }
            if (!CheckOpen(iTypeID))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("Feature"), Library.Enums.ModalTypes.warning);//该功能未开放
                return;
            }

            string strMoney = txtMoney.Text.Trim();
            if (string.IsNullOrEmpty(strMoney))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("transferMoneyIsnull"), Library.Enums.ModalTypes.warning);//转账金额不能为空
                return;
            }
            string strPayPwd = txtSecondPassword.Text.Trim();
            if (string.IsNullOrEmpty(strPayPwd))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("SecondaryISNUll"), Library.Enums.ModalTypes.warning);//二级密码不能为空
                return;
            }
            if (!ValidPassword(userInfo.SecondPassword, PageValidate.GetMd5(strPayPwd)))
            {
                MessageBox.ShowBox(this.Page, "支付密码错误", Library.Enums.ModalTypes.warning);//
                return;
            }

            decimal dResult = 0;
            if (decimal.TryParse(strMoney, out dResult))
            {
                decimal dTrans = getParamAmount("Transfer1");//转账最低金额
                decimal d = getParamAmount("Transfer2");//转账倍数基数
                if (iTypeID==2)
                {
                    if (d != 0 && dResult % d != 0)
                    {
                        MessageBox.ShowBox(this.Page, GetLanguage("amountMustbe") + d + GetLanguage("Multiples"), Library.Enums.ModalTypes.warning);//转账金额必须是XX的倍数
                        return;
                    }
                }
                if (dResult < dTrans)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("equalTo") + dTrans, Library.Enums.ModalTypes.warning);//转账金额必须是大于等于XX的整数
                    return;
                }
              
            }
            else
            {
                MessageBox.ShowBox(this.Page, "输入的金额格式错误", Library.Enums.ModalTypes.warning);
                return;
            }

            if (iTypeID == 1 && dResult > userInfo.StockAccount || iTypeID == 3 && dResult > userInfo.StockAccount)
            {
                MessageBox.ShowBox(this.Page, "报单积分余额不足", Library.Enums.ModalTypes.warning);//
                return;
            }
            if (iTypeID == 2 && dResult > userInfo.StockMoney || iTypeID == 5 && dResult > userInfo.StockMoney)
            {
                MessageBox.ShowBox(this.Page, "电子积分余额不足", Library.Enums.ModalTypes.warning);//
                return;
            }
            if (iTypeID == 4 && dResult > userInfo.BonusAccount)
            {
                MessageBox.ShowBox(this.Page, "消费积分余额不足", Library.Enums.ModalTypes.warning);//
                return;
            }
            //else if (iTypeID == 3 && dResult > userInfo.StockAccount)
            //{
            //    MessageBox.ShowBox(this.Page, "链接钱包余额不足", Library.Enums.ModalTypes.warning);//
            //    return;
            //}

            string strUserCode = txtUserCode.Text.Trim();
            var toUser = userBLL.GetModelByUserCode(strUserCode);
            if (toUser == null)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("numberIsExist"), Library.Enums.ModalTypes.warning);//会员编号不存在
                return;
            }
            else
            {
                toUserID = int.Parse(toUser.UserID.ToString());
            }

            if (toUserID <= 0)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("objectExist"), Library.Enums.ModalTypes.warning);//转帐对象不存在
                return;
            }
            string[] Path = LoginUser.UserPath.Split('-');
            string[] Path1 = toUser.UserPath.Split('-');
            if (Path.Contains(toUserID.ToString())==false &&   Path1.Contains(getLoginID().ToString()) == false)/**/
            {
                MessageBox.ShowBox(this.Page,"该会员与您不在同一条线上", Library.Enums.ModalTypes.warning);//转帐对象不存在
                return;
            }
            
            if (!userInfo.SecondPassword.Equals(PageValidate.GetMd5(txtSecondPassword.Text.Trim())))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("PasswordError"), Library.Enums.ModalTypes.error);//二级密码错误
                return;
            }

            decimal fee = dResult * getParamAmount("Transfer3");
            changeInfo.UserID = getLoginID();
            changeInfo.ToUserID = toUserID;
            changeInfo.ToUserType = 0;
            changeInfo.MoneyType = 0;
            changeInfo.Amount = dResult;
            changeInfo.ChangeType = iTypeID;
            changeInfo.ChangeDate = DateTime.Now;
            changeInfo.Change005 = dResult - fee;
            changeInfo.Change006 = fee;// 转账手续费
            
            if (changeBLL.Add(changeInfo) > 0)
            {
                try
                {
                    // 报单积分转电子积分", "3"
                    //奖金积分转电子积分", "4"));
                    //电子积分转消费积分", "5"));
                    if (changeInfo.ChangeType == 1)//报单积分互转
                    {
                        #region 报单积分互转
                        decimal dStockAccount = userBLL.GetMoney(userInfo.UserID, "StockAccount");

                        if (dStockAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("StockAccount", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("StockAccount", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（佣金币减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "报单积分转给 " + strUserCode;
                            jmodel.RemarkEn = "Investment BonusAccount transferred to other member";
                            jmodel.InAmount = 0;
                            jmodel.OutAmount = changeInfo.Amount;
                            jmodel.BalanceAmount = userBLL.GetMoney(userInfo.UserID, "StockAccount");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = 5;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);

                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "收到 " + LoginUser.UserCode + "转来的报单积分";
                            journalInfo.RemarkEn = "Investment BonusAccount transferred to other member";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "StockAccount ");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = 5;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                        }
                        else
                        {
                            MessageBox.ShowBox(this.Page, GetLanguage("objectExist"), Library.Enums.ModalTypes.warning);//转帐对象不存在
                            return;
                        }
                        #endregion
                    }
                    else if (changeInfo.ChangeType == 2)//电子币互转
                    {
                        #region 电子币互转
                        decimal dStockAccount = userBLL.GetMoney(userInfo.UserID, "StockMoney");

                        if (dStockAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("StockMoney", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("StockMoney", toUserID, changeInfo.Change005, 1);//
                            //加入流水账表（佣金币减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "电子积分转给 "+ strUserCode;
                            jmodel.RemarkEn = "Investment BonusAccount transferred to other member";
                            jmodel.InAmount = 0;
                            jmodel.OutAmount = changeInfo.Amount;
                            jmodel.BalanceAmount = userBLL.GetMoney(userInfo.UserID, "StockMoney");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = 2;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);

                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "收到 "+LoginUser.UserCode +"转来的报单积分";
                            journalInfo.RemarkEn = "Investment BonusAccount transferred to other member";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "StockMoney ");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = 2;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                        }
                        else
                        {
                            MessageBox.ShowBox(this.Page, GetLanguage("objectExist"), Library.Enums.ModalTypes.warning);//转帐对象不存在
                            return;
                        }
                        #endregion
                    }
                    else if (changeInfo.ChangeType == 3)//报单积分转电子积分
                    {
                        #region 报单积分转电子积分
                        decimal dBonusAccount = userBLL.GetMoney(userInfo.UserID, "StockAccount");
                        if (dBonusAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("StockAccount", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("StockMoney", toUserID, changeInfo.Change005, 1);//
                            
                            fee = changeInfo.Amount - changeInfo.Change005;
                            //加入流水账表（减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "报单积分转电子积分";
                            jmodel.RemarkEn = "Currency to shopping currency";
                            jmodel.InAmount = 0;
                            jmodel.OutAmount = changeInfo.Change005;
                            jmodel.BalanceAmount = userBLL.GetMoney(toUserID, "StockAccount");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = 5;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);
                            
                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "报单积分转电子积分";
                            journalInfo.RemarkEn = "Currency to shopping currency";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "StockMoney ");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = 2;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                        }
                        #endregion
                    }
                    else if (changeInfo.ChangeType == 4)//奖金积分转电子积分
                    {
                        #region 奖金积分转电子积分
                        decimal dBonusAccount = userBLL.GetMoney(userInfo.UserID, "Emoney");
                        if (dBonusAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("Emoney", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("StockMoney", toUserID, changeInfo.Change005, 1);//

                            fee = changeInfo.Amount - changeInfo.Change005;
                            //加入流水账表（减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "奖金积分转电子积分";
                            jmodel.RemarkEn = "Currency to shopping currency";
                            jmodel.InAmount = 0;
                            jmodel.OutAmount = changeInfo.Change005;
                            jmodel.BalanceAmount = userBLL.GetMoney(toUserID, "Emoney");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = 1;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);

                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "奖金积分转电子积分";
                            journalInfo.RemarkEn = "Currency to shopping currency";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "StockMoney ");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = 2;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                        }
                        #endregion
                    }
                    else if (changeInfo.ChangeType == 5)//电子积分转消费积分
                    {
                        #region 电子积分转消费积分
                        decimal dBonusAccount = userBLL.GetMoney(userInfo.UserID, "StockMoney");
                        if (dBonusAccount >= changeInfo.Amount)
                        {
                            UpdateAccount("StockMoney", userInfo.UserID, changeInfo.Amount, 0);//
                            UpdateAccount("BonusAccount", toUserID, changeInfo.Change005, 1);//

                            fee = changeInfo.Amount - changeInfo.Change005;
                            //加入流水账表（减少）
                            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                            jmodel.UserID = userInfo.UserID;
                            jmodel.Remark = "电子积分转消费积分";
                            jmodel.RemarkEn = "Currency to shopping currency";
                            jmodel.InAmount = 0;
                            jmodel.OutAmount = changeInfo.Change005;
                            jmodel.BalanceAmount = userBLL.GetMoney(toUserID, "StockMoney");
                            jmodel.JournalDate = DateTime.Now;
                            jmodel.JournalType = 2;
                            jmodel.Journal01 = toUserID;
                            journalBLL.Add(jmodel);

                            //加入流水账表(现金币增加)
                            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                            journalInfo.UserID = toUserID;
                            journalInfo.Remark = "电子积分转消费积分";
                            journalInfo.RemarkEn = "Currency to shopping currency";
                            journalInfo.InAmount = changeInfo.Change005;
                            journalInfo.OutAmount = 0;
                            journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "BonusAccount");
                            journalInfo.JournalDate = DateTime.Now;
                            journalInfo.JournalType = 3;
                            journalInfo.Journal01 = userInfo.UserID;
                            journalBLL.Add(journalInfo);
                        }
                        #endregion
                    }
                }
                catch
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("addError"), Library.Enums.ModalTypes.error);//添加流水账错误
                }
                MessageBox.ShowBox(this.Page, GetLanguage("TransferSuccess"), Library.Enums.ModalTypes.success, "TransferToEmoney.aspx");//转账成功
            }
            else
            {
                MessageBox.ShowBox(this.Page, GetLanguage("addError"), Library.Enums.ModalTypes.error);//操作失败
            }
        }

        private string GetWhere()
        {
            string strWhere = string.Format("{0}", getLoginID());

            if (dropType.SelectedValue != "0")
            {
                strWhere += " AND c.ChangeType = " + dropType.SelectedValue + "";
            }

            string strStartTime = this.txtStart.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();
            if (GetLanguage("LoginLable") == "en-us")
            {
                strStartTime = this.txtStartEn.Text.Trim();
                strEndTime = this.txtEndEn.Text.Trim();
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) >= '" + strStartTime + "' ");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) <= '" + strEndTime + "' ");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) between '" + strStartTime + "' and '" + strEndTime + "' ");
            }
            return strWhere;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData()
        {
            bind_repeater(changeBLL.GetDataSet(GetWhere()), Repeater1, "ChangeDate desc", tr1, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 根据选择級別获取金額
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dropCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropCurrency.SelectedValue == "3" || dropCurrency.SelectedValue == "4" || dropCurrency.SelectedValue == "5")
            {
                txtUserCode.Enabled = false;
                txtUserCode.Text = LoginUser.UserCode;
                txtTrueName.Text = LoginUser.NiceName;
            }
            else
            {
                txtUserCode.Enabled = true;
                txtUserCode.Text = string.Empty;
                txtTrueName.Text = string.Empty;
              
            }
        }

        protected void txtMoney_TextChanged(object sender, EventArgs e)
        {
            string strMoney = txtMoney.Text.Trim();
            if (strMoney != "")
            {
                decimal dMoney = decimal.Parse(strMoney);
                decimal dValue = dMoney - dMoney * getParamAmount("Transfer3") / 100;

                txtActualAmount.Value = dValue.ToString();
            }
        }


    }
}