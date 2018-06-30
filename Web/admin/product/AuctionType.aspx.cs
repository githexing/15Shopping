using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.admin.product
{
    public partial class AuctionType : AdminPageBase
    {
        public lgk.Model.tb_Salesroom model{ get;set;}
        public int SaId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 46, getLoginID());//权限
            if (!IsPostBack)
            {
                SaId = ConvertToInt(Request.QueryString["id"]);//排场ID
                model = tb_SalesroomBll.GetModel(SaId);
                if (model.SaJinpaiSate == 0)
                {
                    DivZi.Visible = true;
                    DivShou.Visible = false;
                    this.rdoZi.Checked = true;
                    this.rdoShou.Checked = false;
                }
                if (model.SaJinpaiSate == 1)
                {
                    DivZi.Visible = false;
                    DivShou.Visible = true;
                    this.rdoZi.Checked = false;
                    this.rdoShou.Checked = true;
                }
                if (model.SuccessUserID != 0 && model.SuccessUserID != null)
                {
                    txtCode.Value = userBLL.GetModel(" UserID='" + model.SuccessUserID + "'").UserCode;
                }
                txtStar.Text = model.RegTime1 == null ? "" :  Convert.ToDateTime(model.RegTime1).ToString("yyyy-MM-dd");
                txtEnd.Text = model.RegTime2 == null ? "" : Convert.ToDateTime(model.RegTime2).ToString("yyyy-MM-dd");
                bind();
            }
        }
        /// <summary>
        /// 手动竞拍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DivZi.Visible = false;
            DivShou.Visible = true;
            this.rdoZi.Checked = false;
            bind();
        }
        /// <summary>
        /// 自动竞拍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DivZi.Visible = true;
            DivShou.Visible = false;
            this.rdoShou.Checked = false;
            SaId = ConvertToInt(Request.QueryString["id"]);//排场ID
            model = tb_SalesroomBll.GetModel(SaId);
            if (model.SaJinpaiSate == 1) 
            {
                this.txtStar.Text = "";
                this.txtEnd.Text = "";
            }
            bind();
        }
        void bind() 
        {
            SaId = ConvertToInt(Request.QueryString["id"]);//拍场ID
            if (this.rdoShou.Checked)
            {
                //rptUser.Visible = false;
                //rptProduct.Visible = true;
                bind_repeater(tb_SalesroomBll.GetListUser(" SaId=" + SaId + " and SuccessUserID!=0"), rptProduct, "", tr1, AspNetPager1);
            }
            else if (this.rdoZi.Checked) 
            {
                //rptUser.Visible = true;
                //rptProduct.Visible = false;
                string str = string.Format(" Convert(nvarchar(10),OpenTime,120)  between '" + this.txtStar.Text + "' and '" + this.txtEnd.Text + "'");
                bind_repeater(userBLL.GetList(str), rptProduct, "", tr1, AspNetPager1);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
        /// <summary>
        /// 手动提交竞拍会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChuSearch_Click(object sender, EventArgs e)
        {
            if (txtCode.Value != null)
            {
                string userCode = this.txtCode.Value.ToString();
                lgk.Model.tb_user user = userBLL.GetModel(" userCode='" + userCode+"'");
                SaId = ConvertToInt(Request.QueryString["id"]);
                if (user!=null)
                {
                    model = tb_SalesroomBll.GetModel(SaId);
                    model.SaJinpaiSate = 1;
                    model.SuccessUserID = (int)user.UserID;
                    if (user.BonusAccount < (model.SaPrUsually)) 
                    {
                        MessageBox.Show(this, "该会员奖金币余额不足！");
                        return;
                    }
                    if (tb_SalesroomBll.Update(model))
                    {
                        //user.BonusAccount = user.BonusAccount - 1;
                        //user.StockAccount =user.StockAccount+1;
                        //userBLL.Update(user);
                        MessageBox.Show(this, "设置成功");
                        bind();
                    }
                    else 
                    {
                        MessageBox.Show(this, "设置失败");
                    }
                }
                else 
                {
                    MessageBox.Show(this, "该会员编号无效");
                    return;
                }
            }
            else 
            {
                MessageBox.Show(this,"请输入会员编号");
                return;
            }
        }
        /// <summary>
        /// 自动竞拍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_s2_Click(object sender, EventArgs e)
        {
            if (txtStar.Text != "" && txtEnd.Text != "")
            {
                SaId = ConvertToInt(Request.QueryString["id"]);
                model = tb_SalesroomBll.GetModel(SaId);
                model.SaJinpaiSate = 0;
                model.SuccessUserID = 0;
                model.RegTime1 = DateTime.Parse(txtStar.Text);
                model.RegTime2 = DateTime.Parse(txtEnd.Text);
                //this.MyExecProc(string.Format("exec proc_JinpaiKoubi '{0}','{1}','{2}'", model.RegTime1, model.RegTime2, model.SaPrUsually));
                if (tb_SalesroomBll.Update(model))
                {
                    
                    MessageBox.Show(this, "设置成功");
                    bind();
                }
                else
                {
                    MessageBox.Show(this, "设置失败");
                }
            }
            else
            {
                MessageBox.Show(this, "请输入激活时间");
                return;
            }
        }
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesroomList.aspx");
        }
    }
}