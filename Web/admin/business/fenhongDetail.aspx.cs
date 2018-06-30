using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Library;


namespace Web.admin.business
{
    public partial class fenhongDetail : AdminPageBase//System.Web.UI.Page
    {
        private string strWhere = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 14, getLoginID());//权限
            //if (Session["a_pass"] == null)
            //{
            //    spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            //    Session["a_pass"] = "on";
            //}
            if (!IsPostBack)
            {
                bind();
            }
        }
        private void bind()
        {
            bind_repeater(bo.Getfenhong1(getWhere()), Repeater1, "SttleTime desc", trBonusNull, AspNetPager1);
        }

        private string getWhere()
        {
            string SttleTime = Request.QueryString["FhTime"].ToString();
            strWhere = string.Format(" b.Amount>0  and DATEDIFF(DAY,SttleTime,'"+SttleTime+"')=0");
            if (this.txtUserCode.Text != "")
            {
                strWhere += " and u.usercode like '%" + this.txtUserCode.Text + "%'";
            }
            if (this.txtTrueName.Text != "")
            {
                strWhere += " and u.truename like '%" + this.txtTrueName.Text + "%'";
            }
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

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int userid = Convert.ToInt32(e.CommandArgument);
            string SttleTime = Request.QueryString["SttleTime"].ToString();
            if (e.CommandName.Equals("Open"))
            {
                Response.Redirect("BonusDetails.aspx?userid=" + userid + "&SttleTime=" + SttleTime);
            }
        }
    }
}