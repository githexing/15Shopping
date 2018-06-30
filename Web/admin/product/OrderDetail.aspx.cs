using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Library;
namespace web.admin.product
{
    public partial class OrderDetail : AdminPageBase
    {
        lgk.BLL.tb_Order ob = new lgk.BLL.tb_Order();
        lgk.BLL.tb_OrderDetail detailBLL = new lgk.BLL.tb_OrderDetail();
        lgk.BLL.tb_flag fg = new lgk.BLL.tb_flag();
        lgk.BLL.tb_goods tb_goodsBLL = new lgk.BLL.tb_goods();
        lgk.Model.tb_goods tb_goodsModel = new lgk.Model.tb_goods();

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 39, getLoginID());//权限

            if (!IsPostBack)
            {
                BindData();
            }

        }

        protected void BindData()
        {
            lgk.Model.tb_Order model = ob.GetModel("OrderCode='" + getStringRequest("oid") + "'");
            lgk.Model.tb_user user = userBLL.GetModel(" UserID=" + model.UserID);
            string orderID = getStringRequest("oid") == null ? "" : getStringRequest("oid");
            string UserCode = user.UserCode == null ? "" : user.UserCode;
            string TrueName = user.TrueName == null ? "" : user.TrueName;
            string UserAddr = model.UserAddr == null ? "" : model.UserAddr;
            string OrderTotal = model.OrderTotal.ToString() == null ? "" : model.OrderTotal.ToString();
            string order3 = model.Order3 == null ? "" : model.Order3;
            string order4 = model.Order4 == null ? "" : model.Order4;
            Label1.Text = orderID;//订单号
            Label2.Text = UserCode;//代理编号
            Label3.Text = model.Order7;//代理姓名
            Label4.Text = UserAddr;//收货地址
           // Label5.Text = OrderTotal;//总额
            Label6.Text = order3;//快递公司
            Label7.Text = order4;//快递单号
                                 // bind_repeater(GetDetail(getStringRequest("oid")), rptOrder, "OrderDate desc", null, AspNetPager1);
            //int typeid = 0;
            //var pmodel = produceTypeBLL.GetModel("Type02 = 1");
            //if (pmodel != null)
            //    typeid = pmodel.ID;

            if (model.TypeID == 0) //如果等于促销类
            {
                bind_repeater(GetDetail(getStringRequest("oid")), Repeater1, "OrderDate desc", null, AspNetPager1);
            }
            else
            {
                bind_repeater(GetDetail(getStringRequest("oid"), 5), Repeater1, "OrderDate desc", null, AspNetPager1);
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("<script language=javascript>self.history.back(1);</script>");
        }

        //protected int Pid(string cid)
        //{
        //    if (cid != "" && PageValidate.IsInt(cid) == true)
        //    {
        //        int id = Convert.ToInt32(cid);
        //        tb_goodsModel = tb_goodsBLL.GetModel(id);
        //        if (tb_goodsModel.TypeID > 0)
        //        {
        //            return tb_goodsModel.TypeID;
        //        }
        //        else
        //            return -1;
        //    }
        //    else
        //        return -1;
        //}

        protected string Pid(string cid, string gid)
        {
            string url = "#";
            if (cid != "" && PageValidate.IsInt(cid) == true)
            {
                int id = Convert.ToInt32(cid);
                int goodId = Convert.ToInt32(gid);
                //if (id == 37) //促销类
                //{
                //    lgk.BLL.tb_goods_cxth g = new lgk.BLL.tb_goods_cxth();
                //    lgk.Model.tb_goods_cxth gModel = new lgk.Model.tb_goods_cxth();
                //    gModel = g.GetModel(goodId);
                //    if (gModel.PareTopChild == 78)//秒杀
                //    {

                //        url = "../../user/shop/miaoshao.aspx?pid=" + gModel.PareTopChild + "&id=" + goodId;
                //    }
                //    else
                //    {
                //        url = "../../user/shop/tuangou_detail.aspx?pid=" + gModel.PareTopChild + "&id=" + goodId;
                //    }
                   
                //    return url;
                //}
                //else //普通类
                {
                    url = "../../user/shop/goodsdetail.aspx?pid=" + cid + "&gid=" + goodId;
                    return url;
                }

            }
            return url;

        }
    }
}