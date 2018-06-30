/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-6-6 15:31:46 
 * 文 件 名：		QQEdit.cs 
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

namespace Web.admin.system
{
    public partial class QQEdit : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 28, getLoginID());//权限
            //.jumpAdminUrl(this.Page, 1);//跳转三级密码

            if (!IsPostBack)
            {
                BindData(getIntRequest("id"));
            }
        }

        private void BindData(int p)
        {
            lgk.Model.tb_serviceQQ model = qqBLL.GetModel(p);
            txtName.Value = model.ServiceName;
            this.txtQQNumber.Value = model.QQnum;
            //if (model.QQType == 0)
            //{
            //    this.chkGroup.Checked = false;
            //}
            //else
            //{
            //    this.chkGroup.Checked = true;
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            if (txtName.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('客服名称不能为空!');", true);
                return;
            }
            if (txtQQNumber.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('客服号码不能为空!');", true);
                return;
            }
            lgk.Model.tb_serviceQQ model = qqBLL.GetModel(getIntRequest("id"));
            model.ServiceName = txtName.Value.Trim();
            model.QQnum = txtQQNumber.Value.Trim();
            //if (chkGroup.Checked == true)
            //{
            //    model.QQType = 1;
            //}
            //else
            {
                model.QQType = 0;
            }
            if (qqBLL.Update(model))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('设置成功!');window.location.href='QQSet.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('设置失败!');", true);
            }
        }
    }
}

