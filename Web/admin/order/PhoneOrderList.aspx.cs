using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.order
{
    public partial class PhoneOrderList : AdminPageBase
    {
        lgk.BLL.tb_PhoneOrder tran = new lgk.BLL.tb_PhoneOrder();
        lgk.BLL.tb_Account bllaccount = new lgk.BLL.tb_Account();
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 71, getLoginID());//权限
            //spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                banlcenmoney.Text = bllaccount.BanlceAcount("PhoneAccount").ToString();
                BindData();
            }
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            bind_repeater(tran.GetList(GetWhere()), Repeater1, "AddDate desc", tr1, AspNetPager1);
        }
        private string GetWhere()
        {
            string strWhere = "", strOrderCode = "";

            //购买状态(0未付款，1已付款，2已完成，3已终止)

            strWhere = "State>=0";

            #region 订单编号
            strOrderCode = txtOrderCode.Text.Trim();
            if (strOrderCode != "")
                strWhere += " AND UorderID='" + strOrderCode + "'";
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
                str = "充值中";
            }
            if (state == "1")
            {
                str = "充值成功";
            }
            if (state == "9")
            {
                str = "充值失败";
            }
            return str;
        }
    }
}