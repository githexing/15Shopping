/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-23 15:43:45 
 * 文 件 名：		UserList.cs 
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

namespace Web.admin.business
{
    public partial class UserList : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 4, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                bind();
            }
        }
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <returns></returns>
        private string getWhere()
        {
            string strWhere = " AgentsID=" + Convert.ToInt32(Request["id"]);
            if (this.txtUserCode.Value != "")
            {
                strWhere += " and usercode like  '%" + this.txtUserCode.Value.Trim() + "%'";
            } 
            if (this.txtTreuName.Value != "")
            {
                strWhere += " and TrueName like  '%" + this.txtTreuName.Value.Trim() + "%'";
            }
            return strWhere;
        }
        private void bind()
        {
            bind_repeater(userBLL.GetDetailList(getWhere()), Repeater2, "UserID desc", tr1, AspNetPager2);
        }

        /// <summary>
        /// 导出申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void daochu_Click(object sender, EventArgs e)
        {
            DataSet ds = userBLL.GetDetailList(getWhere());
            DataTable dv = ds.Tables[0];
            if (Repeater2.Items.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('不能导出空表格!');", true);
                return;
            }
            if (dv.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('错误的操作!');", true);
                return;
            }
            string str = ToOpenExecl(Server.MapPath("../../Upload"), dv);
            Response.Redirect("../../Upload/" + str.Replace("\\", "/").Replace("//", "/"), true);
        }
        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            bind();
        }
        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int UserID = int.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_user model = userBLL.GetModel(UserID);
            if (model == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该会员已删除,无法再进行此操作!');", true);
            }
            else
            {
                if (e.CommandName == "edit")
                {
                    spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                    Response.Redirect("UserDetail.aspx?UserID=" + UserID);
                }
                if (e.CommandName == "close")
                {
                    spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码
                    model.IsLock = 1;
                    userBLL.Update(model);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('冻结成功!');", true);
                }
                if (e.CommandName == "open")
                {
                    spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                    model.IsLock = 0;
                    userBLL.Update(model);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('开启成功!');", true);
                }
                if (e.CommandName == "goto")
                {
                    Session["goto_uid"] = UserID;
                    Response.Write("<script>window.open('/Login.aspx')</script>");
                }
            }
            bind();
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
    }
}
