/*********************************************************************************
*Copyright(c) 	2012 RJ.COM
 * 创建日期：		2012-5-8 10:48:21
 * 文 件 名：		Business.cs
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
using BLL;
using System.Data;
using Library;

namespace web.user.member
{
    public partial class Business : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 填充信息
        /// </summary>
        protected void BindData()
        {
            bind_repeater(newsBLL.GetList("NewType=2"), rpBusiness, "Click desc,PublishTime desc", divNull, anpBusiness);
        }

        protected void anpGoods_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
