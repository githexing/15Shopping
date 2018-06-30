using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Library;
using System.Drawing;
using System.Data;
using System.IO;

namespace web.admin.product
{
    public partial class EditProduct : AdminPageBase//System.Web.UI.Page//AdminPageBase
    {
        lgk.BLL.tb_globeParam glo = new lgk.BLL.tb_globeParam();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindType();
                bind_DropDownList_ht(ddlType, produceTypeBLL.GetList("ParentID=0 ").Tables[0], "ID", "TypeName"); //一级类目

                if (GetPID() > 0)
                {
                    //bindSize();
                    ShowInfo();
                    //bindProperty();
                }
            }
        }

        private void BindType()
        {
            IList<lgk.Model.tb_produceType> list = produceTypeBLL.GetModelList(" ParentID>1");
            ddlType.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            ddlType.Items.Add(li);
            foreach (lgk.Model.tb_produceType item in list)
            {
                ListItem items = new ListItem();
                items.Value = item.ID.ToString();
                items.Text = item.TypeName;
                ddlType.Items.Add(items);
            }
        }

        private void bindProperty()
        {
            //int gid = GetPID();
            //if (gid <= 0) return;
            //   GetGoodsProperty(Convert.ToInt32(getrequest()))

            //bind_repeater(new lgk.BLL.tb_goods_property_color().GetList("goodsid=" + gid), rpColor, "", tr1);
        }

        protected int GetPID()
        {
            if (Request.QueryString["pid"] != null)
            {
                return int.Parse(Request.QueryString["pid"].ToString());
            }
            return 0;
        }

        private void bindSize()
        {
            //bind_repeater(new lgk.BLL.tb_goods_size().GetList(""), rpSize, "", tr1);
        }

        protected void ShowInfo()
        {
            lgk.Model.tb_goods model = goodsBLL.GetModel(GetPID());
            txtGoodsCode.Text = model.GoodsCode;
            txtGoodsName.Text = model.GoodsName;

            txtPrice.Text = model.Price.ToString();
            txtShopPrice.Text = model.ShopPrice.ToString();
            txtNum.Text = model.Goods002.ToString();//库存

            //Goods004
            //foreach( ListItem li in  checkList.Items)
            //{
            //    if (("," + model.Goods004 + ",").IndexOf("," + li.Value + ",") > -1)
            //    {
            //        li.Selected = true;
            //    }
            //}
           
            //txtCity.Text = model.City;
            ddlType.SelectedValue = model.TypeID.ToString();
            ListItem item_list = new ListItem();
            item_list.Value = "0";
            item_list.Text = "请选择";
            //this.ddl_secondType.Items.Add(item_list);
            //bind_DropDownList(this.ddl_secondType, produceTypeBLL.GetList("ParentID=" + model.TypeID).Tables[0], "ID", "TypeName");
            //ddl_secondType.SelectedValue = model.GoodsType.ToString();
            textPubContext.Text = model.Remarks;
            
            Image1.ImageUrl = "../../Upload/" + model.Pic1;
        }

        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {

            if (this.ddlType.SelectedValue == "0")
            {
                MessageBox.Show(this, "请选择商品类别");
                return;
            }
            if (this.txtGoodsCode.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入商品编号");
                return;
            }
            if (this.txtGoodsName.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入商品名称");
                return;
            }

            if (this.txtNum.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入库存");
                return;
            }
            if (this.txtPrice.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入市场价");
                return;
            }
            if (this.txtShopPrice.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入本站价");
                return;
            }

            try
            {
                decimal lsj = Convert.ToDecimal(txtPrice.Text);
                decimal lsj2 = Convert.ToDecimal(txtShopPrice.Text);
                decimal kucun = Convert.ToDecimal(txtNum.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "库存、市场价、积分必须是数字");
                return;
            }

            if (GetPID() == 0)
            {
                if (goodsBLL.GetModel(" GoodsCode='" + this.txtGoodsCode.Text.Trim() + "'") != null)
                {
                    MessageBox.Show(this, "商品编号已存在，请重新输入");
                    return;
                }
                string strUpload = "";
                if (ViewState["urlname1"] != null)
                {
                    strUpload = ViewState["urlname1"].ToString();
                }
                if (strUpload == "")
                {
                    MessageBox.Show(this, "请上传商品图片");
                    return;
                }
                //  upload1 = upload1.Substring(upload1.LastIndexOf("/") + 1, upload1.Length - upload1.LastIndexOf("/") - 1);

                if (this.textPubContext.Text.Trim() == "")
                {
                    MessageBox.Show(this, "请输入商品详情");
                    return;
                }
                int danwei=0;
                //if (int.TryParse(TextBox1.Text, out danwei)==false)
                //{
                //    MessageBox.Show(this, "请输入正确的分润单位");
                //    return;
                //}

                lgk.Model.tb_goods model = new lgk.Model.tb_goods();
                model.Goods001 = 1;
                model.Goods002 = Convert.ToInt32(txtNum.Text.Trim());//库存
                model.AddTime = DateTime.Now;
                model.GoodsCode = txtGoodsCode.Text.Trim();
                model.GoodsName = txtGoodsName.Text.Trim();
                //model.UploadUser = 0;//上传者ID
                //model.City = txtCity.Text.Trim();
                model.Pic1 = strUpload;
                model.Price = Convert.ToDecimal(txtPrice.Text.Trim());
                model.ShopPrice = Convert.ToDecimal(txtShopPrice.Text.Trim());
                model.RealityPrice = model.ShopPrice;//
                model.Pic5 = "";
                model.Remarks = textPubContext.Text;
                //model.UserCode = "";
                model.IsHave = danwei;// 分润单位
                model.Goods003 = "0";//1:隐藏
                string chkSelect = "";
                //for (int i = 0; i < checkList.Items.Count; i++)
                //{
                //    if (checkList.Items[i].Selected == true)
                //    {
                //        chkSelect += checkList.Items[i].Value + ",";
                //    }
                //}
                //if (chkSelect != "")
                //{
                //    chkSelect = chkSelect.Substring(0, chkSelect.Length - 1);
                //}
                //else
                //{
                //    chkSelect = "0";
                //}
                model.Goods004 = chkSelect;
                model.Goods005 = 0;//折扣
                model.TypeID = Convert.ToInt32(ddlType.SelectedValue);//一级分类
                model.GoodsType = 0;//二级分类
                model.Goods006 = 0;
                model.Remarks_en = "";
                model.GoodsName_en = "";

                if (goodsBLL.Add(model) > 0)
                {
                    MessageBox.ShowAndRedirect(this, "添加成功", "ProductList.aspx");
                }
                else { MessageBox.Show(this, "添加失败"); }
            }
            else
            {
                lgk.Model.tb_goods model = goodsBLL.GetModel(GetPID());
                int danwei = 0;
                //if (int.TryParse(TextBox1.Text, out danwei) == false)
                //{
                //    MessageBox.Show(this, "请输入正确的分润单位");
                //    return;
                //}
                string upload1 = "";
                if (ViewState["urlname1"] != null)
                {
                    upload1 = ViewState["urlname1"].ToString();
                }
                if (upload1 != "")
                {
                    upload1 = upload1.Substring(upload1.LastIndexOf("/") + 1, upload1.Length - upload1.LastIndexOf("/") - 1);
                    model.Pic1 = upload1;
                }
                model.GoodsCode = txtGoodsCode.Text.Trim();
                model.GoodsName = txtGoodsName.Text.Trim();
                //model.City = txtCity.Text.Trim();
                model.Price = Convert.ToDecimal(txtPrice.Text.Trim());
                model.ShopPrice = Convert.ToDecimal(txtShopPrice.Text.Trim());
                model.RealityPrice = model.ShopPrice;//
                model.Pic5 = "";
                model.Remarks = textPubContext.Text;
                model.Goods002 = Convert.ToInt32(txtNum.Text.Trim());//库存
                model.Goods005 = 0;//打折
                model.IsHave = danwei;// 分润单位
                //model.UserCode = "";

                string chkSelect = "";
                //for (int i = 0; i < checkList.Items.Count; i++)
                //{
                //    if (checkList.Items[i].Selected == true)
                //    {
                //        chkSelect += checkList.Items[i].Value + ",";
                //    }
                //}
                //if (chkSelect != "")
                //{
                //    chkSelect = chkSelect.Substring(0, chkSelect.Length - 1);
                //}
                //else
                //{
                //    chkSelect = "0";
                //}
                model.Goods004 = chkSelect;


                model.TypeID = Convert.ToInt32(ddlType.SelectedValue);
                //model.GoodsType = Convert.ToInt32(ddl_secondType.SelectedValue);
                //model.Goods006 = Convert.ToDecimal(dd_sanType.SelectedValue);

                model.StateType = 0;//审核
                if (goodsBLL.Update(model))
                {
                    MessageBox.ShowAndRedirect(this, "更新成功", "ProductList.aspx");
                }
                else
                {
                    MessageBox.Show(this, "更新失败");
                }
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductList.aspx");
        }

        /// <summary>
        /// 上传商品图片
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        private string UpLoadFile(string pName)
        {
            string _fileName = "";
            string _name = "";
            if (FileUpload1.HasFile)
            {
                if (Directory.Exists(Server.MapPath("~/Upload")) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(Server.MapPath("~/Upload"));
                }
                _fileName = (Server.MapPath("../../Upload/"));
                if (pName == "")
                    _name = DateTime.Now.ToString("yyyyMMddHHmmss") + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.'));
                else
                    _name = pName;
                _fileName += _name;
                FileUpload1.SaveAs(_fileName);
            }
            return _name;
        }

        /// <summary>
        /// 商品图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择商品图片!');", true);
                return;
            }
            string upload = UpLoadFile("");
            ViewState["urlname1"] = upload;
            this.Image1.ImageUrl = "../../Upload/" + upload;
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('商品图片上传成功!');", true);
        }

        #region 二级分类（注释）
        //protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.ddlType.SelectedValue != "0")
        //    {
        //        ListItem item_list = new ListItem();
        //        item_list.Value = "0";
        //        item_list.Text = "请选择";
        //        this.ddl_secondType.Items.Add(item_list);
        //        bind_DropDownList_ht(this.ddl_secondType, produceTypeBLL.GetList("ParentID=" + ddlType.SelectedValue).Tables[0], "ID", "TypeName");
        //    }
        //}
        #endregion

        #region 三级分类（注释）
        //protected void ddl_secondType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.ddl_secondType.SelectedValue != "0")
        //    {
        //        ListItem item_list = new ListItem();
        //        item_list.Value = "0";
        //        item_list.Text = "请选择";
        //        this.dd_sanType.Items.Add(item_list);
        //        bind_DropDownList_ht(this.dd_sanType, produceTypeBLL.GetList("ParentID=" + ddl_secondType.SelectedValue).Tables[0], "ID", "TypeName");
        //    }
        //} 
        #endregion

        lgk.BLL.tb_goods_property_size psizeBLL = new lgk.BLL.tb_goods_property_size();

        protected void rpColor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptProduct = (Repeater)e.Item.FindControl("rptProduct");
                //找到分类Repeater关联的数据项
                DataRowView rowv = (DataRowView)e.Item.DataItem;
                //提取分类ID
                int CategorieId = Convert.ToInt32(rowv["ColorID"]);
                //根据分类ID查询该分类下的产品，并绑定产品Repeater
                rptProduct.DataSource = psizeBLL.GetList(" ColorID =" + CategorieId);
                rptProduct.DataBind();
            }
        }

        protected void rpColor_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int colorid = Convert.ToInt32(e.CommandArgument);
                var sizelist = new lgk.BLL.tb_goods_property_size().GetModelList(" colorid = " + colorid);
                foreach (var size in sizelist)
                {
                    new lgk.BLL.tb_goods_property_size().Delete(size.ID);
                }
                new lgk.BLL.tb_goods_property_color().Delete(colorid);
                MessageBox.ShowAndRedirect(this, "颜色删除成功！", "EditProduct.aspx?pid=" + GetPID());
            }
        }

    }
}