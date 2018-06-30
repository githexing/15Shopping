using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Mall
{
    public partial class Goodsdetail : PageCore//AllCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["gid"] != null && Request.QueryString["gid"] != "")
                {
                    ShowData();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "history.back();", true);
                }
            }
        }

        public void ShowData()
        {
            string gID = SafeHelper.NoHtml(Request.QueryString["gid"]);
            long Igid = 0;
            if (long.TryParse(gID, out Igid))
            {
                hdgid.Value = gID;
                hduid.Value = getLoginID().ToString();
                lgk.Model.tb_goods gModel = goodsBLL.GetModel(Igid);
                if (gModel != null)
                {
                    ltGoodsCode.Text = gModel.GoodsCode;
                    ltGoodsName.Text = gModel.GoodsName;
                    ltPrice.Text = gModel.Price.ToString();
                    ltRPrice.Text = gModel.RealityPrice.ToString();
                    ltKucun.Text = gModel.Goods002.ToString();
                    Image0.ImageUrl = "../../Upload/" + gModel.Pic1;
                    ltRemark.Text = gModel.Remarks;
                }
            }
        }

        /// <summary>
        /// 获取当前登录代理商ID
        /// </summary>
        /// <returns></returns>
        public long getLoginID()
        {
            if (System.Web.HttpContext.Current.Request.Cookies["A128076_user"] != null)
            {
                return Convert.ToInt64(System.Web.HttpContext.Current.Request.Cookies["A128076_user"]["Id"]);
            }
            else
            {
                return 0;
            }

        }

    }
}