/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-4 17:42:11 
 * 文 件 名：		TradeEdit.cs 
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
    public partial class TradeEdit : AdminPageBase//System.Web.UI.Page
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
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                lgk.Model.gp_BusinessAmount model = gp_amountBLL.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                textStar.Value = model.BusinessTime.ToString();
                txtNum.Value = model.BusinessAmount.ToString();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

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
            lgk.Model.gp_BusinessAmount model = gp_amountBLL.GetModel(Convert.ToInt32(Request.QueryString["id"])); ;
            model.BusinessAmount = Convert.ToDecimal(txtNum.Value);
            if (gp_amountBLL.Update(model))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('编辑成功!');window.location.href='trade.aspx'", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('编辑失败!');", true);
                return;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("trade.aspx");
        }
    }
}
