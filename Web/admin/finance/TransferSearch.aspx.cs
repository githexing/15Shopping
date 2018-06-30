/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-16 20:06:22 
 * 文 件 名：		TransferSearch.cs 
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
    public partial class TransferSearch : AdminPageBase//System.Web.UI.Page//
    {
        private string strWhere = "";
        string StarTime;
        string EndTime;

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 12, getLoginID());//权限表：转账查询id=19
            spd.jumpAdminUrl1(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                bind();
            }
        }

        public void bind()
        {
            bind_repeater(GetTransferList(GetWhere()), Repeater1, "ChangeDate desc", tr1, AspNetPager1);
        }

        private string GetWhere()
        {
            //日期
            StarTime = this.txtChuStar.Text.Trim();
            EndTime = this.txtChuEnd.Text.Trim();

            strWhere = string.Format("0=0");
            if (textChuUserCode.Value.Trim() != "")
            {
                strWhere += string.Format(" and u1.UserCode like '%" + textChuUserCode.Value.Trim() + "%'");
            }
            //if (textRuUserCode.Value != "")
            //{
            //    strWhere += string.Format(" and u2.UserCode like '%" + textRuUserCode.Value + "%'");
            //}
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) >= '" + StarTime + "' ");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) <= '" + EndTime + "' ");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),c.ChangeDate,120) between '" + StarTime + "' and '" + EndTime + "' ");
            }
            return strWhere;
        }

        protected void btnChuSearch_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
    }
}