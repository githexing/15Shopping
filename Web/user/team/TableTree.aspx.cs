/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-12-5 15:31:25 
 * 文 件 名：		TableTree.cs 
 * CLR 版本: 		2.0.50727.3643 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
  
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user.team
{
    public partial class TableTree : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSearch.Text = GetLanguage("Search");//搜索
                BindData();
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
            string usercode = SafeHelper.GetSafeSqlandHtml(this.txtUserCode.Value.Trim());
            string strWhere = "IsOpend = 2";

            strWhere += " AND (RecommendID = " + LoginUser.UserID + " OR RecommendPath LIKE '%" + LoginUser.RecommendPath + "-')";

            #region 会员编号姓名

            strWhere += " AND UserCode LIKE  '%" + usercode + "%'";

            #endregion

            if (GetLanguage("LoginLable") == "en-us")
            {
                strStart = txtStartEn.Text.Trim();
                strEnd = txtEndEn.Text.Trim();
            }

            #region 开通时间
            if (strStart != "" && strEnd == "" && PageValidate.IsDateTime(strStart))
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OpenTime,120) >= '" + strStart + "'");
            }
            else if (strStart == "" && strEnd != "" && PageValidate.IsDateTime(strStart) )
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OpenTime,120) <= '" + strEnd + "'");
            }
            else if (strStart != "" && strEnd != "" && PageValidate.IsDateTime(strStart) && PageValidate.IsDateTime(strEnd))
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OpenTime,120) BETWEEN '" + strStart + "' AND '" + strEnd + "'");
            }
            #endregion

            return strWhere;
        }

        private void BindData()
        {
            bind_repeater(userBLL.GetOpenList(GetWhere()), Repeater1, "OpenTime desc", tr1, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}