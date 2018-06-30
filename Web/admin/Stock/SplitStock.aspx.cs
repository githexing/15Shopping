using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using DataAccess;
using System.Data;

namespace Web.admin.Stock
{
    public partial class SplitStock : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 6, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                ShowData();
                BindData();
            }
        }

        /// <summary>
        /// 拆分参数
        /// </summary>
        private void ShowData()
        {
            decimal dSplitPriceL = getParamAmount("Shares6");//原始MDD金币价
            decimal dSplitPriceB = getParamAmount("Shares3");//当前MDD金币价
            decimal dSplitPrice = getParamAmount("Shares7");//MDD金币拆分价格(系统拆分价格)

            ltSplitPriceB.Text = dSplitPriceB.ToString();//拆分前MDD金币价
            ltSplitPriceL.Text = dSplitPriceL.ToString();//拆分后MDD金币价
            ltSplitPrice.Text = dSplitPrice.ToString();//MDD金币拆分价格
            ltSplitRateOne.Text = "1"; //getRemark("Remark", "Shares9");//拆分比例
            ltSplitRate.Text = "2"; //getParamVarchar("Shares9").Trim();//拆分比例
            ltSplitTimes.Text = (getParamAmount("Shares8") + 1).ToString();//拆分次数

            if (dSplitPriceB == dSplitPrice)//当前MDD金币价与MDD金币拆分价格比较
            {
                ltltSplit.Text = "";
                ltltSplit.Visible = false;
                lbtnSubmit.Visible = true;
            }
            else
            {
                ltltSplit.Text = "当前不可拆分";
                ltltSplit.Visible = true;
                lbtnSubmit.Visible = false;
            }

            if (getParamInt("Shares") == 1)
            {
                ltltSplit.Text = "交易系统未关闭，不能拆分！";
                ltltSplit.Visible = true;
                lbtnSubmit.Visible = false;
            }
            else if (stockIssueBLL.GetModel("") == null)
            {
                ltltSplit.Text = "MDD金币未发行，不能拆分！";
                ltltSplit.Visible = true;
                lbtnSubmit.Visible = false;
            }
            else if (stockIssueBLL.GetSurplusAmount() > 0 || stockorderBLL.GetSurplusAmount() > 0)
            {
                ltltSplit.Text = "MDD金币未销售完，不能拆分！";
                ltltSplit.Visible = true;
                lbtnSubmit.Visible = false;
            }
        }

        private void BindData()
        {
            bind_repeater(stockSplitBLL.GetList("1=1"), Repeater1, "SplitDate desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {
            decimal dSplitPriceL = getParamAmount("Shares2");//原始股价
            decimal dSplitPriceB = getParamAmount("Shares3");//当前股价
            decimal dSplitPrice = getParamAmount("Shares6");//股票拆分价格(系统拆分价格)

            lgk.Model.tb_StockSplit model = new lgk.Model.tb_StockSplit();

            model.SplitPrice = dSplitPrice;
            model.SplitPriceB = dSplitPriceB;
            model.SplitPriceL = dSplitPriceL;
            model.SplitRate = "1:" + getParamVarchar("Shares9").Trim();
            model.SplitTimes = Convert.ToInt32(getParamAmount("shares8") + 1);
            model.SplitDate = DateTime.Now;

            if (getParamInt("Shares") == 1)
            {
                MessageBox.MyShow(this, "请将参数设置中的[MDD金币设置>>是否开启]改成0再拆分！");
                return;
            }

            if (stockIssueBLL.GetSurplusAmount() > 0 || stockorderBLL.GetSurplusAmount() > 0)
            {
                MessageBox.MyShow(this, "MDD金币未销售完，不能拆分！");
                return;
            }

            if (dSplitPriceB == dSplitPrice)
            {
                model.SplitID = stockSplitBLL.Add(model);
                if (model.SplitID > 1)
                {
                    stockSplitDetailBLL.SplitProcDetail(model);
                    UpdateParamVarchar("ParamVarchar", model.SplitTimes.ToString(), "Shares8");//将发行期数更新成1。
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('拆分成功！');window.location.href='SplitStock.aspx';", true);//股票拆分成功
                    BindData();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('当前MDD金币价必须等于MDD金币拆分价格才能拆分!');", true);
            }
        }

        protected void lbtnIssue_Click(object sender, EventArgs e)
        {
            Response.Redirect("StockIssue.aspx");
        }

        protected void lbtnSplit_Click(object sender, EventArgs e)
        {
            Response.Redirect("SplitStock.aspx");
        }
    }
}