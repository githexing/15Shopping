using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.userControl
{
    public partial class Left : BaseControl
    {
        public int aa { get; set; } = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(LoginUser != null)
            {
                ltUserCode.Text = LoginUser.UserCode;
                aa = LoginUser.IsAgent;

            }
       
        }
    }
}