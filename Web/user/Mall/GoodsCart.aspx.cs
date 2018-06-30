using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Mall
{
    public partial class GoodsCart : PageCore
    {
        IList<lgk.Model.tb_goodsCar> listCar = new List<lgk.Model.tb_goodsCar>();//购物车集合

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (getLoginID() > 0)
                {
                    bind_DropDownList_ht(ddlType, produceTypeBLL.GetList("ParentID=0 ").Tables[0], "ID", "TypeName"); //一级类目
                    BindAddress();
                    BindData(ddlType.SelectedValue);
                    GG();
                }
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData(string s)
        {
            long iUserID = getLoginID();
            hduid.Value = iUserID.ToString();

            long addrid = addressBLL.GetAddressID(" UserID="+getLoginID()+ " and Address01='1' ");
            if (addrid > 0)
            {
                lgk.Model.tb_Address addrModel = addressBLL.GetModel(addrid);
                if (addrModel != null)
                {
                    dropAddress.SelectedValue = addrid.ToString();
                    lbAddess.Text = addrModel.Address;
                }
            }
            
            DataSet ds = goodsCarBLL.GetList("BuyUser=" + iUserID + " and TypeID="+ s);
            int iHdd = ds.Tables[0].Rows.Count;
            hdVlaue.Value = iHdd.ToString();
            if (iHdd >= 0)
            {
                RepeaterCar.DataSource = ds;
                RepeaterCar.DataBind();
            }
        }

        public void BindAddress()
        {
            IList<lgk.Model.tb_Address> list = new lgk.BLL.tb_Address().GetModelList(" UserID="+getLoginID()+"");
            dropAddress.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            dropAddress.Items.Add(li);
            foreach (lgk.Model.tb_Address item in list)
            {
                ListItem items = new ListItem();
                items.Value = item.ID.ToString();
                items.Text = item.PhoneNum+" "+ item.MemberName;
                dropAddress.Items.Add(items);
            } 
        }
        private void GG()
        { 
            IList<lgk.Model.tb_agent1> list = new lgk.BLL.tb_agent1().GetModelList("");
            DropDownList2.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            DropDownList2.Items.Add(li);
            foreach (lgk.Model.tb_agent1 item in list)
            {
                ListItem items = new ListItem();
                items.Value = userBLL.GetUserID(item.AgentCode).ToString();
                items.Text = item.AgentCode;
                DropDownList2.Items.Add(items);
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long iID = Convert.ToInt64(e.CommandArgument);
            lgk.Model.tb_goodsCar gCarModel = goodsCarBLL.GetModel(iID);
            string tag = e.CommandName;
            if (tag.Equals("del"))
            {
                if (gCarModel != null)
                {
                    if (goodsCarBLL.Delete(gCarModel.ID))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除成功！');", true);
                        BindData(ddlType.SelectedValue);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除失败！');", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已删除！');", true);
                    return;
                }
            }
        }

        protected void dropAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            int addrid = Convert.ToInt32(dropAddress.SelectedValue);
            if (addrid > 0)
            {
                lgk.Model.tb_Address addrModel = addressBLL.GetModel(addrid);
                if(addrModel!= null)
                {
                    lbAddess.Text = addrModel.Address;
                }
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData(ddlType.SelectedValue);
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var agent1 = agent1BLL.GetModel(int.Parse(DropDownList2.SelectedValue));
            if (agent1!=null)
            {
                Label1.Text = "详细地址：" + agent1.AgentAddress + " 手机号码："+agent1.PicLink;
                return;
            }

            Label1.Text = "";

        }
    }
}