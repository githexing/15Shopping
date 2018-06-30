using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.finance
{
    public partial class Bonus : PageCore// System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //spd.jumpUrl(this.Page, 1);//跳转二级密码
            if (!IsPostBack)
            {
                BindData();
                //Button1.Text = GetLanguage("AccountsQueries");//账户查询
                //Button4.Text = GetLanguage("Transfer");//账户转账
                btnSearch.Text = GetLanguage("Search");//搜索
            }
        }

        private void BindData()
        {

            bind_repeater(bo.GetList_money(GetWhere()), Repeater1, "SttleTime desc", tr1, AspNetPager1);
        }

        private string GetWhere()
        {
            string strWhere = "";
            strWhere = string.Format(" b.Amount <> 0 AND u.UserID = " + getLoginID());

            string strStart = txtStart.Text.Trim();
            string strEnd = txtEnd.Text.Trim();

            if (GetLanguage("LoginLable") == "en-us")
            {
                strStart = txtStartEn.Text.Trim();
                strEnd = txtEndEn.Text.Trim();
            }

            #region 时间
            if (strStart != "" && strEnd == "" && PageValidate.IsDateTime(strStart))
            {
                    strWhere += string.Format(" AND Convert(nvarchar(10),SttleTime,120) >= '" + strStart + "'");
            }
            else if (strStart == "" && strEnd != "" && PageValidate.IsDateTime(strEnd))
            {
                    strWhere += string.Format(" AND Convert(nvarchar(10),SttleTime,120) <= '" + strEnd + "'");
            }
            else if (strStart != "" && strEnd != "" && PageValidate.IsDateTime(strStart) && PageValidate.IsDateTime(strEnd))
            {
                    strWhere += string.Format(" AND Convert(nvarchar(10),SttleTime,120) BETWEEN '" + strStart + "' AND '" + strEnd + "'");
            }
            #endregion

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
    }
}