using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;


namespace Web.admin
{
    public partial class test : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //日结算奖金
            MySQL(string.Format(" exec proc_datebonus"));
          //  MySQL(string.Format(" exec proc_datebonus"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('结算成功!');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //周发奖金
            MySQL(string.Format(" exec proc_monthbonus"));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('奖金已发放!');", true);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //MySQL(string.Format("  update tb_bonus set Bonus002=0"));

            if (string.IsNullOrEmpty(this.txt_text.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('无内容执行!');", true);
            }
            else {
                 MySQL(string.Format(this.txt_text.Text));
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('执行完毕!');", true);
            }

            
        }
    }
}