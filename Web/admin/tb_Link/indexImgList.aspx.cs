using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Library;
using System.Drawing;
//using LTP.Accounts.Bus;
//网站首页焦点图管理
namespace lgk.Web.tb_Link
{
    public partial class indexImgList : AdminPageBase
    {
		lgk.BLL.tb_Link bll = new lgk.BLL.tb_Link();
        public string type = "2";//焦点图
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }


        #region repeater

        public void BindData()
        {
            lgk.BLL.tb_Link linkBll = new BLL.tb_Link();
            bind_repeater(linkBll.GetList(" Link001="+type), Repeater1, "Status desc", trBonusNull, AspNetPager1);
        }

        #endregion

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
