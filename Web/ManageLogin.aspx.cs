/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-2-4 16:48:14 
 * 文 件 名：		ManageLogin.cs 
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
using System.Data;

namespace Web
{
    public partial class ManageLogin : AllCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtUserName.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入用户名!');", true);
                //MessageBox.Show(this, "请输入用户名!");
                return;
            }
            if (this.txtUserName.Value.Trim() == "用户名")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入用户名!');", true);
                //MessageBox.Show(this, "请输入用户名!");
                return;
            }
            if (this.txtPwd.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入密码!');", true);
                //MessageBox.Show(this, "请输入密码!");
                return;
            }
            if (this.txtVa.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('验证码不能为空!');", true);
                return;
            }

            if (this.txtVa.Value.Trim().ToLower() != Session["CheckCode"].ToString().ToLower())
            {
                WriteDBLog("验证码错误:" + this.txtVa.Value, 1);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('验证码错误!');", true);
                return;
            }

            if (!ExistsAdmin(txtUserName.Value.Trim(), PageValidate.GetMd5(txtPwd.Value.Trim())))
            {
                WriteDBLog("账号或密码错误:"+ txtPwd.Value, 1);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('账号或密码错误!');", true);
                //MessageBox.Show(this, "账号或密码错误");
                return;
            }

            WriteDBLog("登录成功",0);

            //string xd = Session["CheckCode"] != null && Session["CheckCode"].ToString() != "" ? Session["CheckCode"].ToString() : "";
            //if (xd.ToLower() != txtfield.Text.ToLower())
            //{
            //    MessageBox.Show(this, "验证码错误");
            //    return;
            //}
            lgk.Model.tb_admin admin = adminBLL.GetModel(txtUserName.Value.Trim());
            //if (admin.Limits == null)
            //{
            //    MessageBox.Show(this, "您的权限不足，请联系超级管理员");
            //    return;
            //}
            UserUtil.Login(this.txtUserName.Value.Trim(), "A128076_admin", false);
            //放入cookie
            HttpCookie UserCookie = new HttpCookie("A128076_admin");
            DataSet ds = GetAdminModel(txtUserName.Value, PageValidate.GetMd5(txtPwd.Value));
            UserCookie["Id"] = ds.Tables[0].Rows[0]["ID"].ToString();
            UserCookie["name"] = Convert.ToString(txtUserName.Value);
            Response.AppendCookie(UserCookie);
            Response.Redirect("admin/index.aspx");
        }

        private void WriteDBLog(string msg,int leve)
        {
            lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
            lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
            log.LogMsg = msg;
            log.LogType = 1;//后台登陆
            log.LogLeve = leve;// 0:提示，1：出错
            log.LogDate = DateTime.Now;
            log.LogCode = "后台登陆";//后台登陆
            log.IsDeleted = 0;
            log.Log1 = txtUserName.Value;//用户UserID
            log.Log2 = BrowserHelper.UserHostIP(this.Page);
            log.Log3 = BrowserHelper.UserHostName();
            log.Log4 = "";
            syslogBLL.Add(log);
        }
    }
}
