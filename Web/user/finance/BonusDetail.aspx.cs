/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-14 15:40:52 
 * 文 件 名：		BonusDetail.cs 
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

namespace Web.user.finance
{
    public partial class BonusDetail : PageCore//System.Web.UI.Page
    {
        public string cnen = "zh-cn";
        private string strWhere = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            cnen = GetLanguage("LoginLable");
            if (!IsPostBack)
            {
                BonusType();
                BindData();
            }
            //btnBack.Text = GetLanguage("Return");//返回
            btnSearch.Text = GetLanguage("Search");//搜索
        }

        private void BonusType()
        {
            IList<lgk.Model.tb_bonusType> list = new lgk.BLL.tb_bonusType().GetModelList("");
            this.dropBonus.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            if (cnen == "zh-cn")
            {
                li.Text = "-请选择-";
            }
            else
            {
                li.Text = "-please choose-";
            }
            dropBonus.Items.Add(li);
            foreach (lgk.Model.tb_bonusType item in list)
            {
                ListItem items = new ListItem();
                items.Value = item.TypeID.ToString();
                if (cnen == "zh-cn")
                {
                    items.Text = item.TypeName;
                }
                else
                {
                    items.Text = item.TypeNameEn;
                }
                dropBonus.Items.Add(items);
            }
        }

        private void BindData()
        {
            string SttleTime = Request.QueryString["SttleTime"].ToString();
            strWhere = string.Format(" b.Amount<>0  and b.UserID=" + getLoginID() + " and Convert(nvarchar(10),SttleTime,120)='" + SttleTime + "'");
            if (Convert.ToInt32(this.dropBonus.SelectedValue) == 0)
            {
                strWhere += " ";
            }
            else
            {
                strWhere += " and b.TypeID = " + Convert.ToInt32(dropBonus.SelectedValue);
            }
            bind_repeater(bo.GetUserBonus(strWhere), Repeater1, "SttleTime desc", tr1, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
