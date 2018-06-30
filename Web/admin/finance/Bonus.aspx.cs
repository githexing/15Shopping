/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-14 12:33:52 
 * 文 件 名：		Bonus.cs 
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
using System.Collections;
using System.IO;

namespace Web.admin.finance
{
    public partial class Bonus : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 14, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            bind_repeater(bo.GetAList(GetWhere()), Repeater1, "SttleTime desc", tr1, AspNetPager1);
        }

        private string GetWhere()
        {
            string strWhere = "";
            string StarTime = this.txtStar.Text.Trim();
            string EndTime = txtEnd.Text.Trim();

            strWhere = string.Format("Amount > 0");
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SttleTime,120) >= '" + StarTime + "'");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SttleTime,120) <= '" + EndTime + "'");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SttleTime,120) between '" + StarTime + "' and '" + EndTime + "'");
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

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //导出
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            MyExcel();
        }
    
        private string getWhere2()
        {
            string strWhere = "";
            string StarTime = this.txtStar.Text.Trim();
            string EndTime = txtEnd.Text.Trim();

            strWhere = string.Format(" and Amount<>0  ");
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),SttleTime,120) >= '" + StarTime + "'");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format("  and Convert(nvarchar(10),SttleTime,120) <= '" + EndTime + "'");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format("  and Convert(nvarchar(10),SttleTime,120) between '" + StarTime + "' and '" + EndTime + "'");
            }
            return strWhere;
        }

        private void MyExcel() 
        {
            DataSet ds = new lgk.BLL.tb_bonus().GetListByUser(getWhere2());//获取所有时间段的奖金信息
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                string FilePath = Server.MapPath("/userfiles/");// +"\\" + ExcelFolder + "\\";
                if(!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
                //生成列的中文对应表
                Hashtable nameList = new Hashtable();
                nameList.Add("UserCode", "用户名");
                nameList.Add("sf", "应发奖金");
                nameList.Add("BankAccountUser", "开户姓名");
                nameList.Add("BankName", "开户行");
                nameList.Add("BankAccount", "卡号");
                nameList.Add("BankBranch", "支行名称");
                
                //利用excel对象
                DataToExcel dte = new DataToExcel();
                string filename = "";
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        filename = dte.DataExcel(ds.Tables[0], "奖金", FilePath, nameList);
                    }
                }
                catch
                {
                    //dte.KillExcelProcess();
                }

                if (filename != "")
                {
                    string path = FilePath +  filename;
                    Response.Redirect("/userfiles/" + filename, true);
                }
            }
            else {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('当前无数据导出!');", true);
            }
        }
    }
}