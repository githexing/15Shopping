/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-6-2 10:22:09 
 * 文 件 名：		member_buy.cs 
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
    public partial class member_buy : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindMyMaiRu();
            }
        }
        /// <summary>
        /// 用户买入记录
        /// </summary>
        private void bindMyMaiRu()
        {
            string StarTime = this.txtMairuStar.Text.Trim();
            string EndTime = this.txtMairuEnd.Text.Trim();
            string strWhere = string.Format(" BusinessType = 2 and status = 2 and UserType=1");
            if (this.txtMairuCode.Value != "")
            {
                strWhere += " and UserCode like '%" + this.txtMairuCode.Value.Trim() + "%'";
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
            bind_repeater(gp_notesBLL.GetList(strWhere), Repeater1, "BusinessTime desc", tr1, AspNetPager1);
        }
        protected string getType(int BusinessType)
        {
            if (BusinessType == 2)
            {
                return "买入交易";
            }
            return "卖出交易";
        }
        protected void btnMairu_Click(object sender, EventArgs e)
        {
            bindMyMaiRu();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bindMyMaiRu();
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
