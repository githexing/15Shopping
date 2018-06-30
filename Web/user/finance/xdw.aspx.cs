using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library;
using System.Collections.Generic;
namespace Web.user.finance
{
    public partial class xdw : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl1(this.Page, 1);//跳转3级密码


            if (!IsPostBack)
            {
                getLastLevel();
                Label1.Text = userBLL.GetModel(LoginUser.UserID).User011.ToString();
                Label2.Text = userBLL.GetModel(LoginUser.UserID).User012.ToString();
                BindData();
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }
        protected void getLastLevel()
        {
            if (Convert.ToDecimal(userBLL.GetModel(LoginUser.UserID).User011.ToString()) >= Convert.ToDecimal(paramBLL.GetModel(28).ParamVarchar))
            {
                btnSubmit.Style["display"] = "";
                btnSubmit.Text = "添加新点位";
            }
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "UserID=" + LoginUser.UserID ;
            return strWhere;
        }
        /// <summary>
        /// 填充
        /// </summary>
        protected void BindData()
        {
            bind_repeater(userMaleBLL.GetList(GetWhere()), rpTake, "AddDate desc", tr1, AspNetPager1);
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
                if (flag_fh(getLoginID()) > 0)
                {

                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('新点位产生成功!');", true);
                    Label1.Text = userBLL.GetModel(LoginUser.UserID).User011.ToString();
                    Label2.Text = userBLL.GetModel(LoginUser.UserID).User012.ToString();
                }
                else
                { MessageBox.MyShow(this, "新点位产生失败!!"); }
                BindData();
        }
    }
}
