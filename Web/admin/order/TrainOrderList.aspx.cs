using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.order
{
    public partial class TrainOrderList : AdminPageBase
    {
        lgk.BLL.tb_TrainTicketsOrder tran = new lgk.BLL.tb_TrainTicketsOrder();
        lgk.BLL.tb_Account bllaccount = new lgk.BLL.tb_Account();
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 69, getLoginID());//权限
            //spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                banlcenmoney.Text = bllaccount.BanlceAcount("TrainAccount").ToString();
                BindData();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        
        private void BindData()
        {
            bind_repeater(tran.GetList(GetWhere()), Repeater1, "TrainDate desc", tr1, AspNetPager1);
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
        private string GetWhere()
        {
            string strWhere = "", strOrderCode = "";

            //购买状态(0未付款，1已付款，2已完成，3已终止)

            strWhere = "State>=0";

            #region 订单编号
            strOrderCode = txtOrderCode.Text.Trim();
            if (strOrderCode != "")
                strWhere += " AND OrderCode='" + strOrderCode + "'";
            #endregion

            #region 下定时间
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),TrainDate,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),TrainDate,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),TrainDate,120)  between '" + strStartTime + "' AND '" + strEndTime + "'");
            }
            #endregion

            return strWhere;
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}