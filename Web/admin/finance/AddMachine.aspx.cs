/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-23 12:06:36 
 * 文 件 名：		AddMoney.cs 
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
using System.Data;

namespace Web.admin.finance
{
    public partial class AddMachine : AdminPageBase//System.Web.UI.Page
    {
        lgk.BLL.tb_BuyMachine buymacBLL = new lgk.BLL.tb_BuyMachine();

        private string strWhere = "";
        string StarTime;
        string EndTime;
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 73, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密碼
            if (!IsPostBack)
            {
                bind();

            }
        }
        private void bind()
        {
            bind_repeater(GetAdminMachineList(" buytype = 1"), Repeater1, "BuyTime desc", tr1, AspNetPager1);

        }
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <returns></returns>
        private string getWhere()
        {
            StarTime = this.txtStart.Text.Trim();
            EndTime = this.txtEnd.Text.Trim();

            strWhere = string.Format(" buytype = 1");
            if (this.usercode.Text != "")
            {
                strWhere += " and usercode like'%" + SafeHelper.GetSafeSqlandHtml(this.usercode.Text.Trim()) + "%' ";
            }
             
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),RechargeDate,120)  >= '" + StarTime + "' ");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),RechargeDate,120)  <= '" + EndTime + "' ");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),RechargeDate,120)  between '" + StarTime + "' and '" + EndTime + "' ");
            }
            return strWhere;
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_user user = new lgk.Model.tb_user();
            user = userBLL.GetModel("  usercode='" + SafeHelper.GetSafeSqlandHtml(this.txtUserCode.Text.Trim()) + "' ");

            string usercode = txtUserCode.Text.Trim();
            if (string.IsNullOrEmpty(usercode))
            {
                MessageBox.MyShow(this, "请填写要充值的会员账号!");
                return;
            }
            if (user == null)
            {
                MessageBox.MyShow(this, "该会员账号不存在!");
                return;
            }
            
            string tMoney = this.txtMoney.Text.Trim();
            if (string.IsNullOrEmpty(tMoney))
            {
                MessageBox.MyShow(this, "充值数量不能为空!");
                return;
            }

            int num = tMoney.ToInt();

            int flag = proc_BuyMachine(user.UserID, num ,1);

            if (flag == 2)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('充值矿机成功');window.location.href='AddMachine.aspx';", true);
                return;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('充值矿机失败!');", true);
                return;
            }
   
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
    }
}
