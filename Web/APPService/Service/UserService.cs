using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library;
using lgk.BLL;
using System.Data;
using Web.APPService.ViewModel;

namespace Web.APPService.Service
{
    public class UserService : AllCore
    {
        public bool ValidToken(string tokencode, out string message)
        {
            bool flag = false;
            message = "";

            lgk.Model.tb_LoginToken tokenmodel = logintokenBLL.GetModelByToken(tokencode);
            if (tokenmodel == null)
            {
                message = "授权码token不存在";
            }
            else if (tokenmodel.EndTime < DateTime.Now)
            {
                message = "授权码token已过期";
            }
            else if (tokenmodel.IsValid == 1)
            {
                message = "授权码token已失效";
            }
            else
            {
                flag = true;
                message = "验证成功";
            }
            return flag;
        }

        public bool Register(string UserCode, string Sex, string Phone, string Password, string PayPassword, long Validid, string invitecode, string nickname, out long NewUserId, out string HX_Password, out string message)
        {
            NewUserId = 0;
            HX_Password = "";
            if (RegValidate(UserCode, Sex, Phone, Password, PayPassword, invitecode, out message))
            {
                lgk.Model.tb_user userInfo = new lgk.Model.tb_user();
                lgk.Model.tb_user recommendInfo = userBLL.GetModel(userBLL.GetUserIDByInviteCode(invitecode.Trim()));//推荐用户 通过邀请码

                userInfo.UserCode = UserCode;//会员编号
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

                userInfo.Emoney = 0;//原始币
                userInfo.BonusAccount = 0;//释放币
                userInfo.AllBonusAccount = 0;//累计现金积分账户
                userInfo.StockAccount = 0;//复投积分
                userInfo.ShopAccount = 0;//
                userInfo.StockMoney = 0;//投资积分

                userInfo.RegTime = DateTime.Now;//注册時間
                //userInfo.OpenTime = DateTime.Now;//注册時間
                userInfo.GLmoney = 0;// 
                userInfo.BillCount = 1;// 
                userInfo.Password = Password.Trim().ToUpper();// PageValidate.GetMd5(Password.Trim());//一级密码
                userInfo.SecondPassword = PayPassword.Trim().ToUpper();// PageValidate.GetMd5(PayPassword.Trim());//二级密码
                userInfo.ThreePassword = PageValidate.GetMd5(Util.CreateNo());

                HX_Password = userInfo.ThreePassword;

                userInfo.BankAccount = ""; //this.txtBankAccount.Value.Trim();// "銀行賬號";
                userInfo.BankAccountUser = "";// this.txtBankAccountUser.Value.Trim();// "開户姓名";
                userInfo.BankName = "";// this.dropBank.SelectedValue;// "開户銀行";
                userInfo.BankBranch = "";// this.txtBankBranch.Value.Trim();// "支行名稱";
                userInfo.BankInProvince = "";// dropProvince.SelectedItem.Text;// "銀行所在省份";
                userInfo.BankInCity = "";// "銀行所在城市";

                userInfo.NiceName = nickname;//昵称
                userInfo.TrueName = "";// idenname;// "姓名";
                userInfo.IdenCode = "";// idencode;// "身份证號";
                string strPhoneNum = Phone; //this.txtPhoneNum.Value.Trim();
                userInfo.PhoneNum = string.IsNullOrEmpty(strPhoneNum) ? "" : strPhoneNum;// "手机號碼";
                userInfo.Address = ""/*txtAddress.Value*/;//聯系地址

                userInfo.User001 = 0;//--- 
                userInfo.User002 = 0; //LoginUser.UserID;  //注册人ID
                userInfo.User003 = 0;//推荐人数
                userInfo.User004 = 0;//投资单数标识 
                userInfo.User005 = "";//资料修改标识
                userInfo.User007 = Util.GetUniqueIndentifier(20);//YT钱包地址
                userInfo.User008 = Util.GetUniqueIndentifier(4).ToUpper();//邀请码
                userInfo.User010 = "";// Util.GetUniqueIndentifier(20);//聚元交易地址
                // int iQuestion = 0;
                //int.TryParse(dropQuestion.SelectedValue, out iQuestion);
                //string strQuestion = iQuestion > 0 && iQuestion <= 3 ? dropQuestion.SelectedItem.Text : string.Empty;
                //userInfo.SafetyCodeQuestion = strQuestion;//密保问题
                //userInfo.SafetyCodeAnswer = string.IsNullOrEmpty(strQuestion) ? string.Empty : txtAnswer.Text.Trim();//密保答案
                userInfo.User011 = 0;
                userInfo.User012 = 0;
                userInfo.User013 = 0;// 
                userInfo.User018 = 0; // 

                userInfo.RegMoney = 0;
                userInfo.Gender = Sex == "2" ? 2 : 1; //1:男，2：女
                NewUserId = userBLL.GetUserID(UserCode.Trim());
                if (NewUserId > 0)
                {
                    message = GetLanguage("RegistrationFails");//注册失败，该会员编号已存在，请重新注册!
                    return false;
                }
                else
                {
                    if (userBLL.Add(userInfo) > 0)
                    {
                        long userid = GetUserID(userInfo.UserCode);
                        int flag = flag_ActivationUser(GetUserID(userInfo.UserCode), 0);
                        if (flag != 0)
                        {
                            userBLL.Delete(userid);

                            if (flag == -1)
                            {
                                message = GetLanguage("ActivationUserFail");//激活会员失败
                                return false;
                            }
                            else
                            {
                                message = GetLanguage("RegOpenMust");//原始币不足
                                return false;
                            }
                        }
                        else
                        {
                            if (Validid > 0)
                            {
                                smsBLL.UpdateState(Validid, 1);//已验证
                            }
                            message = "注册成功";
                            return true;
                        }
                    }
                    else
                    {
                        message = "注册失败";
                        return false;
                    }
                }

            }
            else
                return false;
        }
        public bool RegisterDel(long userid)
        {
            return userBLL.Delete(userid);
        }
        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        private bool RegValidate(string UserCode, string Sex, string Phone, string Password, string PayPassword, string inviteCode, out string message)
        {
            lgk.Model.tb_user recommendInfo = new lgk.Model.tb_user();

            if (UserCode.Trim() == "")
            {
                message = GetLanguage("PleaseNumber");//请输入会员编号

                return false;
            }
            //if (!PageValidate.checkUserCode(UserCode.Trim()))
            //{
            //    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("MemberNumber") + "');", true);//会员编号必须由6-10位的英文字母或数字组成
            //    message = GetLanguage("MemberNumber");//会员编号必须由6-10位的英文字母或数字组成
            //    return false;
            //}

            if (userBLL.GetUserID(UserCode.Trim()) > 0)
            {
                message = GetLanguage("Memberexists");//该会员编号已存在,请重新输入!
                return false;
            }

            if (Phone.Trim() == "")
            {
                message = "手机号码不能为空";//
                return false;
            }
            if (userBLL.GetUserIDByPhoneNum(Phone.Trim()) > 0)
            {
                message = "手机号码已存在,请重新输入";
                return false;
            }

            #region 密码验证
            if (Password.Trim() == "")
            {
                message = GetLanguage("PasswordISNull");//登录密码不能为空
                return false;
            }
            if (PayPassword.Trim() == "")
            {
                message = GetLanguage("SecondaryISNUll");//支付密码不能为空
                return false;
            }
            #endregion

            recommendInfo = userBLL.GetModel(userBLL.GetUserIDByInviteCode(inviteCode));//邀请码
            if (recommendInfo == null)
            {
                message = GetLanguage("invitecodeNotExist");//邀请码无效
                return false;
            }
            if (recommendInfo.IsOpend == 0)
            {
                message = GetLanguage("MemberISNull");//该会员尚未开通，不能作为推荐会员
                return false;
            }

            #region 推荐人验证
            //if (RecommendCode.Trim() == "")
            //{
            //    message = GetLanguage("ReferenceNumberIsnull");//推荐人编号不能为空
            //    return false;
            //}
            //else
            //{
            //    string reName = RecommendCode.Trim();
            //    recommendInfo = userBLL.GetModel(userBLL.GetUserID(reName));//推薦用户
            //    if (recommendInfo == null)
            //    {
            //        message = GetLanguage("featuredNotExist");//该推荐会员不存在
            //        return false;
            //    }
            //    if (recommendInfo.IsOpend == 0)
            //    {
            //        message = GetLanguage("MemberISNull");//该会员尚未开通，不能作为推荐会员
            //        return false;
            //    }
            //}

            #endregion
            message = "";
            return true;
        }
        //修改密码
        public bool UpdatePassword(string UserID, string OldPassword, string Password, string NewPassWord,string smscode, out string message)
        {
            if (validatePass(UserID, OldPassword, Password, NewPassWord, out message))
            {
                lgk.Model.tb_user model = userBLL.GetModel(Int64.Parse(UserID));

                if (model == null)
                {
                    message = "用户不存在";
                    return false;
                }

                if (OldPassword.Trim().ToUpper() != model.Password)
                {
                    message = GetLanguage("oldPassCorrect");//旧登录密码不正确
                    return false;
                }

                long validid = CheckSMSCode(model.PhoneNum, smscode, 4);
                if (validid == 0)  //关闭短信
                {
                    if (smscode != "123456")
                    {
                        message = "验证码错误";//登录密码修改成功
                        return false;
                    }
                }
                else if (validid < 0)
                {
                    message = "验证码错误";//登录密码修改成功
                    return false;
                }

                if (UpdateUserPwd(model.UserID, "Password", NewPassWord.Trim()) > 0)
                {
                    message = GetLanguage("PasswordChanged");//登录密码修改成功
                    return true;
                }
                else
                {
                    message = GetLanguage("Passwordfailed");//登录密码修改失败
                    return false;
                }

            }
            else
                return false;
        }
        //修改密码 设置
        public bool SetPassword(string UserID, string NewPassWord,string smscode, out string message)
        {
           // if (validatePass(UserID, OldPassword, Password, NewPassWord, out message))
            {
                lgk.Model.tb_user model = userBLL.GetModel(Int64.Parse(UserID));

                if (model == null)
                {
                    message = "用户不存在";
                    return false;
                }

                long validid = CheckSMSCode(model.PhoneNum, smscode, 7);
                if(validid == 0 )  //关闭短信
                {
                    if (smscode != "123456")
                    {
                        message = "验证码错误";//登录密码修改成功
                        return false;
                    }
                }
                else if(validid < 0)
                {
                    message = "验证码错误";//登录密码修改成功
                    return false;
                }

                if (UpdateUserPwd(model.UserID, "Password", NewPassWord.Trim()) > 0)
                {
                    message = GetLanguage("PasswordChanged");//登录密码修改成功
                    return true;
                }
                else
                {
                    message = GetLanguage("Passwordfailed");//登录密码修改失败
                    return false;
                }

            }
           
        }
        public bool validatePass(string UserCode, string OldPassword, string Password, string NewPassWord, out string message)
        {
            if (OldPassword.Trim() == "")
            {
                message = GetLanguage("oldPassEmpty");//旧登录密码不能为空
                return false;
            }

            if (Password.Trim() == "")
            {
                message = GetLanguage("NewPassEmpty");//新登录密码不能为空
                return false;
            }
            if (NewPassWord.Trim() == "")
            {
                message = "确认登录密码不能为空";
                return false;
            }

            if (Password.Trim() != NewPassWord.Trim())
            {
                message = GetLanguage("TwoPassIncorrect");//两次输入的密码不正确

                return false;
            }

            message = "";
            return true;
        }
        //支付密码
        public bool Payment(string UserID, string OldAlternate, string Alternate, string NewAlternate, string smscode,out string message)
        {
            if (AlternatePwd(UserID, OldAlternate, Alternate, NewAlternate, out message))
            {
                long _userid;
                long.TryParse(UserID, out _userid);
                lgk.Model.tb_user model = userBLL.GetModel(_userid);

                if (model == null)
                {
                    message = "用户不存在";
                    return false;
                }

                if (OldAlternate.Trim() != model.SecondPassword)
                {
                    message = "旧支付密码不正确";
                    return false;
                }

                long validid = CheckSMSCode(model.PhoneNum, smscode, 5);
                if (validid == 0)  //关闭短信
                {
                    if (smscode != "123456")
                    {
                        message = "验证码错误";//登录密码修改成功
                        return false;
                    }
                }
                else if (validid < 0)
                {
                    message = "验证码错误";//登录密码修改成功
                    return false;
                }

                if (UpdateUserPwd(model.UserID, "SecondPassword", NewAlternate.Trim()) > 0)
                {
                    message = GetLanguage("PaymentPwd");//支付密码修改成功
                    return true;
                }
                else
                {
                    message = GetLanguage("FailedPayPwd");//支付密码修改失败
                    return false;
                }

            }
            else
                return false;
        }
        //支付密码
        public bool SetPayment(string UserID, string NewAlternate, string smscode,out string message)
        {
          //  if (AlternatePwd(UserID, NewAlternate, out message))
            {
                long _userid;
                long.TryParse(UserID, out _userid);
                lgk.Model.tb_user model = userBLL.GetModel(_userid);

                if (model == null)
                {
                    message = "用户不存在";
                    return false;
                }

                long validid = CheckSMSCode(model.PhoneNum, smscode, 8);
                if (validid == 0)  //关闭短信
                {
                    if (smscode != "123456")
                    {
                        message = "验证码错误";//登录密码修改成功
                        return false;
                    }
                }
                else if (validid < 0)
                {
                    message = "验证码错误";//登录密码修改成功
                    return false;
                }


                if (UpdateUserPwd(model.UserID, "SecondPassword", NewAlternate.Trim()) > 0)
                {
                    message = GetLanguage("PaymentPwd");//支付密码修改成功
                    return true;
                }
                else
                {
                    message = GetLanguage("FailedPayPwd");//支付密码修改失败
                    return false;
                }

            }
          //  else
             //   return false;
        }
        public bool AlternatePwd(string UserCode, string OldAlternate, string Alternate, string NewAlternate, out string message)
        {
            if (OldAlternate.Trim() == "")
            {
                message = GetLanguage("oldpayment");//旧支付密码不能为空
                return false;
            }

            if (Alternate.Trim() == "")
            {
                message = GetLanguage("SecondaryISNUll");//支付密码不能为空
                return false;
            }

            if (Alternate.Trim() != NewAlternate.Trim())
            {
                message = GetLanguage("TwoPassIncorrect");//两次输入的密码不正确

                return false;
            }

            message = "";
            return true;
        }

