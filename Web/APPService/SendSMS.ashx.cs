using Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// SendSMS 的摘要说明
    /// </summary>
    public class SendSMS : ServiceHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string result = string.Empty;

            string act = context.Request["act"];
            switch (act.ToLower())
            {
                case "send"://发送短信 1
                    result = Send(context);
                    break;
                case "verify"://验证手机验证码 2
                    result = VerifySmsCode(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常.", "SMS");
                    break;
            }

            context.Response.Write(result);

        }



        #region 发送短信

        private string Send(HttpContext context)
        {
            string jsondata = context.Request["data"] ?? "";
            string op = context.Request["op"] ?? "";
            string phone = string.Empty;
            long userid = 0;

            LogHelper.SaveLog("send-account:" + jsondata, "SendSMS");
            SendSMSModel rModel = null;
            
            if (jsondata.Length < 24)
                return ResultJson(ResultType.error, "数据异常", "");

            try
            {
                jsondata = AESEncrypt.Decrypt(jsondata);
                rModel = JsonConvert.DeserializeObject<SendSMSModel>(jsondata);
            }
            catch
            {
                return ResultJson(ResultType.error, "数据异常", "");
            }

            UserService userSvc = new UserService();
            if (op == "account")
            {
                if(string.IsNullOrEmpty(rModel.usercode))
                    return ResultJson(ResultType.error, "账号异常", "");

                phone = userSvc.GetPhoneByAccount(rModel.usercode);

                if (string.IsNullOrEmpty(phone))
                    return ResultJson(ResultType.error, "账号不存在", "");

            }
            else if (op == "id")
            {
                long.TryParse(rModel.userid, out userid);
                if(userid<= 0)
                    return ResultJson(ResultType.error, "id异常", "");

                phone = userSvc.GetPhoneByUserID(userid);

                if (string.IsNullOrEmpty(phone))
                    return ResultJson(ResultType.error, "账号不存在", "");
            }
            else if (op == "phone")
            {
                if (string.IsNullOrEmpty(rModel.phone))
                    return ResultJson(ResultType.error, "手机号异常", "");

                if (userSvc.GetPhoneNumber(rModel.phone) > 0)
                    return ResultJson(ResultType.error, "该手机号已注册", "");
            }
            else
                return ResultJson(ResultType.error, "数据异常", "");



            return sendSms(phone, rModel.type);
        }


        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string sendSms(string phone,string type)
        {
            bool flag = false;
            string msg = "";
            try
            {
                int itype = 0;
                string strphone = phone;// context.Request["phone"] ?? "";
                string strtype = type;// context.Request["type"] ?? "";
                LogHelper.SaveLog(strphone + "," + strtype, "sendSms");
                lgk.BLL.SMS smsBLL = new lgk.BLL.SMS();

                string regSwitch = ConfigurationManager.AppSettings["SMS_SWITCH"];//注册短信开关
                if (!regSwitch.Equals("Open"))
                {
                    flag = true;
                    msg = "不需要验证码";
                }
                else
                {
                    if (string.IsNullOrEmpty(strphone))
                    {
                        msg = "手机号码为空";
                    }
                    if (!new RegexR().isPhones(strphone))
                    {
                        msg = "请输入正确的手机号";
                    }
                    else if (string.IsNullOrEmpty(strtype))
                    {
                        msg = "验证码类别为空";
                    }
                    else if (!int.TryParse(strtype, out itype))
                    {
                        msg = "type参数无效";
                    }
                    else if (smsBLL.GetSendCountOfDay(strphone) >= 5) //同号码每日限制：5条 
                    {
                        msg = "超出短信发送计数限制";
                    }
                    else if (smsBLL.GetSendCountOfMinute(strphone,1) >= 1) //同号码每分钟限制：1条
                    {
                        msg = "操作过于频繁，请稍后重试";
                    }
                    else
                    {

                        if (regSwitch.Equals("Open"))
                        {
                            LogHelper.SaveLog("2:" + strphone, "PHONEJS");
                            lgk.Model.SMS model = new lgk.Model.SMS();
                            model.IsDeleted = 0;
                            model.IsValid = 0;
                            model.PublishTime = DateTime.Now;
                            model.SCode = new Library.Common().GetRandom(6);
                            model.ToPhone = strphone;
                            model.SMSContent = model.SCode;
                            model.SendNum = 1;
                            model.ToUserCode = "";
                            model.ValidTime = DateTime.Now.AddMinutes(5);
                            model.TypeID = itype;

                            long isid = smsBLL.Add(model);
                            if (isid > 0)
                            {
                                //msg = "验证码已发送";
                                string strreturn = Library.SMSHelper.SendMessage2(strphone, model.SCode);
                                if (strreturn == "0")
                                {
                                    flag = true;
                                    msg = "发送成功";
                                }
                                else
                                {
                                    smsBLL.UpdateDelete(isid, -1);
                                    msg = "发送失败";
                                }
                            }
                            else
                            {
                                msg = "验证码发送失败";
                            }
                        }
                        else
                        {
                            msg = "短信接口关闭";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            if (flag == true)
            {
                return ResultJson(ResultType.success, msg, "");
            }
            else
            {
                return ResultJson(ResultType.error, msg, "");
            }
        }
        #endregion

        #region 忘记密码
        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string VerifySmsCode(HttpContext context)
        {
            bool flag = false;
            string msg = string.Empty;

            long iVerID = 0;
            AllCore core = new AllCore();

            string usercode = context.Request["usercode"] ?? "";//账号
            string strcode = context.Request["code"] ?? "";//验证码
            string strtype = context.Request["type"] ?? "";//验证码类别
            string strpwd = context.Request["pwd"] ?? "";//新密码
            LogHelper.SaveLog(usercode + "," + strcode + "," + strtype + "," + strpwd, "");
            int itype = 0;
            if (string.IsNullOrEmpty(usercode))
            {
                msg = "登录账号为空";
            }
            else if (string.IsNullOrEmpty(strpwd))
            {
                msg = "新密码为空";
            }
            else
            {

                lgk.Model.tb_user userModel = core.userBLL.GetModelByUserCode(usercode);//
                if (userModel == null)
                {
                    msg = "用户不存在";
                }
                else if (string.IsNullOrEmpty(strcode))
                {
                    msg = "手机验证码为空";
                }
                else if (string.IsNullOrEmpty(strtype))
                {
                    msg = "验证码类别为空";
                }
                else if (!int.TryParse(strtype, out itype))
                {
                    msg = "验证码类别无效";
                }
                //else if (itype > 2 || itype < 1)
                //{
                //    msg = "验证码类别无效";
                //}
                else
                {

                    //短信验证
                    long checkResult = core.CheckSMSCode(userModel.PhoneNum, strcode, int.Parse(strtype));
                    if (checkResult < 0)
                        return ResultJson(ResultType.error, "验证码无效.", "");

                    if (itype == 1)
                    {
                        userModel.Password = strpwd.ToUpper();//登录密码
                    }
                    else if (itype == 2)
                    {
                        userModel.SecondPassword = strpwd.ToUpper();//登录密码
                    }
                    else if(itype == 3)
                    {
                        userModel.Password = strpwd.ToUpper();//登录密码
                    }
                    if (core.userBLL.Update(userModel))
                    {
                        flag = true;
                        if (iVerID > 0)
                        {
                            core.smsBLL.UpdateState(iVerID, 1);//已验证
                        }
                        msg = "修改成功";
                    }
                    else
                    {
                        msg = "修改失败";
                    }
                }

            }

            if (flag == true)
            {
                return ResultJson(ResultType.success, msg, "");
            }
            else
            {
                return ResultJson(ResultType.error, msg, "");
            }
        }
        #endregion

    }
}