using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.admin.system
{
    public partial class message : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 22, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                BindData();
            }
        }
        /// <summary>
        /// 填充数据
        /// </summary>
        protected void BindData()
        {
            bind_repeater(messageBLL.GetList("1=1 order by MID desc"), rpNews, "", trNull, anpNews);
        }
        protected void anpNews_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}