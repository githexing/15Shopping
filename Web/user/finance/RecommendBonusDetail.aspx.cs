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
    public partial class RecommendBonusDetail : PageCore//System.Web.UI.Page
    {
        public string cnen = "zh-cn";
        private string strWhere = "";
        //string theUserIDValue = Session["UserID"];

        protected void Page_Load(object sender, EventArgs e)
        {
            cnen = GetLanguage("LoginLable");
            if (!IsPostBack)
            {
                ddlL();
                bind();
            }
            Button1.Text = GetLanguage("Return");//返回
            Button2.Text = GetLanguage("AccountsQueries");//账户查询
            Button4.Text = GetLanguage("Transfer");//账户转账
            btnSearch.Text = GetLanguage("Search");//搜索
        }

        private void ddlL()
        {
            IList<lgk.Model.tb_bonusType> ddlList = new lgk.BLL.tb_bonusType().GetModelList(" TypeID<=7");
            this.ddlBonus.Items.Clear();
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
            ddlBonus.Items.Add(li);
            foreach (lgk.Model.tb_bonusType item in ddlList)
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
                ddlBonus.Items.Add(items);
            }
        }

        private void bind()
        {
            string SttleTime = Request.QueryString["SttleTime"].ToString();
            strWhere = string.Format(" b.Amount<>0  and b.userid=" + Request.QueryString["UserID"] + " and Convert(nvarchar(10),SttleTime,120)='" + SttleTime + "'");
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
