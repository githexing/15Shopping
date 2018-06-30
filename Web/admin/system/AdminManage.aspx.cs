/*********************************************************************************
*Copyright(c) 	2012 RJ.COM
 * 创建日期：		2012-6-5 9:40:49
 * 文 件 名：		AdminManage.cs
 * CLR 版本:		2.0.50727.3053
 * 创 建 人：		
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 備注描述： 
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using BLL;
using Library;

namespace Web.admin.system
{
    public partial class AdminManage : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 32, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindAdmin();
            }
        }
        /// <summary>
        /// 填充管理員表格
        /// </summary>
        protected void BindAdmin()
        {
            bind_repeater(adminBLL.GetList("ID<>1"), rpAdmin, "AddDate desc", trNull, anpAdmin);
        }
        /// <summary>
        /// 添加管理員
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码
            Response.Redirect("AdminEdit.aspx");
        }
        /// <summary>
        /// 分页控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindAdmin();
        }

        protected void rpAdmin_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            if (ID == getLoginID())
            {
                MessageBox.Show(this, "无法操作");
                return;
            }
            if (e.CommandName.Equals("del"))//删除
            {
                //spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                lgk.Model.tb_admin admin = adminBLL.GetModel(ID);
                if (adminBLL.Delete(admin.ID))
                {
                    MessageBox.ShowAndRedirect(this, "删除成功", "AdminManage.aspx");
                }
                else
                {
                    MessageBox.Show(this, "删除失败");
                }
            }
            else if (e.CommandName.Equals("modify"))
            {
               // spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                Response.Redirect("AdminEdit.aspx?id=" + ID);
            }
        }
    }
}
