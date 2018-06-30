/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-25 15:57:18 
 * 文 件 名：		huigou.cs 
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
using Library;
using System.Web.UI.HtmlControls;
using DataAccess;

namespace Web.admin.licai
{
    public partial class huigou : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlL();
                bind();
            }
        }
        private void ddlL()
        {
            IList<lgk.Model.tb_level> ddlList = new lgk.BLL.tb_level().GetModelList("1=1");
            ddlLevel.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "请选择";
            ddlLevel.Items.Add(li);
            foreach (lgk.Model.tb_level item in ddlList)
            {
                ListItem items = new ListItem();
                items.Value = item.LevelID.ToString();
                items.Text = item.LevelName;
                ddlLevel.Items.Add(items);
            }
        }
        /// <summary>
        /// 根据搜索条件进行绑定
        /// </summary>
        private void bind()
        {
            string strWhere = string.Format("  isopend<>0  and StockAccount>0");
            string opStarTime = this.txtOpenStar.Text.Trim();
            string opEndTime = this.txtOpenEnd.Text.Trim();

            if (this.textUserCode.Value != "")
            {
                strWhere += " and UserCode like '%" + this.textUserCode.Value.Trim() + "%'";
            }
            if (Convert.ToInt32(this.ddlLevel.SelectedValue) == 0)
            {
                strWhere += " ";
            }
            else
            {
                strWhere += " and LevelID=" + Convert.ToInt32(ddlLevel.SelectedValue);
            }
            if (opStarTime != "" && opEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),OpenTime,120)  >= '" + opStarTime + "' ");
            }
            else if (opStarTime == "" && opEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),OpenTime,120)  <= '" + opEndTime + "' ");
            }
            else if (opStarTime != "" && opEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),OpenTime,120)  between '" + opStarTime + "' and '" + opEndTime + "' ");
            }
            if (this.txtRecommendCode.Value != "")
            {
                strWhere += " and RecommendCode like '%" + this.txtRecommendCode.Value.Trim() + "%'";
            }
            bind_repeater(userBLL.GetList(strWhere), Repeater1, "StockAccount desc", trBonusNull, AspNetPager1);
        }
        protected string getLevel(int LevelID)
        {
            return levelBLL.GetModel(LevelID).LevelName;
        }
        //格式验证
        bool CheckModeIn()
        {
            //==============================================买入
            if (gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)") == null)//股票价格表
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格未发布，不能进行此操作!');", true);
                return false;
            }
            if (this.txtMoney.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入每股的单价!');", true);
                return false;
            }
            if (!PageValidate.IsDecimalTwo(this.txtMoney.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格输入格式有误!');", true);
                return false;
            }
            if (Convert.ToDecimal(this.txtMoney.Text.Trim()) <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('股票价格不能小于零!');", true);
                return false;
            }
            //卖出价格不能高于当前发布交易价格的
            //卖出价格不能低于当前发布交易价格
            if (!CheckAmount(Convert.ToDecimal(this.txtMoney.Text.Trim())))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('买入价格不能高于系统发布价格的百分" + getGPAmount("kp_max_rate").ToString() + "；也不能低于发布价格的百分" + getGPAmount("kp_min_rate").ToString() + "!');", true);
                return false;
            }
            decimal account = smoneyBLL.GetModel().MoneyAccount;
            string strID = "";
            decimal allaccount = 0;
            if (rbtnSelete.Checked == true)
            {
                for (int i = 0; i < Repeater1.Items.Count; i++)
                {
                    HtmlInputCheckBox chk = (HtmlInputCheckBox)Repeater1.Items[i].FindControl("CheckBoxIn");
                    if (chk.Checked == true)
                    {
                        strID += chk.Value;
                        strID += ",";
                    }
                }
                if (strID.Length == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('没有可回购的用户!');", true);
                    return false;
                }

                strID = strID.Substring(0, strID.Length - 1);
                string[] array = strID.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    if (userBLL.GetModel(Convert.ToInt32(array[i])).StockAccount == 0)
                    {
                        MessageBox.Show(this, "回购的用户" + GetUserCode(Convert.ToInt32(array[i])) + "股票不能为零");
                        return false;
                    }
                    allaccount += Convert.ToDecimal(userBLL.GetModel(Convert.ToInt32(array[i])).StockAccount);
                }
            }
            else if (rbtnAll.Checked == true)
            {
                allaccount = Convert.ToDecimal(DbHelperSQL.GetSingle("select sum(StockAccount) from tb_user where isopend<>0 and  StockAccount>0"));
            }
            if (allaccount * Convert.ToDecimal(txtMoney.Text) * getGPAmount("hg_gp_rate")/100 > account)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('账户余额不足!');", true);
                return false;
            }

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
        protected void btn_ok_Click(object sender, EventArgs e)
        {
            if (CheckModeIn())
            {
                
                if (rbtnSelete.Checked==true)
                {
                    int zh_type = 1;
                    bool succeed = true;
                    string strID = "";
                    for (int i = 0; i < Repeater1.Items.Count; i++)
                    {
                        HtmlInputCheckBox chk = (HtmlInputCheckBox)Repeater1.Items[i].FindControl("CheckBoxIn");
                        if (chk.Checked == true)
                        {
                            strID += chk.Value;
                            strID += ",";
                        }
                    }
                    if (strID.Length == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('没有可回购的用户!');", true);
                        return;
                    }

                    strID = strID.Substring(0, strID.Length - 1);
                    string[] array = strID.Split(',');
                    for (int i = 0; i < array.Length; i++)
                    {

                        if (gp_opBLL.flag_HuiGou(Convert.ToInt32(array[i]), zh_type, Convert.ToDecimal(txtMoney.Text)) < 1)
                        {
                            succeed = false;
                            break;
                        }
                    }
                    if (succeed)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='huigou.aspx'", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作失败!');", true);
                    }
                }
                else if (rbtnAll.Checked == true)
                {

                    if (gp_opBLL.flag_HuiGou(Convert.ToDecimal(txtMoney.Text)) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='huigou.aspx'", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作失败!');", true);
                    }

                }
            }
                //int zh_type = 1;
                //bool succeed = true;
                //string strID = "";
                //for (int i = 0; i < Repeater1.Items.Count; i++)
                //{
                //    HtmlInputCheckBox chk = (HtmlInputCheckBox)Repeater1.Items[i].FindControl("CheckBoxIn");
                //    if (chk.Checked == true)
                //    {
                //        strID += chk.Value;
                //        strID += ",";
                //    }
                //}
                //if (strID.Length == 0)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('没有可回购的用户!');", true);
                //    return;
                //}

                //strID = strID.Substring(0, strID.Length - 1);
                //string[] array = strID.Split(',');
                //for (int i = 0; i < array.Length; i++)
                //{

                //    if (gp_opBLL.flag_HuiGou(Convert.ToInt32(array[i]), zh_type, Convert.ToDecimal(txtMoney.Text)) < 1)
                //    {
                //        succeed = false;
                //        break;
                //    }
                //}
                //if (succeed)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');window.location.href='forcehuigoujilu.aspx'", true);
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作失败!');", true);
                //}
            //}
        }

        protected void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)Repeater1.Items[i].FindControl("CheckBoxIn");
                chk.Checked = ckAll.Checked;
            }
        }
        protected string getName(int UserID)
        {
            return userBLL.GetModel(UserID).TrueName;
        }
        protected string getGender(int UserID)
        {
            return userBLL.GetModel(UserID).Gender == 0 ? "女" : "男";
        }
        protected string getIDcord(int UserID)
        {
            return userBLL.GetModel(UserID).IdenCode;
        }

        protected void rbtnSelete_CheckedChanged(object sender, EventArgs e)
        {
            ckAll.Enabled = true;
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)Repeater1.Items[i].FindControl("CheckBoxIn");
                chk.Disabled = false;
            }
        }

        protected void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            ckAll.Enabled = false;
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)Repeater1.Items[i].FindControl("CheckBoxIn");
                chk.Disabled = true;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("huigou.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("huigoujilu.aspx");
        }
    }
}
