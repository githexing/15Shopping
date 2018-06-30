using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.finance
{
    public partial class OnlineRechargeAlipay : PageCore
    {
        public string AlipayAccount { get; set; }
        public string PayAmount { get; set; }
        public string out_trade_no { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            AlipayAccount = getParamVarchar("AlipayAccount");

            if (Request.QueryString["RechargeAmount"] != null)
            {
                PayAmount = Request.QueryString["RechargeAmount"].ToString();        
            }
            memo.Text = LoginUser.UserCode;
        }

      

    }
}