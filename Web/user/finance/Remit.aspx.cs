/*********************************************************************************
* Copyright(c)  	2012 ZXHLRJ.COM
 * 创建日期：		2012-5-23 11:15:27 
 * 文 件 名：		Remit.cs 
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
using System.Data;
using System.Collections;
using System.Runtime.Serialization;
using Library.Alipay;
using System.Web.Script.Serialization;

namespace Web.user.finance
{
    public partial class Remit : PageCore
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           // spd.jumpUrl(this.Page, 1);//跳转二级密码
            //spd.jumpUrl1(this.Page, 1);//跳转3级密码
            if (!IsPostBack)
            {
                BindSysBank();
                BindUserBank();
                BindData();
                btnSubmit.Text = GetLanguage("Submit");//提交
               // btnReset.Text = GetLanguage("Reset");//重置
                btnSearch.Text = GetLanguage("Search");//搜索
                txtRemitCode.Text = new Library.Common().GetRandom(6); //充值随机码
            }
        }

        private void BindSysBank()
        {

            IList<lgk.Model.tb_systemBank> ddlList = new lgk.BLL.tb_systemBank().GetModelList(" flag = 0 ");
            dropBank.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = GetLanguage("PleaseSselect");//"-请选择-";
            dropBank.Items.Add(li);
            foreach (lgk.Model.tb_systemBank item in ddlList)
            {
                ListItem items = new ListItem();
                string bankname = item.BankName;
                items.Value = item.ID.ToString();
                items.Text = bankname;
                items.Attributes["BankType"] = item.BankType.ToString();
                items.Attributes["BankAccount"] = item.BankAccount.ToString();
                dropBank.Items.Add(items);
            }
        }
        private void BindUserBank()
        {

            IList<lgk.Model.tb_UserBank> ddlList = new lgk.BLL.tb_UserBank().GetModelList("Bank003=1 and Bank004 >= 0 and userid=" + LoginUser.UserID);
            dropOutAccount.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = GetLanguage("PleaseSselect");//"-请选择-";
            dropOutAccount.Items.Add(li);
            foreach (lgk.Model.tb_UserBank item in ddlList)
            {
                ListItem items = new ListItem();
                string bankname = item.BankName;
                items.Value = item.ID.ToString();
                items.Text = bankname;
                items.Attributes["BankType"] = item.Bank003.ToString();
                items.Attributes["BankAccount"] = item.BankAccount.ToString();
                items.Attributes["QRCode"] = item.Bank001.ToString();
                dropOutAccount.Items.Add(items);
            }
        }
        /// <summary>
        /// 获取银行集合
        /// </summary>
        /// <returns></returns>
        private List<List<string>> GetBanknameList()
        {
            string strbandname = new lgk.BLL.tb_bankName().GetModel(1).BankName;
            string[] s = strbandname.Split('|');
            List<List<string>> banklist = new List<List<string>>();
            if (s.Length < 2)
            {
                return banklist;
            }
            string[] cnlist = s[0].Split('，');
            string[] enlist = s[1].Split('，');

            int count = 0;
            if (cnlist.Length > enlist.Length)
            {
                count = enlist.Length;
            }
            else
            {
                count = cnlist.Length;
            }
            for (int i = 0; i < count; i++)
            {
                List<string> list = new List<string>();
                list.Add(cnlist[i]);
                list.Add(enlist[i]);
                banklist.Add(list);
            }

            return banklist;
        }

        protected void dropBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strName = dropBank.SelectedValue;
            if (strName == "0")
            {
                lblBankAccount.Text = "";
                lblBankAccountUser.Text = "";
            }
            else
            {
                lgk.Model.tb_systemBank model = bankBLL.GetModel(strName.ToInt());
                lblBankAccount.Text = model.BankAccount;
                lblBankAccountUser.Text = model.BankAccountUser;
            }
        }
        protected void dropOutAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strName = dropOutAccount.SelectedValue;
            if (strName == "0")
            {
                lblOutAccount.Text = "";
                imgOutQRCode.ImageUrl = "";
            }
            else
            {
                lgk.Model.tb_UserBank model = userBankBLL.GetModel(strName.ToInt());
                lblOutAccount.Text = model.BankAccount;
                imgOutQRCode.ImageUrl = model.Bank001;
                lblOutName.Text = model.BankAccountUser;
                if(model.Bank003 == 1)
                {
                    divOutAccount.Visible = true;
                    divOutQrCode.Visible = false;
                    divOutName.Visible = true;
                    lblOutNameTitle.Text = "开户名称";
                }
                else if (model.Bank003 == 2)
                {
                    divOutAccount.Visible = true;
                    divOutQrCode.Visible = true;
                    divOutName.Visible = false;
                    lblOutNameTitle.Text = "昵称";
                }
                else if (model.Bank003 == 3)
                {
                    divOutAccount.Visible = true;
                    divOutQrCode.Visible = true;
                    divOutName.Visible = false;
                    lblOutNameTitle.Text = "昵称";
                }
            }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = "";
            string strStartTime = this.txtStart.Text.Trim();
            string strEndTime = this.txtEnd.Text.Trim();

            strWhere = " r.UserID=" + getLoginID();
            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),AddDate,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),AddDate,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),AddDate,120)  between '" + strStartTime + "' and '" + strEndTime + "'");
            }

            return strWhere;
        }

        /// <summary>
        /// 填充
        /// </summary>
        protected void BindData()
        {
            bind_repeater(GetRemitAndBankList(GetWhere()), rpTake, "State asc, AddDate desc", divno, AspNetPager1);
           // bind_repeater(GetRemitList(GetWhere()), rpTake, "State asc, AddDate desc", divno, AspNetPager1);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region 汇入银行验证
            if (dropBank.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseSBank") + "');", true);//请选择汇款银行
                return;
            }
            #endregion

            #region 汇款金额验证
            string strMoney = txtMoney.Value.Trim();
            if (string.IsNullOrEmpty(strMoney))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("RemittanceIsnull") + "');", true);//汇款金额不能为空
                return;
            }
            long money = 0;
            try
            {
                money = Convert.ToInt32(strMoney);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("integer") + "');", true);//汇款金额格式为整数
                return;
            }
            decimal remitMin = getParamAmount("RemitMin");
            if (money < remitMin)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("greater") + "');", true);//汇款金额必须大于100
                return;
            }

            #endregion

            #region 汇款时间验证
            if (txtTime.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("timeEmpty") + "');", true);//汇款具体时间不能为空
                return;
            }
            if (Convert.ToDateTime(txtTime.Text.Trim()) > DateTime.Now)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("pleaseRe-enter") + "');", true);//汇款时间填写有误，请重新填写
                return;
            }
            #endregion

            #region 汇出银行验证
            if (dropOutAccount.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PleaseSBank") + "');", true);//请选择汇款银行
                return;
            }
            //string strOutBank = txtOutBank.Value;
            //if (string.IsNullOrEmpty(strOutBank))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("banksEmpty") + "');", true);//汇出银行不能为空
            //    return;
            //}
            //string strOutAccount = txtOutAccount.Text;
            //if (string.IsNullOrEmpty(strOutAccount))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("accountEmpty") + "');", true);//汇出账户不能为空
            //    return;
            //}
            //if (strOutAccount.Length < 10)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("greaterThan") + "');", true);//汇出帐户格式错误，账号长度要大于10
            //    return;
            //}
            #endregion

            DateTime dt = DateTime.Now;
            string strDate = this.txtTime.Text.Trim();

            if (!DateTime.TryParse(strDate, out dt))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("timeError") + "');", true);//时间格式错误
                return;
            }
            lgk.Model.tb_remit remitInfo = new lgk.Model.tb_remit();
            lgk.Model.tb_user userInfo = userBLL.GetModel(LoginUser.UserID);
            remitInfo.UserID = getLoginID();
            remitInfo.RechargeableDate = Convert.ToDateTime(strDate);//汇款具体时间
            remitInfo.State = 0;
            remitInfo.AddDate = DateTime.Now;
            decimal m = Convert.ToDecimal(this.txtMoney.Value);
            remitInfo.RemitMoney = Convert.ToDecimal(m.ToString("0.00"));
            remitInfo.YuAmount = LoginUser.Emoney + Convert.ToDecimal(this.txtMoney.Value);
            if (this.txtRemark.Text == "")
            {
                remitInfo.Remark = "无";
            }
            else
            {
                remitInfo.Remark = this.txtRemark.Text;
            }

            //remitInfo.BankName = dropBank.SelectedIndex == 0 ? string.Empty : dropBank.SelectedValue;
            //remitInfo.BankAccount = this.lblBankAccount.Text;
            //remitInfo.BankAccountUser = this.lblBankAccountUser.Text;

            remitInfo.Remit003 = txtRemitCode.Text;//充值随机码
            //凭证图片
            remitInfo.Remit004 = 
                Request.Form["hiddenupimage"] == null 
                || Request.Form["hiddenupimage"].ToString() == "" ? "" : Request.Form["hiddenupimage"].ToString();

            int _playid = dropBank.SelectedValue.ToInt();
            int _revenueid = dropOutAccount.SelectedValue.ToInt();
            remitInfo.Remit001 = _revenueid;//打款id
            remitInfo.Remit002 =  _playid;//收款id
            remitInfo.PassDate = DateTime.Now;
            
            long iRemitID = remitBLL.Add(remitInfo);

            if (iRemitID > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("application") + "');window.location.href='Remit.aspx';", true);//申请汇款成功
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Remit.aspx");
        }
    }
}
