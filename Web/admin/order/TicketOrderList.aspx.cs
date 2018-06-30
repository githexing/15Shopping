using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.order
{
    public partial class TicketOrderList : AdminPageBase
    {
        lgk.BLL.tb_TicketOrder ticket = new lgk.BLL.tb_TicketOrder();
        lgk.BLL.tb_Account bllaccount = new lgk.BLL.tb_Account();
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 70, getLoginID());//权限
            //spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                banlcenmoney.Text = bllaccount.BanlceAcount("TicketAccount").ToString();
                BindData();

            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {

        }
        private void BindData()
        {
            bind_repeater(ticket.GetList(GetWhere()), Repeater1, "AddDate desc", tr1, AspNetPager1);
        }
        private string GetWhere()
        {
            string strWhere = "", strOrderCode = "";

            //购买状态(0未付款，1已付款，2已完成，3已终止)

            strWhere = "Status>=0";

            #region 订单编号
            strOrderCode = txtOrderCode.Text.Trim();
            if (strOrderCode != "")
                strWhere += " AND OrdeID='" + strOrderCode + "'";
            #endregion

            #region 下定时间
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),AddDate,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),AddDate,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),AddDate,120)  between '" + strStartTime + "' AND '" + strEndTime + "'");
            }
            #endregion

            return strWhere;
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
    }
}