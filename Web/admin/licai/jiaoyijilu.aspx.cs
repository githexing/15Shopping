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
using DataAccess;

namespace Web.admin.licai
{
    public partial class jiaoyijilu : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindMyDai();
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_buy.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_sell.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("jiaoyijilu.aspx");
        }
        /// <summary>
        /// 我的待交易记录
        /// </summary>
        private void bindMyDai()
        {
            string StarTime = this.txtDaiStar.Text.Trim();
            string EndTime = this.txtDaiEnd.Text.Trim();
            string strWhere = string.Format("  status = 1 and UserType=2");
            //if (this.txtDaiCode.Value != "")
            //{
            //    strWhere += " and UserCode like '%" + this.txtDaiCode.Value.Trim() + "%'";
            //}
            if (StarTime != "" && EndTime == "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),BusinessTime,120)  >= '" + StarTime + "' ");
            }
            else if (StarTime == "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),BusinessTime,120)  <= '" + EndTime + "' ");
            }
            else if (StarTime != "" && EndTime != "")
            {
                strWhere += string.Format(" and Convert(nvarchar(10),BusinessTime,120)  between '" + StarTime + "' and '" + EndTime + "' ");
            }
            bind_repeater(gp_notesBLL.GetList(strWhere), Repeater3, "BusinessTime desc", tr3, AspNetPager3);
        }
        protected string getType(int BusinessType)
        {
            if (BusinessType==2)
            {
                return "买入交易";
            }
            return "卖出交易";
        }

        protected void btnDai_Click(object sender, EventArgs e)
        {
            bindMyDai();
        }

        protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        {
            bindMyDai();
        }

        protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            lgk.Model.gp_BusinessNotes model = gp_notesBLL.GetModel(ID);
            if (model == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('已撤单,无法再进行此操作！');window.location.href='jiaoyijilu.aspx'", true);
            }
            else
            {
                if (e.CommandName.Equals("Open"))//
                {
                    model.Status = 4;
                    if (model.BusinessType == 1)
                    {
                        int siid = Convert.ToInt32(DbHelperSQL.GetSingle("select  top 1 ID from gp_StockIssue  where SurplusAmount>0 order by AddTime asc"));
                        if (gp_notesBLL.Update(model) && gp_opBLL.UpdateSurplusAmount(siid, Convert.ToDecimal(model.BusinessAmount), 1) > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('撤单成功!');", true);
                        }
                    }
                    else
                    {
                        //if (gp_notesBLL.Update(model) && UpdateSystemAccount(Convert.ToDecimal(model.SumMoney),1) > 0)
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('撤单成功!');", true);
                        //}
                    }
                    bindMyDai();
                }
            }
        }
    }
}
