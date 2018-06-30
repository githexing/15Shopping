using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library;

namespace Web.admin.system
{
    public partial class BankEdit : AdminPageBase//System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 30, getLoginID());//权限
            if (!IsPostBack)
            {
                //if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                //{
                //    BindData(Request.QueryString["id"]);
                //}
                bind();
            }
        }

        private void bind()
        {
            lgk.Model.tb_systemBank bank = bankBLL.GetModel(getIntRequest("ID"));
            if (bank != null)
            {
                textBankName.Value = bank.BankName;
                textBankAccount.Value = bank.BankAccount;
                textBankAccountUser.Value = bank.BankAccountUser;
                tr1.Visible = true;
                tr2.Visible = false;
                tr3.Visible = false;
            }
        }
        /// <summary>
        /// 填充數据
        /// </summary>
        protected void BindData(string id)
        {
            lgk.Model.tb_systemBank bank = bankBLL.GetModel(int.Parse(id));
            if (bank.BankType==1)
            {
                textBankName.Value = bank.BankName;
                textBankAccount.Value = bank.BankAccount;
                textBankAccountUser.Value = bank.BankAccountUser;
                tr1.Visible = true;
                tr2.Visible = false;
                tr3.Visible = false;
            }
            else if (bank.BankType==2)
            {
                textRichesNum.Value = bank.BankAccount;
                textRichesName.Value = bank.BankAccountUser;
                tr1.Visible = false;
                tr2.Visible = true;
                tr3.Visible = false;
            }
            else if (bank.BankType == 3)
            {
                textPayNum.Value = bank.BankAccount;
                textPayName.Value = bank.BankAccountUser;
                tr1.Visible = false;
                tr2.Visible = false;
                tr3.Visible = true;
            }
        }
        /// <summary>
        /// 銀行賬戶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (textBankName.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行名称不能为空!');", true);
                return;
            }
            if (textBankAccount.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行账号不能为空!');", true);
                return;
            }
            if (textBankAccountUser.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('开户名不能为空!');", true);
                return;
            }
            lgk.Model.tb_systemBank bank = bankBLL.GetModel(getIntRequest("ID"));
            if (bank != null)
            {
                bank.BankAccount = textBankAccount.Value.Trim();
                bank.BankName = textBankName.Value.Trim();
                bank.BankAccountUser = textBankAccountUser.Value.Trim();
                if (bankBLL.Update(bank))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('设置成功！');window.location.href='AccountSet.aspx';", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('设置失败!');", true);
                    return;
                }
            }
            else
            {
                bank = new lgk.Model.tb_systemBank();
                bank.BankAccount = textBankAccount.Value.Trim();
                bank.BankName = textBankName.Value.Trim();
                bank.BankAccountUser = textBankAccountUser.Value.Trim();
                if (bankBLL.Add(bank) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('设置成功！');window.location.href='AccountSet.aspx';", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('设置失败!');", true);
                    return;
                }
            }
        }
        /// <summary>
        /// 财付通
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbtnRiches_Click(object sender, EventArgs e)
        {
            if (textRichesNum.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('财付通號不能为空!');", true);
                return;
            }
            if (textRichesName.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('财付通名稱不能为空!');", true);
                return;
            }
            lgk.Model.tb_systemBank bank = bankBLL.GetModel(getIntRequest("id"));
            bank.BankAccount = textRichesNum.Value.Trim();
            bank.BankAccountUser = textRichesName.Value.Trim();
            if (bankBLL.Update(bank))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('编辑成功！');window.location.href='AccountSet.aspx'", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('設置失败!');", true);
                return;
            }
        }
        /// <summary>
        /// 支付宝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkbtnPay_Click(object sender, EventArgs e)
        {
            if (textPayNum.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('支付宝號不能为空!');", true);
                return;
            }
            if (textPayName.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('支付宝名稱不能为空!');", true);
                return;
            }
            lgk.Model.tb_systemBank bank = bankBLL.GetModel(getIntRequest("id"));
            bank.BankAccount = textPayNum.Value.Trim();
            bank.BankAccountUser = textPayName.Value.Trim();
            if (bankBLL.Update(bank))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('编辑成功！');window.location.href='AccountSet.aspx'", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('設置失败!');", true);
                return;
            }
        }
    }
}
