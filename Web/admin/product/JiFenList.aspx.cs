using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using DataAccess;

namespace Web.admin.product
{
    public partial class JiFenList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 51, getLoginID());//权限
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            decimal money=0;
            DateTime BeginTime;
            DateTime EndTime;
            if (txtStar.Text.Trim().Length > 0)
            {
                BeginTime = Convert.ToDateTime(txtStar.Text.Trim());
            }
            else
            {
                BeginTime = DateTime.Now.AddYears(-100);
            }
            if (txtEnd.Text.Trim().Length > 0)
            {
                EndTime = Convert.ToDateTime(txtEnd.Text.Trim());
            }
            else
            {
                EndTime = DateTime.Now.AddYears(100);
            }

            if (txtEmoney.Value != "")
            {
                try
                {
                    money = Convert.ToDecimal(this.txtEmoney.Value);
                    if (money <= 0)
                    {
                        MessageBox.Show(this, "请输入大于0的数字");
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "必须输入数字");
                    return;
                }
            }
            else 
            {
                MessageBox.Show(this, "请输入金额");
                return;
            } 
            if (rdoJiang.Checked) 
            {
                //if (txtBonusAccount.Value != "")
                //{
                //    try
                //    {
                //         money= Convert.ToDecimal(this.txtBonusAccount.Value);
                //    }
                //    catch (Exception)
                //    {
                //        MessageBox.Show(this,"必须输入数字");
                //    }
                if (this.MyExecProc(string.Format("exec addStockMoney {0},1,'" + BeginTime + "','" + EndTime + "'", money)) > 0)
                {
                    MessageBox.MyShow(this, "奖金币增加积分成功!");
                    this.txtEmoney.Value = "";
                }
                else 
                {
                    MessageBox.MyShow(this, "奖金币增加积分失败!");
                }
                //}

            }
            else if (rdoDian.Checked)
            {
                //if (txtEmoney.Value != "")
                //{
                //    try
                //    {
                //        money = Convert.ToDecimal(this.txtEmoney.Value);
                //    }
                //    catch (Exception)
                //    {
                //        MessageBox.Show(this, "必须输入数字");
                //    }
                if (this.MyExecProc(string.Format("exec addStockMoney {0},2,'" + BeginTime + "','" + EndTime + "'", money)) > 0)
                {
                    MessageBox.MyShow(this, "金币增加积分成功!");
                    this.txtEmoney.Value = "";
                }
                else
                {
                    MessageBox.MyShow(this, "金币增加积分失败!");
                }
                //}
            }
            else
            {
                MessageBox.MyShow(this, "请选择币种!"); return;
            }
            bind();
        }

        protected void btnChuSearch_Click(object sender, EventArgs e)
        {
            bind();
        }
        string getWhere() 
        {
            string str = " JournalType IN (1,2) and Journal02=0";
            if (!string.IsNullOrEmpty(this.txtCode.Value.Trim()))
            {
                str += " and UserCode like '%" + txtCode.Value.Trim().Replace("'", "") + "%'";
            }
            return str;
        }
        void bind()
        {
            bind_repeater(journalBLL.GetList(getWhere()), rptProduct, "JournalDate desc", tr1, AspNetPager1);
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
        public string Type(string typeid) 
        {
            string state = "";
            switch (typeid)
            {
                case "1":
                    state = "奖金币";
                    break;
                case "2":
                    state = "金币";
                    break;
            }
            return state;
        }
       
    }
}