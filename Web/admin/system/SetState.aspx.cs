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
    public partial class SetState : AdminPageBase//System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 29, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                BindDate();
            }
        }
        /// <summary>
        /// 填充数据
        /// </summary>
        protected void BindDate()
        {
            lgk.Model.tb_setSystem set = setBLL.GetModel(setBLL.GetMaxId());
            if (set != null)
            {
                if (set.IsOpenWeb == 0)
                {
                    rdoEnabled.Checked = false;
                    rdoClose.Checked = true;

                }
                else
                {
                    rdoEnabled.Checked = true;
                    rdoClose.Checked = false;
                }
                txtMsgContent.Text = set.CloseWebRemark;
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            if (txtMsgContent.Text == "")
            {
                MessageBox.Show(this, "关闭提示信息不能为空");
                return;
            }
            lgk.Model.tb_setSystem set = setBLL.GetModel(setBLL.GetMaxId());
            if (set == null)
            {
                set = new lgk.Model.tb_setSystem();
                set.CloseWebRemark = txtMsgContent.Text;
                if (rdoEnabled.Checked == true)
                {
                    set.IsOpenWeb = 1;

                }
                else
                {
                    set.IsOpenWeb = 0;
                }
                if (setBLL.Add(set) > 0)
                {
                    MessageBox.ShowAndRedirect(this, "设置成功", "SetState.aspx");
                }
                else
                {
                    MessageBox.Show(this, "设置失败");
                }
            }
            else
            {
                set.CloseWebRemark = txtMsgContent.Text;
                if (rdoEnabled.Checked == true)
                {
                    set.IsOpenWeb = 1;
                }
                else
                {
                    set.IsOpenWeb = 0;
                }
                if (setBLL.Update(set))
                {
                    MessageBox.Show(this, "设置成功");
                }
                else
                {
                    MessageBox.Show(this, "设置失败");
                }
            }
        }
    }
}
