using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.team
{
    public partial class MemberList : PageCore// System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                BindData();

                btnSearch.Text = GetLanguage("Search");//搜索
            }
        }

        /// <summary>
        ///查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strStart = txtStart.Text.Trim();
            string strEnd = txtEnd.Text.Trim();

            string strWhere = " RecommendID = " + LoginUser.UserID;

            #region 会员编号姓名
            if(!string.IsNullOrEmpty(this.txtUserCode.Value.Trim()))
                strWhere += " AND UserCode LIKE  '%" + this.txtUserCode.Value.Trim() + "%'";

            #endregion

            if (GetLanguage("LoginLable") == "en-us")
            {
                strStart = txtStartEn.Text.Trim();
                strEnd = txtEndEn.Text.Trim();
            }

            #region 开通时间
            if (strStart != "" && strEnd == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OpenTime,120) >= '" + strStart + "'");
            }
            else if (strStart == "" && strEnd != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OpenTime,120) <= '" + strEnd + "'");
            }
            else if (strStart != "" && strEnd != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OpenTime,120) BETWEEN '" + strStart + "' AND '" + strEnd + "'");
            }
            #endregion

            return strWhere;
        }

        /// <summary>
        /// 绑定已开通会员列表
        /// </summary>
        private void BindData()
        {
            bind_repeater(userBLL.GetOpenList(GetWhere()), Repeater1, "RegTime desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 搜索提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
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