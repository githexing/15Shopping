using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;


namespace Web.admin.business
{
    public partial class XMemberList : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 10, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                BindData();
            }
        }


        /// <summary>
        ///已开通查询条件
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string strRegStart = this.txtRegStart.Text.Trim();
            string strRegEnd = txtRegEnd.Text.Trim();
            string strWhere = "id<>1";
            if (txtInput.Value != "")
            {
                if (userBLL.GetModel("usercode='" + txtInput.Value + "'") == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('这个会员帐号不存在');", true);
                }
                else
                {
                    strWhere += string.Format(" and UserID=" + userBLL.GetModel("usercode='" + txtInput.Value + "'").UserID);
                }
            }

            #region 注册时间
            if (strRegStart != "" && strRegEnd == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),AddDate,120)  >= '" + strRegStart + "'");
            }
            else if (strRegStart == "" && strRegEnd != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),AddDate,120)  <= '" + strRegEnd + "'");
            }
            else if (strRegStart != "" && strRegEnd != "")
            {
                strWhere += string.Format(" and  Convert(nvarchar(10),AddDate,120)  between '" + strRegStart + "' and '" + strRegEnd + "'");
            }
            #endregion

            return strWhere;
        }

        /// <summary>
        /// 绑定已开通会员列表
        /// </summary>
        private void BindData()
        {
            bind_repeater(userMaleBLL.GetList(GetWhere()), Repeater1, "AddDate desc", tr1, AspNetPager1);
        }

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

        protected string getmodel(int id)
        {
            string str = "";
            str = userBLL.GetModel(id).UserCode;
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
    }
}