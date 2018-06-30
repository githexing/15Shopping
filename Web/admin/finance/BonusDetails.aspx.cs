/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-14 15:22:40 
 * 文 件 名：		BonusDetails.cs 
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
using System.Data;
using Library;

namespace Web.admin.finance
{
    public partial class BonusDetails : AdminPageBase//System.Web.UI.Page
    {
        private string strWhere = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 14, getLoginID());//权限
            if (!IsPostBack)
            {
                BonusType();
                BindData();
            }
        }
        private void BonusType()
        {
            IList<lgk.Model.tb_bonusType> list = new lgk.BLL.tb_bonusType().GetModelList("");
            this.ddlBonus.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            ddlBonus.Items.Add(li);
            foreach (lgk.Model.tb_bonusType item in list)
            {
                ListItem items = new ListItem();
                items.Value = item.TypeID.ToString();
                items.Text = item.TypeName;
                ddlBonus.Items.Add(items);
            }
        }
        private void BindData()
        {
            bind_repeater(bo.GetUserBonus(GetWhere()), Repeater1, "SttleTime desc", tr1, AspNetPager1);
        }

        private string GetWhere()
        {
            long iUserID = Convert.ToInt32(Request.QueryString["UserID"].ToString());
            string SttleTime = Request.QueryString["SttleTime"].ToString();
            strWhere = string.Format(" b.Amount<>0 and b.UserID=" + iUserID + " and Convert(nvarchar(10),SttleTime,120)='" + SttleTime + "'");
            if (Convert.ToInt32(this.ddlBonus.SelectedValue) == 0)
            {
                strWhere += " ";
            }
            else
            {
                strWhere += " and b.typeid=" + Convert.ToInt32(ddlBonus.SelectedValue);
            }
            return strWhere;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("BonusDetail.aspx?SttleTime=" + Request.QueryString["SttleTime"].ToString());
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
