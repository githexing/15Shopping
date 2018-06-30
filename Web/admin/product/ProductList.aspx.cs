/*********************************************************************************
*Copyright(c) 	2012 RJ.COM
 * 创建日期：		2012-5-8 18:09:18
 * 文 件 名：		ProductList.cs
 * CLR 版本:		2.0.50727.3053
 * 创 建 人：		
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述： 
**********************************************************************************/
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


namespace web.admin.product
{
    public partial class ProductList : AdminPageBase//System.Web.UI.Page//AdminPageBase//
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                BindData();
            }
        }
   
        private void BindData()
        {
            string strWhere = " ";
            strWhere = "1=1";

            if (txtCode.Value.Trim() != "")
            {
                strWhere += " and GoodsCode like '%" + txtCode.Value.Trim() + "%'";
            }
            if (txtName.Value.Trim() != "")
            {
                strWhere += " and GoodsName like '%" + txtName.Value.Trim() + "%'";
            }

            //GetGoodsList(strWhere)
            bind_repeater(goodsBLL.GetModelAndOneNameList(strWhere), Repeater1, "AddTime desc", tr1, AspNetPager1); // Goods001 desc,TypeID asc,AddTime desc
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            lgk.Model.tb_goods model = goodsBLL.GetModel(id);
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
                    if (goodsBLL.Update(model))
                    {
                        MessageBox.Show(this, "审核不通过!");
                    }
                }
                else
                {
                    model.StateType = 1;
                    if (goodsBLL.Update(model))
                    {
                        MessageBox.Show(this, "审核通过!");
                    }
                }
            }
            if (e.CommandName.Equals("edit")) //编辑商品
            {
                Response.Redirect("EditProduct.aspx?pid=" + id);
            }
            if (e.CommandName.Equals("up"))
            {
                model.Goods001 = 1;
                if (goodsBLL.Update(model))
                {
                    MessageBox.Show(this, "上架成功!");
                }
            }
            if (e.CommandName.Equals("down"))
            {
                model.Goods001 = 0;
                if (goodsBLL.Update(model))
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
                if (goodsBLL.Delete1(id))
                {
                    MessageBox.Show(this, "删除成功!");
                }
            }
            BindData();
        }

        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProduct.aspx");
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        //protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bind(Convert.ToInt32(ddlType.SelectedValue));
        //}

        public string KuCun(int cun,string id) 
        {
            int num = ConvertToInt(DbHelperSQL.GetSingle("SELECT isnull(sum(OrderSum),0) AS ordersum FROM tb_OrderDetail t WHERE t.ProcudeID=" + id));//销售数量
            return (cun - num).ToString();
        }
    }
}
