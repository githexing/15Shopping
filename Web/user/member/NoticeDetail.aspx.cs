/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-19 17:54:34 
 * 文 件 名：		NoticeDetail.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：
**********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
namespace web.user.member
{
    public partial class NoticeDetail : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
                {
                    BindData(Request.QueryString["id"]);
                }

                //btnBack.Text = GetLanguage("Return");//返回
            }
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        protected void BindData(string id)
        {
            lgk.Model.tb_news newInfo = newsBLL.GetModel(Convert.ToInt64(id));
            if (newInfo != null)
            {
                ltTitle.Text = newInfo.NewsTitle;
                LitPublishTime.Text = newInfo.PublishTime.ToString("yyyy-MM-dd");
                LitPublisher.Text = newInfo.Publisher;
                ltContent.Text = newInfo.NewsContent;
            }
        }

        ///// <summary>
        ///// 返回
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnBack_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("NoticeList.aspx");
        //}
    }
}
