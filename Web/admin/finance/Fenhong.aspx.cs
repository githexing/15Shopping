using Library;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.finance
{
    public partial class Fenhong : AdminPageBase
    {
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            string strWhere = string.Format(" and b.IsOpend >= 0");

            if (this.textUserCode.Value != "")
            {
                strWhere += " and b.UserCode like '%" + this.textUserCode.Value.Trim() + "%'";
            }
            if (this.txtTrueName.Text != "")
            {
                strWhere += " and b.TrueName like '%" + this.txtTrueName.Text.Trim() + "%'";
            }
            string sql = "select b.TrueName,b.UserCode, BaodanOrder,Order1,PVTotal,OrderCode,OrderDate from tb_Order a  left join tb_user b on a.UserID=b.UserID  where BaodanOrder>0 and IsSend>2";
            sql += strWhere;
            bind_repeater(userBLL.getData_Chaxun(sql,""), Repeater1, "OrderDate desc", tr1, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            decimal jine1 = 0;
            if (!decimal.TryParse(TextBox1.Text,out jine1))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入正确的金额');", true);
                return;
            }
            if (jine1==0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('输入的金额不能为0');", true);
                return;
            }
            string sql = "select OrderID,a.userid ,BaodanOrder,OrderCode,PVTotal,Order1 from tb_Order a left join tb_user b on a.UserID=b.UserID  where BaodanOrder >0 and Order1<>PVTotal and  IsSend>2  and IsOpend = 2";
            var dt= userBLL.getData_Chaxun(sql,"").Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal shouxufei = 0;
                long ID = long.Parse(dt.Rows[i]["OrderID"].ToString());
                long userid = long.Parse(dt.Rows[i]["userid"].ToString());
                string BaodanOrder = dt.Rows[i]["BaodanOrder"].ToString();
                string OrderCode = dt.Rows[i]["OrderCode"].ToString();
                decimal PVTotal = decimal.Parse(dt.Rows[i]["PVTotal"].ToString());
                decimal Order1 = decimal.Parse(dt.Rows[i]["Order1"].ToString());
                if (PVTotal- Order1 <= jine1)//封顶设置
                {
                    jine1 = PVTotal - Order1;
                }
                shouxufei = jine1 * getParamAmount("PingTai")/100;
                decimal jine = jine1- shouxufei;
                 
                decimal jiangjin= getParamAmount("JJ");
                decimal zhongzi = getParamAmount("ZZ");
                decimal JJ = jine* jiangjin/100;
                decimal ZZ = jine * zhongzi/100;
                UpdateAccount("Emoney", userid, JJ,1);//奖金
                UpdateAccount("AllBonusAccount", userid, ZZ, 1);//种子

                lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                journalInfo.UserID = userid;
                journalInfo.Remark = "订单号："+OrderCode+",有"+BaodanOrder + "个分润单位，加权分红获得"+ (jine+shouxufei)+"，其中扣除平台手续费"+ shouxufei+"，剩余"+ jiangjin+"%进入奖金积分";
                journalInfo.RemarkEn = OrderCode;
                journalInfo.InAmount = JJ;
                journalInfo.OutAmount = 0;
                journalInfo.BalanceAmount = userBLL.GetMoney(userid, "Emoney"); ;
                journalInfo.JournalDate = DateTime.Now;
                journalInfo.JournalType = 1;
                journalInfo.Journal01 = 0;
                journalBLL.Add(journalInfo);

                journalInfo.UserID = userid;
                journalInfo.Remark = "订单号：" + OrderCode + ",有" + BaodanOrder + "个分润单位，加权分红获得" + (jine + shouxufei) + "，其中扣除平台手续费" + shouxufei + "，剩余" + zhongzi + "%进入种子积分";
                journalInfo.RemarkEn = OrderCode;
                journalInfo.InAmount = ZZ;
                journalInfo.OutAmount = 0;
                journalInfo.BalanceAmount = userBLL.GetMoney(userid, "AllBonusAccount"); ;
                journalInfo.JournalDate = DateTime.Now;
                journalInfo.JournalType = 4;
                journalInfo.Journal01 = 0;
                journalBLL.Add(journalInfo);
                string Source = "订单号：" + OrderCode + ",有" + BaodanOrder +"个分润单位，加权分红获得"+ (jine+shouxufei);

                SqlConnection conn = new SqlConnection(sconn);
                conn.Open();
                string sql_Add = "insert into tb_bonus(UserID,TypeID,Amount,Revenue,sf,AddTime,IsSettled,Source,SourceEn,SttleTime,FromUserID,Bonus005,Bonus006)";
                sql_Add += "values (" + userid + ",4," + (jine + shouxufei) + "," + shouxufei + "," + jine + ",getdate(),1,'" + Source + "','',getdate()," + userid + "," + jiangjin + "," + zhongzi + ");update tb_order set Order1+="+ (jine + shouxufei )+ "  where OrderID = " + ID + ""; 
                SqlCommand cmd = new SqlCommand(sql_Add, conn);
                int reInt = cmd.ExecuteNonQuery();
                conn.Close();
            }
            if (dt.Rows.Count==0)
            {
                Response.Write("<script>alert('暂无会员分红');location.href='Fenhong.aspx';</script>");
                return;
            }
            Response.Write("<script>alert('分红成功');location.href='Fenhong.aspx';</script>");
            return;

        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}