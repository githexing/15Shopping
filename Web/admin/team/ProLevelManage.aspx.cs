using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;
using System.Data.SqlClient;

namespace Web.admin.team
{
    public partial class ProLevelManage : AdminPageBase
    {
        //lgk.BLL.tb_level levbll = new lgk.BLL.tb_level();
        //lgk.BLL.tb_systemBank sysbank = new lgk.BLL.tb_systemBank();
        //lgk.BLL.tb_remit remitbll = new lgk.BLL.tb_remit();
        //public int mk = 0;
        lgk.BLL.tb_remit remitbll = new lgk.BLL.tb_remit();
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 11, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密碼
            if (!IsPostBack)
            {

                BindData();
              
                this.btnSearch.Text = "搜索";//搜索
            }
        }
        protected string getLastLevel(int lastLevel)
        {
            try
            {
                return levelBLL.GetModel(lastLevel).LevelName;
            }
            catch (Exception )
            {
                return "";
            }
        }

        //private void ddlL()
        //{
        //    IList<lgk.Model.tb_level> ddlList = new lgk.BLL.tb_level().GetModelList("LevelID<=7");
        //    string strUserCode = txtUserCode1.Text.Trim();
        //    if(strUserCode!=""&&GetUserID(strUserCode)>0)
        //    {
        //        int i = userBLL.GetModel(GetUserID(strUserCode)).LevelID;//当前会员等级
        //        ddlList = ddlList.Where(o => o.LevelID > i).ToList();
        //    }
        //    ddlLevel.Items.Clear();
        //    ListItem li = new ListItem();
        //    li.Value = "0";
        //    li.Text = "-请选择-";
        //    ddlLevel.Items.Add(li);
        //    foreach (lgk.Model.tb_level item in ddlList)
        //    {
        //        ListItem items = new ListItem();
        //        items.Value = item.LevelID.ToString();
        //        items.Text = item.LevelName;
        //        ddlLevel.Items.Add(items);
        //    }
        //}

        //#region 判断用户是否为最高级别
        //public void heightClassHand()
        //{
        //    int levlId = 7;//levbll.GetMaxId();
        //    string strUserCode = txtUserCode1.Text.Trim();
        //    if(strUserCode!=""&&userBLL.GetModel(GetUserID(strUserCode))!=null)
        //    {
        //        int LevelID = userBLL.GetModel(GetUserID(strUserCode)).LevelID;
        //        if (levlId != 0)
        //        {
        //            if (LevelID >= levlId)
        //            {
        //                Literal1.Text = GetLanguage("highestLevel");//您当前已是最高级别
        //                btnSubmit.Visible = false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
        //#endregion

        //private void bind_pro()
        //{
        //    string strWhere = " 1=1 ";//1 会员晋升 2 开通报单中心
        //    if (mk==0)
        //    {
        //        bind_repeater(GetProList(strWhere), Repeater1, "AddDate desc", tr1, AspNetPager1);
        //    }
        //    else if(mk==1)
        //    {
        //        if(txtUserCode1.Text!="")
        //        {
        //            strWhere += " and u.usercode like '%" + txtUserCode1.Text.Trim() + "%'";
        //            bind_repeater(GetProList(strWhere), Repeater1, "AddDate desc", tr1, AspNetPager1);
        //        }
        //    }
        //    else if(mk==2)
        //    {
        //        string StarTime = this.txtStar.Text.Trim();
        //        string EndTime = this.txtEnd.Text.Trim();
        //        if (txtUserCode.Text!="")
        //        {
        //            strWhere += " and u.usercode like '%" + txtUserCode.Text.Trim() + "%'";
        //            if (StarTime != "")
        //            {
        //                strWhere += string.Format(" and Convert(nvarchar(10),p.AddDate,120)  >= '" + StarTime + "'");
        //            }
        //            if (EndTime != "")
        //            {
        //                strWhere += string.Format(" and  Convert(nvarchar(10),p.AddDate,120)  <= '" + EndTime + "'");
        //            }
        //            bind_repeater(GetProList(strWhere), Repeater1, "AddDate desc", tr1, AspNetPager1);
        //        }
        //        else if(StarTime!=""&&EndTime!="")
        //        {
        //            strWhere += string.Format(" and Convert(nvarchar(10),p.AddDate,120)  >= '" + StarTime + "'");
        //            strWhere += string.Format(" and  Convert(nvarchar(10),p.AddDate,120)  <= '" + EndTime + "'");
        //            bind_repeater(GetProList(strWhere), Repeater1, "AddDate desc", tr1, AspNetPager1);
        //        }
        //        else
        //        {
        //            return;
        //        }
        //    } 
        //    //if (txtUserCode.Text != "")
        //    //{
        //    //    strWhere += " and u.usercode like '%" + txtUserCode.Text.Trim() + "%'";
        //    //}

