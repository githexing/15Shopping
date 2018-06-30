using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class help : AllCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindData();

               
            }
        }
        /// <summary>
        /// 填充数据
        /// </summary>
        protected void BindData()
        {
          
            lgk.Model.tb_news newInfo = newsBLL.GetModelList("NewType=3").OrderByDescending(s=>s.PublishTime).FirstOrDefault();
            if (newInfo != null)
            {
               // ltTitle.Text = newInfo.NewsTitle;
                ltContent.Text = newInfo.NewsContent;
            }
        }

    }
}
