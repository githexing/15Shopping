using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Library;
using System.Web.UI.HtmlControls;
using DataAccess;
using lgk.DAL;

namespace web.admin.product
{
    public partial class SalesroomList : AdminPageBase//System.Web.UI.Page//AdminPageBase//
    {
        lgk.BLL.tb_goods_cxth _goodsBLL = new lgk.BLL.tb_goods_cxth();

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 46, getLoginID());//权限
            //spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                bind();
                //ddlType.SelectedValue = "1";
            }
        }
 
        private void bind()
        {
            string where = " 1=1";

            if (txtCode.Value.Trim() != "")
            {
                where += " and GoodsCode like '%" + txtCode.Value.Trim() + "%'";
            }
            if (txtName.Value.Trim() != "")
            {
                where += " and GoodsName like '%" + txtName.Value.Trim() + "%'";
            }
            tb_flag cx = new tb_flag();
            bind_repeater(cx.GetGoodsListCx(where), Repeater1, "Goods001 desc,TypeID asc,AddTime desc", tr1, AspNetPager1);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
           bind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
            //bind(Convert.ToInt32(ddlType.SelectedValue));
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int iID = Convert.ToInt32(e.CommandArgument.ToString());
            lgk.Model.tb_goods_cxth model = _goodsBLL.GetModel(iID);

            if (model == null)
            {
                MessageBox.Show(this, "该商品已删除!");
                return;
            }

            if (e.CommandName.Equals("Audit")) //审核商品
            {
                if (model.StateType == 1)
                {
                    model.StateType = 0;
                    if (_goodsBLL.Update(model))
                    {
                        MessageBox.Show(this, "审核不通过!");
                    }
                }
                else
                {
                    model.StateType = 1;
                    if (_goodsBLL.Update(model))
                    {
                        MessageBox.Show(this, "审核通过!");
                    }

                }
            }
            if (e.CommandName.Equals("edit")) //编辑商品
            {
                Response.Redirect("EditSalesroom.aspx?pid=" + iID);
            }
            if (e.CommandName.Equals("up"))
            {
                model.Goods001 = 1;
                if (_goodsBLL.Update(model))
                {
                    MessageBox.Show(this, "上架成功!");
                }
            }
            if (e.CommandName.Equals("down"))
            {
                model.Goods001 = 0;
                if (_goodsBLL.Update(model))
                {
                    MessageBox.Show(this, "下架成功!");
                }
            }
            if (e.CommandName.Equals("del")) //商品上架
            {
                if (model.Goods001 > 0)
                {
                    MessageBox.Show(this, "请先下架后再删除!");
                    return;
                }
                if (_goodsBLL.Delete1(iID))
                {
                    MessageBox.Show(this, "删除成功!");
                }

                //if (getOrder(id) > 0)
                //{
                //    MessageBox.Show(this, "该商品已有订单，不能删除!");
                //    return;
                //}
                //if (goodsBLL.Delete(id))
                //{
                //    MessageBox.Show(this, "删除成功!");
                //}
            }
            if (e.CommandName.Equals("lucky")) //抽奖
            {
                model.IsLucky = 1;
                if (_goodsBLL.Update(model))
                {
                    MessageBox.Show(this, "抽奖成功!");
                }

                //SELECT o.UserID FROM [NN15080570].[dbo].[tb_OrderDetail] d
                //join [tb_Order] as o on o.OrderCode = d.OrderCode where o.TypeID = 5 AND d.ProcudeID = 1

                long iUserID = 0;
                long iProcudeID = 0;
                string strOrderCode = "";
                IList<lgk.Model.tb_OrderDetail> listone = orderDetailBLL.GetJoinList("o.TypeID = 5 AND d.ProcudeID = " + iID + " ORDER BY NEWID()");
                //foreach (lgk.Model.tb_OrderDetail item in listone)
                //{
                //    iUserID = item.UserID;
                //    iProcudeID = item.ProcudeID;
                //    strOrderCode = item.OrderCode;
                //}

                IList<lgk.Model.tb_OrderDetail> list = orderDetailBLL.GetJoinListAll("o.TypeID = 5 AND d.ProcudeID = " + iID + "");

                foreach (lgk.Model.tb_OrderDetail item in list)
                {
                    //删除未抽中的订单

                    if (strOrderCode != item.OrderCode)
                    {
                        orderBLL.Delete(item.OrderCode);
                        orderDetailBLL.DeleteByOrderCode(item.OrderCode);
                    }
                }
            }
            bind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditSalesroom.aspx");
        }

        protected void btnChuSearch_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int iID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ID"));

                LinkButton lbtnAudit = (LinkButton)e.Item.FindControl("lbtnAudit");
                LinkButton lbtnEdit = (LinkButton)e.Item.FindControl("lbtnEdit");
                LinkButton lbtnDel = (LinkButton)e.Item.FindControl("lbtnDel");
                LinkButton lbtnLucky = (LinkButton)e.Item.FindControl("lbtnLucky");

                lgk.Model.tb_goods_cxth model = _goodsBLL.GetModel(iID);

                //IList<lgk.Model.tb_OrderDetail> list = orderDetailBLL.GetJoinListAll("o.TypeID = 5 AND d.ProcudeID = " + iID + "");

                if (model.Purchase == model.SealPurchase && model.IsLucky == 0)// && list.Count >= 1)
                    lbtnLucky.Visible = true;
                else if (model.Purchase == model.SealPurchase && model.IsLucky == 1)
                {
                    lbtnAudit.Visible = false;
                    lbtnEdit.Visible = false;
                    lbtnDel.Visible = false;
                    lbtnLucky.Visible = false;
                }
                else
                {
                    lbtnLucky.Visible = false;
                }
            }
        }
        //public string KuCun(int cun, string id)
        //{
        //    int num = ConvertToInt(DbHelperSQL.GetSingle("SELECT isnull(sum(OrderSum),0) AS ordersum FROM tb_OrderDetail t WHERE t.ProcudeID=" + id));//销售数量
        //    return (cun - num).ToString();
        //}
        //protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bind(Convert.ToInt32(ddlType.SelectedValue));
        //}

    }
}
