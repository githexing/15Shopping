using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.admin.product
{
    public partial class DescTime : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 46, getLoginID());//权限
            if (!IsPostBack)
            {
                int SaId = ConvertToInt(Request.QueryString["id"]);//排场ID
                lgk.Model.tb_Salesroom model = tb_SalesroomBll.GetModel(SaId);
                if (string.IsNullOrEmpty(model.SaBeginTime.ToString()))
                {
                    model.SaBeginTime = DateTime.Now;
                }
                txtNian.Text = model.SaBeginTime.Value.Year.ToString();
                txtYue.Text = model.SaBeginTime.Value.Month.ToString();
                txtDay.Text = model.SaBeginTime.Value.Day.ToString();
                txtHour.Text = model.SaBeginTime.Value.Hour.ToString();
                txtMinute.Text = model.SaBeginTime.Value.Minute.ToString();
                txtSecond.Text = model.SaBeginTime.Value.Second.ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int SaId = ConvertToInt(Request.QueryString["id"]);//排场ID
            int year = ConvertToInt(txtNian.Text);
            int month = ConvertToInt(txtYue.Text);
            int day = ConvertToInt(txtDay.Text);
            int hour = ConvertToInt(txtHour.Text);
            int minute = ConvertToInt(txtMinute.Text);
            int second = ConvertToInt(txtSecond.Text);
            string sTime = year + "/" + month + "/" + day + " " + hour + ":" + minute + ":" + second;
            if (!PageValidate.IsDateTime(sTime))
            {
                MessageBox.Show(this, "您输入的数据格式有误！"); return;
            }
            DateTime time = Convert.ToDateTime(sTime);
            
            if (time > DateTime.Now)
            {
                lgk.Model.tb_Salesroom model = tb_SalesroomBll.GetModel(SaId);
                model.SaBeginTime = time;
                model.SaTurnoverTime = time;
                if (tb_SalesroomBll.Update(model))
                {
                    MessageBox.ShowAndRedirect(this, "设置倒计时成功", "SalesroomList.aspx");
                }
                else 
                {
                    MessageBox.Show(this, "设置倒计时失败");
                }
            }
            else 
            {
                MessageBox.Show(this,"请设置大于当前时间");
            }
           
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesroomList.aspx");
        }
    }
}