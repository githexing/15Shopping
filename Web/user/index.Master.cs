using DataAccess;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Web.user
{
    public partial class index1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AllCore AC = new AllCore();
                //AC.
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
            if (HttpContext.Current.Request.Cookies["Culture"] != null && HttpContext.Current.Request.Cookies["Culture"].Value.ToString() == "en-us")// (Request.Cookies["Culture"].Value == "en-us")
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
    }
}