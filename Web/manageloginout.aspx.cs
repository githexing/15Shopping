/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-2-4 16:48:43 
 * 文 件 名：		manageloginout.cs 
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

namespace Web
{
    public partial class manageloginout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("a_pass");
            UserUtil.Logout();
            Session.Clear();
            lgk.BLL.SecondPasswordBLL76.AdminId = 0;//管理员以会员身份登陆会员前台页面后，作出标记
            Request.Cookies["A128076_admin"].Expires = DateTime.Now.AddDays(-2);
            Response.Cookies.Set(Request.Cookies["A128076_admin"]);
            Response.Write("<script>parent.window.location.href='ManageLogin.aspx'</script>"); 
        }
    }
}
