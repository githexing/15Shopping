using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.cash
{
    public partial class CashOrderList : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 47, getLoginID());//权限

            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region 查询条件
        public string GetWhere()
        {
            string strWhere = " 1=1 ";

            int type = Convert.ToInt32(dropType.SelectedValue);
            string strInput = txtInput.Value.Trim();
            if (!string.IsNullOrEmpty(strInput))
            {
                if (type == 1)
                {
                    strWhere += " and bu.UserCode like '%" + strInput + "%'";
                }
                else if (type == 2)
                {
                    strWhere += " and su.UserCode like '%" + strInput + "%'";
                }
                else if (type == 3)
                {
                    strWhere += " and o.OrderCode like '%" + strInput + "%'";
                }
                else if (type == 4)
                {
                    strWhere += " and b.OrderCode like '%" + strInput + "%'";
                }
                else if (type == 5)
                {
                    strWhere += " and s.OrderCode like '%" + strInput + "%'";
                }
            }
            string strStart = txtStart.Text.Trim();
            string strEnd = txtEnd.Text.Trim();

            if (strStart != "" && strEnd == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),o.OrderDate,120) >= '" + strStart + "'");
            }
            else if (strStart == "" && strEnd != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),o.OrderDate,120) <= '" + strEnd + "'");
            }
            else if (strStart != "" && strEnd != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),o.OrderDate,120) between '" + strStart + "' and '" + strEnd + "'");
            }

            return strWhere;
        }
        #endregion

        public void BindData()
        {
            bind_repeater(cashorderBLL.GetOrderList(0,GetWhere(), "order by o.OrderDate desc"), Repeater1, "", tr1, AspNetPager1);
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