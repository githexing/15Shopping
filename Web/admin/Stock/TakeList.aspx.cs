using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.admin.Stock
{
    public partial class TakeList : AdminPageBase
    {
        private string strWhere = "", StarTime = "", EndTime = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 6, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                BindData();
            }
            txtMoney.Value = GetTotalTake(0, 1).ToString("0.00");
        }

        /// <summary>
        /// 填充提现记录
        /// </summary>
        private void BindData()
        {
            bind_repeater(GetTakeList(GetWhere()), Repeater2, "TakeTime desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 提现记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            StarTime = txtStar.Text.Trim();
            EndTime = txtEnd.Text.Trim();
            strWhere = " Flag=1 and TakeType=1";
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
        
        protected void lbtnApply_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeMoney.aspx");
        }

        protected void lbtnDeposit_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeList.aspx");
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
            string str = ToTakeExecl(Server.MapPath("../../Upload"), dv);
            Response.Redirect("../../Upload/" + str.Replace("\\", "/").Replace("//", "/"), true);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}