/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-7-15 11:46:41 
 * 文 件 名：		Member.cs 
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
using System.IO;
using System.Text;
using System.Collections.Specialized;

namespace Web.user.finance
{
    public partial class TransRemit : PageCore//System.Web.UI.Page
    {
        lgk.BLL.tb_systemBank sysbank = new lgk.BLL.tb_systemBank();
        lgk.BLL.tb_remit remitbll = new lgk.BLL.tb_remit();
        
       
        protected void Page_Load(object sender, EventArgs e)
        {
 
            if (!IsPostBack)
            {
                //BindLevel();
                //txtInput.Value = LoginUser.RegMoney.ToString();
                BindBank();
                Bank();
                //BankBind();
             
                BindData();
                //UserCode.Text = LoginUser.UserCode;
                //UserName.Text = LoginUser.TrueName;
                //BonusAccount.Text = LoginUser.BonusAccount.ToString();
            }
            btnSearch.Text = GetLanguage("Search");//确定
            btn_Open.Text = GetLanguage("Submit");//提交
            btnUpload.Text = GetLanguage("upload");//上传
            txtName.Text = GetLanguage("OutBank");//汇出银行
            zh.Text = GetLanguage("RemittanceAccount");//汇出账户
            khyh.Text = GetLanguage("CompanyDepositary");//公司开户银行
            gszh.Text = GetLanguage("CompanyDepositary");//公司开户账号
            khm.Text = GetLanguage("AccountName");//开户名
            pz.Text = GetLanguage("UploadVoucher");//上传打款凭证
            bz.Text = GetLanguage("RemittanceNotes");//汇款备注
            lblMoney.Text = GetLanguage("RechargeAmount");//充值金额
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

        //#region 绑定用户級別
        ///// <summary>
        ///// 绑定用户級別
        ///// </summary>
        //private void BindLevel()
        //{
        //    IList<lgk.Model.tb_level> list = new lgk.BLL.tb_level().GetModelList("");
        //    //droplevel.Items.Clear();
        //    ListItem li = new ListItem();
        //    li.Value = "0";
        //    li.Text = "-请选择-";
        //    //droplevel.Items.Add(li);
        //    foreach (lgk.Model.tb_level item in list)
        //    {
        //        ListItem items = new ListItem();
        //        items.Value = item.LevelID.ToString();
        //        items.Text = item.LevelName;
        //        droplevel.Items.Add(items);

        //    }
        //}
        //#endregion
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
     
        //public void BankBind()
        //{
        //    string strBankName = new lgk.BLL.tb_bankName().GetModel(1).BankName;

        //    string[] a = strBankName.Split(',');
        //    ListItem item_list = new ListItem();
        //    item_list.Value = "0";
        //    item_list.Text = GetLanguage("PleaseSselect");//"-请选择-"
        //    this.OutBank.Items.Add(item_list);
        //    foreach (string b in a)
        //    {
        //        ListItem item_list1 = new ListItem();
        //        item_list1.Value = b;
        //        item_list1.Text = b;
        //        this.OutBank.Items.Add(item_list1);
        //    }
        //}
        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "";
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            strWhere = " r.Remit001=1 and r.UserID=" + getLoginID();

            //if (this.dropLevel.SelectedValue != "0" && this.dropLevel.SelectedValue != "")
            //{
            //    strWhere += " and LevelID=" + dropLevel.SelectedValue;
            //}
            if (strStartTime != "" && strEndTime == "" && PageValidate.IsDateTime(strStartTime))
            {
                strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "" && PageValidate.IsDateTime(strEndTime))
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),r.AddDate,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "" && PageValidate.IsDateTime(strStartTime) && PageValidate.IsDateTime(strEndTime))
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),r.AddDate,120)  between '" + strStartTime + "' and '" + strEndTime + "'");
            }
            return strWhere;
        }

        /// <summary>
        /// 填充申请记录
        /// </summary>
        private void BindData()
        {
            bind_repeater(userBLL.RemitGetList(GetWhere()), Repeater1, "AddDate desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 搜索申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 分页申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
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
            //if (IsPostBack)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('一步!');", true);
            //    return;
            //}
            if (!FileUpload1.HasFile)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("Picture"), Library.Enums.ModalTypes.warning);//请选择图片
                return;
            }
            Boolean fileOk = false;
            // 得到文件的后缀
            String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            //允许文件的后缀
            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" };
            //看包含的文件是否是被允许的文件的后缀

            for (int i = 0; i < allowedExtensions.Length; i++)
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
                    MessageBox.ShowBox(this.Page, GetLanguage("Error"), Library.Enums.ModalTypes.error);//系统错误
                    return;
                }
                if (upload.Equals("1"))
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("UploadFail"), Library.Enums.ModalTypes.error);//上传失败
                    return;
                }

                ViewState["urlname1"] = upload;
                this.Image1.ImageUrl = "/Upload/" + upload;
                MessageBox.ShowBox(this.Page, GetLanguage("Successfully"), Library.Enums.ModalTypes.success);//图片上传成功
             
            }
            else
            {
                MessageBox.ShowBox(this.Page, GetLanguage("Please"), Library.Enums.ModalTypes.warning);//请选择图片格式
             
            }
        }
        public string StateType(string type)
        {
            string t = "";
            if (type == "0")
            {
                t = "<span style='color:red'>未审核....</span>";
            }
            if (type == "1")
            {
                t = "<span style='color:blue'>已审核</span>";
            }
            return t;
        }
        /// <summary>
        /// 上传商品图片
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        private string UpLoadFile(string pName)
        {
            string _fileName = "";//,newfilename="" , _name2 = "";
            string _name = "";
            try
            {
                if (FileUpload1.HasFile)
                {
                    _fileName = (Server.MapPath("/Upload/"));
                    if (pName == "")
                    {
                        string code = Util.BuildOuterOrderNumber((int)LoginUser.UserID);
                        _name = code + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.'));
                    }
                    else
                        _name = pName;
                    _fileName += _name;

                    FileUpload1.SaveAs(_fileName);
                    new ImageThumbnail(_fileName).ReducedImage(0.9, _fileName);
                    return _name;
                    // File.Delete(_fileName);
                    //byte[] bfile = FileUpload1.FileBytes;
                    //using (MemoryStream mems = new MemoryStream(bfile))
                    //{
                    //    using (FileStream fstream = new FileStream(_fileName,FileMode.Create))
                    //    {
                    //        try
                    //        {
                    //            fstream.Write(bfile, 0, bfile.Length);
                    //        }
                    //        finally
                    //        {
                    //            fstream.Close();
                    //        }
                    //    }
                    //}

                    //ServiceReference1.ImgServiceSoapClient uf = new ServiceReference1.ImgServiceSoapClient();
                    //FileInfo imgFile = new FileInfo(@_fileName);
                    //byte[] imgByte = new byte[imgFile.Length];//1.初始化用于存放图片的字节数组  
                    //System.IO.FileStream imgStream = imgFile.OpenRead();//2.初始化读取图片内容的文件流  
                    //imgStream.Read(imgByte, 0, Convert.ToInt32(imgFile.Length));//3.将图片内容通过文件流读取到字节数组  
                    //string str = uf.UploadFileImg(imgByte, _name);//4.发送到服务器   
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
            catch (Exception  )
            {
                return "0";
            }
        }

        protected void btn_Open_Click(object sender, EventArgs e)
        {
            try
            {

                if (ourbankname.SelectedValue == "")
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("banksEmpty"), Library.Enums.ModalTypes.warning);//汇出银行不能为空
                    return;
                }
                if (ourbankaccount.Text == "")
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("accountEmpty"), Library.Enums.ModalTypes.warning);//汇出账户不能为空
                    return;
                }
                if (bank.Text == "")
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("Bank"), Library.Enums.ModalTypes.warning);//公司开户银行不能为空
                    return;
                }
                if (bankAccount.Text == "")
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("OpeningEmpty"), Library.Enums.ModalTypes.warning);//公司开户账户不能为空
                    return;
                }
                if (bankUserName.Text == "")
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("OpenAccount"), Library.Enums.ModalTypes.warning);//公司开户名不能为空
                    return;
                }
                if (Image1.ImageUrl == "")
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("Moneyempty"), Library.Enums.ModalTypes.warning);//打款凭证不能为空
                    return;
                }

                string money = txtMoney.Text.Trim();
                decimal dmoney = 0;
                if (string.IsNullOrEmpty(money))
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("EnterAmount"), Library.Enums.ModalTypes.warning);//请输入充值金额
                    return;
                }

                decimal.TryParse(money, out dmoney);
                if (dmoney<=0)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("EnterAmount"), Library.Enums.ModalTypes.warning);//请输入充值金额
                    return;
                }
                if (bz.Text == "")
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("RemittanceEmpty"), Library.Enums.ModalTypes.warning);//汇款备注不能为空
                    return;
                }
                string bankname = "";
                lgk.Model.tb_remit remit = new lgk.Model.tb_remit();
                remit.UserID = LoginUser.UserID;
                remit.RemitMoney = dmoney;
                remit.BankAccountUser = bankUserName.Text;
                remit.BankAccount = bankAccount.Text;
                remit.BankName = bank.Text;
                remit.RechargeableDate = DateTime.Now;
                remit.AddDate = DateTime.Now;
                //remit.PassDate = DateTime.Now;
                remit.Remark = barmk.Text;
                remit.State = 0;//0-付款中 1-付款成功 2-付款失败
                remit.Remit001 = 1; //1-开通会员 2-复投
                remit.Remit002 = 0;
                remit.Remit006 = 0;//支付方式
                string orderCode = Util.GetUniqueIndentifier(20);
                remit.Remit004 = orderCode;//订单号
                remit.Remit005 = Image1.ImageUrl;
                remit.Remit007 = 1;//是否提交成功 0-是 1-否
              
                remit.Remit003 = ourbankname.SelectedValue;//打款银行
                bankname = ourbankname.SelectedItem.Text;


                long uid = remitbll.Add(remit);
                if (uid > 0)
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("ApplySuccess"), Library.Enums.ModalTypes.success, "TransRemit.aspx");//申请充值成功
                   
                   // BindData();
                }
                else
                {
                    MessageBox.ShowBox(this.Page, GetLanguage("ApplyError"), Library.Enums.ModalTypes.error);//申请充值失败
                    
                }

            }
            catch (Exception ex)
            {
              
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + ex.Message + "!');", true);
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
    

    }
}
