/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-13 17:39:15 
 * 文 件 名：		Registers.cs 
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
using System.Data.SqlClient;
using DataAccess;
using Library;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Data;

namespace Web.user
{
    public partial class Registers : PageCore//AllCore//System.Web.UI.Page
    {
        public bool SmsPost { set; get; }

        public int asd = 0;
        private long iUserID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "hideloading", "function hideloading() {  ajaxbg.hide(); }", true);

            if (Request["UserID"] != null && Request["UserID"].Length > 0)
            {
                if (PageValidate.IsLong(Request["UserID"]))
                {
                    iUserID = Convert.ToInt64(Request["UserID"].ToString());
                }
            }
            else
            {
                iUserID = 0;
            }

            SetCountDownBtn();

            if (!IsPostBack)
            {

                //BindBank();
                //BindQuestion();
                //BindProvince();

                if (iUserID == 0)
                    iUserID = GetLoginID();

                string state = getStringRequest("state");

                int a0 = 0, a1 = -1, a2 = 0;
                if (state != null && state != "")
                {
                    string[] a = state.Split(',');
                    int.TryParse(a[0].Trim(), out a0);

                    if (a.Length >= 2)
                    {
                        int.TryParse(a[1].Trim(), out a1);
                    }
                    if (a.Length >= 3)
                    {
                        int.TryParse(a[2].Trim(), out a2);
                    }
                }

                else
                {
                    var userInfo = userBLL.GetModel(iUserID);

                    string strUserCode = userInfo != null ? userInfo.UserCode : "";

                    txtRecommendCode.Value = strUserCode;


                    //if (userInfo != null)
                    //{
                    //    if (userInfo.IsAgent == 1 && agentBLL.GetIDByIDUser(getLoginID(),1) > 0)
                    //    {
                    //        txtAgentCode.Value = strUserCode;
                    //    }
                    //    else
                    //    {
                    //        txtAgentCode.Value = agentBLL.GetModel(userInfo.AgentsID).AgentCode;
                    //    }
                    //}
                }
                btnCreateUser.Text = GetLanguage("Build");//生成编号 
                btnValidate.Text = GetLanguage("detection");//检测编号
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        /// <summary>
        /// 获取登录用户ID
        /// </summary>
        /// <returns></returns>
        public long GetLoginID()
        {
            if (Request.Cookies["A128076_user"] != null)
            {
                return Convert.ToInt64(Request.Cookies["A128076_user"]["Id"]);
            }
            else
            {
                return 1;
            }
        }

        //private void BindProvince()
        //{
        //    bind_DropDownList(dropProvince, provinceBLL.GetList("").Tables[0], "provinceID", "province"); //銀行省份
        //}

        /// <summary>
        /// 绑定密保问题
        /// </summary>
        //public void BindQuestion()
        //{
        //    dropQuestion.Items.Add(new ListItem(GetLanguage("PleaseSselect"), "0"));
        //    dropQuestion.Items.Add(new ListItem(GetLanguage("YourNameIs"), "1"));
        //    dropQuestion.Items.Add(new ListItem(GetLanguage("YourHome"), "2"));
        //    dropQuestion.Items.Add(new ListItem(GetLanguage("YourPeople"), "3"));
        //}

        /// <summary>
        /// 绑定银行
        /// </summary>
        //private void BindBank()
        //{
        //    string strBandName = banknameBLL.GetModel(1).BankName;
        //    string[] s = strBandName.Split('|');

        //    //dropBank.Items.Clear();
        //    strBandName = s[0];
        //    if (s.Length < 2)
        //    {
        //        return;
        //    }
        //    if (currentCulture == "en-us")
        //    {
        //        strBandName = s[1];
        //    }
        //    string[] a = strBandName.Split(',');
        //    ListItem list = new ListItem();
        //    list.Value = "0";
        //    list.Text = GetLanguage("PleaseSselect");//"-请选择-"
        //    this.dropBank.Items.Add(list);
        //    foreach (string b in a)
        //    {
        //        ListItem item = new ListItem();
        //        item.Value = b;
        //        item.Text = b;
        //        this.dropBank.Items.Add(item);
        //    }
        //}
        /// <summary>
        /// 验证手机长度 和验证码
        /// </summary>
        /// <returns></returns>
        public bool Get_Yanzheng()
        {
            string phone = txtUserCode.Value.Trim().ToString();

            if (phone.Length != 11)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('手机长度不符合!');", true);
                return false;
            }
            //------------------验证码
            if (this.Text1.Value.Trim() == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("Verification"), Library.Enums.ModalTypes.warning);//验证码不能为空

                return false;
            }

