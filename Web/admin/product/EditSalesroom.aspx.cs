using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Library;
using System.Drawing;

namespace web.admin.product
{
    public partial class EditSalesroom : AdminPageBase//System.Web.UI.Page//AdminPageBase
    {
        lgk.BLL.tb_goods_cxth goodsOneBLL = new lgk.BLL.tb_goods_cxth();

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 46, getLoginID());//权限
            if (!IsPostBack)
            {
                bindType();
                
                if (GetPID() != "")
                {
                    ShowInfo();
                }
            }

        }

        private void bindType()
        {
            bind_DropDownList_ht(dropOneType, produceTypeBLL.GetList("ParentID=0 and Type01 = 0").Tables[0], "ID", "TypeName"); //一级类目
        }

        protected void dropOneType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dropOneType.SelectedValue != "0")
            {
                ListItem item_list = new ListItem();
                item_list.Value = "0";
                item_list.Text = "请选择";
                this.dropSecondType.Items.Add(item_list);
                bind_DropDownList(this.dropSecondType, produceTypeBLL.GetList("ParentID=" + dropOneType.SelectedValue).Tables[0], "ID", "TypeName");
            }
        }

        protected void dropSecondType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dropSecondType.SelectedValue != "0")
            {
                ListItem item_list = new ListItem();
                item_list.Value = "0";
                item_list.Text = "请选择";
                this.dropThreeType.Items.Add(item_list);
                bind_DropDownList_ht(this.dropThreeType, produceTypeBLL.GetList("ParentID=" + dropSecondType.SelectedValue).Tables[0], "ID", "TypeName");
            }
        }

        string GetPID()
        {
            if (Request.QueryString["pid"] != null)
            {
                return Request.QueryString["pid"].ToString();
            }
            return "";
        }

        protected void ShowInfo()
        {
            lgk.Model.tb_goods_cxth model = goodsOneBLL.GetModel(Convert.ToInt32(GetPID()));
            txtGoodsCode.Text = model.GoodsCode;//编号
            txtGoodsName.Text = model.GoodsName;//名称
            txtPrice.Text = model.Price.ToString();//原价
            txtRealityPrice.Text = model.RealityPrice.ToString("0");//促销价

            txtPurchase.Text = model.Purchase.ToString(); //竞拍次数
            //txtCity.Text = model.City;
            dropOneType.SelectedValue = model.TypeID.ToString();//一级
            ListItem item_list = new ListItem();
            item_list.Value = "0";
            item_list.Text = "请选择";
            this.dropSecondType.Items.Add(item_list);
            bind_DropDownList(this.dropSecondType, produceTypeBLL.GetList("ParentID=" + model.TypeID).Tables[0], "ID", "TypeName");
            dropSecondType.SelectedValue = model.GoodsType.ToString();//二级

            bind_DropDownList_ht(this.dropThreeType, produceTypeBLL.GetList("ParentID=" + dropSecondType.SelectedValue).Tables[0], "ID", "TypeName");
            dropThreeType.SelectedValue = model.PareTopId.ToString();//三级

            textPubContext.Text = model.Remarks;//详情
            Image1.ImageUrl = "../../Upload/" + model.Pic1;//图片
            txtPlay.Text = model.Goods004;//支付时间
            txtCount.Text = model.Goods006.ToString();//数量
            txtStart.Text = model.Goods007.ToString();//k开始时间
            txtEnd.Text = model.Goods008.ToString();
        }

        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {
            if (this.dropOneType.SelectedValue == "0")
            {
                MessageBox.Show(this, "请选择一级类别");
                return;
            }
            if (this.dropSecondType.SelectedValue == "0")
            {
                MessageBox.Show(this, "请选择二级类别");
                return;
            }
            if (this.dropThreeType.SelectedValue == "0")
            {
                MessageBox.Show(this, "请选择三级类别");
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

            if (this.txtPrice.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入市场价");
                return;
            }
            if (txtRealityPrice.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入竞拍价");
                return;
            }
            if (txtCount.Text.Trim() == "")
            {
                MessageBox.Show(this, "请输入商品数量");
                return;
            }
            //if ( txtCity.Text.Trim() == "")
            //{
            //    MessageBox.Show(this, "请输入城市名");
            //    return;
            //}
            //if (txtPurchase.Text.Trim() == "")
            //{
            //    MessageBox.Show(this, "请输入每账号限制购买数量");
            //    return;
            //}
            try
            {
                decimal lsj = Convert.ToDecimal(txtPrice.Text);
                decimal ls = Convert.ToDecimal(txtRealityPrice.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "市场价、优惠价必须是数字");
                return;
            }
            //try
            //{
            //    Convert.ToInt32(txtPurchase.Text);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show(this, "每账号限制购买数量必须是数字");
            //    return;
            //}
            if (GetPID() == "")
            {
                if (goodsBLL.GetModel(" GoodsCode='" + this.txtGoodsCode.Text.Trim() + "'") != null)
                {
                    MessageBox.Show(this, "商品编号已存在，请重新输入");
                    return;
                }
                string upload1 = "";
                if (ViewState["urlname1"] != null)
                {
                    upload1 = ViewState["urlname1"].ToString();
                }
                if (upload1 == "")
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

                lgk.Model.tb_goods_cxth model = new lgk.Model.tb_goods_cxth();
                model.Goods001 = 1; //上架
                model.Goods002 = 0;//积分
                model.AddTime = DateTime.Now;
                model.GoodsCode = txtGoodsCode.Text.Trim();
                model.GoodsName = txtGoodsName.Text.Trim();
                model.Pic1 = upload1;//图片
                model.Price = Convert.ToDecimal(txtPrice.Text.Trim());//市场价
               // model.City = txtCity.Text.Trim();
                model.RealityPrice = Convert.ToDecimal(txtRealityPrice.Text.Trim());//竞拍价
                model.Remarks = textPubContext.Text;//详情
                model.Goods003 = 0;//不删除
                model.Goods004 =txtPlay.Text.Trim();//支付时间
                model.Goods005 = 0;//折扣
                model.Goods006 = Convert.ToInt32(txtCount.Text.Trim());//数量
                model.Goods007 = DateTime.Now;//Convert.ToDateTime(txtStart.Text.Trim());//开始时间
                model.Goods008 = DateTime.Now;//Convert.ToDateTime(txtEnd.Text.Trim());//结束时间
                model.TypeID = Convert.ToInt32(dropOneType.SelectedValue);//一级分类
                model.GoodsType = Convert.ToInt32(dropSecondType.SelectedValue);//二级分类
                model.PareTopId = Convert.ToInt32(dropThreeType.SelectedValue);//三级分类
                model.UploadUser = Convert.ToInt32(getLoginID());//上传者ID
                model.SealCount = 0;//卖出数量
                int iPurchase = Convert.ToInt32(model.Price / model.RealityPrice);
                model.Purchase = iPurchase;//Convert.ToInt32(txtPurchase.Text); //竞拍次数
                model.SealPurchase = 0;
                model.UserCode = "";
                model.UploadUser = 0;//上传者ID

                if (goodsOneBLL.Add(model) > 0)
                {
                    MessageBox.ShowAndRedirect(this, "添加成功", "SalesroomList.aspx");
                }
                else { MessageBox.Show(this, "添加失败"); }
            }
            else
            {
                lgk.Model.tb_goods_cxth model = goodsOneBLL.GetModel(Convert.ToInt32(GetPID()));
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
                model.Price = Convert.ToDecimal(txtPrice.Text.Trim());
                model.RealityPrice = Convert.ToDecimal(txtRealityPrice.Text.Trim());
                model.Remarks = textPubContext.Text;
                model.Goods002 = 0;//积分
                model.Goods004 = txtPlay.Text.Trim();//支付时间
                model.Goods005 = 0;//折扣
                model.Goods006 = Convert.ToInt32(txtCount.Text.Trim());//数量
                model.Goods007 = DateTime.Now;//Convert.ToDateTime(txtStart.Text.Trim());//开始时间
                model.Goods008 = DateTime.Now;//Convert.ToDateTime(txtEnd.Text.Trim());//结束时间
                model.TypeID = Convert.ToInt32(dropOneType.SelectedValue);//一级分类
                model.GoodsType = Convert.ToInt32(dropSecondType.SelectedValue);//二级分类
                model.PareTopId = Convert.ToInt32(dropThreeType.SelectedValue); ;//促销
             //   model.UploadUser = Convert.ToInt32(getLoginID());//上传者ID
                model.StateType = 0;//审核不通过
                int iPurchase = Convert.ToInt32(model.Price / model.RealityPrice);
                model.Purchase = iPurchase;
                model.UserCode = "";
                model.UploadUser = 0;//上传者ID
                                           //   model.City = txtCity.Text.Trim();
                if (goodsOneBLL.Update(model))
                {
                    MessageBox.ShowAndRedirect(this, "更新成功", "SalesroomList.aspx");
                }
                else
                {
                    MessageBox.Show(this, "更新失败");
                }
            }

        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesroomList.aspx");
        }

        /// <summary>
        /// 上传商品图片
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        private string UpLoadFile1(string pName)
        {
            string _fileName = "";
            string _name = "";
            if (FileUpload1.HasFile)
            {
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择商品图片!');", true);
                return;
            }
            string upload = UpLoadFile1("");
            ViewState["urlname1"] = upload;
            this.Image1.ImageUrl = "../../Upload/" + upload;
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('商品图片上传成功!');", true);
        }
    }
}