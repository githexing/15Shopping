using System;
using System.Text;


namespace Web.user.finance
{
    public partial class redirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //提交地址
            string form_url;

            form_url = "https://shenghuo.alipay.com/send/payment/fill.htm"; // 

            //交易账户号
            string AlipayAccount = Request.Form["optEmail"];

            //商户证书：登陆商户后台下载的商户证书内容
            string PayAmount = Request.Form["payAmount"];

            long userid = Convert.ToInt64(Request.Form["userid"]);

            Random rand = new Random();
            string out_trade_no = DateTime.Now.ToString("yyyyMMddhhmmss") + rand.Next(10000, 99999);


            Recharge(out_trade_no, Convert.ToDecimal(PayAmount), userid);
            //商户订单编号
            // string out_trade_no = Request.Form["out_trade_no"];

            //订单备注 
            string memo = Request.Form["memo"];
            //Encoding gbk =Encoding.GetEncoding("gbk");
            //Encoding utf8 = Encoding.GetEncoding("utf-8");


            //byte[] utf8b= utf8.GetBytes(memo);
            ////关键也就是这句了
            //byte[] gbkb= Encoding.Convert(utf8,gbk,utf8b);

            //string strGBK = gbk.GetString(gbkb);

            //memo = strGBK;

            string postForm = "<form name=\"frm1\" id=\"frm1\" method=\"post\" action=\"" + form_url + "\">";

            postForm += "<input type=\"hidden\" name=\"optEmail\" value=\"" + AlipayAccount + "\" />";
            postForm += "<input type=\"hidden\" name=\"payAmount\" value=\"" + PayAmount + "\" />";
            postForm += "<input type=\"hidden\" name=\"title\" value=\"" + out_trade_no + "\" />";
            postForm += "<input type=\"hidden\" name=\"memo\" value=\"" + memo + "\" />";

            postForm += "</form>";

            //自动提交该表单到测试网关
            postForm += "<script type=\"text/javascript\" language=\"javascript\">setTimeout(\"document.getElementById('frm1').submit();\",100);</script>";

            Response.Write(postForm);
        }

        public long Recharge(string trade_no, decimal PayAmount, long userid)
        {
            lgk.Model.tb_recharge recharge = new lgk.Model.tb_recharge();
            recharge.UserID = userid;
            recharge.RechargeableMoney = Convert.ToDecimal(PayAmount);
            recharge.RechargeStyle = 1;  // 1:"增加" : 2:"减少"
            recharge.RechargeType = 1; //1: "电子币" : 2:"金币"
            recharge.Recharge001 = 2; //1：后台；2：支付宝
            recharge.Flag = 0;// 充值状态
            recharge.RechargeDate = DateTime.Now;
            recharge.Recharge003 = trade_no;//订单编号
            long id = new lgk.BLL.tb_recharge().Add(recharge);
            return id;
        }
    }
}