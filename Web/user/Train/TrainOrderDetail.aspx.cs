using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Web.user.Train
{
    public partial class TrainOrderDetail : System.Web.UI.Page
    {
        lgk.BLL.tb_TrainTicketsOrder bllorder = new lgk.BLL.tb_TrainTicketsOrder();
        lgk.BLL.tb_TrainTicketsOrderDetail bllorderdeil = new lgk.BLL.tb_TrainTicketsOrderDetail();
        lgk.BLL.tb_user usbll = new lgk.BLL.tb_user();
        public string piaodate, trancode, starttime, startstationname, arrivetime, endstationname, usercode,linkphone, orderinfo, price, orderid,states;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    orderid = Request["ordercode"].ToString();
                    lgk.Model.tb_TrainTicketsOrder model = bllorder.GetModel("OrderID='" + orderid + "'");
                    if (model != null)
                    {
                        piaodate = Convert.ToDateTime(model.FromStationDate).ToString("yyyy-MM-dd");
                        trancode = model.CheCi;
                        starttime = Convert.ToDateTime(model.FromStationDate).ToShortTimeString();
                        startstationname = model.FromStationName;
                        arrivetime = Convert.ToDateTime(model.ToStationDate).ToShortTimeString();
                        endstationname = model.ToStationName;
                        usercode = model.LinkMan;
                        linkphone = model.LinkPhone;
                        // orderinfo = Request["orderinfo"].ToString();
                        price = model.OrderPrice.ToString();
                        orderid = model.OrderCode;
                        uid.Value = model.UserID.ToString();
                        ordercode.Value = model.OrderID;
                        status.Value = model.State.ToString();
                        states = States(model.State.ToString());
                        List<lgk.Model.tb_TrainTicketsOrderDetail> modeldite = bllorderdeil.GetModelList("OrderID=" + model.ID);
                        List<orderinfo> order = new List<orderinfo>();
                        for (int i = 0; i < modeldite.Count; i++)
                        {
                            orderinfo ordermodel = new orderinfo();
                            ordermodel.name = modeldite[i].PassengerseName;
                            ordermodel.idcard = modeldite[i].PassportseNO;
                            if (modeldite[i].InsuranceID != 0)
                            {
                                ordermodel.insurance = "1份";
                            }
                            else if (modeldite[i].InsuranceID == 0)
                            {
                                ordermodel.insurance = "无";
                            }
                           
                            order.Add(ordermodel);
                        }
                        DataSet ds = DataSetList(order);
                        bind_repeater(ds, Repeater1, "idcard");
                    }
                }
                catch (Exception ex)
                {
                     ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('系统异常，异常信息："+ex.Message+"');", true);
                }
                
            }
        }
        public string States(string state)
        {
            string str = "";
            if (state == "0")
            {
                str = "订单处理中";
            }
            if (state == "1")
            {
                str = "失败／失效／取消的订单";
            }
            if (state == "2")
            {
                str = "占座成功待支付";
            }
            if (state == "3")
            {
                str = "支付成功待出票";
            }
            if (state == "4")
            {
                str = "出票成功";
            }
            if (state == "5")
            {
                str = "出票失败";
            }
            if (state == "6")
            {
                str = "正在处理线上退票请求";
            }
            if (state == "7")
            {
                str = "有乘客退票成功";
            }
            if (state == "8")
            {
                str = "有乘客退票失败";
            }

            return str;
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
            dt.Columns.Add("idcard", typeof(string));
            dt.Columns.Add("insurance", typeof(string));
            for (int i = 0; i < emResult.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = emResult[i].name;
                dr[1] = emResult[i].idcard;
                dr[2] = emResult[i].insurance;
                dt.Rows.Add(dr);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;        }
    }
    public class orderinfo
    {
        public string name { set; get; }
        public string idcard { set; get; }
        public string insurance { set; get; }
        
    }
}