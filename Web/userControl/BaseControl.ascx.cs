using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Web.userControl
{
    public partial class BaseControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 会员信息
        /// </summary>
        public lgk.Model.tb_user LoginUser
        {
            get
            {
                try
                {
                    return new lgk.BLL.tb_user().GetModel(getLoginID());
                }
                catch
                {
                    return new lgk.Model.tb_user();
                }

            }
            set
            {

            }
        }

        public int getLoginID()
        {
            if (Request.Cookies["A128076_user"] != null)
            {
                return Convert.ToInt32(Request.Cookies["A128076_user"]["Id"]);
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 根据给定的键值，获取语言key的值。
        /// </summary>
        /// <param name="key">给定的键值</param>
        /// <returns></returns>
        public string GetLanguage(string key)
        {
            string lang = "zh-cn";//中文
            if (HttpContext.Current.Request.Cookies["Culture"].Value.ToString() == "en-us")// (Request.Cookies["Culture"].Value == "en-us")
            {
                lang = "en-us";//英语
            }
            else
            {
                lang = "zh-cn";//中文
            }
            XDocument doc = new XDocument();
            doc = XDocument.Load(Server.MapPath("~/language/lang.xml"));

            XElement xEle = doc.Descendants("key").SingleOrDefault(t => t.Attribute("name").Value.Equals(key));
            xEle = xEle.Descendants("langtype").SingleOrDefault(t => t.Attribute("name").Value.Equals(lang));
            if (xEle != null)
            {
                return xEle.Value;
            }
            try
            {
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// 无分页绑定
        /// </summary>
        /// <param name="dateSet">数据源</param>
        /// <param name="Repeater1">绑定的Repeater控件名</param>
        /// <param name="sort">排序</param>
        /// <param name="span1">无数据时提示的控件名</param>
        /// <param name="pagesize">取几条数据</param>
        public void bind_repeater(DataSet dateSet, Repeater Repeater1, string sort, HtmlControl span1, int pagesize)
        {
            DataSet ds = null;
            if (dateSet != null)
            {
                try
                {
                    ds = dateSet;
                }
                catch (Exception)
                {
                    ds = null;
                }
            }
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = sort;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = 0;
            pds.PageSize = pagesize;
            Repeater1.DataSource = pds;
            Repeater1.DataBind();
            if (span1 != null)
            {
                span1.Style.Add("display", "none");
                if (dv.Count <= 0)
                {
                    span1.Style.Add("display", "block");
                }
            }
        }
    }
}
    
