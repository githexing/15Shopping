/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-14 18:03:03 
 * 文 件 名：		UserDetail.cs 
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
using System.Text.RegularExpressions;

namespace Web.admin.business
{
    public partial class UserDetail : AdminPageBase//System.Web.UI.Page
    {
        public int levelID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            if (!IsPostBack)
            {
              //  BindBank();
                ShowInfo();
            }
        }
        private long getID()
        {
            if (Request.QueryString["UserID"] != null)
            {
                return Convert.ToInt64(Request.QueryString["UserID"]);
            }
            return 0;
        }

        /// <summary>
        /// 绑定银行
        /// </summary>
        private void BindBank()
        {
           // bind_DropDownList(dropProvince, provinceBLL.GetList("").Tables[0], "provinceID", "province"); //銀行省份

            #region 绑定银行
            //string strBankName = new lgk.BLL.tb_bankName().GetModel(1).BankName;
          
            //string[] a = strBankName.Split(',');
            //ListItem item_list = new ListItem();
            //item_list.Value = "0";
            //item_list.Text = GetLanguage("PleaseSselect");//"-请选择-"
            //this.dropBank.Items.Add(item_list);
            //foreach (string b in a)
            //{
            //    ListItem item_list1 = new ListItem();
            //    item_list1.Value = b;
            //    item_list1.Text = b;
            //    this.dropBank.Items.Add(item_list1);
            //}
            #endregion
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
        private void ShowInfo()
        {
            var  model = userBLL.GetModel(getID());
            //lgk.Model.tb_agent amodel = agentBLL.GetModel("UserID=" + model.UserID);
            if (model == null) return;
            //{
                //dropBank.Enabled = false;
                //dropProvince.Enabled = false;
                //DropDownList1.Enabled = false;
                //DropDownList4.Enabled = false;
                //DropDownList5.Enabled = false;
                //txtBankBranch.Disabled = true;
                //txtBankAccount.Disabled = true;
                //txtBankAccountUser.Disabled = true;
              //  txtTrueName.Disabled = true;
                //txtAddress.Disabled = true;
                //txtEmail.Disabled = true;
                //txtIdenCode.Disabled = true;
               // txtPhoneNum.Disabled = false;
                //txtQQnumer.Disabled = true;
              //  btnSubmit.Visible = false;
                //txtNickName.Disabled = true;
                //txtCaiCode.Disabled = true;
            //}
            txtUserCode.Value = model.UserCode;
            txtPassword.Value = "******";
            txtSecondPassword.Value = "******";
          //  txtThreePassword.Value = "******";
          //  var level = levelBLL.GetModel(Convert.ToInt32(model.LevelID));
         //   if (level != null)
          //      txtLevel.Value = level.LevelName;
          //  txtRegMoney.Value = model.RegMoney.ToString();
            txtRecommendCode.Value = model.RecommendCode;
          //  txtParentCode.Value = model.ParentCode;
        //    var agent = agentBLL.GetModel(model.AgentsID);
       //     txtAgentCode.Value = agent != null ? agent.AgentCode : string.Empty;
        //    if (model.Location == 1) { Radio1.Checked = true; } else { Radio2.Checked = true; }
            //if (model.User004 == 1) { rdHK.Checked = true; }
            //else if (model.User004 == 2) { rdZX.Checked = true; }
         //   this.dropProvince.SelectedItem.Text = model.BankInProvince;
            //if (!string.IsNullOrEmpty(model.User009))
            //{
            //    this.ddlQuestion.SelectedItem.Text = model.User009;
            //}
            //txtAnswer.Text = model.User010;
         //   this.txtAddress.Value = model.Address;
         //   ListItem lt = new ListItem();
          //  lt.Value = model.BankInCity;
          //  lt.Text = model.BankInCity;
            //this.DropDownList1.Items.Add(lt);
            //this.DropDownList1.SelectedValue = model.BankInCity;

            //this.DropDownList4.SelectedItem.Text = model.SafetyCodeQuestion;
            //ListItem lt1 = new ListItem();
            //lt1.Value = model.SafetyCodeAnswer;
            //lt1.Text = model.SafetyCodeAnswer;
            //this.DropDownList5.Items.Add(lt1);
            //this.DropDownList5.SelectedValue = model.SafetyCodeAnswer;
            //txtEmail.Value = model.Email;
            //txtQQnumer.Value = model.QQnumer;
            //txtBankBranch.Value = model.BankBranch;
            //txtBankAccount.Value = model.BankAccount;
            //txtBankAccountUser.Value = model.BankAccountUser;
           // txtTrueName.Value = model.TrueName;
            txtIdenCode.Value = model.IdenCode;
           // txtPhoneNum.Value = model.PhoneNum;
          //  txtAddress.Value = model.Address;
            txtNickName.Value = model.NiceName;
           // dropBank.SelectedValue = model.BankName;
           // txtAlipay.Value = model.User010; //支付宝
                                                     //this.txtCaiCode.Value = model.User007;
                                                     //this.txtCaiName.Value = model.User008;
                                                     //  levelID = model.LevelID;

            //if (model.LevelID > 4 && amodel.AgentInProvince.Trim() != "")
            //{
            //    txtArea.Visible = true;
            //    txtProvince.Value = amodel.AgentInProvince;
            //    txtCity.Value = amodel.AgentInCity;
            //    txtCountry.Value = amodel.AgentAddress;
            //}
            //else
            //{
            //    txtArea.Visible = false;
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (RegValidate())
            {
                var  m_user = userBLL.GetModel(getID());
                //  m_user.BankAccount = this.txtBankAccount.Value.Trim();// "銀行賬號";
                //   m_user.BankAccountUser = this.txtBankAccountUser.Value.Trim();// "開户姓名";
                //   m_user.BankName = this.dropBank.SelectedValue;// "開户銀行";
                //    m_user.BankBranch = this.txtBankBranch.Value.Trim();// "支行名稱";
                //   m_user.BankInProvince = dropProvince.SelectedItem.Text;// "銀行所在省份";
                // m_user.BankInCity = DropDownList1.SelectedItem.Text;// "銀行所在城市";
                if (m_user.UserCode!= this.txtUserCode.Value.Trim())
                {
                    var UserCode = this.txtUserCode.Value.Trim();
                    MySQL(string.Format(" update tb_user set RecommendCode = '"+ UserCode + "',ParentCode== '" + UserCode + "' where UserCode = '" + m_user.UserCode + "' "));//修改推荐人
                    MySQL(string.Format(" update tb_user set User006 = '" + UserCode + "' where UserCode = '" + m_user.UserCode + "' "));//修改服务中心
                    MySQL(string.Format(" update tb_agent set AgentCode = '" + UserCode + "' where UserCode = '" + m_user.UserCode + "' "));//修改报单中心数据
                  
                    m_user.UserCode = UserCode;
                }
            
                m_user.NiceName = this.txtNickName.Value.Trim();// "姓名";
                m_user.TrueName = this.txtTrueName.Value.Trim();// "姓名";
                m_user.IdenCode = this.txtIdenCode.Value.Trim();// "身份证號";
             //   m_user.PhoneNum = this.txtPhoneNum.Value;// "手机號碼";
             //   m_user.QQnumer = txtQQnumer.Value.Trim();//QQ
            //    m_user.Email = txtEmail.Value.Trim();//电子邮箱
                //m_user.SafetyCodeQuestion = DropDownList4.SelectedItem.Text;
                //m_user.SafetyCodeAnswer = DropDownList5.SelectedItem.Text;
             //   m_user.Address = txtAddress.Value;//聯系地址
              //  m_user.Email = txtEmail.Value;//郵編號碼
           //     m_user.User006 = txtQQnumer.Value;//QQ號碼
               // m_user.User010 = txtAlipay.Value.Trim(); //支付宝
                if (userBLL.Update(m_user))
                {
                    string ip = Page.Request.UserHostAddress;

                    lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
                    lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
                    log.LogMsg = "";
                    log.LogType = 11;//后台修改会员资料
                    log.LogLeve = 0;//
                    log.LogDate = DateTime.Now;
                    log.LogCode = "后台修改会员资料";//后台修改会员资料
                    log.IsDeleted = 0;
                    log.Log1 = LoginAdmin.UserName;//用户UserID
                    log.Log2 = ip;// 
                    log.Log3 = m_user.UserID.ToString();
                    log.Log4 = "";
                    syslogBLL.Add(log);

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改资料成功!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('修改资料失败!');", true);
                }
                ShowInfo();
            }
        }
        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        protected bool RegValidate()
        {

            //if (this.dropBank.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择开户银行!');", true);
            //    return false;
            //}
            //if (this.dropProvince.SelectedValue == "请选择")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择银行所在地!');", true);
            //    return false;
            //}
            //if (this.txtBankBranch.Value.Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行支行不能为空!');", true);
            //    return false;
            //}
            //if (this.txtBankAccount.Value.Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行卡号不能为空!');", true);
            //    return false;
            //}
            //if (!PageValidate.RegexTrueBank(this.txtBankAccount.Value))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('银行卡号输入错误!');", true);
            //    return false;
            //}
            //if (this.txtBankAccountUser.Value.Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('开户名不能为空!');", true);
            //    return false;
            //}
            //if (!PageValidate.RegexTrueName(txtBankAccountUser.Value.Trim()))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('开户名必须为2-30个中英文!');", true);
            //    return false;
            //}

            //if (this.txtTrueName.Value.Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('姓名不能为空!');", true);
            //    return false;
            //}
            //if (!PageValidate.RegexTrueName(txtTrueName.Value.Trim()))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('姓名必须为2-30个中英文!');", true);
            //    return false;
            //}

            //if (this.txtNickName.Value.Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('昵称不能为空!');", true);
            //    return false;
            //}
            //string email = this.txtEmail.Value.Trim();
            //if (email == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('Email不能为空!');", true);//
            //    return false;
            //}
            //int emailnum = userBLL.GetCount(" Email='" + email + "'");
            //if (emailnum > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('此Email已被注册!');", true);//
            //    return false;
            //}

            //if (this.txtQQnumer.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('QQ不能为空哦 !!');", true);//联系地址不能为空
            //    return false;
            //}
            if (this.txtIdenCode.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('身份证号不能为空!');", true);
                return false;
            }
            if (!PageValidate.RegexIden(txtIdenCode.Value.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('身份证号格式错误!');", true);
                return false;
            }

            //string phone = this.txtPhoneNum.Value.Trim();
            //if (string.IsNullOrEmpty(phone))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('手机号不能为空!');", true);
            //    return false;
            //}
            //if (!string.IsNullOrEmpty(phone) && !PageValidate.RegexPhone(phone))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('手机号格式错误!');", true);
            //    return false;
            //}
            //if (this.txtAddress.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('联系地址不能为空!');", true);
            //    return false;
            //}
            //if (ddlQuestion.SelectedValue.Trim() == "请选择")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择密保问题!');", true);
            //    return false;
            //}
            //if (string.IsNullOrEmpty(txtAnswer.Text))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入密保答案!');", true);
            //    return false;
            //}
            //if (this.DropDownList5.SelectedValue == "请选择")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择地址所在地!');", true);
            //    return false;
            //}

            //if (this.txtYouBian.Value == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('邮编号码不能为空!');", true);
            //    return false;
            //}
            return true;
        }

        //protected void ddlQuestion_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.txtAnswer.Text = "";
        //}

        protected void btnUpdatePwd_Click(object sender, EventArgs e)
        {
            if (UpdateUserPwd(getID(), "Password", PageValidate.GetMd5("111111")) > 0 && UpdateUserPwd(getID(), "SecondPassword", PageValidate.GetMd5("111111")) > 0 )
            {
                MessageBox.MyShow(this, "密码重置成功!");
            }
            else { MessageBox.MyShow(this, "密码重置失败!"); }
           
            ShowInfo();
        }
    }
}
