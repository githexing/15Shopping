/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-30 15:17:11 
 * 文 件 名：		MemberList.cs 
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
using DataAccess;

namespace Web.admin.business
{
    public partial class MemberList : AdminPageBase//System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 10, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码
            
            if (!IsPostBack)
            {
                BindLevel();
                BindData();
            }
        }

        #region 绑定用户級別
        /// <summary>
        /// 绑定用户級別
        /// </summary>
        private void BindLevel()
        {
            IList<lgk.Model.tb_level> List = new lgk.BLL.tb_level().GetModelList("");
            dropLevel.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-请选择-";
            dropLevel.Items.Add(li);
            foreach (lgk.Model.tb_level item in List)
            {
                ListItem items = new ListItem();
                items.Value = item.LevelID.ToString();
                items.Text = item.LevelName;
                dropLevel.Items.Add(items);
            }
        } 
        #endregion

        /// <summary>
        ///已开通查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strRegStart = this.txtRegStart.Text.Trim();
            string strRegEnd = txtRegEnd.Text.Trim();
            string strOpenStart = txtOpenStart.Text.Trim();
            string strOpenEnd = txtOpenEnd.Text.Trim();
            string strWhere = "1 = 1";

            #region 会员类型
            if (this.dropType.SelectedValue != "0")
            {
                if (this.dropType.SelectedValue == "1")
                {
                    strWhere += " and usercode like  '%" + this.txtInput.Value.Trim() + "%'";
                }
                if (this.dropType.SelectedValue == "2")
                {
                    strWhere += " and truename like  '%" + this.txtInput.Value.Trim() + "%'";
                }
                if (this.dropType.SelectedValue == "3")
                {
                    strWhere += " and RecommendCode like  '%" + this.txtInput.Value.Trim() + "%'";
                }
                if (this.dropType.SelectedValue == "4")
                {
                    strWhere += " and ParentCode like  '%" + this.txtInput.Value.Trim() + "%'";
                }
                if (this.dropType.SelectedValue == "5")
                {
                    strWhere += " and User006 like  '%" + this.txtInput.Value.Trim() + "%'";
                }
            }
            #endregion

            #region 会员等级
            if (this.dropLevel.SelectedValue != "0")
            {
                strWhere += " and tb_user.LevelID=" + dropLevel.SelectedValue;
            }
            #endregion
            #region 状态
            if (this.DropDownList1.SelectedValue != "0")
            {
                if (this.DropDownList1.SelectedValue == "1")
                {
                    strWhere += " and tb_user.IsOpend=" + 0;
                }
                if (this.DropDownList1.SelectedValue == "2")
                {
                    strWhere += " and tb_user.IsOpend=" + 2;
                }
                if (this.DropDownList1.SelectedValue == "3")
                {
                    strWhere += " and tb_user.IsLock=" + 1 ;
                }
            }
            #endregion

            #region 注册时间
            if (strRegStart != "" && strRegEnd == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),RegTime,120)  >= '" + strRegStart + "'");
            }
            else if (strRegStart == "" && strRegEnd != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  <= '" + strRegEnd + "'");
            }
            else if (strRegStart != "" && strRegEnd != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120)  between '" + strRegStart + "' and '" + strRegEnd + "'");
            }
            #endregion

            #region 开通时间
            if (strOpenStart != "" && strOpenEnd == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),OpenTime,120) >= '" + strOpenStart + "'");
            }
            else if (strOpenStart == "" && strOpenEnd != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),OpenTime,120) <= '" + strOpenEnd + "'");
            }
            else if (strOpenStart != "" && strOpenEnd != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),OpenTime,120) between '" + strOpenStart + "' and '" + strOpenEnd + "'");
            }
            #endregion

            return strWhere;
        }

        /// <summary>
        /// 绑定已开通会员列表
        /// </summary>
        private void BindData()
        {
            bind_repeater(userBLL.GetOpenList(GetWhere()), Repeater1, "OpenTime desc", tr1, AspNetPager1);
        }

        /// <summary>
        /// 导出申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnExport_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            DataSet ds = userBLL.GetOpenList(GetWhere());
            DataTable dv = ds.Tables[0];
            if (Repeater1.Items.Count == 0)
            {
                MessageBox.MyShow(this, "不能导出空表格");
                return;
            }
            if (dv.Rows.Count == 0)
            {
                MessageBox.MyShow(this, "错误的操作!");
                return;
            }
            string str = ToOpenExecl(Server.MapPath("../../Upload"), dv);
            Response.Redirect("../../Upload/" + str.Replace("\\", "/").Replace("//", "/"), true);
        }

        /// <summary>
        /// 搜索提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        /// <summary>
        /// 分页提现记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        public string adre(int type)
        {
            string bi = "";
              lgk.Model.tb_agent typer = agentBLL.GetModel("userid=" + type);
              if (typer == null)
            { bi = "无"; }
            else
            { 
              if (typer.AgentType == 1)
              {
                  bi = "一级服务中心";
              }
              else if (typer.AgentType == 2)
              {
                  bi = "二级服务中心";
              }
              else if (typer.AgentType == 3)
              {
                  bi = "三级服务中心";
              }
            }
            return bi;
        }

        public string GetTrueName(string strName)
        {
            string str = "";
            if (strName.Trim() != "")
            {
                if (strName.Trim() == "admin")
                {
                    str = "admin";
                }
                else
                {
                    lgk.Model.tb_user userModel = userBLL.GetModel(" UserCode='" + strName + "'");
                    if (userModel != null)
                    {
                        if (userModel.RecommendCode == "admin")
                        {
                            str = "";
                        }
                    }
                }
            }

            return str;
        }
        public string GetNiceName(string strName)
        {
            string str = "";
            if (strName.Trim() != "")
            {
                if (strName.Trim() == "admin")
                {
                    str = "admin";
                }
                else
                {
                    lgk.Model.tb_user userModel = userBLL.GetModel(" UserCode='" + strName + "'");
                    if (userModel != null)
                    {
                        if (userModel.RecommendCode == "admin")
                        {
                            str = "";
                        }
                        else str = userModel.NiceName;
                    }
                }
            }

            return str;
        }

        /// <summary>
        /// 报单方式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string TypeName(object obj)
        {
            string str = string.Empty;
            try
            {
                if (obj != null)
                {
                    string value = obj.ToString();
                    if (value == "0")
                    {
                        str = "未开通"; 
                    }
                    else if(value=="2")
                    {
                        str = "开通";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                int iUserID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "UserID"));

                //LinkButton lbtnOpend = (LinkButton)e.Item.FindControl("lbtnOpend");

                //if (GetRecommend(iUserID) && GetBonus(iUserID))
                //{
                //    lbtnOpend.Visible = true;
                //}
                //else
                //{
                //    lbtnOpend.Visible = false;
                //}
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int iUserID = int.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_user userInfo = userBLL.GetModel(iUserID);
            //lgk.Model.Stock stockInfo = stockBLL.GetModel("UserID=" + iUserID + "");
            if (e.CommandName == "Activate")
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                UserOpen(iUserID);
            }
            if (e.CommandName == "Into")
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                Session["goto_uid"] = iUserID;
                Security sec = new Security();
                string admins = sec.EncryptQueryString("1");//加密传递的adminid
                string userid = sec.EncryptQueryString(iUserID.ToString());//加密传递的adminid
                string _adminUrl = WebHelper.ServerCurrentDomain;
                if (ConfigHelper.GetConfigBool("AdminUseRedirect"))
                    _adminUrl = ConfigHelper.GetConfigString("AdminUrl");
               // Response.Write("<script>window.open('"+ _adminUrl + "/Login.aspx?adminid=" + admins + "&uid=" + userid + "')</script>");
                Response.Write("<script>window.open('../../Login.aspx?adminid=" + admins + "&uid=" + userid + "')</script>");
            }
            if (e.CommandName == "Lock")//冻结
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                userInfo.IsLock = 1;
                userBLL.Update(userInfo);
                //if (stockInfo != null)
                //{
                //    stockInfo.IsLock = 1;
                //    stockBLL.Update(stockInfo);
                //}
                MessageBox.MyShow(this, "冻结成功!");
            }
            if (e.CommandName == "Open")//解冻
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                userInfo.IsLock = 0;
                userBLL.Update(userInfo);
                //if (stockInfo!=null)
                //{
                //    stockInfo.Price = getParamAmount("Share5");
                //    stockInfo.IsLock = 0;
                //    stockBLL.Update(stockInfo);
                //}
                MessageBox.MyShow(this, "解冻成功!");
            }
            if (e.CommandName == "Batch")//解冻
            {
                spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

                //userInfo.BillCount += 1;
                //userInfo.IsOut= 0;
                //userInfo.Emoney += Convert.ToDecimal(getParamAmount("consume" + userInfo.LevelID));
                //if (userBLL.Update(userInfo))
                //{
                //    MessageBox.MyShow(this, "复投成功!");
                //}else
                //{
                //    MessageBox.MyShow(this, "复投失败!");
                //}
            }
            if(e.CommandName == "modifypass")
            {
                userInfo.User005 = "0";
                if (userBLL.Update(userInfo))
                {
                    string ip = Page.Request.UserHostAddress;

                    lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
                    lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
                    log.LogMsg = "设置允许修改资料";
                    log.LogType = 3;//修改资料
                    log.LogLeve = 0;//
                    log.LogDate = DateTime.Now;
                    log.LogCode = "1000";//订单编号
                    log.IsDeleted = 0;
                    log.Log1 = LoginAdmin.UserName;//用户UserID
                    log.Log2 = ip;// 
                    log.Log3 = userInfo.UserID.ToString();
                    log.Log4 = "";
                    syslogBLL.Add(log);

                    MessageBox.MyShow(this, "设置允许修改资料成功!");
                }
                else
                {
                    MessageBox.MyShow(this, "设置允许修改资料失败!");
                }
            }
            if (e.CommandName == "nomodify")
            {
                userInfo.User005 = "1";
                if (userBLL.Update(userInfo))
                {
                    string ip = Page.Request.UserHostAddress;

                    lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
                    lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
                    log.LogMsg = "设置拒绝修改资料";
                    log.LogType = 4;//修改资料
                    log.LogLeve = 0;//
                    log.LogDate = DateTime.Now;
                    log.LogCode = "1001";//订单编号
                    log.IsDeleted = 0;
                    log.Log1 = LoginAdmin.UserName;//用户UserID
                    log.Log2 = ip;// 
                    log.Log3 = userInfo.UserID.ToString();
                    log.Log4 = "";
                    syslogBLL.Add(log);

                    MessageBox.MyShow(this, "设置拒绝修改资料成功!");
                }
                else
                {
                    MessageBox.MyShow(this, "设置拒绝修改资料失败!");
                }
            }
            BindData();
        }
       
        /// <summary>
        /// 开通给定编号的用户
        /// </summary>
        /// <param name="iUserID">用户编号</param>
        private void UserOpen(int iUserID)
        {
            lgk.Model.tb_user userInfo = userBLL.GetModel(iUserID);

            if (userInfo != null)
            {
                if (GetRecommend(iUserID) && GetBonus(iUserID))
                {
                    userInfo.IsOpend = 2;
                    userInfo.User008 = "激活";
                    userBLL.Update(userInfo);
                    MessageBox.MyShow(this, "激活成功!");
                }
                else
                {
                    MessageBox.MyShow(this, "条件不满足,无法激活!");
                }
            }
            else
                MessageBox.MyShow(this, "该会员不存在或已删除,无法再进行此操作!");
        }

        /// <summary>
        /// 获取给定用户编号的会员直推资产（直接推荐人的投资总额）
        /// </summary>
        /// <param name="iUserID">给定用户编号</param>
        /// <returns></returns>
        private bool GetRecommend(int iUserID)
        {
            bool bFalg = false;
            decimal dAsset = Convert.ToDecimal(0.00);

            IList<lgk.Model.tb_user> list = userBLL.GetModelList("[RecommendID] = " + iUserID);
            if (list != null)
            {
                foreach (lgk.Model.tb_user item in list)
                {
                    dAsset += item.RegMoney;
                }

                if (dAsset > 20000)
                    bFalg = true;
                else
                    bFalg = false;
            }
            else
            {
                bFalg = false;
            }

            return bFalg;
        }

        /// <summary>
        /// 判断给定用户编号的会员直推奖金是否大于投资资金。
        /// </summary>
        /// <param name="iUserID">给定用户编号</param>
        /// <returns></returns>
        private bool GetBonus(int iUserID)
        {
            bool bFalg = false;
            decimal dBonus = Convert.ToDecimal(0.00);
            lgk.Model.tb_user userInfo = userBLL.GetModel(iUserID);
            IList<lgk.Model.tb_bonus> list = bonusBLL.GetModelList("[UserID] = " + iUserID + " AND TypeID = 1");

            if (list != null)
            {
                foreach (lgk.Model.tb_bonus item in list)
                {
                    dBonus += item.Amount;
                }

                if (dBonus > userInfo.RegMoney)
                    bFalg = true;
                else
                    bFalg = false;
            }

            return bFalg;
        }
    }
}