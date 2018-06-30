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
using DataAccess;

namespace Web.admin.licai
{
    public partial class licaibiDynamicParameter : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
                bindrdo();
            }
        }

        private void bind()
        {
            bind_repeater(gpBLL.GetList(" ParamAmount>=0"), Repeater1, "id asc", null);
        }
        private void bindrdo()
        {
            bind_repeater(gpBLL.GetList(" ParamAmount<0"), Repeater2, "id asc", null);
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName.ToString();
            if (name == "update")
            {
                decimal value = 0;
                HtmlInputText valuemoney = (HtmlInputText)e.Item.FindControl("paramValue");
                if (valuemoney.Value == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入参数值!');", true);
                    return;
                }
                try
                {
                    value = Convert.ToDecimal(valuemoney.Value);
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入数字格式参数!');", true);
                    return;
                }
                if (value <= 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入大于0的参数!');", true);
                    return;
                }

                lgk.Model.gp_globeParam item_param = gpBLL.GetModel(id);
                if (item_param != null)
                {
                    if (item_param.ParamType==1)
                    {
                        if (value > 100)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('比率不能大于100%!');", true);
                            return;
                        }
                    }
                    item_param.ParamAmount = value;
                    if (item_param.ParamName=="gp_rate")
                    {
                        DbHelperSQL.Query("update gp_globeParam set ParamAmount=" + (100 - value) + " where ParamName='hg_rate'");
                    }
                    if (item_param.ParamName == "hg_rate")
                    {
                        DbHelperSQL.Query("update gp_globeParam set ParamAmount=" + (100 - value) + " where ParamName='gp_rate'");
                    }
                    if (gpBLL.Update(item_param))
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改成功!');", true);
                    else ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改失败!');", true);
                }
                bind();
            }
        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName.ToString();
            if (name == "update")
            {
                int value = 0;
                HtmlInputRadioButton valueInt = (HtmlInputRadioButton)e.Item.FindControl("ropen");
                if (valueInt.Checked == true)
                {
                    value = 1;
                }

                lgk.Model.gp_globeParam item_param = gpBLL.GetModel(id);
                if (item_param != null)
                {
                    item_param.ParamInt = value;
                    if (gpBLL.Update(item_param))
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改成功!');", true);
                    else ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改失败!');", true);
                }
                bindrdo();
            }
        }
    }
}
