using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.user.finance
{
    public partial class HonoraryAward : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码
            if (!IsPostBack)
            {
                bind(LoginUser.UserID);
            }
        }

        private void bind(long userid)
        {
            bind_repeater(bo.GetHonorarayRs(getWhere(userid)), Repeater1, "HonoraryAward_ID desc", trBonusNull, AspNetPager1);
        }

        private string getWhere(long userid)
        {
            //string strWhere = string.Format("select * from tb_HonoraryAward where userid=" + userid);
            string strWhere =
                string.Format("select h.HonoraryAward_ID, tb_user.UserCode,h.UserID,h.AwardTitle,h.LeftCount,h.RightCount,h.AwardDetail,h.EnAwardTitle,h.EnAwardDetail from tb_HonoraryAward h JOIN tb_user ON h.UserID = tb_user.UserID where h.UserID=" + userid);

            return strWhere;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind(LoginUser.UserID);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind(LoginUser.UserID);
        }
    }
}