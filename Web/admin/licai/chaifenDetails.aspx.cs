using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library;

namespace Web.admin.licai
{
    public partial class chaifenDetails : AdminPageBase//System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            bindSplit();
        }

        private void bindSplit()
        {
            string StarTime = this.txtStar.Text.Trim();
            string EndTime = this.txtEnd.Text.Trim();
            string sj = Request.QueryString["cfsj"].ToString();
            string strWhere = string.Format(" Split01=1 and Convert(nvarchar(10),SplitStockTime,120)='" + sj + "'");
            if (this.txtUserCode.Value != "")
            {
                strWhere += " and usercode like '%" + this.txtUserCode.Value + "%'";
            }
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SplitStockTime,120)  >= '" + StarTime + "' ");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SplitStockTime,120)  <= '" + EndTime + "' ");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SplitStockTime,120)  between '" + StarTime + "' and '" + EndTime + "' ");
            }
            bind_repeater(gp_ssBLL.GetList(strWhere), Repeater1, "SplitStockTime desc", tr1, AspNetPager2);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindSplit();
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            bindSplit();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("chaifen.aspx");
        }
    }
}
