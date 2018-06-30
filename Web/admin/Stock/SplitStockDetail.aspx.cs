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

namespace Web.admin.Stock
{
    public partial class SplitStockDetail : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 6, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            bind_repeater(stockSplitDetailBLL.GetList(GetWhere()), Repeater1, "SplitDate desc", tr1, AspNetPager1);
        }

        private string GetWhere()
        {
            string strSplitID = "", strWhere = "";

            string StarTime = this.txtStar.Text.Trim();
            string EndTime = this.txtEnd.Text.Trim();

            if (PageValidate.IsInteger(Request.QueryString["SplitID"]))
                strSplitID = Request.QueryString["SplitID"].ToString().Trim();
            else
                strSplitID = "0";

            strWhere = string.Format("SplitID=" + strSplitID + "");
            if (this.txtUserCode.Value != "")
            {
                strWhere += " and UserCode like '%" + this.txtUserCode.Value + "%'";
            }
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SplitDate,120)  >= '" + StarTime + "' ");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SplitDate,120)  <= '" + EndTime + "' ");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SplitDate,120)  between '" + StarTime + "' and '" + EndTime + "' ");
            }

            return strWhere;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}