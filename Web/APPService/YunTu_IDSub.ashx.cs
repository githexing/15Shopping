using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Library;

namespace Web.APPService
{
    /// <summary>
    /// YunTu_IDSub 的摘要说明
    /// </summary>
    public class YunTu_IDSub : IHttpHandler
    {
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        public void ProcessRequest(HttpContext context)
        {
            string result = "error";
            string message = "";
            string dates = "";
            string strID = context.Request["ID"];
            string strUserID = context.Request["UserID"];
            decimal Money = 0;
           
            long ID = 0;
            long UserID = 0;
            if (string.IsNullOrEmpty(strID) || strID.Trim() == string.Empty|| string.IsNullOrEmpty(strUserID) || strUserID.Trim() == string.Empty)
            {
                message = "账号不存在";
                SendResponse(context, result, message, dates);
                return;
            }
            try
            {
                ID = long.Parse(strID);
                UserID = long.Parse(strUserID);
            }
            catch (Exception)
            {

                ID = 0;
                UserID = 0;
                message = "账号不存在";
                SendResponse(context, result, message, dates);
            }
            AllCore core = new AllCore();
            lgk.Model.tb_user userModel = core.userBLL.GetModel(UserID);

            SqlConnection conn = new SqlConnection(sconn);
            conn.Open();
            string sql = string.Format("select ID,RandMoney from tb_Rand where ID=" + ID + " and Flag=0 and UserID= '" + UserID + "' ;");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count>0)
            {
                Money = decimal.Parse(dt.Rows[0]["RandMoney"].ToString());
                conn.Open();
                string sql_1 = "update tb_Rand set Flag=2,ClickTime=getdate() where ID='" + ID + "' and UserID= '" + UserID + "';update tb_user set BonusAccount+='"+Money+"' where UserID= '" + UserID + "'; ";
                SqlCommand cmd = new SqlCommand(sql_1, conn);
                int reInt = cmd.ExecuteNonQuery();
                conn.Close();
                if (reInt > 0)
                {
                    AllCore AC = new AllCore();
                    var model = AC.userBLL.GetModel(UserID);
                    dates = "\"Account\":{\"Emoney\":\"" + model.Emoney.ToString() + "\",\"BonusAccount\":\"" + model.BonusAccount.ToString() + "\",\"ShengYuSuanLi\":\"" + Convert.ToInt32(model.User012) + "\"}"; 
                    result = "success";
                    message = "领取成功！";
                    //明细记录
                    var Mjournal = new lgk.Model.tb_journal();
                    lgk.BLL.tb_journal Bjournal = new lgk.BLL.tb_journal();
                    Mjournal.UserID = UserID;
                    Mjournal.InAmount = Money;
                    Mjournal.OutAmount = 0;
                    Mjournal.Remark = "领取释放币 ";
                    Mjournal.RemarkEn = "Collect "+ Money + " clouds"  ;
                    Mjournal.JournalType = 2;
                    Mjournal.BalanceAmount = model.BonusAccount;
                    Mjournal.JournalDate = DateTime.Now;
                    Bjournal.Add(Mjournal);
                    
                    //奖项记录
                    lgk.Model.tb_bonus Mbonus = new lgk.Model.tb_bonus();
                    lgk.BLL.tb_bonus Bbonus = new lgk.BLL.tb_bonus();
                    Mbonus.AddTime = DateTime.Now;
                    Mbonus.TypeID = 1;
                    Mbonus.IsSettled = 1;
                    Mbonus.FromUserID = UserID;
                    Mbonus.Amount = Money; 
                    Mbonus.UserID = UserID;
                    Mbonus.Source= "领取释放币 ";
                    Mbonus.sf = Money;
                    Mbonus.SourceEn= "Collect " + Money + " clouds";
                    Mbonus.SttleTime = DateTime.Now; 
                    Bbonus.Add(Mbonus);

                    //如果冻结释放币账户大于0，激活矿机时转入明细
                    if (userModel.User016 > 0)
                    {
                        core.UpdateAccount("User016", userModel.UserID, userModel.User016, 0);//
                        core.UpdateAccount("BonusAccount", userModel.UserID, userModel.User016, 1);//

                        lgk.Model.tb_journal jourInfo = new lgk.Model.tb_journal();
                        jourInfo.UserID = userModel.UserID;
                        jourInfo.Remark = "释放币账户进账，冻结释放币转入释放币账户";
                        jourInfo.RemarkEn = "Cash withdrawal";
                        jourInfo.InAmount = userModel.User016;
                        jourInfo.OutAmount = 0;
                        jourInfo.BalanceAmount = core.userBLL.GetMoney(UserID, "BonusAccount");
                        jourInfo.JournalDate = DateTime.Now;
                        jourInfo.JournalType = 2;
                        jourInfo.Journal01 = userModel.UserID;
                        core.journalBLL.Add(jourInfo);
                    }
                    
                    SendResponse(context, result, message, dates);
                    //差一条记录
                } 
            } 
            message = "已经领取过";
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