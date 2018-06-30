using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.IO;

namespace Web.user.member
{
    public partial class Recast : PageCore
    {
        lgk.BLL.tb_systemBank sysbank = new lgk.BLL.tb_systemBank();
        lgk.BLL.tb_remit remitbll = new lgk.BLL.tb_remit();
        ImgeHandel imghandle = new ImgeHandel();
        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl1(this.Page, 1);//跳转三级密码

            if (!IsPostBack)
            {
                ShowInfo();
                BindBank();
                BankBind();
                Bank();
                ZFBData();
                OurWXData();
                BindLevel();
                BindData();
                //  btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        private void ShowInfo()
        {
            LitTotalAAmount.Text = LoginUser.Emoney.ToString();
            LiteraCapValue.Text =getParamAmount("Level" + LoginUser.User004).ToString();
            BindData();
            //if (LoginUser.IsOut == 1)
            //{
            //    // btnSubmit.Visible = true;
            //    LitWhetherCast.Text = GetLanguage("YesCast");
            //}
            //else
            //{
            //    //   btnSubmit.Visible = false;
            //    LitWhetherCast.Text = GetLanguage("NoCast");
            //}
        }

       
        public void BindBank()
        {
            try
            {
                bank.Text = sysbank.strGetModel(" IsMor=1").BankName.ToString();
                bankAccount.Text = sysbank.strGetModel(" IsMor=1").BankAccount.ToString();
                bankUserName.Text = sysbank.strGetModel(" IsMor=1").BankAccountUser.ToString();

            }
            catch (Exception)
            {

                bank.Text = "";
                bankAccount.Text = "";
                bankUserName.Text = "";
            }

        }
        private void BindLevel()
        {
            if (LoginUser.LevelID == 1)
            {
                droplevel.Value = "普通会员";
            }
            if (LoginUser.LevelID == 2)
            {
                droplevel.Value = "黄金会员";
            }
            if (LoginUser.LevelID == 3)
            {
                droplevel.Value = "铂金会员";
            }
            if (LoginUser.LevelID == 4)
            {
                droplevel.Value = "裸钻会员";
            }
            if (LoginUser.LevelID == 5)
            {
                droplevel.Value = "蓝钻会员";
            }
            if (LoginUser.LevelID == 6)
            {
                droplevel.Value = "至尊会员";
            }
        }
        public void BankBind()
        {
            string strBankName = new lgk.BLL.tb_bankName().GetModel(1).BankName;

            string[] a = strBankName.Split(',');
            ListItem item_list = new ListItem();
            item_list.Value = "0";
            item_list.Text = GetLanguage("PleaseSselect");//"-请选择-"
            this.OutBank.Items.Add(item_list);
            foreach (string b in a)
            {
                ListItem item_list1 = new ListItem();
                item_list1.Value = b;
                item_list1.Text = b;
                this.OutBank.Items.Add(item_list1);
            }
        }
        private void Bank()
        {

            ourbankname.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            ourbankname.Items.Add(li);
            ListItem li1 = new ListItem();
            li1.Value = "CMBC";
            li1.Text = "招商银行";
            ourbankname.Items.Add(li1);
            ListItem li2 = new ListItem();
            li2.Value = "ICBC";
            li2.Text = "工商银行";
            ourbankname.Items.Add(li2);
            ListItem li3 = new ListItem();
            li3.Value = "CCB";
            li3.Text = "建设银行";
            ourbankname.Items.Add(li3);
            ListItem li4 = new ListItem();
            li4.Value = "SPDB";
            li4.Text = "浦发银行";
            ourbankname.Items.Add(li4);
            ListItem li5 = new ListItem();
            li5.Value = "ABC";
            li5.Text = "农业银行";
            ourbankname.Items.Add(li5);
            ListItem li6 = new ListItem();
            li6.Value = "CMSB";
            li6.Text = "民生银行";
            ourbankname.Items.Add(li6);
            ListItem li7 = new ListItem();
            li7.Value = "SDB";
            li7.Text = "深圳发展银行";
            ourbankname.Items.Add(li7);
            ListItem li8 = new ListItem();
            li8.Value = "CIB";
            li8.Text = "兴业银行";
            ourbankname.Items.Add(li8);
            ListItem li9 = new ListItem();
            li9.Value = "BCM";
            li9.Text = "交通银行";
            ourbankname.Items.Add(li9);
            ListItem li10 = new ListItem();
            li10.Value = "CEB";
            li10.Text = "光大银行";
            ourbankname.Items.Add(li10);
            ListItem li11 = new ListItem();
            li11.Value = "BOC";
            li11.Text = "中国银行";
            ourbankname.Items.Add(li11);
            ListItem li12 = new ListItem();
            li12.Value = "PAB";
            li12.Text = "平安银行";
            ourbankname.Items.Add(li12);
            ListItem li13 = new ListItem();
            li13.Value = "GDB";
            li13.Text = "广发银行";
            ourbankname.Items.Add(li13);
            ListItem li14 = new ListItem();
            li14.Value = "CNCB";
            li14.Text = "中信银行";
            ourbankname.Items.Add(li14);
            ListItem li15 = new ListItem();
            li15.Value = "NBCB";
            li15.Text = "宁波银行";
            ourbankname.Items.Add(li15);

        }
        public void ZFBData()
        {
            OurZFB.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            OurZFB.Items.Add(li);
            ListItem li1 = new ListItem();
            li1.Value = "ALIPAY-Alipayjszf";
            li1.Text = "支付宝即时收款";
            OurZFB.Items.Add(li1);
            ListItem li2 = new ListItem();
            li2.Value = "zfb-JasZfbWap";
            li2.Text = "JAS-支付宝WAP";
            OurZFB.Items.Add(li2);
            ListItem li3 = new ListItem();
            li3.Value = "alipay-WftZfb";
            li3.Text = "威富通-支付宝扫码";
            OurZFB.Items.Add(li3);
            ListItem li4 = new ListItem();
            li4.Value = "ALIPAY-XingYeZfb";
            li4.Text = "兴业支付宝WAP";
            OurZFB.Items.Add(li4);

        }
        public void OurWXData()
        {
            OurWX.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            OurWX.Items.Add(li);
            ListItem li1 = new ListItem();
            li1.Value = "WXZF-WftWx";
            li1.Text = " 威富通-微信扫码";
            OurWX.Items.Add(li1);
            ListItem li2 = new ListItem();
            li2.Value = "WXZF-WftGzh";
            li2.Text = "威富通-微信公众号";
            ListItem li3 = new ListItem();
            li3.Value = "WXZF-JasWx";
            li3.Text = "Jax-微信扫码";
            OurWX.Items.Add(li3);
            ListItem li4 = new ListItem();
            li4.Value = "WXZF-WanWuGzh";
            li4.Text = "万物-微信公众号";
            OurWX.Items.Add(li4);
            ListItem li5 = new ListItem();
            li5.Value = "WXZF-WanWuWxSm";
            li5.Text = "万物-微信扫码";
            OurWX.Items.Add(li5);

        }
        public string StateType(string type)
        {
            string t = "";
            if (type == "0")
            {
                t = "<span style='color:red'>付款中....</span>";
            }
            if (type == "1")
            {
                t = "<span style='color:blue'>付款成功</span>";
            }
            if (type == "2")
            {
                t = "<span style='color:red'>付款失败</span>";
            }
            return t;
        }
        protected void btn_IsOut_Click(object sender, EventArgs e)
        {
            
        }
        public string BankStr(string str)
        {
            string st = "";
            if (str.Trim() == "CMBC")
            {
                st = "招商银行";
            }
            else if (str.Trim() == "ICBC")
            {
                st = "工商银行";
            }
            else if (str.Trim() == "CCB")
            {
                st = "建设银行";
            }
            else if (str.Trim() == "SPDB")
            {
                st = "浦发银行";
            }
            else if (str.Trim() == "ABC")
            {
                st = "银行银行";
            }
            else if (str.Trim() == "CMSB")
            {
                st = "民生银行";
            }
            else if (str.Trim() == "SDB")
            {
                st = "深圳发展银行";
            }
            else if (str.Trim() == "CIB")
            {
                st = "兴业银行";
            }
            else if (str.Trim() == "BCM")
            {
                st = "交通银行";
            }
            else if (str.Trim() == "CEB")
            {
                st = "光大银行";
            }
            else if (str.Trim() == "BOC")
            {
                st = "中国银行";
            }
            else if (str.Trim() == "PAB")
            {
                st = "平安银行";
            }
            else if (str.Trim() == "GDB")
            {
                st = "广发银行";
            }
            else if (str.Trim() == "CNCB")
            {
                st = "中信银行";
            }
            else if (str.Trim() == "NBCB")
            {
                st = "宁波银行";
            }
            else if (str.Trim() == "ALIPAY-Alipayjszf")
            {
                st = "支付宝即时收款";
            }
            else if (str.Trim() == "zfb-JasZfbWap")
            {
                st = "JAS-支付宝WAP";
            }
            else if (str.Trim() == "alipay-WftZfb")
            {
                st = "威富通-支付宝扫码";
            }
            else if (str.Trim() == "ALIPAY-XingYeZfb")
            {
                st = "兴业支付宝WAP";
            }
            else if (str.Trim() == "WXZF-WftWx")
            {
                st = "威富通-微信扫码";
            }
            else if (str.Trim() == "WXZF-WftGzh")
            {
                st = "威富通-微信公众号";
            }
            else if (str.Trim() == "WXZF-JasWx")
            {
                st = "Jax-微信扫码";
            }
            else if (str.Trim() == "WXZF-WanWuGzh")
            {
                st = "万物-微信公众号";
            }
            else if (str.Trim() == "WXZF-WanWuWxSm")
            {
                st = "万物-微信扫码";
            }
            else
            {
                st = str.Trim();
            }
            return st;
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择图片!');", true);
                return;
            }
            Boolean fileOk = false;
            // 得到文件的后缀
            String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            //允许文件的后缀
            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" };
            //看包含的文件是否是被允许的文件的后缀
          
            for (int i = 0; i < allowedExtensions.Length;i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    fileOk = true;
                }
            }
        
