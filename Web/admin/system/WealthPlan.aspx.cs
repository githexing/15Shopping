/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-19 16:15:23 
 * 文 件 名：		WealthPlan.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		黎胜刚
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
using Library;

namespace web.admin.system
{
    public partial class WealthPlan : AdminPageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 24, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 填充按钮
        /// </summary>
        protected void BindData()
        {
            lgk.Model.tb_wealth wealth = wealthBLL.GetModel();
            if (wealth != null)
            {
                textPubContext.Text = wealth.WealthContent;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string t = textPubContext.Text.ToString().Trim().Replace("&nbsp;", "");
            if (t.Length <= 7)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('财富计划内容不能为空!');", true);
                return;
            }
            lgk.Model.tb_wealth wealth = wealthBLL.GetModel();
            if (wealth != null)
            {
                wealth.WealthContent = textPubContext.Text;
                if (wealthBLL.Update(wealth))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改失败!');", true);
                }
            }
            else
            {
                wealth = new lgk.Model.tb_wealth();
                wealth.WealthContent = textPubContext.Text;
                if (wealthBLL.Add(wealth) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('添加成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('添加失败!');", true);
                }
            }
        }
    }
}
