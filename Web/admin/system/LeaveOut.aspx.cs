/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-30 17:30:54 
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
using System.Web.UI.HtmlControls;

namespace Web.admin.system
{
    public partial class LeaveOut : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 23, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindSendMail();
            }
        }

        /// <summary>
        /// 填充发件箱
        /// </summary>
        protected void BindSendMail()
        {
            string condition = "UserID=" + getLoginID() + " and FromUserType=2 and FromIDIsDel=0";
            if (textInCode.Value.Trim() != "")
            {
                condition += " and ToUserCode like '%" + textInCode.Value.Trim() + "%'";
            }
            bind_repeater(leaveMsgBLL.GetList(condition), rpSendBox, "LeaveTime desc", trSendNull, anpSendMail);
        }
        /// <summary>
        /// 发件箱全选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckAllSend_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < rpSendBox.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)rpSendBox.Items[i].FindControl("CheckBoxSend");
                chk.Checked = ckAllSend.Checked;
            }
        }
        /// <summary>
        /// 删除发件箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelSend_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            bool succeed = true;
            string strID = "";
            for (int i = 0; i < rpSendBox.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)rpSendBox.Items[i].FindControl("CheckBoxSend");
                if (chk.Checked == true)
                {
                    strID += chk.Value;
                    strID += ",";
                }
            }
            if (strID.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('没有可删除的邮件!');", true);
                return;
            }
            strID = strID.Substring(0, strID.Length - 1);
            string[] array = strID.Split(',');
            for (int i = 0; i < array.Length; i++)
            {
                if (DelEmail(Convert.ToInt64(array[i]), 1) == 0)
                {
                    succeed = false;
                    break;
                }
            }
            if (succeed)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('删除成功!');", true);
                BindSendMail();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('删除失败!');", true);
            }
        }

        /// <summary>
        /// 发件箱分页控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void anpsendMail_PageChanged(object sender, EventArgs e)
        {
            BindSendMail();
        }
        /// <summary>
        /// 留言
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendLeave_Click(object sender, EventArgs e)
        {
            Response.Redirect("Leavewords.aspx");
        }
        /// <summary>
        /// 搜索发件箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendSearch_Click(object sender, EventArgs e)
        {
            BindSendMail();
        }
        protected void btn_s1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveIn.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveOut.aspx");
        }
    }
}
