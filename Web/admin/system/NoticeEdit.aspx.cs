/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-19 13:44:10 
 * 文 件 名：		NoticeEdit.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		黎胜刚
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
    public partial class NoticeEdit : AdminPageBase
    {
        long iNoticeID = 0;
       // string strAction = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 22, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            if (Request["ID"] != null && Request["ID"].Length > 0)
            {
                if (PageValidate.IsInteger(Request["ID"].ToString()))
                    iNoticeID = long.Parse(Request["ID"].ToString());
                else
                    iNoticeID = 0;
            }
            else
            {
                //strAction = "";
            }

            if (!IsPostBack)
            {
                if (iNoticeID > 0)
                {
                    BindData();
                }
                else
                {
                    txtTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }

                lbltitle.Text = "发布信息";
                this.rdoZH.Checked = true;
            }
        }

        /// <summary>
        /// 填充信息
        /// </summary>
        protected void BindData()
        {
            lgk.Model.tb_news newInfo = newsBLL.GetModel(iNoticeID);
            txtTitle.Text = newInfo.NewsTitle;
            textPubContext.Value = newInfo.NewsContent;
            txtTime.Text = newInfo.PublishTime.ToString();
            dropNewType.SelectedValue = newInfo.NewType.ToString();
            if (newInfo.New01 == 0)
            {
                rdoZH.Checked = true;
                rdoEn.Checked = false;
            }
            else
            {
                rdoEn.Checked = true;
                rdoZH.Checked = false;
            }
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        protected bool validate()
        {
            if (txtTitle.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('标题不能为空!');", true);
                return false;
            }
            if (textPubContext.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('内容不能为空!');", true);
                return false;
            }
            if (txtTime.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入发布时间!');", true);
                return false;
            }
            return true;
        }

        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            if (validate())
            {
                lgk.Model.tb_news newInfo = new lgk.Model.tb_news();
                newInfo.NewsTitle = txtTitle.Text;
                newInfo.NewsContent = textPubContext.Value;
                //newInfo.NewsType = 1;
                newInfo.Publisher = getColumn(0, "TrueName", "tb_admin", "ID=" + getLoginID(), "");
                DateTime dt = DateTime.Now;
                DateTime.TryParse(txtTime.Text.Trim(), out dt);
                newInfo.PublishTime = dt;
                newInfo.NewType = int.Parse(dropNewType.SelectedValue);
                if (rdoEn.Checked)
                {
                    newInfo.New01 = 1;//英文
                }
                if (rdoZH.Checked)
                {
                    newInfo.New01 = 0;//中文
                }
                if (iNoticeID > 0)
                {
                    newInfo.ID = Convert.ToInt64(iNoticeID);
                    if (newsBLL.Update(newInfo))
                    {
                        MessageBox.ShowAndRedirect(this.Page, "修改成功", "NoticeManage.aspx");
                    }
                }
                else
                {
                    if (newsBLL.Add(newInfo) > 0)
                    {
                        MessageBox.ShowAndRedirect(this.Page, "添加成功", "NoticeManage.aspx");
                    }
                }
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("NoticeManage.aspx");
        }
    }
}
