using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.order
{
    public partial class TicketOrderDetail : AdminPageBase
    {
        lgk.BLL.tb_Passengers pass = new lgk.BLL.tb_Passengers();
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 70, getLoginID());//权限

            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            int orderid = Convert.ToInt32(Request["orderID"].ToString());
            bind_repeater(pass.GetList("OrderID=" + orderid), Repeater1, "ID desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        public string cardtype(string str)
        {
            string st="";
            if (str == "NI")
            {
                st = "身份证";
            }
            if (str == "PP")
            {
                st = "护照";
            }
            if (str == "ID")
            {
                st = "其他";
            }
            return st;
        }
        public string piaotype(string str)
        {
            string st = "";
            if (str == "ADT")
            {
                st = "成人";
            }
            if (str == "CHD")
            {
                st = "儿童";
            }
            if (str == "INF")
            {
                st = "婴儿";
            }
            return st;
        }
    }
}