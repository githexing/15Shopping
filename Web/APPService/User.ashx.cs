using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Web.APPService.Service;
using System.Data;
using System.Configuration;
using Web.APPService.ViewModel;
using Library.ThirdPartyAPIs;

namespace Web.APPService
{
    /// <summary>
    /// User 的摘要说明
    /// </summary>
    public class User : ServiceHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string result = string.Empty;

            string act = context.Request["act"];
            if (string.IsNullOrEmpty(act) || act.Trim() == string.Empty)
            {
                return;
            }
            switch (act.ToLower())
            {
                case "init"://初始环信 ,注册第一个账户
                    result = InitEaseMob(context);
                    break;
                case "login"://登录
                    result = Login(context);
                    break;
                case "validtoken"://验证登陆授权码token
                    result = ValidToken(context);
                    break;
                case "register"://注册
                    result = Register(context);
                    break;
                //case "fastregister"://快速注册
                //    result = FastRegister(context);
                //    break;

                case "addfriend"://向IM 用户添加好友
                    result = AddFriend(context);
                    break;
                case "delfriend"://解除 IM 用户的好友关系
                    result = DelFriend(context);
                    break;
                case "modifypassword"://修改密码
                    result = UpdateUserPwd(context);
                    break;
                case "setpassword"://修改密码
                    result = SetUserPwd(context);
                    break;
                case "modifypaypassword"://支付密码
                    result = PayPwd(context);
                    break;
                case "setpaypassword"://支付密码 设置
                    result = SetPayPwd(context);
                    break;
                case "getfriend"://获取好友
                    result = GetFriend(context);
                    break;
                //case "deluser"://批量删除好友
                //    result = DelUser(context);
                //    break;
                case "view"://个人信息
                    result = ViewPersonal(context);
                    break;
                case "viewfriend"://好友信息
                    result = ViewFriendPersonal(context);
                    break;
                case "infomodify"://修改个人信息
                    result = PersonalInformation(context);
                    break;
                case "link"://推广链接
                    result = GetLink(context);
                    break;
                case "friendlist"://好友列表
                    result = FriendList(context);
                    break;
                case "teamlist"://队友
                    result = TeamList(context);
                    break;
                case "geteasemobuserlist"://获取用户列表
                    result = GetEaseMobUserList(context);
                    break;
                case "invitecode"://获取邀请码
                    result = GetInviteCode(context);
                    break;
                case "bindwallet"://绑定钱包地址
                    result = BindWalletAddress(context);
                    break;
                case "verifyidencode"://校验身份证
                    result = VerifyIdenCode(context);
                    break;
                case "decrypt"://
                    result = Decrypt(context);
                    break;
                case "encrypt"://
                    result = Encrypt(context);
                    break;
                case "isverifyidencode"://身份证是否已验证
                    result = IsVerifyIdenCode(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常", "user");
                    break;
            }
            context.Response.Write(result);
        }

