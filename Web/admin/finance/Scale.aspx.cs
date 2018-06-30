using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.admin.finance
{
    public partial class Scale : AdminPageBase
    {
        public string AllIn = string.Empty;
        public string AllOut = string.Empty;
        public string AllScale = string.Empty;
        public string In = string.Empty;
        public string Out = string.Empty;
        public string Scal = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsCallback)
            {
                DataBing();
            }
        }
        private void DataBing()
        {
            decimal zsr = userBLL.CountRegMoney(" UserID!=1 ");//总收入
            decimal zzc = bonusBLL.CountAmount("");//总支出
            decimal zbl = 0;
            if (zzc > 0)
            {
                zbl=( zzc/zsr) * 100;
            }

            AllIn = zsr.ToString();
            AllOut = zzc.ToString();
            AllScale = Format(double.Parse(zbl.ToString()))+"%";

            string time = this.txtChuStar.Text.Trim();
            string strWhere = " UserID!=1";
            string strWhere2 = "";
            if (!string.IsNullOrEmpty(time))
            {
                strWhere += " and CONVERT(NVARCHAR(100),OrderDate,23)='" + time+"'";
                strWhere2 += " CONVERT(NVARCHAR(100),AddTime,23)='"+time+"'";
                decimal inMoney = userBLL.CountRegMoney(strWhere);//收入
                decimal outMoney = bonusBLL.CountAmount(strWhere2);//支出
                decimal scaled = 0;
                if (outMoney > 0)
                {
                    scaled = (outMoney / inMoney ) * 100;
                }

                In = inMoney.ToString();
                Out = outMoney.ToString();
                Scal = Format(double.Parse(scaled.ToString())) + "%";
            }
        }

        protected void btnChuSearch_Click(object sender, EventArgs e)
        {
            DataBing();
        }

        /// <summary>
        /// 格式化保留两位小数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Format(double d)
        {
            return d.ToString("0.00");
        }

    }
}