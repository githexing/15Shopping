/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-16 10:49:17 
 * 文 件 名：		LeaveMsg.cs 
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
using System.Web.UI.HtmlControls;
using Library;
using System.Data;

namespace Web.user.member
{
    public partial class LeaveMsg : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //spd.jumpUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();
            }
        }


        /// <summary>
        /// 填充收件箱
        /// </summary>
        protected void BindData()
        {
            string strWhere = "ToUserID=" + getLoginID() + "and ToUserType = 1 and ToIDIsDel = 0";
            bind_repeater(leaveMsgBLL.GetList(strWhere), Repeater1, "IsReply, LeaveTime desc", tr1, AspNetPager1);
        }


        /// <summary>
        /// 收件箱分页控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
