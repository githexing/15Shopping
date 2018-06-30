/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-19 12:23:20 
 * 文 件 名：		NoticeManage.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：
**********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Library;

namespace web.admin.system
{
    public partial class NoticeManage : AdminPageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 22, getLoginID());//权限
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
            bind_repeater(newsBLL.GetList(""), Repeater1, "PublishTime desc", tr1, AspNetPager1);
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long iID = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "modify")
            {
                //spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                Response.Redirect("NoticeEdit.aspx?ID=" + iID + "");
            }
            if (e.CommandName == "del")
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                if (newsBLL.GetModel(iID) == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('已删除，不能再进行此操作!');window.location.href='NoticeManage.aspx'", true);
                }
                if (newsBLL.Delete(iID))
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

        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("NoticeEdit.aspx");
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                long iID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "ID"));

                Literal ltTypeName = (Literal)e.Item.FindControl("ltTypeName");

                lgk.Model.tb_news newsInfo = newsBLL.GetModel(iID);

                if (newsInfo.NewType == 1)//1系统公告，2公司简介,3新闻中心,4疑问解答,5商城公告
                    ltTypeName.Text = "系统公告";
                else if (newsInfo.NewType == 2)
                    ltTypeName.Text = "关于释放币";
                else if (newsInfo.NewType == 3)
                    ltTypeName.Text = "释放币帮助";
                //else if (newsInfo.NewType == 4)
                //    ltTypeName.Text = "疑问解答";
                //else if (newsInfo.NewType == 5)
                //    ltTypeName.Text = "商城公告";
            }
        }

    }
}
