using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Ticket
{
    public partial class TicketOrderDetail : System.Web.UI.Page
    {
        lgk.BLL.tb_TicketOrder bllorder = new lgk.BLL.tb_TicketOrder();
        lgk.BLL.tb_Passengers bllorderdeil = new lgk.BLL.tb_Passengers();
        lgk.BLL.tb_user usbll = new lgk.BLL.tb_user();
        public string price, orderid, piaodate, trancode, starttime, startstationname, arrivetime, endstationname, linkman, linkmobile, cabin,statusstr;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ordercode.Value=orderid = Request["ordercode"].ToString();
                lgk.Model.tb_TicketOrder model = bllorder.GetModel("OrdeID='" + orderid + "'");
                if (model != null)
                {
                    price = model.PayPrice.ToString();
                    piaodate = model.DepDate.ToString("yyyy-MM-dd");
                    trancode = model.AirName;
                    starttime = Convert.ToDateTime(model.DepTime).ToShortTimeString();
                    startstationname = model.DepcityName;
                    arrivetime = Convert.ToDateTime(model.ArrTime).ToShortTimeString();
                    endstationname = model.ArrcityName;
                    //usercode = usbll.GetModel(model.UserID).UserCode;
                    // orderinfo = Request["orderinfo"].ToString();
                    linkman = model.LinkMan;
                    linkmobile = model.LinkMobile;
                   
                    cabin = model.Cabin;
                    List<lgk.Model.tb_Passengers> modeldite = bllorderdeil.GetModelList("OrderID=" + model.ID);
                    List<orderinfo> order = new List<orderinfo>();
                    for (int i = 0; i < modeldite.Count; i++)
                    {
                        orderinfo ordermodel = new orderinfo();
                        ordermodel.name = modeldite[i].Name;
                        ordermodel.cardno = modeldite[i].Cardno;
                        order.Add(ordermodel);
                    }
                    DataSet ds = DataSetList(order);
                    bind_repeater(ds, Repeater1, "cardno");
                    uid.Value = model.UserID.ToString();
                    status.Value = model.Status.ToString();
                    statusstr = statushand(model.Status.ToString());
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('系统异常，异常信息：" + ex.Message + "');", true);
            }
        }
        public string statushand(string str)
        {
            string msg;
            switch (str)
            {
                case "0":
                    msg = "待确认";
                    break;
                case "1":
                    msg = "等待支付";
                    break;
                case "2":
                    msg = "等待出票";
                    break;
                case "3":
                    msg = "出票完成";
                    break;
                case "10":
                    msg = "订单关闭";
                    break;
                case "16":
                    msg = "暂不能出票";
                    break;
                case "19":
                    msg = "已拒单";
                    break;
                case "31":
                    msg = "退款中";
                    break;
                case "32":
                    msg = "退款失败";
                    break;
                case "33":
                    msg = "退款成功";
                    break;
                default:
                    msg = "待确认";
                    break;
            }
            return msg;
        }
        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="dateSet">数据源</param>
        /// <param name="AspNetPager1">分页控件名</param>
        /// <param name="Repeater1">绑定的Repeater控件名</param>
        /// <param name="sort">排序</param>
        /// <param name="span1">无数据时提示的控件名</param>
        public void bind_repeater(DataSet dateSet, Repeater Repeater1, string sort)
        {
            DataSet ds = null;
            if (dateSet != null)
            {
                try
                {
                    ds = dateSet;
                }
                catch (Exception)
                {
                    ds = null;
                }
            }

            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = sort;
            //AspNetPager1.RecordCount = dv.Count;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dv;
            pds.AllowPaging = true;
           
            Repeater1.DataSource = pds;
            Repeater1.DataBind();
        }
        #endregion
        private static DataSet DataSetList(List<orderinfo> emResult)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("cardno", typeof(string));
            for (int i = 0; i < emResult.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = emResult[i].name;
                dr[1] = emResult[i].cardno;
                dt.Rows.Add(dr);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;        }
    }
    public class orderinfo
    {
        public string name { set; get; }
        public string cardno { set; get; }
        
    }
    
}