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
    public partial class addcishan : PageCore//System.Web.UI.Page
    {
        lgk.BLL.tb_user myUser = new lgk.BLL.tb_user();

        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码
            if (!IsPostBack)
            {
                Label_money.Text = userBLL.GetModel(LoginUser.UserID).BonusAccount.ToString();
                BindData();
                btnSubmit.Text = GetLanguage("Submit");//提交
                btnSubmit.OnClientClick = "javascript:return confirm('" + GetLanguage("TransferConfirm") + "')";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int toUserID = 0;
            lgk.Model.tb_user userInfo = userBLL.GetModel(getLoginID());
            lgk.Model.tb_change changeInfo = new lgk.Model.tb_change();
            int type = 0;

            if (Convert.ToDecimal(txtMoney.Value.Trim()) > userInfo.BonusAccount)
            {
                MessageBox.Show(this, GetLanguage("balanceDollars"));//奖金余额不足
                return;
            }
            changeInfo.UserID = getLoginID();
            changeInfo.ToUserID = toUserID;
            changeInfo.ToUserType = 0;
            changeInfo.MoneyType = 0;
            changeInfo.Amount = Convert.ToDecimal(txtMoney.Value.Trim());
            changeInfo.ChangeType = 5;
            changeInfo.ChangeDate = DateTime.Now;

            if (changeBLL.Add(changeInfo) > 0)
            {
                var user = userBLL.GetModel(LoginUser.UserID);
                decimal EMoney = Convert.ToDecimal(getColumn(0, "BonusAccount", "tb_user", "UserID=" + getLoginID(), ""));
                if (EMoney >= Convert.ToDecimal(txtMoney.Value.Trim()))
                {
                    UpdateAccount("BonusAccount", getLoginID(), Convert.ToDecimal(changeInfo.Amount), 0);//
                    UpdateSystemAccount("Money001", Convert.ToDecimal(changeInfo.Amount), 1);
                    UpdateSystemAccount("Money002", Convert.ToDecimal(changeInfo.Amount), 1);
                  //  UpdateAccount("Emoney", toUserID, Convert.ToDecimal(changeInfo.Amount), 1);//
                    //加入流水账表（奖金币减少）
                    lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                    jmodel.UserID = getLoginID();
                    jmodel.Remark ="慈善捐款";
                    jmodel.RemarkEn = "慈善捐款";
                    jmodel.InAmount = 0;
                    jmodel.OutAmount = changeInfo.Amount;
                    var data = userBLL.GetModel(getLoginID());
                    jmodel.BalanceAmount = data.BonusAccount;
                    jmodel.JournalDate = DateTime.Now;
                    jmodel.JournalType =3;
                    jmodel.Journal01 = toUserID;
                    journalBLL.Add(jmodel);
                    MessageBox.ShowAndRedirect(this, "捐款金额成功！", "addcishan.aspx");//转账成功
                  //  ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('捐款金额成功！');", true);//奖金币转拍币功能未开放
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('捐款金额不能大于奖金币余额！');", true);//奖金币转拍币功能未开放
                }
                //发送短信通知
                //content = GetLanguage("TransferMoenyFrom").Replace("{username}", user.UserCode).Replace("{Amount}", changeInfo.Amount.ToString()).Replace("{time}", DateTime.Now.ToString("yyyy年MM月dd日HH时mm分")).Replace("{timeEn}", DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
                //SendMessage(getLoginID(), user.PhoneNum, content);

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData()
        {
            string strWhere = string.Format("and c.ChangeType=5 and c.UserID=" + getLoginID());
            string strStartDate = this.txtStartDate.Text.Trim();
            string strEndDate = this.txtEndDate.Text.Trim();

            if (strStartDate != "" && strEndDate == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120)  >= '" + strStartDate + "'");
            }
            else if (strStartDate == "" && strEndDate != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),c.ChangeDate,120)  <= '" + strEndDate + "'");
            }
            else if (strStartDate != "" && strEndDate != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),c.ChangeDate,120)  between '" + strStartDate + "' and '" + strEndDate + "'");
            }

            bind_repeater(changeBLL.GetDataSet2(strWhere), Repeater1, "ChangeDate desc", trBonusNull, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

    }
}