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
    public partial class ProduceOneType  : AdminPageBase // System.Web.UI.Page
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
        /// 分頁 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 绑定父栏目
        /// </summary>
        /// <param name="str"></param>
        private void BindData()
        {
            bind_repeater(produceTypeBLL.GetList(" ParentID=0"), Repeater2, "", span1, AspNetPager1);
        }

        /// <summary>
        /// 添加父栏目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPriduceType.Text))
            {
                MessageBox.Show(this, "请输入一级分类名");
                return;
            }
            else
            {
                string Name = this.txtPriduceType.Text;
                int ParentID = 0;
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
        /// 删除，修改
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string name = e.CommandName.ToString();
            int id = Convert.ToInt32(e.CommandArgument);
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
                    int p2 = produceTypeBLL.GetModelList(" parentid=" + id).Count;
                    if (p2 > 0 )
                    {
                        MessageBox.Show(this, "请先删除此类别下的二级类别！");
                        return;
                    }
                    else if (produceTypeBLL.DeleteForHide(id))
                    {
                        MessageBox.Show(this, "删除成功！");
                    }
                }
            }
            if (name == "Update")//修改
            {
                TextBox txt_des = (TextBox)e.Item.FindControl("txtTypeName");//一级分类
                if (string.IsNullOrEmpty(txt_des.Text))
                {
                    MessageBox.Show(this, "请输入一级分类名");
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