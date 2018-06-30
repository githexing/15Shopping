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
using System.Data.SqlClient;

namespace Web.user.finance
{
    public partial class RWGH : PageCore
    {
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        protected void Page_Load(object sender, EventArgs e)
        {

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
            //dropType.Items.Add(new ListItem("奖金币", "1"));
            //dropType.Items.Add(new ListItem("YT", "2"));
        }
        public string TakeType(int type)
        {
            string str = "";
            if (type == 1)
            {
                str = "奖金币";
            }
            return str;
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strWhere = " ";
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
            string sql = "select * from  tb_takeMoney1 where  UserID = " + LoginUser.UserID + " ";
            var dt = userBLL.getData_Chaxun(sql+ GetWhere(), "");
            bind_repeater(dt, Repeater1, "TakeTime desc", tr1, AspNetPager1);
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
           
            string filename = "";

            #region 提现金额验证 
            string strMoney = txtTake.Text.Trim();
            if (string.IsNullOrEmpty(strMoney))
            {
                MessageBox.ShowBox(this.Page, "金额不能为空", Library.Enums.ModalTypes.warning);//提现金额不能为空
                return;
            }

            decimal resultNum = 0;
            if (!decimal.TryParse(strMoney, out resultNum))
            {
                MessageBox.ShowBox(this.Page, GetLanguage("AmountErrors"), Library.Enums.ModalTypes.warning);//金额格式输入错误
                return;
            }
 
            lgk.Model.tb_user userModel = userBLL.GetModel(getLoginID());

        
            string sql = "select * from  tb_takeMoney1 where  UserID = " + LoginUser.UserID + " and Flag = 0";
            var dt = userBLL.getData_Chaxun(sql,"").Tables[0];
        
            if (dt.Rows.Count>=1)
            {
                MessageBox.MyShow(this, "您有待审核的申请记录，请等待后台审核后再申请！");//提现金额必须大于最低提现金额!
                return;
            }

            if (txtPubContext.Text.Trim()=="")
            {
                MessageBox.MyShow(this, "备注不能为空！");//提现金额必须大于最低提现金额!
                return;
            }
            if (txtPubContext.Text.Length >=100)
            {
                MessageBox.MyShow(this, "备注长度不能超过100");//提现金额必须大于最低提现金额!
                return;
            }
            #endregion

            #region 申请 


            string sql1 = "insert into tb_takeMoney1(TakeTime,TakePoundage,TakeMoney,RealityMoney,Flag,UserID,BonusBalance,BankName,Take003,BankAccount,BankAccountUser,Take001,Take002,Take004) ";
                sql1 += "values(getdate(),0,"+ resultNum + "," + resultNum + ",0,"+ getLoginID() + ",0,'"+ userModel.BankName + "','" + userModel.BankBranch + "','" + userModel.BankAccount + "','" + userModel.BankAccountUser + "','1','" + dropOutAccount.SelectedValue.ToInt() + "','"+ txtPubContext.Text+ "')";
            SqlConnection conn = new SqlConnection(sconn);
            conn.Open(); 
            SqlCommand cmd = new SqlCommand(sql1, conn);
            int reInt = cmd.ExecuteNonQuery();
            conn.Close(); 
            #endregion 
            if (true)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('提交申请成功！');window.location.href='TakeMoney.aspx';", true);//申请提现成功
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
       
            if (e.CommandName == "change")
            {
                long iID = Convert.ToInt64(e.CommandArgument);
                string sql1 = "delete from tb_takeMoney1 where ID= '"+ iID + "'";
                SqlConnection conn = new SqlConnection(sconn);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql1, conn);
                int reInt = cmd.ExecuteNonQuery();
                conn.Close();

                if (reInt>0)
                { 
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('取消成功！');window.location.href='TakeMoney.aspx';", true);//取消成功  
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('取消失败！');", true);//取消失败
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
               
                if (model.Bank003 == 1)
                {
                    divOutAccount.Visible = true;
                    divOutQrCode.Visible = false;
                  
                  
                }
                else if (model.Bank003 == 2)
                {
                    divOutAccount.Visible = true;
                    divOutQrCode.Visible = true;
                 
                   
                }
                else if (model.Bank003 == 3)
                {
                    divOutAccount.Visible = true;
                    divOutQrCode.Visible = true;
                   
                   
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