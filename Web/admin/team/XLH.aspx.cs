using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.team
{
    public partial class XLH : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_user user = userBLL.GetModel(GetUserID(TextBox1.Text.Trim()));
            if (user == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('用户名不正确');", true);
                return;
            }
            //检验序列号
            string xlh = PageValidate.GetMd5(user.UserID.ToString()).ToUpper();
            LiteralAgent.Text = xlh;
        }
    }
}