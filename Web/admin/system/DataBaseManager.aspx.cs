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
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Web.admin.system
{
    public partial class DataBaseManager : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 33, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密碼
            if (!IsPostBack)
            {
                BindData();
            }
        }
        /// <summary>
        /// 绑定数据备份列表
        /// </summary>
        private void BindData()
        {
            List<BackModel> list1 = BackUpSystem.BackList(Server.MapPath(ConfigurationManager.AppSettings["DBpath"].ToString()));
            DataTable ta = new DataTable();
            ta.Columns.Add("id", typeof(int));
            ta.Columns.Add("name", typeof(string));
            ta.Columns.Add("time", typeof(string));
            ta.Columns["id"].AutoIncrement = true;

            for (int i = 0; i < list1.Count; i++)
            {
                DataRow row = ta.NewRow();
                row["name"] = list1[i].fileName;
                row["time"] = list1[i].CreationTime;
                ta.Rows.Add(row);
            }
            DataView dv = ta.DefaultView;
            dv.Sort = "time desc";
            //AspNetPager1.RecordCount = dv.Count;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = 0; /*AspNetPager1.CurrentPageIndex - 1*/
            pds.PageSize = 0; /*AspNetPager1.PageSize*/
            //this.Repeater1.DataSource = pds;
            //this.Repeater1.DataBind();

            //if (BackUpSystem.BackList(Server.MapPath(ConfigurationManager.AppSettings["DBpath"].ToString())).Count == 0)
            //{
            //    this.tr1.Visible = true;
            //}
            //else
            //    this.tr1.Visible = false;
        }
        ///<summary>
        /// 打开指定的文件
        ///</summary>
        ///<param name="FileName">文件名（带扩展名）</param>  
        ///<returns>bool</returns>
        public bool OpenFile(string fileName)
        {
            string name = fileName;
            try
            {
                if (File.Exists(Server.MapPath(name)))
                {
                    FileInfo aFile = new FileInfo(Server.MapPath(name));
                    string na = Path.GetFileName(name);
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.BufferOutput = true;
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(na, Encoding.UTF8));
                    Response.AddHeader("Content-Length", aFile.Length.ToString());
                    Response.WriteFile(name);
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return false;
        }
        ///// <summary>
        ///// 备份
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnBak_Click(object sender, EventArgs e)
        //{
        //    spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

        //    if (BackUpSystem.BackUp(this) == null)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('备份失败!');", true);
        //    }
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('备份成功！');window.location.href='DataBaseManager.aspx'", true);
        //}
        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            if (ClearDataBase() <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('清空失败!');", true);
            }
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('清空完成！');window.location.href='DataBaseManager.aspx'", true);
        }
        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "close")
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                BackUpSystem.SQLBack(this, Server.MapPath(ConfigurationManager.AppSettings["DBpath"].ToString() + @"\" + e.CommandArgument.ToString()));
                
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('还原成功!');", true);
                //绑定
                SqlConnection.ClearAllPools();
            }
            if (e.CommandName == "open")
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                OpenFile(ConfigurationManager.AppSettings["DBpath"].ToString() + @"\" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "que")
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                BackUpSystem.DelBackUp(this, Server.MapPath(ConfigurationManager.AppSettings["DBpath"].ToString() + @"\" + e.CommandArgument.ToString()));
                
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除成功！');window.location.href='DataBaseManager.aspx'", true);
            }
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnAd_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            gp_opBLL.ExecProc("proc_TEST_JsAndFf");
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('今日结算和发放奖金成功!');", true);
        }

    }
}