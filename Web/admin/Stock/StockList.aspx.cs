using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.admin.Stock
{
    public partial class StockList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            bind_repeater(stockBLL.GetInnerList(GetWhere()), Repeater1, "BuyDate ASC", tr1, AspNetPager1);
        }

        private string GetWhere()
        {
            string strWhere = "1=1";

            string strUserCode = this.txtUserCode.Text.Trim();
            if (!string.IsNullOrEmpty(strUserCode))
                strWhere += " AND UserCode LIKE '%" + strUserCode + "%'";

            #region 下定时间
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120) >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120) <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),BuyDate,120) between '" + strStartTime + "' AND '" + strEndTime + "'");
            }
            #endregion

            return strWhere;
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                long iStockID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "StockID"));

                Literal ltIsBuy = (Literal)e.Item.FindControl("ltIsBuy");

                lgk.Model.tb_Stock stockInfo = stockBLL.GetModel(iStockID);

                if (stockInfo.IsSell == 0)//0持有，1挂单，2已生成订单卖出中,3已卖出
                    ltIsBuy.Text = "持有";
                else if (stockInfo.IsSell == 1)
                    ltIsBuy.Text = "挂单";
                else if (stockInfo.IsSell == 2)
                    ltIsBuy.Text = "卖出中";
                else if (stockInfo.IsSell == 3)
                    ltIsBuy.Text = "已卖出";
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}