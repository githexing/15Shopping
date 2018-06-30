/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-24 14:56:12 
 * 文 件 名：		UpdatePwd.cs 
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

namespace Web.admin.business
{
    public partial class UpdatePwd : AdminPageBase//System.Web.UI.Page
    {
        protected string usercode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["a_pass"] == null)
            {
                spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
                Session["a_pass"] = "on";
            }
            usercode = GetUserCode(getIntRequest("userid"));
        }
        /// <summary>
        /// 验证登录密码
        /// </summary>
        /// <returns></returns>
        protected bool validatePass(string pass)
        {
            if (textNewPassWord.Value == "")
            {
                MessageBox.MyShow(this, "新登录密码不能为空!");
                return false;
            }
            if (textNewPassWord.Value != textRPNewPassWord.Value)
            {
                MessageBox.MyShow(this, "两次输入的密码不正确!");
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
            lgk.Model.tb_user model = userBLL.GetModel(getIntRequest("userid"));
            if (validatePass(model.Password))
            {
                if (UpdateUserPwd(Convert.ToInt32(model.UserID), "Password", PageValidate.GetMd5(textNewPassWord.Value)) > 0)
                {
                    MessageBox.MyShow(this, "登录密码修改成功!");
                }
                else
                {
                    MessageBox.MyShow(this, "登录密码修改失败!");
                }
            }
        }
        /// <summary>
        /// 验证二级密码
        /// </summary>
        /// <returns></returns>
        protected bool validateSecondPass(string pass)
        {
            if (textNewSecondPass.Value == "")
            {
                MessageBox.MyShow(this, "新二级密码不能为空!");
                return false;
            }
            if (textNewSecondPass.Value != textRPSecondPass.Value)
            {
                MessageBox.MyShow(this, "两次输入的密码不正确!");
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
            lgk.Model.tb_user model = userBLL.GetModel(getIntRequest("userid"));
            if (validateSecondPass(model.SecondPassword))
            {
                if (UpdateUserPwd(Convert.ToInt32(model.UserID), "SecondPassword", PageValidate.GetMd5(textNewSecondPass.Value)) > 0)
                {
                    MessageBox.MyShow(this, "二级密码修改成功!");
                }
                else
                {
                    MessageBox.MyShow(this, "二级密码修改失败!");
                }
            }
        }
        /// <summary>
        /// 验证三级密码
        /// </summary>
        /// <returns></returns>
        protected bool validateTPass(string pass)
        {
            if (Password2.Value == "")
            {
                MessageBox.MyShow(this, "新三级密码不能为空!");
                return false;
            }
            if (Password2.Value != Password3.Value)
            {
                MessageBox.MyShow(this, "两次输入的密码不正确!");
                return false;
            }
            return true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_user model = userBLL.GetModel(getIntRequest("userid"));
            if (validateTPass(model.User005))
            {
                if (UpdateUserPwd(Convert.ToInt32(model.UserID), "ThreePassword", PageValidate.GetMd5(Password2.Value)) > 0)
                {
                    MessageBox.MyShow(this, "三级密码修改成功!");
                }
                else
                {
                    MessageBox.MyShow(this, "三级密码修改失败!");
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDetail.aspx?UserID=" + getIntRequest("userid"));
        }
    }
}
