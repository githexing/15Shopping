/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-19 17:44:08 
 * 文 件 名：		NoticeList.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：
**********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Library;

namespace web.user.member
{
    public partial class NoticeList : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "1=1";

            var strTitle = SafeHelper.GetSafeSqlandHtml(this.txtTitle.Value.Trim()); 
            if (!string.IsNullOrEmpty(strTitle))
                strWhere += " AND NewsTitle LIKE '%" + strTitle + "%'";

            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (currentCulture == "en-us")
            {
                strStartTime = txtStartEn.Text.Trim();
                strEndTime = txtEndEn.Text.Trim();

                strWhere += " AND New01=1";
            }
            else
            {
                strWhere += " AND New01=0";
            }

            if (strStartTime != "" && strEndTime == "" && PageValidate.IsDateTime(strStartTime))
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),PublishTime,120) >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "" && PageValidate.IsDateTime(strEndTime))
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),PublishTime,120) <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "" && PageValidate.IsDateTime(strStartTime) && PageValidate.IsDateTime(strEndTime))
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),PublishTime,120) between '" + strStartTime + "' and '" + strEndTime + "'");
            }

            return strWhere;
        }

        /// <summary>
        /// 填充信息
        /// </summary>
        protected void BindData()
        {
            bind_repeater(newsBLL.GetList(GetWhere()), Repeater1, "PublishTime desc", tr1, AspNetPager1);
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
