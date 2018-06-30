using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using DataAccess;

namespace Library
{
    public class WebPageCore: System.Web.UI.Page
    {
        public WebPageCore()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 重写页面初始化事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            //继续执行页面初始化事件
            base.OnInit(e);
            //在页面Page_Load事件后执行页面权限检查
            this.Load += new System.EventHandler(PageBase_Load);
            //在页面出错事件后执行错误记录
            this.Error += new System.EventHandler(PageBase_Error);
        }
        /// <summary>
        /// 在页面Page_Load事件执行结束后执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageBase_Load(object sender, System.EventArgs e)
        {
            if (Convert.ToInt32(this.GetIsWebOpen().Rows[0]["IsWebOpen02"]) == 0)
            {
                Response.Write("<script>window.top.location='../WebClose.aspx'</script>");
                Response.End();
            }
        }
        /// <summary>
        /// 在页面出错之后执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PageBase_Error(object sender, System.EventArgs e)
        {
            OnErrorRecord();
        }

        new public System.Type GetType()
        {
            //if()
            //if(!DataAccess.DbHelperSQL.pdp())
            //Library.UserUtil.Logout();
            return Page.GetType();
        }
        /// <summary>
        /// 记录错误方法
        /// </summary>
        protected virtual void OnErrorRecord()
        {
            StringBuilder infoBuild = new StringBuilder(200);
            infoBuild.Append(Context.Request.UserHostAddress);
            infoBuild.Append("|");
            infoBuild.Append(Context.Request.UserHostName);
            infoBuild.Append("|");
            infoBuild.Append(Context.Request.UserAgent);
            infoBuild.Append("|");
            if (Context.Request.UrlReferrer != null)
                infoBuild.Append(Context.Request.UrlReferrer.ToString());
            UserRole.ErrorRecord(Request.Url.AbsoluteUri, infoBuild.ToString(), GetErrorDescribe());

        }
        /// <summary>
        /// 获得错误信息描述
        /// </summary>
        /// <returns></returns>
        private string GetErrorDescribe()
        {
            if (Context.Error != null)
                return Context.Error.ToString();
            else
                return string.Empty;
        }


        public string setp()
        {
            string s = System.Net.Dns.GetHostName();
            System.Net.IPAddress[] p = System.Net.Dns.GetHostEntry(s).AddressList;
            return p[0].ToString();
        }
        private DataTable GetIsWebOpen()
        {
            string sql = "select * from IsWebOpen where IsWebOpen01 = 1";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
    }
}