        //添加好友
        public bool AddFriend(string userid, string friendCode, out string usercode, out long IMFriendID, out string message)
        {
            usercode = string.Empty;
            IMFriendID = 0;

            long _userid = 0;
            Int64.TryParse(userid, out _userid);
            var user = userBLL.GetModel(_userid);
            if (user == null)
            {
                message = "用户ID不存在";
                return false;
            }

            var friendmodel = userBLL.GetModel(userBLL.GetUserID(friendCode));
            if (friendmodel == null)
            {
                message = "好友用户编号不存在";
                return false;
            }

            if (_userid == friendmodel.UserID)
            {
                message = "不能添加自己为好友";
                return false;
            }

            var exmodel = imFriendBLL.GetModel(_userid, friendmodel.UserID);
            if (exmodel != null)
            {
                message = "好友已存在";
                return false;
            }

            lgk.Model.tb_IMFriend model = new lgk.Model.tb_IMFriend();
            model.AddTime = DateTime.Now;
            model.UserID = _userid;
            model.UserCode = user.UserCode;
            model.FriendID = friendmodel.UserID;
            model.FriendCode = friendmodel.UserCode;
            IMFriendID = imFriendBLL.Add(model);

            usercode = user.UserCode;
            message = "添加好友成功";
            return true;
        }
        //删除好友
        public bool DelFriend(long id, out string message)
        {
            imFriendBLL.Delete(id);

            message = "删除好友成功";
            return true;
        }
        //获取删除好友 的ID
        public long GetFriendID(string userid, string friendCode, out string usercode, out string message)
        {
            long _userid = 0;
            Int64.TryParse(userid, out _userid);

            usercode = userBLL.GetUserCode(_userid);
            if (string.IsNullOrEmpty(usercode))
            {
                message = "用户ID不存在";
                return 0;
            }

            long frienduserid = userBLL.GetUserID(friendCode);
            if (frienduserid == 0)
            {
                message = "好友用户编号不存在";
                return 0;
            }

            long ID = imFriendBLL.GetID(_userid, frienduserid);
            if (ID == 0)
            {
                message = "删除的好友不存在";
                return 0;
            }

            message = "删除好友成功";
            return ID;
        }

