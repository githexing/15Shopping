/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-7-19 10:14:28 
 * 文 件 名：		chongxiaoEdit.cs 
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

namespace Web.admin.team
{
    public partial class chongxiaoEdit : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtMoney.Value = userBLL.GetModel(getIntRequest("userid")).BonusAccount.ToString();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_user umodel = userBLL.GetModel(getIntRequest("userid"));
            if (this.txtMoney.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改金额不能为空!');", true);
                return;
            }
            if (Convert.ToDecimal(this.txtMoney.Value.Trim()) < 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改金额需大于零!');", true);
                return;
            }
            if (Convert.ToDecimal(this.txtMoney.Value.Trim()) > umodel.BonusAccount)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改金额不能大于会员重消账户余额!');", true);
                return;
            }
            lgk.Model.tb_mix model = new lgk.Model.tb_mix();
            model.UserID = umodel.UserID;
            model.Amount = umodel.BonusAccount;
            model.AddTime = DateTime.Now;
            model.Mix005 = umodel.BonusAccount - Convert.ToDecimal(txtMoney.Value.Trim());
            model.Mix006 = Convert.ToDecimal(txtMoney.Value.Trim());
            //加入流水账表
            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
            jmodel.UserID = getIntRequest("userid");
            jmodel.JournalDate = DateTime.Now;
            jmodel.JournalType = 1;
            jmodel.InAmount = 0;
            jmodel.OutAmount = umodel.BonusAccount - Convert.ToDecimal(txtMoney.Value.Trim());
            jmodel.BalanceAmount = Convert.ToDecimal(txtMoney.Value.Trim());
            jmodel.Remark = "B网消费";
            umodel.BonusAccount = Convert.ToDecimal(txtMoney.Value.Trim());
            if (userBLL.Update(umodel) && mixBLL.Add(model) > 0 && journalBLL.Add(jmodel) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改成功！');window.location.href='chongxiaoList.aspx'", true);
            }
            else { ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改失败!');", true); }
        }
    }
}
