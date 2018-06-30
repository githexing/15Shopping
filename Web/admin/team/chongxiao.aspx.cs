/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-7-19 9:46:38 
 * 文 件 名：		chongxiao.cs 
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

namespace Web.admin.team
{
    public partial class chongxiao : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            bind_repeater(userBLL.GetList(getWhere()), Repeater1, "BonusAccount desc", divno, AspNetPager1);
        }
        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string getWhere()
        {
            string strWhere = "  IsOpend<>0 and BonusAccount>0";
            if (!string.IsNullOrEmpty(this.txtUserCode.Value.Trim()))
            {
                strWhere += " and UserCode like '%" + txtUserCode.Value.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(this.txtTrueName.Value.Trim()))
            {
                strWhere += " and TrueName like '%" + txtTrueName.Value.Trim() + "%'";
            }
            return strWhere;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Open"))
            {
                Response.Redirect("chongxiaoEdit.aspx?userid=" + Convert.ToInt32(e.CommandArgument));
            }
        }
    }
}
