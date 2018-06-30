using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.system
{
    public partial class ScoktSet: AdminPageBase
    {
        lgk.BLL.tb_TrainBackUrl tback = new lgk.BLL.tb_TrainBackUrl();
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 67, getLoginID());//权限
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            lgk.Model.tb_TrainBackUrl model = tback.GetModel("");
            if(model != null)
            {
                city.Value = model.SubmitCallback ;
                text1.Value = model.CompanName;
                textName.Value = model.PayCallback ;
                textCode.Value = model.RefundCallback;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (city.Value == "")
                {
                    MessageBox.Show(this.Page, "占座回调地址不能为空");
                    return;
                }
                if (text1.Value == "")
                {
                    MessageBox.Show(this.Page, "公司名称不能为空");
                    return;
                }
                if (textName.Value == "")
                {
                    MessageBox.Show(this.Page, "出票回调地址不能为空");
                    return;
                }
                if (textCode.Value == "")
                {
                    MessageBox.Show(this.Page, "退款回调地址不能为空");
                    return;
                }
                //提交前先删除原来的地址
                if (tback.Delete())
                {
                    lgk.Model.tb_TrainBackUrl model = new lgk.Model.tb_TrainBackUrl();
                    model.SubmitCallback = city.Value;
                    model.CompanName = text1.Value;
                    model.PayCallback = textName.Value;
                    model.RefundCallback = textCode.Value;
                    if (tback.Add(model) > 0)
                    {
                        MessageBox.Show(this.Page, "提交成功");
                    }
                    else
                    {
                        MessageBox.Show(this.Page, "提交失败");
                    }
                }
                else
                {
                    MessageBox.Show(this.Page, "删除来的地址失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Page, "系统异常，异常信息：" + ex.Message);
            }
        }

    }
}