/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-4-19 18:09:59 
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
namespace web.user.member
{
    public partial class WealthPlan : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                Session["reurl"] = Request.Path;
            }
        }

        /// <summary>
        /// 填充信息
        /// </summary>
        protected void BindData()
        {
            //lgk.Model.tb_wealth wealth = wealthBLL.GetModel();
            string cnen = GetLanguage("LoginLable");
            int langType = cnen.Equals("zh-cn") ? 0 : 1;
            lgk.Model.tb_news data = newsBLL.GetModelByNewType(7, langType);
            if (data == null)
            {
                lbTitle.Text = GetLanguage("terms");//服务条款
                lilContent.Text = "<span style='color:red;'>" + GetLanguage("Manager") + "</span>";
            }
            else
            {
                lbTitle.Text = data.NewsTitle;
                lilContent.Text = data.NewsContent;
            }
        }
    }
}
