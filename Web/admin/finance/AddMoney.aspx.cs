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
    public partial class AddMoney : AdminPageBase//System.Web.UI.Page
    {
        private string strWhere = "";
        string StarTime;
        string EndTime;
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 36, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密碼
            if (!IsPostBack)
            {
                bind();

            }
        }
        private void bind()
        {
            bind_repeater(GetRechangeList(getWhere()), Repeater1, " RechargeDate desc", tr1, AspNetPager1);
        }
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <returns></returns>
        private string getWhere()
        {
            StarTime = this.txtStart.Text.Trim();
            EndTime = this.txtEnd.Text.Trim();

            strWhere = string.Format(" 1=1");
            if (this.usercode.Text != "")
            {
                strWhere += " and usercode like'%" + SafeHelper.GetSafeSqlandHtml(this.usercode.Text.Trim()) + "%' ";
            }
            if (Convert.ToInt32(dropType.SelectedValue) == 0)
            {
                strWhere += " ";
            }
            else
            {
                strWhere += " and RechargeStyle=" + Convert.ToInt32(dropType.SelectedValue);
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
            lgk.Model.tb_recharge Model = new lgk.Model.tb_recharge();
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
            //if (user.IsOpend == 0)
            //{
            //    MessageBox.MyShow(this, "会员未开通!");
            //    return;
            //}
            Model.UserID = user.UserID;
            if (Convert.ToInt32(dropMoneyType.SelectedValue) == 0)
            {
                MessageBox.MyShow(this, "请选择账户类型!");
                return;
            }
            Model.RechargeType = Convert.ToInt32(dropMoneyType.SelectedValue);
            if (Convert.ToInt32(dropRechargeStyle.SelectedValue) == 0)
            {
                MessageBox.MyShow(this, "请选择充值类型!");
                return;
            }
            Model.RechargeStyle = Convert.ToInt32(dropRechargeStyle.SelectedValue);

            string tMoney = this.txtMoney.Text.Trim();
            if (string.IsNullOrEmpty(tMoney))
            {
                MessageBox.MyShow(this, "充值金额不能为空!");
                return;
            }
            else if (Convert.ToDecimal(tMoney) <= 0)
            {
                MessageBox.MyShow(this, "金额需大于零!");
                return;
            }
            decimal reMoney = Convert.ToDecimal(tMoney);
            //加入流水账表
            lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
            jmodel.UserID = Convert.ToInt32(user.UserID);
            jmodel.JournalDate = DateTime.Now;
            jmodel.JournalType = Model.RechargeType;
            jmodel.Remark = "后台充值" + AccountTypeHelper.GetName((int)Model.RechargeType) + "(增加)";
            if (Model.RechargeStyle == 1)
            {
                jmodel.OutAmount = 0;
                jmodel.JournalType = Model.RechargeType;
                jmodel.InAmount = reMoney;
                if (Model.RechargeType == 1)//原始币
                {
                    Model.YuAmount = user.Emoney + reMoney;
                    jmodel.BalanceAmount = user.Emoney + reMoney;
                }
                if (Model.RechargeType == 2)//释放币
                {
                    Model.YuAmount = user.StockMoney + reMoney;
                    jmodel.BalanceAmount = user.StockMoney + reMoney;
                }
                if (Model.RechargeType == 3)//智能钱包
                {
                    Model.YuAmount = user.BonusAccount + reMoney;
                    jmodel.BalanceAmount = user.BonusAccount + reMoney;
                }
                if (Model.RechargeType == 4)//链接钱包
                {
                    Model.YuAmount = user.AllBonusAccount + reMoney;
                    jmodel.BalanceAmount = user.AllBonusAccount + reMoney;
                }
                if (Model.RechargeType == 5)//交易钱包
                {
                    Model.YuAmount = user.StockAccount + reMoney;
                    jmodel.BalanceAmount = user.StockAccount + reMoney;
                }
                if (Model.RechargeType == 6)//能量值
                {
                    Model.YuAmount = user.GLmoney + reMoney;
                    jmodel.BalanceAmount = user.GLmoney + reMoney;
                }
                if (Model.RechargeType == 7)//购物钱包
                {
                    Model.YuAmount = user.AllBonusAccount + reMoney;
                    jmodel.BalanceAmount = user.AllBonusAccount + reMoney;
                }
            }
            if (Model.RechargeStyle == 2)
            {
                jmodel.InAmount = 0;
                jmodel.JournalType = Model.RechargeType;
                jmodel.OutAmount = reMoney;

                jmodel.Remark = "后台充值" + AccountTypeHelper.GetName((int)Model.RechargeType) + "(扣除)";
                if (Model.RechargeType == 1)
                {
                    if (reMoney > user.Emoney)
                    {
                        MessageBox.MyShow(this, AccountTypeHelper.GetName((int)Model.RechargeType) + "余额不足!");
                        return;
                    }
                    Model.YuAmount = user.Emoney - reMoney;
                    jmodel.BalanceAmount = user.Emoney - reMoney;
                }
                if (Model.RechargeType == 2)
                {
                    if (reMoney > user.StockMoney)
                    {
                        MessageBox.MyShow(this, AccountTypeHelper.GetName((int)Model.RechargeType) + "余额不足!");
                        return;
                    }
                    Model.YuAmount = user.StockMoney - reMoney;
                    jmodel.BalanceAmount = user.StockMoney - reMoney;
                }
                if (Model.RechargeType == 3)
                {
                    if (reMoney > user.BonusAccount)
                    {
                        MessageBox.MyShow(this, AccountTypeHelper.GetName((int)Model.RechargeType) + "余额不足!");
                        return;
                    }
                    Model.YuAmount = user.BonusAccount - reMoney;
                    jmodel.BalanceAmount = user.BonusAccount - reMoney;
                }
                if (Model.RechargeType == 4)
                {
                    if (reMoney > user.AllBonusAccount)
                    {
                        MessageBox.MyShow(this, AccountTypeHelper.GetName((int)Model.RechargeType) + "余额不足!");
                        return;
                    }
                    Model.YuAmount = user.AllBonusAccount - reMoney;

                    jmodel.BalanceAmount = user.AllBonusAccount - reMoney;
                }
                if (Model.RechargeType == 5)
                {
                    if (reMoney > user.StockAccount)
                    {
                        MessageBox.MyShow(this, AccountTypeHelper.GetName((int)Model.RechargeType) + "余额不足!");
                        return;
                    }
                    Model.YuAmount = user.ShopAccount - reMoney;
                    jmodel.BalanceAmount = user.ShopAccount - reMoney;
                }
                if (Model.RechargeType == 6)
                {
                    if (reMoney > user.GLmoney)
                    {
                        MessageBox.MyShow(this, AccountTypeHelper.GetName((int)Model.RechargeType) + "余额不足!");
                        return;
                    }
                    Model.YuAmount = user.GLmoney - reMoney;
                    jmodel.BalanceAmount = user.GLmoney - reMoney;
                }
                if (Model.RechargeType == 7)
                {
                    if (reMoney > user.AllBonusAccount)
                    {
                        MessageBox.MyShow(this, AccountTypeHelper.GetName((int)Model.RechargeType) + "余额不足!");
                        return;
                    }
                    Model.YuAmount = user.AllBonusAccount - reMoney;
                    jmodel.BalanceAmount = user.AllBonusAccount - reMoney;
                }
            }
            Model.RechargeableMoney = reMoney;
            Model.RechargeDate = DateTime.Now;
            Model.Flag = 1;
            if ( rechargeBLL.Add(Model) > 0 && journalBLL.Add(jmodel) > 0)
            {
                string fieldName = "";
                if (Model.RechargeType == 1)
                {
                    fieldName = "Emoney";
                }
                else if (Model.RechargeType == 2)
                {
                    fieldName = "StockMoney";
                }
                else if (Model.RechargeType == 3)
                {
                    fieldName = "BonusAccount"; 
                }
                else if (Model.RechargeType == 4)
                {
                    fieldName = "AllBonusAccount";
                }
                else if (Model.RechargeType == 5)
                {
                    fieldName = "StockAccount";
                }
                else if (Model.RechargeType == 6)
                {
                    fieldName = "GLmoney";
                }
                else if (Model.RechargeType == 7)
                {
                    fieldName = "AllBonusAccount";
                }

                if (Model.RechargeStyle == 1)
                {
                    UpdateAccount(fieldName, Convert.ToInt32(Model.UserID), reMoney, 1);
                    UpdateSystemAccount("MoneyAccount", reMoney, 1);//公司账户增加
                }
                else
                {
                    UpdateAccount(fieldName, Convert.ToInt32(Model.UserID), reMoney, 0);
                    UpdateSystemAccount("MoneyAccount", reMoney, 0);//公司账户减少
                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='AddMoney.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('充值失败!');", true);
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
