using System.Linq;
using System.Web;
using Library;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Data;
using Web.APPService.Service;
using Web.APPService.ViewModel;
using System;

namespace Web.APPService
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : ServiceHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = string.Empty;

            result = LoginModeByPassword(context);
            context.Response.Write(result);
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
            //string strphonecode = context.Request["phonecode"] ?? "1";
          
            //int LoginMode = 1; //密码登录
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
            AllCore AC = new AllCore();
            long UserID= AC.userBLL.GetUserID(strusername);
            if (UserID<=0)
            {
                return ResultJson(ResultType.error, "此账号不存在!", "");
            }
            var model= AC.userBLL.GetModel(UserID);
            if (model.Password != strpassword.ToUpper())
            {
                return ResultJson(ResultType.error, "账号密码错误!", "");
            }
            message = "ok";
            return ResultJson(ResultType.success, message, "");
            
        }
    }
}