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
    public partial class CashExaminat : AdminPageBase
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
            bind_repeater(purchaseBLL.GetInnerList(GetWhere()), Repeater1, "", tr1, AspNetPager1);
        }

        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            string strWhere = "IsPur=0";

            string strUserCode = this.txtUserCode.Text.Trim();
            if (!string.IsNullOrEmpty(strUserCode))
                strWhere += " AND UserCode like '%" + strUserCode + "%'";

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),RegTime,120) >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),RegTime,120) <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),RegTime,120) BETWEEN '" + strStartTime + "' AND '" + strEndTime + "'");
            }
            return strWhere;
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                long iUserID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "UserID"));

                Literal ltBValues = (Literal)e.Item.FindControl("ltBValues");//买家评分

                int iValue = cashcreditBLL.GetValues(iUserID, "BValues");
                if (iValue > 0)
                {
                    for (int i = 0; i < iValue; i++)
                    {
                        ltBValues.Text += "<img alt='' src='../../images/start.png' />";
                    }
                }
            }
        }

        /// <summary>
        /// 审核分页申请记录
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long iPurchaseID = long.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_Purchase model = purchaseBLL.GetModel(iPurchaseID);
            if (model == null)
            {
                MessageBox.MyShow(this, "该求购信息删除,无法再进行此操作!");
                return;
            }
            if (model.IsPur != 0)
            {
                MessageBox.MyShow(this, "该求购信息已审核,无法再进行此操作!");
                return;
            }
            if (e.CommandName.Equals("Examinat"))//审核
            {
                Response.Redirect("PurchaseExam.aspx?PurchaseID=" + iPurchaseID + "");
            }
            if (e.CommandName.Equals("Remove"))//删除
            {
                if (purchaseBLL.Delete(iPurchaseID))
                {
                    MessageBox.MyShow(this, "删除成功!");
                }
                else
                {
                    MessageBox.MyShow(this, "删除失败!");
                }
            }
            BindData();
        }

        /// <summary>
        /// 分页申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}