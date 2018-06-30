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
    /// YuTu_Rank 的摘要说明
    /// </summary>
    public class YuTu_Rank : IHttpHandler
    {
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        public void ProcessRequest(HttpContext context)
        {
            string result = "error";
            string message = "暂无数据";
            string dates = "";
            string Page_1 = context.Request["Page"];
            string Mumber_1 = context.Request["Mumber"];
            int Page = 0;
            int Mumber = 0;
            try
            {
                Page = int.Parse(Page_1);
                Mumber = int.Parse(Mumber_1);
            }
            catch (Exception)
            {
                message = "页码错误！";
                SendResponse(context, result, message, dates);
            }
            if (Page == 0)
            {
                Page = 1;
            }
            int Start = (Page - 1) * Mumber;
            int YM = Page * Mumber;

            SqlConnection conn = new SqlConnection(sconn);
            conn.Open();
            string sql = string.Format("select c.* from (select ROW_NUMBER()OVER(ORDER BY Total_Suanli desc)RankID,b.* from (select u.NiceName Name ,IsNull(a.RandMoney,0) Jine ,u.UserID, u.User004 as Kuangji, u.User012 as Total_Suanli from tb_user as u left join (select UserID,SUM(RandMoney) RandMoney  from tb_Rand where Flag=2 group by UserID) a on u.UserID=a.UserID) as b) as c order by c.RankID ");
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dates += "\"RankList\":[";
            int GG = 0;
            decimal dd = dt.Rows.Count / Mumber;
            int yu = dt.Rows.Count % Mumber;
            if (YM > dt.Rows.Count)//最后一页处理
            {
                if (YM - dt.Rows.Count> Mumber)
                {
                    GG = 1;
                }
                Page = (int)Math.Floor(dd);
                Start = Mumber * Page;
                Mumber = yu;
               
            }
            if (yu > 0)
            {
                dd += 1;
            }

            if (dt.Rows.Count>0)
            {
                result = "success";
                message = "查询成功！";
                if (GG==1)
                {
                    Mumber = 0;
                }
                for (int i = Start; i < Start + Mumber; i++)
                {
                    if (Mumber == 1)
                    { 
                        dates += "{\"RankID\":\"" + dt.Rows[i]["RankID"].ToString() + "\",\"Name\":\"" + dt.Rows[i]["Name"].ToString() + "\",\"SuanLi\":\"" + dt.Rows[i]["Total_Suanli"].ToString() + "\",\"KuangJi\":\"" + dt.Rows[i]["Kuangji"].ToString() + "\",\"Money\":\"" + dt.Rows[i]["Jine"].ToString() + "\"}";
                        continue;
                    }
                    if (i == Start + Mumber - 1)
                    {
                        dates += "{\"RankID\":\"" + dt.Rows[i]["RankID"].ToString() + "\",\"Name\":\"" + dt.Rows[i]["Name"].ToString() + "\",\"SuanLi\":\"" + dt.Rows[i]["Total_Suanli"].ToString() + "\",\"KuangJi\":\"" + dt.Rows[i]["Kuangji"].ToString() + "\",\"Money\":\"" + dt.Rows[i]["Jine"].ToString() + "\"}";
                        continue;
                    }
                    if (Mumber > 1)
                    {
                        dates += "{\"RankID\":\"" + dt.Rows[i]["RankID"].ToString() + "\",\"Name\":\"" + dt.Rows[i]["Name"].ToString() + "\",\"SuanLi\":\"" + dt.Rows[i]["Total_Suanli"].ToString() + "\",\"KuangJi\":\"" + dt.Rows[i]["Kuangji"].ToString() + "\",\"Money\":\"" + dt.Rows[i]["Jine"].ToString() + "\"},";

                    }
                }
               
            }
            dates += "]";
            dates += ",\"CountPage\":" + dd + "";
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