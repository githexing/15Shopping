using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Mall
{
    public partial class GoodsList : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenu();
                BindData();
            }
        }

        public void BindMenu()
        {
            //类别
            IList<lgk.Model.tb_produceType> iList = new lgk.BLL.tb_produceType().GetModelList(" ParentID=0 and IsDeleted=0");
            RepeaterMenu.DataSource = iList;
            RepeaterMenu.DataBind();
        }

        public void BindData()
        {
            int iGtype = getIntRequest("gt");
            hdtype.Value = iGtype.ToString();
            hduid.Value = getLoginID().ToString();
            string strOrderBy = "[AddTime] desc";
            //int iSort = Convert.ToInt32(hfValue.Value);
            //if (iSort == 1)
            //{
            //    if (dropSort.SelectedValue == "1")
            //    {
            //        strOrderBy = "[AddTime] desc";
            //    }
            //    else if (dropSort.SelectedValue == "2")
            //    {
            //        strOrderBy = "[RealityPrice] desc";
            //    }
            //    else if (dropSort.SelectedValue == "3")
            //    {
            //        strOrderBy = "[RealityPrice] asc";
            //    }
            //}
            //else if (iSort == 2)
            //{
            //    if (dropSell.SelectedValue == "1")
            //    {
            //        strOrderBy = "[SaleNum] desc";
            //    }
            //}
            string strWhere = "";
            if (iGtype > 0)
            {
                strWhere = "g.Goods001=1 and g.Goods003=0 and g.StateType=1 and g.TypeID = " + iGtype;
            }
            else
            {
                strWhere = "g.Goods001=1 and g.Goods003=0 and g.StateType=1 ";
            }

            bind_repeater(goodsBLL.GetModelAndOneNameList(strWhere), RepeaterGoods, "AddTime desc", li1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

    }
}