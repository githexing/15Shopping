/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-17 9:56:27 
 * 文 件 名：		Member.cs 
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
using System.Data;
using Library;

namespace Web.user.member
{
    public partial class Member : PageCore//System.Web.UI.Page
    {
        private string strWhere = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //limitsBLL.jumpMain(this, 6, getLoginID());//权限
            //if (Session["pass"] == null)
            //{
            //    spd.jumpAdminUrl(this.Page, 1);//跳转二级密码
            //    Session["pass"] = "on";
            //}
            if (!IsPostBack)
            {
                ddlL();
                bind();
            }
        }
        /// <summary>
        /// 根据搜索条件进行绑定
        /// </summary>
        private void bind()
        {
            strWhere = string.Format("  userpath like '%" + getLoginID() + "-%'");
            if (this.textUserCode.Value != "")
            {
                strWhere += " and UserCode like '%" + this.textUserCode.Value.Trim() + "%'";
            }
            if (Convert.ToInt32(this.ddlLevel.SelectedValue) == 0)
            {
                strWhere += " ";
            }
            else
            {
                strWhere += " and LevelID=" + Convert.ToInt32(ddlLevel.SelectedValue);
            }
            bind_repeater(userBLL.GetList(strWhere), Repeater1, "IsOpend asc,RegTime desc", divno, AspNetPager1);
        }
        private void ddlL()
        {
            IList<lgk.Model.tb_level> ddlList = new lgk.BLL.tb_level().GetModelList("1=1");
            ddlLevel.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "请选择";
            ddlLevel.Items.Add(li);
            foreach (lgk.Model.tb_level item in ddlList)
            {
                ListItem items = new ListItem();
                items.Value = item.LevelID.ToString();
                items.Text = item.LevelName;
                ddlLevel.Items.Add(items);
            }
        }
        protected string getLevel(int LevelID)
        {
            return levelBLL.GetModel(LevelID).LevelName;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
    }
}
