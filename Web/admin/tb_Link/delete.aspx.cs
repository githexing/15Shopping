using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
namespace lgk.Web.tb_Link
{
    public partial class delete : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = string.Empty;
            if (!Page.IsPostBack)
            {
                lgk.BLL.tb_Link bll = new lgk.BLL.tb_Link();
              
                //string ssss = Request.RawUrl.ToString();
                if (Request.QueryString["p"] != null && Request.QueryString["p"].Trim() != "")
                {
                    url = Request.QueryString["p"].ToString()+".aspx";
                }
                else
                {
                    url = "../index.aspx";
                }
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    int ID = (Convert.ToInt32(Request.Params["id"]));
                    bll.Delete(ID);
                   // Response.Redirect("list.aspx");
                }
               // Response.Redirect("list.aspx");
               
                
            }
           // MessageBox.ShowAndRedirect(this, "删除成功！", url);
            Response.Redirect(url);
        }
    }
}