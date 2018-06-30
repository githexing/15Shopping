/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-7-17 10:19:42 
 * 文 件 名：		Agent1.cs 
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
    public partial class Agent1 : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //spd.jumpUrl1(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                ShowData();
                ltAgent1.Text = "运营中心编号";//服务网点编号
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        private void ShowData()
        {
            LitAgent1Code.Text = LoginUser.UserCode;
            if (Loginagent1 != null)//申请报单中心时，判断该用户是否为报单中心
            {
                btnSubmit.Visible = false;
                Address.Value = Loginagent1.AgentAddress;
                Phone.Value = Loginagent1.PicLink;
                if (Loginagent1.Flag == 1)
                {
                    ltAudit.Visible = true;
                    ltAudit.Text = "你已经是运营中心";//审核中
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
            int iAgent1Opend = getParamInt("Yunying");//是否可申请报单中心（0否，1是）
            if (iAgent1Opend == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Feature") + "');", true);//该功能未开放
                return;
            }

            if (Loginagent1 != null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("pleaseWait") + "');", true);//您的申请已提交，请耐心等待
                return;
            }

            //if (userBLL.GetCount("RecommendID=" + LoginUser.UserID + " AND IsOpend = 2") < getParamInt("Agent11"))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("InsufficientNumber") + "');", true);//推荐人数不足
            //    return;
            //}
            if (agentBLL.GetAgentsID(LoginUser.UserCode)==0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('成为报单中心才能申请运营中心');", true);//推荐人数不足
                return;                                                                                                                               
            }
            if (agent1BLL.GetAgentsID(LoginUser.UserCode) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('正在审核或者已经是运营中心');", true);//推荐人数不足
                return;
            }
            if (this.Address.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('地址不能为空');", true);//推荐人数不足
                return;
            }
            if (this.Phone.Value == ""|| this.Phone.Value.Length!=11)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入正确的手机号码');", true);//推荐人数不足
                return;
            }

            lgk.Model.tb_agent1 model = new lgk.Model.tb_agent1();
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
            model.AgentAddress = this.Address.Value;
            model.PicLink = this.Phone.Value;

            if (agent1BLL.Add(model) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');window.location.href='Agent1.aspx';", true);//申请XX成功
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OperationFailed") + "');", true);//申请失败
            }
        }
    }
}
