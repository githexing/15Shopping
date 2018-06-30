/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-6-2 9:38:56 
 * 文 件 名：		chaifen.cs 
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
using DataAccess;
using System.Data;

namespace Web.admin.licai
{
    public partial class chaifen : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindSplit();
            }
            txtPrice.Value = gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)") == null ? "" : gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)").OpenMoney.ToString();
        }
        private void bindSplit()
        {
            DataSet ds = DbHelperSQL.Query("select openmoney jg,splitrate bl,convert(varchar(10),SplitStockTime,120) sj  from gp_SplitStockManage group by openmoney,splitrate,convert(varchar(10),SplitStockTime,120)");
            bind_repeater(ds, Repeater1, "sj desc", tr1, AspNetPager2);
        }
        protected void btnwcash_Click(object sender, EventArgs e)
        {

            if (this.txtBeiShu.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请填写拆分比率!');", true);
                return;
            }
            if (!PageValidate.IsDecimalTwo(txtBeiShu.Value))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('拆分比率必须是数字!');", true);
                return;
            }
            else if (Convert.ToDouble(this.txtBeiShu.Value.Trim()) <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('拆分比率需大于零!');", true);
                return;
            }
            if (this.txtPrice.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('开盘价未设置，无法拆分!');", true);
                return;
            }
            else
            {
                int flag = Convert.ToInt32(DbHelperSQL.GetSingle("select count(*) from gp_SplitStockManage where convert(varchar(10),SplitStockTime,120) = convert(varchar(10),getdate(),120)"));
                if (flag > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('今天已拆分，无法再进行此操作!');", true);
                    return;
                }
                else
                {
                    if (gp_opBLL.chaigu() > 0 && gp_opBLL.chaigu(Convert.ToDecimal(txtPrice.Value.Trim()), Convert.ToDecimal(txtBeiShu.Value.Trim())) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功!');", true);
                        bindSplit();
                        txtBeiShu.Value = "";
                    }
                }
            }
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            bindSplit();
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