            string xd = Session["CheckCode"] != null && Session["CheckCode"].ToString() != "" ? Session["CheckCode"].ToString() : "";
            if (xd.ToLower() != Text1.Value.Trim().ToLower())
            {
                MessageBox.ShowBox(this.Page, GetLanguage("VerificationError"), Library.Enums.ModalTypes.error);//验证码错误 
                return false;
            }
            return true;
        }
        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DX_btnLogin_Click(object sender, EventArgs e)
        {
            if (Get_Yanzheng())
            {
                string msg = "";
                int SMSInterval = 5; //短信有效期

                string phone = txtUserCode.Value.Trim().ToString();

                if (smsBLL.GetSendCountOfDay(phone) >= 5) //同号码每日限制：5条 
                {
                    msg = "超出短信发送计数限制";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + msg + "');", true);
                    return;
                }
                if (smsBLL.GetSendCountOfMinute(phone, 1) >= 1) //同号码每分钟限制：1条
                {
                    msg = "操作过于频繁，请稍后重试";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + msg + "');", true);
                    return;
                }
                //------------------验证码//

                lgk.Model.SMS model = new lgk.Model.SMS();
                model.IsDeleted = 0;
                model.IsValid = 0;
                model.PublishTime = DateTime.Now;
                model.SCode = new Library.Common().GetRandom(6);
                model.ToPhone = phone;
                model.SMSContent = model.SCode;
                model.SendNum = 1;
                model.ToUserCode = "";
                model.ValidTime = DateTime.Now.AddMinutes(SMSInterval);
                model.TypeID = 1;

                long isid = smsBLL.Add(model);
                if (isid > 0)
                {

                    //msg = "验证码已发送";
                    string strreturn = Library.SMSHelper.SendMessage2(phone, model.SCode);
                    if (strreturn == "0")
                    {
                        CacheHelper.Insert_s(Session.SessionID, DateTime.Now.AddMinutes(2).ToString("yyyy-MM-dd HH:mm:ss"), 2 * 60 - 4);//时间减3秒，提前过期缓存
                        SetCountDownBtn();
                        msg = "发送成功请注意查看手机短信";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + msg + "');", true);
                        return;
                    }
                    else
                    {
                        smsBLL.UpdateDelete(isid, -1);
                        msg = "发送失败";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + msg + "');", true);
                        return;
                    }

                }
                else
                {
                    msg = "验证码发送失败";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + msg + "');", true);
                    return;
                }
            }
        }



        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (RegValidate())
            {
                string phone = txtUserCode.Value.Trim().ToString();
                //if (CheckSMSCode(phone, txtVerifCode.Value.Trim().ToString(), 1) < 0)//验证短信验证码
                //{
                //    MessageBox.ShowBox(this.Page, "", GetLanguage("SMSVerificationError"), Library.Enums.ModalTypes.warning);//注册失败，该会员编号已存在，请重新注册!
                //    return;
                //}

                lgk.Model.tb_user userInfo = new lgk.Model.tb_user();
                lgk.Model.tb_user recommendInfo = userBLL.GetModel(GetUserID(this.txtRecommendCode.Value.Trim()));//推荐用户
                //lgk.Model.tb_user parentInfo = userBLL.GetModel(GetUserID(this.txtParentCode.Value.Trim()));//父节点用户
                //lgk.Model.tb_user agentInfo = userBLL.GetModel(GetUserID(txtAgentCode.Value.Trim()));//报单会员

                userInfo.UserCode = txtUserCode.Value.Trim();//会员编号
                userInfo.LevelID = 1;
                userInfo.RecommendID = recommendInfo.UserID;//推荐人ID
                userInfo.RecommendCode = recommendInfo.UserCode;
                userInfo.RecommendPath = recommendInfo.RecommendPath; //路径
                userInfo.RecommendGenera = Convert.ToInt32(recommendInfo.RecommendGenera + 1);//（推荐代数）第几代

                userInfo.LeftBalance = 0;
                userInfo.LeftNewScore = 0;
                userInfo.RightBalance = 0;
                userInfo.RightNewScore = 0;
                userInfo.LeftScore = 0;
                userInfo.RightScore = 0;

              
                userInfo.User007 = "";//m_user.Location == 1 ? "左区" : "右区";
                userInfo.IsOpend = 0;//是否启用 0-未激活,1-新注册, 2-已激活
                userInfo.IsLock = 0;//是否被冻結(0-否,1-冻結)
                userInfo.IsAgent = 0;//是否报單中心(0-否，1-是)

                //string a = Luodian();
                //if (a == "")
                //{
                //    MessageBox.ShowBox(this.Page, "", "落点失败！", Library.Enums.ModalTypes.error);//注册失败
                //    return;
                //}
                //string[] ID = a.Split('-');
                //var model_1 = userBLL.GetModel(long.Parse(ID[0]));


                userInfo.ParentID = 0;//父节点ID
                userInfo.ParentCode = "";//父节点編號
                userInfo.UserPath = ""; //路径
                userInfo.Layer = 0;//属于多少层

                userInfo.Emoney = 0;//报单积分
                userInfo.BonusAccount = 0;//拆分积分
                userInfo.AllBonusAccount = 0;//量子宝
                userInfo.StockAccount = 0;//云积分
                userInfo.StockMoney = 0;//公积金
                userInfo.GLmoney = 0;//复投积分
                decimal dRegMoney = 0;
                userInfo.ShopAccount = 0;//奖金币 
                userInfo.RegMoney = dRegMoney; 
              
                userInfo.BillCount = 1;// getParamInt("reg" + ddlLevel.SelectedValue);//注册单数 

              
               
                userInfo.Location = 0;//区域

                userInfo.RegTime = DateTime.Now;//注册時間
                userInfo.Password = PageValidate.GetMd5(this.txtPassword.Value.Trim());//一级密码
                userInfo.SecondPassword = PageValidate.GetMd5(this.txtSecondPassword.Value.Trim());//二级密码
                userInfo.ThreePassword = PageValidate.GetMd5(Util.CreateNo());

                userInfo.NiceName = txtNiceName.Value.Trim();
                userInfo.TrueName = "";// "姓名";
                userInfo.IdenCode = txtIDNumber.Value.Trim() ;// "身份证號";
                string strPhoneNum = this.txtUserCode.Value.Trim();
                userInfo.PhoneNum = string.IsNullOrEmpty(strPhoneNum) ? "" : strPhoneNum;// "手机號碼";
                userInfo.Address = "";//聯系地址
                userInfo.NiceName = string.Empty;//txtNickName.Value.Trim();//昵称
                userInfo.TrueName = string.Empty;// "姓名";
                //userInfo.IdenCode = string.Empty;// "身份证號";
                string phoneNum = this.txtPhoneNum.Value.Trim();
                userInfo.PhoneNum = string.IsNullOrEmpty(phoneNum) ? "" : phoneNum;// "手机號碼";
                userInfo.Address = string.Empty;//聯系地址
                userInfo.QQnumer = "";//QQ
                userInfo.Email = "";//电子邮箱

                userInfo.User001 = 0;
                userInfo.User004 = 0;
                userInfo.User002 = 1;//
                userInfo.User003 = 0;//
                userInfo.User003 = 0;//
                userInfo.Location = 0; /*radMarketOne.Checked == true ? 1 : 2*/
                userInfo.User007 = "";
                userInfo.User006 = Agent.Value.Trim();
                //int.TryParse(dropQuestion.SelectedValue, out q);
                //string question = q > 0 && q <= 3 ? dropQuestion.SelectedItem.Text : string.Empty;
                userInfo.User009 = "";// question;//密保问题
                userInfo.User010 = "";// string.IsNullOrEmpty(question) ? string.Empty : txtAnswer.Text.Trim();//密保答案
                userInfo.User011 = 0;
                userInfo.User015 = 0;//购股币
                userInfo.User016 = 0;
                userInfo.User017 = 0;
                userInfo.User018 = 0;//--用户竞拍该扣未扣的奖金币

                //userInfo.User007 = Util.GetUniqueIndentifier(20);
                //userInfo.User008 = Util.GetUniqueIndentifier(4).ToUpper();//邀请码
                //userInfo.User010 = "";// txtAlipay.Value.Trim(); //支付宝

                long iUID = GetUserID(txtUserCode.Value.Trim());
                if (iUID > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "hideloading", "hideloading();", true);
                    MessageBox.ShowBox(this.Page, GetLanguage("RegistrationFails"), Library.Enums.ModalTypes.error);//注册失败，该会员编号已存在，请重新注册!
                }
                else
                {

                    if (userBLL.Add(userInfo) > 0)
                    {
                        lgk.Model.tb_user model = userBLL.GetModel(GetUserID(userInfo.UserCode));

                        //model.UserPath = model.UserPath + "-" + model.UserID.ToString();
                        model.RecommendPath = model.RecommendPath + "-" + model.UserID.ToString();  
                        model.RegMoney = 0;
                        model.LeftScore = 0;
                        model.RightScore = 0;
                        model.RightNewScore = 0;
                        model.LeftNewScore = 0; 
                        userBLL.Update(model);

                        //写流水
                          MessageBox.ShowBox(this.Page, "", "注册成功!", Library.Enums.ModalTypes.success);//注册成功
                         return;
                       
                    }
                    else
                    {
                        lgk.Model.tb_user model = userBLL.GetModel(GetUserID(userInfo.UserCode));
                        userBLL.Delete(model.UserID);//删除该会员资料
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('异常错误，注册失败！');", true);
                        return;
                    } 


                    //    string msg = userBLL.proc_RegisterUser(userInfo);
                    //if (msg == "ok")
                    //{
                    //    long userid = GetUserID(userInfo.UserCode);
                    //    int statusCode;
                    //    var api = new EaseMobAPIHelper();
                    //    if (System.Configuration.ConfigurationManager.AppSettings["ACCOUNTSYNC_SWITCH"] != "Open")
                    //    {
                    //        var data = api.AccountCreate(userInfo.UserCode, userInfo.ThreePassword, out statusCode);

                    //        if (statusCode == 200)
                    //        {
                    //            var emResult = JsonConvert.DeserializeObject<APPService.EaseMobResult>(data);
                    //            if (!string.IsNullOrEmpty(emResult.error) || emResult.error == null)
                    //            {
                    //                MessageBox.ShowBox(this.Page, "", "注册成功", Library.Enums.ModalTypes.success);//注册成功
                    //                return;
                    //            }
                    //            else
                    //            {
                    //                userBLL.Delete(userid);
                    //                MessageBox.ShowBox(this.Page, "", "网络繁忙，注册失败.", Library.Enums.ModalTypes.error);//注册失败
                    //            }
                    //        }
                    //        else
                    //        {
                    //            userBLL.Delete(userid);
                    //            LogHelper.SaveLog(data, "LinkRegister");
                    //            MessageBox.ShowBox(this.Page, "", "网络繁忙，请稍后重试", Library.Enums.ModalTypes.error);//注册失败
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.ShowBox(this.Page, "", "注册成功", Library.Enums.ModalTypes.success);//注册成功
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.ShowBox(this.Page, "", msg, Library.Enums.ModalTypes.error);//注册失败
                    //}
                }

            }
        }

        #region 输入验证
        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        protected bool RegValidate()
        {
            lgk.Model.tb_user recommendInfo = new lgk.Model.tb_user();
            //lgk.Model.tb_user parentInfo = new lgk.Model.tb_user();
            //lgk.Model.tb_agent agentInfo = new lgk.Model.tb_agent();

            #region 会员编号验证
            if (txtUserCode.Value.Trim() == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("PleaseNumber"), Library.Enums.ModalTypes.warning);//请输入会员编号

                return false;
            }
            //if (!PageValidate.checkUserCode(txtUserCode.Value.Trim()))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("MemberNumber") + "');", true);//会员编号必须由6-10位的英文字母或数字组成
            //    return false;
            //}

            if (GetUserID(txtUserCode.Value.Trim()) > 0)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("Memberexists"), Library.Enums.ModalTypes.info);//该会员编号已存在,请重新输入!
                return false;
            }
            #endregion

            if (txtNiceName.Value.Trim() == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("Nickname"), Library.Enums.ModalTypes.warning);//会员昵称不能为空
                return false;
            }

            #region 密码验证
            if (txtPassword.Value.Trim() == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("PasswordISNull"), Library.Enums.ModalTypes.warning);//登录密码不能为空
                return false;
            }
            //if (txtPassword.Value.Trim().Length < 6)
            //{
            //    MessageBox.ShowBox(this.Page, GetLanguage("PasswordLength"), Library.Enums.ModalTypes.warning);//密码长度不能小于6位
            //    return false;
            //}
            if (txtRegPassword.Value.Trim() == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("ConfirmPasswordISNull"), Library.Enums.ModalTypes.warning);//确认密码不能为空
                return false;
            }
            if (!txtPassword.Value.Trim().Equals(txtRegPassword.Value.Trim()))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("TwoPasswordMatch"), Library.Enums.ModalTypes.warning);//两次输入的登录密码不一致
                return false;
            }
            if (txtSecondPassword.Value.Trim() == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("SecondaryISNUll"), Library.Enums.ModalTypes.warning);//二级密码不能为空
                return false;
            }

            if (txtRegSecondPassword.Value.Trim() == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("secondaryPasswordISNull"), Library.Enums.ModalTypes.warning);//确认二级密码不能为空
                return false;
            }
            if (!txtSecondPassword.Value.Trim().Equals(txtRegSecondPassword.Value.Trim()))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("TwoSecondaryMatch"), Library.Enums.ModalTypes.warning);//两次输入的二级密码不一致
                return false;
            }
            #endregion

            #region 银行验证
            //string strBankAccount = this.txtBankAccount.Value.Trim();

            //if (txtAlipay.Value.Trim() == "" && string.IsNullOrEmpty(strBankAccount))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("AlipayAccount") + "');", true);//支付宝账号不能为空
            //    return false;
            //}


            //if (!string.IsNullOrEmpty(strBankAccount) && !PageValidate.RegexTrueBank(this.txtBankAccount.Value) && string.IsNullOrEmpty(txtAlipay.Value.Trim()))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("BankCardErrors") + "');", true);//银行卡号输入错误
            //    return false;
            //}

            //string strBankAccountUser = this.txtBankAccountUser.Value.Trim();


            //if (!string.IsNullOrEmpty(strBankAccountUser) && !PageValidate.RegexTrueName(txtBankAccountUser.Value.Trim()) && string.IsNullOrEmpty(txtAlipay.Value.Trim()))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NameMust") + "');", true);//开户名必须为2-30个中英文
            //    return false;
            //} 
            #endregion

            #region 推荐人验证
            string reName = this.txtRecommendCode.Value.Trim();
            if (string.IsNullOrEmpty(reName))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("ReferenceNumberIsnull"), Library.Enums.ModalTypes.warning);//推荐人编号不能为空
                return false;
            }
            else
            {
                recommendInfo = userBLL.GetModel(GetUserID(reName));//推薦用户
                if (recommendInfo == null)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("featuredNotExist"), Library.Enums.ModalTypes.warning);//该推荐会员不存在
                    return false;
                }
                if (recommendInfo.IsOpend == 0)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("MemberISNull"), Library.Enums.ModalTypes.warning);//该会员尚未开通，不能作为推荐会员
                    return false;
                }
            }
            #endregion

            //if (radioRegQy.SelectedValue == "")
            //{
            //    MessageBox.ShowBox(this.Page, "请选择注册区域", Library.Enums.ModalTypes.warning);//会员昵称不能为空
            //    return false;
            //}

            #region 手机号码验证
            var strPhoneNum = this.txtUserCode.Value.Trim();

            if (!string.IsNullOrEmpty(strPhoneNum) && !PageValidate.RegexPhone(strPhoneNum))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("PhoneMust"), Library.Enums.ModalTypes.error);//联系电话格式错误
                return false;
            }

            int userid = GetUserIDbByPhone(strPhoneNum);
            if (userid > 0)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("PhoneRegExists"), Library.Enums.ModalTypes.info);//该手机号码已注册
                return false;
            }

            int ct = GetPhoneNumber(strPhoneNum);
            //  int p_phoneNumer = getParamInt("RegisterPhoneNumber");
            if (ct >= 1)
            {
                MessageBox.ShowBox(this.Page, string.Format(GetLanguage("RegisterPhoneNumber")), Library.Enums.ModalTypes.warning);//该手机号码已注册
                return false;
            }
            //身份证判断
            AllCore ac = new AllCore();
            if (txtIDNumber.Value.Trim().Length < 15 && txtIDNumber.Value.Trim().Length > 18)
            {
                MessageBox.ShowBox(this.Page, string.Format("请输入正确的身份证号码！"), Library.Enums.ModalTypes.warning);//请输入正确的身份证号码
                return false;
            }
            ct = ac.GetIDCodeNumber(txtIDNumber.Value.Trim());

            if (ct >= 1)
            {
                MessageBox.ShowBox(this.Page, string.Format(ac.GetLanguage("RegisterIDCodeNumber")), Library.Enums.ModalTypes.warning);//该身份证号注册
                return false;
            }
            //服务中心判断
            var agentcode = Agent.Value.Trim();
            int ID = ac.agentBLL.GetAgentsIDByUserCode(agentcode);
            if (ID == 0)//服务中心
            {
                MessageBox.ShowBox(this.Page, string.Format("该服务中心不存在！"), Library.Enums.ModalTypes.warning);//请输入正确的身份证号码
                return false;
            }
            if (ac.agentBLL.GetModel(ID).Flag == 2)
            {
                MessageBox.ShowBox(this.Page, string.Format("该服务中心已被冻结！"), Library.Enums.ModalTypes.warning);//请输入正确的身份证号码
                return false;
            }

            #endregion

            #region 密保问题验证
            //if (dropQuestion.SelectedValue.Trim() == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseSelectQuestion") + "');", true);//请选择密保问题
            //    return false;
            //}
            //if (string.IsNullOrEmpty(txtAnswer.Text))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseAnswer") + "');", true);//请输入密保答案
            //    return false;
            //} 
            #endregion

            #region 商务中心
            //int iAgentOpend = getParamInt("AgentSwith");//商务中心是否开启
            //if (!string.IsNullOrEmpty(txtAgent.Value.Trim()))
            //{
            //    if (iAgentOpend == 1)
            //    {

            //        bool isagent = agentBLL.isExistByName(txtAgent.Value.Trim());
            //        if (!isagent)
            //        {
            //            MessageBox.ShowBox(this.Page, GetLanguage("AgentNumberExist"), Library.Enums.ModalTypes.warning);//商务中心编号不存在
            //            return false;
            //        }
            //    }
            //}

            //decimal regopen = getParamAmount("RegOpen");
            //if(LoginUser.Emoney < regopen)
            //{
            //    MessageBox.ShowBox(this.Page, GetLanguage("RegOpenMust"), Library.Enums.ModalTypes.warning);//注册积分不足
            //    return false;
            //} 
            #endregion

            return true;
        } 
        #endregion

        #region 自动生成用户编号
        /// <summary>
        /// 自动生成用户编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            UserCode code = new UserCode();
            string strCode = string.Empty;
            string strUserCode = string.Empty;

            bool bFlag = true;
            while (bFlag)
            {
                strCode = code.GetCode();
                strUserCode =   strCode;
                if (!userBLL.Exists(strUserCode))
                {
                    bFlag = false;
                }
            }
            txtUserCode.Value = strUserCode;
        } 
        #endregion

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            string strUserCode = txtUserCode.Value.Trim();
            if (strUserCode == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("PleaseNmae"), Library.Enums.ModalTypes.warning);//请输入用户名
                return;
            }
            //if (!PageValidate.checkUserCode(txtUserCode.Value.Trim()))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("UserNmae") + "');", true);//用户名必须由6-10位的英文字母或数字组成
            //    return;
            //}
            if (userBLL.Exists(strUserCode))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("existsrNmae"), Library.Enums.ModalTypes.info);//该用户名已存在
                return;
            }
            else
            {
                MessageBox.ShowBox(this.Page, GetLanguage("availableNmae"), Library.Enums.ModalTypes.info);//该用户名可用
                return;
            }
        }

        private string  Luodian( )
        {
            int ceng = 1;//推荐会员的层（自己算1）
            int Ceng = 0;//真实线内的层
            string UserID = getLoginID()==1?"1-" : "-" + getLoginID() + "-";
            var model = userBLL.GetModel(getLoginID());
            string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"]; 

            string sql_1 = "select count(UserID) RS from tb_user ;"; 
            DataTable dt_1 = userBLL.getData_Chaxun(sql_1, "").Tables[0]; 
            int RS = int.Parse(dt_1.Rows[0]["RS"].ToString());
            for (int i = 1; i <= RS; i++)
            {
                //第一层
                string sql = "select count(UserID) RS from tb_user where UserPath like '%" + UserID + "%' and Layer="+ (model.Layer+i) +" ;";
                DataTable dt = userBLL.getData_Chaxun(sql, "").Tables[0];
                int count = int.Parse(dt.Rows[0]["RS"].ToString());
                if (count== i*2)//人数满了 就回去 下一层
                {
                    continue;
                }

                //否则 按这上层来找
                if (model.Layer + i - 1==1)
                {
                    UserID = "1";
                    sql = "select UserID from tb_user where UserPath like '%" + UserID + "%' and Layer=" + (model.Layer + i - 1) + " ;";
                }
                else
                {
                    sql = "select UserID from tb_user where UserPath like '%" + UserID + "%' and Layer=" + (model.Layer + i - 1) + " ;";
                }
              
                dt = userBLL.getData_Chaxun(sql, "").Tables[0];
                //if (dt.Rows.Count==0)//如果下一层没有人的处理
                //{
                //    sql = "select min(UserID)UserID from tb_user where UserPath like '%" + UserID + "%' and Layer=" + (model.Layer + i-1) + " ;";
                //    dt = userBLL.getData_Chaxun(sql, "").Tables[0];
                //    long Userid = long.Parse(dt.Rows[0]["UserID"].ToString());
                //    return Userid + "-" + 1;

                //}
                for (int ii = 0; ii < i*2; ii++)
                {
                    long Userid = long.Parse(dt.Rows[ii]["UserID"].ToString());
                    string sql2 = "select UserID RS from tb_user where ParentID = " + Userid + " ";
                    DataTable dt2 = userBLL.getData_Chaxun(sql2, "").Tables[0];
                    if (dt2.Rows.Count==2) //人数满了 就回去 下一位
                    {
                        continue;
                    }
                    else if (dt2.Rows.Count == 0)
                    {
                        return Userid + "-" + 1;
                    }
                    else if (dt2.Rows.Count == 1)
                    {
                        return Userid + "-" + 2;
                    }
                } 
            } 
            return "";
        }
        /// <summary>
        /// 设置倒计时时间
        /// </summary>
        private void SetCountDownBtn()
        {
            if (CacheHelper.Get(Session.SessionID) != null)
            {
                countdown_s.Visible = true;
                //varifiBtn.Style.Add("display","none");
                btnSendSMS.Visible = false;
                btn_is_view.Value = "0";
                TimeSpan date = DateTime.Parse(CacheHelper.Get(Session.SessionID).ToString()) - DateTime.Now;
                countdown_val.Value = (date.Minutes * 60 + date.Seconds + 2).ToString();
                SmsPost = true;
            }
            else
            {
                btn_is_view.Value = "1";
                SmsPost = false;
                //varifiBtn.Style.Add("display", "inline");
                btnSendSMS.Visible = true;
                countdown_s.Visible = false;
                countdown_val.Value = "-1";
                msg.InnerHtml = "";
            }
        }
    }
}