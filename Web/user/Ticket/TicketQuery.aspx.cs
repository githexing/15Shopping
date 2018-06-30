using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Ticket
{
    public partial class TicketQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string uid = Request["UserID"].ToString();
                if (!string.IsNullOrEmpty(uid))
                {
                    Session.Add("UserID", uid);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请登录后再操作');", true);//没有这个用户
            }
        }
    }
}