/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-20 9:58:35 
 * 文 件 名：		member_jiaoyijilu.cs 
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
using System.Data;
using Library;

namespace Web.admin.licai
{
    public partial class member_jiaoyijilu : AdminPageBase//System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                bindMyDai();
            }
		}

        /// <summary>
        /// 用户待交易记录
        /// </summary>
        private void bindMyDai()
        {
            string StarTime = this.txtDaiStar.Text.Trim();
            string EndTime = this.txtDaiEnd.Text.Trim();
            string strWhere = string.Format("  status = 1 and UserType=1");
            if (this.txtDaiCode.Value != "")
            {
                strWhere += " and UserCode like '%" + this.txtDaiCode.Value.Trim() + "%'";
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
            bind_repeater(gp_notesBLL.GetList(strWhere), Repeater3, "BusinessTime desc", tr3, AspNetPager3);
        }
        protected string getType(int BusinessType)
        {
            if (BusinessType == 2)
            {
                return "买入交易";
            }
            return "卖出交易";
        }

        protected void btnDai_Click(object sender, EventArgs e)
        {
            bindMyDai();
        }

        protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        {
            bindMyDai();
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
