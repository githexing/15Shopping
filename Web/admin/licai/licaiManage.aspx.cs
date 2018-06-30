/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-20 11:23:51 
 * 文 件 名：		licaiManage.cs 
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
using System.Data;
using DataAccess;
using System.Web.UI.HtmlControls;
using Library;

namespace Web.admin.licai
{
    public partial class licaiManage : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        /// <summary>
        /// 根据搜索条件进行绑定
        /// </summary>
        private void bind()
        {
            Label1.Text = DbHelperSQL.GetSingle("select sum(StockAccount) from tb_user where isopend<>0").ToString();
            Label2.Text = DbHelperSQL.GetSingle("select sum(StockMoney) from tb_user where isopend<>0").ToString();
            string strWhere = string.Format("  IsOpend<>0");
            if (this.textUserCode.Value != "")
            {
                strWhere += " and UserCode like '%" + this.textUserCode.Value.Trim() + "%'";
            }
            if (this.txtStockAccount.Value!="")
            {
                strWhere += " and StockAccount>=" + Convert.ToDecimal(txtStockAccount.Value);
            }
            //if (txtDmoney.Value != "")
            //{
            //    strWhere += " and Dmoney>=" + Convert.ToDecimal(txtDmoney.Value);
            //}
            if (this.txtIDcord.Value != "")
            {
                strWhere += " and IdenCode like '%" + this.txtIDcord.Value.Trim() + "%'";
            }
            bind_repeater(userBLL.GetList(strWhere), Repeater1, "StockAccount desc", trBonusNull, AspNetPager1);
        }
        protected string getLevel(int LevelID)
        {
            return levelBLL.GetModel(LevelID).LevelName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }

        protected void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)Repeater1.Items[i].FindControl("CheckBoxIn");
                chk.Checked = ckAll.Checked;
            }
        }
        /// <summary>
        /// 锁定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            bool succeed = true;
            string strID = "";
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)Repeater1.Items[i].FindControl("CheckBoxIn");
                if (chk.Checked == true)
                {
                    strID += chk.Value;
                    strID += ",";
                }
            }
            if (strID.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('没有可锁定的用户!');", true);
                return;
            }
            strID = strID.Substring(0, strID.Length - 1);
            string[] array = strID.Split(',');
            for (int i = 0; i < array.Length; i++)
            {

                if (UpdateState(Convert.ToInt32(array[i]), 1) < 1)
                {
                    succeed = false;
                    break;
                }
            }
            if (succeed)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('锁定成功！');window.location.href='licaiManage.aspx'", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('锁定失败!');", true);
            }
        }
        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            bool succeed = true;
            string strID = "";
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                HtmlInputCheckBox chk = (HtmlInputCheckBox)Repeater1.Items[i].FindControl("CheckBoxIn");
                if (chk.Checked == true)
                {
                    strID += chk.Value;
                    strID += ",";
                }
            }
            if (strID.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('没有可解锁的用户!');", true);
                return;
            }
            strID = strID.Substring(0, strID.Length - 1);
            string[] array = strID.Split(',');
            for (int i = 0; i < array.Length; i++)
            {

                if (UpdateState(Convert.ToInt32(array[i]), 0) < 1)
                {
                    succeed = false;
                    break;
                }
            }
            if (succeed)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('解锁成功！');window.location.href='licaiManage.aspx'", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('解锁失败!');", true);
            }
        }
    }
}
