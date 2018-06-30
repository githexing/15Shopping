using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Ticket
{
    public partial class TicketSuccess : System.Web.UI.Page
    {
        lgk.BLL.tb_TicketOrder bllorder = new lgk.BLL.tb_TicketOrder();
        public string orderid, orderdate, price, checi, deptime,arrytime;
        protected void Page_Load(object sender, EventArgs e)
        {
            orderid = Request["orderid"].ToString();
            lgk.Model.tb_TicketOrder model = bllorder.GetModel("OrdeID='" + orderid + "'");
            orderid = model.OrdeID;
            orderdate = model.DepDate.ToString("yyy-MM-dd");
            price = model.PayPrice.ToString();
            checi = model.Flight;
            deptime = model.DepcityName + "("+ model .DepTime.ToString("HH:mm")+ ")" ;
            arrytime = model.ArrcityName + "(" + model.ArrTime.ToString("HH:mm") + ")";
            uid.Value = model.UserID.ToString();
        }
    }
}