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

namespace Web.admin.licai
{
    public partial class trade : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_num();
            }
        }

        private void bind_num()
        {
            bind_repeater(gp_amountBLL.GetList("1=1"), Repeater1, "BusinessTime desc", trBonusNull, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtStar.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择日期!');", true);
                return;
            }
            else if (Convert.ToDateTime(txtStar.Text).Day<DateTime.Now.Day)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择今天之后的日期!');", true);
                return;
            }
            if (this.txtNum.Value.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入交易数目!');", true);
                return;
            }
            if (!PageValidate.IsDecimalTwo(this.txtNum.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('只能输入整数或者带两位小数的浮点数!');", true);
                return;
            }
            if (gp_amountBLL.Exists(Convert.ToDateTime(this.txtStar.Text)))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('当天已存在记录!');window.location.href='trade.aspx'", true);
            }
            else
            {
                lgk.Model.gp_BusinessAmount model = new lgk.Model.gp_BusinessAmount();
                model.BusinessTime = Convert.ToDateTime(txtStar.Text);
                model.BusinessAmount = Convert.ToDecimal(txtNum.Value);
                if (gp_amountBLL.Add(model) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('数据提交成功!');window.location.href='trade.aspx'", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('提交数据失败!');", true);
                    return;
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            lgk.Model.gp_BusinessAmount model = gp_amountBLL.GetModel(id);
            if (model==null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已删除，无法再进行此操作!');window.location.href='trade.aspx'", true);
            }
            else
            {
                if (e.CommandName.Equals("del"))
                {
                    if (gp_amountBLL.Delete(id))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除成功!');", true);
                        bind_num();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除失败!');", true);
                    }
                }
                if (e.CommandName.Equals("edi"))
                {
                    Response.Redirect("TradeEdit.aspx?id=" + id);

                }
            }
            
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind_num();
        }
    }
}
