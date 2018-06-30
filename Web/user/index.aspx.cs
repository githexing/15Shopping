/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-16 11:51:31 
 * 文 件 名：		index.cs 
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

namespace Web.user
{
    public partial class index : PageCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData1();
                DataInit();
                BindData();
                string culture;
                if (HttpContext.Current.Request.Cookies["Culture"] != null)
                {
                    culture = HttpContext.Current.Request.Cookies["Culture"].Value;
                }
            }
        }
        public string lefturl;
        public string righturl;
        private void DataInit()
        {
            string strNewUrl = Request.Url.ToString().Replace("/user/finance/", "/").Replace("/user/business/", "/").Replace("/user/Info/", "/").Replace("/user/member/", "/").Replace("/user/team/", "/").Replace("/user/product/", "/").Replace("/user/shop/", "/").Replace("/user/", "/");//取得当前的外网
            strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径
            string url = strNewUrl + "user/LinkRegist.aspx?i=" + LoginUser.UserID;
            lefturl = url + "&la=1";
            righturl = url + "&la=2";
        }

        //public string rem_url = "";
        /// <summary>
        /// 非会员限制
        /// </summary>
        protected void BindData1()
        {
            if (LoginUser.IsOpend!=2)
            {

            }

        }
        /// <summary>
        /// 填充信息
        /// </summary>
        protected void BindData()
        {
            if (Language == "zh-cn")
            {
                bind_repeater(newsBLL.GetList(8, "NewsType=0 and New01=0", "PublishTime desc"), Repeater1, "PublishTime desc", tr1, 8);
            }
            else if (Language == "en-us")
            {
                bind_repeater(newsBLL.GetList(8, "NewsType=0 and New01=1", "PublishTime desc"), Repeater1, "PublishTime desc", tr1, 8);
            }

        }
       
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HttpCookie Culture;

            if (HttpContext.Current.Request.Cookies["Culture"] == null)
                Culture = new HttpCookie("Culture");
            else
                Culture = HttpContext.Current.Request.Cookies["Culture"];
            
            Response.AppendCookie(Culture);
            Response.Redirect("index.aspx");
        }

        protected void btnActive_Click(object sender, EventArgs e)
        {
            decimal regopen = getParamAmount("RegOpen");
            if (LoginUser.Emoney < regopen)
            {
                MessageBox.ShowAndRedirect(this.Page, GetLanguage("RegOpenMust"), "index.aspx");//原始币不足
                return ;
            }

            int flag = flag_ActivationUser(LoginUser.UserID, LoginUser.UserID);
            if (flag != 0)
            {
                if (flag == -1)
                {
                    MessageBox.ShowAndRedirect(this.Page, GetLanguage("ActivationUserFail"), "index.aspx");//激活会员失败
                }
                else
                {
                    MessageBox.ShowAndRedirect(this.Page, GetLanguage("RegOpenMust"), "index.aspx");//原始币不足
                }
                return;
            }
            else
                MessageBox.ShowAndRedirect(this.Page, GetLanguage("Congratulations"), "index.aspx");//恭喜您激活成功
        }

    }
}