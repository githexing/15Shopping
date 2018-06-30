using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web
{
    public partial class getemailcode : AllCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.ContentType = "text/plain";
            switch (Request.Params["action"])
            {
                case "selectpwd":
                    GetQuest();
                    break;
                default:
                    break;
            }
        }
        public void GetQuest() 
        {
            string question = Request["question"].ToString();
            string answer = Request["answer"].ToString();
            string name = Request["ucode"].ToString();
            lgk.Model.tb_user LoginUser = null;
            int num = ConvertToInt(Session["num"]);
            if (num > 3)
            {
                Response.Write("4");
                return;
            }
            try
            {
                LoginUser = new lgk.BLL.tb_user().GetModel(name == "" ? " 1<>1 " : " usercode ='" + name + "'");
            }
            catch (Exception)
            {
                 Response.Write("1");
                 return;
            }
            if (LoginUser == null)
            {
                Response.Write("1");
                return;
            }
            if (LoginUser.User009 != question) 
            {
                num++;
                Session["num"] = num;
                Response.Write("2");
                return;
            }
            if (LoginUser.User010 != answer)
            {
                num++;
                Session["num"] = num;
                Response.Write("3");
                return;
            }
            Session["userCount"] = 0;
            LoginUser.Password = PageValidate.GetMd5("111111");
            if (userBLL.Update(LoginUser))
            {
                Response.Write("5");
                return;
            }
            else 
            {
                Response.Write("6");
                return;
            }
        }
    }
}