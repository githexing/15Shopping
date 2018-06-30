using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user
{
    public partial class passwordupdata : AllCore
    {
       // lgk.BLL.tb_user userBLL = new lgk.BLL.tb_user();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // lgk.Model.tb_user model = userBLL.GetModel("usercode='" + TextBox1.Text.Trim() + "'");
            string youb=TextBox2.Text.Trim();
            if (this.TextBox1.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入用户名!');", true);
                return;
            }
            else if (userBLL.GetModel("usercode='" + TextBox1.Text.Trim() + "'")==null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('用户名不存在!');", true);
                return;
            }
            lgk.Model.tb_user model = userBLL.GetModel("usercode='" + TextBox1.Text.Trim() + "'");
            if (model.User005 != youb)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('用户名或邮箱不正确!');", true);
                return;
            }
            string title = "会员密码修改";
            string content = "您的帐号为"+model.UserCode+",您的密码已经修改为:123456 ； 请及时登录系统进行密码修改!";
            SendMail(getParamVarchar("you_1"), getParamVarchar("you_2"), "admin", title, content, getParamVarchar("you_3"), model.User005);
            model.Password = PageValidate.GetMd5("123456");
            model.SecondPassword = PageValidate.GetMd5("123456");
            model.ThreePassword = PageValidate.GetMd5("123456");
            userBLL.Update(model);
            //if (this.txtVa.Text == "")
            //{
            //    MessageBox.Show(this, "验证码不能为空!");
            //    return;
            //}

            //string xd = Session["CheckCode"] != null && Session["CheckCode"].ToString() != "" ? Session["CheckCode"].ToString() : "";
            //if (xd.ToLower() != txtVa.Text.ToLower())
            //{
            //    MessageBox.Show(this, "验证码错误");
            //    return;
            //}

        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="SendMailUser">发送邮箱账号</param>
        /// <param name="SendPassword">发送邮箱密码</param>
        /// <param name="SenderName">发送显示名称</param>
        /// <param name="MailTitle">邮件标题</param>
        /// <param name="MailContent">邮件内容</param>
        /// <param name="Host">发送邮件邮箱服务器地址</param>
        /// <param name="ReceiveMail">接收邮件邮箱账号</param>
        public void SendMail(string SendMailUser, string SendPassword, string SenderName, string MailTitle, string MailContent, string Host, string ReceiveMail)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(ReceiveMail);

            msg.From = new System.Net.Mail.MailAddress(SendMailUser, SenderName, System.Text.Encoding.UTF8);
            msg.Subject = MailTitle;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = MailContent;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;
            msg.Priority = System.Net.Mail.MailPriority.Normal;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = Host;//smtp.163.com
            client.Credentials = new System.Net.NetworkCredential(SendMailUser, SendPassword);

            object userToken = msg;
            try
            {
                client.Send(msg);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('发送成功');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + ex.Message + "');", true);
            }
        }

    }
}
