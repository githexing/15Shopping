/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-14 16:18:05 
 * 文 件 名：		Account.cs 
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
using DataAccess;

namespace Web.admin.finance
{
    public partial class Account : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 13, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                //txtMoneyAccount.Value = smoneyBLL.GetModel().MoneyAccount.ToString();
                //txtAllBonusAccount.Value = smoneyBLL.GetModel().AllBonusAccount.ToString();
                bind_Pay();
            }
        }
        private void bind_Pay()
        {
            Label1.Text = Convert.ToInt32(DbHelperSQL.GetSingle("select count(*) from tb_MachineDetail ")).ToString(); //拨出矿机
            Label2.Text = Convert.ToInt32(DbHelperSQL.GetSingle("select count(*) from tb_MachineDetail where isActive = 1")).ToString();//激活矿机
            Label3.Text = Convert.ToDecimal(DbHelperSQL.GetSingle("select sum(emoney) from tb_user where emoney > 0")).ToString();// 原始币数量
            Label4.Text = Convert.ToDecimal(DbHelperSQL.GetSingle("select sum(bonusaccount) from tb_user where bonusaccount > 0")).ToString();//释放币数量
            Label5.Text = Convert.ToDecimal(DbHelperSQL.GetSingle("select count(*) from tb_takeMoney where Flag=0")).ToString();
            Label6.Text = GetTotalTake(0).ToString("0.00"); //Convert.ToInt32(DbHelperSQL.GetSingle("select isnull(sum(isnull(TakeMoney,0)),0) from tb_takeMoney where Flag<>0 and UserID<>1")).ToString();
            Label7.Text = Convert.ToDecimal(DbHelperSQL.GetSingle("select sum(StockMoney) from tb_user where StockMoney > 0")).ToString();
            //Label8.Text = Convert.ToInt32(DbHelperSQL.GetSingle("select count(*) from tb_remit where State=0")).ToString();
            string where1 = " ";
            string where2 = " ";
            if (txtStar.Text != "")
            {
                where1 += string.Format(" and recordTime  >= convert(varchar(10),'" + txtStar.Text.Trim() + "',120)");
                 where2 += string.Format(" and addTime  >= convert(varchar(10),'" + txtStar.Text.Trim() + "',120)");
            }
            if (txtEnd.Text != "")
            {
                where1 += string.Format(" and recordTime  <= convert(varchar(10),'" + txtEnd.Text.Trim() + "',120)");
                 where2 += string.Format(" and addTime  <= convert(varchar(10),'" + txtEnd.Text.Trim() + "',120)");
            }
          //  bind_repeater(GetPayScale(where1, where2), Repeater1, "recordTime desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind_Pay();
        }
        public string MyBL(object shour,object zhuc) 
        {
            string str = "-";
            if(shour!=null&&zhuc!=null)
            {
                float z = 0;
                float s = 0;
                float.TryParse(shour.ToString(),out s);
                float.TryParse(zhuc.ToString(),out z);
                if (s > 0) 
                {
                  str=  ((z / s)*(float)100).ToString("0.00")+"%";
                }
            }
            return str;
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            bind_Pay();
        }
    }
}
