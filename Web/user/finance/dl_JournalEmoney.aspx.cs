/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-6-8 18:02:38 
 * 文 件 名：		dl_JournalEmoney.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 備注描述：         
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
    public partial class dl_JournalEmoney : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindCurrency();
                BindData();
                btnSearch.Text = GetLanguage("Search");//搜索
            }
        }

        ///// <summary>
        ///// 绑定币种
        ///// </summary>
        //public void BindCurrency()
        //{
        //    if (currentCulture == "zh-cn")
        //    {
        //        dropCurrency.Items.Add(new ListItem("-请选择-", "0"));
        //        dropCurrency.Items.Add(new ListItem("流通币", "1"));
        //        dropCurrency.Items.Add(new ListItem("MDD钻币", "2"));
        //        dropCurrency.Items.Add(new ListItem("购物币", "4"));
        //        dropCurrency.Items.Add(new ListItem("注册币", "5"));
        //    }
        //    else
        //    {
        //        dropCurrency.Items.Add(new ListItem("-Please choose-", "0"));
        //        dropCurrency.Items.Add(new ListItem("Currency", "1"));
        //        dropCurrency.Items.Add(new ListItem("MDD Drill", "2"));
        //        dropCurrency.Items.Add(new ListItem("Shopping currency", "4"));
        //        dropCurrency.Items.Add(new ListItem("Registered currency", "5"));
        //    }
        //    //dropCurrency.Items.Add(new ListItem("平台费用", "3"));
        //}

        private void BindData()
        {
            bind_repeater(journalBLL.GetList(GetWhere()), Repeater1, "id desc", tr1, AspNetPager1);
        }

        private string GetWhere()
        {
            string strWhere = string.Format("u.UserID=" + getLoginID());

            //if (dropCurrency.SelectedValue != "0" && PageValidate.IsInt(dropCurrency.SelectedValue))
            //{
            //    strWhere += " AND j.JournalType=" + dropCurrency.SelectedValue + "";
            //}

            string strStartTime = this.txtStart.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();
            if (GetLanguage("LoginLable") == "en-us")
            {
                strStartTime = this.txtStartEn.Text.Trim();
                strEndTime = this.txtEndEn.Text.Trim();
            }

            if (strStartTime != "" && strEndTime == "" && PageValidate.IsDateTime(strStartTime))
            {
                strWhere += string.Format(" and Convert(nvarchar(10),j.JournalDate,120) >= '" + strStartTime + "' ");
            }
            else if (strStartTime == "" && strEndTime != "" && PageValidate.IsDateTime(strEndTime) )
            {
                strWhere += string.Format(" and Convert(nvarchar(10),j.JournalDate,120) <= '" + strEndTime + "' ");
            }
            else if (strStartTime != "" && strEndTime != "" && PageValidate.IsDateTime(strStartTime) && PageValidate.IsDateTime(strEndTime))
            {
                strWhere += string.Format(" and Convert(nvarchar(10),j.JournalDate,120) between '" + strStartTime + "' and '" + strEndTime + "' ");
            }
            return strWhere;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("dl_JournalAccount.aspx");
        }
    }
}