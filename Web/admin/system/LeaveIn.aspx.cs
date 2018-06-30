/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-30 17:20:11 
 * 文 件 名：		LeaveIn.cs 
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
    public partial class LeaveIn : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 23, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                BindInMail();
            }
        }
        /// <summary>
        /// 填充收件箱
        /// </summary>
        protected void BindInMail()
        {
            string condition = " ToUserType=2 and ToIDIsDel=0";
            if (textSendCode.Value.Trim() != "")
            {
                condition += " and UserCode like '%" + textSendCode.Value.Trim() + "%'";
            }
            bind_repeater(leaveMsgBLL.GetList(condition), rpInBox, "IsReply,LeaveTime desc", trInNull, anpInMail);
        }
        /// <summary>
        /// 收件箱全选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckAllIn_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < rpInBox.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)rpInBox.Items[i].FindControl("CheckBoxIn");
                chk.Checked = ckAllIn.Checked;
            }
        }

        /// <summary>
        /// 删除收件箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInDel_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            bool succeed = true;
            string strID = "";
            for (int i = 0; i < rpInBox.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)rpInBox.Items[i].FindControl("CheckBoxIn");
                if (chk.Checked == true)
                {
                    strID += chk.Value;
                    strID += ",";
                }
            }
            if (strID.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('没有要删除的邮件!');", true);
                return;
            }
            strID = strID.Substring(0, strID.Length - 1);
            string[] array = strID.Split(',');
            for (int i = 0; i < array.Length; i++)
            {
                if (DelEmail(Convert.ToInt64(array[i]), 2) == 0)
                {
                    succeed = false;
                    break;
                }
            }
            if (succeed)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('删除成功!');", true);
                BindInMail();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('删除失败!');", true);
            }

        }
        /// <summary>
        /// 收件箱分页控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void anpInMail_PageChanged(object sender, EventArgs e)
        {
            BindInMail();
        }
        /// <summary>
        /// 搜索收件箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInSearch_Click(object sender, EventArgs e)
        {
            BindInMail();
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
