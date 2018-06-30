using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.admin.business
{
    public partial class TreeList : AdminPageBase//System.Web.UI.Page
    {
        private string strWhere = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            jumpMain(this, 7, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密碼
            if (!IsPostBack)
            {
                bind2();
            }
        }
        /// <summary>
        /// 提现记录查询条件
        /// </summary>
        /// <returns></returns>
        private string getWhere2()
        {
            strWhere = "";
            if (this.txtUserCode2.Value != "")
            {
                strWhere += " and usercode like  '%" + this.txtUserCode2.Value.Trim() + "%'";
            }
            if (txtGenera.Value.Trim()!= "")
            {
                strWhere += string.Format(" and Layer= " + txtGenera.Value.Trim());
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
                    if ("2".Equals(obj.ToString()))
                    {
                        str = "一级会员";
                    }
                    if ("3".Equals(obj.ToString()))
                    {
                        str = "VIP会员";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;
        }

        public string IsOpen(object obj)
        {
            string str = "";
            try
            {
                if (obj != null)
                {
                    if ("0".Equals(obj.ToString()))
                    {
                        str = "未开通";
                    }
                    if ("2".Equals(obj.ToString()))
                    {
                        str = "实单";
                    }
                    if ("3".Equals(obj.ToString()))
                    {
                        str = "空单";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;
        }

        /// <summary>
        /// 我的左右区
        /// </summary>
        /// <param name="id"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public string MyChild(object id,int location)
        {
            string str = "<a href=\"../../Registers.aspx?\">注册</a>";
            try
            {
                if (id != null)
                {
                    var user=userBLL.GetModel(" parentID=" + id.ToString() + " and location=" + location);
                    if (user != null)
                    {
                        return user.UserCode;
                    }
                    else
                    {
                        str = "<a href=\"../../Registers.aspx?state="+id.ToString()+","+location+",0\">注册</a>";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;
        }

        /// <summary>
        /// 填充提现记录
        /// </summary>
        private void bind2()
        {
            //string a = Request.QueryString["a"];
            string strSql = string.Format("select * from tb_user where UserID>0 {0} ", getWhere2());
            //if (!string.IsNullOrEmpty(a))
            //{
            //   int id= getLoginID();
            //   strSql = "    SELECT * FROM dbo.tb_user WHERE '-'+CAST(RecommendPath AS NVARCHAR(max))+'-' LIKE '%-"+id+"-%' "+getWhere2();
            //}
            bind_repeater(strSql, "layer asc", AspNetPager2, Repeater2, tr1);
            //bind_repeater(GetAgentList(getWhere2()), Repeater2, "OpenTime desc", tr1, AspNetPager2);
        }
        /// <summary>
        /// 搜索提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            bind2();
        }
        /// <summary>
        /// 分页提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            bind2();
        }


        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_agent agent = agentBLL.GetModel(ID);
            if (e.CommandName == "close")
            {
                agent.Flag = 2;
                agentBLL.Update(agent);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('冻结成功!');", true);
            }
            if (e.CommandName == "open")
            {
                agent.Flag = 1;
                agentBLL.Update(agent);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('解冻成功!');", true);
            }
            if (e.CommandName == "close_hx")
            {
                agent.Agent001 = 1;
                agentBLL.Update(agent);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('设置空单成功!');", true);
            }
            if (e.CommandName == "open_hx")
            {
                agent.Agent001 = 0;
                agentBLL.Update(agent);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('取消空单成功!');", true);
            }
            if (e.CommandName == "list")
            {
                Response.Redirect("UserList.aspx?id=" + ID);
            }
            bind2();
        }
    }
}