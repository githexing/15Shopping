/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-6-2 9:33:13 
 * 文 件 名：		faxing.cs 
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

namespace Web.admin.licai
{
    public partial class faxing : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindFX();
            }
        }
        private void bindFX()
        {
            bind_repeater(gp_issueBLL.GetList(" 1=1"), rpsp, "AddTime desc", tr2, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bindFX();
        }

        protected void rpsp_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            lgk.Model.gp_StockIssue model = gp_issueBLL.GetModel(ID);
            if (model == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该发行记录已删除，不能再进行此操作！');window.location.href='faxing.aspx'", true);
            }
            else
            {
                if (e.CommandName.Equals("del"))//
                {
                    if (model.SurplusAmount != model.IssueAmount)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('已有股票卖出，不能删除！');window.location.href='faxing.aspx'", true);
                    }
                    else
                    {
                        if (gp_issueBLL.Delete(ID))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除成功！');window.location.href='faxing.aspx'", true);
                        }
                    }
                }
            }

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            lgk.Model.gp_StockIssue model = new lgk.Model.gp_StockIssue();
            if (this.txtNum.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('发行量不能为空!');", true);
                return;
            }
            if (!PageValidate.IsDecimalSign(txtNum.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('发行量必须是数字!');", true);
                return;
            }
            else if (Convert.ToDouble(this.txtNum.Text.Trim()) <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('发行量需大于零!');", true);
                return;
            }
            model.IssueAmount = Convert.ToDecimal(this.txtNum.Text.Trim());
            model.SurplusAmount = Convert.ToDecimal(this.txtNum.Text.Trim());
            model.SaleAmount = 0;
            model.AddTime = DateTime.Now;
            if (gp_issueBLL.Add(model) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('发行成功！');window.location.href='faxing.aspx'", true);
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("faxing.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("chaifen.aspx");
        }
    }
}
