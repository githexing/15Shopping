using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.finance
{
    public partial class RemitVoucher : AdminPageBase
    {
        string name = System.Web.Configuration.WebConfigurationManager.AppSettings["ImgAdminUrl"];
        protected void Page_Load(object sender, EventArgs e)
        {
            long id = Convert.ToInt32(Request.Params["ID"]);
            if (id != 0)
            {
                lgk.Model.tb_remit remit = remitBLL.GetModel(id);
                remitimg.ImageUrl = name+remit.Remit005;
            }
        }

        protected void lbtnVerify_Click(object sender, EventArgs e)
        {
            Response.Redirect("RemitManage.aspx");
        }
    }
}