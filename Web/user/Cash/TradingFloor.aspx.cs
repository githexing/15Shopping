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
    public partial class TradingFloor : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
   

            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            string strWhere1 = "UnitNum<>SaleNum AND [Cashsell].[UserID]<>" + getLoginID() + " AND IsSell=1 AND [Cashsell].[IsUndo]=0";//

            bind_repeater(cashsellBLL.GetInnerList(strWhere1), Repeater1, "", tr1, AspNetPager1);
            //bind_repeater((cashsellBLL.GetInnerList(strWhere1), Repeater1, "", tr1, 10);

            //string strWhere2 = "Number<>Quantity AND [Purchase].[UserID]<>" + getLoginID() + " AND IsPur=1";

            //bind_repeater(purchaseBLL.GetInnerList(strWhere2), Repeater2, "", tr2, 10);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                long iUserID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "UserID"));
                int iUnitNum = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "UnitNum"));
                int iSaleNum = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "SaleNum"));

                //Literal ltSValues = (Literal)e.Item.FindControl("ltSValues");//卖家评分
                LinkButton lbtnBuy = (LinkButton)e.Item.FindControl("lbtnBuy");//操作按钮

                int iValue = cashcreditBLL.GetValues(iUserID, "SValues");
                //if (iValue > 0)
                //{
                //    for (int i = 0; i < iValue; i++)
                //    {
                //        ltSValues.Text += "<img alt='' style='width:15px; height:15px' src='../../images/start.png' />";
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

        /// <summary>
        /// 分页提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            //{
            //    int iUserID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "UserID"));
            //    int iNumber = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Number"));//求购数量
            //    int iQuantity = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Quantity"));//已购数量

            //    Literal ltBValues = (Literal)e.Item.FindControl("ltBValues");//买家评分
            //    LinkButton lbtnSell = (LinkButton)e.Item.FindControl("lbtnSell");//操作按钮

            //    int iValue = cashcreditBLL.GetValues(iUserID, "BValues");
            //    if (iValue > 0)
            //    {
            //        for (int i = 0; i < iValue; i++)
            //        {
            //            ltBValues.Text += "<img alt='' style='width:15px; height:15px' src='../../images/start.png' />";
            //        }
            //    }

            //    if (iNumber == iQuantity)
            //        lbtnSell.Visible = false;
            //    else
            //        lbtnSell.Visible = true;
            //}
        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //if (e.CommandName == "SellTo")
            //{
            //    int iPurchaseID = Convert.ToInt32(e.CommandArgument);

            //    if (getParamInt("Gold1") == 0)
            //    {
            //        MessageBox.Show(this, GetLanguage("Feature"));//该功能未开放
            //        return;
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "window.location.href='PurchaseEdit.aspx?PurchaseID=" + iPurchaseID + "';", true);//取消成功
            //    }
            //}
        }
    }
}