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
    public partial class AdBonus : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码
            if (!IsPostBack)
            {
                bind();
            }
        }

        private void bind()
        {

            bind_repeater(bo.GetList_AdBonus(getWhere()), Repeater1, "ID desc", trBonusNull, AspNetPager1);
        }

        private string getWhere()
        {
            string strWhere = "";
            strWhere = string.Format("select * from tb_bonus where UserID= " + getLoginID());

            return strWhere;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
    }
}