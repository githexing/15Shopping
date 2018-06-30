using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.finance
{
    public partial class Remit2 : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Emoney.Text = LoginUser.Emoney.ToString();
            UserCode.Text = LoginUser.UserCode;
        }

        protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
        {
            if (TxtmMoney1.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入充值金额');", true);
                return;
            }
            if (TxtmMoney1.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入确认金额');", true);
                return;
            }

            decimal jy = Convert.ToDecimal(TxtmMoney1.Value.Trim());
            decimal qr = Convert.ToDecimal(TxtSecond.Value.Trim());
            string amount;

            if (jy <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入有效的充值金额');", true);
                return;
            }
            if (qr <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入有效的确认金额');", true);
                return;
            }
            if (qr != jy)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('充值金额跟确认金额不一致！');", true);
                return;
            }

            amount = jy.ToString();
            if (PageValidate.IsNumberOrDecimal(amount))
            {
                decimal a = Convert.ToDecimal(amount);
                decimal b = getParamAmount("AlipayMoney");
                if (b != 0 && a % b != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您输入的金额需要是"+ b +"的整数倍！');", true);
                    return;
                }
                if (Convert.ToDecimal(amount) <= 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('充值金额要大于 0 ！');window.location.href='OnlineRecharge.aspx';", true);
                }
                else
                {
                    Response.Redirect(string.Format("OnlineRechargeAlipay.aspx?RechargeAmount={0}", amount));
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('输入的金额不合法，请重新输入！');window.location.href='OnlineRecharge.aspx';", true);
            }

            //try
            //{
            //    decimal jy = Convert.ToDecimal(TxtmMoney1.Value.Trim());
            //    decimal qr = Convert.ToDecimal(TxtSecond.Value.Trim());

            //    if (jy == 0)
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入有效的充值金额');", true);
            //        return;
            //    }
            //    if (qr == 0)
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入有效的确认金额');", true);
            //        return;
            //    }
            //    decimal dAmount = Convert.ToDecimal(this.TxtmMoney1.Value.Trim());

            //    lgk.Model.tb_recharge rechargeInfo = new lgk.Model.tb_recharge();

            //    rechargeInfo.UserID = LoginUser.UserID;
            //    rechargeInfo.RechargeStyle = 1;//1：增加
            //    rechargeInfo.RechargeType = 1;//1：电子币
            //    rechargeInfo.RechargeableMoney = dAmount;
            //    rechargeInfo.RechargeDate = DateTime.Now;
            //    rechargeInfo.YuAmount = LoginUser.Emoney + dAmount;
            //    rechargeInfo.Recharge001 = 0;  //在线支付
            //    rechargeInfo.Flag = 0;

            //    if (rechargeBLL.Add(rechargeInfo) > 0)
            //    {
            //        lgk.Model.tb_recharge model = rechargeBLL.GetModel(" UserID=" + LoginUser.UserID + " AND RechargeDate=" + rechargeInfo.RechargeDate);
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='Paydown.aspx?RechargeID=" + model.ID + "';", true);
            //    }

            //}
            //catch
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('输入的金额格式错误');", true);
            //    return;
            //}
            
        }
    }
}