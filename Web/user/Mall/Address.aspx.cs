using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user.product
{
    public partial class Address : PageCore
    {
        long iID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ID"] != null && Request["ID"].Length > 0)
            {
                if (PageValidate.IsLong(Request["ID"]))
                {
                    iID = Convert.ToInt64(Request["ID"].ToString());
                }
            }
            else
            {
                iID = 0;
            }

            if (!IsPostBack)
            {
                if (iID > 0)
                {
                    ShowInfo();
                }
                BindData();
                btnSubmit.Text = GetLanguage("Submit");//提交
            }
        }

        private void ShowInfo()
        {
            lgk.Model.tb_Address addressInfo = addressBLL.GetModel(iID);
            if (addressInfo == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("ParameterError") + "');", true);//参数出错
                return;
            }
            else
            {
                if (addressInfo.UserID != getLoginID())
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("IOperation") + "');", true);//非法操作
                    return;
                }
                else
                {
                    txtAddress.Text = addressInfo.Address;
                    txtMemberName.Text = addressInfo.MemberName;
                    txtPhoneNum.Text = addressInfo.PhoneNum;
                    //txtPhone.Text = addressInfo.Phone;
                    chkDefault.Checked = (addressInfo.Address01 == "1");
                }
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            string strWhere = "UserID = " + LoginUser.UserID + "";
            bind_repeater(addressBLL.GetList(strWhere), Repeater1, "ID desc", tr1, AspNetPager1);
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long iID = Convert.ToInt64(e.CommandArgument);
            lgk.Model.tb_Address addressInfo = addressBLL.GetModel(iID);

            if (e.CommandName == "Default")
            {
                if (addressInfo == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("RecordNotExist") + "');", true);//该记录不存在
                    return;
                }

                if (addressBLL.SetDefault(addressInfo.UserID, iID))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("Successful") + "');window.location.href='Address.aspx';", true);//操作成功
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("OperationFailed") + "');", true);//操作失败
                }
            }
            if (e.CommandName == "Edit")
            {
                Response.Redirect("Address.aspx?ID=" + iID + "");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                lgk.Model.tb_Address addressInfo = new lgk.Model.tb_Address();

                if (iID > 0)
                {
                    addressInfo = addressBLL.GetModel(iID);
                }

                addressInfo.Address = txtAddress.Text.Trim();
                addressInfo.MemberName = txtMemberName.Text.Trim();
                addressInfo.PhoneNum = txtPhoneNum.Text.Trim();
                addressInfo.Phone = "";// txtPhone.Text.Trim();
                addressInfo.UserID = getLoginID();
                addressInfo.AreaInProvince = "";
                addressInfo.AreaInCity = "";
                addressInfo.PostCode = "";

                if (iID > 0)
                {
                    if (chkDefault.Checked == false)
                    {
                        addressInfo.Address01 = "0";
                    }
                    else
                    {
                        addressBLL.SetDefault(getLoginID(), addressInfo.ID);
                        addressInfo.Address01 = "1";
                    }

                    if (addressBLL.Update(addressInfo))
                    {
                        MessageBox.ShowAndRedirect(this, GetLanguage("Successful"), "Address.aspx");//操作成功
                    }
                    else
                    {
                        MessageBox.Show(this, GetLanguage("OperationFailed"));//操作失败
                        return;
                    }
                }
                else
                {
                    long id = addressBLL.Add(addressInfo);
                    if (id > 0)
                    {
                        if (chkDefault.Checked)
                            addressBLL.SetDefault(getLoginID(), id);
                        else
                            addressInfo.Address01 = "0";

                        MessageBox.ShowAndRedirect(this, GetLanguage("Successful"), "Address.aspx");//操作成功
                    }
                    else
                    {
                        MessageBox.Show(this, GetLanguage("OperationFailed"));//操作失败
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 验证添加
        /// </summary>
        /// <returns></returns>
        public bool ValidateData()
        {
            if (txtAddress.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, GetLanguage("AddressEmpty"));//收货地址不能为空
                return false;
            }
            if (txtMemberName.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, GetLanguage("ConsigneeEmpty"));//收货人不能为空
                return false;
            }

            if (txtPhoneNum.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, GetLanguage("CommonEmpty"));//常用号码不能为空
                return false;
            }
            var phoneNum = this.txtPhoneNum.Text.Trim();
            if (!string.IsNullOrEmpty(phoneNum) && !PageValidate.RegexPhone(phoneNum))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PhoneMust") + "');", true);//联系电话格式错误
                return false;
            }

            //var phone = this.txtPhone.Text.Trim();
            //if (!string.IsNullOrEmpty(phone) && !PageValidate.RegexPhone(phone))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("PhoneMust") + "');", true);//联系电话格式错误
            //    return false;
            //}
            return true;
        }
    }
}