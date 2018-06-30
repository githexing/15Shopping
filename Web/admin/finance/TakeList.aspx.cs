/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-6-2 11:16:55 
 * 文 件 名：		TakeList.cs 
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

namespace Web.admin.finance
{
    public partial class TakeList : AdminPageBase//System.Web.UI.Page
    {
        private string strWhere = "";
        string StarTime;
        string EndTime;
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this,16, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                bind2();
            }
            txtMoney.Value = GetTotalTake(0).ToString("0.00");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeMoney.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeList.aspx");
        }
        /// <summary>
        /// 提现记录查询条件
        /// </summary>
        /// <returns></returns>
        private string getWhere2()
        {
            StarTime = textStar.Text.Trim();
            EndTime = textEnd.Text.Trim();
            strWhere = " Flag=1";
            if (this.txtUserCode2.Value != "")
            {
                strWhere += " and u.usercode like '%" + this.txtUserCode2.Value.Trim() + "%'";
            }
            if (this.txtTrueName.Value != "")
            {
                strWhere += " and u.trueName like '%" + this.txtTrueName.Value.Trim() + "%'";
            }
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),TakeTime,120) >= '" + StarTime + "'");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),TakeTime,120) <= '" + EndTime + "'");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),TakeTime,120) between '" + StarTime + "' and '" + EndTime + "'");
            }
            if (dropDown.SelectedValue != "0")
            {
                strWhere += string.Format(" and Take001="+ dropDown.SelectedValue);
            }
            return strWhere;
        }
        public string TakeType(int type)
        {
            string str = "";
            if (type == 1)
            {
                str = "原始币";
            }
            if (type == 2)
            {
                str = "释放币";
            }

            return str;
        }
        /// <summary>
        /// 填充提现记录
        /// </summary>
        private void bind2()
        {
            bind_repeater(GetTakeList(getWhere2()), Repeater2, "TakeTime desc", tr1, AspNetPager2);
        }
        /// <summary>
        /// 导出申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void daochu_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            DataSet ds = GetTakeList(getWhere2());
            DataTable dv = ds.Tables[0];
            if (Repeater2.Items.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('不能导出空表格!');", true);
                return;
            }
            if (dv.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('错误的操作!');", true);
                return;
            }
            string str = ToTakeExecl(Server.MapPath("../../Upload"), dv);
            Response.Redirect("../../Upload/" + str.Replace("\\", "/").Replace("//", "/"), true);
        }
        /// <summary>
        /// 搜索提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            bind2();
        }
        /// <summary>
        /// 分页提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            bind2();
        }
    }
}
