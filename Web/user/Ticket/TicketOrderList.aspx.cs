using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Ticket
{
    public partial class TicketOrderList : System.Web.UI.Page
    {
        lgk.BLL.tb_TicketOrder trcket = new lgk.BLL.tb_TicketOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["UserID"] == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请登录后再操作');", true);//没有这个用户                                                         // Response.Redirect("/Login.aspx");
                }
                else
                {
                    DataSet ds = trcket.GetList(StrWhere("全部"));
                    bind_repeater(ds, Repeater1, "AddDate desc");
                }
            }
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
        public string States(string state)
        {
            string str = "";
            if (state == "0")
            {
                str = "待确认";
            }
            if (state == "1")
            {
                str = "等待支付";
            }
            if (state == "2")
            {
                str = "等待出票";
            }
            if (state == "3")
            {
                str = "出票完成";
            }
            if (state == "10")
            {
                str = "订单关闭";
            }
            if (state == "16")
            {
                str = "暂不能出票";
            }
            if (state == "19")
            {
                str = "已拒单";
            }
            if (state == "31")
            {
                str = "退款中";
            }
            if (state == "32")
            {
                str = "退款失败";
            }
            if (state == "33")
            {
                str = "退款成功";
            }
            return str;
        }
        public string StrWhere(string strWhere)
        {
            string userid = Request["UserID"].ToString();
            string str = "";
            if (strWhere.Equals("全部"))
            {
                str = "UserID=" + userid ;
            }
            if (strWhere.Equals("未支付"))
            {
                str = "UserID=" + userid+" and Status<=1 and PayStatus=0";
            }
            if (strWhere.Equals("出票中"))
            {
                str = "UserID=" + userid + " and Status=2 and PayStatus=1";
            }
            if (strWhere.Equals("已出票"))
            {
                str = "UserID=" + userid + " and Status=3 and PayStatus=1";
            }
            return str;
        }
        protected void nopay_Click(object sender, EventArgs e)
        {
            DataSet ds = trcket.GetList(StrWhere(nopay.Text));
            bind_repeater(ds, Repeater1, "AddDate desc");
            dpay.CssClass = "";
            ypayt.CssClass = "";
            nopay.CssClass = "active";
            all.CssClass = "";
        }

        protected void dpay_Click(object sender, EventArgs e)
        {
            DataSet ds = trcket.GetList(StrWhere(dpay.Text));
            bind_repeater(ds, Repeater1, "AddDate desc");
            dpay.CssClass = "active";
            ypayt.CssClass = "";

            nopay.CssClass = "";
            all.CssClass = "";
        }

        protected void ypayt_Click(object sender, EventArgs e)
        {
            DataSet ds = trcket.GetList(StrWhere(ypayt.Text));
            bind_repeater(ds, Repeater1, "AddDate desc");
            dpay.CssClass = "";
            ypayt.CssClass = "active";

            nopay.CssClass = "";
            all.CssClass = "";
        }

        protected void all_Click(object sender, EventArgs e)
        {
            DataSet ds = trcket.GetList(StrWhere(all.Text));
            bind_repeater(ds, Repeater1, "AddDate desc");
            dpay.CssClass = "";
            ypayt.CssClass = "";

            nopay.CssClass = "";
            all.CssClass = "active";
        }
    }
}