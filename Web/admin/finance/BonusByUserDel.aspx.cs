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

namespace Web.admin.finance
{
    public partial class BonusByUserDel : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //jumpMain(this, 14, getLoginID());//权限
            //spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                bind();
            }
        }
        private void bind()
        {
            DataSet ds = new lgk.BLL.BonusOperationBLL().GetList_money(getWhere());
            bind_repeater(ds, Repeater1, "SttleTime desc", trBonusNull, AspNetPager1);
        }

        private string getWhere()
        {
            string uid = Request.QueryString["uid"];
            string time = Request.QueryString["SttleTime"];
            string strWhere = string.Format("  Amount<>0 and Bonus001=1 ");
            if (!string.IsNullOrEmpty(time))
            {
                strWhere += " and Convert(nvarchar(10),SttleTime,120)  = '" + time.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(uid))
            {
                strWhere += " and b.userID=" + uid.Trim();
            }
            return strWhere;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string name = e.CommandName.Trim();
            string type = e.CommandArgument.ToString().Trim();
            string uid = Request.QueryString["uid"];
            string time = Request.QueryString["SttleTime"];
            if (name == "delete")
            {
                #region delete
                if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(time))
                {
                    string where = "userid=" + uid.Trim() + " and Convert(nvarchar(10),SttleTime,120)='" + time.Trim() + "'";
                    int t = 0;
                    bool flag = int.TryParse(type, out t);
                    if (flag)
                    {
                        where += " and typeID=" + t;
                        var rs = bonusBLL.Delete(where);
                    }
                    else if (type == "Revenue")
                    {
                        where += " and Revenue>0";
                        var result = bonusBLL.DeleteRevenue(where);
                    }
                    else if (type == "Bonus006")
                    {
                        where += " and Bonus006>0";
                       var res= bonusBLL.DeleteBonus006(where);
                    }

                    MessageBox.Show(this, "删除成功");
                }
                else
                {
                    MessageBox.Show(this, "数据异常，删除失败！");
                }
                #endregion
            }
            bind();
        }
    }
}
