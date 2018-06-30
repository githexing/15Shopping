using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 

namespace Web.user.Mall
{
    public partial class ItemList : AllCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["st"] != null && Request.QueryString["st"] != "")
                {
                    ViewState["ItemListSort"] = 1; 
                    BindData();
                 
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "history.back();", true);
                }
            }
        }

        public void BindData()
        {
            string isearch = SafeHelper.NoHtml((Request.QueryString["st"]));
            ltSearch.Text = isearch;
            string strOrderBy = "";
            string strSort = ViewState["ItemListSort"].ToString();
            if (strSort == "1")
            {
                if (dropSort.SelectedValue == "1")
                {
                    strOrderBy = "[AddTime] desc";
                }
                else if (dropSort.SelectedValue == "2")
                {
                    strOrderBy = "[RealityPrice] desc";
                }
                else if (dropSort.SelectedValue == "3")
                {
                    strOrderBy = "[RealityPrice] asc";
                }
            }
            else if (strSort == "2")
            {
                if (dropSell.SelectedValue == "1")
                {
                    strOrderBy = "[SaleNum] desc";
                }
            }
            bind_repeater(goodsBLL.GetList(1000, "g.Goods001=1 and g.Goods003=0 and g.GoodsName like '%" + isearch + "%'", strOrderBy), Repeater1, "AddTime desc", li1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void dropSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["ItemListSort"] = 1;
            BindData();
        }

        protected void dropSell_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["ItemListSort"] = 2;
            BindData();
        }

    }
}