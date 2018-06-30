using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.order
{
    public partial class TrainOrderDetail : AdminPageBase
    {
        lgk.BLL.tb_TrainTicketsOrderDetail tran = new lgk.BLL.tb_TrainTicketsOrderDetail();
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 69, getLoginID());//权限

            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            int orderid = Convert.ToInt32(Request["orderID"].ToString());
            bind_repeater(tran.GetList("OrderID=" + orderid), Repeater1, "ID desc", tr1, AspNetPager1);
        }
        public string Status(string state)
        {
            string str = "";
            if (state == "0")
            {
                str = "待确认";
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

    }
}