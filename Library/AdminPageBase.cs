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
    public class AdminPageBase : AllCore
    {
        public UserInfo uinfo;
        public lgk.Model.tb_admin LoginAdmin { get; set; }
        public AdminPageBase()
        { 
        
        }
        //public int PermissionID = -1;//默认无限制
        public int UserType = 1;//用户所属的用户表
        /// <summary>
        /// 重写页面初始化事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            //继续执行页面初始化事件
            base.OnInit(e);
            //在页面Page_Load事件后执行页面权限检查
            this.PreLoad += new System.EventHandler(PageBase_Load);
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
            LoginAdmin = adminBLL.GetModel(getLoginID());
            //结算系统和网站共用域名,当前根目录被移到/jsxt下
            string strNewUrl = Request.Url.ToString().Replace("/admin/finance/", "/").Replace("/admin/business/", "/").Replace("/admin/product/", "/").Replace("/admin/info/", "/").Replace("/admin/team/", "/").Replace("/admin/system/", "/").Replace("/admin/cash/", "/").Replace("/admin/", "/");//取得当前的外网
            strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径

            //检测Session["User"] 是否存在，如果存在，把它转换成UserInfo类，如果不存在，初始化一个UserInfo类，并存储到Session["User"]
            if (Request.Cookies["A128076_admin"] == null)
            {
                Response.Write("<script>window.top.location='" + strNewUrl + "ManageLogin.aspx'</script>");
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
            //结算系统和网站共用域名,当前根目录被移到/jsxt下
            //string strNewUrl = Request.Url.ToString().ToLower().Replace("/admin/", "/").Replace("/admin/finance/", "/").Replace("/admin/business/", "/").Replace("/admin/licai/", "/").Replace("/admin/info/", "/").Replace("/admin/team/", "/").Replace("/admin/system/", "/");//取得当前的外网
            //strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径
            //Response.Write("<script>window.top.location='" + strNewUrl + "Error.aspx'</script>");
            //Response.End();
            //string strError = Request.Url.ToString();
            //Response.Redirect(strError);
            //Response.Redirect(strNewUrl + "Error.aspx");
            //Response.Redirect("../../Error.aspx");

        }

        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpRequestValidationException)
            {
                //结算系统和网站共用域名,当前根目录被移到/jsxt下
                //string strNewUrl = Request.Url.ToString().ToLower().Replace("/admin/", "/").Replace("/admin/finance/", "/").Replace("/admin/business/", "/").Replace("/admin/licai/", "/").Replace("/admin/info/", "/").Replace("/admin/team/", "/").Replace("/admin/system/", "/");//取得当前的外网
                //strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径
                //Response.Redirect(strNewUrl + "Error.aspx?type=1");
                //Response.Redirect("../../Error.aspx?type=1");
            }
        }
        /// <summary>
        /// 根据年份和周数获取该周的开始结束日期
        /// </summary>
        /// <param name="year"></param>
        /// <param name="weeknum"></param>
        /// <returns></returns>
        public string first_lastDate(int year, int weeknum)
        {
            DateTime time = Convert.ToDateTime(year.ToString() + "-01-01");
            int dayOfWeek = (int)time.DayOfWeek;
            DateTime firstDay = time.AddDays((weeknum - 2) * 7 + (6 - dayOfWeek) + 1);
            DateTime lastDay = firstDay.AddDays(6);
            return firstDay.ToString("yyyy-MM-dd") + "到" + lastDay.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 获取当前登录ID
        /// </summary>
        /// <returns></returns>
        public int getLoginID()
        {
            if (Request.Cookies["A128076_admin"] != null)
            {
                return Convert.ToInt32(Request.Cookies["A128076_admin"]["Id"]);
            }
            else
            {
                return 0;
            }
        }

        new public System.Type GetType()
        {
            return Page.GetType();
        }
        public string setp()
        {
            string s = System.Net.Dns.GetHostName();
            System.Net.IPAddress[] p = System.Net.Dns.GetHostEntry(s).AddressList;
            return p[0].ToString();
        }
        private bool GetIsWebOpen()
        {
            return true;
        }
    }
}
