using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;
using System.Data.SqlClient;

namespace Web.user.finance
{
    public partial class RecommendBonus : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码
            if (!IsPostBack)
            {
                bind();
                Button1.Text = GetLanguage("AccountsQueries");//账户查询
                //Button4.Text = GetLanguage("Transfer");//账户转账
                btnSearch.Text = GetLanguage("Search");//搜索
            }
        }

        private void bind()
        {

            bind_repeater(bo.GetList_money1(6,getWhere()," OpenTime "), Repeater1, "SttleTime desc", trBonusNull, AspNetPager1);
        }

        private string getWhere()
        {
            string strWhere = "";
            strWhere = string.Format(" RecommendID= " + getLoginID());
            if (GetLanguage("LoginLable") == "zh-cn")
            {
                if (this.txtStar.Text != "")
                {
                    strWhere += string.Format(" and Convert(nvarchar(10),SttleTime,120)  >= '" + this.txtStar.Text + "'");
                }
                if (this.txtEnd.Text != "")
                {
                    strWhere += string.Format("  and Convert(nvarchar(10),SttleTime,120)  <= '" + this.txtEnd.Text + "'");
                }
            }
            else
            {
                if (this.txtStarEn.Text != "")
                {
                    strWhere += string.Format(" and Convert(nvarchar(10),SttleTime,120)  >= '" + this.txtStarEn.Text + "'");
                }
                if (this.txtEndEn.Text != "")
                {
                    strWhere += string.Format("  and Convert(nvarchar(10),SttleTime,120)  <= '" + this.txtEndEn.Text + "'");
                }
            }
            return strWhere;
        }
        
        //private void bind()
        //{
        //    bind_repeater(bo.GetList_money(getWhere()), Repeater1, "SttleTime desc", trBonusNull, AspNetPager1);
        //}

        //private string getWhere()
        //{
        //    string strWhere = "";
        //    strWhere = string.Format(" b.Amount<>0  and u.UserID= " + getLoginID());
        //    if (GetLanguage("LoginLable") == "zh-cn")
        //    {
        //        if (this.txtStar.Text != "")
        //        {
        //            strWhere += string.Format(" and Convert(nvarchar(10),SttleTime,120)  >= '" + this.txtStar.Text + "'");
        //        }
        //        if (this.txtEnd.Text != "")
        //        {
        //            strWhere += string.Format("  and Convert(nvarchar(10),SttleTime,120)  <= '" + this.txtEnd.Text + "'");
        //        }
        //    }
        //    else
        //    {
        //        if (this.txtStarEn.Text != "")
        //        {
        //            strWhere += string.Format(" and Convert(nvarchar(10),SttleTime,120)  >= '" + this.txtStarEn.Text + "'");
        //        }
        //        if (this.txtEndEn.Text != "")
        //        {
        //            strWhere += string.Format("  and Convert(nvarchar(10),SttleTime,120)  <= '" + this.txtEndEn.Text + "'");
        //        }
        //    }
        //    return strWhere;
        //}

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