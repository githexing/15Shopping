using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Web.APPService
{
    /// <summary>
    /// YunTu_QianDao 的摘要说明
    /// </summary>
    public class YunTu_QianDao : IHttpHandler
    {
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        public void ProcessRequest(HttpContext context)
        {
            string result = "error";
           string message = "账号不存在或签到失败";
            string dates = "";
            string User = context.Request["UserID"];
            string Pass_1= context.Request["Pass"];
            long Pass = 0;
            long UserID = 0;
            if (string.IsNullOrEmpty(User) || User.Trim() == string.Empty)
            {
                message = "账号不存在！";
                SendResponse(context, result, message, dates);
                return;
            }
            try
            {
                Pass= long.Parse(Pass_1);
                UserID = long.Parse(User);
            }
            catch (Exception)
            {
                Pass = 0;
                UserID = 0;
            } 
            AllCore AC = new AllCore();
            var model = AC.userBLL.GetModel(UserID);//-。
            if (model == null)
            {
                //不存在
                message = "账号不存在！";
                SendResponse(context, result, message, dates);
            }

            SqlConnection conn = new SqlConnection(sconn);
            conn.Open();
            string sql = string.Format("select * from tb_Ready_Rand where JoinDate >= convert( datetime,  convert(varchar(10),GETDATE(),120) + ' 00:00:00' ) and UserID='"+ UserID + "'  and TuiJian_QianDao=2 ;");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            decimal Param = 0;
            int Qiandao = 0;
           
            if (dt.Rows.Count>0)
            {
                result = "success";
                message = "您今天已经签到了！";
                Qiandao = 2;  
            }
            else
            {
                result = "success";
                message = "未签到！";
            }
            Param = AC.getParamAmount("RecCalcPower");
            if (Pass > 0 && dt.Rows.Count == 0)
            {
                int a = AC.Get_Qiandao(UserID);
                if (a > 0)
                {
                    Qiandao = 2;
                    result = "success";
                    message = "签到成功！";
                }
            } 
            dates = "\"QianDao\":" + Qiandao.ToString() + ",\"Param\":" + Param.ToString() + "";
            SendResponse(context, result, message, dates);


        }
        private void SendResponse(HttpContext context, string result, string returnString, string dates)
        {
            context.Response.Clear();
            string json = "{\"state\":\"" + result.ToString() + "\",\"message\":\"" + returnString + "\",\"data\":{" + dates + "}}";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.Serialize(json);
            context.Response.Write(json);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}