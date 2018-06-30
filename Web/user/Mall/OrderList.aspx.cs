using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Mall
{
    public partial class OrderList : PageCore
    {
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewState["iType"] = 0;
                BindData();
            }
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string getWhere()
        {
            string str = " o.IsSend>=0 and o.IsDel=0 and o.UserID=" + getLoginID();
            string id = dropOrderState.SelectedValue;
            switch (id)
            {
                case "0": str += ""; break;
                case "1": str += " and o.IsSend=1"; break;//已支付
                case "2": str += " and o.IsSend=2"; break;//已发货
                case "3": str += " and o.IsSend=3"; break;//已完成
            }

            string strordercode = txtOrdercode.Value.Trim();
            string StarTime = txtStartTime.Value.Trim();
            string EndTime = txtEndTime.Value.Trim();

            if (!string.IsNullOrEmpty(strordercode))
            {
                str += string.Format(" and o.ordercode  like '%" + strordercode + "%'");
            }

            if (StarTime != "" && EndTime == "")
            {
                str += string.Format(" and Convert(nvarchar(10),o.OrderDate,120)  >= '" + StarTime + "'");
            }
            else if (StarTime == "" && EndTime != "")
            {
                str += string.Format("  and Convert(nvarchar(10),o.OrderDate,120)  <= '" + EndTime + "'");
            }
            else if (StarTime != "" && EndTime != "")
            {
                str += string.Format("  and Convert(nvarchar(10),o.OrderDate,120)  between '" + StarTime + "' and '" + EndTime + "'");
            }

            return str;
        }

        private void BindData()
        {
            //dropOrderState.SelectedValue = ViewState["iType"].ToString();
            bind_repeater(GetAllOrderList(getWhere()), rpOrderList, "IsSend asc,OrderDate desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        
        protected void rpOrderList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Repeater dl1 = e.Item.FindControl("rpOrderDetailList") as Repeater;
                //if (dl1 != null)
                //{
                //    string strOrderCode = DataBinder.Eval(e.Item.DataItem, "OrderCode").ToString();
                //    DataSet ds = orderDetailBLL.GetGoodsListAll(" d.OrderCode=" + strOrderCode);
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        dl1.DataSource = ds;
                //        dl1.DataBind();
                //    }
                //}
                Literal StateName = e.Item.FindControl("ltStateName") as Literal;
                //LinkButton btnCancel = e.Item.FindControl("lbtnCancel") as LinkButton;
                if (StateName != null)
                {
                    int iIsSend = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "IsSend").ToString());
                    string strState = "";
                    if (iIsSend == 0)
                    {
                        strState = "未付款";
                    }
                    else if (iIsSend == 1)
                    {
                        strState = "已支付";
                    }
                    else if (iIsSend == 2)
                    {
                        strState = "已发货";
                    }
                    else if (iIsSend == 3)
                    {
                        strState = "已完成";
                    }
                    StateName.Text = strState;
                }
            }
        }

        protected void rpOrderList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long iID = Convert.ToInt64(e.CommandArgument);
            lgk.Model.tb_Order orderModel = orderBLL.GetModel(iID);
            if (e.CommandName.Equals("cancel"))
            {
                if (orderModel != null)
                {
                    if (orderModel.IsDel == 0)
                    {
                        orderModel.IsDel = 1;
                        if (orderBLL.Update(orderModel))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('订单取消成功!');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('订单取消失败!');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('此订单已取消!');", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('此订单记录不存在!');", true);
                    return;
                }
            }
            else if (e.CommandName.Equals("sure"))
            {
                if (orderModel != null)
                {
                    if (orderModel.IsSend == 3)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('此订单已收货!');", true);
                        return;
                    }
                    else if (orderModel.IsSend == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('此订单未发货!');", true);
                        return;
                    }
                    else 
                    {
                        orderModel.IsSend = 3;
                        
                        if (orderBLL.Update(orderModel))
                        {
                            //发奖 
                               #region 报单中心（20套）改为4万元
                            if (orderModel.OrderTotal >= getParamInt("Fuwu2"))//报单中心（20套）
                            {
                                int a = agentBLL.GetIDByIDUser(orderModel.UserID); 
                                if (a == 0)//插入用户
                                {
                                    var userModel = userBLL.GetModel(orderModel.UserID);
                                    lgk.Model.tb_agent model = new lgk.Model.tb_agent();
                                    model.UserID = userModel.UserID;
                                    model.AgentCode = userModel.UserCode;
                                    model.Flag = 1;
                                    model.AgentType = 1;
                                    model.Agent003 = userModel.TrueName;
                                    model.AppliTime = DateTime.Now;
                                    model.JoinMoney = 0;
                                    model.Agent004 = "";
                                    model.Agent001 = 0;
                                    model.Agent002 = 0;
                                    model.PicLink = "";
                                    agentBLL.Add(model);

                                    var model1 = userBLL.GetModel(userModel.UserID);
                                    model1.AgentsID = agentBLL.GetIDByIDUser(userModel.UserID);
                                    model1.IsAgent = 1;
                                    userBLL.Update(model1);

                                    lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                                    journalInfo.UserID = userModel.UserID;
                                    journalInfo.Remark = "一次性购买 " + getParamInt("Fuwu2") + "元的产品，成为服务网点";
                                    journalInfo.RemarkEn = "Cash withdrawal";
                                    journalInfo.InAmount = 0;
                                    journalInfo.OutAmount = 0;
                                    journalInfo.BalanceAmount = userBLL.GetMoney(userModel.UserID, "StockMoney");
                                    journalInfo.JournalDate = DateTime.Now;
                                    journalInfo.JournalType = 2;
                                    journalInfo.Journal01 = userModel.UserID;
                                    journalBLL.Add(journalInfo);


                                }
                            }
                            long userid = orderModel.UserID;
                            decimal totalMoney = orderModel.OrderTotal;
                            #endregion
                            if (getParamInt("Fuwu")==1)
                            { 
                                //报单中心奖 

                                long BD_UserID = userBLL.GetUserID(userBLL.GetModel(orderModel.UserID).User006);
                                decimal BD = getParamAmount("Fuwu1") / 100 * totalMoney;

                                int isLock = userBLL.GetModel(BD_UserID).IsLock;
                                int Ag = userBLL.GetModel(BD_UserID).IsAgent;
                                if (isLock == 0&& Ag==1)
                                {
                                    decimal shouxufei = BD * getParamAmount("PingTai") / 100;
                                    BD -= shouxufei;
                                    decimal jiangjin = getParamAmount("JJ");
                                    decimal zhongzi = getParamAmount("ZZ");
                                    decimal xiaofei = getParamAmount("XF");
                                    decimal JJ = BD * jiangjin / 100;
                                    decimal ZZ = BD * zhongzi / 100;
                                    decimal XF = BD * xiaofei / 100;
                                    UpdateAccount("Emoney", BD_UserID, JJ, 1);//奖金
                                    UpdateAccount("AllBonusAccount", BD_UserID, ZZ, 1);//种子
                                    if (XF>0)
                                    {
                                        UpdateAccount("AllBonusAccount", BD_UserID, XF, 1);//种子
                                        lgk.Model.tb_journal journal1 = new lgk.Model.tb_journal();
                                        journal1.UserID = BD_UserID;
                                        journal1.Remark = "服务网点获得" + (BD + shouxufei) + "，其中扣除平台手续费" + shouxufei + "，剩余" + xiaofei + "%进入消费积分";
                                        journal1.RemarkEn = "";
                                        journal1.InAmount = XF;
                                        journal1.OutAmount = 0;
                                        journal1.BalanceAmount = userBLL.GetMoney(BD_UserID, "BonusAccount"); ;
                                        journal1.JournalDate = DateTime.Now;
                                        journal1.JournalType = 3;
                                        journal1.Journal01 = 0;
                                        journalBLL.Add(journal1);
                                    }
                                
                                    lgk.Model.tb_journal journal = new lgk.Model.tb_journal();
                                    journal.UserID = BD_UserID;
                                    journal.Remark = "服务网点获得" + (BD + shouxufei) + "，其中扣除平台手续费" + shouxufei + "，剩余" + jiangjin + "%进入奖金积分";
                                    journal.RemarkEn = "";
                                    journal.InAmount = JJ;
                                    journal.OutAmount = 0;
                                    journal.BalanceAmount = userBLL.GetMoney(BD_UserID, "Emoney"); ;
                                    journal.JournalDate = DateTime.Now;
                                    journal.JournalType = 1;
                                    journal.Journal01 = 0;
                                    journalBLL.Add(journal);

                                    journal.UserID = BD_UserID;
                                    journal.Remark = "服务网点获得" + (BD + shouxufei) + "，其中扣除平台手续费" + shouxufei + "，剩余" + zhongzi + "%进入电子积分";
                                    journal.RemarkEn = "";
                                    journal.InAmount = ZZ;
                                    journal.OutAmount = 0;
                                    journal.BalanceAmount = userBLL.GetMoney(BD_UserID, "StockMoney"); ;
                                    journal.JournalDate = DateTime.Now;
                                    journal.JournalType = 2;
                                    journal.Journal01 = 0;
                                    journalBLL.Add(journal);

                                    SqlConnection conn = new SqlConnection(sconn);
                                    conn.Open();
                                    string sql_Add = "insert into tb_bonus(UserID,TypeID,Amount,Revenue,sf,AddTime,IsSettled,Source,SourceEn,SttleTime,FromUserID,Bonus005,Bonus006)";
                                    sql_Add += "values (" + BD_UserID + ",6," + (BD + shouxufei) + "," + shouxufei + "," + BD + ",getdate(),1,'" + journal.Remark + "','',getdate()," + userid + "," + jiangjin + "," + zhongzi + ");";
                                    SqlCommand cmd = new SqlCommand(sql_Add, conn);
                                    int reInt = cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                            }
                            ////还有运营中心 Yunying1
                            //if (getParamInt("Yunying") == 1)
                            //{  
                            //        long YY_UserID = long.Parse(orderModel.Order5);
                            //    int isLock = userBLL.GetModel(YY_UserID).IsLock;
                            //    int Ag= agent1BLL.GetIDByIDUser(agent1BLL.GetIDByIDUser(YY_UserID));
                            //    if (isLock==0&&Ag==1)
                            //    {

                               
                            //        decimal YY = getParamAmount("Yunying1") / 100 * totalMoney;

                            //        decimal shouxufei = YY * getParamAmount("PingTai") / 100;
                            //        YY -= shouxufei;
                            //        decimal jiangjin = getParamAmount("JJ");
                            //        decimal zhongzi = getParamAmount("ZZ");
                            //        decimal JJ = YY * jiangjin / 100;
                            //        decimal ZZ = YY * zhongzi / 100;
                            //        UpdateAccount("Emoney", YY_UserID, JJ, 1);//奖金
                            //        UpdateAccount("AllBonusAccount", YY_UserID, ZZ, 1);//种子

                            //        lgk.Model.tb_journal journal = new lgk.Model.tb_journal();
                            //        journal.UserID = YY_UserID;
                            //        journal.Remark = "运营中心奖获得" + (YY + shouxufei) + "，其中扣除平台手续费" + shouxufei + "，剩余" + jiangjin + "%进入奖金积分";
                            //        journal.RemarkEn = "";
                            //        journal.InAmount = JJ;
                            //        journal.OutAmount = 0;
                            //        journal.BalanceAmount = userBLL.GetMoney(YY_UserID, "Emoney"); ;
                            //        journal.JournalDate = DateTime.Now;
                            //        journal.JournalType = 1;
                            //        journal.Journal01 = 0;
                            //        journalBLL.Add(journal);

                            //        journal.UserID = YY_UserID;
                            //        journal.Remark = "运营中心奖获得" + (YY + shouxufei) + "，其中扣除平台手续费" + shouxufei + "，剩余" + zhongzi + "%进入种子积分";
                            //        journal.RemarkEn = "";
                            //        journal.InAmount = ZZ;
                            //        journal.OutAmount = 0;
                            //        journal.BalanceAmount = userBLL.GetMoney(YY_UserID, "AllBonusAccount"); ;
                            //        journal.JournalDate = DateTime.Now;
                            //        journal.JournalType = 4;
                            //        journal.Journal01 = 0;
                            //        journalBLL.Add(journal);

                            //        SqlConnection conn = new SqlConnection(sconn);
                            //        conn.Open();
                            //        string sql_Add1 = "insert into tb_bonus(UserID,TypeID,Amount,Revenue,sf,AddTime,IsSettled,Source,SourceEn,SttleTime,FromUserID,Bonus005,Bonus006)";
                            //        sql_Add1 += "values (" + YY_UserID + ",5," + (YY + shouxufei) + "," + shouxufei + "," + YY + ",getdate(),1,'" + journal.Remark + "','',getdate()," + userid + "," + jiangjin + "," + zhongzi + ");";
                            //        SqlCommand cmd = new SqlCommand(sql_Add1, conn);
                            //        int reInt1 = cmd.ExecuteNonQuery();
                            //        conn.Close();

                            //    }

                            //}
                            //用户账户更新
                            //MySQL(string.Format(" exec proc_Fenxiangjiang "+ orderModel.UserID+ ","+ orderModel.OrderTotal+ "" ));
                            //MySQL(string.Format(" exec proc_Yejijiang " + orderModel.UserID + "," + orderModel.OrderTotal + "")); 
                            //MySQL(string.Format(" exec proc_YejiUp " + orderModel.UserID + "," + orderModel.OrderTotal + ""));
                            Response.Write("<script>alert('收货成功');location.href='OrderList.aspx';</script>");
                            return;
                            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('收货成功!');", true);
                        }
                        else
                        {
                            
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('收货失败!');", true);
                            return;
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('此订单记录不存在!');", true);
                    return;

                }
            }
        }

        protected void lbAll_Click(object sender, EventArgs e)
        {
            //ViewState["iType"] = 0;
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

    }
}