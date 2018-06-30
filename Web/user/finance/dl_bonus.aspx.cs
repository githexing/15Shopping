/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-11-29 10:23:58 
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

namespace Web.user.finance
{
    public partial class dl_bonus : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码
            if (!IsPostBack)
            {
                bind();
            }
        }
        private void bind()
        {

            bind_repeater(bo.GetList_money(getWhere()), Repeater1, "SttleTime desc", trBonusNull, AspNetPager1);
        }

        private string getWhere()
        {
            string strWhere = "";
            strWhere = string.Format(" b.Amount<>0  and u.UserID= " + getLoginID());
            if (txtStar.Text.Trim() != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SttleTime,120)  >= '" + txtStar.Text.Trim() + "'");
            }
            if (txtEnd.Text.Trim() != "")
            {
                strWhere += string.Format("  and Convert(nvarchar(10),SttleTime,120)  <= '" + txtEnd.Text.Trim() + "'");
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
