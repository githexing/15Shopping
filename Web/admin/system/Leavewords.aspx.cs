/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-19 17:02:36 
 * 文 件 名：		Leavewords.cs 
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

namespace web.admin.system
{
    public partial class Leavewords : AdminPageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 23, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_admin fromAdmin = adminBLL.GetModel(getLoginID());
            lgk.Model.tb_user user = null;//收件人
            if (textUserCode.Value=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('留言对象不能为空!');", true);
                return;
            }
            //验证是否存在会员
            user = userBLL.GetModel(GetUserID(textUserCode.Value.Trim()));
            if (user == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('不存在的账号!');", true);
                return;
            }
            if (user.IsOpend == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('会员未开通!');", true);
                return;
            }
            if (textTitle.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('标题不能为空!');", true);
                return;
            }
            if (txtPubContext.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('内容不能为空!');", true);
                return;
            }
            lgk.Model.tb_leaveMsg leaveMsg = new lgk.Model.tb_leaveMsg()
            {
                MsgTitle = textTitle.Value,
                MsgContent = txtPubContext.Text,
                LeaveTime = DateTime.Now,
                IsRead = 0,
                IsReply = 0,
                FromUserType = 2,
                UserID = 1,
                UserCode = "admin",
                FromIDIsDel = 0,
                ToIDIsDel = 0,

            };
            leaveMsg.ToUserType = 1;
            leaveMsg.ToUserID = user.UserID;
            leaveMsg.ToUserCode = user.UserCode;
            if (leaveMsgBLL.Add(leaveMsg) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('发送成功！');window.location.href='LeaveOut.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('发送失败!');", true);
            }

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveOut.aspx");
        }
    }
}
