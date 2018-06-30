using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.admin.product
{
    public partial class JinpaiList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 49, getLoginID());//权限
            if (!IsPostBack)
            {
                //竞拍
                gp_opBLL.ExecProc("proc_salesroom");
                bind();
            }
        }
        string getrequest()
        {
            if (Request.QueryString["id"] != null)
            {
                return " SaNumber='"+Request.QueryString["id"].ToString()+"'";
            }
            return "";
        }
        void bind() 
        {
            bind_repeater(auctionBll.GetList(getrequest()), rptProduct, "SaNumber asc,AuctionTime desc", tr1, AspNetPager1);
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
    }
}