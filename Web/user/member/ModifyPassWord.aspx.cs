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

namespace Web.user.member
{
    public partial class ModifyPassWord : PageCore
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //spd.jumpUrl1(this.Page, 1);//跳转三级密码

            btnPwd.Text = GetLanguage("Modify");//确认修改
            btnSecond.Text = GetLanguage("Modify");
            //btnThree.Text = GetLanguage("Modify");

            if (!IsPostBack)
            {
                BindQuestion();
            }
        }
        public void BindQuestion()
        {
            //dropQuestion.Items.Add(new ListItem(GetLanguage("PleaseSselect"), "0"));
            //dropQuestion.Items.Add(new ListItem(GetLanguage("YourNameIs"), "1"));
            //dropQuestion.Items.Add(new ListItem(GetLanguage("YourHome"), "2"));
            //dropQuestion.Items.Add(new ListItem(GetLanguage("YourPeople"), "3"));
        }

        /// <summary>
        /// 验证登录密码
        /// </summary>
        /// <returns></returns>
        protected bool validatePass(string strPwd)
        {
            if (txtPwd.Value == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("oldPassEmpty"), Library.Enums.ModalTypes.warning, "ModifyPassWord.aspx");//旧登录密码不能为空
                return false;
            }
            if (PageValidate.GetMd5(txtPwd.Value) != strPwd)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("oldPassCorrect"), Library.Enums.ModalTypes.warning, "ModifyPassWord.aspx");//旧登录密码不正确
                return false;
            }
            if (txtNewPwd.Value == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("NewPassEmpty"), Library.Enums.ModalTypes.warning, "ModifyPassWord.aspx");//新登录密码不能为空
                return false;
            }
            if (txtNewPwd.Value != txtRPNewPwd.Value)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("TwoPassIncorrect"), Library.Enums.ModalTypes.warning, "ModifyPassWord.aspx");//两次输入的密码不正确
                return false;
            }

            return true;
        }

        /// <summary>
        /// 保存登录密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPwd_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_user model = LoginUser;

            if (validatePass(model.Password))
            {
                if (UpdateUserPwd(model.UserID, "Password", PageValidate.GetMd5(txtNewPwd.Value)) > 0)
                {
                    MessageBox.ShowBox(this.Page,  GetLanguage("PasswordChanged") , Library.Enums.ModalTypes.success);//登录密码修改成功
                   
                  }
                else
                {
                    MessageBox.ShowBox(this.Page,  GetLanguage("Passwordfailed") , Library.Enums.ModalTypes.error);//登录密码修改失败
                 
                  
                }
            }
        }

        /// <summary>
        /// 验证二级密码
        /// </summary>
        /// <returns></returns>
        protected bool validateSecondPass(string strPwd)
        {
            if (txtSecondPwd.Value == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("OldTwoPassEmpty"), Library.Enums.ModalTypes.warning);//旧二级密码不能为空
                return false;
            }
            if (PageValidate.GetMd5(txtSecondPwd.Value) != strPwd)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("oldTwoPassCorrect"), Library.Enums.ModalTypes.warning);//旧二级密码不正确
                return false;
            }
            if (txtNewSecondPwd.Value == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("NewTwoPassEmpty"), Library.Enums.ModalTypes.warning);//新二级密码不能为空
                return false;
            }
            if (txtNewSecondPwd.Value != txtRPSecondPwd.Value)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("TwoPassIncorrect"), Library.Enums.ModalTypes.warning);//两次输入的密码不正确
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// 保存二级密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSecond_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_user model = LoginUser;
            if (validateSecondPass(model.SecondPassword))
            {
                if (UpdateUserPwd(model.UserID, "SecondPassword", PageValidate.GetMd5(txtNewSecondPwd.Value)) > 0)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("TwoPasswordChanged"), Library.Enums.ModalTypes.success);//二级密码修改成功
                   
                }
                else
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("TwoPasswordfailed"), Library.Enums.ModalTypes.error);//二级密码修改失败
                   
                }
            }
        }

        ///// <summary>
        ///// 验证三级密码
        ///// </summary>
        ///// <returns></returns>
        //protected bool validateTPass(string strPwd)
        //{
        //    if (txtThreePwd.Value == "")
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OldthreePassEmpty") + "');", true);//旧三级密码不能为空
        //        return false;
        //    }
        //    if (PageValidate.GetMd5(txtThreePwd.Value) != strPwd)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("oldthreePassCorrect") + "');", true);//旧三级密码不正确
        //        return false;
        //    }
        //    if (txtNewThreePwd.Value == "")
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NewthreePassEmpty") + "');", true);//新三级密码不能为空
        //        return false;
        //    }
        //    if (txtNewThreePwd.Value != txtRPThreePwd.Value)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("TwoPassIncorrect") + "');", true);//两次输入的密码不正确
        //        return false;
        //    }

        //    return true;
        //}

        //protected void btnThree_Click(object sender, EventArgs e)
        //{
        //    lgk.Model.tb_user model = LoginUser;
        //    if (validateTPass(model.ThreePassword))
        //    {
        //        if (UpdateUserPwd(model.UserID, "ThreePassword", PageValidate.GetMd5(txtNewThreePwd.Value)) > 0)
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("threePasswordChanged") + "');", true);//三级密码修改成功
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("threePasswordfailed") + "');", true);//三级密码修改失败
        //        }
        //    }
        //}

        protected void btnQuestion_Click(object sender, EventArgs e)
        {
            //if (dropQuestion.SelectedValue.Trim() == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseSelectQuestion") + "');", true);//请选择密保问题
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtAnswer.Text))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseAnswer") + "');", true);//请输入密保答案
            //    return;
            //}
            //long userId = 0;
            //long.TryParse(getLoginID().ToString(), out userId);
            //var user = userBLL.GetModel(userId);
            //int q = 0;
            //int.TryParse(dropQuestion.SelectedValue, out q);
            //string question = q > 0 && q <= 3 ? dropQuestion.SelectedItem.Text : string.Empty;
            //user.User009 = question;//密保问题
            //user.User010 = string.IsNullOrEmpty(question) ? string.Empty : txtAnswer.Text.Trim();//密保答案
            //if (userBLL.Update(user))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("UpdateSuccessful") + "');", true);//更新成功
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("UpdateFailed") + "');", true);//更新失败
            //}
        }
    }
}
