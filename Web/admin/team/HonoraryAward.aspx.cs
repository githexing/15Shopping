using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.admin.team
{
    public partial class HonoraryAward : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //jumpMain(this, 2, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密碼
            if (!IsPostBack)
            {
                bind("");
            }
        }

        private void bind(string usercode)
        {
            bind_repeater(bo.GetHonorarayRs(getWhere(usercode)), Repeater1, "HonoraryAward_ID desc", trBonusNull, AspNetPager1);
        }

        private string getWhere(string usercode)
        {
            if (usercode != "")
            {
                return string.Format("select tb_HonoraryAward.HonoraryAward_ID, tb_user.UserCode,tb_HonoraryAward.UserID,tb_HonoraryAward.AwardTitle,tb_HonoraryAward.LeftCount,tb_HonoraryAward.RightCount,tb_HonoraryAward.AwardDetail from tb_HonoraryAward JOIN tb_user ON tb_HonoraryAward.UserID = tb_user.UserID where tb_user.UserCode = '" + usercode + "'");
            }
            else
            {
               return string.Format("select tb_HonoraryAward.HonoraryAward_ID, tb_user.UserCode,tb_HonoraryAward.UserID,tb_HonoraryAward.AwardTitle,tb_HonoraryAward.LeftCount,tb_HonoraryAward.RightCount,tb_HonoraryAward.AwardDetail from tb_HonoraryAward JOIN tb_user ON tb_HonoraryAward.UserID = tb_user.UserID");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind("");
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind("");
        }

        protected void idSearch_Click(object sender, EventArgs e)
        {
            string code = txtUserCode.Text.Trim();
            if (code != "")
            {
                bind(code);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请填写用户编号!');", true);
            }
        }

    }
}