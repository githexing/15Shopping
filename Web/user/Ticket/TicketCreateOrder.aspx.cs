using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Ticket
{
    public partial class TicketCreateOrder : System.Web.UI.Page
    {
        public string piaodate, ticketcode, starttime, startstationname, arrivetime, endstationname, alltime, price, jjf, ryf;
        public decimal allprice;
        protected void Page_Load(object sender, EventArgs e)
        {
            depdate.Value=piaodate = Request["piaodate"].ToString();
            ticketcodeTxt.Value=ticketcode = Request["ticketcode"].ToString();
            deptime.Value=starttime = Request["starttime"].ToString();
            depacity.Value=startstationname = Request["startstationname"].ToString();
            arrtime.Value=arrivetime = Request["arrivetime"].ToString();
            arrycity.Value=endstationname = Request["endstationname"].ToString();
            alltime = Request["alltime"].ToString();
            dprice.Value=price = Request["price"].ToString();
            aircode.Value = Request["aircode"].ToString();
            depcity.Value = Request["depcity"].ToString();
            arrcity.Value = Request["arrcity"].ToString();
            flight.Value = Request["flight"].ToString();
            flightmodel.Value = Request["flightmodel"].ToString();
            cabin.Value = Request["cabin"].ToString();
            yprice.Value = Request["yprice"].ToString();
            discount.Value = Request["discount"].ToString();
            depterminal.Value = Request["depterminal"].ToString();
            arrterminal.Value = Request["arrterminal"].ToString();
            airportfee.Value=jjf = Request["airportfee"].ToString();
            fuelfee.Value = ryf = Request["fuelfee"].ToString();
            staynum.Value = Request["staynum"].ToString();
            allprice = Convert.ToDecimal(price) + Convert.ToDecimal(jjf) + Convert.ToDecimal(ryf);
            pricesum.Value = (Convert.ToDecimal(price) + Convert.ToDecimal(jjf) + Convert.ToDecimal(ryf)).ToString();
            if (Session["UserID"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('系登录已失效请重新登录');", true);
                Response.Redirect("TicketQuery.aspx");
            }
            else
            {
                uid.Value = Session["UserID"].ToString();
            }
            
        }
    }
}