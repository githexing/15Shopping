using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using DataAccess;
using System.Data;

namespace Web.admin.Stock
{
    public partial class StockAudit : AdminPageBase
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
            bind_repeater(stockBuyBLL.GetInnerList(GetWhere()), Repeater1, "BuyDate ASC", tr1, AspNetPager1);
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int iIsBuy = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "IsBuy"));

                Literal ltIsBuy = (Literal)e.Item.FindControl("ltIsBuy");

                if (iIsBuy == 0)//购买状态(0等待买入，1购买中，2购买完毕)
                    ltIsBuy.Text = "等待买入";
                else if (iIsBuy == 1)
                    ltIsBuy.Text = "购买中";
                else if (iIsBuy == 2)
                    ltIsBuy.Text = "已完成";
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                long iStockBuyID = Convert.ToInt64(e.CommandArgument);
                lgk.Model.tb_StockBuy stockBuyInfo = stockBuyBLL.GetModel(iStockBuyID);
                if (stockBuyInfo == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordDeleted") + "');", true);//该记录已删除，无法再进行此操作
                    return;
                }
                if (stockBuyInfo.IsBuy != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordApproved") + "');", true);//该记录已审核，无法再进行此操作
                    return;
                }

                stockBuyInfo.IsBuy = 1;

                if (stockBuyBLL.Update(stockBuyInfo))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('审核成功！');window.location.href='StockAudit.aspx';", true);//审核成功
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('审核失败！');", true);//审核失败
                }
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}