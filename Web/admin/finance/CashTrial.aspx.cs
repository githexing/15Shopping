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
    public partial class CashTrial_aspx : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 16, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转二级密码

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
            bind_repeater(cashsellBLL.GetInnerList(GetWhere()), Repeater1, "Price desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "IsSell=0";

            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),SellDate,120) >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),SellDate,120) <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),SellDate,120) between '" + strStartTime + "' AND '" + strEndTime + "'");
            }

            return strWhere;
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
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
                int iUserID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "UserID"));
                Literal ltSValues = (Literal)e.Item.FindControl("ltSValues");//卖家评分

                int iValue = cashcreditBLL.GetValues(iUserID, "SValues");
                if (iValue > 0)
                {
                    for (int i = 0; i < iValue; i++)
                    {
                        ltSValues.Text += "<img alt='' src='../../images/start.png' />";
                    }
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Trial")
            {
                int iCashsellID = Convert.ToInt32(e.CommandArgument);
                lgk.Model.Cashsell cashsellInfo = cashsellBLL.GetModel(iCashsellID);

                cashsellInfo.IsSell = 1;

                if (cashsellBLL.Update(cashsellInfo))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('审批成功');", true);//审批成功
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('审批失败');", true);//审批失败
                }
            }

            BindData();
        }

    }
}