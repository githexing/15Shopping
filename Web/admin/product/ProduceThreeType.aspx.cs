using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Library;
using System.Drawing;

namespace Web.admin.product
{
    public partial class ProduceThreeType : AdminPageBase//System.Web.UI.Page//
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 55, getLoginID());//权限
            //spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        ///分頁 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 绑定数据到repeater2控件
        /// </summary>
        /// <param name="str"></param>
        void BindData()
        {
            this.ddlPriduceType.DataSource = produceTypeBLL.GetList("parentID in (select id from tb_produceType where ParentID=0)");
            this.ddlPriduceType.DataTextField = "TypeName";
            this.ddlPriduceType.DataValueField = "ID";
            this.ddlPriduceType.DataBind();
            bind_repeater(produceTypeBLL.GetList("ParentID in (select ID FROM tb_produceType where ParentID in (select id from tb_produceType where ParentID=0))"), Repeater1, "", span1, AspNetPager1);
        }

        /// <summary>
        /// 添加类目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPriduceType.Text))
            {
                MessageBox.Show(this, "请输入三级分类名");
                return;
            }

            else
            {
                string Name = this.txtPriduceType.Text;
                int ParentID = ConvertToInt(this.ddlPriduceType.SelectedValue);
                lgk.Model.tb_produceType model = new lgk.Model.tb_produceType();
                model.TypeName = Name;
                model.ParentID = ParentID;
                if (produceTypeBLL.Add(model) > 0)
                {
                    MessageBox.Show(this, "添加成功！");
                    BindData();
                    this.txtPriduceType.Text = "";
                }
            }
        }

        /// <summary>
        /// 绑定父类别名称
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public string GetParentName(object ParentID)
        {
            lgk.Model.tb_produceType model = produceTypeBLL.GetModel(ConvertToInt(ParentID));
            return model.TypeName;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            string name = e.CommandName.ToString();
            int id = Convert.ToInt32(e.CommandArgument);
            //string[] ids = id.Split(',');
            //int cid = int.Parse( ids[0]);
            //int pid = int.Parse(ids[1]);
            lgk.Model.tb_produceType model = produceTypeBLL.GetModel(id);
            if (name == "del")//删除
            {

                int online = goodsBLL.GetModelList(" Goods001=1 and GoodsType=" + id).Count;
                int d = tb_SalesroomBll.GetModelList(" SaTargetPoint=" + id).Count;
                if (online > 0)// || tb_SalesroomBll.GetModelList(" SaTargetPoint=" + id).Count > 0)
                {
                    MessageBox.Show(this, "请先下架此类别下的所有商品，再删除！");
                    return;
                }
                else
                {
                    if (id <= 77 || id == 78 || id == 79)
                    {
                        MessageBox.Show(this, "该类别不能删除！");
                        return;
                    }
                    else
                    {
                        if (produceTypeBLL.DeleteForHide(id))
                        {
                            MessageBox.Show(this, "删除成功！");
                        }
                    }

                }
            }
            if (name == "Update")//修改
            {
                TextBox txt_des = (TextBox)e.Item.FindControl("txtTypeName");//二级分类
                if (string.IsNullOrEmpty(txt_des.Text))
                {
                    MessageBox.Show(this, "请输入三级分类名");
                    return;
                }
                else
                {
                    model.TypeName = txt_des.Text.Trim();
                    if (produceTypeBLL.Update(model))
                    {
                        MessageBox.Show(this, "编辑成功！");
                    }
                }
            }
            BindData();
        }
    }
}