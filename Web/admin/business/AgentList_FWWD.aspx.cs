/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-6-2 11:42:07 
 * 文 件 名：		AgentList.cs 
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
using System.Collections;
using System.IO;

namespace Web.admin.business
{
    public partial class AgentList_FWWD : AdminPageBase//System.Web.UI.Page
    {
        private string strWhere = "";
        string StarTime = string.Empty;
        string EndTime = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 7, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindLevel();
                bind2();
            }
        }

        #region 绑定用户級別
        /// <summary>
        /// 绑定用户級別
        /// </summary>
        private void BindLevel()
        {
            IList<lgk.Model.tb_level> List = new lgk.BLL.tb_level().GetModelList(" LevelID>3");
            dropLevel.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            dropLevel.Items.Add(li);
            foreach (lgk.Model.tb_level item in List)
            {
                ListItem items = new ListItem();
                items.Value = item.LevelID.ToString();
                items.Text = item.LevelName;
                dropLevel.Items.Add(items);
            }
        }
        #endregion

        #region 记录查询条件
        /// <summary>
        /// 记录查询条件
        /// </summary>
        /// <returns></returns>
        private string getWhere2()
        {
            StarTime = textStar.Text.Trim();
            EndTime = textEnd.Text.Trim();
            string trueName = txtTrueName.Value;
            strWhere = " Flag<>0 ";
            if (this.txtUserCode.Value != "")
            {
                strWhere += " and UserCode like  '%" + this.txtUserCode.Value.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(trueName))
            {
                strWhere += " and TrueName like  '%" + trueName.Trim() + "%'";
            }
            if (dropLevel.SelectedValue != "0")
            {
                strWhere += " and tb_user.LevelID=" + dropLevel.SelectedValue;
            }
            if (StarTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),a.OpenTime,120)  >= '" + StarTime + "'");
            }
            if (EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),a.OpenTime,120)  <= '" + EndTime + "'");
            }
            return strWhere;
        }
        #endregion

        public string MyTypeName(object obj)
        {
            string str = "";
            try
            {
                if (obj != null)
                {
                    if ("1".Equals(obj.ToString()))
                    {
                        str = "一级服务中心";
                    }
                    else if ("2".Equals(obj.ToString()))
                    {
                        str = "二级服务中心";
                    }
                    else if ("3".Equals(obj.ToString()))
                    {
                        str = "三级服务中心";
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
            bind_repeater(GetAgentList(getWhere2()), Repeater2, "OpenTime desc", tr1, AspNetPager2);
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
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                agent.Flag = 2;
                agentBLL.Update(agent);
                var User = userBLL.GetModel(agent.UserID);
                User.IsAgent = 2;
                userBLL.Update(User);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('冻结成功!');", true);
            }
            if (e.CommandName == "open")
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                agent.Flag = 1;
                agentBLL.Update(agent);
                var User = userBLL.GetModel(agent.UserID);
                User.IsAgent = 1;
                userBLL.Update(User);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('解冻成功!');", true);
            }
            if (e.CommandName == "close_hx")
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                agent.Agent001 = 1;
                agentBLL.Update(agent);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('设置空单成功!');", true);
            }
            if (e.CommandName == "open_hx")
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

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

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MyExcel();
        }

        private void MyExcel()
        {
            DataSet ds = GetAgentList(getWhere2());//获取信息
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                string FilePath = Server.MapPath("/userfiles/");// +"\\" + ExcelFolder + "\\";
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                //生成列的中文对应表
                Hashtable nameList = new Hashtable();
                nameList.Add("AgentCode", "服务网点编号");
                nameList.Add("UserCode", "会员编号");
                nameList.Add("TrueName", "会员姓名");
                nameList.Add("LevelName", "会员级别");
                nameList.Add("Quyu", "代理区域");
                nameList.Add("AppliTime", "申请日期");
                nameList.Add("OpenTime", "确认日期");

                DataTable dt = ds.Tables[0];
                dt.Columns.Remove("ID");
                dt.Columns.Remove("AgentType");
                dt.Columns.Remove("Flag");
                dt.Columns.Remove("UserID");
                dt.Columns.Remove("LevelID");
                dt.Columns.Remove("AgentsID");
                dt.Columns.Remove("User006");

                DataTable newTable = new DataTable();
                DataColumn newCol = new DataColumn();
                newCol.ColumnName = "Quyu";
                newTable.Columns.Add(newCol);

                foreach (DataColumn col in dt.Columns)
                {
                    DataColumn c = new DataColumn();
                    c.ColumnName = col.ColumnName;
                    newTable.Columns.Add(c);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = newTable.NewRow();
                    dr["Quyu"] = dt.Rows[i]["AgentInProvince"].ToString() + dt.Rows[i]["AgentInCity"].ToString() + dt.Rows[i]["AgentAddress"].ToString();
                    foreach (DataColumn ncol in dt.Columns)
                    {
                        dr[ncol.ColumnName] = dt.Rows[i][ncol.ColumnName];
                    }
                    newTable.Rows.Add(dr);
                }
                newTable.Columns.Remove("AgentInProvince");
                newTable.Columns.Remove("AgentInCity");
                newTable.Columns.Remove("AgentAddress");
                //利用excel对象
                DataToExcel dte = new DataToExcel();
                string filename = "";
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        filename = dte.DataExcel(newTable, "已开通服务网点", FilePath, nameList);
                    }
                }
                catch
                {
                    //dte.KillExcelProcess();
                }

                if (filename != "")
                {
                    string path = FilePath + filename;
                    Response.Redirect("/userfiles/" + filename, true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('当前无数据导出!');", true);
            }
        }

    }
}
