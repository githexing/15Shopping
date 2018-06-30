using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.finance
{
    public partial class RechargeList : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl1(this.Page, 1);//跳转3级密码

            if (!IsPostBack)
            {
                BindData();
                btnSearch.Text = GetLanguage("Search");//搜索
            }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = " u.UserID=" + getLoginID() + " AND Recharge001 >= 2 ";  //Recharge001 = 1 是后台充值，前台不需要显示

            if (GetLanguage("LoginLable") == "zh-cn")
            {
                if (this.txtStar.Text != "")
                {
                    strWhere += " and convert(varchar(10),RechargeDate,120) >='" + this.txtStar.Text + "'";
                }
                if (this.txtEnd.Text != "")
                {
                    strWhere += " and convert(varchar(10),RechargeDate,120) <='" + this.txtEnd.Text + "'";
                }
            }
            else
            {
                if (this.txtStarEn.Text != "")
                {
                    strWhere += " and convert(varchar(10),RechargeDate,120) >='" + this.txtStarEn.Text + "'";
                }
                if (this.txtEndEn.Text != "")
                {
                    strWhere += " and convert(varchar(10),RechargeDate,120) <='" + this.txtEndEn.Text + "'";
                }
            }
            return strWhere;
        }

        /// <summary>
        /// 填充
        /// </summary>
        protected void BindData()
        {
            bind_repeater(GetRechangeList(GetWhere()), Repeater1, "RechargeDate desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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