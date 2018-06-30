/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-6-8 9:53:50 
 * 文 件 名：		LeaveOut.cs 
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

namespace Web.user.member
{
    public partial class LeaveOut : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 填充发件箱
        /// </summary>
        protected void BindData()
        {
            string strWhere = "UserID=" + getLoginID() + " and FromUserType = 1 and FromIDIsDel = 0";
            bind_repeater(leaveMsgBLL.GetList(strWhere), Repeater1, "LeaveTime desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 发件箱分页控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
