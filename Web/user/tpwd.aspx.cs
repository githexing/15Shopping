/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-19 17:30:02 
 * 文 件 名：		tpwd.cs 
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

namespace Web.user
{
    public partial class tpwd : PageCore//System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["tpurl"] = "no";

            txtSecondPassword.Focus();
            btnOK.Text = GetLanguage("Determine");//确定
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (txtSecondPassword.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseThreePassword") + "');", true);//请输入三级密码
                return;
            }
            string Md5Password = PageValidate.GetMd5(txtSecondPassword.Value.Trim());
            spd.rejumpUrl1(this.Page, Md5Password, 1, getLoginID());
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PasswordError") + "');", true);//密码输入错误
            txtSecondPassword.Focus();
        }
    }
}
