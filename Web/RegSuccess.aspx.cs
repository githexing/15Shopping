/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-2-4 16:49:04 
 * 文 件 名：		RegSuccess.cs 
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

namespace Web
{
    public partial class RegSuccess : AllCore//System.Web.UI.Page
    {
        protected string strUserCode = "";
        protected string strLevelName = "";
        protected string strNickname = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowInfo();
            }
        }

        /// <summary>
        /// 获取当前登录代理商ID
        /// </summary>
        /// <returns></returns>
        public long getLoginID()
        {
            if (Request.Cookies["A128076_user"] != null)
            {
                return Convert.ToInt64(Request.Cookies["A128076_user"]["Id"]);
            }
            else
            {
                return 0;
            }

        }

        private void ShowInfo()
        {
            if (Request.QueryString["UserCode"] != null)
            {
                lgk.Model.tb_user model = userBLL.GetModel(GetUserID(getStringRequest("UserCode")));
                strUserCode = model.UserCode;
                strLevelName = levelBLL.GetLevelName(model.LevelID, currentCulture);
                strNickname = model.NiceName.ToString();
            }
            else
            {
                Response.Redirect("Error.aspx");
            }
        }
    }
}
