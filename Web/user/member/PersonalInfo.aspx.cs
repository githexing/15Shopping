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

namespace Web.user.member
{
    public partial class PersonalInfo : PageCore
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
                //if (LoginUser.User005 == "1")
                //{
                //    btnSubmit.Visible = false;
                //}
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
            var banklist = new lgk.BLL.tb_bankName().GetModelList("");

            ListItem item_list = new ListItem();
            item_list.Value = "0";
            item_list.Text = GetLanguage("PleaseSselect");//"-请选择-"
            this.dropBank.Items.Add(item_list);
            foreach (var item in banklist)
            {
                ListItem item_list1 = new ListItem();
                item_list1.Value = item.ID.ToString();
                item_list1.Text = item.BankName;
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
                txtBankBranch.Disabled = false;
                txtBankAccount.Disabled = false;
                txtBankAccountUser.Disabled = false;
                txtUserCode.Disabled = false;
                txtNiceName.Disabled = false;
                txtAlipay.Disabled = false;
                txtPhoneNum.Disabled = false;
            
            }
            if(userInfo != null)
            {
                txtRecommendCode.Value = userInfo.RecommendCode;
                //var agent = agentBLL.GetModel(userInfo.AgentsID);
                //LiteralAgent.Text = agent != null ? agent.AgentCode : string.Empty;
                //this.dropProvince.SelectedItem.Text = userInfo.BankInProvince;
                //city.Value = userInfo.BankInCity;
                //if (!string.IsNullOrEmpty(userInfo.User009))
                //{
                //    this.dropQuestion.SelectedItem.Text = userInfo.User009;
                //}
                //txtAnswer.Text = userInfo.User010;

                // txtBankAccountUser.Disabled = !string.IsNullOrEmpty(userInfo.BankAccountUser);

                txtPhoneNum.Disabled = true;
                IdenCode.Value = userInfo.IdenCode;
                txtNiceName.Value = userInfo.NiceName;
                txtAlipay.Value = userInfo.User010;
                txtBankBranch.Value = userInfo.BankBranch;
                txtBankAccount.Value = userInfo.BankAccount;
                txtBankAccountUser.Value = userInfo.BankAccountUser;
                txtPhoneNum.Value = userInfo.PhoneNum;
                //dropBank.Text = userInfo.BankName;
                //dropProvince.SelectedIndex = dropProvince.Items.IndexOf(dropProvince.Items.FindByText(userInfo.BankInProvince)) ;
                txtUserCode.Value = userInfo.UserCode;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (LoginUser.User005 == "1") return;

            if (RegValidate())
            {
                lgk.Model.tb_user m_user = userBLL.GetModel(GetUserID());

                m_user.BankAccount = this.txtBankAccount.Value.Trim();// "銀行賬號";
                //if (string.IsNullOrEmpty(m_user.BankAccountUser))
                m_user.BankAccountUser = this.txtBankAccountUser.Value.Trim();// "開户姓名";
                m_user.BankName = this.dropBank.SelectedValue;// "開户銀行";
                m_user.BankBranch = this.txtBankBranch.Value.Trim();// "支行名稱";
                m_user.BankInProvince = dropProvince.SelectedItem.Text;// "銀行所在省份";
                //m_user.BankInCity = city.Value;// "銀行所在城市";

                m_user.NiceName = this.txtNiceName.Value.Trim();// "姓名";
                //m_user.TrueName = this.txtTrueName.Value.Trim();// "姓名";
                //m_user.IdenCode = this.txtIdenCode.Text.Trim();// "身份证號";
                //m_user.PhoneNum = this.txtPhoneNum.Value;// "手机號碼";
                //m_user.QQnumer =txtQQnumer.Value.Trim();//QQ
                //m_user.Email = txtEmail.Text.Trim();//电子邮箱
                //m_user.Address = txtAddress.Value;//聯系地址
                m_user.User010 = txtAlipay.Value.Trim(); //支付宝

                //m_user.User005 = "1";
                if (userBLL.Update(m_user))
                {
                    #region 日志
                    string ip = Page.Request.UserHostAddress;

                    lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
                    lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
                    log.LogMsg = "";
                    log.LogType = 5;//修改资料
                    log.LogLeve = 0;//
                    log.LogDate = DateTime.Now;
                    log.LogCode = "修改资料";//订单编号
                    log.IsDeleted = 0;
                    log.Log1 = m_user.UserID.ToString();//用户UserID
                    log.Log2 = ip;// 
                    log.Log3 = "";
                    log.Log4 = "";
                    syslogBLL.Add(log); 
                    #endregion
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Modifications") + "');window.location.href='PersonalInfo.aspx'", true);//修改资料成功

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("FailedModify") + "');", true);//修改资料失败
                }
                
            }
        }
        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        protected bool RegValidate()
        {

            if (this.dropBank.SelectedValue != "0")
            {

                if (this.dropProvince.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Banklocation") + "');", true);//请选择银行所在地
                    return false;
                }
                if (this.txtBankBranch.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("BankIsNull") + "');", true);//银行支行不能为空
                    return false;
                }
                if (this.txtBankAccount.Value != "")
                {
                    if (!PageValidate.RegexTrueBank(this.txtBankAccount.Value))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("BankCardErrors") + "');", true);//银行卡号输入错误
                        return false;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("BankCardIsNull") + "');", true);//银行卡号不能为空
                    return false;
                }
                if (this.txtBankAccountUser.Value.Trim() != "")
                {

                    if (!PageValidate.RegexTrueName(txtBankAccountUser.Value.Trim()))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NameMust") + "');", true);//开户名必须为2-30个中英文
                        return false;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NameIsNull") + "');", true);//开户名不能为空
                    return false;
                }
            }
            //if (this.txtTrueName.Value.Trim() != "")
            //{
            //    if (!PageValidate.RegexTrueName(txtTrueName.Value.Trim()))
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AccountMust") + "');", true);//姓名必须为2-30个中英文
            //        return false;
            //    }
            //}
            //string email = this.txtEmail.Text.Trim();
            //if (email != "")
            //{
            //    if (!PageValidate.IsEmail(email))
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Email格式不正确!');", true);//E-Mail格式不正确
            //        return false;
            //    }
            //}

            if (this.txtNiceName.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('昵称不能为空!');", true);
                return false;
            }
            if (this.txtSecondPassword.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Pleasepassword") + "');", true); 
                return false;
            }
            if (PageValidate.GetMd5(this.txtSecondPassword.Value.Trim()) != LoginUser.SecondPassword)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PasswordError") + "');", true);
                return false;
            }
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

            //string IdenCode = this.txtIdenCode.Text.Trim();
            //if (IdenCode == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("CardIDIsNull") + "');", true);//身份证号不能为空
            //    return false;
            //}
            //if (IdenCode != "")
            //{
            //    if (!PageValidate.RegexIden(IdenCode))
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("CardIDMust") + "');", true);//身份证号格式错误
            //        return false;
            //    }

            //}
            //if (this.txtQQnumer.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('QQ不能为空！');", true);//联系地址不能为空
            //    return false;
            //}
            //if (this.txtAddress.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AddressIsnull") + "');", true);//联系地址不能为空
            //    return false;
            //}
            //if (this.txtYouBian.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('邮编号码不能为空!');", true);
            //    return false;
            //}
            return true;
        }

        protected void txtBankAccount_TextChanged(object sender, EventArgs e)
        {
            //int BankAccount = userBLL.GetCount("BankAccount='" + txtBankAccount.Text + "'");
            //if (BankAccount > 0)
            //{
            //    btnSubmit.Visible = false;
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行卡已被绑定，请重新选择银行卡');", true);//银行卡已被绑定，请重新选择银行卡
                
            //}else
            //{
            //    btnSubmit.Visible = true;
            //}
        }

        protected void txtIdenCode_TextChanged(object sender, EventArgs e)
        {
            //int iIdenCode = userBLL.GetCount("IdenCode='" + txtIdenCode.Text.Trim() + "'");
            //if (iIdenCode > 0)
            //{
            //    btnSubmit.Visible = false;
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("IdenCodeReg") + "');", true);//身份证号已被注册
                
            //}else
            //{
            //    btnSubmit.Visible = true;
            //}
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            //string email = this.txtEmail.Text.Trim();
          
            //if (email != "")
            //{
            //    int emailnum = userBLL.GetCount(" Email='" + email + "'");
            //    if (emailnum > 0)
            //    {
            //        btnSubmit.Visible = false;
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('此Email已被注册！');", true);//
                    
            //    }
            //    else
            //    {
            //        btnSubmit.Visible = true;
            //    }
            //}
        }

      

        //protected void dropProvince_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bind_DropDownList(DropDownList1, cityBLL.GetList(" father="+ dropProvince.SelectedValue).Tables[0], "cityID", "city"); //銀行省份
        //}

        //  protected void ddlQuestion_SelectedIndexChanged(object sender, EventArgs e)
        //   {
        //    this.txtAnswer.Text = "";
        //  }
    }
}
