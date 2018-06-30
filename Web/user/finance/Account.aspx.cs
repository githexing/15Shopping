/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-7-17 9:26:03 
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

namespace Web.user.finance
{
    public partial class Account : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码
            if (!IsPostBack)
            {
                txtBonus.Value = LoginUser.AllBonusAccount.ToString();
                txtEmoney.Value = LoginUser.Emoney.ToString();
                txtMoney.Value = LoginUser.BonusAccount.ToString();
            }
        }
    }
}
