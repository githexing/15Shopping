using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.finance
{
    public partial class OnlineRecharge : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBonus.Text = LoginUser.Emoney.ToString();
        }
        protected void btnTenpay_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("OnlineRechargeTenpay.aspx?RechargeAmount={0}", txtRechargeAmount.Text));
        }

        protected void btnAlipay_Click1(object sender, EventArgs e)
        {
            string amount = txtRechargeAmount.Text;
            if (PageValidate.IsNumberOrDecimal(amount))
            {
                if (Convert.ToDecimal( amount) <= 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('充值金额要大于 0 ！');window.location.href='OnlineRecharge.aspx';", true);  
                }
                else 
                    Response.Redirect(string.Format("OnlineRechargeAlipay.aspx?RechargeAmount={0}", amount));
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('输入的金额不合法，请重新输入！');window.location.href='OnlineRecharge.aspx';", true);

        }
    }
}