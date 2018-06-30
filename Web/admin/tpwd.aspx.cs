/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-6-30 12:00:02 
 * 文 件 名：		tpwd.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 備注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.admin
{
    public partial class tpwd : AdminPageBase// AllCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["a_tpass"] = "no";

            txtsecondPassword.Focus();
        }

        protected void btn_s_Click(object sender, EventArgs e)
        {
            if (txtsecondPassword.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "$.messager.alert('提示','请输入三级密码!','error');", true);
                return;
            }
            string Md5Password = PageValidate.GetMd5(txtsecondPassword.Text.Trim());

            spd.rejumpUrl_admin(this.Page, Md5Password, getLoginID());
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('密码输入错误!');", true);
            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "$.messager.alert('提示','密码输入错误!','error');", true);
            txtsecondPassword.Focus();
        }
    }
}