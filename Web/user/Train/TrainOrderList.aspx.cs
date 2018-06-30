using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Train
{
    public partial class TrainOrderList : System.Web.UI.Page
    {
        lgk.BLL.tb_TrainTicketsOrder train = new lgk.BLL.tb_TrainTicketsOrder();
        protected void Page_Load(object sender, EventArgs e)
        
        {
            if (!IsPostBack)
            {
                if (Request["UserID"] == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请登录后再操作');", true);//没有这个用户
                    //MessageBox.ShowBox(this.Page, "请登录后再操作", Library.Enums.ModalTypes.warning);//请登录
                   // Response.Redirect("/Login.aspx");
                }
                else
                {
                    DataSet ds = train.GetList(StrWhere("全部"));
                    bind_repeater(ds, Repeater1, "TrainDate desc");
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
        protected void all_Click(object sender, EventArgs e)
        {
            DataSet ds = train.GetList(StrWhere(all.Text));
            bind_repeater(ds, Repeater1, "TrainDate desc");
            dpay.CssClass = "";
            ypayt.CssClass = "";
          
            nopay.CssClass = "";
            all.CssClass = "active";
        }
        public string StrWhere(string strWhere)
        {
            string userid = Request["UserID"].ToString();
            string str = "";
            if (strWhere.Equals("全部"))
            {
                str = " UserID=" + userid ;
            }
            if (strWhere.Equals("未支付"))
            {
                str = " UserID=" + userid + " and State<=2";
            }
            if (strWhere.Equals("出票中"))
            {
                str = " UserID=" + userid + " and State=3";
            }
            if (strWhere.Equals("已出票"))
            {
                str = " UserID=" + userid + " and State=4";
            }
            if (strWhere.Equals("退票"))
            {
                str = " UserID=" + userid + " and State>=6";
            }
            return str;
        }
        protected void nopay_Click(object sender, EventArgs e)
        {   
            DataSet ds = train.GetList(StrWhere(nopay.Text));
            bind_repeater(ds, Repeater1, "TrainDate desc");
            dpay.CssClass = "";
            ypayt.CssClass = "";
           
            nopay.CssClass = "active";
            all.CssClass = "";
        }

        protected void dpay_Click(object sender, EventArgs e)
        {
            DataSet ds = train.GetList(StrWhere(dpay.Text));
            bind_repeater(ds, Repeater1, "TrainDate desc");
            dpay.CssClass = "active";
            ypayt.CssClass = "";
          
            nopay.CssClass = "";
            all.CssClass = "";
        }

        protected void ypayt_Click(object sender, EventArgs e)
        {
            DataSet ds = train.GetList(StrWhere(ypayt.Text));
            bind_repeater(ds, Repeater1, "TrainDate desc");
            dpay.CssClass = "";
            ypayt.CssClass = "active";
          
            nopay.CssClass = "";
            all.CssClass = "";
        }
    }
}