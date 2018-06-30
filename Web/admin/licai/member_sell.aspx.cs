/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-6-2 10:22:25 
 * 文 件 名：		member_sell.cs 
 * CLR 版本: 		2.0.50727.3053 
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

namespace Web.admin.licai
{
    public partial class member_sell : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindMyMaiChu();
            }
        }
        /// <summary>
        /// 用户卖出记录
        /// </summary>
        private void bindMyMaiChu()
        {
            string StarTime = this.txtMaichuStar.Text.Trim();
            string EndTime = this.txtMaichuEnd.Text.Trim();
            string strWhere = string.Format(" BusinessType = 1 and status = 2  and UserType=1");
            if (this.txtMaichuCode.Value != "")
            {
                strWhere += " and UserCode like '%" + this.txtMaichuCode.Value.Trim() + "%'";
            }
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),BusinessTime,120)  >= '" + StarTime + "' ");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),BusinessTime,120)  <= '" + EndTime + "' ");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),BusinessTime,120)  between '" + StarTime + "' and '" + EndTime + "' ");
            }
            bind_repeater(gp_notesBLL.GetList(strWhere), Repeater2, "BusinessTime desc", tr2, AspNetPager2);
        }
        protected string getType(int BusinessType)
        {
            if (BusinessType == 2)
            {
                return "买入交易";
            }
            return "卖出交易";
        }

        protected void btnMaichu_Click(object sender, EventArgs e)
        {
            bindMyMaiChu();
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            bindMyMaiChu();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("member_buy.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("member_sell.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("member_jiaoyijilu.aspx");
        }
    }
}
