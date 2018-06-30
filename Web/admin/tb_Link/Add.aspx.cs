using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Library;
using System.IO;
//using LTP.Accounts.Bus;
namespace lgk.Web.tb_Link
{
    public partial class Add : Page
    {
        string type = "1";//分类，友情链接、首页焦点图，商品焦点图
        int id = 0;
        lgk.BLL.SecondPasswordBLL76 spd = new BLL.SecondPasswordBLL76();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
            {
                id = int.Parse(Request.Params["id"].ToString());
                if (!IsPostBack)
                {
                    ShowInfo(id);
                }
            }
            if (Request.Params["Link001"] != null && Request.Params["Link001"].Trim() != "")
            {
                type = Request.Params["Link001"].ToString();
            }
            else
            {
              
                Response.Redirect("../index.aspx");
            }         
        }


        //绑定数据
        private void ShowInfo(int ID)
        {
            lgk.BLL.tb_Link bll = new lgk.BLL.tb_Link();
            lgk.Model.tb_Link model = bll.GetModel(ID);

            this.Image1.ImageUrl = "../../Upload/Banner/" + model.LinkImage;
            this.txtLinkName.Text = model.LinkName;
            this.txtLinkUrl.Text = model.LinkUrl;
            this.txtSort.Text = model.Status.ToString();
            ViewState["urlname1"] = model.LinkImage;

        }


        //保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            string upload1 = "";
           
            if (ViewState["urlname1"] != null)
            {
                upload1 = ViewState["urlname1"].ToString();
            }
            if (upload1 == "")
            {
                MessageBox.Show(this, "请上传图片");
                return;
            }
            upload1 = upload1.Substring(upload1.LastIndexOf("/") + 1, upload1.Length - upload1.LastIndexOf("/") - 1);
            int i = 0;
            if (!int.TryParse(txtSort.Text, out i) && int.Parse(txtSort.Text) < 0)
            {
                strErr += "排序号必需是大于或等于0的整数！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            string LinkImage = upload1;
            string LinkName = this.txtLinkName.Text;
            string LinkUrl = this.txtLinkUrl.Text;
            string sort = txtSort.Text.Trim();
           

            lgk.BLL.tb_Link bll = new lgk.BLL.tb_Link();
            lgk.Model.tb_Link model = new lgk.Model.tb_Link();
            if (id != 0)
            {
                model = bll.GetModel(id);
            }
            model.LinkImage = LinkImage;//链接图片
            model.LinkName = LinkName;//链接名称
            model.LinkUrl = LinkUrl;//链接地址
            model.Status = int.Parse(sort);//排序号
            model.Link001 = type;
            model.Link002 = "";

          
            if (id == 0)
            {
                bll.Add(model);
            }
            else
            {
                bll.Update(model);
            }
          //  MessageBox.ShowAndRedirect(this, "保存成功！", "add.aspx");
            MyRedirect(type);
        }


     


        //上传图片
        protected void btnupimg_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择图片!');", true);
                return;
            }
            string upload = UpLoadFile1("");
            ViewState["urlname1"] = upload;
            this.Image1.ImageUrl = "../../Upload/Banner/" + upload;
           // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('图片上传成功!');", true);
          
        }

        /// <summary>
        /// 上传商品图片
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        private string UpLoadFile1(string pName)
        {
            string _fileName = "";
            string _name = "";
            if (FileUpload1.HasFile)
            {
                _fileName = (Server.MapPath("../../Upload/"));
                if (!Directory.Exists(_fileName))
                    Directory.CreateDirectory(_fileName);
                _fileName = (Server.MapPath("../../Upload/Banner/"));
                if (!Directory.Exists(_fileName))
                    Directory.CreateDirectory(_fileName);

                if (pName == "")
                    _name = DateTime.Now.ToString("yyyyMMddHHmmss") + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.'));
                else
                    _name = pName;
                _fileName += _name;
                FileUpload1.SaveAs(_fileName);
            }
            return _name;
        }

        //跳转
        private void MyRedirect(string type)
        {
            string url = "List.aspx";
            switch (type)
            {
                case "2": url = "indexImgList.aspx"; break;
                case "3": url = "shopImgList.aspx"; break;
            }

            MessageBox.ShowAndRedirect(this,"保存成功",url);
        }
    }
}
