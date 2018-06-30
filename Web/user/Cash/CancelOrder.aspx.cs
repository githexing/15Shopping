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
    public partial class CancelOrder : PageCore
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

        protected void Page_Load(object sender, EventArgs e)
        {
            

            iUserID = getLoginID();
            btnCheck.Text = GetLanguage("Submit");//提 交
            btnBack.Text = GetLanguage("Back");//返 回

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
                #region 订单信息
                lblOrderCode.Text = cashorderInfo.OrderCode;
                lbOrderDate.Text = cashorderInfo.OrderDate.ToString();
                #endregion

                #region 商品信息
                ltTitle.Text = "";// cashsellBLL.GetModel(cashorderInfo.CashsellID).Title;
                lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);
                ltAmount.Text = cashbuyInfo.Amount.ToString();
               // ltNumber.Text = (cashbuyInfo.Number + cashbuyInfo.Number * getParamAmount("Gold2") / 100).ToString();
                ltPayment.Text = cashbuyInfo.Number.ToString();
                //ltArrival.Text = (cashbuyInfo.Number + cashbuyInfo.Number * getParamAmount("Gold3") / 100).ToString();
                //ltPrice.Text = cashbuyInfo.Price.ToString();
               
                #endregion

                #region 卖家信息
                lgk.Model.tb_user userInfo = userBLL.GetModel(cashorderInfo.SUserID);
                ltBankAccount.Text = userInfo.BankAccount;
                ltBankAccountUser.Text = userInfo.BankAccountUser;
                ltBankBranch.Text = userInfo.BankBranch;
                #endregion

                //#region 信用等级
                //if (iUserID == cashorderInfo.SUserID)
                //{
                //    lgk.Model.Cashcredit cashcreditInfo = cashcreditBLL.GetModel("UserID=" + cashorderInfo.BUserID + "");

                //    ltCredit.Text = "买家信用度";
                //    if (cashcreditInfo != null)
                //        ltGrade.Text = cashcreditInfo.SValues.ToString();
                //}
                //else if (iUserID == cashorderInfo.BUserID)
                //{
                //    lgk.Model.Cashcredit cashcreditInfo = cashcreditBLL.GetModel("UserID=" + cashorderInfo.SUserID + "");
                //    ltCredit.Text = "卖家信用度";
                //    if (cashcreditInfo != null)
                //        ltGrade.Text = cashcreditInfo.BValues.ToString();
                //}
                //#endregion
            }
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            string strRemark = "";
            decimal dAccount = Convert.ToDecimal(0.00);
            lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(iOrderID);
            lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);

            if (txtRemark.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('终止原因不能为空！');", true);//登录密码不能为空
                return;
            }

            strRemark = txtRemark.Text;

            dAccount = cashbuyInfo.Number * cashbuyInfo.BuyNum;//每件数量*件数
            decimal dFactorage = cashbuyInfo.Number * getParamAmount("Gold2") / 100;//手续费
            decimal dTotal = dAccount;// + dFactorage;

            //加入流水账表
            if (iUserID == cashorderInfo.BUserID)
            {
                strRemark = "买家终止原因：" + strRemark;
                
               // cashorderBLL.Update(strRemark, iOrderID, iUserID, 1);
                UpdateAccount("BonusAccount", cashorderInfo.SUserID, dTotal, 1);//终止交易，将EP币返还卖家
               // UpdateAccount("ShopAccount", cashorderInfo.SUserID, dFactorage, 1);//终止交易，将交易码返还卖家
                SetAccount(cashorderInfo.SUserID, dTotal, strRemark, (int)Library.AccountType.交易钱包);
               // SetAccount(cashorderInfo.SUserID, dFactorage, strRemark, (int)Library.AccountType.交易码);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('终止交易成功！');window.location.href='CashOrderList.aspx';", true);
            }
            else if (iUserID == cashorderInfo.SUserID)
            {
                strRemark = "卖家终止原因：" + strRemark;
                //dAccount = cashbuyInfo.Number * cashbuyInfo.BuyNum;

             //   cashorderBLL.Update(strRemark, iOrderID, iUserID, 2);
                UpdateAccount("BonusAccount", cashorderInfo.SUserID, dTotal, 1);//终止交易，将EP币返还卖家
               // UpdateAccount("ShopAccount", cashorderInfo.SUserID, dFactorage, 1);//终止交易，将交易码返还卖家

                SetAccount(iUserID, dTotal, strRemark, (int)Library.AccountType.交易钱包);
               // SetAccount(iUserID, dFactorage, strRemark, (int)Library.AccountType.交易码);

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('终止交易成功！');window.location.href='CashOrderList.aspx';", true);
            }
        }

        /// <summary>
        /// 加入流水账表
        /// </summary>
        /// <param name="iUserID">用户编号</param>
        /// <param name="dAccount">终止交易货物数量</param>
        /// <param name="strRemark">备注(终止原因)</param>
        private void SetAccount(long iUserID, decimal dAccount, string strRemark,int JournalType)
        {
            #region 加入流水账表

            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            lgk.Model.tb_user userInfo = userBLL.GetModel(iUserID);
            journalInfo.UserID = iUserID;
            journalInfo.Remark = strRemark;
            journalInfo.RemarkEn = "Trading halt!";
            journalInfo.InAmount = dAccount;
            journalInfo.OutAmount = 0;
            journalInfo.BalanceAmount = userInfo.BonusAccount + dAccount;
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = JournalType;
            journalInfo.Journal01 = iUserID;

            #endregion

            journalBLL.Add(journalInfo);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CashOrderList.aspx");
        }
    }
}