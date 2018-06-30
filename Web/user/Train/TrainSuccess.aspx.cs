using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Train
{
    public partial class TrainSuccess : System.Web.UI.Page
    {
        lgk.BLL.tb_TrainTicketsOrder bllorder = new lgk.BLL.tb_TrainTicketsOrder();
        public string orderid, orderdate, price, checi, weizhi;
        protected void Page_Load(object sender, EventArgs e)
        {
            orderid=Request["orderid"].ToString();
            lgk.Model.tb_TrainTicketsOrder model = bllorder.GetModel("OrderID='" + orderid + "'");
            orderid = model.OrderCode;
            orderdate = model.FromStationDate.ToString();
            price = model.OrderPrice.ToString();
            checi = model.CheCi;
            weizhi = model.FromStationName + "-" + model.ToStationName;
            uid.Value = model.UserID.ToString();
        }
    }
}