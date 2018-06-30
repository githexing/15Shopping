using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.admin.finance
{
    public partial class CashTradeList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 16, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            bind_repeater(cashorderBLL.GetOrderList(GetWhere()), Repeater1, "OrderDate desc", tr1, AspNetPager1);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int iSUserID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "SUserID"));
                int iBUserID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "BUserID"));
                int iBStatus = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "BStatus"));
                int iSStatus = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "SStatus"));
                int iStatus = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status"));

                LinkButton lbtnSend = (LinkButton)e.Item.FindControl("lbtnSend");//确认付款
                Literal ltStatus = (Literal)e.Item.FindControl("ltStatus");//订单状态

                if (iSStatus == 1 && iBStatus == 1 && iStatus == 1)//已付款和已发货表明订单已完成交付，所以不能取消
                {
                    ltStatus.Text = "已完成";
                }
                else
                {
                    ltStatus.Text = "已撤销";
                }
            }
        }

        private string GetWhere()
        {
            string strWhere = "", strOrderCode = "";

            //购买状态(0未付款，1已付款，2已完成，3已终止)

            strWhere = "Status>=1";

            #region 订单编号
            strOrderCode = txtOrderCode.Text.Trim();
            if (strOrderCode != "")
                strWhere += " AND OrderCode='" + strOrderCode + "'";
            #endregion

            #region 下定时间
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OrderDate,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OrderDate,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OrderDate,120)  between '" + strStartTime + "' AND '" + strEndTime + "'");
            }
            #endregion

            return strWhere;
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
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
    }
}