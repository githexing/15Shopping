using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using DataAccess;

namespace Library
{
    /// <summary>
    /// PageBase 的摘要说明
    /// </summary>
    public class PageCore : AllCore
    {
        public UserInfo uinfo;
        public lgk.Model.tb_user LoginUser { get; set; }
        public lgk.Model.tb_agent Loginagent { get; set; }
        public lgk.Model.tb_agent1 Loginagent1 { get; set; }
        public string Language { get; set; }
        public PageCore()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        //public int PermissionID = -1;//默认无限制
        public int UserType = 1;//用户所属的用户表
        /// <summary>
        /// 重写页面初始化事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            //继续执行页面初始化事件
            base.OnInit(e);
            //在页面Page_Load事件后执行页面权限检查
            this.PreLoad += new System.EventHandler(PageBase_Load);
            //在页面出错事件后执行错误记录
            this.Error += new System.EventHandler(PageBase_Error);

        }
        /// <summary>
        /// 在页面Page_Load事件执行结束后执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageBase_Load(object sender, System.EventArgs e)
        {
            //结算系统和网站共用域名,当前根目录被移到/jsxt下
            string strNewUrl = Request.Url.ToString().Replace("/user/finance/", "/").Replace("/user/business/", "/").Replace("/user/Info/", "/").Replace("/user/member/", "/").Replace("/user/team/", "/").Replace("/user/product/", "/").Replace("/user/shop/", "/").Replace("/user/Cash/", "/").Replace("/user/Mall/", "/").Replace("/user/", "/");//取得当前的外网
            strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径
            //检测Session["User"] 是否存在，如果存在，把它转换成UserInfo类，如果不存在，初始化一个UserInfo类，并存储到Session["User"]

            if (Request.Cookies["A128076_user"] == null)
            {
                Response.Write("<script>alert('请登录！');window.top.location='" + strNewUrl + "Login.aspx'</script>");
                Response.End();
            }
            LoginUser = userBLL.GetModel(getLoginID());
            if(LoginUser == null)
            {
                Response.Write("<script>alert('请登录！');window.top.location='" + strNewUrl + "Login.aspx'</script>");
                Response.End();
            }
            Loginagent = new lgk.BLL.tb_agent().GetModel(LoginUser == null ? " userid=0" : ("  userid =" + LoginUser.UserID));
            Loginagent1 = new lgk.BLL.tb_agent1().GetModel(LoginUser == null ? " userid=0" : ("  userid =" + LoginUser.UserID));
            Language = Request.Cookies["Culture"].Value==null?"zh-cn":Request.Cookies["Culture"].Value;
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

        /// <summary>
        /// 前台开通会员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int OpenCheckFront(lgk.Model.tb_user model)
        {
            int iFalg = 0;
            decimal regMoney = 0;
            lgk.Model.tb_user userInfo = new lgk.Model.tb_user();
            regMoney = getParamAmount("Level" + model.LevelID) * getParamAmount("billMoney"); //注册金额
            userInfo = userBLL.GetModel(getLoginID());//服务网点实体
            //if (model.IsReport == 1)//使用报单币注册
            //{
            //    lgk.Model.tb_user recommendInfo = userBLL.GetModel(model.RecommendID);

            //    if (Convert.ToDecimal(userInfo.BankAccount) > regMoney / 2 && Convert.ToDecimal(recommendInfo.BankAccount) > regMoney / 2)
            //    {
            //        recommendInfo.Emoney = recommendInfo.Emoney - regMoney / 2;//使用注册币支付一半的注册费
            //        userInfo.BankAccount = (Convert.ToDecimal(userInfo.BankAccount) - regMoney).ToString();//使用金钱支付一半的注册费

            //        if (userBLL.Update(userInfo) && userBLL.Update(recommendInfo))
            //        {
            //            //加入流水账表扣除注册币
            //            lgk.Model.tb_journal data = new lgk.Model.tb_journal();

            //            data.Remark = "开通会员" + model.UserCode;
            //            data.RemarkEn = "open user " + model.UserCode;
            //            data.InAmount = 0;
            //            data.OutAmount = regMoney;
            //            data.BalanceAmount = userInfo.Emoney;
            //            data.JournalDate = DateTime.Now;
            //            data.JournalType = 2;
            //            data.TakeType = 3;
            //            data.Journal01 = int.Parse(model.UserID.ToString());

            //            data.UserID = int.Parse(userInfo.UserID.ToString());
            //            journalBLL.Add(data);

            //            data.UserID = int.Parse(recommendInfo.UserID.ToString());
            //            journalBLL.Add(data);
            //        }
            //        else
            //        {
            //            iFalg = 1;
            //        }

            //        UpdateSystemAccount("MoneyAccount", regMoney, 1);
            //    }
            //    else
            //        iFalg = 2;
            //}
            //if (model.IsReport == 0)
            //{
            if (Convert.ToDecimal(userInfo.BonusAccount) >= regMoney)
            {
                userInfo.BonusAccount = Convert.ToDecimal(userInfo.BonusAccount) - regMoney;
                if (userBLL.Update(userInfo))
                {
                    //加入流水账表扣除E币
                    lgk.Model.tb_journal data = new lgk.Model.tb_journal();
                    data.UserID = int.Parse(userInfo.UserID.ToString());
                    data.Remark = "开通会员" + model.UserCode;
                    data.RemarkEn = "open user " + model.UserCode;
                    data.InAmount = 0;
                    data.OutAmount = regMoney;
                    data.BalanceAmount = Convert.ToDecimal(userInfo.BonusAccount);
                    data.JournalDate = DateTime.Now;
                    data.JournalType = 1;
                    data.Journal01 = int.Parse(model.UserID.ToString());
                    journalBLL.Add(data);
                }
                else
                {
                    iFalg = 1;
                }

                //UpdateSystemAccount("MoneyAccount", regMoney, 1);
            }
            else 
            {
                iFalg = 2;
            }
            return iFalg;
        }


        /// <summary>
        /// 获取当前登录代理商ID
        /// </summary>
        /// <returns></returns>
        //public int getLoginID()
        //{
        //    if (Request.Cookies["a128012user_zzh"] != null)
        //    {
        //        return Convert.ToInt32(Request.Cookies["a128012user_zzh"]["Id"]);
        //    }
        //    else
        //    {
        //        if (Request.Cookies["a128012user"] != null)
        //        {
        //            return Convert.ToInt32(Request.Cookies["a128012user"]["Id"]);
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
            
        //}

        /// <summary>
        /// 在页面出错之后执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PageBase_Error(object sender, System.EventArgs e)
        {
            //结算系统和网站共用域名,当前根目录被移到/jsxt下
            //string strNewUrl = Request.Url.ToString().ToLower().Replace("/user/", "/").Replace("/user/finance/", "/").Replace("/user/business/", "/").Replace("/user/Info/", "/").Replace("/user/member/", "/").Replace("/user/team/", "/").Replace("/user/licai/", "/");//取得当前的外网
            //strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径
            //Response.Write("<script>window.top.location='" + strNewUrl + "Error.aspx'</script>");
            //Response.End();
            //string strError = Request.Url.ToString();
            //Response.Redirect(strError);
            //Response.Redirect(strNewUrl + "Error.aspx");
            //结算系统和网站共用域名,当前根目录被移到/jsxt下
            string strNewUrl = Request.Url.ToString().Replace("/user/finance/", "/").Replace("/user/business/", "/").Replace("/user/Info/", "/").Replace("/user/member/", "/").Replace("/user/team/", "/").Replace("/user/product/", "/").Replace("/user/shop/", "/").Replace("/user/", "/");//取得当前的外网
            strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径
            //检测Session["User"] 是否存在，如果存在，把它转换成UserInfo类，如果不存在，初始化一个UserInfo类，并存储到Session["User"]

            //Response.Redirect(strNewUrl + "Error.aspx");

        }

        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpRequestValidationException)
            {
                ////结算系统和网站共用域名,当前根目录被移到/jsxt下
                //string strNewUrl = Request.Url.ToString().ToLower().Replace("/user/", "/").Replace("/user/finance/", "/").Replace("/user/business/", "/").Replace("/user/Info/", "/").Replace("/user/member/", "/").Replace("/user/team/", "/").Replace("/user/licai/", "/");//取得当前的外网
                //strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径
                //Response.Redirect(strNewUrl + "Error.aspx?type=1");
                //结算系统和网站共用域名,当前根目录被移到/jsxt下
                string strNewUrl = Request.Url.ToString().Replace("/user/finance/", "/").Replace("/user/business/", "/").Replace("/user/Info/", "/").Replace("/user/member/", "/").Replace("/user/team/", "/").Replace("/user/product/", "/").Replace("/user/shop/", "/").Replace("/user/", "/");//取得当前的外网
                strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径
                //检测Session["User"] 是否存在，如果存在，把它转换成UserInfo类，如果不存在，初始化一个UserInfo类，并存储到Session["User"]

                //Response.Redirect(strNewUrl + "Error.aspx?type=1");
            }
        }
        new public System.Type GetType()
        {
            return Page.GetType();
        }

        public string setp()
        {
            string s = System.Net.Dns.GetHostName();
            System.Net.IPAddress[] p = System.Net.Dns.GetHostEntry(s).AddressList;
            return p[0].ToString();
        }
        private bool GetIsWebOpen()
        {
            return true;
        }
    }

}