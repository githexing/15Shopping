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
using lgk.BLL;
using Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web
{
    public partial class Registers : AllCore
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string sprID = Request.QueryString["UserID"];
                string state = getStringRequest("state");
                //string[] a;
                if (state != "" && state != null)
                {
                    //a = state.Split(',');
                    //if (int.Parse(a[1].Trim()) == 1)
                    //    sex1.Checked = true;
                    //else
                    //    sex2.Checked = true;
                    state = DESEncrypt.Decrypt(state);
                    long userid;
                    long.TryParse(state, out userid);
                    var data = userBLL.GetModel(userid);
                    txtRecommendCode.Value = data != null ? data.UserCode : userBLL.GetModel(1).UserCode;

                }
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


        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (RegValidate())
            {
                lgk.Model.tb_user userInfo = new lgk.Model.tb_user();
                lgk.Model.tb_user recommendInfo = userBLL.GetModel(GetUserID(this.txtRecommendCode.Value.Trim()));//推荐用户


                userInfo.UserCode = txtUserCode.Value.Trim();//会员编号
                userInfo.LevelID = 1;
                userInfo.RecommendID = recommendInfo.UserID;//推荐人ID
                userInfo.RecommendCode = recommendInfo.UserCode;//推荐人编号
                userInfo.RecommendPath = recommendInfo.RecommendPath; //路径
                userInfo.RecommendGenera = Convert.ToInt32(recommendInfo.RecommendGenera + 1);//（推荐代数）第几代

                userInfo.ParentID = 0;//父节点ID
                userInfo.ParentCode = "-";//父节点編號
                userInfo.UserPath = "-"; //路径
                userInfo.Layer = 0;//属于多少层
                userInfo.LeftBalance = 0;
                userInfo.LeftNewScore = 0;
                userInfo.RightBalance = 0;
                userInfo.RightNewScore = 0;
                userInfo.LeftScore = 0;
                userInfo.RightScore = 0;

                userInfo.Location = 0;

                userInfo.IsOpend = 0;//是否启用 0-未激活,1-新注册, 2-已激活
                userInfo.IsLock = 0;//是否被冻結(0-否,1-冻結)
                userInfo.IsAgent = 0;//是否报單中心(0-否，1-是)
                userInfo.User006 = ""/*txtAgentCode.Value.Trim()*/;
                userInfo.AgentsID = 0/*agentBLL.GetAgentsID(txtAgentCode.Value.Trim(),1)*/;//
                //userInfo.QQnumer = txtQQnumer.Value.Trim();//QQ
                //userInfo.Email = txtEmail.Value.Trim();//电子邮箱

                userInfo.Emoney = 0;//云盾
                userInfo.BonusAccount = 0;//现金积分
                userInfo.AllBonusAccount = 0;//累计现金积分账户
                userInfo.StockAccount = 0;//复投积分
                userInfo.ShopAccount = 0;//云图
                userInfo.StockMoney = 0;//投资积分

                userInfo.RegTime = DateTime.Now;//注册時間
                //userInfo.OpenTime = DateTime.Now;//注册時間
                userInfo.GLmoney = 0;// 
                userInfo.BillCount = 1;// 
                userInfo.Password = PageValidate.GetMd5(this.txtPassword.Value.Trim());//一级密码
                userInfo.SecondPassword = PageValidate.GetMd5(this.txtSecondPassword.Value.Trim());//二级密码
                userInfo.ThreePassword = PageValidate.GetMd5(Util.CreateNo());

                userInfo.BankAccount = ""; //this.txtBankAccount.Value.Trim();// "銀行賬號";
                userInfo.BankAccountUser = "";// this.txtBankAccountUser.Value.Trim();// "開户姓名";
                userInfo.BankName = "";// this.dropBank.SelectedValue;// "開户銀行";
                userInfo.BankBranch = "";// this.txtBankBranch.Value.Trim();// "支行名稱";
                userInfo.BankInProvince = "";// dropProvince.SelectedItem.Text;// "銀行所在省份";
                userInfo.BankInCity = "";// "銀行所在城市";

                userInfo.NiceName = string.Empty;/*string.Empty;*///昵称
                userInfo.TrueName = "";// "姓名";
                userInfo.IdenCode = "";// "身份证號";
                string strPhoneNum = this.txtUserCode.Value.Trim();
                userInfo.PhoneNum = string.IsNullOrEmpty(strPhoneNum) ? "" : strPhoneNum;// "手机號碼";
                userInfo.Address = ""/*txtAddress.Value*/;//聯系地址

                userInfo.User001 = 0;//--- 
                userInfo.User002 = 0;  //注册人ID
                userInfo.User003 = 0;//推荐人数
                userInfo.User004 = 0;//投资单数标识 
                userInfo.User005 = "";//资料修改标识
                userInfo.User007 = "";
                userInfo.User009 = "";
                userInfo.User010 = Util.GetUniqueIndentifier(20);//聚元交易地址
                userInfo.Gender = sex1.Checked == true ? 1 : 2;
                // int iQuestion = 0;
                //int.TryParse(dropQuestion.SelectedValue, out iQuestion);
                //string strQuestion = iQuestion > 0 && iQuestion <= 3 ? dropQuestion.SelectedItem.Text : string.Empty;
                //userInfo.SafetyCodeQuestion = strQuestion;//密保问题
                //userInfo.SafetyCodeAnswer = string.IsNullOrEmpty(strQuestion) ? string.Empty : txtAnswer.Text.Trim();//密保答案
                userInfo.User011 = 0;
                userInfo.User013 = 0;// 
                userInfo.User018 = 1; // 推广链接注册

                userInfo.RegMoney = 0;

                if (userBLL.Exists(txtUserCode.Value.Trim()))
                {
                    MessageBox.ShowBox(this.Page, "",  "该会员编号已存在，请重新注册!", Library.Enums.ModalTypes.success);//注册成功
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("RegistrationFails") + "');", true);//注册失败，该会员编号已存在，请重新注册!
                }
                else
                {
                    if (userBLL.Add(userInfo) > 0)
                    {
                        long userid = GetUserID(userInfo.UserCode);
                        int statusCode;
                        var api = new EaseMobAPIHelper();
                        var data = api.AccountCreate(userInfo.UserCode, userInfo.ThreePassword, out statusCode);

                        if (statusCode == 200)
                        {
                            var emResult = JsonConvert.DeserializeObject<APPService.EaseMobResult>(data);
                            if (!string.IsNullOrEmpty(emResult.error) || emResult.error == null)
                            {
                                
                                int flag = flag_ActivationUser(GetUserID(userInfo.UserCode), 0);
                                if (flag != 0)
                                {
                                    userBLL.Delete(userid);

                                    if (flag == -1)
                                    {
                                        userBLL.Delete(userid);
                                        MessageBox.ShowBox(this.Page, "", GetLanguage("ActivationUserFail"), Library.Enums.ModalTypes.error);//激活会员失败
                                    }
                                    else
                                    {
                                        userBLL.Delete(userid);
                                        MessageBox.ShowBox(this.Page, "", GetLanguage("RegOpenMust"), Library.Enums.ModalTypes.error);//云盾不足
                                    }
                                }
                                else
                                {
                                    MessageBox.ShowBox(this.Page, "", "注册成功", Library.Enums.ModalTypes.success);//注册成功
                                    return;
                                }
                            }
                            else
                            {
                                userBLL.Delete(userid);
                                MessageBox.ShowBox(this.Page, "", "网络繁忙，注册失败.", Library.Enums.ModalTypes.error);//注册失败
                            }
                        }
                        else
                        {
                            userBLL.Delete(userid);
                            LogHelper.SaveLog(data, "LinkRegister");
                            MessageBox.ShowBox(this.Page,"", "网络异常，注册失败", Library.Enums.ModalTypes.error);//注册失败
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        protected bool RegValidate()
        {
            lgk.Model.tb_user recommendInfo = new lgk.Model.tb_user();


            if (txtUserCode.Value.Trim() == "")
            {
                MessageBox.ShowBox(this.Page, "", GetLanguage("PleaseNumber"), Library.Enums.ModalTypes.warning);//请输入会员编号

                return false;
            }
            if (!PageValidate.checkUserCode(txtUserCode.Value.Trim()))
            {
                MessageBox.ShowBox(this.Page, "", GetLanguage("MemberNumber"), Library.Enums.ModalTypes.warning);//会员编号必须由6-10位的英文字母或数字组成
                return false;
            }

            if (GetUserID(txtUserCode.Value.Trim()) > 0)
            {
                MessageBox.ShowBox(this.Page, "", GetLanguage("Memberexists"), Library.Enums.ModalTypes.info);//该会员编号已存在,请重新输入!
                return false;
            }

            //if (sex1.Checked != true && sex2.Checked != true)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseArea") + "');", true);//请选择注册区域
            //    return false;
            //}

            //int iLocation = 0;
            //if (sex1.Checked == true) { iLocation = 1; }
            //if (sex2.Checked == true) { iLocation = 2; }
            #region 手机号码验证
            if (txtPhoneNum.Value == "")
            {
                MessageBox.ShowBox(this.Page, "", GetLanguage("Phoneempty"), Library.Enums.ModalTypes.warning);//手机号码不能为空
                return false;
            }
            var strPhoneNum = this.txtPhoneNum.Value.Trim();

            if (!string.IsNullOrEmpty(strPhoneNum) && !PageValidate.RegexPhone(strPhoneNum))
            {
                MessageBox.ShowBox(this.Page, "", GetLanguage("PhoneMust"), Library.Enums.ModalTypes.error);//联系电话格式错误
                return false;
            }

            int userid = GetUserIDbByPhone(strPhoneNum);
            if (userid > 0)
            {
                MessageBox.ShowBox(this.Page, "", GetLanguage("PhoneRegExists"), Library.Enums.ModalTypes.info);//该手机号码已注册
                return false;
            }

            if (appId == "Open")
            {
                if (verifid_code.Value.Trim() == "")
                {
                    MessageBox.ResponseScript(this, "msg_disp('请输入验证码！');");
                    return false;
                }
                DataSet ds = new lgk.BLL.SMS().GetList(" IsValid=0 and ToUserCode='" + Session.SessionID + "' and ToPhone='" + txtPhoneNum.Value.Trim() + "' and SCode='" + verifid_code.Value.Trim() + "' and ValidTime >= getdate() ");
                if (ds == null || ds.Tables == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.ResponseScript(this, "msg_disp('验证码无效！');");
                    return false;
                }
                else
                {
                    lgk.Model.SMS sms = new lgk.BLL.SMS().GetModel(long.Parse(ds.Tables[0].Rows[0]["ID"].ToString()));
                    sms.IsValid = -1;
                    new lgk.BLL.SMS().Update(sms);
                    CacheHelper.Remove(Session.SessionID);
                }
            }
            #endregion

            #region 密码验证
            if (txtPassword.Value.Trim() == "")
            {
                MessageBox.ShowBox(this.Page, "", GetLanguage("PasswordISNull"), Library.Enums.ModalTypes.warning);//登录密码不能为空
                return false;
            }



            if (txtSecondPassword.Value.Trim() == "")
            {
                MessageBox.ShowBox(this.Page, "", GetLanguage("SecondaryISNUll"), Library.Enums.ModalTypes.warning);//二级密码不能为空
                return false;
            }



            #endregion



            #region 推荐人验证
            if (txtRecommendCode.Value == "")
            {
                MessageBox.ShowBox(this.Page, GetLanguage("ReferenceNumberIsnull"), Library.Enums.ModalTypes.warning);//推荐人编号不能为空
                return false;
            }
            else
            {
                string reName = this.txtRecommendCode.Value.Trim();
                recommendInfo = userBLL.GetModel(GetUserID(reName));//推薦用户
                if (recommendInfo == null)
                {
                    MessageBox.ShowBox(this.Page, "", GetLanguage("featuredNotExist"), Library.Enums.ModalTypes.warning);//该推荐会员不存在
                    return false;
                }
                if (recommendInfo.IsOpend == 0)
                {
                    MessageBox.ShowBox(this.Page, "", GetLanguage("MemberISNull"), Library.Enums.ModalTypes.warning);//该会员尚未开通，不能作为推荐会员
                    return false;
                }
            }
            #endregion


            return true;


        }
        protected void VerifiCode_Click(object sender, EventArgs e)
        {
          
            string str = "";
            string strPhone = txtPhoneNum.Value.Trim();
            if (!new RegexR().isPhones(strPhone))
            {
                str = "手机号码有误！";
                return;
            }
            else
            {
                AllCore core = new AllCore();
                lgk.Model.SMS model = new lgk.Model.SMS();
                model.IsDeleted = 0;
                model.IsValid = 1;
                model.PublishTime = DateTime.Now;
                model.SCode = new Library.Common().GetRandom(6);
                model.ToPhone = strPhone;
                model.SMSContent = model.SCode;
                model.SendNum = 0;
                model.ToUserCode = Session.SessionID;
                model.ValidTime = DateTime.Now.AddMinutes(5);
                model.TypeID = 4;//推广链接的类别
                CacheHelper.Insert_s(Session.SessionID, DateTime.Now.AddMinutes(1).ToString("yyyy-MM-dd HH:mm:ss"), 1 * 60 - 4);//时间减3秒，提前过期缓存
                if (new lgk.BLL.SMS().Add(model) > 0)
                {
                    string strreturn = Library.SMSHelper.SendMessage2(strPhone, model.SCode);
                    if (strreturn == "0")
                    {
                        str = "验证码已发送";
                    }
                    else
                    {
                        str = "验证码发送失败！";
                    }
                    SetCountDownBtn();
                }
                else
                {
                    str = "验证码发送失败！";
                }
            }
            msg.InnerHtml = str;

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
                varifiBtn.Visible = false;
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
                varifiBtn.Visible = true;
                countdown_s.Visible = false;
                countdown_val.Value = "-1";
                msg.InnerHtml = "";
            }
        }
        public bool SmsPost { set; get; }
        public string appId { get; set; }

    }
}