using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Library;

namespace Web.admin.Stock
{
    public partial class TakeMoney : AdminPageBase
    {
        private string strWhere = "";
        string StarTime = "", EndTime = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 16, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                BindData();
            }

            txtMoney.Value = GetTotalTake(0,1).ToString("0.00");
        }

        private void BindData()
        {
            bind_repeater(GetTakeList(GetWhere()), Repeater1, "TakeTime desc", divno, AspNetPager1);
        }

        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            StarTime = txtStar.Text.Trim();
            EndTime = txtEnd.Text.Trim();
            strWhere = " b.Flag=0 and TakeType=1";
            if (this.txtUserCode.Value != "")
            {
                strWhere += " and u.usercode like  '%" + this.txtUserCode.Value.Trim() + "%'";
            }
            if (this.txtTrueName.Value != "")
            {
                strWhere += " and u.trueName like  '%" + this.txtTrueName.Value.Trim() + "%'";
            }
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),b.TakeTime,120)  >= '" + StarTime + "'");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),b.TakeTime,120)  <= '" + EndTime + "'");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),b.TakeTime,120)  between '" + StarTime + "' and '" + EndTime + "'");
            }
            return strWhere;
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void lbtnExport_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密碼

            DataSet ds = GetTakeList(GetWhere());
            DataTable dv = ds.Tables[0];
            if (Repeater1.Items.Count == 0)
            {
                MessageBox.MyShow(this, "不能导出空表格");
                return;
            }
            if (dv.Rows.Count == 0)
            {
                MessageBox.MyShow(this, "错误的操作");
                return;
            }
            string str = ToTakeExecl2(Server.MapPath("../../Upload"), dv);
            Response.Redirect("../../Upload/" + str.Replace("\\", "/").Replace("//", "/"), true);
        }

        protected void lbtnApply_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeMoney.aspx");
        }

        protected void lbtnWithdraw_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeList.aspx");
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = Convert.ToInt32(e.CommandArgument); //ID
            lgk.Model.tb_takeMoney takeMoneyInfo = takeBLL.GetModel(ID);
            lgk.BLL.tb_systemMoney sy = new lgk.BLL.tb_systemMoney();
            lgk.Model.tb_systemMoney system = sy.GetModel(1);
            if (takeMoneyInfo == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已删除,无法再进行此操作！');window.location.href='TakeMoney.aspx';", true);
            }
            else
            {
                if (takeMoneyInfo.Flag == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已审核,无法再进行此操作！');window.location.href='TakeMoney.aspx';", true);
                }
                else
                {
                    lgk.Model.tb_Stock stockInfo = stockBLL.GetModel("UserID=" + takeMoneyInfo.UserID);
                    lgk.Model.tb_user userInfo = userBLL.GetModel(Convert.ToInt32(takeMoneyInfo.UserID));
                    decimal dProfit = stockInfo.Number * (getParamAmount("shares5") - stockInfo.Price);

                    if (e.CommandName.Equals("Open"))//确认
                    {
                        takeMoneyInfo.Flag = 1;
                        takeMoneyInfo.Take006 = DateTime.Now;
                        if (takeBLL.Update(takeMoneyInfo) && UpdateSystemAccount("MoneyAccount", Convert.ToDecimal(takeMoneyInfo.RealityMoney), 0) > 0)
                        {
                            //发送短信通知
                            string content = GetLanguage("MessageTakeMoneyOK").Replace("{username}", userInfo.UserCode).Replace("{time}", Convert.ToDateTime(takeMoneyInfo.TakeTime).ToString("yyyy年MM月dd日HH时mm分")).Replace("{timeEn}", Convert.ToDateTime(takeMoneyInfo.TakeTime).ToString("yyyy/MM/dd HH:mm"));
                            SendMessage(Convert.ToInt32(takeMoneyInfo.UserID), userInfo.PhoneNum, content);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='TakeMoney.aspx';", true);
                        }
                    }
                    if (e.CommandName.Equals("Remove"))//删除
                    {
                        //加入流水账表
                        lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                        model.UserID = takeMoneyInfo.UserID;
                        model.Remark = "取消提现";
                        model.InAmount = takeMoneyInfo.TakeMoney;
                        model.OutAmount = 0;
                        model.BalanceAmount = dProfit + takeMoneyInfo.TakeMoney;
                        model.JournalDate = DateTime.Now;
                        model.JournalType = 1;
                        model.Journal01 = takeMoneyInfo.UserID;

                        bool bFalg = stockBLL.UpdateStockNumber(stockInfo.StockID, Convert.ToDecimal(takeMoneyInfo.TakeMoney), getParamAmount("shares5"), 1);

                        if (journalBLL.Add(model) > 0 && bFalg && takeBLL.Delete(ID))
                        {
                            MessageBox.MyShow(this, "取消成功");
                            BindData();
                        }
                        else
                        {
                            MessageBox.MyShow(this, "取消失败");
                        }
                    }
                }
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}