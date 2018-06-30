using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library;
using System.Text.RegularExpressions;

namespace Web.admin.team
{
    public partial class PersonalInfos : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //spd.jumpUrl1(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindBank();
                //BindQuestion();

                ShowData();
                btnSubmit.Text = GetLanguage("Submit");//提交

            }
        }

        //public void BindDdl()
        //{
        //    ddlQuestion.Items.Add(new ListItem(GetLanguage("PleaseSselect"), "0"));
        //    ddlQuestion.Items.Add(new ListItem(GetLanguage("YourNameIs"), "1"));
        //    ddlQuestion.Items.Add(new ListItem(GetLanguage("YourHome"), "2"));
        //    ddlQuestion.Items.Add(new ListItem(GetLanguage("YourPeople"), "3"));
        //}

        /// <summary>
        /// 绑定銀行
        /// </summary>
        private void BindBank()
        {
            #region 绑定银行所在地
            if (Language == "zh-cn")
            {
                bind_DropDownList(dropProvince, provinceBLL.GetList("").Tables[0], "provinceID", "province"); //銀行省份
            }
            else
            {
                bind_DropDownList(dropProvince, provinceBLL.GetList("").Tables[0], "provinceID", "provinceen"); //銀行省份
            }
            #endregion

            #region 绑定银行
            string strBankName = new lgk.BLL.tb_bankName().GetModel(1).BankName;
            string[] s = strBankName.Split('|');

            dropBank.Items.Clear();
            strBankName = s[0];
            if (s.Length < 2)
            {
                return;
            }
            if (currentCulture == "en-us")
            {
                strBankName = s[1];
            }
            string[] a = strBankName.Split(',');
            ListItem item_list = new ListItem();
            item_list.Value = "0";
            item_list.Text = GetLanguage("PleaseSselect");//"-请选择-"
            this.dropBank.Items.Add(item_list);
            foreach (string b in a)
            {
                ListItem item_list1 = new ListItem();
                item_list1.Value = b;
                item_list1.Text = b;
                this.dropBank.Items.Add(item_list1);
            }
            #endregion
        }

        private long GetUserID()
        {
            if (Request.QueryString["UserID"] != null)
            {
                return Convert.ToInt64(Request.QueryString["UserID"]);
            }
            else
            {
                return getLoginID();
            }
        }

        /// <summary>
        /// 绑定會員信息
        /// </summary>
        private void ShowData()
        {
            lgk.Model.tb_user userInfo = userBLL.GetModel(GetUserID());

            if (Request.QueryString["UserID"] != null)
            {
                dropBank.Enabled = false;
                dropProvince.Enabled = false;
                txtBankBranch.Disabled = true;
                txtBankAccount.Disabled = true;
                txtBankAccountUser.Disabled = true;
                txtTrueName.Disabled = true;
                txtAddress.Disabled = true;
                btnSubmit.Visible = false;
            }
            LiteralRecommendCode.Text = userInfo.RecommendCode;
            var agent = agentBLL.GetModel(userInfo.AgentsID);
            LiteralAgent.Text = agent != null ? agent.AgentCode : string.Empty;
            this.dropProvince.SelectedItem.Text = userInfo.BankInProvince;
            //if (!string.IsNullOrEmpty(userInfo.User009))
            //{
            //    this.dropQuestion.SelectedItem.Text = userInfo.User009;
            //}
            //txtAnswer.Text = userInfo.User010;

            this.txtAddress.Value = userInfo.Address;

            txtBankBranch.Value = userInfo.BankBranch;
            txtBankAccount.Value = userInfo.BankAccount;
            txtBankAccountUser.Value = userInfo.BankAccountUser;
            txtTrueName.Value = userInfo.TrueName;
            LiteralIdenCode.Text = userInfo.IdenCode;
            LiteralPhoneNum.Text = userInfo.PhoneNum;
            txtAddress.Value = userInfo.Address;
            dropBank.SelectedValue = userInfo.BankName;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (RegValidate())
            {
                lgk.Model.tb_user m_user = LoginUser;
                if (GetUserID() > 0)
                {
                    m_user = userBLL.GetModel(GetUserID());
                }
                m_user.BankAccount = this.txtBankAccount.Value.Trim();// "銀行賬號";
                m_user.BankAccountUser = this.txtBankAccountUser.Value.Trim();// "開户姓名";
                m_user.BankName = this.dropBank.SelectedValue;// "開户銀行";
                m_user.BankBranch = this.txtBankBranch.Value.Trim();// "支行名稱";
                m_user.BankInProvince = dropProvince.SelectedItem.Text;// "銀行所在省份";
                //m_user.BankInCity = DropDownList1.SelectedItem.Text;// "銀行所在城市";

                m_user.NiceName = string.Empty;//this.txtNickName.Value.Trim();// "姓名";
                m_user.TrueName = this.txtTrueName.Value.Trim();// "姓名";
                //m_user.IdenCode = this.txtIdenCode.Value.Trim();// "身份证號";
                //m_user.PhoneNum = this.txtPhoneNum.Value;// "手机號碼";
                //m_user.QQnumer =txtQQnumer.Value.Trim();//QQ
                //m_user.User005 = txtEmail.Value.Trim();//电子邮箱
                //m_user.SafetyCodeQuestion = DropDownList4.SelectedItem.Text;
                //m_user.SafetyCodeAnswer = DropDownList5.SelectedItem.Text;
                m_user.Address = txtAddress.Value;//聯系地址
                //m_user.User009 = ddlQuestion.SelectedItem.Text;//密保问题
                //m_user.User010 =txtAnswer.Text.Trim();//密保答案
                if (userBLL.Update(m_user))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Modifications") + "');", true);//修改资料成功
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("FailedModify") + "');", true);//修改资料失败
                }
                ShowData();
            }
        }
        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        protected bool RegValidate()
        {

            if (this.dropBank.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseSelectBank") + "');", true);//请选择开户银行
                return false;
            }
            if (this.dropProvince.SelectedValue == "请选择")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Banklocation") + "');", true);//请选择银行所在地
                return false;
            }
            if (this.txtBankBranch.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("BankIsNull") + "');", true);//银行支行不能为空
                return false;
            }
            if (this.txtBankAccount.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("BankCardIsNull") + "');", true);//银行卡号不能为空
                return false;
            }
            if (!PageValidate.RegexTrueBank(this.txtBankAccount.Value))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("BankCardErrors") + "');", true);//银行卡号输入错误
                return false;
            }
            if (this.txtBankAccountUser.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NameIsNull") + "');", true);//开户名不能为空
                return false;
            }
            if (!PageValidate.RegexTrueName(txtBankAccountUser.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NameMust") + "');", true);//开户名必须为2-30个中英文
                return false;
            }

            if (this.txtTrueName.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AccountIsNull") + "');", true);//姓名不能为空
                return false;
            }
            if (!PageValidate.RegexTrueName(txtTrueName.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AccountMust") + "');", true);//姓名必须为2-30个中英文
                return false;
            }

            //if (this.txtNickName.Value.Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('昵称不能为空!');", true);
            //    return false;
            //}
            //if (ddlQuestion.SelectedValue.Trim() == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseSelectQuestion") + "');", true);//请选择密保问题
            //    return false;
            //}
            //if(string.IsNullOrEmpty(txtAnswer.Text))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseAnswer") + "');", true);//请输入密保答案
            //    return false;
            //}
            //if (this.DropDownList5.SelectedValue == "请选择")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择地址所在地!');", true);
            //    return false;
            //}
            //string email = this.txtEmail.Value.Trim();
            //if (email == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Email不能为空！');", true);//
            //    return false;
            //}
            //int emailnum = userBLL.GetCount(" Email='" + email + "'");
            //if (emailnum > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('此Email已被注册！');", true);//
            //    return false;
            //}

            //if (this.txtQQnumer.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('QQ不能为空！');", true);//联系地址不能为空
            //    return false;
            //}
            if (this.txtAddress.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AddressIsnull") + "');", true);//联系地址不能为空
                return false;
            }
            //if (this.txtYouBian.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('邮编号码不能为空!');", true);
            //    return false;
            //}
            return true;
        }

        //  protected void ddlQuestion_SelectedIndexChanged(object sender, EventArgs e)
        //   {
        //    this.txtAnswer.Text = "";
        //  }
    }
}