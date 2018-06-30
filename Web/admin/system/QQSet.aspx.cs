/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-29 16:40:45 
 * 文 件 名：		QQSet.cs 
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
    public partial class QQSet : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 28, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                BindData();
            }
        }
        /// <summary>
        /// 填充數据
        /// </summary>
        protected void BindData()
        {
            bind_repeater(qqBLL.GetList(""), rpBank, "ID desc", trNull, anpBank);
        }
        /// <summary>
        /// 提交QQ号码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtName.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('客服名称不能为空!');", true);
                return;
            }
            if (txtQQnumber.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('客服号码不能为空!');", true);
                return;
            }
            lgk.Model.tb_serviceQQ model = new lgk.Model.tb_serviceQQ();
            model.ServiceName = txtName.Value.Trim();
            model.QQnum = txtQQnumber.Value.Trim();
            //if (chkGroup.Checked == true)
            //{
            //    model.QQType = 1;
            //}
            //else 
            {
                model.QQType = 0;
            }
            if (qqBLL.Add(model) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('添加成功!');window.location.href='QQSet.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('添加失败!');", true);
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void anpBank_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rpBank_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            if (!qqBLL.Exists(ID))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已删除!');", true);
                return;
            }
            if (e.CommandName == "modify")
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                Response.Redirect("QQEdit.aspx?id=" + ID);
            }
            if (e.CommandName == "del")
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                if (qqBLL.Delete(ID))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除失败!');", true);
                }
            }
            BindData();
        }
    }
}
