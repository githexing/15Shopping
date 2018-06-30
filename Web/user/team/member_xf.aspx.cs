/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-11-30 16:54:08 
 * 文 件 名：		member_xf.cs 
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
    public partial class member_xf : PageCore//System.Web.UI.Page
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
            string strWhere = " tb_mix.UserID=" + getLoginID();
            string StarTime = txtStar.Text.Trim();
            string EndTime = txtEnd.Text.Trim();
            if (StarTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),AddTime,120)  >= '" + StarTime + "'");
            }
            if (EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),AddTime,120)  <= '" + EndTime + "'");
            }
            return strWhere;
        }
        private void bind()
        {
            lblAccount.Text = LoginUser.StockAccount.ToString();
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


        protected void LinkButton3_Click(object sender, EventArgs e)
        {
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
            if (money > LoginUser.StockAccount)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('重复消费账户余额不足!');", true);
                return;
            }
            lgk.Model.tb_mix model = new lgk.Model.tb_mix();
            model.UserID = getLoginID();
            model.Amount = money;
            model.AddTime = DateTime.Now;
            model.Source = "自身消费";
            if (mixBLL.Add(model) > 0)
            {
                AllCore acore = new AllCore();//1收入2支出
                acore.add_userRecord(new lgk.BLL.tb_user().GetModel(model.UserID).UserCode, DateTime.Now, money, 2);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功!');window.location.href='member_xf.aspx';", true);
            }
            else { ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('错误!');", true); }
        }
    }
}
