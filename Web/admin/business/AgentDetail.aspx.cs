/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-7-19 16:53:47 
 * 文 件 名：		AgentDetail.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.admin.business
{
    public partial class AgentDetail : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                bind_DropDownList(DropDownList4, provinceBLL.GetList("").Tables[0], "provinceID", "province"); //地址省份
                if (getIntRequest("agentid") != 0) { bind(); }
            }
        }

        private void bind()
        {
            Button3.Visible = false;
            txtAddress.Disabled = true;
            DropDownList4.Enabled = false;
            DropDownList5.Enabled = false;
            tr2.Visible = false;
            RadioButtonList1.Enabled = false;
            txtAgentCode.Disabled = true;
            txtCode.Disabled = true;
            lgk.Model.tb_agent model = agentBLL.GetModel(getIntRequest("agentid"));
            if (model.Flag == 0) { tr1.Visible = true; }
            txtAgentCode.Value = model.AgentCode;
            RadioButtonList1.Items[model.AgentType - 1].Selected = true;
            txtCode.Value = model.Agent003;
            img2.Src = "../../Upload/" + model.PicLink;
            this.example1.HRef = "../../Upload/" + model.PicLink;
            if (model.AgentType == 2)
            {
                this.DropDownList4.SelectedItem.Text = model.AgentInProvince;
                ListItem lt1 = new ListItem();
                lt1.Value = model.AgentInCity;
                lt1.Text = model.AgentInCity;
                this.DropDownList5.Items.Add(lt1);
                this.DropDownList5.SelectedValue = model.AgentInCity;
                txtAddress.Value = model.AgentAddress;
                Div1.Visible = true;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string upload = UpLoadFile("");
            ViewState["urlname1"] = upload;
            img2.Src = "../../Upload/" + upload;
            this.example1.HRef = "../../Upload/" + upload;
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        private string UpLoadFile(string pName)
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
        /// 选择申请类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "1") { Div1.Visible = false; } else { Div1.Visible = true; }
        }
        /// <summary>
        /// 地址省市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DropDownList4.SelectedValue != "0")
            {
                bind_DropDownList(this.DropDownList5, new lgk.BLL.tb_city().GetList("father='" + DropDownList4.SelectedValue + "'").Tables[0], "city", "city");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            //if (txtAgentCode.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入服务中心编号!');", true);
            //    return;
            //}
            //if (agentBLL.GetModel(" AgentCode='" + txtAgentCode.Value.Trim() + "'") != null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该服务中心编号已存在!');", true);
            //    return;
            //}
            //lgk.Model.tb_agent model = new lgk.Model.tb_agent();
            //model.AgentCode = txtAgentCode.Value.Trim();
            //model.Flag = 0;
            //model.UserID = getLoginID();
            //model.AgentType = Convert.ToInt32(RadioButtonList1.SelectedValue);
            //model.AppliTime = DateTime.Now;
            //if (agentBLL.GetModel(" Agent003='" + txtCode.Value.Trim() + "'") != null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该营业执照已存在!');", true);
            //    return;
            //}
            //model.Agent003 = txtCode.Value.Trim();
            //string upload1 = "";
            //if (ViewState["urlname1"] != null)
            //{
            //    upload1 = ViewState["urlname1"].ToString();
            //}
            //if (upload1 == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请上传营业执照图片！')", true);
            //    return;
            //}
            //if (upload1 != "")
            //{
            //    upload1 = upload1.Substring(upload1.LastIndexOf("/") + 1, upload1.Length - upload1.LastIndexOf("/") - 1);
            //}
            //model.PicLink = upload1;
            //if (LoginUser.LevelID == 5)
            //{
            //    if (agentBLL.GetModel(" AgentAddress='" + txtAddress.Value.Trim() + "'") != null)
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该县已存在专卖店，无法再申请成为专卖店!');", true);
            //        return;
            //    }
            //    model.AgentInProvince = DropDownList4.SelectedItem.Text;
            //    model.AgentInCity = DropDownList5.SelectedItem.Text;
            //    model.AgentAddress = txtAddress.Value.Trim();
            //}
            //if (agentBLL.Add(model) > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('申请成功!');window.location.href='Agent.aspx'", true);
            //}
            //else { ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('申请失败！')", true); }
        }
    }
}
