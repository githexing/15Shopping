using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user.member
{
    public partial class GetCalcPower : PageCore
    {
        public static int A { get; set; } = 0;
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(sconn);
                conn.Open();
                string sql = string.Format("select * from tb_Ready_Rand where JoinDate >= convert( datetime,  convert(varchar(10),GETDATE(),120) + ' 00:00:00' )  and TuiJian_QianDao=2 ;");
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                if (dt.Rows.Count == 0)
                {
                    A = 1;
                }

                DataInit();
            }

        }
        private void DataInit()
        {
            string strNewUrl = Request.Url.ToString().Replace("/user/finance/", "/").Replace("/user/business/", "/").Replace("/user/Info/", "/").Replace("/user/member/", "/").Replace("/user/team/", "/").Replace("/user/product/", "/").Replace("/user/shop/", "/").Replace("/user/", "/");//取得当前的外网
            strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径
            rem_url = strNewUrl + "user/LinkRegist.aspx?i=" + LoginUser.UserID;
        }

        public string rem_url = "";
    }
}