        //    //bind_repeater(GetProList(strWhere), Repeater1, "AddDate desc", tr1, AspNetPager1);
        //}

        //private void bind_pro1()
        //{
        //    string strWhere = " 1=1";
        //    if(txtUserCode1.Text!="")
        //    {
        //        strWhere += " and u.usercode like '%" + txtUserCode1.Text.Trim() + "%'";
        //    }
        //    bind_repeater(GetProList(strWhere),Repeater1,"AddDate desc",tr1,AspNetPager1);
        //}

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    this.label1.Text = "搜索";
        //    bind_pro();
        //}



        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    string usercode = txtUserCode1.Text.Trim();
        //    if (sender==btnSubmit)
        //    {
        //        mk = 1;   //标出Button_Click事件触发者 1-点击提交/确认按钮 2-点击查询/搜索按钮
        //        if (usercode == "")
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入要晋升的会员编号!');", true);
        //            return;
        //        }

        //        lgk.Model.tb_user userInfo = userBLL.GetModel(GetUserID(usercode));

        //        if (userInfo == null)
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该会员不存在!');", true);
        //            return;
        //        }
        //        lgk.Model.tb_userPro userpro = proBLL.GetModelByUserID(Convert.ToInt32(userInfo.UserID));

        //        if (userInfo.IsOpend == 0)
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该会员尚未开通，请开通后再进行此操作!');", true);
        //            return;
        //        }
        //        if (userpro != null)
        //        {
        //            if (userpro.Flag == 0)
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该会员尚有申请未审核！');", true);
        //                return;
        //            }
        //        }

        //        int endLevel = Convert.ToInt32(ddlLevel.SelectedValue.Trim());
        //        if (endLevel == 0)
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择晋升级别!');", true);
        //            return;
        //        }
        //        if (endLevel <= userInfo.LevelID)
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请选择高于当前会员的等级!');", true);
        //            return;
        //        }
        //        decimal money = getParamAmount("Level" + ddlLevel.SelectedValue);
        //        if (userInfo != null)
        //        {
        //            //记录升级表
        //            lgk.Model.tb_userPro upModel = new lgk.Model.tb_userPro();
        //            upModel.UserID = Convert.ToInt32(userInfo.UserID);
        //            upModel.LastLevel = userInfo.LevelID;
        //            upModel.Remark = "后台晋升";
        //            upModel.Flag = 0;
        //            upModel.ProMoney = money;
        //            if (userInfo.StockAccount >= money)
        //            {
        //                upModel.Pro003 = userInfo.StockAccount - upModel.ProMoney;//所剩奖金积分(此时为月静态钱包奖金积分)
        //                upModel.Pro001 = 1;   //扣除的奖金积分类型( 1表示月静态钱包奖金积分 2表示月动态钱包奖金积分 )
        //            }
        //            else if (userInfo.StockMoney >= money)
        //            {
        //                upModel.Pro003 = userInfo.StockMoney - upModel.ProMoney;//所剩奖金积分(此时为月分红动态钱包奖金积分)
        //                upModel.Pro001 = 2;   //扣除的奖金积分类型( 1表示月静态钱包奖金积分 2表示月动态钱包奖金积分 )
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您的奖金积分不足，无法晋升');", true);//奖金积分不足，无法晋升
        //                return;
        //            }
        //            upModel.EndLevel = endLevel;

        //            upModel.AddDate = DateTime.Now;
        //            upModel.FlagDate = DateTime.Now;
        //            //upModel.Pro008 = "1";//1会员晋升 2 报单中心

        //            if (proBLL.Add(upModel) > 0)
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('升级申请成功!请等待审核..');window.location.href='ProManage.aspx';", true);
        //                return;
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('会员升级申请失败！');", true);
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.MyShow(this, "该会员不存在!");
        //        }
        //        //this.label1.Text = "提交";
        //        bind_pro();
        //    }
        //    else if(sender==btnSearch)
        //    {
        //        mk = 2;
        //        if(txtUserCode.Text==""&&txtStar.Text.Trim()==""&&txtEnd.Text.Trim()=="")
        //        {
        //            MessageBox.MyShow(this, "请输入会员编号或选择查询时间!");
        //        }
        //        bind_pro();
        //    }
        //}



        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string UC = SafeHelper.GetSafeSqlandHtml(txtUserCode.Text.Trim());
            string strWhere = "";
           
            string strStartTime = txtStart.Text.Trim();
            string strEndTime = txtEnd.Text.Trim();

