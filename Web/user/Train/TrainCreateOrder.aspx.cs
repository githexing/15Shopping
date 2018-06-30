using DataAccess;
using Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Train
{
    public partial class TrainCreateOrder : System.Web.UI.Page
    {
        public string piaodate, trancode, starttime, startstationname, arrivetime, endstationname, runtime, zwprice;
        lgk.BLL.tb_user user = new lgk.BLL.tb_user();
        lgk.BLL.tb_globeParam glob=new  lgk.BLL.tb_globeParam();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                // var emResult = JsonConvert.DeserializeObject<data>(data);
                arry.Value = Request["arry"].ToString();
                DateTime dt = DateTime.ParseExact(Request["piaodate"].ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                piaodatetxt.Value=piaodate = Convert.ToDateTime(dt).ToString("yyyy-MM-dd");
                trancodetxt.Value = trancode = Request["trancode"].ToString();
                starttimetxt.Value = starttime = Request["starttime"].ToString();
                startstationnametxt.Value = startstationname = Request["startstationname"].ToString();
                arrivetimetxt.Value = arrivetime = Request["arrivetime"].ToString();
                endstationnametxt.Value = endstationname = Request["endstationname"].ToString();
                runtimetxt.Value = runtime = Request["runtime"].ToString();
                zwpricetxt.Value = zwprice = Request["zwprice"].ToString();
                formcode.Value = Request["formcode"].ToString();
                endcode.Value = Request["endcode"].ToString();
                
                if (Session["UserID"]==null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请登录后再操作');", true);//没有这个用户
                    // Response.Redirect("/Login.aspx");
                }
                else
                {
                    uid.Value = Session["UserID"].ToString();
                }
                lgk.Model.tb_user model = user.GetModel(long.Parse(Session["UserID"].ToString()));
                money.Value = model.Emoney.ToString();

                isbaoxian.Value = getParamInt().ToString();
            }
        }
        public int getParamInt()
        {
            return Convert.ToInt32(DbHelperSQL.GetSingle("select ParamVarchar from tb_globeParam where ParamName='IsBoxian'"));
        }
    }
   
}