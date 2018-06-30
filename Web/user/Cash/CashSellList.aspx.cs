using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.user.Cash
{
    public partial class CashsellList : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

            if (!IsPostBack)
            {
                BindData();
                btnSearch.Text = GetLanguage("Search");//搜索
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            bind_repeater(cashsellBLL.GetInnerList(GetWhere()), Repeater1, "Price desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "[Cashsell].[UserID]=" + getLoginID() + "";

            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            if (currentCulture == "en-us")
            {
                strStartTime = txtStartEn.Text.Trim();
                strEndTime = txtEndEn.Text.Trim();
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),SellDate,120) >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),SellDate,120) <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),SellDate,120) between '" + strStartTime + "' AND '" + strEndTime + "'");
            }

            return strWhere;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                long iUserID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "UserID"));
                long iCashsellID = Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "CashsellID"));
                int iIsSell = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "IsSell"));
                //Literal ltSValues = (Literal)e.Item.FindControl("ltSValues");//卖家评分
                Literal ltStatus = (Literal)e.Item.FindControl("ltStatus");//可提现余额
                LinkButton lbtnCancel = (LinkButton)e.Item.FindControl("lbtnCancel");//撤销按钮
                LinkButton lbtnCancelEn = (LinkButton)e.Item.FindControl("lbtnCancelEn");//撤销按钮

                int iValue = cashcreditBLL.GetValues(iUserID, "SValues");
                //if (iValue > 0)
                //{
                //    for (int i = 0; i < iValue; i++)
                //    {
                //        ltSValues.Text += "<img alt='' src='../../../images/start.png' />";
                //    }
                //}

                lgk.Model.Cashsell cashsellInfo = cashsellBLL.GetModel(iCashsellID);
                if (cashsellInfo != null)
                {
                    if (cashsellInfo.IsUndo == 1)
                    {
                        ltStatus.Text = GetLanguage("Undone");//已撤销
                    }
                    else
                    {
                        ltStatus.Text = GetLanguage("NotRevoked");//未撤销
                    }

                    if (cashsellInfo.SaleNum == 0 && cashsellInfo.IsUndo == 0)
                    {
                        lbtnCancel.Visible = true;
                        lbtnCancelEn.Visible = true;
                    }
                    else
                    {
                        lbtnCancel.Visible = false;
                        lbtnCancelEn.Visible = false;
                    }
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "cancel")
            {
                long iCashsellID = Convert.ToInt64(e.CommandArgument);
                lgk.Model.Cashsell cashsellInfo = cashsellBLL.GetModel(iCashsellID);
                lgk.Model.tb_user userInfo = userBLL.GetModel(cashsellInfo.UserID);
                if (cashsellInfo == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordDeleted") + "');", true);//该记录已删除，无法再进行此操作
                    return;
                }
                if (cashsellInfo.IsSell > 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("GoldUnable") + "');", true);//金币已卖出，无法再进行此操作
                    return;//GoldUnable
                }

                #region 加入流水账表
                //现金积分
                //decimal dNumber = (cashsellInfo.Number + cashsellInfo.Charge) * cashsellInfo.UnitNum;
                decimal dNumber = (cashsellInfo.Number);

                lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                model.UserID = cashsellInfo.UserID;
                model.Remark = "取消订单,返回交易币";
                model.InAmount = dNumber;
                model.OutAmount = 0;
                model.BalanceAmount = userInfo.ShopAccount + dNumber;
                model.JournalDate = DateTime.Now;
                model.JournalType = (int)Library.AccountType.交易钱包;
                model.Journal01 = cashsellInfo.UserID;

                //交易码
                lgk.Model.tb_journal modelTrans = new lgk.Model.tb_journal();
                modelTrans.UserID = cashsellInfo.UserID;
                modelTrans.Remark = "取消订单，返回保证金";
                modelTrans.InAmount = cashsellInfo.Charge;
                modelTrans.OutAmount = 0;
                modelTrans.BalanceAmount = userInfo.ShopAccount + dNumber + cashsellInfo.Charge;
                modelTrans.JournalDate = DateTime.Now;
                modelTrans.JournalType = (int)Library.AccountType.交易钱包;
                modelTrans.Journal01 = cashsellInfo.UserID;

                #endregion

                if (journalBLL.Add(model) > 0 && journalBLL.Add(modelTrans) > 0 && cashsellBLL.UpdateUndo(iCashsellID, 1) && UpdateAccount("ShopAccount", getLoginID(), dNumber + cashsellInfo.Charge, 1) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("CancellationSuccess") + "');window.location.href='CashsellList.aspx';", true);//取消成功
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("FailedToCancel") + "');", true);//取消失败
                }
            }
        }
    }
}