/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-2 16:27:11 
 * 文 件 名：		StockPriceEdit.cs 
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
using DataAccess;

namespace Web.admin.licai
{
    public partial class StockPriceEdit : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_update();
            }
        }

        private void bind_update()
        {
            if (Request.QueryString["ID"]!="" && Request.QueryString["ID"]!=null)
            {
                lgk.Model.gp_StockPrice model = gp_priceBLL.GetModel(Convert.ToInt32(Request.QueryString["ID"]));
                text_startDate.Value = model.BusinessTime.ToString();
                txt_back.Text = model.UpPrice.ToString();
                txt_open.Text = model.OpenMoney.ToString();
                if (model.PriceType==2)
                {
                    RadioButton1.Checked = true;
                    text_up.Value = model.Price.ToString();
                    text_upday.Value = model.Up_DropDayNumber.ToString();
                    text_down.Disabled = false;
                    text_downday.Disabled = false;
                }
                else if (model.PriceType ==3)
                {
                    RadioButton2.Checked = true;
                    text_down.Value = model.Price.ToString();
                    text_downday.Value = model.Up_DropDayNumber.ToString();
                    text_up.Disabled = false;
                    text_upday.Disabled = false;
                }
            }
        }
        //判断数据类型
        bool CheckDatabase()
        {
            //if (si.GetModel() == null)///是否已发行股票
            //{
            //    MessageBox.Show(this, "暂时不能进行此操作");
            //    return false;
            //}
            if (this.text_startDate.Value.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择日期!');", true);
                return false;
            }
            else if (Convert.ToDateTime(text_startDate.Value).Day < DateTime.Now.Day)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择今天之后的日期!');", true);
                return false;
            }
            if (!PageValidate.IsDecimalTwo(this.txt_back.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请正确输入收盘价!');", true);
                return false;
            }
            if (!PageValidate.IsDecimalTwo(this.txt_open.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请正确输入开盘价!');", true);
                return false;
            }
            if (this.RadioButton1.Checked == true)
            {
                if (this.text_up.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('日涨价不能为空!');", true);
                    return false;
                }
                if (this.text_upday.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('日涨天数不能为空!');", true);
                    return false;
                }
                if (this.text_up.Value.Trim() != "" || this.text_upday.Value.Trim() != "")
                {
                    if (!PageValidate.IsDecimalTwo(this.text_up.Value.Trim()))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('日涨价输入有误!');", true);
                        return false;
                    }
                    if (!PageValidate.IsNumber(this.text_upday.Value.Trim()))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('天数只能输入整数!');", true);
                        return false;
                    }
                }
            }
            if (this.RadioButton2.Checked == true)
            {
                if (this.text_down.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('日跌价不能为空!');", true);
                    return false;
                }
                if (this.text_downday.Value.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('日跌天数不能为空!');", true);
                    return false;
                }
                if (this.text_down.Value.Trim() != "" || this.text_downday.Value.Trim() != "")
                {
                    if (!PageValidate.IsDecimalTwo(this.text_down.Value.Trim()))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('日跌价输入有误!');", true);
                        return false;
                    }
                    if (!PageValidate.IsNumber(this.text_downday.Value.Trim()))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('天数只能输入整数!');", true);
                        return false;
                    }
                }
            }
            return true;
        }
        protected void btn_ok_Click(object sender, EventArgs e)
        {
            if (CheckDatabase())
            {
                bool flag = false;
                int PriceType = 1;
                DateTime BusinessTime = Convert.ToDateTime(this.text_startDate.Value);
                decimal UpPrice = Convert.ToDecimal(txt_back.Text.Trim());
                decimal OpenMoney = Convert.ToDecimal(this.txt_open.Text.Trim());
                decimal Price = 0;
                int Up_DropDayNumber = 1;
                decimal lastOpenMoney = Convert.ToDecimal(this.txt_open.Text.Trim());
                DateTime LastUp_DropDayNumber = DateTime.Now;

                if (RadioButton1.Checked == true && this.text_up.Value.Trim() != "" && this.text_upday.Value.Trim() != "") //涨价
                {
                    PriceType = 2;
                    Price = Convert.ToDecimal(this.text_up.Value);
                    Up_DropDayNumber = Convert.ToInt32(this.text_upday.Value) + 1;

                    //lastOpenMoney = Convert.ToDecimal(this.txt_open.Text) + Convert.ToDecimal(this.text_up.Value) * Convert.ToInt32(this.text_upday.Value);
                    LastUp_DropDayNumber = Convert.ToDateTime(this.text_startDate.Value).AddDays(Convert.ToDouble(this.text_upday.Value));
                }
                if (RadioButton2.Checked == true && this.text_down.Value.Trim() != "" && this.text_downday.Value.Trim() != "") //跌价
                {
                    PriceType = 3;
                    Price = Convert.ToDecimal(this.text_down.Value);
                    Up_DropDayNumber = Convert.ToInt32(this.text_downday.Value) + 1;
                    //lastOpenMoney = Convert.ToDecimal(this.txt_open.Text) - Convert.ToDecimal(this.text_down.Value) * Convert.ToInt32(this.text_downday.Value);
                    LastUp_DropDayNumber = Convert.ToDateTime(this.text_startDate.Value).AddDays(Convert.ToDouble(this.text_downday.Value));
                }

                //if (Convert.ToDecimal(this.txt_open.Text.Trim()) >= 1)
                //{
                //    MessageBox.Show(this, "开盘价格已经大于或者等于1");
                //    return;
                //}
                //if (Convert.ToInt32(DbHelperSQL.GetSingle(" delete from gp_StockPrice where convert(varchar(10),BusinessTime,120)>=convert(varchar(10),getdate(),120)"))>0)
                //{
                    
                //}
                DbHelperSQL.GetSingle(" delete from gp_StockPrice where convert(varchar(10),BusinessTime,120)>=convert(varchar(10),getdate(),120)");
                for (int i = 0; i < Up_DropDayNumber; i++)
                {
                    lgk.Model.gp_StockPrice price = new lgk.Model.gp_StockPrice();
                    if (i == 0)
                    {
                        price.PriceType = PriceType;
                        price.BusinessTime = BusinessTime;
                        price.UpPrice = UpPrice;
                        price.OpenMoney = OpenMoney;
                        price.Price = Price;
                        price.Up_DropDayNumber = Up_DropDayNumber - 1;
                        price.LastOpenMoney = lastOpenMoney;
                        price.LastUp_DropDayNumber = LastUp_DropDayNumber;
                        price.AddTime = DateTime.Now;
                    }
                    else if (i == 1)
                    {
                        if (PriceType == 2)
                        {
                            price.PriceType = PriceType;
                            price.BusinessTime = BusinessTime.AddDays(i);
                            price.UpPrice = OpenMoney;
                            price.OpenMoney = OpenMoney + Price * (i);
                            price.Price = Price;
                            price.Up_DropDayNumber = Up_DropDayNumber - 1 - i;
                            price.LastOpenMoney = lastOpenMoney + Price * (i);
                            price.LastUp_DropDayNumber = LastUp_DropDayNumber;
                            price.AddTime = DateTime.Now;
                        }
                        else
                        {
                            price.PriceType = PriceType;
                            price.BusinessTime = BusinessTime.AddDays(i);
                            price.UpPrice = OpenMoney;
                            price.OpenMoney = OpenMoney - Price * (i);
                            price.Price = Price;
                            price.Up_DropDayNumber = Up_DropDayNumber - 1 - i;
                            price.LastOpenMoney = lastOpenMoney - Price * (i);
                            price.LastUp_DropDayNumber = LastUp_DropDayNumber;
                            price.AddTime = DateTime.Now;
                        }
                    }
                    else
                    {
                        if (PriceType == 2)
                        {
                            price.PriceType = PriceType;
                            price.BusinessTime = BusinessTime.AddDays(i);
                            price.UpPrice = OpenMoney + Price * (i - 1);
                            price.OpenMoney = OpenMoney + Price * (i);
                            price.Price = Price;
                            price.Up_DropDayNumber = Up_DropDayNumber - 1 - i;
                            price.LastOpenMoney = lastOpenMoney + Price * (i);
                            price.LastUp_DropDayNumber = LastUp_DropDayNumber;
                            price.AddTime = DateTime.Now;
                        }
                        else
                        {
                            price.PriceType = PriceType;
                            price.BusinessTime = BusinessTime.AddDays(i);
                            price.UpPrice = OpenMoney - Price * (i - 1);
                            price.OpenMoney = OpenMoney - Price * (i);
                            price.Price = Price;
                            price.Up_DropDayNumber = Up_DropDayNumber - 1 - i;
                            price.LastOpenMoney = lastOpenMoney - Price * (i);
                            price.LastUp_DropDayNumber = LastUp_DropDayNumber;
                            price.AddTime = DateTime.Now;
                        }
                    }
                    if (gp_priceBLL.Add(price) > 0)
                    {
                        DbHelperSQL.GetSingle(" exec gp_jiaoyiliang");
                        flag = true;
                    }
                }
                if (flag == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('提交成功！');window.location.href='jiaoyijiage.aspx'", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('提交失败!');", true);
                }
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.text_down.Disabled = true;
            this.text_downday.Disabled = true;
            text_down.Value = "";
            this.text_downday.Value = "";

            this.text_up.Disabled = false;
            this.text_upday.Disabled = false;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.text_up.Disabled = true;
            this.text_upday.Disabled = true;
            this.text_up.Value = "";
            this.text_upday.Value = "";

            this.text_down.Disabled = false;
            this.text_downday.Disabled = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("jiaoyijiage.aspx");
        }
    }
}
