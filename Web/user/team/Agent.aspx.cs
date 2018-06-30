/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-7-17 10:19:42 
 * 文 件 名：		Agent.cs 
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
using DataAccess;
using System.Data;
namespace Web.user.team
{
    public partial class Agent : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //spd.jumpUrl1(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                ShowData();
                ltAgent.Text = GetLanguage("DeclarationNumber");//服务网点编号
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        private void ShowData()
        {
            LitAgentCode.Text = LoginUser.UserCode;
            if (Loginagent != null)//申请报单中心时，判断该用户是否为报单中心
            {
                btnSubmit.Visible = false;

                if (Loginagent.Flag == 1)
                {
                    ltAudit.Visible = true;
                    ltAudit.Text = GetLanguage("DeclarationAgent");//审核中
                }
                else
                {
                    ltAudit.Visible = true;
                    ltAudit.Text = GetLanguage("Audit");//审核中
                }
            }
            else
            {
                ltAudit.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int iAgentOpend = getParamInt("Agent");//是否可申请报单中心（0否，1是）
            if (iAgentOpend == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                return;
            }

            if (Loginagent != null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("pleaseWait") + "');", true);//您的申请已提交，请耐心等待
                return;
            }

            if (userBLL.GetCount("RecommendID=" + LoginUser.UserID + " AND IsOpend = 2") < getParamInt("Agent1"))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("InsufficientNumber") + "');", true);//推荐人数不足
                return;
            }

            lgk.Model.tb_agent model = new lgk.Model.tb_agent();
            model.UserID = getLoginID();
            model.AgentCode = LoginUser.UserCode;
            model.Flag = 0;
            model.AgentType = LoginUser.LevelID;
            model.Agent003 = LoginUser.TrueName;
            model.AppliTime = DateTime.Now;
            model.JoinMoney = getParamAmount("Level" + LoginUser.LevelID);
            model.Agent004 = "";
            model.Agent001 = 0;
            model.Agent002 = 0;
            model.PicLink = "";

            if (agentBLL.Add(model) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');window.location.href='Agent.aspx';", true);//申请XX成功
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OperationFailed") + "');", true);//申请失败
            }
        }
    }
}
