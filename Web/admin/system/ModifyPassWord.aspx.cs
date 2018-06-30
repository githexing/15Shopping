using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library;

namespace Web.admin.system
{
    public partial class ModifyPassWord : AdminPageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 27, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密碼
        }
        /// <summary>
        /// 验证登录密码
        /// </summary>
        /// <returns></returns>
        protected bool validatePass(string pass)
        {
            if (textPassWord.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('旧登录密码不能为空!');", true);
                return false;
            }
            if (PageValidate.GetMd5(textPassWord.Value) != pass)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('旧登录密码不正确!');", true);
                return false;
            }
            if (textNewPassWord.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('新登录密码不能为空!');", true);
                return false;
            }
            if (textNewPassWord.Value != textRPNewPassWord.Value)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('两次输入的密码不正确!');", true);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 保存登录密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPassWord_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_admin admin = adminBLL.GetModel(getLoginID());
            if (validatePass(admin.Password))
            {
                if (UpdateAdminPwd(admin.UserName, "Password", PageValidate.GetMd5(textNewPassWord.Value)) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('登录密码修改成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('登录密码修改失败!');", true);
                }
            }
        }
        /// <summary>
        /// 验证二级密码
        /// </summary>
        /// <returns></returns>
        protected bool validateSecondPass(string pass)
        {
            if (textSecondPass.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('旧二级密码不能为空!');", true);
                return false;
            }
            if (PageValidate.GetMd5(textSecondPass.Value) != pass)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('旧二级密码不正确!');", true);
                return false;
            }
            if (textNewSecondPass.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('新二级密码不能为空!');", true);
                return false;
            }
            if (textNewSecondPass.Value != textRPSecondPass.Value)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('两次输入的密码不正确!');", true);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 保存二级密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSecondPass_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_admin admin = adminBLL.GetModel(getLoginID());
            if (validateSecondPass(admin.SecondPassword))
            {
                if (UpdateAdminPwd(admin.UserName, "SecondPassword", PageValidate.GetMd5(textNewSecondPass.Value)) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('二级密码修改成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('二级密码修改失败!');", true);
                }
            }
        }

        /// <summary>
        /// 验证三级密码
        /// </summary>
        /// <returns></returns>
        protected bool validateTPass(string pass)
        {
            if (Password1.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('旧三级密码不能为空!');", true);
                return false;
            }
            if (PageValidate.GetMd5(Password1.Value) != pass)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('旧三级密码不正确!');", true);
                return false;
            }
            if (Password2.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('新三级密码不能为空!');", true);
                return false;
            }
            if (Password2.Value != Password3.Value)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('两次输入的密码不正确!');", true);
                return false;
            }
            return true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_admin model = adminBLL.GetModel(getLoginID());
            if (validateTPass(model.ThirdPassword))
            {
                if (UpdateAdminPwd(model.UserName, "ThirdPassword", PageValidate.GetMd5(Password2.Value)) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('三级密码修改成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('三级密码修改失败!');", true);
                }
            }
        }
    }
}
