using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.admin.team
{
    public partial class TableTrees : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSearch.Text = GetLanguage("Search");//搜索
                BindData();
            }
        }

        /// <summary>
        ///查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            //lgk.Model.tb_admin LoginUser = adminBLL.GetModel(getLoginID());
            string strStart = txtStart.Text.Trim();
            string strEnd = txtEnd.Text.Trim();

            string strWhere = "IsOpend >=0";

            //strWhere += " AND (RecommendID = " + LoginUser.UserID + " OR RecommendPath LIKE '%" + LoginUser.RecommendPath + "-')";

            #region 会员编号姓名

            strWhere += " AND UserCode LIKE  '%" + this.txtUserCode.Value.Trim() + "%'";

            #endregion

            if (GetLanguage("LoginLable") == "en-us")
            {
                strStart = txtStartEn.Text.Trim();
                strEnd = txtEndEn.Text.Trim();
            }

            #region 开通时间
            if (strStart != "" && strEnd == "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OpenTime,120) >= '" + strStart + "'");
            }
            else if (strStart == "" && strEnd != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OpenTime,120) <= '" + strEnd + "'");
            }
            else if (strStart != "" && strEnd != "")
            {
                strWhere += string.Format(" AND Convert(nvarchar(10),OpenTime,120) BETWEEN '" + strStart + "' AND '" + strEnd + "'");
            }
            #endregion

            return strWhere;
        }

        private void BindData()
        {
            bind_repeater(userBLL.GetOpenList(GetWhere()), Repeater1, "OpenTime desc", tr1, AspNetPager1);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long UserID = long.Parse(e.CommandArgument.ToString());
            lgk.Model.tb_user model = userBLL.GetModel(UserID);
            if (model == null)
            {
                MessageBox.MyShow(this, "该会员已删除,无法再进行此操作!");
                return;
            }
            if (model.IsOpend ==2)
            {
                MessageBox.MyShow(this, "该会员已开通,无法再进行此操作!");
                return;
            }
            if (userBLL.Delete(UserID))
            {
                MessageBox.MyShow(this, "删除成功!");
                BindData();
            }
            else
            {
                MessageBox.MyShow(this, "删除失败!");
            }
        }
    }
}