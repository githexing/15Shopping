using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Text.RegularExpressions;

namespace Web.user.team
{
    public partial class UpdateUser : PageCore
    {
        public int levelID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlBankName();
                bind_DropDownList(DropDownList3, provinceBLL.GetList("").Tables[0], "provinceID", "province"); //銀行省份
                //bind_DropDownList(DropDownList4, info_province.GetList("").Tables[0], "provinceID", "province"); //銀行省份
                bind_member();
            }
        }
        private int getID()
        {
            if (Request.QueryString["UserID"] != null)
            {
                return Convert.ToInt32(Request.QueryString["UserID"]);
            }
            return 0;
        }

        /// <summary>
        /// 绑定银行
        /// </summary>
        private void ddlBankName()
        {
            string strbandname = new lgk.BLL.tb_bankName().GetModel(1).BankName;
            string[] a = strbandname.Split('，');
            ddlBank.Items.Clear();
            foreach (string b in a)
            {
                ListItem item_list1 = new ListItem();
                item_list1.Value = b;
                item_list1.Text = b;
                this.ddlBank.Items.Add(item_list1);
            }
        }

        /// <summary>
        /// 选择省，加载市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.DropDownList3.SelectedValue != "0")
        //    {
        //        bind_DropDownList(this.DropDownList1, new lgk.BLL.tb_city().GetList("father='" + DropDownList3.SelectedValue + "'").Tables[0], "city", "city");
        //    }
        //}
        ///// <summary>
        ///// 选择省，加载市
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.DropDownList4.SelectedValue != "0")
        //    {
        //        bind_DropDownList(this.DropDownList5, new lgk.BLL.tb_city().GetList("father='" + DropDownList4.SelectedValue + "'").Tables[0], "city", "city");
        //    }
        //}
        /// <summary>
        /// 绑定會員信息
        /// </summary>
        private void bind_member()
        {
            lgk.Model.tb_user model = userBLL.GetModel(getID());
            txtUserCode.Value = model.UserCode;
            txtPassword.Value = "******";
            txtSecondPassword.Value = "******"; 
            txtThreePassword.Value = "******";
            txtLevel.Value = levelBLL.GetModel(Convert.ToInt32(model.LevelID)).LevelName;
            txtRegMoney.Value = model.RegMoney.ToString();
            txtRecommendCode.Value = model.RecommendCode;
            txtParentCode.Value = model.ParentCode;
            var data=agentBLL.GetModel(model.AgentsID);
            txtAgentCode.Value = data != null ? data.AgentCode : "";
            if (model.Location == 1) { Radio1.Checked = true; } else { Radio2.Checked = true; }
            this.DropDownList3.SelectedItem.Text = model.BankInProvince;
            ListItem lt = new ListItem();
            lt.Value = model.BankInCity;
            lt.Text = model.BankInCity;
            //this.DropDownList1.Items.Add(lt);
            //this.DropDownList1.SelectedValue = model.BankInCity;

            //this.DropDownList4.SelectedItem.Text = model.SafetyCodeQuestion;
            //ListItem lt1 = new ListItem();
            //lt1.Value = model.SafetyCodeAnswer;
            //lt1.Text = model.SafetyCodeAnswer;
            //this.DropDownList5.Items.Add(lt1);
            //this.DropDownList5.SelectedValue = model.SafetyCodeAnswer;

            txtBankBranch.Value = model.BankBranch;
            txtBankAccount.Value = model.BankAccount;
            txtBankAccountUser.Value = model.BankAccountUser;
            txtTrueName.Value = model.TrueName;
            txtIdenCode.Value = model.IdenCode;
            txtPhoneNum.Value = model.PhoneNum;
            txtAddress.Value = model.Address;
            txtNickName.Value = model.NiceName;
            ddlBank.SelectedValue = model.BankName;
            levelID = model.LevelID;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (RegValidate())
            {
                lgk.Model.tb_user m_user = userBLL.GetModel(getID());
                m_user.BankAccount = this.txtBankAccount.Value.Trim();// "銀行賬號";
                m_user.BankAccountUser = this.txtBankAccountUser.Value.Trim();// "開户姓名";
                m_user.BankName = this.ddlBank.SelectedValue;// "開户銀行";
                m_user.BankBranch = this.txtBankBranch.Value.Trim();// "支行名稱";
                m_user.BankInProvince = DropDownList3.SelectedItem.Text;// "銀行所在省份";
                //m_user.BankInCity = DropDownList1.SelectedItem.Text;// "銀行所在城市";

                m_user.NiceName = this.txtNickName.Value.Trim();// "姓名";
                m_user.TrueName = this.txtTrueName.Value.Trim();// "姓名";
                m_user.IdenCode = this.txtIdenCode.Value.Trim();// "身份证號";
                m_user.PhoneNum = this.txtPhoneNum.Value;// "手机號碼";
                //m_user.SafetyCodeQuestion = DropDownList4.SelectedItem.Text;
                //m_user.SafetyCodeAnswer = DropDownList5.SelectedItem.Text;
                m_user.Address = txtAddress.Value;//聯系地址
                m_user.User005 = "";//txtEmail.Value;//郵編號碼

                if (userBLL.Update(m_user))
                {
                    MessageBox.MyShow(this, "修改资料成功!");
                }
                else
                {
                    MessageBox.MyShow(this, "修改资料失败!");
                }
                bind_member();
            }
        }
        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        protected bool RegValidate()
        {
            string trueName = this.txtTrueName.Value.Trim();
            if (trueName == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('姓名不能为空!');", true);
                return false;
            }
            if (!PageValidate.RegexTrueName(trueName))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('姓名必须为2-30个中文!');", true);
                return false;
            }

            if (this.txtNickName.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('昵称不能为空!');", true);
                return false;
            }

            string IdenCode = this.txtIdenCode.Value.Trim();
            if (IdenCode == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('身份证号不能为空!');", true);
                return false;
            }
            if (!PageValidate.RegexIden(IdenCode))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('身份证号格式错误!');", true);
                return false;
            }

            var phoneNum = this.txtPhoneNum.Value.Trim();
            if (phoneNum == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('手机号不能为空!');", true);
                return false;
            }
            if (!PageValidate.RegexPhone(phoneNum))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('手机号格式错误!');", true);
                return false;
            }

            if (string.IsNullOrEmpty(ddlBank.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择开户银行!');", true);
                return false;
            }
            if (string.IsNullOrEmpty(DropDownList3.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择省份!');", true);
                return false;
            }
            if (this.txtBankBranch.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行支行不能为空!');", true);
                return false;
            }
            if (this.txtBankAccount.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行卡号不能为空!');", true);
                return false;
            }

            if (!PageValidate.RegexTrueBank(this.txtBankAccount.Value))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行卡号输入错误!');", true);
                return false;
            }
            if (this.txtBankAccountUser.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('开户名不能为空!');", true);
                return false;
            }
            if (!PageValidate.RegexTrueName(txtBankAccountUser.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('开户名必须为2-30个中文!');", true);
                return false;
            }

            return true;
        }
    }
}