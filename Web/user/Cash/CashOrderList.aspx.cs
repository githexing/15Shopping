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
    public partial class CashOrderList : PageCore
    {
        /// <summary>
        /// 登录用户编号
        /// </summary>
        private long iUserID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
         

            iUserID = getLoginID();

            btnSearch.Text = GetLanguage("Search");//搜索

            if (!IsPostBack)
            {
                OrderType();
                BindData();
            }
        }

        private void OrderType()
        {
            if (currentCulture == "en-us")
            {
                dropOrderType.Items.Add(new ListItem("All", "0"));
                dropOrderType.Items.Add(new ListItem("Sell", "1"));
                dropOrderType.Items.Add(new ListItem("Buy", "2"));
            }
            else
            {
                dropOrderType.Items.Add(new ListItem("全部", "0"));
                dropOrderType.Items.Add(new ListItem("出售", "1"));
                dropOrderType.Items.Add(new ListItem("购买", "2"));
            }
        }

        private void BindData()
        {
            bind_repeater(cashorderBLL.GetOrderList(GetWhere()), Repeater1, "OrderDate desc", tr1, AspNetPager1);
        }

        private string GetWhere()
        {
            int iType = Convert.ToInt32(this.dropOrderType.SelectedValue);
            string strWhere = "", strOrderCode = "";

            #region 订单类型
            if (iType == 0)
                strWhere = "(SUserID=" + iUserID + " OR BUserID=" + iUserID + ")";
            else if (iType == 1)
                strWhere = "SUserID=" + iUserID + "";
            else if (iType == 2)
                strWhere = "BUserID=" + iUserID + "";
            #endregion

            #region 订单编号
            strOrderCode = txtOrderCode.Text.Trim();
            if (strOrderCode != "")
                strWhere += " AND OrderCode='" + strOrderCode + "'";
            #endregion

            #region 下定时间
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (currentCulture == "en-us")
            {
                strStartTime = txtStartEn.Text.Trim();
                strEndTime = txtEndEn.Text.Trim();
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OrderDate,120) >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OrderDate,120) <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OrderDate,120) between '" + strStartTime + "' AND '" + strEndTime + "'");
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
                long iSUserID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "SUserID"));
                long iBUserID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "BUserID"));
                int iBStatus = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "BStatus"));
                int iSStatus = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "SStatus"));
                int iStatus = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status"));
                int iIsFeedback = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "IsFeedback"));

                LinkButton lbtnPayfor = (LinkButton)e.Item.FindControl("lbtnPayfor");//确认付款
                LinkButton lbtnPayforEn = (LinkButton)e.Item.FindControl("lbtnPayforEn");//确认付款
                LinkButton lbtnSendout = (LinkButton)e.Item.FindControl("lbtnSendout");//已确认付款
                LinkButton lbtnSendoutEn = (LinkButton)e.Item.FindControl("lbtnSendoutEn");//已确认付款
                LinkButton lbtnUndone = (LinkButton)e.Item.FindControl("lbtnUndone");//撤销
                LinkButton lbtnUndoneEn = (LinkButton)e.Item.FindControl("lbtnUndoneEn");//撤销
                Literal ltStatus = (Literal)e.Item.FindControl("ltStatus");//订单状态
                LinkButton lbtnNoGetPay = (LinkButton)e.Item.FindControl("lbtnNoGetPay");//未收到付款
                

                if (iUserID == iBUserID && iSStatus == 0 && iBStatus == 0)
                {
                    lbtnPayfor.Visible = true;//付款
                    lbtnPayforEn.Visible = true;
                    lbtnSendout.Visible = false;//付款
                    lbtnSendoutEn.Visible = false;//付款
                    lbtnUndone.Visible = false;
                    lbtnUndoneEn.Visible = false;
                    lbtnNoGetPay.Visible = false; //未收到付款
                }
                else if (iUserID == iSUserID && iSStatus == 0 && iBStatus == 1)
                {
                    lbtnPayfor.Visible = false;//付款
                    lbtnPayforEn.Visible = false;//付款
                    lbtnSendout.Visible = iIsFeedback == 0;//确认已付款
                    lbtnSendoutEn.Visible = true;//确认已付款
                    lbtnUndone.Visible = false;
                    lbtnUndoneEn.Visible = false;
                    lbtnNoGetPay.Visible = iIsFeedback == 0; //未收到付款
                }
                else
                {
                    lbtnPayfor.Visible = false;//确认付款
                    lbtnPayforEn.Visible = false;
                    lbtnSendout.Visible = false;//确认已付款
                    lbtnSendoutEn.Visible = false;//确认已付款
                    lbtnUndone.Visible = false;
                    lbtnUndoneEn.Visible = false;
                    lbtnNoGetPay.Visible = false; //未收到付款
                }

                if (iSStatus == 0 && iBStatus == 0)
                {
                    //ltStatus.Text = "等待付款！";
                    ltStatus.Text = GetLanguage("WaitingPay");
                }
                if (iSStatus == 0 && iBStatus == 1)
                {
                    if(iIsFeedback == 1)
                        ltStatus.Text = GetLanguage("WaitingConfirmPayWait");//未收到付款，待审核
                    else
                        ltStatus.Text = GetLanguage("WaitingConfirmPay");//"确认付款中！";

                }
                //已付款和已发货表明订单已完成交付，所以不能取消
                if (iSStatus == 1 && iBStatus == 1 && iStatus == 0)
                {
                    //ltStatus.Text = "等待发货！";
                    ltStatus.Text = GetLanguage("WaitingDelivery");
                }
                else if (iStatus == 1)
                {
                    //ltStatus.Text = "已完成";
                    ltStatus.Text = GetLanguage("Completed");
                }
                else if (iStatus == 2 || iSStatus == 2 || iBStatus == 2)
                {
                    //ltStatus.Text = "已撤销";
                    ltStatus.Text = GetLanguage("Undone");
                }
                else if (iStatus == 3)
                {
                    //ltStatus.Text = "已冻结";
                    ltStatus.Text = GetLanguage("Freezed");
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long iOrderID = Convert.ToInt64(e.CommandArgument);

            if (e.CommandName == "Payfor")
            {
                //付款
                Response.Redirect("CheckOrder.aspx?Action=" + iOrderID + ",1");
            }

            if (e.CommandName == "Sendout")
            {
                //确认已付款
                Response.Redirect("CheckOrder.aspx?Action=" + iOrderID + ",2");
            }

            if (e.CommandName == "Undone")
            {
                //确认已付款
                Response.Redirect("CancelOrder.aspx?Action=" + iOrderID + ",1");
            }
            if(e.CommandName == "NoGetPay")
            {
                //未收到付款
                Response.Redirect("Feedback.aspx?Action=" + iOrderID + ",1");
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}