            if (fileOk)
            {
                string upload = UpLoadFile("");
                if (upload.Equals("0"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('系统错误!');", true);
                    return;
                }
                if (upload.Equals("1"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('上传失败!');", true);
                    return;
                }
                ViewState["urlname1"] = upload;
                this.Image1.ImageUrl = "/Upload/" + upload;
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('图片上传成功!');", true);
            }else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('清选择图片格式!');", true);
            }
        }
        private string UpLoadFile(string pName)
        {
            string _fileName = "";
            string _name = "";
            try
            {
                if (FileUpload1.HasFile)
                {
                    _fileName = (Server.MapPath("/Upload/"));
                    if (pName == "")
                        _name = DateTime.Now.ToString("yyyyMMddHHmmss") + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.'));
                    else
                        _name = pName;
                    _fileName += _name;
                    FileUpload1.SaveAs(_fileName);
                    FileUpload1.Dispose();
                    
                   // _fileName =imghandle.MakeThumbPic(_fileName, _fileName, 150, 150, "Cut");
                   
                    new ImageThumbnail(_fileName).ReducedImage(0.9, _fileName);

                    //ServiceReference1.ImgServiceSoapClient uf = new ServiceReference1.ImgServiceSoapClient();
                    //FileInfo imgFile = new FileInfo(@_fileName);
                    //byte[] imgByte = new byte[imgFile.Length];//1.初始化用于存放图片的字节数组  
                    //System.IO.FileStream imgStream = imgFile.OpenRead();//2.初始化读取图片内容的文件流  
                    //imgStream.Read(imgByte, 0, Convert.ToInt32(imgFile.Length));//3.将图片内容通过文件流读取到字节数组  
                    //string str = uf.UploadFileImg(imgByte, _name);//4.发送到服务器   

                    return _name;
                    //if (str.Equals("上传成功"))
                    //{
                    //    return _name;
                    //}
                    //else
                    //{
                        
                    //    return "1";
                    //}
                }
                return _name;
            }
            catch (Exception ex)
            {

                return "0";
            }
        }
        public string paymoth(string value)
        {
            string str = "";
            if (value == "0")
            {
                str = "线下支付";
            }
            if (value == "1")
            {
                str = "银行卡支付";
            }
            if (value == "2")
            {
                str = "支付宝支付";
            }
            if (value == "3")
            {
                str = "微信支付";
            }
            return str;
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            bind_repeater(userBLL.RemitGetList(" r.Remit001=2 and u.UserID="+ LoginUser.UserID), Repeater1, "AddDate desc", tr1, AspNetPager1);
        }

