/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-11-29 10:31:17 
 * 文 件 名：		dl_bonus.cs 
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

namespace Web.admin.finance
{
    public partial class dl_bonus : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 15, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                bind();
            }
        }
        private void bind()
        {
            bind_repeater(bo.GetAList(getWhere()), Repeater1, "SttleTime desc", trBonusNull, AspNetPager1);
        }

        private string getWhere()
        {
            string strWhere = "";
            string StarTime = this.txtStar.Text.Trim();
            string EndTime = txtEnd.Text.Trim();

            strWhere = string.Format("  Amount<>0 and Bonus001=2 ");
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SttleTime,120)  >= '" + StarTime + "'");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format("  and Convert(nvarchar(10),SttleTime,120)  <= '" + EndTime + "'");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format("  and Convert(nvarchar(10),SttleTime,120)  between '" + StarTime + "' and '" + EndTime + "'");
            }
            return strWhere;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
    }
}
