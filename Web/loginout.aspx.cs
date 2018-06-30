/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-2-4 16:48:34 
 * 文 件 名：		loginout.cs 
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

namespace Web
{
    public partial class loginout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            UserUtil.Logout();
            if (Request.Cookies["A128076_user"] != null)
            {
                HttpCookie ck = Request.Cookies["A128076_user"];
                ck.Expires = DateTime.Now.AddDays(-2);
                Response.Cookies.Set(ck);
            }

            if (Request["r"] == null)
            {
                string host = Request.Url.Host;
                if (host.IndexOf("www.") == 0)
                {
                    //Response.Redirect("http://" + host.Replace("www.", "vip.") + "/loginout.aspx?r=");//退出用户中心
                    Response.Redirect("/loginout.aspx?r=");
                }
                else
                {
                    //Response.Redirect("http://" + host.Replace("vip", "www") + "/loginout.aspx?r=");//退出商城
                    Response.Redirect("/loginout.aspx?r=");
                }
            }
            else
            {
                string host = Request.Url.Host;
                if (host.IndexOf("www.") == 0)
                {
                    //Response.Write("<script>parent.window.location.href='http://" + host.Replace("www.", "vip.") + "/Login.aspx'</script>");
                    Response.Write("<script>parent.window.location.href='/Login.aspx'</script>");
                }
                else
                {
                    //Response.Write("<script>parent.window.location.href='http://" + host.Replace("vip.", "www.") + "/user/shop/index.aspx'</script>");
                    Response.Write("<script>parent.window.location.href='/Login.aspx'</script>");
                }
            }
        }
    }
}
