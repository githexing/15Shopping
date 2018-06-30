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
    public partial class CashbuyList : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            btnSearch.Text = GetLanguage("Search");//搜索

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
            bind_repeater(cashbuyBLL.GetInnerList(GetWhere()), Repeater1, "BuyDate desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "[Cashbuy].[UserID]=" + getLoginID() + "";

            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (currentCulture == "en-us")
            {
                strStartTime = txtStartEn.Text.Trim();
                strEndTime = txtEndEn.Text.Trim();
            }

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
                long iSUserID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "SUserID"));
                int iIsBuy = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "IsBuy"));

                Literal ltBUserCode = (Literal)e.Item.FindControl("ltBUserCode");//买家
                Literal ltSUserCode = (Literal)e.Item.FindControl("ltSUserCode");//卖家
                //Literal ltSValues = (Literal)e.Item.FindControl("ltSValues");//卖家评分
                Literal ltIsBuy = (Literal)e.Item.FindControl("ltIsBuy");//状态

                ltBUserCode.Text = userBLL.GetUserCode(iUserID);
                ltSUserCode.Text = userBLL.GetUserCode(iSUserID);

                int iValue = cashcreditBLL.GetValues(iUserID, "SValues");
                if (iValue > 0)
                {
                    //for (int i = 0; i < iValue; i++)
                    //{
                    //    ltSValues.Text += "<img alt='' src='../../images/start.png' />";
                    //}
                }

                if (currentCulture == "en-us")
                {
                    if (iIsBuy == 0)
                        ltIsBuy.Text = "Not Paid";
                    else if (iIsBuy == 1)
                        ltIsBuy.Text = "Non delivery";
                    else if (iIsBuy == 2)
                        ltIsBuy.Text = "Complete";
                }
                else
                {
                    if (iIsBuy == 0)
                        ltIsBuy.Text = "未付款";
                    else if (iIsBuy == 1)
                        ltIsBuy.Text = "未发货";
                    else if (iIsBuy == 2)
                        ltIsBuy.Text = "完成";
                }
            }
        }
    }
}