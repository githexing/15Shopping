/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-11-29 10:27:39 
 * 文 件 名：		dl_BonusDetail.cs 
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

namespace Web.user.finance
{
    public partial class dl_BonusDetail : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlL();
                bind();
            }
        }
        private void ddlL()
        {
            IList<lgk.Model.tb_bonusType> ddlList = new lgk.BLL.tb_bonusType().GetModelList(" TypeID>0");
            this.ddlBonus.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            ddlBonus.Items.Add(li);
            foreach (lgk.Model.tb_bonusType item in ddlList)
            {
                ListItem items = new ListItem();
                items.Value = item.TypeID.ToString();
                items.Text = item.TypeName;
                ddlBonus.Items.Add(items);
            }
        }
        private void bind()
        {
            string SttleTime = Request.QueryString["SttleTime"].ToString();
            string strWhere = string.Format(" b.Amount<>0 and b.Bonus001=2  and b.userid=" + getLoginID() + " and Convert(nvarchar(10),SttleTime,120)='" + SttleTime + "'");
            if (Convert.ToInt32(this.ddlBonus.SelectedValue) == 0)
            {
                strWhere += " ";
            }
            else
            {
                strWhere += " and b.typeid=" + Convert.ToInt32(ddlBonus.SelectedValue);
            }
            bind_repeater(bo.GetUserBonus(strWhere), Repeater1, "SttleTime desc", trBonusNull, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
    }
}
