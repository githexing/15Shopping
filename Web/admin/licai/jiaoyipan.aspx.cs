/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-19 9:12:12 
 * 文 件 名：		jiaoyipan.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess;
using Library;

namespace Web.admin.licai
{
    public partial class jiaoyipan : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindMaiRu();
                bindMyMaiRu();
                bindMaiChu();
                bindMyMaiChu();
                bindBase();
                BindLoginMessage();
            }
        }
        /// <summary>
        /// 欢迎信息
        /// </summary>
        public void BindLoginMessage()
        {
            //this.lbl_uname.Text = "admin";
            //this.lbl_times.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Today.ToString("dddd", new System.Globalization.CultureInfo("zh-CN"));
            //this.lbl_ip.Text = Page.Request.UserHostAddress;
        }
        /// <summary>
        /// 其他信息
        /// </summary>
        private void bindBase()
        {
            //我的股票信息
            //decimal dai = Convert.ToDecimal(bn.GetNum(1, 2, 1, 0));
            //this.Label3.Text = dai.ToString();
            //this.Label2.Text = Convert.ToDecimal(DbHelperSQL.GetSingle("select sum(isnull(SurplusAmount,0)) from gp_StockIssue ")).ToString();
            //this.Label4.Text = Convert.ToDecimal(DbHelperSQL.GetSingle("select top(1)isnull(SurplusAmount,0) from gp_StockIssue order by AddTime asc")).ToString();
            ///最近交易的一条记录
            string sql = "select top 1 id from gp_BusinessNotes where status = 2 order by BusinessTime desc ";
            lgk.Model.gp_BusinessNotes note = gp_notesBLL.GetModel(Convert.ToInt32(DbHelperSQL.GetSingle(sql)));
            if (note==null)
            {
                this.lbl_mai1.Text = "";
                this.lbl_mai2.Text = "";
                this.lbl_amount.Text = "0.00";
                this.lbl_num.Text = "0";
                this.lbl_time.Text = "";
            }
            else
            {
                if (note.BusinessType == 1)
                {
                    this.lbl_mai1.Text = note.FromUserCode.ToString();
                    this.lbl_mai2.Text = note.UserCode.ToString();
                }
                if (note.BusinessType == 2)
                {
                    this.lbl_mai1.Text = note.UserCode.ToString();
                    this.lbl_mai2.Text = note.FromUserCode.ToString();
                }
                this.lbl_amount.Text = note.BusinessPrice.ToString();
                this.lbl_num.Text = note.BusinessAmount.ToString();
                this.lbl_time.Text = note.BusinessTime.ToString();
            }
        }
        /// <summary>
        /// 系统待卖出记录
        /// </summary>
        private void bindMaiChu()
        {
            string strWhere = string.Format(" BusinessType = 1 and status = 1 ");
            bind_repeater(gp_notesBLL.GetList(strWhere), Repeater3, "BusinessPrice asc,BusinessTime asc", tr3, AspNetPager3);
        }
        /// <summary>
        /// 我的待卖出记录
        /// </summary>
        private void bindMyMaiChu()
        {
            string strWhere = string.Format(" BusinessType = 1 and status = 1  and UserType=2");
            bind_repeater(gp_notesBLL.GetList(strWhere), Repeater4, "BusinessPrice desc", tr4, AspNetPager4);
        }
        /// <summary>
        /// 系统待买入记录
        /// </summary>
        private void bindMaiRu()
        {
            string strWhere = string.Format(" BusinessType = 2 and status = 1 ");
            bind_repeater(gp_notesBLL.GetList(strWhere), Repeater1, "BusinessPrice asc,BusinessTime asc", tr1, AspNetPager1);
        }
        /// <summary>
        /// 我的待买入记录
        /// </summary>
        private void bindMyMaiRu()
        {
            string strWhere = string.Format(" BusinessType = 2 and status = 1 and UserType=2");
            bind_repeater(gp_notesBLL.GetList(strWhere), Repeater2, "BusinessPrice desc", tr2, AspNetPager2);
        }
        protected void txt_num1_TextChanged(object sender, EventArgs e)
        {
            GetAmount();
            if (txt_amount1.Text.Trim() == "")
            {
                this.txt_amount1.Focus();
            }
        }

        protected void txt_amount1_TextChanged(object sender, EventArgs e)
        {
            GetAmount();
            if (txt_num1.Text.Trim() == "")
            {
                this.txt_num1.Focus();
            }
        }

        protected void bt_in_Click(object sender, EventArgs e)
        {
            if (CheckModeIn())
            {
                int num = Convert.ToInt32(this.txt_num1.Text);
                decimal amount = Convert.ToDecimal(this.txt_amount1.Text);
                if (gp_opBLL.A_SaleIn(num, amount)>0)//调用存储过程买股票
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='jiaoyipan.aspx'", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作失败!');", true);
                }
            }
        }

        protected void txt_num2_TextChanged(object sender, EventArgs e)
        {
            GetAmount2();
            if (this.txt_amount2.Text.Trim() == "")
            {
                this.txt_amount2.Focus();
            }
        }

        protected void txt_amount2_TextChanged(object sender, EventArgs e)
        {
            GetAmount2();
            if (this.txt_num2.Text.Trim() == "")
            {
                this.txt_num2.Focus();
            }
        }

        protected void bt_out_Click(object sender, EventArgs e)
        {
            if (CheckModeOut())
            {
                int num = Convert.ToInt32(this.txt_num2.Text);
                decimal amount = Convert.ToDecimal(this.txt_amount2.Text);
                if (gp_opBLL.A_SaleOut(num, amount) > 0)//调用存储过程卖股票
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='jiaoyipan.aspx'", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作失败!');", true);
                }
            }
        }
        public void GetAmount()
        {
            if (this.txt_num1.Text.Trim().Equals(""))
            {
                return;
            }
            if (this.txt_amount1.Text.Trim().Equals(""))
            {
                return;
            }
            if (!PageValidate.IsInt(this.txt_num1.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票数只能输入正整数!');", true);
                return;
            }
            if (!PageValidate.IsDecimalTwo(this.txt_amount1.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格输入格式有误!');", true);
                return;
            }
            int num = Convert.ToInt32(this.txt_num1.Text.Trim());
            decimal amount = Convert.ToDecimal(this.txt_amount1.Text.Trim());
            this.textAllamount1.Value = (num * amount).ToString();
        }

        public void GetAmount2()
        {
            if (this.txt_num2.Text.Trim().Equals(""))
            {
                return;
            }
            if (this.txt_amount2.Text.Trim().Equals(""))
            {
                return;
            }
            if (!PageValidate.IsInt(this.txt_num2.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票数只能输入正整数!');", true);
                return;
            }
            if (!PageValidate.IsDecimalTwo(this.txt_amount2.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格输入格式有误!');", true);
                return;
            }
            int num = Convert.ToInt32(this.txt_num2.Text.Trim());
            decimal amount = Convert.ToDecimal(this.txt_amount2.Text.Trim());
            this.textAllamount2.Value = (num * amount).ToString();
        }

        //格式验证
        bool CheckModeIn()
        {
            //==============================================买入
            //if (si.GetModel() == null)//股票发行管理表
            //{
            //    MessageBox.Show(this, "暂时不能进行此操作");
            //    return false;
            //}
            if (gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)") == null)//股票价格表
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格未发布，不能进行此操作!');", true);
                return false;
            }
            //if (sv.GetModel(1) == null)//股票价格临时变动表
            //{
            //    MessageBox.Show(this, "股票价格未发布，不能进行此操作");
            //    return false;
            //}
            if (this.txt_num1.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入购买的股票数!');", true);
                return false;
            }
            if (!PageValidate.IsInt(this.txt_num1.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('只能输入正整数!');", true);
                return false;
            }
            if (Convert.ToDecimal(this.txt_num1.Text.Trim()) < getGPAmount("buy_min_money"))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('最低交易股票数不能少于:" + getGPAmount("buy_min_money").ToString() + "!');", true);
                return false;
            }
            //if (!PageValidate.IsMultiple(100, this.txt_num1.Text.Trim()))
            //{
            //    MessageBox.Show(this, "股票数必须为100的倍数");
            //    return false;
            //}
            if (this.txt_amount1.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入每股的单价!');", true);
                return false;
            }
            if (!PageValidate.IsDecimalTwo(this.txt_amount1.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格输入格式有误!');", true);
                return false;
            }
            if (Convert.ToDecimal(this.txt_amount1.Text.Trim()) <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格不能小于零!');", true);
                return false;
            }
            //卖出价格不能高于当前发布交易价格的
            //卖出价格不能低于当前发布交易价格
            if (!CheckAmount(Convert.ToDecimal(this.txt_amount1.Text.Trim())))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('买入价格不能高于系统发布价格的百分" + getGPAmount("kp_max_rate").ToString() + "；也不能低于发布价格的百分" + getGPAmount("kp_min_rate").ToString() + "!');", true);
                return false;
            }
            decimal account = smoneyBLL.GetModel().MoneyAccount;
            if (Convert.ToDecimal(this.textAllamount1.Value.Trim()) > account)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('账户余额不足!');", true);
                return false;
            }

            return true;
        }

        bool CheckModeOut()
        {
            if (gp_issueBLL.GetModel() == null)//股票发行管理表
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票未发行，不能进行此操作!');", true);
                return false;
            }
            if (gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)") == null)//股票价格表
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格未发布，不能进行此操作!');", true);
                return false;
            }
            //if (sv.GetModel(1) == null)//股票价格临时变动表
            //{
            //    MessageBox.Show(this, "股票价格未发布，不能进行此操作");
            //    return false;
            //}

            if (this.txt_num2.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入要卖出的股票数!');", true);
                return false;
            }
            if (!PageValidate.IsInt(this.txt_num2.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('只能输入正整数,且和100成倍数关系!');", true);
                return false;
            }
            if (Convert.ToDecimal(this.txt_num2.Text.Trim()) < getGPAmount("sell_min_money"))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('最低交易股票数不能少于:" + getGPAmount("sell_min_money").ToString() + "!');", true);
                return false;
            }
            if (Convert.ToDecimal(this.txt_num2.Text.Trim()) > getGPAmount("sell_max_money"))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('最高交易股票数不能少于:" + getGPAmount("sell_ax_money").ToString() + "!');", true);
                return false;
            }
            if (!PageValidate.IsDecimalTwo(this.txt_amount2.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格输入格式有误!');", true);
                return false;
            }
            if (this.txt_amount2.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入每股的单价!');", true);
                return false;
            }
            if (Convert.ToDecimal(this.txt_amount2.Text.Trim()) <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格不能小于零!');", true);
                return false;
            }
            //卖出价格不能高于当前发布交易价格的
            //卖出价格不能低于当前发布交易价格
            if (!CheckAmount(Convert.ToDecimal(this.txt_amount2.Text.Trim())))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('当前卖出价格不能高于系统发布价格的百分" + getGPAmount("kp_max_rate").ToString() + "；也不能低于发布价格的百分" + getGPAmount("kp_min_rate").ToString() + "!');", true);
                return false;
            }

            //卖出股票判断
            if (Convert.ToDecimal(DbHelperSQL.GetSingle("select top(1)isnull(SurplusAmount,0) from gp_StockIssue where SurplusAmount>0 order by AddTime asc")) < Convert.ToDecimal(this.txt_num2.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('卖出股票数大于系统剩余的股票数!');", true);
                return false;
            }

            //==================================================================================
            return true;
        }

        public bool CheckAmount(decimal amount)
        {
            decimal hig = getGPAmount("kp_max_rate");
            decimal dow = getGPAmount("kp_min_rate");

            lgk.Model.gp_StockPrice vary = gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)");
            decimal varyAmount = Convert.ToDecimal(vary.OpenMoney);
            decimal higAmount = varyAmount * hig / 100 + varyAmount;
            decimal dowAmount = varyAmount - varyAmount * dow / 100;

            if (amount > higAmount)
            {
                return false;
            }
            else if (amount < dowAmount)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bindMaiRu();
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            bindMyMaiRu();
        }

        protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        {
            bindMaiChu();
        }

        protected void AspNetPager4_PageChanged(object sender, EventArgs e)
        {
            bindMyMaiChu();
        }
    }
}
