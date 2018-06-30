using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.system
{
    public partial class InviteInfoSet : System.Web.UI.Page
    {
        lgk.BLL.tb_InviteInfo inviteInfoBLL = new lgk.BLL.tb_InviteInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var model = inviteInfoBLL.GetModel(1);
                if(model != null)
                {
                    txtInviteInfo.Text = model.InviteInfo;
                    txtInviteRule.Value = model.InviteRule;
                    txtIntro.Text = model.Intro;
                }
            }
        }

        /// <summary>
        /// 提交QQ号码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtInviteInfo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('邀请信息不能为空!');", true);
                return;
            }
            if (txtInviteRule.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入规则内容!');", true);
                return;
            }
            lgk.Model.tb_InviteInfo model = new lgk.Model.tb_InviteInfo();
            model = inviteInfoBLL.GetModel(1);
            
            model.InviteInfo = txtInviteInfo.Text.Trim();
            model.InviteRule = txtInviteRule.Value.Trim();
            model.Intro = txtIntro.Text.Trim();
            model.ModifyTime = DateTime.Now;

            if (model == null)
            {
                if (inviteInfoBLL.Add(model) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('保存成功!');window.location.href='InviteInfoSet.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('保存失败!');", true);
                }
            }
            else
            {
                if (inviteInfoBLL.Update(model))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('保存成功!');window.location.href='InviteInfoSet.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('保存失败!');", true);
                }
            }

            
        }

    }
}