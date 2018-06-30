using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.cash
{
    public partial class CashManage : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 48, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        protected void BindData()
        {
            lgk.Model.CashManage set = cashmanageBLL.GetModelByTypeID(1);
            if (set != null)
            {
                if (set.State == 0)//关闭
                {
                    rdoEnabled.Checked = false;
                    rdoClose.Checked = true;

                }
                else //启用
                {
                    rdoEnabled.Checked = true;
                    rdoClose.Checked = false;
                }
                txtMsgContent.Text = set.Remark;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strMsg = txtMsgContent.Text.Trim();
            if (string.IsNullOrEmpty(strMsg))
            {
                MessageBox.Show(this, "关闭提示信息不能为空");
                return;
            }
            lgk.Model.CashManage set = cashmanageBLL.GetModelByTypeID(1);
            if (set == null)
            {
                set = new lgk.Model.CashManage();
                set.Remark = strMsg;
                if (rdoEnabled.Checked == true)
                {
                    set.State = 1;//开启
                }
                else
                {
                    set.State = 0;//关闭
                }
                if (cashmanageBLL.Add(set) > 0)
                {
                    MessageBox.Show(this, "设置成功");
                    BindData();
                }
                else
                {
                    MessageBox.Show(this, "设置失败");
                }
            }
            else
            {
                set.Remark = strMsg;
                if (rdoEnabled.Checked == true)
                {
                    set.State = 1;
                }
                else
                {
                    set.State = 0;
                }
                if (cashmanageBLL.Update(set))
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