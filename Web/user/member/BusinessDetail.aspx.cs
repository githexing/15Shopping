/*********************************************************************************
*Copyright(c) 	2012 RJ.COM
 * 创建日期：		2012-5-8 17:46:07
 * 文 件 名：		BusinessDetail.cs
 * CLR 版本:		2.0.50727.3053
 * 创 建 人：		
 * 文件版本：		1.0.0.0
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
    public partial class BusinessDetail : PageCore//System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                BindData(Request.QueryString["id"]);
            }
        }
        /// <summary>
        /// 填充数据
        /// </summary>
        protected void BindData(string id)
        {
            lgk.Model.tb_news newInfo = newsBLL.GetModel(Convert.ToInt64(id));
            lblTitle.Text = newInfo.NewsTitle;
            lblAuthor.Text = newInfo.Publisher;
            lblDate.Text = newInfo.PublishTime.ToString("yyyy-MM-dd HH:mm:ss");
            lilContent.Text = newInfo.NewsContent;
            newInfo.Click += 1;
            newsBLL.Update(newInfo);
        }
        
    }
}
