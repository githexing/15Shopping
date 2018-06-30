using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.member
{
    public partial class UserBank : PageCore//System.Web.UI.Page
    {
        public long MyUserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyUserID = getLoginID();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }

    }
}