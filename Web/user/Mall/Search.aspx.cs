using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.Mall
{
    public partial class Search : AllCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (getLoginID() > 0)
                {
                    BindData();
                }
            }
        }

        public void BindData()
        {
            //DataSet ds = searchRecordBLL.GetList(50, "UserID=" + getLoginID(), " AddTime desc ");
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    rpSearchList.DataSource = ds;
            //    rpSearchList.DataBind();
            //    Button1.Visible = true;
            //}
            //else
            //{
            //    Button1.Visible = false;
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //string strSearch = SafeHelper.NoHtml(txtSearch.Value.TrimEnd());
            //if (string.IsNullOrEmpty(strSearch))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('请输入您要搜索的内容');", true);//
            //    return;
            //}
            //if (getLoginID() > 0)
            //{
            //    lgk.Model.tb_searchRecord searchModel = new lgk.Model.tb_searchRecord();
            //    searchModel.UserID = getLoginID();
            //    searchModel.SearchContext = strSearch;
            //    searchModel.AddTime = DateTime.Now;
                
            //    searchRecordBLL.Add(searchModel);
            //}
            //Response.Redirect("ItemList.aspx?st=" + strSearch);
        }

        /// <summary>
        /// 获取当前登录代理商ID
        /// </summary>
        /// <returns></returns>
        public long getLoginID()
        {
            if (System.Web.HttpContext.Current.Request.Cookies["A128076_user"] != null)
            {
                return Convert.ToInt64(System.Web.HttpContext.Current.Request.Cookies["A128076_user"]["Id"]);
            }
            else
            {
                return 0;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //int iCount = searchRecordBLL.GetCount(" UserID=" + getLoginID());
            //if (iCount > 0)
            //{
            //    if (searchRecordBLL.DeleteByUserID(getLoginID()))
            //    {
            //        BindData();
            //    }
            //}
        }

    }
}