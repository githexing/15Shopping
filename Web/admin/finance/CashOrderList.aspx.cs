using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.admin.finance
{
    public partial class CashOrderList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 16, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            bind_repeater(cashorderBLL.GetOrderList(GetWhere()), Repeater1, "OrderDate desc", tr1, AspNetPager1);
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                long iSUserID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "SUserID"));
                long iBUserID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "BUserID"));
                int iBStatus = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "BStatus"));
                int iSStatus = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "SStatus"));
                int iStatus = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status"));
                int IsFeedback = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "IsFeedback"));

                LinkButton lbtnUndo = (LinkButton)e.Item.FindControl("lbtnUndo");//撤销
                LinkButton lbtnPayfor = (LinkButton)e.Item.FindControl("lbtnPayfor");//确认收款
                LinkButton lbtnSend = (LinkButton)e.Item.FindControl("lbtnSend");//发货
                Literal ltStatus = (Literal)e.Item.FindControl("ltStatus");//订单状态
                LinkButton lbtnAdjustNoPay = (LinkButton)e.Item.FindControl("lbtnAdjustNoPay");//裁决买家未付款
                LinkButton lbtnAdjustReceived = (LinkButton)e.Item.FindControl("lbtnAdjustReceived");//裁决卖家已收款
                if (iSStatus == 0 && iBStatus == 0 && iStatus == 0)
                {
                    ltStatus.Text = "等待付款";
                    lbtnUndo.Visible = true;
                    lbtnPayfor.Visible = false;
                    lbtnSend.Visible = false;
                }
                else if (iSStatus == 0 && iBStatus == 1 && iStatus == 0)
                {
                    if (IsFeedback == 1)
                    {
                        ltStatus.Text = "未收到付款，待审核";
                        lbtnPayfor.Visible = false;
                        lbtnAdjustNoPay.Visible = true;
                        lbtnAdjustReceived.Visible = true;
                    }
                    else {
                        ltStatus.Text = "确认收款中";
                        lbtnPayfor.Visible = true;
                    }
                    lbtnUndo.Visible = false;                    
                    lbtnSend.Visible = false;
                }
                else if (iSStatus == 1 && iBStatus == 1 && iStatus == 0)
                {
                    ltStatus.Text = "等待发货";
                    lbtnUndo.Visible = false;
                    lbtnPayfor.Visible = false;
                    lbtnSend.Visible = true;
                }
                else if (iSStatus == 1 && iBStatus == 1 && iStatus == 1)
                {
                    ltStatus.Text = "已完成";
                    lbtnUndo.Visible = false;
                    lbtnPayfor.Visible = false;
                    lbtnSend.Visible = false;
                }
                else if (iStatus == 2 || iSStatus == 2 || iBStatus == 2)
                {
                    ltStatus.Text = "已撤销";
                    lbtnUndo.Visible = false;
                    lbtnSend.Visible = false;
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int iOrderID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Undo")
            {
                lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(iOrderID);
                if (cashorderInfo != null)
                {
                    cashorderBLL.UndoOrder(iOrderID, "后台撤销订单");//后台撤销订单

                    lgk.Model.Cashsell cashsellInfo = cashsellBLL.GetModel(cashorderInfo.CashsellID);
                    decimal dAccount = Convert.ToDecimal(cashsellInfo.Number);// + cashsellInfo.Charge;//数量+手续费
                    UpdateAccount("ShopAccount", cashsellInfo.UserID, dAccount + cashsellInfo.Charge, 1);//返还金币 + 保证金
                  //  UpdateAccount("ShopAccount", cashsellInfo.UserID, cashsellInfo.Charge, 1);//返还

                    //SetAccount(iUserID, dAccount, "EP币发货！", 1);
                    SetAccount(cashsellInfo.UserID, dAccount, "后台撤销订单，返回交易币！", cashsellInfo.UserID, (int)Library.AccountType.交易钱包);

                    //if (cashorderInfo.SStatus == 0 && cashorderInfo.BStatus == 0)
                    //{
                    //    userBLL.UserLock(cashorderInfo.BUserID, 1);
                    //}
                    //else
                    //{
                    //    userBLL.UserLock(cashorderInfo.SUserID, 1);
                    //    userBLL.UserLock(cashorderInfo.BUserID, 1);
                    //}

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('撤销成功！');window.location.href='CashOrderList.aspx';", true);
                }
            }

            if (e.CommandName == "Payfor")
            {
                lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(iOrderID);
                if (cashorderInfo != null)
                {
                    cashorderBLL.Update(cashorderInfo.SUserID, cashorderInfo.OrderID, DateTime.Now, "","",2);//确认已付款

                    cashorderBLL.Update(cashorderInfo.SUserID, iOrderID, DateTime.Now, "", "", 3);//发货

                    lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);

                    lgk.Model.Cashsell CashsellInfo = cashsellBLL.GetModel(cashbuyInfo.CashsellID);

                    decimal dNumber = CashsellInfo.Number;
                    //decimal dCharge = CashsellInfo.Charge;//总手续费
                    //decimal dMTaxRate = dNumber * getParamAmount("Gold3") / 100;//买家获得手续费
                    // decimal dCTaxRate = dNumber * getParamAmount("Gold4") / 100;//公司获得手续费

                    //decimal dTNumber = dNumber - dCharge + dMTaxRate;
                    decimal dTNumber = dNumber; // + dMTaxRate;
                   // decimal give = dTNumber * getParamAmount("Gold10") / 100; //买入获得系统赠送
                   // dTNumber += give; //买入获得系统赠送2018-3-15
                    //买家得到的是投资积分 StockMoney
                    UpdateAccount("ShopAccount", cashorderInfo.BUserID, dTNumber, 1);//发货给购买者

                    //UpdateSystemAccount("MoneyAccount", dCTaxRate, 1);

                    ////SetAccount(iUserID, dAccount, "EP币发货！", 1);
                    //SetAccount(cashorderInfo.BUserID, dTNumber, "金币收货！", cashorderInfo.SUserID, (int)Library.AccountType.交易钱包);
                   

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');window.location.href='CashOrderList.aspx';", true);
                }
            }

            if (e.CommandName == "Send")
            {
                lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(iOrderID);
                if (cashorderInfo != null)
                {
                    cashorderBLL.Update(cashorderInfo.SUserID, iOrderID, DateTime.Now, "", "", 3);//发货

                    lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);
                    //decimal dAccount = Convert.ToDecimal(cashbuyInfo.Number * cashbuyInfo.BuyNum);//每件数量*件数

                    lgk.Model.Cashsell CashsellInfo = cashsellBLL.GetModel(cashbuyInfo.CashsellID);

                    decimal dNumber = cashbuyInfo.Number;
                    //decimal dCharge = CashsellInfo.Charge;//总手续费
                    //decimal dMTaxRate = dNumber * getParamAmount("Gold3") / 100;//买家获得手续费
                    //decimal dCTaxRate = dNumber * getParamAmount("Gold4") / 100;//公司获得手续费

                    decimal dTNumber = dNumber;// + dMTaxRate;
                   // decimal give = dTNumber * getParamAmount("Gold10") / 100; //买入获得系统赠送
                  //  dTNumber += give; //买入获得系统赠送2018-3-15
                    //买家得到的是投资积分 StockMoney
                    UpdateAccount("ShopAccount", cashorderInfo.BUserID, dTNumber, 1);//发货给购买者

                   // UpdateSystemAccount("MoneyAccount", dCTaxRate, 1);

                    ////SetAccount(iUserID, dAccount, "EP币发货！", 1);
                    SetAccount(cashorderInfo.BUserID, dTNumber, "金币发货！", cashorderInfo.SUserID, (int)Library.AccountType.交易钱包);

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('发货成功！');window.location.href='CashOrderList.aspx';", true);
                }
            }
            if (e.CommandName == "AdjustNoPay")
            {
                lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(iOrderID);
                if (cashorderInfo != null)
                {
                    cashorderBLL.UndoOrder(iOrderID, "后台撤销订单");//后台撤销订单

                    lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);
                    lgk.Model.Cashsell cashsellInfo = cashsellBLL.GetModel(cashorderInfo.CashsellID);
                    //decimal dAccount = Convert.ToDecimal(cashbuyInfo.Amount);// + cashsellInfo.Charge;//数量+手续费
                    cashsellInfo.SaleNum = cashsellInfo.SaleNum - cashbuyInfo.BuyNum; //减掉购买的金额,卖方继续挂卖
                    cashsellBLL.Update(cashsellInfo);

                    //UpdateAccount("BonusAccount", cashsellInfo.UserID, dAccount, 1);//返还金币
                    //UpdateAccount("ShopAccount", cashsellInfo.UserID, cashsellInfo.Charge, 1);//返还金币

                    //SetAccount(iUserID, dAccount, "EP币发货！", 1);
                    // SetAccount(cashsellInfo.UserID, dAccount, "后台撤销订单，返回现金积分！", cashsellInfo.UserID, (int)Library.AccountType.现金积分);
                    // SetAccount(cashsellInfo.UserID, dAccount, "后台撤销订单，返回交易码！", cashsellInfo.UserID, (int)Library.AccountType.交易码);

                    //冻结买家
                    var user = userBLL.GetModel(cashorderInfo.BUserID);
                    user.IsLock = 1;
                    userBLL.Update(user);

                    lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
                    lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
                    log.LogMsg = "后台裁决买家【" + cashorderInfo.OrderCode + "】未付款，冻结帐号";
                    log.LogType = 23;//
                    log.LogLeve = 0;//
                    log.LogDate = DateTime.Now;
                    log.LogCode = "后台裁决买家未付款冻结帐号";//
                    log.IsDeleted = 0;
                    log.Log1 = cashorderInfo.BUserID.ToString();//用户UserID
                    log.Log2 = BrowserHelper.UserHostIP(this.Page);
                    log.Log3 = BrowserHelper.UserHostName();
                    log.Log4 = "";
                    syslogBLL.Add(log);

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='CashOrderList.aspx';", true);
                }
            }
            if (e.CommandName == "AdjustReceived")
            {
                lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(iOrderID);
                if (cashorderInfo != null)
                {
                    cashorderBLL.Update(cashorderInfo.SUserID, cashorderInfo.OrderID, DateTime.Now, "", "", 2);//确认已付款

                    cashorderBLL.Update(cashorderInfo.SUserID, iOrderID, DateTime.Now, "", "", 3);//发货

                    lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);

                    lgk.Model.Cashsell CashsellInfo = cashsellBLL.GetModel(cashbuyInfo.CashsellID);

                    decimal dNumber = cashbuyInfo.Amount;

                    decimal dTNumber = dNumber; // + dMTaxRate;
                   // decimal give = dTNumber * getParamAmount("Gold10") / 100; //买入获得系统赠送
                   // dTNumber += give; //买入获得系统赠送
                    //买家得到的是投资积分 StockMoney
                    UpdateAccount("ShopAccount", cashorderInfo.BUserID, dTNumber, 1);//发货给购买者

                    SetAccount(cashorderInfo.BUserID, dTNumber, "金币收货！", cashorderInfo.SUserID, (int)Library.AccountType.交易钱包);
                    //冻结卖家
                    var user = userBLL.GetModel(cashorderInfo.SUserID);
                    user.IsLock = 1;
                    userBLL.Update(user);

                    lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
                    lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
                    log.LogMsg = "后台裁决卖家订单【"+ cashorderInfo.OrderCode+ "】未付款，冻结帐号";
                    log.LogType = 24;//
                    log.LogLeve = 0;//
                    log.LogDate = DateTime.Now;
                    log.LogCode = "后台裁决卖家未付款冻结帐号";//
                    log.IsDeleted = 0;
                    log.Log1 = cashorderInfo.SUserID.ToString();//用户UserID
                    log.Log2 = BrowserHelper.UserHostIP(this.Page);
                    log.Log3 = BrowserHelper.UserHostName();
                    log.Log4 = "";
                    syslogBLL.Add(log);

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');window.location.href='CashOrderList.aspx';", true);
                }
            }
        }

        /// <summary>
        /// 加入流水账表
        /// </summary>
        /// <param name="iUserID">用户编号</param>
        /// <param name="dAccount">收发货数量</param>
        /// <param name="strRemark">备注</param>
        private void SetAccount(long iBUserID, decimal dAccount, string strRemark, long iSUserID,int JournalType)
        {
            #region 加入流水账表

            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            lgk.Model.tb_user userInfo = userBLL.GetModel(iBUserID);
            journalInfo.UserID = iBUserID;
            journalInfo.Remark = strRemark;//"EP币发货";
            journalInfo.RemarkEn = "Gold coin receipt!";
            journalInfo.InAmount = dAccount;
            journalInfo.OutAmount = 0;
            journalInfo.BalanceAmount = userInfo.StockMoney;//EP币收货！
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = JournalType;
            journalInfo.Journal01 = iSUserID;

            #endregion

            journalBLL.Add(journalInfo);
        }

        private string GetWhere()
        {
            string strWhere = "", strOrderCode = "";

            //购买状态(0未付款，1已付款，2已完成，3已终止,4未收到付款)
            strWhere = string.Format("(Status={0})",(int)Library.Enums.CashStatusTypes.未付款);

            #region 订单编号
            strOrderCode = txtOrderCode.Text.Trim();
            if (strOrderCode != "")
                strWhere += " AND OrderCode='" + strOrderCode + "'";
            #endregion

            #region 下定时间
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OrderDate,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OrderDate,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OrderDate,120)  between '" + strStartTime + "' AND '" + strEndTime + "'");
            }
            #endregion

            return strWhere;
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 分页提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}