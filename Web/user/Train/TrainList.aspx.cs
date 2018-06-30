using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Train
{
    public partial class TrainList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                train_date.Value = Request["train_date"].ToString().Trim();
                from_station.Value = Request["from_station"].ToString().Trim();
                to_station.Value = Request["to_station"].ToString().Trim();
            }
        }
    }
}