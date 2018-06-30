/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-23 11:51:51 
 * 文 件 名：		RemitManage.cs 
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
using System.Data;
using System.IO;

namespace Web.admin.finance
{
    public partial class RemitManage : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 34, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密碼
            if (!IsPostBack)
            {
                bind();
            }
        }

        private void bind()
        {
            bind_repeater(GetRemitAndBankList(GetWhere()), rpRemit, "AddDate desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "";

            string strStartTime = this.txtStar.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();

            strWhere = string.Format(" 1=1");
            if (this.dropState.SelectedValue == "1")
            {
                strWhere += " and r.State=0";
            }
            else if (this.dropState.SelectedValue == "2")
            {
                strWhere += " and r.State=1";
            }
            else if (this.dropState.SelectedValue == "3")
            {
                strWhere += " and r.State=-1";
            }

            if (this.txtUserCode.Text != "")
            {
                strWhere += " and u.UserCode like '%" + this.txtUserCode.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtTrueName.Text))
            {
                strWhere += " and u.TrueName like '%" + this.txtTrueName.Text.Trim() + "%'";
            }

            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  >= '" + strStartTime + "' ");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  <= '" + strEndTime + "' ");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  between '" + strStartTime + "' and '" + strEndTime + "' ");
            }
            return strWhere;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }
        public string StateType(string type)
        {
            string t = "";
            if (type == "0")
            {
                t = "<span style='color:red'>未审核....</span>";
            }
            else if (type == "1")
            {
                t = "<span style='color:blue'>已审核</span>";
            }
            else if(type == "-1")
            {
                t = "<span style='color:red'>已撤消</span>";
            }
            return t;
        }
        
        protected void rpRemit_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string s = "\r\n" + "\r\n" + "\r\n" + "\r\n" + "记录时间" + DateTime.Now.ToString() + "\r\n";
            string ip = Page.Request.UserHostAddress;
            try
            {
                long id = Convert.ToInt64(e.CommandArgument);
                lgk.Model.tb_remit remit = remitBLL.GetModel(id);
                if (remit == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已删除，无法再进行此操作!');window.location.href='RemitManage.aspx';", true);
                }
                else
                {
                    if (remit.State == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已审核，无法再进行此操作!');window.location.href='RemitManage.aspx';", true);
                    }
                    if (remit.State == -1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已撤销，无法再进行此操作!');window.location.href='RemitManage.aspx';", true);
                    }
                    else
                    {
                        if (e.CommandName.Equals("verify"))//确认
                        {
                            remit.State = 1;
                            remit.PassDate = DateTime.Now;

                            lgk.Model.tb_user user = userBLL.GetModel(remit.UserID);
                            user.StockAccount = user.StockAccount + remit.RemitMoney;
                            //加入流水账表

                            lgk.Model.tb_journal jmodelEmoney = new lgk.Model.tb_journal();
                            jmodelEmoney.UserID = remit.UserID;
                            jmodelEmoney.Remark = "报单积分汇款充值";
                            jmodelEmoney.InAmount = remit.RemitMoney;
                            jmodelEmoney.OutAmount = 0;
                            jmodelEmoney.BalanceAmount = user.StockAccount;
                            jmodelEmoney.JournalDate = DateTime.Now;
                            jmodelEmoney.JournalType = 5;
                            jmodelEmoney.Journal02 = 0;
                            jmodelEmoney.Journal01 = 0;
                            
                            if (remitBLL.Update(remit) && userBLL.Update(user) && UpdateSystemAccount("MoneyAccount", remit.RemitMoney, 1) > 0 && journalBLL.Add(jmodelEmoney) > 0)
                            {
                                add_userRecord(user.UserCode, DateTime.Now, remit.RemitMoney, 3);
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('确认成功!');", true);
                                bind();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('确认失败!');", true);
                            }
                        }
                    }
                    if (e.CommandName.Equals("Remove"))//撤销  
                    {
                        string type = "";
                        string res = "撤销失败";
                                              
                        if (remitBLL.Cancel(id))
                        {
                             res= "撤销成功";
                             ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('撤销成功!');", true);
                             bind();
                        }
                        else
                        {
                             ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('撤销失败!');", true);
                        }
                        
                        s = s + "操作人IP：:" + ip + "，操作人ID：" + getLoginID() + ",操作类型：撤销数据，撤销类型：" + type + "，撤销会员ID：" + remit.UserID + "，撤销结果：" + res + "\r\n";
                    }
                    if (e.CommandName.Equals("Query"))//查看凭证  
                    {
                        Response.Redirect("RemitVoucher.aspx?ID=" + id);
                    }
                }
            }
            catch (Exception ex)
            {
                s = s + "操作人IP：:" + ip + "，操作人ID：" + getLoginID() + ",程序异常：" + ex.Message + "\r\n";
            }
            LogHelper.SaveLog(s,"ManageRemit");
        }
        
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
        public string BankStr(string str)
        {
            string st = "";
            if (str.Trim() == "CMBC")
            {
                st = "招商银行";
            }
            else if (str.Trim() == "ICBC")
            {
                st = "工商银行";
            }
            else if (str.Trim() == "CCB")
            {
                st = "建设银行";
            }
            else if (str.Trim() == "SPDB")
            {
                st = "浦发银行";
            }
            else if (str.Trim() == "ABC")
            {
                st = "银行银行";
            }
            else if (str.Trim() == "CMSB")
            {
                st = "民生银行";
            }
            else if (str.Trim() == "SDB")
            {
                st = "深圳发展银行";
            }
            else if (str.Trim() == "CIB")
            {
                st = "兴业银行";
            }
            else if (str.Trim() == "BCM")
            {
                st = "交通银行";
            }
            else if (str.Trim() == "CEB")
            {
                st = "光大银行";
            }
            else if (str.Trim() == "BOC")
            {
                st = "中国银行";
            }
            else if (str.Trim() == "PAB")
            {
                st = "平安银行";
            }
            else if (str.Trim() == "GDB")
            {
                st = "广发银行";
            }
            else if (str.Trim() == "CNCB")
            {
                st = "中信银行";
            }
            else if (str.Trim() == "NBCB")
            {
                st = "宁波银行";
            }
            else if (str.Trim() == "ALIPAY-Alipayjszf")
            {
                st = "支付宝即时收款";
            }
            else if (str.Trim() == "zfb-JasZfbWap")
            {
                st = "JAS-支付宝WAP";
            }
            else if (str.Trim() == "alipay-WftZfb")
            {
                st = "威富通-支付宝扫码";
            }
            else if (str.Trim() == "ALIPAY-XingYeZfb")
            {
                st = "兴业支付宝WAP";
            }
            else if (str.Trim() == "WXZF-WftWx")
            {
                st = "威富通-微信扫码";
            }
            else if (str.Trim() == "WXZF-WftGzh")
            {
                st = "威富通-微信公众号";
            }
            else if (str.Trim() == "WXZF-JasWx")
            {
                st = "Jax-微信扫码";
            }
            else if (str.Trim() == "WXZF-WanWuGzh")
            {
                st = "万物-微信公众号";
            }
            else if (str.Trim() == "WXZF-WanWuWxSm")
            {
                st = "万物-微信扫码";
            }
            else
            {
                st = str.Trim();
            }
            return st;
        }
    }
}
