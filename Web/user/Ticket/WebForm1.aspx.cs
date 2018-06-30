using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Ticket
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            piaodate.Text = Request["piaodate"].ToString();
            ticketcode.Text = Request["ticketcode"].ToString();
            starttime.Text = Request["starttime"].ToString();
            startstationname.Text = Request["startstationname"].ToString();
            arrivetime.Text = Request["arrivetime"].ToString();
            endstationname.Text = Request["endstationname"].ToString();
            alltime.Text = Request["alltime"].ToString();
            price.Text = Request["price"].ToString();
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
            jjf.Text = Request["airportfee"].ToString();
            ryf.Text = Request["fuelfee"].ToString();
            staynum.Value = Request["staynum"].ToString();
            allprice.Text = (Convert.ToDecimal(price.Text) + Convert.ToDecimal(jjf.Text) + Convert.ToDecimal(ryf.Text)).ToString();
            pricesum.Value = (Convert.ToDecimal(price.Text) + Convert.ToDecimal(jjf.Text) + Convert.ToDecimal(ryf.Text)).ToString();
            uid.Value = Session["UserID"].ToString();
        }

        protected void ddlInsurance_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlpassenger_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 增加乘客
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addpassgen_Click(object sender, EventArgs e)
        {
            mainpassengerinfo.InnerHtml+="<ul class='passengerinfo'>" + mainpassengerinfo.InnerHtml + "</ul>)";
        }
    }
}