using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.admin.finance
{
    public partial class Bonusff : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MySQL(string.Format(" exec proc_Task_ReleaseOriginal "));
            //  MySQL(string.Format(" exec proc_datebonus"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('释放成功!');", true);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            MySQL(string.Format(" exec proc_Task_StaticAward "));
            //  MySQL(string.Format(" exec proc_datebonus"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('发放成功!');", true);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            MySQL(string.Format(" exec proc_Task_DynamicAward "));
            //  MySQL(string.Format(" exec proc_datebonus"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('发放成功!');", true);
        }
        
        private void BindData()
        {
            bind_repeater(sysLogBLL.GetList("LogType = 999"), Repeater1, "LogDate desc", tr1, AspNetPager1);
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
