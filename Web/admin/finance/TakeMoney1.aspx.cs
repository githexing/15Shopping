using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library;
using System.Data.SqlClient;

namespace Web.admin.finance
{
    public partial class TakeMoney1 : AdminPageBase//System.Web.UI.Page
    {
        private string strWhere = "";
        string StarTime;
        string EndTime;
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 16, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            string action = Request.QueryString["action"];
            if (action == "ajax")
            {
                ajax();
                return;
            }

            if (!IsPostBack)
            {
                BindType();
            }

            BindData();

            txtMoney.Value = GetTotalTake(0).ToString("0.00");
        }
        protected void lbtnApply_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeMoney.aspx");
        }

        protected void lbtnDraw_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeList.aspx");
        }
        private void BindType()
        {
            //dropTypeDown.Items.Clear();
            //ListItem li = new ListItem();
            //li.Value = "0";
            //li.Text = "-请选择-";
            //dropTypeDown.Items.Add(li);
            //ListItem li6 = new ListItem();
            //li6.Value = "1";
            //li6.Text = "原始币";
            //dropTypeDown.Items.Add(li6);
            //ListItem li2 = new ListItem();
            //li2.Value = "2";
            //li2.Text = "释放币";

            //dropTypeDown.Items.Add(li2);
            //ListItem li3 = new ListItem();
            //li3.Value = "3";
            //li3.Text = "动态月分红";
            //dropTypeDown.Items.Add(li3);
            //ListItem li4 = new ListItem();
            //li4.Value = "4";
            //li4.Text = "静态年分红";
            //dropTypeDown.Items.Add(li4);
            //ListItem li5 = new ListItem();
            //li5.Value = "5";
            //li5.Text = "动态年分红";
            //dropTypeDown.Items.Add(li5);

        }
        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            StarTime = txtStar.Text.Trim();
            EndTime = txtEnd.Text.Trim();
            strWhere = "where  1=1 ";
            if (this.txtUserCode.Value != "")
            {
                strWhere += " and u.usercode like '%" + this.txtUserCode.Value.Trim() + "%'";
            }
            if (this.txtTrueName.Value != "")
            {
                strWhere += " and u.trueName like '%" + this.txtTrueName.Value.Trim() + "%'";
            }
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),b.TakeTime,120) >= '" + StarTime + "'");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),b.TakeTime,120) <= '" + EndTime + "'");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),b.TakeTime,120) between '" + StarTime + "' and '" + EndTime + "'");
            }
            if (dropTypeDown.SelectedValue != "0")
            {
                if (dropTypeDown.SelectedValue=="1")
                {
                    strWhere += string.Format(" and flag=0");
                }
                else
                {
                    strWhere += string.Format(" and flag=1");
                }
              
            }
            return strWhere;
        }
        public string TakeType(int type)
        {
            string str = "";
            if (type == 1)
            {
                str = "奖金币";
            }
            if (type == 2)
            {
                str = "释放币";
            }

            return str;
        }
        /// <summary>
        /// 填充申请记录
        /// </summary>
        private void BindData()
        {
            string sql = "select * from  tb_takeMoney1 b  left join tb_user u on b.userid=u.userid ";
            var dt = userBLL.getData_Chaxun(sql + GetWhere(), "");
            bind_repeater(dt, Repeater1, "TakeTime desc", tr1, AspNetPager1);
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
        /// 导出申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnExport_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            DataSet ds = GetTakeList(GetWhere());
            DataTable dt = ds.Tables[0];
            DataView dataView = dt.DefaultView;
            dataView.Sort = "TakeTime asc";
            dt = dataView.ToTable();
            if (Repeater1.Items.Count == 0)
            {
                MessageBox.MyShow(this, "不能导出空表格");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.MyShow(this, "错误的操作");
                return;
            }
            string str = ToTakeExecl2(Server.MapPath("../../Upload"), dt);
            Response.Redirect("../../Upload/" + str.Replace("\\", "/").Replace("//", "/"), true);
        }
        /// <summary>
        /// 审核分页申请记录
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long ID = Convert.ToInt64(e.CommandArgument); //ID
            string filename = ""; 
            lgk.BLL.tb_systemMoney sy = new lgk.BLL.tb_systemMoney(); 
            lgk.Model.tb_systemMoney system = sy.GetModel(1); 
                 
                    if (e.CommandName.Equals("Open"))//确认
                          {
                            string sql1 = "update  tb_takeMoney1 set Flag=1  where   ID= '" + ID + "'";
                            SqlConnection conn = new SqlConnection(sconn);
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(sql1, conn);
                            int reInt = cmd.ExecuteNonQuery();
                            conn.Close();
                            if (reInt>=1)
                            {
                                MessageBox.MyShow(this, "操作成功！");
                                BindData();
                                return;
                            }
                            else
                            {
                                MessageBox.MyShow(this, "数据不存在！");
                                return;
                            } 
             
                    }
                    if (e.CommandName.Equals("Remove"))//删除
                    {
                        //加入流水账表
              
                        string sql1 = "delete from tb_takeMoney1 where ID= '" + ID + "'";
                        SqlConnection conn = new SqlConnection(sconn);
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql1, conn);
                        int reInt = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (reInt > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('取消成功！');window.location.href='TakeMoney.aspx';", true);//取消成功  
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('取消失败！');", true);//取消失败
                        }
                   }
                
            
        }
        /// <summary>
        /// 分页申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }


        protected void dropTypeDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void ajax()
        {
            string tid = Request.QueryString["tid"];
            string[] tids = tid.Split(',');

            Response.Clear(); //清除所有之前生成的Response内容

            foreach (var t in tids)
            {
                string sql1 = "update  tb_takeMoney1 set Flag=1 where   ID= '" + t + "'";
                SqlConnection conn = new SqlConnection(sconn);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql1, conn);
                int reInt = cmd.ExecuteNonQuery();
                conn.Close();
            }

            Response.Write("ok");
            Response.End(); //停止Response后续写入动作，保证Response内只有我们写入内容
        }
    }
}
