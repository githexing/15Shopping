using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Library;

namespace Web.admin.Stock
{
    public partial class Turntable : AdminPageBase
    {
        private string strWhere = "", StarTime = "", EndTime = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 6, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转3级密碼

            if (!IsPostBack)
            {
                BindData();
            }
            txtMoney.Value = GetTotalTake(0, 2).ToString("0.00");
        }

        private void BindData()
        {
            bind_repeater(GetTakeList(GetWhere()), Repeater1, "TakeTime desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 提现记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            StarTime = txtStar.Text.Trim();
            EndTime = txtEnd.Text.Trim();
            strWhere = " Flag=1 and TakeType=2";
            if (this.txtUserCode.Value != "")
            {
                strWhere += " and u.usercode like  '%" + this.txtUserCode.Value.Trim() + "%'";
            }
            if (this.txtTrueName.Value != "")
            {
                strWhere += " and u.trueName like  '%" + this.txtTrueName.Value.Trim() + "%'";
            }
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),TakeTime,120)  >= '" + StarTime + "'");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),TakeTime,120)  <= '" + EndTime + "'");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),TakeTime,120)  between '" + StarTime + "' and '" + EndTime + "'");
            }
            return strWhere;
        }

        protected void lbtnWithdraw_Click(object sender, EventArgs e)
        {
            Response.Redirect("Turntable.aspx");
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void lbtnExport_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            DataSet ds = GetTakeList(GetWhere());
            DataTable dv = ds.Tables[0];
            if (Repeater1.Items.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('不能导出空表格!');", true);
                return;
            }
            if (dv.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('错误的操作!');", true);
                return;
            }
            string str = ToTakeExecl(Server.MapPath("../../Upload"), dv);
            Response.Redirect("../../Upload/" + str.Replace("\\", "/").Replace("//", "/"), true);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}