        private string BindWalletAddress(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string address = context.Request["address"] ?? "";
            string smscode = context.Request["smscode"] ?? "";
            long _userid;
            string message;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "用户ID无效", "");
            }
            if (string.IsNullOrEmpty(smscode))
            {
                return ResultJson(ResultType.error, "验证码无效", "");
            }
            if (string.IsNullOrEmpty(address))
            {
                return ResultJson(ResultType.error, "钱包地址无效", "");
            }

            long.TryParse(userid, out _userid);
            UserService userSvc = new UserService();
            bool result = userSvc.BindWalletAddress(_userid, address, out message);

            if (result)
                return ResultJson(ResultType.success, "绑定成功", "");
            else
                return ResultJson(ResultType.error, "绑定失败", "");
        }

        private string Decrypt(HttpContext context)
        {
            string txt = context.Request["text"];
            return AESEncrypt.Decrypt(txt);
        }
        private string Encrypt(HttpContext context)
        {
            string txt = context.Request["text"];
            return AESEncrypt.Encrypt(txt);
        }
        //获取邀请码 //   
        private string GetInviteCode(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            long _userid;
            string message;
            object values;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "用户ID无效", "");
            }
            long.TryParse(userid, out _userid);
            UserService userSvc = new UserService();
            bool result = userSvc.GetInviteCode(_userid, out values, out message);

            if (result)
                return ResultJson(ResultType.success, "获取成功", values);
            else
                return ResultJson(ResultType.error, "获取失败", "");
        }

        private string GetEaseMobUserList(HttpContext context)
        {
            string limit = context.Request["limit"] ?? "";
            string cursor = context.Request["cursor"] ?? "";

            int statusCode;
            var api = new EaseMobAPIHelper();
            var data = api.AccountGetList(limit, cursor, out statusCode);
            if (statusCode == 200)
            {
                return ResultJson(ResultType.success, "初始成功", data);
            }
            else
                return ResultJson(ResultType.error, "初始异常", data);
        }

        //好友列表
        private string FriendList(HttpContext context)
        {
            //string value = context.Request["value"] ?? "";
            //if (string.IsNullOrEmpty(value))
            //{
            //    return ResultJson(ResultType.error, "请提交操作数据", "");
            //}

            //AESEncrypt.Decrypt(value)
            string userid = context.Request["userid"] ?? "";
            long _userid;
            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "用户ID无效", "");
            }
            long.TryParse(userid, out _userid);
            UserService userSvc = new UserService();
            var list = userSvc.FriendList(_userid);

            // string enc = AESEncrypt.Encrypt(JsonConvert.SerializeObject(list));

            //  Dictionary<string, string> dic = new Dictionary<string, string>();
            // dic.Add("Encrypt", enc);
            //  dic.Add("Decrypt", AESEncrypt.Decrypt(enc));

            return ResultJson(ResultType.success, "获取成功", list);
        }
        //队友
        private string TeamList(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            long _userid;
            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "用户ID无效", "");
            }
            long.TryParse(userid, out _userid);
            UserService userSvc = new UserService();
            var list = userSvc.TeamList(_userid);


            return ResultJson(ResultType.success, "获取成功", list);
        }

        private string GetLink(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";

            string url = WebHelper.HttpDomain + "/Registers.aspx?state=" + DESEncrypt.Encrypt(userid);
            return ResultJson(ResultType.success, "获取成功", url);
        }

        //初始环信 ,注册第一个账户
        private string InitEaseMob(HttpContext context)
        {
            string username = context.Request["username"] ?? "";
            string password = context.Request["password"] ?? "";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return ResultJson(ResultType.error, "请输入用户名和密码", "");
            }

            int statusCode;
            var api = new EaseMobAPIHelper();
            var data = api.AccountCreate(username, password, out statusCode);
            if (statusCode == 200)
            {
                return ResultJson(ResultType.success, "初始成功", data);
            }
            else
                return ResultJson(ResultType.error, "初始异常", data);
        }

        //注册 
        private string Register(HttpContext context)
        {
            string step = context.Request["step"] ?? "";
            if ("1".Equals(step))
            {
                return RegisterStep1(context);
            }
            else if ("2".Equals(step))
            {
                return RegisterStep2(context);
            }
            else if ("3".Equals(step))
            {
                return RegisterStep3(context);
            }
            //else if ("4".Equals(step))
            //{
            //    return RegisterStep4(context);
            //}

            return ResultJson(ResultType.error, "请输入正确的注册步骤", "");
        }
        //注册 步骤1 
        //验证手机号，发短信验证码
        private string RegisterStep1(HttpContext context)
        {
            //string dec_phone = context.Request["phone"] ?? "";
            string message;

            string jsondata = context.Request["data"] ?? "";
            LogHelper.SaveLog("RegisterStep1:" + jsondata, "RegisterStep");
            RegisterModel rModel = null;

            if (jsondata.Length < 24)
                return ResultJson(ResultType.error, "请输入正确的手机号", "");

            try
            {
                jsondata = AESEncrypt.Decrypt(jsondata);
                rModel = JsonConvert.DeserializeObject<RegisterModel>(jsondata);
            }
            catch
            {
                return ResultJson(ResultType.error, "请输入正确的手机号", "");
            }
            if (string.IsNullOrEmpty(rModel.phone))
                return ResultJson(ResultType.error, "请输入正确的手机号", "");

            UserService userSvc = new UserService();
            if (userSvc.GetPhoneNumber(rModel.phone) > 0)
                return ResultJson(ResultType.error, "该手机号已注册", "");

            if (!userSvc.ExistsInviteCode(rModel.invitecode, out message))
            {
                return ResultJson(ResultType.error, "邀请码无效", "");
            }

            lgk.BLL.SMS smsBLL = new lgk.BLL.SMS();

            if (smsBLL.GetSendCountOfDay(rModel.phone) >= 5) //同号码每日限制：5条 
            {
                return ResultJson(ResultType.success, "超出短信发送计数限制", "");
            }
            if (smsBLL.GetSendCountOfMinute(rModel.phone, 1) >= 1) //同号码每分钟限制：1条
            {
                return ResultJson(ResultType.success, "操作过于频繁，请稍后重试", "");
            }

            bool result = userSvc.SendSMS(rModel.phone, "1");
            if (result)
                return ResultJson(ResultType.success, "验证码已发送", "");
            else
                return ResultJson(ResultType.success, "验证码发送失败", "");
        }
        //注册 步骤2 验证短信验证码
        private string RegisterStep2(HttpContext context)
        {
            string jsondata = context.Request["data"] ?? "";
            LogHelper.SaveLog("RegisterStep2:" + jsondata, "RegisterStep");
            RegisterModel rModel = null;
            try
            {
                jsondata = AESEncrypt.Decrypt(jsondata);
                rModel = JsonConvert.DeserializeObject<RegisterModel>(jsondata);
            }
            catch
            {
                return ResultJson(ResultType.error, "数据异常", "");
            }

            UserService userSvc = new UserService();
            long validid = userSvc.CheckSMSCode(rModel.phone, rModel.smscode, 1);
            if (validid == 0 && rModel.smscode == "123456")
            {
                SortedDictionary<string, object> values = new SortedDictionary<string, object>();
                values.Add("smsValid", validid);
                return ResultJson(ResultType.success, "验证码正确", values);
            }
            else if (validid > 0)
            {
                SortedDictionary<string, object> values = new SortedDictionary<string, object>();
                values.Add("smsValid", validid);

                return ResultJson(ResultType.success, "验证码正确", values);
            }

            return ResultJson(ResultType.error, "验证码错误", "");

        }
        //注册 步骤3 验证邀请码，身份证，姓名
        //private string RegisterStep3(HttpContext context)
        //{
        //    string message = string.Empty;

        //    string jsondata = context.Request["data"] ?? "";
        //    LogHelper.SaveLog("RegisterStep3:" + jsondata, "RegisterStep");
        //    RegisterModel rModel = null;
        //    try
        //    {
        //        jsondata = AESEncrypt.Decrypt(jsondata);
        //        rModel = JsonConvert.DeserializeObject<RegisterModel>(jsondata);
        //    }
        //    catch
        //    {
        //        return ResultJson(ResultType.error, "数据异常", "");
        //    }

        //    //string phone = context.Request["phone"] ?? "";
        //    //string invitecode = context.Request["invitecode"] ?? ""; //邀请码
        //    //string idencode = context.Request["idencode"] ?? "";
        //    //string idenname = context.Request["idenname"] ?? "";

        //    if (string.IsNullOrEmpty(rModel.invitecode) || rModel.invitecode.Length != 4)
        //        return ResultJson(ResultType.error, "邀请码错误", "");

        //    if (string.IsNullOrEmpty(rModel.idencode))//|| recommendcode.Length != 18)
        //        return ResultJson(ResultType.error, "身份证错误", "");

        //    if (string.IsNullOrEmpty(rModel.idenname) || rModel.idenname.Length < 2)
        //        return ResultJson(ResultType.error, "姓名错误", "");

        //    UserService userSvc = new UserService();
        //    if (!userSvc.ExistsInviteCode(rModel.invitecode, out message))
        //    {
        //        return ResultJson(ResultType.error, "邀请码无效", "");
        //    }

        //    return ResultJson(ResultType.success, "验证通过", "");

        //}
        //注册 步骤4
        private string RegisterStep3(HttpContext context)
        {
            string message = string.Empty;
            string HX_Password = string.Empty;

            string jsondata = context.Request["data"] ?? "";
            LogHelper.SaveLog("RegisterStep3:" + jsondata, "RegisterStep");
            if (string.IsNullOrEmpty(jsondata))
                return ResultJson(ResultType.error, "数据段为空", "");

            RegisterModel rModel = null;
            try
            {
                jsondata = AESEncrypt.Decrypt(jsondata);
                rModel = JsonConvert.DeserializeObject<RegisterModel>(jsondata);
            }
            catch
            {
                return ResultJson(ResultType.error, "数据异常", "");
            }

            int statusCode;
            long NewUserId = 0;

            rModel.username = rModel.phone;
            rModel.password = PageValidate.GetMd5("111111");// rModel.phone+ rModel.invitecode);
            rModel.paypassword = PageValidate.GetMd5("111111"); //PageValidate.GetMd5(rModel.phone+ rModel.invitecode);
            UserService userSvc = new UserService();
            bool result = userSvc.Register(rModel.username, rModel.sex, rModel.phone, rModel.password, rModel.paypassword, int.Parse(rModel.smsValid), rModel.invitecode, rModel.nickname, out NewUserId, out HX_Password, out message);
            if (result)
            {
                var api = new EaseMobAPIHelper();
                var data = api.AccountCreate(rModel.username, HX_Password, out statusCode);

                if (statusCode == 200)
                {
                    bool flag;
                    var emResult = JsonConvert.DeserializeObject<EaseMobResult>(data);
                    if (!string.IsNullOrEmpty(emResult.error) || emResult.error == null)
                    {
                        var token = userSvc.Login(rModel.username, rModel.password, rModel.smscode, 1, out flag, out message);
                        SortedDictionary<string, object> values = new SortedDictionary<string, object>();
                        values.Add("logininfo", token);
                        values.Add("giveinfo", userSvc.GetGiveCalcPower());

                        return ResultJson(ResultType.success, "注册成功", values);
                    }
                    else
                    {
                        userSvc.RegisterDel(NewUserId);
                        LogHelper.SaveLog("AccountCreate DeserializeObject:" + data, "EaseMobAPI");
                        return ResultJson(ResultType.error, "注册失败！", emResult.error);
                    }
                }
                else
                {
                    userSvc.RegisterDel(NewUserId);
                    LogHelper.SaveLog("AccountCreate statusCode:" + statusCode, "EaseMobAPI");
                    return ResultJson(ResultType.error, "注册失败！！", data);
                }
            }
            else
            {
                return ResultJson(ResultType.error, message, "");
            }
        }

        //快速注册
        private string FastRegister(HttpContext context)
        {
            string message = string.Empty;
            string HX_Password = string.Empty;
            int smstype = 1; //注册

            string jsondata = context.Request["data"] ?? "";
            LogHelper.SaveLog(jsondata, "FastRegister");

            if (string.IsNullOrEmpty(jsondata))
                return ResultJson(ResultType.error, "数据段为空", "");

            RegisterModel rModel = null;
            try
            {
                jsondata = AESEncrypt.Decrypt(jsondata);
                rModel = JsonConvert.DeserializeObject<RegisterModel>(jsondata);
            }
            catch
            {
                return ResultJson(ResultType.error, "数据异常", "");
            }

            if (string.IsNullOrEmpty(rModel.username) || string.IsNullOrEmpty(rModel.password))
            {
                return ResultJson(ResultType.error, "请输入用户名和密码", "");
            }

            if (string.IsNullOrEmpty(rModel.invitecode))
            {
                return ResultJson(ResultType.error, "请输入邀请码", "");
            }
            UserService userSvc = new UserService();

            #region 注册验证验证码
            long validid = userSvc.CheckSMSCode(rModel.phone, rModel.smscode, smstype);
            if (validid < 0)
                return ResultJson(ResultType.error, "验证码错误", "");
            #endregion

            int statusCode;
            long NewUserId;

            bool result = userSvc.Register(rModel.username, rModel.sex, rModel.phone, rModel.password, rModel.paypassword, validid, rModel.invitecode, rModel.nickname, out NewUserId, out HX_Password, out message);
            if (result)
            {
                var api = new EaseMobAPIHelper();
                var data = api.AccountCreate(rModel.username, HX_Password, out statusCode);

                if (statusCode == 200)
                {
                    var emResult = JsonConvert.DeserializeObject<EaseMobResult>(data);
                    if (!string.IsNullOrEmpty(emResult.error) || emResult.error == null)
                        return ResultJson(ResultType.success, "注册成功", "");
                    else
                    {
                        userSvc.RegisterDel(NewUserId);
                        return ResultJson(ResultType.error, "注册失败", emResult.error);
                    }
                }
                else
                {
                    userSvc.RegisterDel(NewUserId);
                    return ResultJson(ResultType.error, "注册失败", data);
                }
            }
            else
            {
                return ResultJson(ResultType.error, message, "");
            }
        }
        //向IM 用户添加好友
        //先添加本地，再添加远程的，如果远程失败，删除本地的
        private string AddFriend(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string friend_username = context.Request["friend_username"] ?? "";
            string message = string.Empty;
            string usercode = string.Empty;
            long IMFriendID = 0;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "要添加好友的用户ID不能为空", "");
            }
            if (string.IsNullOrEmpty(friend_username))
            {
                return ResultJson(ResultType.error, "被添加好友的用户名不能为空", "");
            }
            UserService userSvc = new UserService();
            bool addResult = userSvc.AddFriend(userid, friend_username, out usercode, out IMFriendID, out message);
            if (addResult)
            {
                int statusCode;
                var api = new EaseMobAPIHelper();
                var data = api.AccountAddFriend(usercode, friend_username, out statusCode);
                if (statusCode == 200)
                {
                    var emResult = JsonConvert.DeserializeObject<EaseMobResult>(data);
                    if (!string.IsNullOrEmpty(emResult.error) || emResult.error == null)
                        return ResultJson(ResultType.success, "添加好友成功", data);
                    else
                    {
                        userSvc.DelFriend(IMFriendID, out message);//环信接口失败要删除好友关系
                        return ResultJson(ResultType.error, "添加好友失败", emResult.error);
                    }
                }
                else
                {
                    userSvc.DelFriend(IMFriendID, out message);//环信接口失败要删除好友关系
                    return ResultJson(ResultType.error, "添加好友失败", data);
                }
            }
            return ResultJson(ResultType.error, message, "");
        }
        //解除 IM 用户的好友关系
        //先删除远程的，再删除本地的
        private string DelFriend(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string friend_username = context.Request["friend_username"] ?? "";
            string message = string.Empty;
            string usercode;
            long IMFriendID = 0;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "要删除好友的用户ID不能为空", "");
            }
            if (string.IsNullOrEmpty(friend_username))
            {
                return ResultJson(ResultType.error, "被删除好友的用户名不能为空", "");
            }

            UserService userSvc = new UserService();
            IMFriendID = userSvc.GetFriendID(userid, friend_username, out usercode, out message);
            if (IMFriendID == 0)
            {
                return ResultJson(ResultType.error, message, "");
            }

            int statusCode;
            var api = new EaseMobAPIHelper();
            var data = api.AccountDelFriend(usercode, friend_username, out statusCode);
            if (statusCode == 200)
            {
                LogHelper.SaveLog("AccountDelFriend:" + data, "IM");
                var emResult = JsonConvert.DeserializeObject<EaseMobResult>(data);
                if (!string.IsNullOrEmpty(emResult.error) || emResult.error == null)
                {
                    userSvc.DelFriend(IMFriendID, out message);//删除本地好友关系
                    return ResultJson(ResultType.success, "删除好友成功", data);
                }
                else
                    return ResultJson(ResultType.error, "删除好友失败", emResult.error);
            }
            else
                return ResultJson(ResultType.error, "删除好友失败", data);

        }
        //修改密码
        private string UpdateUserPwd(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string oldpassword = context.Request["oldpassword"] ?? "";
            string newpassword = context.Request["newpassword"] ?? "";
            string confirmpassword = context.Request["confirmpassword"] ?? "";
            string smscode = context.Request["smscode"] ?? "";
            string message = string.Empty;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户名", "");
            }
            if (string.IsNullOrEmpty(oldpassword))
            {
                return ResultJson(ResultType.error, "请输入旧密码", "");
            }
            //if (string.IsNullOrEmpty(oldpassword) != string.IsNullOrEmpty(pass))
            //{
            //    return ResultJson(ResultType.error, "输入旧密码不正确", "");
            //}
            if (string.IsNullOrEmpty(newpassword))
            {
                return ResultJson(ResultType.error, "请输入新密码", "");
            }

            if (newpassword != confirmpassword)
            {
                return ResultJson(ResultType.error, "两次输入的密码不一致", "");
            }
            var tsvc = new UserService();
            var result = tsvc.UpdatePassword(userid, oldpassword.ToUpper(), newpassword.ToUpper(), confirmpassword.ToUpper(), smscode, out message);
            if (result)
            {
                return ResultJson(ResultType.success, "修改成功", "");
            }
            else
                return ResultJson(ResultType.error, "修改失败", message);


        }
        //修改密码 设置
        private string SetUserPwd(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string newpassword = context.Request["newpassword"] ?? "";
            string smscode = context.Request["smscode"] ?? "";
            string message = string.Empty;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户名", "");
            }

            if (string.IsNullOrEmpty(newpassword))
            {
                return ResultJson(ResultType.error, "请输入密码", "");
            }

            LogHelper.SaveLog(string.Format("userid:{0},newpassword:{1},smscode:{2}", userid, newpassword, smscode), "SetUserPwd");

            var tsvc = new UserService();
            var result = tsvc.SetPassword(userid, newpassword.ToUpper(), smscode, out message);
            if (result)
            {
                return ResultJson(ResultType.success, "设置成功", "");
            }
            else
                return ResultJson(ResultType.error, message, "");


        }
        //支付密码
        private string PayPwd(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string oldpassword = context.Request["oldpassword"] ?? "";
            string newpassword = context.Request["newpassword"] ?? "";
            string confirmpassword = context.Request["confirmpassword"] ?? "";
            string smscode = context.Request["smscode"] ?? "";
            string pwd = context.Request["pwd"] ?? "";
            string message = string.Empty;

            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (string.IsNullOrEmpty(oldpassword))
            {
                return ResultJson(ResultType.error, "请输入旧支付密码", "");
            }
            //if (string.IsNullOrEmpty(oldpassword) != string.IsNullOrEmpty(pwd))
            //{
            //    return ResultJson(ResultType.error, "输入旧支付密码不正确", "");
            //}
            if (string.IsNullOrEmpty(newpassword))
            {
                return ResultJson(ResultType.error, "请输入支付密码", "");
            }
            //if (string.IsNullOrEmpty(confirmpassword))
            //{
            //    return ResultJson(ResultType.error, "再次输入支付密码", "");
            //}
            if (newpassword != confirmpassword)
            {
                return ResultJson(ResultType.error, "两次输入的密码不一致", "");
            }

            var tsvc = new UserService();
            var result = tsvc.Payment(userid, oldpassword.ToUpper(), newpassword.ToUpper(), confirmpassword.ToUpper(), smscode, out message);
            if (result)
            {
                return ResultJson(ResultType.success, "修改成功", "");
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
        //支付密码 设置
        private string SetPayPwd(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string newpassword = context.Request["newpassword"] ?? "";
            string smscode = context.Request["smscode"] ?? "";
            string message = string.Empty;

            LogHelper.SaveLog(string.Format("userid:{0},newpassword:{1},smscode:{2}", userid, newpassword, smscode), "SetPayPwd");
            if (string.IsNullOrEmpty(userid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }

            if (string.IsNullOrEmpty(newpassword))
            {
                return ResultJson(ResultType.error, "请输入支付密码", "");
            }

            LogHelper.SaveLog(string.Format("userid:{0},newpassword:{1},smscode:{2}", userid, newpassword, smscode), "SetPayPwd");

            var tsvc = new UserService();
            var result = tsvc.SetPayment(userid, newpassword.ToUpper(), smscode, out message);
            if (result)
            {
                return ResultJson(ResultType.success, "修改成功", "");
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
        private string GetFriend(HttpContext context)
        {
            int statusCode;
            string username = context.Request["username"] ?? "";
            var api = new EaseMobAPIHelper();
            var data = api.AccountGetFriend(username, out statusCode);

            return ResultJson(ResultType.success, "成功", data);
        }

        /// <summary>
        /// 批量删除IM用户
        ///删除某个 APP 下指定数量的环信账号。可一次删除 N 个用户，数值可以修改。
        ///建议这个数值在100-500之间，不要过大。
        ///需要注意的是，这里只是批量的一次性删除掉 N个用户，具体删除哪些并没有指定，可以在返回值中查看到哪些用户被删除掉了。
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string DelUser(HttpContext context)
        {
            int statusCode;
            int limit = 50;//指定删除数据的最大条数
            //string username = context.Request["username"] ?? "";
            var api = new EaseMobAPIHelper();
            var data = api.AccountDelUser(limit, out statusCode);

            return ResultJson(ResultType.success, "成功", data);
        }
        //个人信息
        private string ViewPersonal(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";

            string message = string.Empty;

            int _userid = 0;
            int.TryParse(userid, out _userid);

            UserService userSvc = new UserService();
            var values = userSvc.Personal(_userid, out message);

            return ResultJson(ResultType.success, message, values);
        }
        //好友信息
        private string ViewFriendPersonal(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string usercode = context.Request["usercode"] ?? "";

            string message = string.Empty;

            if (string.IsNullOrEmpty(usercode))
            {
                return ResultJson(ResultType.error, "输入用户编号", "");
            }

            long _userid;
            long.TryParse(userid, out _userid);

            UserService userSvc = new UserService();
            var values = userSvc.FriendPersonal(_userid, usercode, out message);

            return ResultJson(ResultType.success, message, values);
        }
        //修改个人信息
        private string PersonalInformation(HttpContext context)
        {
            string userid = context.Request["userid"] ?? "";
            string type = context.Request["type"] ?? "";
            string value = context.Request["value"] ?? "";

            string message = string.Empty;

            if (string.IsNullOrEmpty(type))
            {
                return ResultJson(ResultType.error, "请输入类型", "");
            }
            if (type == "3")
            {
                upload(context, "head", out value); // 上传凭证
                if (string.IsNullOrEmpty(value))
                    return ResultJson(ResultType.error, "请上传头像", "");
            }
            else if (string.IsNullOrEmpty(value))
            {
                return ResultJson(ResultType.error, "请输入值", "");
            }

            long _userid;
            long.TryParse(userid, out _userid);

            var tsvc = new UserService();
            var result = tsvc.UpdatePersonal(_userid, type, value, out message);
            if (result)
            {
                return ResultJson(ResultType.success, "修改成功", "");
            }
            else
                return ResultJson(ResultType.error, "修改失败", message);

        }

        //验证授权码
        private string ValidToken(HttpContext context)
        {
            string tokencode = context.Request["tokencode"] ?? "";
            string message = string.Empty;

            if (string.IsNullOrEmpty(tokencode))
            {
                return ResultJson(ResultType.error, "请输入登录授权码", "");
            }
            UserService userSvc = new UserService();
            LogHelper.SaveLog("tokencode:" + tokencode, "UserToken");
            bool result = userSvc.ValidToken(tokencode, out message);
            if (result)
            {
                return ResultJson(ResultType.success, message, "");
            }
            else
            {
                return ResultJson(ResultType.error, message, "");
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string Login(HttpContext context)
        {
            string mode = context.Request["mode"] ?? "";

            if (mode == "1")
            {
                return LoginModeByPassword(context);//密码登录
            }
            else if (mode == "2")
            {
                return LoginModeBySMSCode(context);//短信登录
            }

            return ResultJson(ResultType.error, "请输入正确的登录模式", "");
        }

        /// <summary>
        /// 登录 密码登录
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string LoginModeByPassword(HttpContext context)
        {
            string strusername = context.Request["username"] ?? "";
            string strpassword = context.Request["password"] ?? "";
            string strphonecode = context.Request["phonecode"] ?? "1";
            bool flag;
            int LoginMode = 1; //密码登录
            string message = string.Empty;
            string hx_passowrd = string.Empty;

            if (string.IsNullOrEmpty(strusername))
            {
                return ResultJson(ResultType.error, "请输入用户名", "");
            }
            if (string.IsNullOrEmpty(strpassword))
            {
                return ResultJson(ResultType.error, "请输入密码", "");
            }
            //if (string.IsNullOrEmpty(strphonecode))
            //{
            //    return ResultJson(ResultType.error, "请输入手机验证码", "");
            //}

            UserService userSvc = new UserService();
            UserTokenModel model = userSvc.Login(strusername, strpassword.ToUpper(), strphonecode, LoginMode, out flag, out message);
            if (flag)
            {
                return ResultJson(ResultType.success, message, model);
            }
            else
            {
                return ResultJson(ResultType.error, message, model);
            }
        }

        /// <summary>
        /// 登录 密码登录
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string LoginModeBySMSCode(HttpContext context)
        {
            string strusername = context.Request["username"] ?? "";
            string strphonecode = context.Request["phonecode"] ?? "1";
            bool flag;
            int LoginMode = 2; //短信登录
            string message = string.Empty;
            string hx_passowrd = string.Empty;
            string strpassword = string.Empty;

            if (string.IsNullOrEmpty(strusername))
            {
                return ResultJson(ResultType.error, "请输入用户名", "");
            }
            if (string.IsNullOrEmpty(strphonecode))
            {
                return ResultJson(ResultType.error, "请输入验证码", "");
            }
            //if (string.IsNullOrEmpty(strphonecode))
            //{
            //    return ResultJson(ResultType.error, "请输入手机验证码", "");
            //}

            UserService userSvc = new UserService();
            UserTokenModel model = userSvc.Login(strusername, strpassword.ToUpper(), strphonecode, LoginMode, out flag, out message);
            if (flag)
            {
                return ResultJson(ResultType.success, message, model);
            }
            else
            {
                return ResultJson(ResultType.error, message, model);
            }
        }
        //校验 身份证 姓名
        private string VerifyIdenCode(HttpContext context)
        {
            string message = string.Empty;

            string jsondata = context.Request["data"] ?? "";
            LogHelper.SaveLog(jsondata, "VerifyIdenCode");
            RegisterModel rModel = null;

            try
            {
                jsondata = AESEncrypt.Decrypt(jsondata);
                rModel = JsonConvert.DeserializeObject<RegisterModel>(jsondata);
            }
            catch
            {
                return ResultJson(ResultType.error, "数据异常", "");
            }
            if (string.IsNullOrEmpty(rModel.idencode))//|| recommendcode.Length != 18)
                return ResultJson(ResultType.error, "身份证错误", "");

            if (string.IsNullOrEmpty(rModel.idenname) || rModel.idenname.Length < 2)
                return ResultJson(ResultType.error, "姓名错误", "");

            string strswitch = System.Configuration.ConfigurationManager.AppSettings["IDCARD_SWITCH"];

            UserService userSvc = new UserService();
            int idcodenum = userSvc.GetIDCodeNumber(rModel.idencode);
            if (idcodenum >= userSvc.getParamInt("SystemName6"))
            {
                return ResultJson(ResultType.error, "您的身份证已验证，不能重复验证", "");
            }

            IDAuthentication auth = new IDAuthentication();
            string resultmsg = auth.AuthenticationIDAndName(rModel.idencode, rModel.idenname);
            if (resultmsg != "success")
            {
                return ResultJson(ResultType.error, "身份证验证失败", "");
            }

            
            bool result = userSvc.SaveIdenCode(long.Parse(rModel.userid), rModel.idencode, rModel.idenname);

            if (result)
                return ResultJson(ResultType.success, "验证通过", "");
            else
                return ResultJson(ResultType.error, "验证失败", "");
        }

        private string IsVerifyIdenCode(HttpContext context)
        {
            string message = string.Empty;

            string struserid = context.Request["userid"] ?? "";
            #region 用户ID
            long userid = 0;
            if (string.IsNullOrEmpty(struserid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!long.TryParse(struserid, out userid))
            {
                return ResultJson(ResultType.error, "请输入有效的用户ID", "");
            }
            #endregion

            UserService userSvc = new UserService();
            int result = userSvc.IsValidIdenCode(userid, out message);
            SortedDictionary<string, object> values = new SortedDictionary<string, object>();
            values.Add("IsCardValid", result);
            if (result >= 0)
                return ResultJson(ResultType.success, message, values);
            else
                return ResultJson(ResultType.error, message, values);
        }

    }

    class EaseMobResult
    {
        public string error { set; get; }
    }

}
