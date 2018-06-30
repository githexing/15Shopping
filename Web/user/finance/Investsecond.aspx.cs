using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user.finance
{
    public partial class Investsecond : PageCore
    {
        lgk.BLL.tb_OrderInvest investBLL = new lgk.BLL.tb_OrderInvest();

        public int InvestSecondAmountMul;
        public int InvestSecondAmountMax;

        protected void Page_Load(object sender, EventArgs e)
        {
            InvestSecondAmountMul = getParamInt("InvestSecondAmountMul");
            InvestSecondAmountMax = getParamInt("InvestSecondAmountMax");
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            bind_repeater(investBLL.GetList(" AccountType = 2 and UserID=" + getLoginID()), Repeater1, "AddTime desc", tr1, AspNetPager1);
        }


        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnInvest_Click(object sender, EventArgs e)
        {
            if (LoginUser.IsOpend == 0)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("AccountNoActiveInfo"), Library.Enums.ModalTypes.error);//您的帐号未激活
                return;
            }

            if (LoginUser.IsLock == 1)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("AccountLock"), GetLanguage("AccountLockInfo"), Library.Enums.ModalTypes.error);//您的帐号已冻结，不能进行操作
                return;
            }

            int money;
            int.TryParse(txtMoney.Text, out money);

            if (money <= 0)
            {
                MessageBox.ShowBox(this.Page,"请输入投资金额", Library.Enums.ModalTypes.info);//请输入投资金额
                return;
            }

            if(money % InvestSecondAmountMul != 0)
            {
                MessageBox.ShowBox(this.Page,string.Format("投资金额必须是{0}的倍数", InvestSecondAmountMul), Library.Enums.ModalTypes.info);//请输入投资金额
                return;
            }
            decimal allamount = GetSecondInvestAmount(LoginUser.UserID);
            if ((allamount + money) > InvestSecondAmountMax)
            {
                MessageBox.ShowBox(this.Page,string.Format("投资累计不能大于{0}", InvestSecondAmountMax), Library.Enums.ModalTypes.info);//投资金额不能大于 3000
                return;
            }

            int InvestPrimaryAmount = money;
            int investType = 1;//投资积分

            if (LoginUser.StockMoney < InvestPrimaryAmount)
            {
                MessageBox.ShowBox(this.Page,"投资积分不足", Library.Enums.ModalTypes.warning);//投资积分不足
                return;
            }

            if (LoginUser.User001 != 1)
            {
                MessageBox.ShowBox(this.Page,"您未开通分号，不能用分号进行投资！", Library.Enums.ModalTypes.warning);//您未开通分号，不能用分号进行投资！
                return;
            }

            int flag = proc_Invest(LoginUser.UserID, Util.CreateNo(), 2, investType, InvestPrimaryAmount);

            if (flag == 0)
            {
                BindData();
                LoginUser = userBLL.GetModel(getLoginID());
                MessageBox.ShowBox(this.Page,"投资成功", Library.Enums.ModalTypes.success);//投资成功
                return;
            }
            else
            {
                MessageBox.ShowBox(this.Page,"投资失败", Library.Enums.ModalTypes.error);//投资失败
                return;
            }
        }


    }
}