        //个人信息
        public object Personal(long userid, out string message)
        {
            lgk.Model.tb_user userInfo = userBLL.GetModel(userid);

            #region 基本信息

            SortedDictionary<string, object> values = new SortedDictionary<string, object>();
            values.Add("UserID", userInfo.UserID);
            values.Add("UserCode", userInfo.UserCode);
            values.Add("Gender", userInfo.Gender);
            values.Add("PhoneNum", userInfo.PhoneNum);
            values.Add("NiceName", userInfo.NiceName);
            values.Add("Pic", string.IsNullOrEmpty(userInfo.User009) || userInfo.User009 == null ? "" : WebHelper.HttpDomain + userInfo.User009);//头像
            values.Add("TradingAddr", userInfo.User010);//释放币交易地址
            var qqlist = qqBLL.GetModelList("");
            values.Add("ServiceAccount", qqlist.Select(s => new { s.ServiceName, ServiceNum = s.QQnum }));
            values.Add("RecNum", userInfo.User003);
            values.Add("TeamNum", userInfo.User015.ToString("0"));
            values.Add("TeamAchievement", userInfo.User001.ToString("0"));
            #endregion
            message = "";
            return values;
        }
        //个人信息
        public object FriendPersonal(long userid, string usercode, out string message)
        {
            lgk.Model.tb_user userInfo = userBLL.GetModel(userBLL.GetUserID(usercode));
            var friend = imFriendBLL.GetModelList("((UserID = " + userid + " and FriendID = " + userInfo.UserID + ") or (FriendID = " + userid + " and UserID = " + userInfo.UserID + "))");
            #region 基本信息

