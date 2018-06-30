/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-7-16 17:43:01 
 * 文 件 名：		@default.cs 
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

namespace Web.user
{
    public partial class _default : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // BindLanguage();
                BindData();
            }
        }

        //private void BindLanguage()
        //{
        //    if (currentCulture == "zh-cn")
        //    {
        //        dropLanguage.Items.Add(new ListItem("-请选择-", "0"));
        //        dropLanguage.Items.Add(new ListItem("中文", "1"));
        //        dropLanguage.Items.Add(new ListItem("English", "2"));
        //    }
        //    else
        //    {
        //        dropLanguage.Items.Add(new ListItem("-Please choose-", "0"));
        //        dropLanguage.Items.Add(new ListItem("中文", "1"));
        //        dropLanguage.Items.Add(new ListItem("English", "2"));
        //    }
        //}

        //protected void dropLanguage_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int iLanguage = int.Parse(dropLanguage.SelectedValue);

        //    if (iLanguage == 1)
        //    {
        //        HttpCookie CultureCookie = new HttpCookie("Culture");
        //        CultureCookie.Value = "zh-cn";//中文
        //        Response.AppendCookie(CultureCookie);

        //        //登录系统
        //        Response.Write("<script type='text/javascript'>window.parent.location.href='index.aspx';</script>");

        //    }
        //    else if (iLanguage == 2)
        //    {
        //        HttpCookie CultureCookie = new HttpCookie("Culture");
        //        CultureCookie.Value = "en-us";//英文
        //        Response.AppendCookie(CultureCookie);

        //        Response.Write("<script type='text/javascript'>window.parent.location.href='index.aspx';</script>");
        //    }
        //}

        /// <summary>
        /// 绑定公司快讯
        /// </summary>
        private void BindData()
        {
            if (Language == "zh-cn")
            {
                bind_repeater(newsBLL.GetList(8, "NewsType=0 and New01=0", "PublishTime desc"), Repeater1, "PublishTime desc", tr1, 8);
            }
            else if (Language == "en-us")
            {
                bind_repeater(newsBLL.GetList(8, "NewsType=0 and New01=1", "PublishTime desc"), Repeater1, "PublishTime desc", tr1, 8);
            }
        }
    }
}
