using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Library;
using System.Web.UI.HtmlControls;
using System.Net;

namespace Web.admin.system
{
    public partial class Param : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 26, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName.ToString();
            if (name == "Update")
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                HtmlInputText valuemoney = (HtmlInputText)e.Item.FindControl("paramValue");
                string msg = "";
                UpdateParam(id, valuemoney, out msg);
                MessageBox.Show(this, msg);
            }
        }

        private void BindData()
        {
            bind_repeater(paramBLL.GetList(" ParamAmount>0 and ParamInt<>0"), Repeater1, "ParamInt ASC", null);
        }

        protected void lbtnUpdateAll_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            string msg = "";
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                string msgrow = "";
                HtmlInputText valuetext = (HtmlInputText)Repeater1.Items[i].FindControl("paramValue");
                HtmlInputHidden idinput = (HtmlInputHidden)Repeater1.Items[i].FindControl("hiddenid");
                UpdateParam(Convert.ToInt32(idinput.Value), valuetext, out msgrow);
                msg += msgrow;
            }
            MessageBox.Show(this, "全部更新完成");
        }

        private bool UpdateParam(int id, HtmlInputText valuemoney, out string msg)
        {
            decimal value = 0;
            lgk.Model.tb_globeParam paramInfo = paramBLL.GetModel(id);
            string s = "\r\n" + "\r\n" + "\r\n" + "\r\n" + "记录时间" + DateTime.Now.ToString() + "\r\n";
            if (paramInfo != null)
            {
                // 错误的信息
                IPAddress ads = Dns.GetHostAddresses(Environment.MachineName)[0];
                string ip = Page.Request.UserHostAddress;
                s = s + "操作mac："+ ads.ToString() + ",操作IP" + ip + ",操作人：:" + getLoginID() + ",修改字段："+ paramInfo.ParamName+",修改前的值："+ paramInfo.ParamVarchar+ "，修改后的值："+ valuemoney.Value + "\r\n";
                
                string strRemark = paramInfo.Remark.Replace("</font>", "").Replace("<font color=\"red\">", "").Replace("&gt;", ">");
                if(strRemark.IndexOf(">>")>0)
                    strRemark = strRemark.Remove(0, strRemark.IndexOf(">>")+2);
                msg = "更新完成[" + strRemark + "]\\n";
                if (valuemoney.Value == "") { msg = "请输入参数值[" + strRemark + "]\\n"; return false; }

                lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
                lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
                log.LogMsg =  strRemark + ",修改前值："+ paramInfo.ParamVarchar+ "，修改后值："+ valuemoney.Value ;
                log.LogType = 10;//修改参数
                log.LogLeve = 0;//
                log.LogDate = DateTime.Now;
                log.LogCode = "修改参数";//修改参数
                log.IsDeleted = 0;
                log.Log1 = LoginAdmin.UserName;//用户UserID
                log.Log2 = ip;// 
                log.Log3 = paramInfo.ParamName;//修改字段
                log.Log4 = ads.ToString();
                syslogBLL.Add(log);

                if (paramInfo.ParamType == 1)//Decimal
                {
                    try
                    {
                        value = Convert.ToDecimal(valuemoney.Value);
                    }
                    catch
                    {
                        msg = "参数格式错误[" + strRemark + "]\\n"; return false;
                    }
                    if (value < 0)
                    {
                        msg = "请输入大于等于0的参数[" + strRemark + "]\\n"; return false;
                    }
                }
                else if (paramInfo.ParamType == 2)//Int
                {
                    try
                    {
                        value = Convert.ToInt32(valuemoney.Value);
                    }
                    catch
                    {
                        msg = "请输入整数[" + strRemark + "]\\n"; return false;
                    }
                }
                else if (paramInfo.ParamType == 3)//Decimal
                {
                    value = Convert.ToDecimal(valuemoney.Value);

                    if (value > 100)
                    {
                        msg = "比率不能大于100%的参数[" + strRemark + "]\\n"; return false;
                    }
                }

                if (paramInfo.ParamType <= 3)
                    paramInfo.ParamVarchar = value.ToString();
                else if (paramInfo.ParamType == 4)
                    paramInfo.ParamVarchar = valuemoney.Value;
                LogHelper.SaveLog(s,"Param");
                //paramInfo.ParamVarchar = paramInfo.ParamType == 1 ? valuemoney.Value : value.ToString();
               // System.IO.File.AppendAllText(Server.MapPath("~/log/ParamRecodelog.log"), s);
                if (!paramBLL.Update(paramInfo))
                    msg = "更新出错[" + strRemark + "]\\n"; return false;
            }
            else
            {
                msg = "数据不存在，无法更新！";
            }
           
            return true;
        }
    }
}
