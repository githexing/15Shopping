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

namespace Web.admin.system
{
    public partial class BankSet : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 31, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                BindData();
            }
        }
        /// <summary>
        /// 填充数据
        /// </summary>
        protected void BindData()
        {
            bind_repeater(banknameBLL.GetList(""), Repeater1, "ID desc", trNull, anpBank);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            string bankName = textBankName.Value.Trim();
            lgk.Model.tb_bankName bank = banknameBLL.GetModel("BankName='" + bankName + "'");
            if (bank != null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('此银行已经存在!');", true);
                return;
            }
            else
            {
                lgk.Model.tb_bankName bankModel = new lgk.Model.tb_bankName();
                bankModel.BankName = bankName;
                if (banknameBLL.Add(bankModel) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('保存成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('保存失败!');", true);
                }
            }
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_bankName bank = banknameBLL.GetModel(ID);
            if (bank == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已删除!');", true);
                return;
            }
            if (e.CommandName == "del")
            {
                if (banknameBLL.Delete(Convert.ToInt32(ID)))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除失败!');", true);
                }
            }
            BindData();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void anpBank_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

    }
}