            strWhere = " u.IsOpend=2 and r.Remit001=3 and p.EndLevel=r.Remit002";
            if (UC != "")
            {
                 strWhere += " and u.UserCode='" + UC + "'";
            }
            
            if (strStartTime != "" && strEndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),r.AddDate,120)  >= '" + strStartTime + "'");
            }
            else if (strStartTime == "" && strEndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),r.AddDate,120)  <= '" + strEndTime + "'");
            }
            else if (strStartTime != "" && strEndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),r.AddDate,120)  between '" + strStartTime + "' and '" + strEndTime + "'");
            }
            return strWhere;
        }

        private void BindData()
        {
            bind_repeater(userBLL.RemitToProLevel(GetWhere()), Repeater1, "AddDate desc", tr1, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
        }
        /*protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_remit remit = remitBLL.GetModel(id);
            lgk.Model.tb_userPro model = proBLL.GetModel(id);
            lgk.Model.tb_user user = userBLL.GetModel(model.UserID);
            if (model == null || remit == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('已删除,无法进行此操作！');window.location.href='ProManage.aspx';", true);
            }
            else
            {
                if (model.Flag == 1 || remit.State==1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('已审核,无法进行此操作！');window.location.href='ProManage.aspx';", true);
                }
                else
                {
                    if (e.CommandName == "State")
                    {
                        if (flag_pro(model.ID, 1))
                        {
                            decimal reEmoney = model.ProMoney;
                            
                            AllCore acore = new AllCore();//1收入2支出
                            acore.add_userRecord(user.UserCode, DateTime.Now, reEmoney, 2);
                            
                            //记录流水账表
                            lgk.Model.tb_journal journaM = new lgk.Model.tb_journal();
                            journaM.UserID = Convert.ToInt32(model.UserID);
                            journaM.Remark = "会员升级";
                            journaM.InAmount = 0;
                            journaM.OutAmount = model.ProMoney;
                            journaM.Journal02 = 2;    //tb_journal表标示币种操作类型: 1-积分 2-现金汇款
                            journaM.BalanceAmount = remit.RemitMoney;   //汇款金额
                            journaM.JournalDate = DateTime.Now;
                            journaM.JournalType = 5;      //标记流水账记录类型: 1-提现 2-转账 3-充值 5-会员升级

                            UpdateSystemAccount("MoneyAccount", reEmoney, 1);
                            journalBLL.Add(journaM);
             
                            lgk.Model.tb_remit remitMoney = new lgk.Model.tb_remit();
                            remitMoney.State = 1;
                            //remitMoney.PassDate = DateTime.Now;
                            remitBLL.Update(remitMoney);
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('审核成功!');", true);   
                        }
                    }
                    //if (e.CommandName == "delete")
                    //{
                    //    //加入流水账表
                    //    lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                    //    jmodel.UserID = Convert.ToInt32(model.UserID);
                    //    jmodel.Remark = "会员升级(未通过审核)";
                    //    jmodel.InAmount = model.ProMoney;
                    //    jmodel.OutAmount = 0;
                    //    jmodel.Journal02 = 2;
                    //    jmodel.BalanceAmount = user.StockAccount + model.ProMoney;
                    //    jmodel.JournalDate = DateTime.Now;
                    //    jmodel.JournalType = 5;
                    //    //返还扣除金额
                    //    var u = userBLL.GetModel(model.UserID);
                    //    decimal prom = 0;
                    //    if (u != null && decimal.TryParse(model.ProMoney.ToString(), out prom))
                    //    {
                    //        if(model.Pro001==1)
                    //        {
                    //            u.StockAccount = u.StockAccount + prom;
                    //        }
                    //        else if(model.Pro001==2)
                    //        {
                    //            u.StockMoney = u.StockMoney + prom;
                    //        }
                    //    }
                    //    decimal reEmoney = (decimal)model.ProMoney; 
                    //    if (userBLL.Update(u) && proBLL.Delete(Convert.ToInt32(id)) && journalBLL.Add(jmodel) > 0)
                    //    {
                    //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('删除成功!');", true);
                    //    }
                    //}
                    
                }
            }
        }*/

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

     
        //protected void txtUserCode1_TextChanged(object sender, EventArgs e)
        //{
        //    string usercode = this.txtUserCode1.Text.Trim();
        //    if(usercode!="")
        //    {
        //        lgk.Model.tb_user userInfo = userBLL.GetModel(GetUserID(usercode));
        //        if (userInfo != null)
        //        {
        //            txtLevel.Value = levelBLL.GetModel(userInfo.LevelID).LevelName;
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('该会员不存在!');", true);
        //            txtLevel.Value = "";
        //            return;
        //        }
        //    }
        //   else
        //    {
        //        return;
        //    }
        //}
    }
}