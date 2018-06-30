using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Library;

namespace Web.admin.business
{
    public partial class Member : AdminPageBase
    {
        private string StarTime = "", EndTime = "", strWhere = "", strType = "";
        protected string money = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 8, getLoginID());//权限

            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                //BindLevel();
                BindData();
            }
        }

        /// <summary>
        /// 绑定用户級別
        /// </summary>
        //private void BindLevel()
        //{
        //    IList<lgk.Model.tb_level> myList = new lgk.BLL.tb_level().GetModelList("");
        //    dropLevel.Items.Clear();
        //    ListItem li = new ListItem();
        //    li.Value = "0";
        //    li.Text = "-请选择-";
        //    dropLevel.Items.Add(li);
        //    foreach (lgk.Model.tb_level item in myList)
        //    {
        //        ListItem items = new ListItem();
        //        items.Value = item.LevelID.ToString();
        //        items.Text = item.LevelName;
        //        dropLevel.Items.Add(items);
        //    }
        //}

        /// <summary>
        /// 申请记录查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            StarTime = txtStar.Text.Trim();
            EndTime = txtEnd.Text.Trim();
            strType = dropType.SelectedValue;

            strWhere = " IsOpend=0";

            if (strType != "0")
            {
                if (strType == "1")
                {
                    strWhere += " and usercode like  '%" + this.txtInput.Value.Trim() + "%'";
                }
                if (strType == "2")
                {
                    strWhere += " and truename like  '%" + this.txtInput.Value.Trim() + "%'";
                }
                if (strType == "3")
                {
                    strWhere += " and RecommendCode like  '%" + this.txtInput.Value.Trim() + "%'";
                }
                if (strType == "4")
                {
                    strWhere += " and User006 like  '%" + this.txtInput.Value.Trim() + "%'";
                }
            }

            //if (this.dropLevel.SelectedValue != "0")
            //{
            //    strWhere += " and tb_user.LevelID=" + dropLevel.SelectedValue;
            //}
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),RegTime,120) >= '" + StarTime + "'");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120) <= '" + EndTime + "'");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),RegTime,120) between '" + StarTime + "' and '" + EndTime + "'");
            }
            return strWhere;
        }

        /// <summary>
        /// 填充申请记录
        /// </summary>
        private void BindData()
        {
            bind_repeater(userBLL.GetOpenList(GetWhere()), Repeater1, "RegTime desc", divno, AspNetPager1);
        }

        /// <summary>
        /// 搜索申请记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
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

        /// <summary>
        /// 审核分页申请记录
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long UserID = long.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_user model = userBLL.GetModel(UserID);
            if (model == null)
            {
                MessageBox.MyShow(this, "该会员已删除,无法再进行此操作!");
                return;
            }
            if (model.IsOpend != 0)
            {
                MessageBox.MyShow(this, "该会员已激活,无法再进行此操作!");
                return;
            }
            if (e.CommandName.Equals("open"))//
            {
                AllCore acore = new AllCore();//1收入2支出

                //开通会员检查
                int i = acore.OpenCheck(model);
                if (i != 0)
                {
                    MessageBox.MyShow(this, acore.OpenCheckErrorMsg(i));
                    return;
                }
                if (flag_open(UserID, 2) > 0)
                {
                    acore.add_userRecord(model.UserCode, DateTime.Now, model.RegMoney, 2);
                    MessageBox.MyShow(this, "开通成功!");
                }
                else
                {
                    MessageBox.MyShow(this, "开通失败!"); //开通失败
                }
            }
            if (e.CommandName.Equals("Empty"))//
            {
                if (userBLL.UpdateEmpty(UserID))
                {
                    MessageBox.MyShow(this, "开通空单成功!");
                }
                else
                {
                    MessageBox.MyShow(this, "开通空单失败!"); //开通失败
                }
            }
            if (e.CommandName.Equals("Remove"))//删除
            {
                //返还注册金额
                if (userBLL.Delete(UserID))
                {
                    MessageBox.MyShow(this, "删除成功!");
                }
                else
                {
                    MessageBox.MyShow(this, "删除失败!");
                }
            }
            BindData();
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnExport_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            DataSet ds = userBLL.GetOpenList(GetWhere());
            DataTable dt = ds.Tables[0];
            if (Repeater1.Items.Count == 0)
            {
                MessageBox.MyShow(this, "不能导出空表格");
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.MyShow(this, "错误的操作!");
                return;
            }
            string str = ToOpenExecl(Server.MapPath("../../Upload"), dt);
            Response.Redirect("../../Upload/" + str.Replace("\\", "/").Replace("//", "/"), true);
        }
    }
}
