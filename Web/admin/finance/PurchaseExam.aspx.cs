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
    public partial class PurchaseExam : AdminPageBase
    {
        /// <summary>
        /// EP求购ID
        /// </summary>
        private int iPurchaseID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 16, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (Request["PurchaseID"] != null && Request["PurchaseID"].Length > 0)
            {
                if (PageValidate.IsInteger(Request["PurchaseID"]))
                {
                    iPurchaseID = Convert.ToInt32(Request["PurchaseID"].ToString());
                }
            }
            else
            {
                iPurchaseID = 0;
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
            lgk.Model.tb_Purchase purchaseInfo = purchaseBLL.GetModel(iPurchaseID);

            if (purchaseInfo != null)
            {
                #region 用户信息
                lgk.Model.tb_user userInfo = userBLL.GetModel(purchaseInfo.UserID);

                ltUserCode.Text = userInfo.UserCode;//会员编号

                ltBankName.Text = userInfo.BankName;//开户银行

                ltTrueName.Text = userInfo.TrueName;//银行姓名

                ltBankAccount.Text = userInfo.BankAccount;//银行帐号

                ltBankAccountUser.Text = userInfo.BankAccountUser;//银行姓名

                ltBankBranch.Text = userInfo.BankBranch;//开户网点

                ltQQnumer.Text = userInfo.QQnumer;//卖家QQ号码

                ltPhoneNum.Text = userInfo.PhoneNum;//卖家手机号码
                #endregion

                #region 求购信息
                ltTitle.Text = purchaseInfo.Title;
                ltNumber.Text = purchaseInfo.Number.ToString();
                ltQuantity.Text = purchaseInfo.Quantity.ToString();
                ltPrice.Text = purchaseInfo.Price.ToString("0.00");
                ltFactorage.Text = purchaseInfo.Charge.ToString("0.00");
                #endregion

                #region 信用等级
                lgk.Model.Cashcredit cashcreditInfo = cashcreditBLL.GetModel("UserID=" + purchaseInfo.UserID + "");
                if (cashcreditInfo != null)
                    ltGrade.Text = cashcreditInfo.SValues.ToString();
                #endregion
            }
        }

        protected void lbtnExam_Click(object sender, EventArgs e)
        {
            if (iPurchaseID > 0)
            {
                lgk.Model.tb_Purchase purchaseInfo = purchaseBLL.GetModel(iPurchaseID);

                purchaseInfo.IsPur = 1;

                if (purchaseBLL.Update(purchaseInfo))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('审核成功！');window.location.href='CashExaminat.aspx';", true);
                }
            }
            else
            {
                MessageBox.MyShow(this, "审核失败！");
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CashExaminat.aspx");
        }
    }
}