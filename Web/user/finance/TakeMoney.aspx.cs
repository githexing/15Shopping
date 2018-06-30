using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library;
using System.Collections.Generic;

namespace Web.user.finance
{
    public partial class TakeMoney : PageCore// System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //spd.jumpUrl1(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                //ream.Text = "提现说明:月分红静态钱包需在每月的"+ getParamVarchar("ATM4") + "号提现，月分红动态钱包需在每月的"+ getParamVarchar("ATM5") + "号提现，年分红均需要在年底提现";
                //ream.Text = "提现说明:月分红静态钱包需在每月的25，26号提现，月分红动态钱包需在每月的5,6|15.16|25.26号提现，年分红均需要在满一年提现";
                ShowData();
                BindData();
                BindUserBank();
                btnSearch.Text = GetLanguage("Search");//搜索
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        /// <summary>
        /// 提现金额
        /// </summary>
        private void ShowData()
        {
          //  dropType.Items.Add(new ListItem(GetLanguage("PleaseSselect"), "0"));
            dropType.Items.Add(new ListItem("奖金积分", "1"));
            //dropType.Items.Add(new ListItem("YT", "2"));
        }
        public string TakeType(int type)
        {
            string str = "";
            if (type == 1)
            {
                str = "奖金积分";
            } 
            return str;
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = " u.UserID=" + getLoginID() + "";
            string strStart = txtStart.Text.Trim();
            string strEnd = txtEnd.Text.Trim();

            if (strStart != "" && strEnd == "" && PageValidate.IsDateTime(strStart))
            {
                strWhere += string.Format(" and Convert(nvarchar(10),RegTime,120) >= '" + strStart + "'");
            }
            else if (strStart == "" && strEnd != "" && PageValidate.IsDateTime(strEnd))
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  <= '" + strEnd + "'");
            }
            else if (strStart != "" && strEnd != "" && PageValidate.IsDateTime(strStart) && PageValidate.IsDateTime(strEnd))
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  between '" + strStart + "' and '" + strEnd + "'");
            }
            return strWhere;
        }

        /// <summary>
        /// 填充
        /// </summary>
        protected void BindData()
        {
            bind_repeater(GetTakeList(GetWhere()), Repeater1, "TakeTime desc", tr1, AspNetPager1);
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
            //string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            //week = Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"));
            //var open2 = getParamAmount("extract4");
            //if (week != open2)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请在提现日进行此功能操作，谢谢!');", true);
            //    return;
            //}
            string filename = "";

            #region 提现金额验证

            int iTypeID = Convert.ToInt32(dropType.SelectedValue);
            if (iTypeID == 0)
            {
                MessageBox.ShowBox(this.Page, "请选择提现类型", Library.Enums.ModalTypes.warning);
                return;
            }

            string strMoney = txtTake.Text.Trim();
            if (string.IsNullOrEmpty(strMoney))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("WithdrawalIsnull"), Library.Enums.ModalTypes.warning);//提现金额不能为空
                return;
            }

            decimal resultNum = 0;
            if (!decimal.TryParse(strMoney, out resultNum))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("AmountErrors"), Library.Enums.ModalTypes.warning);//金额格式输入错误
                return;
            }

            decimal MinMoney = getParamAmount("ATM1");//最小金额
            decimal Multiple = getParamAmount("ATM2");//倍数基数
            if (resultNum < MinMoney)
            {
                MessageBox.ShowBox(this.Page, "提现金额必须大于最低提现金额", Library.Enums.ModalTypes.warning);//金额格式输入错误
                return;
            }
            if (Multiple != 0 && resultNum % Multiple != 0)
            {
                MessageBox.ShowBox(this.Page, "提现金额必须是" + Multiple + "的整数倍", Library.Enums.ModalTypes.warning);//金额格式输入错误
                return;
            }

            lgk.Model.tb_user userModel = userBLL.GetModel(getLoginID());
            decimal Fee = resultNum * getParamAmount("ATM3") / 100;//手续费
            if (iTypeID == 1)
            {
                if(userModel.Emoney+ Fee < resultNum)
                {
                    MessageBox.ShowBox(this.Page, "奖金积分余额不足", Library.Enums.ModalTypes.warning);
                    return;
                }
                filename = "Emoney";
            } 
            lgk.Model.tb_takeMoney takemodel = takeBLL.GetModel(" UserID=" + LoginUser.UserID + " and Flag=0");
            if (takemodel != null)
            {
                MessageBox.MyShow(this, "您有待审核的申请记录，请等待后台审核后再申请！");//提现金额必须大于最低提现金额!
                return;
            }
            #endregion

            #region 提现申请
         

            lgk.Model.tb_takeMoney takeMoneyInfo = new lgk.Model.tb_takeMoney();
            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            takeMoneyInfo.TakeTime = DateTime.Now;
            takeMoneyInfo.TakePoundage = Fee;
            takeMoneyInfo.TakeMoney = resultNum + Fee;
            takeMoneyInfo.RealityMoney = resultNum ;
            takeMoneyInfo.Flag = 0;
            takeMoneyInfo.UserID = getLoginID();
            if (iTypeID == 1)//YD
            {
                takeMoneyInfo.BonusBalance = userModel.Emoney - takeMoneyInfo.TakeMoney;
            }
            else//YT
            {
                takeMoneyInfo.BonusBalance = userModel.BonusAccount - takeMoneyInfo.TakeMoney;
            }

            takeMoneyInfo.BankName = userModel.BankName;
            takeMoneyInfo.Take003 = userModel.BankBranch;
            takeMoneyInfo.BankAccount = userModel.BankAccount;
            takeMoneyInfo.BankAccountUser = userModel.BankAccountUser;
            takeMoneyInfo.Take001 = iTypeID;//提现币种：1、YD，2、YT
            takeMoneyInfo.Take002 = dropOutAccount.SelectedValue.ToInt();
            #endregion

            #region 加入流水账表


            journalInfo.UserID = takeMoneyInfo.UserID;
            journalInfo.Remark = "会员提现";
            journalInfo.RemarkEn = "Cash withdrawal";
            journalInfo.InAmount = 0;
            journalInfo.OutAmount = takeMoneyInfo.TakeMoney;
            journalInfo.BalanceAmount = takeMoneyInfo.BonusBalance;
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = iTypeID;
            journalInfo.Journal01 = takeMoneyInfo.UserID;
            #endregion

            if (takeBLL.Add(takeMoneyInfo) > 0 && journalBLL.Add(journalInfo) > 0 && UpdateAccount(filename, getLoginID(), takeMoneyInfo.TakeMoney, 0) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("successful") + "');window.location.href='TakeMoney.aspx';", true);//申请提现成功
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OperationFailed") + "');", true);//操作失败
            }
        }
        public string dateStr(int Month, string day)
        {
            string str = "";
            if (DateTime.Now.Month < 10)
            {
                str = DateTime.Now.Year + "-" + "0" + Month + "-" + day;
            }
            else
            {
                str = DateTime.Now.Year + "-" + Month + "-" + day;
            }
            return str;
        }
        protected void txtTake_TextChanged(object sender, EventArgs e)
        {
            decimal value = 0;
            string strMoney = txtTake.Text.Trim();
            if (!string.IsNullOrEmpty(strMoney))
            {
                decimal money = Convert.ToDecimal(strMoney);

                value = money * getParamAmount("ATM3") / 100;//提现手续费
                txtExtMoney.Value = value.ToString();
            }
            else
            {
                txtExtMoney.Value = "";
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string filename = "";
            if (e.CommandName == "change")
            {
                long iID = Convert.ToInt64(e.CommandArgument);
                lgk.Model.tb_takeMoney take = takeBLL.GetModel(iID);
                if (take == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordDeleted") + "');", true);//该记录已删除，无法再进行此操作
                    return;
                }
                if (take.Flag != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("recordApproved") + "');", true);//该记录已审核，无法再进行此操作
                    return;
                }
                lgk.Model.tb_user userModel = userBLL.GetModel(Convert.ToInt32(take.UserID));
                //加入流水账表
                lgk.Model.tb_journal model = new lgk.Model.tb_journal();

                if (take.Take001 == 1)
                {
                    model.BalanceAmount = userModel.Emoney + take.TakeMoney;
                    filename = "Emoney";
                }
                else
                {
                    model.BalanceAmount = userModel.BonusAccount + take.TakeMoney;
                    filename = "BonusAccount";
                }
                
                model.UserID = take.UserID;
                model.Remark = "取消提现";
                model.RemarkEn = "Cancellation of cash";
                model.InAmount = take.TakeMoney;
                model.OutAmount = 0;
                model.JournalDate = DateTime.Now;
                model.JournalType = take.Take001;
                model.Journal01 = take.UserID;

                if (journalBLL.Add(model) > 0 && UpdateAccount(filename, take.UserID, take.TakeMoney, 1) > 0 && takeBLL.Delete(iID))
                {
                    if(take.Take001 == 2)
                    {
                        //如果冻结释放币账户大于0，激活矿机时转入明细
                        if (userModel.User016 > 0)
                        {
                            UpdateAccount("User016", userModel.UserID, userModel.User016, 0);//
                            UpdateAccount("BonusAccount", userModel.UserID, userModel.User016, 1);//

                            lgk.Model.tb_journal jourInfo = new lgk.Model.tb_journal();
                            jourInfo.UserID = userModel.UserID;
                            jourInfo.Remark = "释放币账户进账，冻结释放币转入释放币账户";
                            jourInfo.RemarkEn = "Cash withdrawal";
                            jourInfo.InAmount = userModel.User016;
                            jourInfo.OutAmount = 0;
                            jourInfo.BalanceAmount = userBLL.GetMoney(userModel.UserID, "BonusAccount");
                            jourInfo.JournalDate = DateTime.Now;
                            jourInfo.JournalType = 2;
                            jourInfo.Journal01 = userModel.UserID;
                            journalBLL.Add(jourInfo);
                        }
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("CancellationSuccess") + "');window.location.href='TakeMoney.aspx';", true);//取消成功  
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("FailedToCancel") + "');", true);//取消失败
                }

            }
        }



        protected void dropShore_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTake.Text = "";
            txtExtMoney.Value = "";//本金提现手续费
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
                if (model.Bank003 == 1)
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

        private void BindUserBank()
        {

            IList<lgk.Model.tb_UserBank> ddlList = new lgk.BLL.tb_UserBank().GetModelList("  Bank003=1 and Bank004 >= 0 and userid=" + LoginUser.UserID);
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
    }
}