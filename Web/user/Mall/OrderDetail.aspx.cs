using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Mall
{
    public partial class OrderDetail : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["OrderCode"] != null && Request.QueryString["OrderCode"] != "")
                {
                    ShowInfo(Request.QueryString["OrderCode"]);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "history.back();", true);
                }
            }
        }

        protected void ShowInfo(string order)
        {
            lgk.Model.tb_Order orderInfo = orderBLL.GetModelByCode(order);
            if (orderInfo != null)
            {
                int iSendType = orderInfo.IsSend;

                lgk.Model.tb_user user = userBLL.GetModel(" UserID=" + orderInfo.UserID);

                ltOrderCode.Text = orderInfo.OrderCode;//订单号
                ltAddTime.Text = orderInfo.OrderDate.ToString();
                ltStateName.Text = OrderStateName(iSendType);

                hdoid.Value = orderInfo.OrderID.ToString();
                hdsend.Value = iSendType.ToString();
                ltPhone.Text = orderInfo.Order6 == null ? "" : orderInfo.Order6;//手机号码
                ltUserName.Text = orderInfo.Order7 == null ? "" : orderInfo.Order7;//收货人姓名
                ltAddress.Text = orderInfo.UserAddr == null ? "" : orderInfo.UserAddr;//收货地址
                ltTotalAmount.Text = orderInfo.OrderTotal.ToString() == null ? "" : orderInfo.OrderTotal.ToString();//总额
                ltGongsi.Text = orderInfo.Order3 == null ? "" : orderInfo.Order3;//快递公司
                ltDanhao.Text = orderInfo.Order4 == null ? "" : orderInfo.Order4;//快递单号
                if (orderInfo.Order5=="")
                {
                    orderInfo.Order5 = "1";
                }
                var model = agent1BLL.GetModel(agent1BLL.GetAgentsIDByUserCode(userBLL.GetModel(long.Parse(orderInfo.Order5)).UserCode));
                Literal1.Text = model.AgentCode;
                Literal2.Text = model.PicLink;
            }

            bind_repeater(orderDetailBLL.GetGoodsListAll(" d.OrderCode=" + order), Repeater1, "OrderDate desc", tr1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                ShowInfo(Request.QueryString["id"]);
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

    }
}