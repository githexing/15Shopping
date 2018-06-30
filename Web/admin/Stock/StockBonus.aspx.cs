using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Library;

namespace Web.admin.Stock
{
    public partial class StockBonus : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 6, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            bind_repeater(stockBLL.GetList(GetWhere()), Repeater1, "BuyDate desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "", strWhereOne = "", strList = "";

            string strStarTime = txtStar.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();
            string strName = txtName.Value.Trim();

            if (this.dropType.SelectedValue != "0")
            {
                strWhereOne = "(IsOpend=2 OR IsOpend=3) AND AccountType=0 ";

                if (this.dropType.SelectedValue == "1" && strName != "")
                {
                    strWhereOne += " and UserCode like '%" + strName + "%'";
                }
                if (this.dropType.SelectedValue == "2" && strName != "")
                {
                    strWhereOne += " and TrueName like '%" + strName + "%'";
                }

                DataSet ds = userBLL.GetList(strWhereOne);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i == ds.Tables[0].Rows.Count - 1)
                        {
                            strList += ds.Tables[0].Rows[i]["UserID"].ToString();
                        }
                        else
                        {
                            strList += ds.Tables[0].Rows[i]["UserID"].ToString() + ",";
                        }
                    }

                    if (strList != "")
                        strWhere = "UserID in (" + strList + ")";
                    else
                        strWhere = "UserID=0";
                }
            }

            if (strWhere != "")
            {
                if (strStarTime != "" && strEndTime == "")
                {
                    strWhere += string.Format(" and Convert(nvarchar(10),BuyDate,120)  >= '" + strStarTime + "' ");
                }
                else if (strStarTime == "" && strEndTime != "")
                {
                    strWhere += string.Format(" and Convert(nvarchar(10),BuyDate,120)  <= '" + strEndTime + "' ");
                }
                else if (strStarTime != "" && strEndTime != "")
                {
                    strWhere += string.Format(" and Convert(nvarchar(10),BuyDate,120)  between '" + strStarTime + "' and '" + strEndTime + "' ");
                }
            }
            else
            {
                if (strStarTime != "" && strEndTime == "")
                {
                    strWhere += string.Format(" Convert(nvarchar(10),BuyDate,120)  >= '" + strStarTime + "' ");
                }
                else if (strStarTime == "" && strEndTime != "")
                {
                    strWhere += string.Format(" Convert(nvarchar(10),BuyDate,120)  <= '" + strEndTime + "' ");
                }
                else if (strStarTime != "" && strEndTime != "")
                {
                    strWhere += string.Format(" Convert(nvarchar(10),BuyDate,120)  between '" + strStarTime + "' and '" + strEndTime + "' ");
                }
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
                int iUserID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "UserID"));
                int iStockID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "StockID"));

                //会员编号
                Literal ltUserCode = (Literal)e.Item.FindControl("ltUserCode");
                Literal ltTrueName = (Literal)e.Item.FindControl("ltTrueName");
                Literal ltProfit = (Literal)e.Item.FindControl("ltProfit");

                lgk.Model.tb_Stock stockInfo = stockBLL.GetModel(iStockID);
                ltProfit.Text = Convert.ToString(stockInfo.Number * (getParamAmount("shares5") - stockInfo.Price));

                lgk.Model.tb_user userInfo = userBLL.GetModel(iUserID);
                ltUserCode.Text = userInfo.UserCode;
                ltTrueName.Text = userInfo.TrueName;
            }
        }
    }
}