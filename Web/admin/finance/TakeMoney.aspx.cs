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

namespace Web.admin.finance
{
    public partial class TakeMoney : AdminPageBase//System.Web.UI.Page
    {
        private string strWhere = "";
        string StarTime;
        string EndTime;

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 16, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            string action = Request.QueryString["action"];
            if (action == "ajax")
            {
                ajax();
                return;
            }

            if (!IsPostBack)
            {
                BindType();
            }
               
                BindData();
            
            txtMoney.Value = GetTotalTake(0).ToString("0.00");
        }
        protected void lbtnApply_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeMoney.aspx");
        }

        protected void lbtnDraw_Click(object sender, EventArgs e)
        {
            Response.Redirect("TakeList.aspx");
        }
        private void BindType()
        {
            dropTypeDown.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            dropTypeDown.Items.Add(li);
            ListItem li6 = new ListItem();
            li6.Value = "1";
            li6.Text = "原始币";
            dropTypeDown.Items.Add(li6);
            ListItem li2 = new ListItem();
            li2.Value = "2";
            li2.Text = "释放币";

            dropTypeDown.Items.Add(li2);
            //ListItem li3 = new ListItem();
            //li3.Value = "3";
            //li3.Text = "动态月分红";
            //dropTypeDown.Items.Add(li3);
            //ListItem li4 = new ListItem();
            //li4.Value = "4";
            //li4.Text = "静态年分红";
            //dropTypeDown.Items.Add(li4);
            //ListItem li5 = new ListItem();
            //li5.Value = "5";
            //li5.Text = "动态年分红";
            //dropTypeDown.Items.Add(li5);

        }
        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            StarTime = txtStar.Text.Trim();
            EndTime = txtEnd.Text.Trim();
            strWhere = " b.Flag=0";
            if (this.txtUserCode.Value != "")
            {
                strWhere += " and u.usercode like '%" + this.txtUserCode.Value.Trim() + "%'";
            }
            if (this.txtTrueName.Value != "")
            {
                strWhere += " and u.trueName like '%" + this.txtTrueName.Value.Trim() + "%'";
            }
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),b.TakeTime,120) >= '" + StarTime + "'");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),b.TakeTime,120) <= '" + EndTime + "'");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),b.TakeTime,120) between '" + StarTime + "' and '" + EndTime + "'");
            }
            if (dropTypeDown.SelectedItem.Value != "0")
            {
                strWhere += string.Format(" and Take001=" + dropTypeDown.SelectedValue);
            }
            return strWhere;
        }
        public string TakeType(int type)
        {
            string str = "";
            if (type == 1)
            {
                str = "奖金币";
            }
            if (type == 2)
            {
                str = "释放币";
            }
           
            return str;
        }
        /// <summary>
        /// 填充申请记录
        /// </summary>
        private void BindData()
        {
            bind_repeater(GetTakeList(GetWhere()), Repeater1, "TakeTime desc", tr1, AspNetPager1);
        }
        /// <summary>
        /// 搜索申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        /// <summary>
        /// 导出申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnExport_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            DataSet ds = GetTakeList(GetWhere());
            DataTable dt = ds.Tables[0];
            DataView dataView = dt.DefaultView;
            dataView.Sort = "TakeTime asc";
            dt = dataView.ToTable();
            if (Repeater1.Items.Count == 0)
            {
                MessageBox.MyShow(this, "不能导出空表格");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.MyShow(this, "错误的操作");
                return;
            }
            string str = ToTakeExecl2(Server.MapPath("../../Upload"), dt);
            Response.Redirect("../../Upload/" + str.Replace("\\", "/").Replace("//", "/"), true);
        }
        /// <summary>
        /// 审核分页申请记录
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long ID = Convert.ToInt64(e.CommandArgument); //ID
            string filename = "";
            lgk.Model.tb_takeMoney cModel = takeBLL.GetModel(ID);
            lgk.BLL.tb_systemMoney sy = new lgk.BLL.tb_systemMoney();
            //lgk.BLL.tb_rechargeable dotx = new lgk.BLL.tb_rechargeable();
            lgk.Model.tb_systemMoney system = sy.GetModel(1);
            if (cModel == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已删除,无法再进行此操作！');window.location.href='TakeMoney.aspx';", true);
            }
            else
            {

                if (cModel.Flag == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该记录已审核,无法再进行此操作！');window.location.href='TakeMoney.aspx';", true);

                }
                else
                {
                    lgk.Model.tb_user user = userBLL.GetModel(Convert.ToInt32(cModel.UserID));
                    if (e.CommandName.Equals("Open"))//确认
                    {
                        cModel.Flag = 1;
                        cModel.Take006 = DateTime.Now;
                        if (takeBLL.Update(cModel) && UpdateSystemAccount("MoneyAccount", Convert.ToDecimal(cModel.RealityMoney), 0) > 0)
                        {
                            if (cModel.Take001 == 6)
                            {
                                user.Batch = 0;
                                userBLL.Update(user);
                            }

                            //发送短信通知
                            string content = GetLanguage("MessageTakeMoneyOK").Replace("{username}", user.UserCode).Replace("{time}", Convert.ToDateTime(cModel.TakeTime).ToString("yyyy年MM月dd日HH时mm分")).Replace("{timeEn}", Convert.ToDateTime(cModel.TakeTime).ToString("yyyy/MM/dd HH:mm"));
                            SendMessage(Convert.ToInt32(cModel.UserID), user.PhoneNum, content);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('操作成功！');", true);//window.location.href='TakeMoney.aspx';
                            BindData();

                        }
                    }
                    if (e.CommandName.Equals("Remove"))//删除
                    {
                        //加入流水账表
                        lgk.Model.tb_journal model = new lgk.Model.tb_journal();
                        lgk.Model.tb_user users = userBLL.GetModel(cModel.UserID);
                        model.UserID = cModel.UserID;
                        model.Remark = "取消提现";
                        model.InAmount = cModel.TakeMoney ;
                        model.OutAmount = 0;
                        if (cModel.Take001 == 1)
                        {
                            model.BalanceAmount = user.Emoney + cModel.TakeMoney;
                            filename = "emoney";
                           // model.Journal02 = 2;//释放币
                            model.JournalType = 1;
                        }
                        if (cModel.Take001 == 2)
                        {
                            model.BalanceAmount = user.BonusAccount + cModel.TakeMoney + cModel.TakePoundage;
                            filename = "BonusAccount";
                          //  users.Emoney = users.Emoney + cModel.RealityMoney + cModel.TakePoundage;
                         //   users.StockMoney = users.BonusAccount + cModel.TakeMoney + cModel.TakePoundage;
                          //  model.Journal02 = 4; //原始积分
                            model.JournalType = 2;
                        }
                        //if (cModel.Take001 == 3)
                        //{
                        //    model.BalanceAmount = user.StockMoney + cModel.TakeMoney + cModel.TakePoundage;
                        //    filename = "StockMoney";
                        //    //users.BonusAccount = users.BonusAccount + cModel.TakeMoney + cModel.TakePoundage;
                        //    model.Journal02 = cModel.Take001;
                        //}
                        //if (cModel.Take001 == 4)
                        //{
                        //    model.BalanceAmount = user.ShopAccount + cModel.TakeMoney + cModel.TakePoundage;
                        //    filename = "ShopAccount";
                        //    users.Emoney = users.Emoney + cModel.RealityMoney;
                        //    users.BonusAccount = users.BonusAccount + cModel.TakeMoney + cModel.TakePoundage;
                        //    model.Journal02 = cModel.Take001;
                        //}
                        //if (cModel.Take001 == 5)
                        //{
                        //    model.BalanceAmount = user.GLmoney + cModel.TakeMoney + cModel.TakePoundage;
                        //    filename = "GLmoney";
                        //    users.BonusAccount = users.BonusAccount + cModel.TakeMoney + cModel.TakePoundage;
                        //    model.Journal02 = cModel.Take001;
                        //}
                        //if (cModel.Take001 == 6)
                        //{
                        //    model.BalanceAmount = user.RegMoney + cModel.TakeMoney + cModel.TakePoundage;
                        //    filename = "RegMoney";
                        //    users.Batch = 0;
                        //    model.Journal02 = cModel.Take001;
                        //}
                        model.JournalDate = DateTime.Now;
                        
                        model.Journal01 = cModel.UserID;
                        if (journalBLL.Add(model) > 0 && userBLL.Update(users) && UpdateAccount(filename, user.UserID, cModel.TakeMoney , 1) > 0 &&  takeBLL.Delete(ID))
                        {
                            MessageBox.MyShow(this, "取消成功");
                            BindData();
                        }
                        else
                        {
                            MessageBox.MyShow(this, "取消失败");
                        }
                    }
                }
            }
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


        protected void dropTypeDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void ajax()
        {
            string tid = Request.QueryString["tid"];
            string[] tids = tid.Split(',');

            Response.Clear(); //清除所有之前生成的Response内容
            
            foreach (var t in tids)
            {
                lgk.Model.tb_takeMoney cModel = takeBLL.GetModel(Convert.ToInt32(t));
                lgk.Model.tb_user user = userBLL.GetModel(Convert.ToInt32(cModel.UserID));
                if (cModel.Flag == 0)
                {
                    cModel.Flag = 1;
                    cModel.Take006 = DateTime.Now;
                    if (takeBLL.Update(cModel) && UpdateSystemAccount("MoneyAccount", Convert.ToDecimal(cModel.RealityMoney), 0) > 0)
                    {
                        if (cModel.Take001 == 6)
                        {
                            user.Batch = 0;
                            userBLL.Update(user);
                        }
                    }
                }
            }

            Response.Write("ok");
            Response.End(); //停止Response后续写入动作，保证Response内只有我们写入内容
        }
    }
}
