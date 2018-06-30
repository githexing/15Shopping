using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.userControl
{
    public partial class Right : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataInit();
            }
        }
        private void DataInit()
        {
            string strNewUrl = Request.Url.ToString().Replace("/user/finance/", "/").Replace("/user/business/", "/").Replace("/user/Info/", "/").Replace("/user/member/", "/").Replace("/user/team/", "/").Replace("/user/product/", "/").Replace("/user/shop/", "/").Replace("/user/", "/");//取得当前的外网
            strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径
            rem_url = strNewUrl + "/user/LinkRegist.aspx?i=" + LoginUser.UserID;
        }

        public string rem_url = "";
    }
}