            SortedDictionary<string, object> values = new SortedDictionary<string, object>();
            values.Add("UserID", userInfo.UserID);
            values.Add("UserCode", userInfo.UserCode);
            values.Add("Gender", userInfo.Gender);
            values.Add("PhoneNum", userInfo.PhoneNum);
            values.Add("NiceName", userInfo.NiceName);
            values.Add("Pic", string.IsNullOrEmpty(userInfo.User009) || userInfo.User009 == null ? "" : WebHelper.HttpDomain + userInfo.User009);//头像
            values.Add("IsFriend", friend.Count > 0 ? 1 : 0);
            #endregion
            message = "";
            return values;
        }
        //修改个人信息
        public bool UpdatePersonal(long userid, string type, string value, out string message)
        {

            if (Information(userid, type, value, out message))
            {
                lgk.Model.tb_user userInfo = userBLL.GetModel(userid);
                if (userInfo == null)
                {
                    message = "用户ID不存在";
                    return false;
                }
                if (type == "1")
                {
                    if (Update(userInfo.UserID, "NiceName", "", value.Trim()) > 0)
                    {
                        message = "修改昵称成功";
                        return true;
                    }
                    else
                    {
                        message = "修改昵称失败";
                        return false;
                    }

                }
                else if (type == "2")
                {
                    if (Update(userInfo.UserID, "Gender", "", value.Trim()) > 0)
                    {
                        message = "修改性别成功";
                        return true;
                    }
                    else
                    {
                        message = "修改性别失败";
                        return false;
                    }
                }
                else if (type == "3") //修改头像
                {
                    if (Update(userInfo.UserID, "user009", "", value.Trim()) > 0)
                    {
                        message = "修改头像成功";
                        return true;
                    }
                    else
                    {
                        message = "修改头像失败";
                        return false;
                    }
                }
            }
            message = "修改失败";
            return false;
        }
        public bool Information(long userid, string type, string value, out string message)
        {

            if (type.Trim() == "")
            {
                message = "类型不能为空";
                return false;
            }

            if (value.Trim() == "")
            {
                message = "值不能为空";
                return false;
            }
            message = "";
            return true;
        }
        //好友列表
        public object FriendList(long userid)
        {
            var tb = imFriendBLL.GetFriendList(userid);
            var list = FriendsToList(tb.Tables[0]);
            return list;
        }
        //队友
        public object TeamList(long userid)
        {
            var tb = imFriendBLL.GetTeamList(userid);
            var list = TeamsToList(tb.Tables[0]);
            return list;
        }

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FriendListModel> FriendsToList(DataTable dt)
        {
            List<FriendListModel> modelList = new List<FriendListModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FriendListModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new FriendListModel();
                    model.UserID = dt.Rows[n]["UserID"] == null ? "" : dt.Rows[n]["UserID"].ToString();
                    model.FriendCode = dt.Rows[n]["FriendCode"] == null ? "" : dt.Rows[n]["FriendCode"].ToString();
                    model.Pic =
                        dt.Rows[n]["Pic"] == null || dt.Rows[n]["Pic"].ToString() == "" ? "" : WebHelper.HttpDomain + dt.Rows[n]["Pic"].ToString();
                    model.NiceName = dt.Rows[n]["NiceName"] == null ? "" : dt.Rows[n]["NiceName"].ToString();
                    model.PhoneNum = dt.Rows[n]["PhoneNum"] == null ? "" : dt.Rows[n]["PhoneNum"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TeamListModel> TeamsToList(DataTable dt)
        {
            List<TeamListModel> modelList = new List<TeamListModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TeamListModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TeamListModel();
                    model.TeamCode = dt.Rows[n]["TeamCode"] == null ? "" : dt.Rows[n]["TeamCode"].ToString();
                    model.Speed = dt.Rows[n]["Speed"] == null ? "" : dt.Rows[n]["Speed"].ToString();
                    model.TeamNum = dt.Rows[n]["TeamNum"] == null ? "" : dt.Rows[n]["TeamNum"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        public bool GetInviteCode(long userid, out object code, out string message)
        {
            string inviteinfo = string.Empty, inviterule = string.Empty, appdownurl,recurl;
            

            code = "";
            message = "";
            lgk.Model.tb_user user = userBLL.GetModel(userid);
            if (user == null)
            {
                message = "账户不存在";
                return false;
            }
            recurl = "/user/LinkRegist.aspx?i=" + user.UserID;
            recurl = WebHelper.HttpDomain + recurl;

            appdownurl = "/appdown.aspx";
            appdownurl = WebHelper.HttpDomain + appdownurl;

            code = user.User008.ToUpper();

            lgk.BLL.tb_InviteInfo inviteInfoBLL = new tb_InviteInfo();
            var model = inviteInfoBLL.GetModel(1);
            if (model != null)
            {
                inviteinfo = model.InviteInfo
                    .Replace("{昵称}", user.NiceName)
                    .Replace("{邀请码}", user.User008.ToUpper())
                    .Replace("{APP下载链接}", appdownurl)
                    .Replace("{推广链接}", recurl);
                inviterule = model.InviteRule;
            }

            SortedDictionary<string, object> values = new SortedDictionary<string, object>();
            values.Add("invitecode", code);
            values.Add("inviteinfo", inviteinfo);
            values.Add("inviterule", inviterule);
            values.Add("appdownurl", recurl);

            code = values;

            return true;
        }
        public bool ExistsInviteCode(string inviteCode, out string message)
        {
            message = "";
            long userid = userBLL.GetUserIDByInviteCode(inviteCode);
            if (userid <= 0)
            {
                message = "账户不存在";
                return false;
            }
            return true;
        }
        //绑定第三方交易平台钱包地址
        public bool BindWalletAddress(long userid, string address, out string message)
        {
            message = "";
            var model = userBLL.GetModel(userid);
            if (model == null)
            {
                message = "账户不存在";
                return false;
            }
            model.User010 = address;
            userBLL.Update(model);

            return true;
        }

        #region 获取Token
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <param name="PhoneCode"></param>
        /// <param name="userid"></param>
        /// <param name="tokencode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public UserTokenModel Login(string UserCode, string Password, string PhoneCode,int LoginMode, out bool flag, out string message)
        {
            long vildid =0;
            UserTokenModel model = new UserTokenModel();
            flag = false;
            message = string.Empty;

            lgk.Model.tb_user user = userBLL.GetModel(GetUserID(UserCode.Trim()));
            if (user == null)
            {
                message = GetLanguage("AccountError");//账号或密码错误
                return model;
            }
            else if (LoginMode == 1) 
            {
                if (user.Password.Length == 32 && Password.Trim().Length == 32)
                {
                    if (user.Password != Password.Trim())
                    {
                        message = GetLanguage("AccountError");//账号或密码错误
                        return model;
                    }
                }
                else
                {
                    //安卓端注册时偶尔会出现传递的md5密码少第一个字符，只传递了31个字符，为了兼容多端登录需要做一下特殊处理
                    string pwd = user.Password, loginPwd = Password.Trim();
                    if (user.Password.Length == 32)     pwd = user.Password.Substring(1, user.Password.Length - 1);
                    if (Password.Trim().Length == 32)   loginPwd = Password.Substring(1, loginPwd.Length - 1);
                    if (pwd != loginPwd)
                    {
                        message = GetLanguage("AccountError");//账号或密码错误
                        return model;
                    }
                }
            }
            else if (LoginMode == 2)
            {
                vildid = CheckSMSCode(user.PhoneNum, PhoneCode, 2);
                if (vildid < 0)
                {
                    message = "验证码错误";
                    return model;
                }
            }
            else if (user.IsLock == 1)
            {
                message = "账户已冻结，登录失败";
                return model;
            }
          
                //lgk.Model.SMS smsModel = smsBLL.GetModelByPhoneAndCode(user.PhoneNum, PhoneCode);
                //if(smsModel == null)
                //{
                //    message = "短信验证码无效";
                //}
                //else if(smsModel.IsValid == 1)
                //{
                //    message = "短信验证码无效";
                //}
                //else if(smsModel.ValidTime < DateTime.Now)
                //{
                //    message = "短信验证码已过期";
                //}
                //else
                //{
                    //更新用户当前有效的token为无效
                    logintokenBLL.UpdateIsValid(user.UserID, 0, 1);
                    //生成
                    string code = Guid.NewGuid().ToString().Replace("-", "") + new Random().Next(1111, 9999);
                    lgk.Model.tb_LoginToken tokenmodel = new lgk.Model.tb_LoginToken();
                    tokenmodel.UserID = user.UserID;
                    tokenmodel.SmsCode = PhoneCode;
                    tokenmodel.TokenCode = code;
                    tokenmodel.AddTime = DateTime.Now;
                    tokenmodel.EndTime = DateTime.Now.AddHours(24);
                    tokenmodel.IsValid = 0;//0：有效，1：无效
                    long lID = logintokenBLL.Add(tokenmodel);
                    if (lID > 0)
                    {
                        model.UserID = user.UserID;
                        model.Token = code;
                        model.UserCode = user.UserCode;
                        model.Hx_password = user.ThreePassword;
                        if (!string.IsNullOrEmpty(user.IdenCode))
                        {
                            model.IsCardValid = 1;//身份已验证
                        }
                        else
                        {
                            model.IsCardValid = 0;//身份未验证
                        }
                        flag = true;
                        message = "登录成功";
                    }
                    else
                    {
                        message = "登录失败";
                    }
                //}
          
            return model;
        } 
        #endregion
        public object GetGiveCalcPower()
        {
            int calcpower = getParamInt("RegGiveCalcPower");
            SortedDictionary<string, object> values = new SortedDictionary<string, object>();
            values.Add("calcpower", calcpower);
            return values;
        }

        public bool SaveIdenCode(long userid,string idencode,string idenname)
        {
            var model = userBLL.GetModel(userid);
            if(model != null)
            {
                model.IdenCode = idencode;
                model.TrueName = idenname;
                userBLL.Update(model);

                return true;
            }
            return false;
        }

        public int IsValidIdenCode(long userid, out string message)
        {
            var usermodel = userBLL.GetModel(userid);
            if (usermodel != null)
            {
                if (string.IsNullOrEmpty(usermodel.IdenCode))
                {
                    
                    message = "身份证尚未验证";
                    return 0;//身份未验证
                }
                else
                {
                    message = "身份证已验证";
                    return 1;
                }
            }
            else
            {
                message = "用户不存在";
                return -1;//身份未验证
            }
        }

    }
}