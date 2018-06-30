/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-11-30 16:54:23 
 * 文 件 名：		agent_xf.cs 
 * CLR 版本: 		2.0.50727.3643 
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

namespace Web.user.team
{
    public partial class agent_xf : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码
            if (!IsPostBack)
            {
                bind();
            }
        }
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <returns></returns>
        private string getWhere()
        {
            string strWhere = " (AgentsID=" + agentBLL.GetIDByIDUser(getLoginID()) + " or tb_mix.UserID=" + getLoginID() + ")";
            string StarTime = txtStar.Text.Trim();
            string EndTime = txtEnd.Text.Trim();
            if (this.txtUserCode.Value != "")
            {
                strWhere += " and tb_user.usercode like  '%" + this.txtUserCode.Value.Trim() + "%'";
            }
            if (this.txtTreuName.Value != "")
            {
                strWhere += " and tb_user.TrueName like  '%" + this.txtTreuName.Value.Trim() + "%'";
            }
            if (StarTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),tb_mix.AddTime,120)  >= '" + StarTime + "'");
            }
            if (EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),tb_mix.AddTime,120)  <= '" + EndTime + "'");
            }
            return strWhere;
        }
        private void bind()
        {
            bind_repeater(mixBLL.GetJoinList(getWhere()), Repeater2, "AddTime desc", tr1, AspNetPager2);
        }
        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            bind();
        }
        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            bind();
        }

        protected void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.MyShow(this, "会员编号不能为空!");
                return;
            }
            lgk.Model.tb_user model = userBLL.GetModel(" UserCode='" + txtCode.Text.Trim() + "'");
            if (model == null)
            {
                MessageBox.MyShow(this, "会员不存在!");
                return;
            }
            // Response.Write(model.AgentsID + "fff" + agentBLL.GetIDByIDUser(getLoginID()));
            //if (model.AgentsID != agentBLL.GetIDByIDUser(getLoginID()))
            //{
            //    MessageBox.MyShow(this, "所属报单中心不正确!");
            //    return;
            //}
            Label1.Text = model.TrueName;
            Label2.Text = model.User006;
            Label3.Text = model.StockAccount.ToString();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('会员编号不能为空!');", true);
                return;
            }
            lgk.Model.tb_user model_user = userBLL.GetModel(" UserCode='" + txtCode.Text.Trim() + "'");
            if (model_user == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('会员不存在!');", true);
                return;
            }
            if (model_user.AgentsID != agentBLL.GetIDByIDUser(getLoginID()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('所属报单中心不正确!');", true);
                return;
            }
            if (txtMoney.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('消费金额不能为空!');", true);
                return;
            }
            decimal money = 0;
            try
            {
                money = Convert.ToDecimal(txtMoney.Value.Trim());
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('消费金额格式不正确!');", true);
                return;
            }
            if (money <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('消费金额要大于零!');", true);
                return;
            }
            if (money > model_user.StockAccount)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('重复消费账户余额不足!');", true);
                return;
            }
            lgk.Model.tb_mix model = new lgk.Model.tb_mix();
            model.UserID = model_user.UserID;
            model.Amount = money;
            model.AddTime = DateTime.Now;
            model.Source = "报单中心消费";
            if (mixBLL.Add(model) > 0)
            {
                AllCore acore = new AllCore();//1收入2支出
                acore.add_userRecord(new lgk.BLL.tb_user().GetModel(model.UserID).UserCode, DateTime.Now, money, 2);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功!');window.location.href='agent_xf.aspx';", true);
            }
            else { ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('错误!');", true); }
        }
    }
}
