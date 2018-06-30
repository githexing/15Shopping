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
    /// YunTu_List 的摘要说明-接收用户UserCode
    /// </summary>
    public class YunTu_List : IHttpHandler
    {
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        public void ProcessRequest(HttpContext context)
        {
            string result = "error";
            string message = "账号不存在!";
            string dates = "";
            string Emoney = "";
            string BonusAccount = "";
            string jine = "";
            long UserID = 0;
            string User = context.Request["UserID"];
            AllCore AC = new AllCore(); 
            if (string.IsNullOrEmpty(User) || User.Trim() == string.Empty)
            {
                message = "账号不存在！";
                SendResponse(context, result, message, dates);
                return;
            }
            try
            {
                UserID = long.Parse(User);
            }
            catch (Exception)
            {

                UserID = 0;
            }
            var model = AC.userBLL.GetModel(UserID);//-取出当前余额的钱。
            if (model == null)
            {
                //不存在
                message = "账号不存在！";
                SendResponse(context, result, message, dates);
            }
            Emoney= model.Emoney.ToString();
            BonusAccount = model.BonusAccount.ToString();
            jine = "],\"Emoney\":\"" + Emoney + "\",\"BonusAccount\":\"" + BonusAccount + "\",\"TotalMachine\":\"" + (model.User004+model.MachineNumLock) + "\",\"ShengYuSuanLi\":\"" + AC.Get_ShengYuSuanLi(UserID) + "\"}";
            SqlConnection conn = new SqlConnection(sconn);
            conn.Open();
            string sql = string.Format("select ID,RandMoney from tb_Rand where UserID=" + UserID + " and Flag=0 and GiveTime <=getdate();");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dates += "{\"List\":[";
            if (dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows.Count == 1)
                    {

                        dates += "{\"ID\":\"" + dt.Rows[i]["ID"].ToString() + "\",\"Money\":\"" + dt.Rows[i]["RandMoney"].ToString() + "\"}";
                        continue;
                    }
                    if (i == dt.Rows.Count - 1)
                    {
                        dates += "{\"ID\":\"" + dt.Rows[i]["ID"].ToString() + "\",\"Money\":\"" + dt.Rows[i]["RandMoney"].ToString() + "\"}";
                        continue;
                    }
                    if (dt.Rows.Count > 1)
                    {
                        dates += "{\"ID\":\"" + dt.Rows[i]["ID"].ToString() + "\",\"Money\":\"" + dt.Rows[i]["RandMoney"].ToString() + "\"},";
                    } 
                } 
            }
           
            dates += jine;
            result = "success";
            message = "查询成功！";
            SendResponse(context, result, message, dates);
            
        }
        private void SendResponse(HttpContext context, string result, string returnString, string dates)
        {
            context.Response.Clear();
            string json = "{\"state\":\"" + result.ToString() + "\",\"message\":\"" + returnString + "\",\"data\":" + dates + "}";
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