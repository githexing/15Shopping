using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Xml.Linq;

namespace Web.admin.system
{
    public partial class IpsConfig : System.Web.UI.Page
    {
        private const string TESTING_ENVIRONMENT = "Testing";
        private const string OFFICIAL_ENVIRONMENT = "Official";
        private const string CONFIG_FILE = @"~/IPS/Config.xml";
        XDocument xDoc = null;
        lgk.BLL.SecondPasswordBLL76 spd = new lgk.BLL.SecondPasswordBLL76();
        /// <summary>
        /// 加载配置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            if (!IsPostBack)
            {
                //加载配置项目
                xDoc = XDocument.Load(Server.MapPath(CONFIG_FILE));
                string environment = xDoc.Element("Root").Element("Environment").Value;
                XElement xEle = xDoc.Descendants("IPS").SingleOrDefault(t => t.Attribute("name").Value.Equals(environment));
                this.RadioButtonList1.Items[0].Selected = environment.Equals(TESTING_ENVIRONMENT) ? true : false;
                this.RadioButtonList1.Items[1].Selected = environment.Equals(OFFICIAL_ENVIRONMENT) ? true : false;

                //配置项目清单
                txtAccount.Text = xEle.Element("Account").Value;
                txtCertificate.Text = xEle.Element("Certificate").Value;

                //txtMerchantUrl.Text = xDoc.Descendants("MerchantUrl").First().Value;
                //txtFailUrl.Text = xDoc.Descendants("FailUrl").First().Value;
                //txtErrorUrl.Text = xDoc.Descendants("ErrorUrl").First().Value;
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtAccount.Text = "";
            txtCertificate.Text = "";
        }

        private void FillInfoByEnvironment(string environment)
        {
            xDoc = XDocument.Load(Server.MapPath(CONFIG_FILE));
            XElement xEle = xDoc.Descendants("IPS").SingleOrDefault(t => t.Attribute("name").Value.Equals(environment));
            txtAccount.Text = xEle.Element("Account").Value;
            txtCertificate.Text = xEle.Element("Certificate").Value;
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RadioButtonList1.Items[0].Selected == true)
            {
                FillInfoByEnvironment(TESTING_ENVIRONMENT);
            }
            else
            {
                FillInfoByEnvironment(OFFICIAL_ENVIRONMENT);
            }
        }

        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            try
            {
                xDoc = XDocument.Load(Server.MapPath(CONFIG_FILE));
                string environment = this.RadioButtonList1.Items[0].Selected == true ? TESTING_ENVIRONMENT : OFFICIAL_ENVIRONMENT;
                string account = txtAccount.Text.Trim();
                string certificate = txtCertificate.Text.Trim();
                //string MerchantUrl = txtMerchantUrl.Text.Trim();
                //string FailUrl = txtFailUrl.Text.Trim();
                //string ErrorUrl = txtErrorUrl.Text.Trim();

                XElement xEle = xDoc.Descendants("IPS").SingleOrDefault(t => t.Attribute("name").Value.Equals(environment));
                xEle.SetElementValue("Account", account);
                xEle.SetElementValue("Certificate", certificate);

                string url = Request.Url.ToString().ToLower();
                string url2 = url.Replace("http://www", "").Replace("http://vip", "");
                url2 = url2.Substring(0, url2.IndexOf("/"));
                url2 = "http://vip" + url2 + "/";

                xDoc.Descendants("MerchantUrl").First().Value = url2 + "IPS/OrderReturn.aspx";
                xDoc.Descendants("FailUrl").First().Value = url2 + "IPS/OrderFail.aspx";
                xDoc.Descendants("ErrorUrl").First().Value = url2 + "IPS/OrderError.aspx";

                xDoc.Element("Root").Element("Environment").SetValue(environment);
                xDoc.Save(Server.MapPath(CONFIG_FILE));

                MessageBox.Show(this, "保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "保存失败！");
                throw ex;
            }
        } 
    }
}