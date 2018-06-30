using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.admin.finance
{
    public partial class CashOrderDetail : AdminPageBase
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        private long iOrderID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
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
                ltPayDate.Text = cashorderInfo.PayDate.ToString();
                
                if(cashorderInfo.IsFeedback == 1)
                {
                    trFeedback.Visible = true;
                    litFeedback.Text = cashorderInfo.Feedback;
                }
                else trFeedback.Visible = false;
                #endregion

                #region 商品信息
                lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);
                ltAmount.Text = cashbuyInfo.Amount.ToString("0.00");
                ltNumber.Text = cashbuyInfo.Number.ToString("0.00");
                #endregion

                #region 卖家信息
                lgk.Model.tb_user suserInfo = userBLL.GetModel(cashorderInfo.SUserID);

                ltSUserCode.Text = suserInfo.UserCode;//会员编号

                ltSBankName.Text = suserInfo.BankName;//开户银行

                ltSTrueName.Text = suserInfo.TrueName;//银行姓名

                ltSBankAccount.Text = suserInfo.BankAccount;//银行帐号

                ltSBankAccountUser.Text = suserInfo.BankAccountUser;//银行姓名

                ltSBankBranch.Text = suserInfo.BankBranch;//开户网点

                ltSPhoneNum.Text = suserInfo.PhoneNum;//卖家手机号码
                #endregion

                #region 买家信息
                lgk.Model.tb_user buserInfo = userBLL.GetModel(cashorderInfo.BUserID);

                ltBUserCode.Text = buserInfo.UserCode;//会员编号

                ltBBankName.Text = buserInfo.BankName;//开户银行

                ltBTrueName.Text = buserInfo.TrueName;//银行姓名

                ltBBankAccount.Text = buserInfo.BankAccount;//银行帐号

                ltBBankAccountUser.Text = buserInfo.BankAccountUser;//银行姓名

                ltBBankBranch.Text = buserInfo.BankBranch;//开户网点

                ltBPhoneNum.Text = buserInfo.PhoneNum;//卖家手机号码
                #endregion

                #region 信用等级
                //"卖家信誉等级";
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
                #endregion
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CashOrderList.aspx");
        }
    }
}