/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-23 15:20:45 
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
using System.Data;

namespace Web.admin.business
{
    public partial class Agent : AdminPageBase//System.Web.UI.Page
    {
        string StarTime=string.Empty;
        string EndTime=string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 6, getLoginID());//权限

            spd.jumpAdminUrl1(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "Flag=0 ";
            string strUserCode = this.txtUserCode.Value.Trim();
            string strTrueName = txtTrueName.Value.Trim();

            if (!string.IsNullOrEmpty(strUserCode))
            {
                strWhere += " and UserCode like '%" + strUserCode + "%'";
            }

            if (!string.IsNullOrEmpty(strTrueName))
            {
                strWhere += " and TrueName like '%" + strTrueName + "%'";
            }

            return strWhere;
        }

        public string MyTypeName(object obj)
        {
            string str = "";
            try
            {
                if (obj != null)
                {
                    if ("3".Equals(obj.ToString()))
                    {
                        str = "运营中心";
                    }
                }
            }
            catch (Exception  ) { }
            return str;
        }

        /// <summary>
        /// 填充申请记录
        /// </summary>
        private void BindData()
        {
            bind_repeater(GetAgentList1(GetWhere()), Repeater1, "AppliTime desc", divno, AspNetPager1);
        }

        /// <summary>
        /// 搜索申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 审核分页申请记录
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long iID = long.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_agent1 agentInfo = agent1BLL.GetModel(iID);
            if (agentInfo == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('已删除,无法再进行此操作！');window.location.href='Agent.aspx';", true);
            }
            else
            {
                if (agentInfo.Flag != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该运营中心已激活，不能再进行此操作！');window.location.href='Agent.aspx';", true);
                }
                else
                {

                    if (e.CommandName == "Remove")
                    {
                        if (agent1BLL.Delete(iID))
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除成功！');window.location.href='Agent.aspx';", true);
                        else
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除失败！');window.location.href='Agent.aspx';", true);
                    }
                    if (e.CommandName == "Open")
                    {
                        agentInfo.Flag = 1;
                        agentInfo.OpenTime = DateTime.Now;
                        var model = userBLL.GetModel(agentInfo.UserID);
                        model.User001 = 1;
                      

                        if (agent1BLL.Update(agentInfo)&&userBLL.Update(model))
                        {
                            string strUserCode = userBLL.GetUserCode(agentInfo.UserID);

                            //userBLL.UpdateAgent1(agentInfo.UserID);
                            //UpdateAgent(iID, agentInfo.UserID, strUserCode);

                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('激活成功！');window.location.href='Agent.aspx';", true);
                        }
                    }
                }
            }
            BindData();
        }

        /// <summary>
        /// 修改下线的运营中心信息
        /// </summary>
        /// <param name="iID"></param>
        /// <param name="iUserID"></param> 
        /// <param name="strUserCode"></param>
        private void UpdateAgent(long iID, long iUserID, string strUserCode)
        {
            userBLL.UpdateAgent(iID, iUserID, strUserCode);
        }
        /// <summary>
        /// 修改下线的运营中心信息
        /// </summary>
        /// <param name="iID"></param>
        /// <param name="iUserID"></param> 
        /// <param name="strUserCode"></param>
        //private void UpdateAgent1(long iID, long iUserID, string strUserCode)
        //{
        //    userBLL.UpdateAgent1(iID, iUserID, strUserCode);
        //}

        /// <summary>
        /// 分页申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                string iProvince = DataBinder.Eval(e.Item.DataItem, "AgentInProvince").ToString();
                string iCity = DataBinder.Eval(e.Item.DataItem, "AgentInCity").ToString();
                string iCountry = DataBinder.Eval(e.Item.DataItem, "AgentAddress").ToString();

                Literal ltlArea = (Literal)e.Item.FindControl("ltlArea");//地点
                if (iProvince.Trim() != "" && iProvince != null)
                {
                    ltlArea.Text = iProvince + "-" + iCity + "-" + iCountry;
                }
                else
                {
                    ltlArea.Text = "无";
                }
            }
        }
    }
}

