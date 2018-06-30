using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using DataAccess;
using System.Data;

namespace Web.admin.system
{
    public partial class Security : AdminPageBase
    {
        /// <summary>
        /// 密保问题编号
        /// </summary>
        private int iSecurityID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 48, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转3级密碼

            if (Request["SecurityID"] != null && Request["SecurityID"].Length > 0)
            {
                if (PageValidate.IsInteger(Request["SecurityID"]))
                {
                    iSecurityID = Convert.ToInt32(Request["SecurityID"].ToString());
                }
                lbtnSubmit.Text = " 修 改 ";
            }
            else
            {
                iSecurityID = 0;
                lbtnSubmit.Text = " 添 加 ";
            }

            if (!IsPostBack)
            {
                if (iSecurityID > 0)
                    ShowData();
                BindData();
            }
        }

        /// <summary>
        /// 拆分参数
        /// </summary>
        private void ShowData()
        {
            lgk.Model.tb_Security securityInfo = securityBLL.GetModel(iSecurityID);

            if (securityInfo != null)
                txtQuestion.Text = securityInfo.Question;
        }

        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {
            lgk.Model.tb_Security securityInfo = new lgk.Model.tb_Security();
            if (txtQuestion.Text.Trim() == "")
            {
                MessageBox.MyShow(this, "密保问题不能为空！");//密保问题不能为空
                return;
            }

            if (iSecurityID > 0)
            {
                securityInfo = securityBLL.GetModel(iSecurityID);
                securityInfo.Question = txtQuestion.Text;
                securityInfo.EditUserID = getLoginID();
                securityInfo.EditDate = DateTime.Now;

                if (securityBLL.Update(securityInfo))
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改成功！');window.location.href='Security.aspx';", true);//修改成功
                else
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改失败，请检查后再试！');window.location.href='Security.aspx';", true);//修改成功
            }
            else
            {
                securityInfo.Question = txtQuestion.Text;
                securityInfo.AddUserID = getLoginID();
                securityInfo.AddDate = DateTime.Now;
                securityInfo.EditUserID = 0;
                securityInfo.Status = 0;

                if (securityBLL.Add(securityInfo) > 0)
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('添加成功！');window.location.href='Security.aspx';", true);//修改成功
                else
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('添加失败，请检查后再试！');window.location.href='Security.aspx';", true);//修改成功
            }
        }

        private void BindData()
        {
            bind_repeater(securityBLL.GetList("1=1"), Repeater1, "AddDate desc", tr1, AspNetPager1);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int iUserID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "AddUserID"));

                Literal ltUserCode = (Literal)e.Item.FindControl("ltUserCode");//会员编号

                ltUserCode.Text = userBLL.GetModel(iUserID).UserCode;
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int iSecurityID = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("Security.aspx?SecurityID=" + iSecurityID + "");
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}