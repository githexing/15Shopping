/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-1-12 13:55:20 
 * 文 件 名：		MemberTree.cs 
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
using lgk.Model;
using lgk.BLL;
using Library;

namespace web.admin.team
{
    public partial class MemberTree : AdminPageBase//System.Web.UI.Page//
    {
        private int x = 1;
        private int y = 2;
        private int z = 3;
        private static int _selectPlatform = 3;
        public int hasChild = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 2, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                BindTreeRe();
                x = GetID();
                ViewState["x"] = x;
                ViewState["y"] = y;
                ViewState["z"] = z;
            }
            else
            {
                x = int.Parse(ViewState["x"].ToString());
                y = int.Parse(ViewState["y"].ToString());
                z = int.Parse(ViewState["z"].ToString());
            }
        }
        
        private void BindTreeRe()
        {
            int id = GetID();
            lgk.BLL.UserView uview = new UserView(id, y, z, _selectPlatform, 1, "zh-cn");
            Literal1.Text = uview.AddTable();
        }
        
        private int GetID()
        {
            if (getIntRequest("tt") != 0)
            {
                return getIntRequest("tt");
            } return 1;
        }
        
        private void BindTree()
        {
            UserView uview = new UserView(x, y, z, _selectPlatform, 1, "zh-cn");
            Literal1.Text = uview.AddTable();
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtUserCode.Text != "")
            {
                int xNode = GetUserID(txtUserCode.Text);
                if (xNode != 0)
                {
                    //ArrayList bli = getli(TextBox1.Text);
                    x = xNode;
                    ViewState["x"] = x;
                    BindTree();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('没有这个用户!');", true);
                    BindTree();
                }
            }
            else
            {
                x = 1;
                ViewState["x"] = x;
                BindTree();
            }
        }

        protected void btnMy_Click(object sender, EventArgs e)
        {
            x = 1;
            ViewState["x"] = x;
            BindTree();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            z = z - 1;
            if (z < 2) z = 2;
            ViewState["z"] = z;
            BindTree();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "11", "parent.document.all('mainFrame').style.height=document.body.scrollHeight;", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            z = z + 1;
            ViewState["z"] = z;
            BindTree();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "11", "parent.document.all('mainFrame').style.height=document.body.scrollHeight;", true);
        }

    }
}