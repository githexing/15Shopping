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
    public partial class Addcishan : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 72, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密碼

            if (!IsPostBack)
            {
                BindData();
                Label_cishan.Text = systemBll.GetModel(1).Money001.ToString();
                Label_cishan2.Text = systemBll.GetModel(1).Money002.ToString();
            }
        }

        private void BindData()
        {
            bind_repeater(GetTransferList(GetWhere()), Repeater1, "ChangeDate desc", trBonusNull, AspNetPager1);
        }

        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strStartTime = this.txtStart.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();

            string strWhere = string.Format(" c.ChangeType=5");
            if (this.txtCode.Text != "")
            {
                strWhere += " and u.UserCode like '%" + this.txtCode.Text.Trim() + "%'";
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120)  >= '" + strStartTime + "' ");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120)  <= '" + strEndTime + "' ");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and and Convert(nvarchar(10),c.ChangeDate,120)  between '" + strStartTime + "' and '" + strEndTime + "' ");
            }
            return strWhere;
        }

        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {
             #region 充值金额验证
            if (this.txtMoney.Text == "")
            {
                MessageBox.MyShow(this, "充值金额不能为空!");
                return;
            }
            else if (Convert.ToDouble(this.txtMoney.Text.Trim()) <= 0)
            {
                MessageBox.MyShow(this, "金额需大于零!");
                return;
            }
            #endregion
            lgk.Model.tb_recharge rechargeInfo = new lgk.Model.tb_recharge();
            lgk.Model.tb_systemMoney userInfo=systemBll.GetModel(1); 

            #region 充值实体
            rechargeInfo.RechargeStyle = Convert.ToInt32(dropRechargeStyle.SelectedValue);
            rechargeInfo.RechargeableMoney = Convert.ToDecimal(this.txtMoney.Text.Trim());
            rechargeInfo.RechargeDate = DateTime.Now;
            #endregion

            #region 加入流水账表
            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
            jmodel.JournalDate = DateTime.Now;
            jmodel.JournalType = 3;
            jmodel.UserID =Convert.ToInt32("system");
            if (rechargeInfo.RechargeStyle == 1)
            {

                    rechargeInfo.RechargeType = 2;
                    rechargeInfo.YuAmount =Convert.ToDecimal(userInfo.Money001) + Convert.ToDecimal(this.txtMoney.Text.Trim());
                    jmodel.InAmount = Convert.ToDecimal(this.txtMoney.Text.Trim());
                    jmodel.OutAmount = 0;
                    jmodel.BalanceAmount =Convert.ToDecimal(userInfo.Money001)+ Convert.ToDecimal(this.txtMoney.Text.Trim());
                    jmodel.Remark = "后台充值慈善(增加)";
            }
            if (rechargeInfo.RechargeStyle == 0)
            {
                    if (Convert.ToDecimal(this.txtMoney.Text) > userInfo.Money001)
                    {
                        MessageBox.MyShow(this, "慈善余额不足!");
                        return;
                    }
                    rechargeInfo.RechargeType = 2;
                    rechargeInfo.YuAmount =Convert.ToDecimal(userInfo.Money001) - Convert.ToDecimal(this.txtMoney.Text.Trim());
                    jmodel.InAmount = 0;
                    jmodel.OutAmount = Convert.ToDecimal(this.txtMoney.Text.Trim());
                    jmodel.BalanceAmount = Convert.ToDecimal(userInfo.Money001) - Convert.ToDecimal(this.txtMoney.Text.Trim());
                    jmodel.Remark = "后台充值慈善(扣除)";
            }
            #endregion

            if (rechargeBLL.Add(rechargeInfo) > 0 && journalBLL.Add(jmodel) > 0)
            {
                if (rechargeInfo.RechargeStyle == 1)
                {
                    UpdateSystemAccount("Money001", Convert.ToDecimal(rechargeInfo.RechargeableMoney), 0);//公司账户减少
                }
                else
                {
                    UpdateSystemAccount("Money001", Convert.ToDecimal(rechargeInfo.RechargeableMoney), 1);//公司账户增加
                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='Addcishan.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('充值失败!');", true);
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