        protected void btn_Open_Click(object sender, EventArgs e)
        {
            try
            {
                lgk.Model.tb_remit me = remitbll.GetModel(" UserID=" + LoginUser.UserID + " and Remit001=2 and State=0");   //Remit001记录汇款操作类型: 1-会员激活 2-复加投资 3-会员升级
                if (me != null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您还有复投申请正在审核..，暂时无法进行新的申请！');", true);
                    return;
                }
                if (PayType.Value == "4")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择付款方式!');", true);
                    return;
                }
                if (PayType.Value == "1")
                {
                    if (ourbankname.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择付款银行!');", true);
                        return;
                    }
                }
                if (PayType.Value == "0")
                {
                    if (ourbankaccount.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('汇出账户不能为空!');", true);
                        return;
                    }
                    if (bank.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('公司开户银行不能为空!');", true);
                        return;
                    }
                    if (bankAccount.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('公司开户账户不能为空!');", true);
                        return;
                    }
                    if (bankUserName.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('公司开户名不能为空!');", true);
                        return;
                    }
                    if (Image1.ImageUrl == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('打款凭证不能为空!');", true);
                        return;
                    }
                    if (LoginUser.IsOut == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('你现在无法复投!');", true);
                        return;
                    }
                    lgk.Model.tb_remit re = remitbll.GetModel(" UserID=" + LoginUser.UserID + " and Remit001=2");
                    if (me != null && me.State == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('你已经申请复投，请等待审核!');", true);
                        return;
                    }
                }
                string bankname = "";
                decimal meoney = getParamAmount("Level" + LoginUser.User004) * 7;
                lgk.Model.tb_remit remit = new lgk.Model.tb_remit();
                remit.UserID = LoginUser.UserID;
                remit.RemitMoney = meoney;
                remit.BankAccountUser = bankUserName.Text;
                remit.BankAccount = bankAccount.Text;
                remit.BankName = bank.Text;
                remit.RechargeableDate = DateTime.Now;
                remit.AddDate = DateTime.Now;
                remit.PassDate = DateTime.Now;
                remit.Remark = barmk.Text;
               
                remit.State = 0;//0-付款中 1-付款成功，等待后台审核 2-审核成功
                remit.Remit001 = 2; //1-开通会员 2-复投
               // remit.Remit002 = Convert.ToInt32(droplevel.Value.Trim());
                remit.Remit006 = Convert.ToDecimal(PayType.Value);//支付方式
                string orderCode = Util.BuildOuterOrderNumber(Convert.ToInt32(LoginUser.UserID));
                remit.Remit004 = orderCode;//订单号
                                           //remit.Remit004 = orderCode;//订单号
                                           //remit.Remit005 = sing;//sing签名
                remit.Remit005 = Image1.ImageUrl;
                if (PayType.Value != "0")
                {
                    if (PayType.Value == "1")
                    {
                        remit.Remit003 = ourbankname.SelectedValue;//打款银行
                        bankname = ourbankname.SelectedItem.Text;
                    }
                    if (PayType.Value == "2")
                    {
                        remit.Remit003 = OurZFB.SelectedValue;//支付宝通道
                        bankname = OurZFB.SelectedItem.Text;
                    }
                    if (PayType.Value == "3")
                    {
                        remit.Remit003 = OurWX.SelectedValue;//微信通道
                        bankname = OurWX.SelectedItem.Text;
                    }
                }
                else if (PayType.Value == "0")
                {
                    remit.Remit003 = OutBank.SelectedValue;//汇出银行
                }
                remit.Remit007 = 1;//是否提交成功 0-是 1-否
                long uid = remitbll.Add(remit);
                if (uid > 0)
                {
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('申请成功!');", true);
                   
                    
                    if (PayType.Value == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('申请成功!');", true);
                    }
                    else
                    {
                        Response.Redirect("/ReciPay.aspx?money=" + meoney + "&bankcode=" + remit.Remit003 + "&remitID=" + uid + "&orderCode=" + orderCode + "&type=会员复投&UserCode=" + LoginUser.UserCode + "&payMoth=" + paymoth(PayType.Value) + "&bankname=" + bankname + "&page=r=Recast");
                        // btn_Open.Visible = false;
                        //this.Ifrc.Attributes.Add("src ", "/ReciPay.aspx?money=" + meoney + "&bankcode=" + ourbankname.SelectedValue + "&remitID=" + uid + "&orderCode=" + orderCode + "");
                        //Response.Write("<script>window.open('/Pay.aspx?money=" + meoney + "&bankcode=" + ourbankname.SelectedValue + "&remitID=" + uid + "&orderCode=" + orderCode + "','_blank')</script>");
                    }
                    BindData();
                    // Response.Write("<script>window.open('/Pay.aspx?money=" + meoney + "&bankcode=" + ourbankname.SelectedValue + "&remitID=" + uid + "&orderCode=" + orderCode + "')</script>");  
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('申请失败!');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + ex.Message + "!');", true);
            }
        }

        
    }
}