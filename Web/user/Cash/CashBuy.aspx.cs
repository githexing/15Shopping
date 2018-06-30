using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.user.Cash
{
    public partial class Cashbuy : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            btnSearch.Text = GetLanguage("Search");//搜索

            if (!IsPostBack)
            {
                BindAmount();
                BindData();
            }
        }

        private void BindAmount()
        {
            //if (currentCulture == "en-us")
            //{
            //    dropAmount.Items.Add(new ListItem("Price Range", "0"));
            //    dropAmount.Items.Add(new ListItem("1-300", "1"));
            //    dropAmount.Items.Add(new ListItem("301-1000", "2"));
            //    dropAmount.Items.Add(new ListItem("1000 Above", "3"));
            //}
            //else
            //{
            //    dropAmount.Items.Add(new ListItem("价格区间", "0"));
            //    dropAmount.Items.Add(new ListItem("1-300", "1"));
            //    dropAmount.Items.Add(new ListItem("301-1000", "2"));
            //    dropAmount.Items.Add(new ListItem("1000以上", "3"));
            //}
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            bind_repeater(cashsellBLL.GetInnerList(GetWhere()), Repeater1, "", tr1, AspNetPager1);
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "UnitNum<>SaleNum AND [Cashsell].[UserID]<>" + getLoginID() + " AND IsSell=1 AND [Cashsell].[IsUndo]=0";//

            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (currentCulture == "en-us")
            {
                strStartTime = txtStartEn.Text.Trim();
                strEndTime = txtEndEn.Text.Trim();
            }

            //if (this.dropAmount.SelectedValue != "0")
            //{
            //    int iAmount = int.Parse(dropAmount.SelectedValue);

            //    if (iAmount == 1)
            //        strWhere += "AND [Cashsell].[Amount] <= 300";
            //    else if (iAmount == 2)
            //        strWhere += "AND ([Cashsell].[Amount] > 300 AND [Cashsell].[Amount] <= 1000)";
            //    else if (iAmount == 3)
            //        strWhere += " AND [Cashsell].[Amount] > 1000";
            //}

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SellDate,120) >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),SellDate,120) <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),SellDate,120) between '" + strStartTime + "' and '" + strEndTime + "'");
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

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                long iUserID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "UserID"));
                int iUnitNum = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "UnitNum"));
                int iSaleNum = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "SaleNum"));

                Literal ltSValues = (Literal)e.Item.FindControl("ltSValues");//卖家评分
                LinkButton lbtnBuy = (LinkButton)e.Item.FindControl("lbtnBuy");//操作按钮

                int iValue = cashcreditBLL.GetValues(iUserID, "SValues");
                //if (iValue > 0)
                //{
                //    for (int i = 0; i < iValue; i++)
                //    {
                //        ltSValues.Text += "<img alt='' src='../../images/start.png' />";
                //    }
                //}

                if (iUnitNum == iSaleNum)
                    lbtnBuy.Visible = false;
                else
                    lbtnBuy.Visible = true;
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Buyinto")
            {
                long iCashsellID = Convert.ToInt64(e.CommandArgument);

                if (getParamInt("Gold1") == 0)
                {
                    MessageBox.Show(this, GetLanguage("Feature"));//该功能未开放
                    return;
                }

                //if (!SysTradeIsOpen())
                //{
                //    string strWeek = GetTradingWeekText();
                //    string tradingReminder = string.Format(GetLanguage("TradingReminder"), strWeek, getParamVarchar("GoldTradingTime"));
                //    MessageBox.ShowBox(this.Page, GetLanguage("TradingReminderTitle"), tradingReminder, Library.Enums.ModalTypes.warning);//请选择投资积分
                //    return;
                //}

                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "window.location.href='CashbuyEdit.aspx?CashsellID=" + iCashsellID + "';", true);//取消成功  
            }
        }
    }
}