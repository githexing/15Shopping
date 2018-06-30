/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-2-3 16:15:30 
 * 文 件 名：		AllCore.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		卢夏群
 * 文件版本：		1.0
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using System.Web.UI.HtmlControls;
using System.Drawing;
using DataAccess;
using System.Net.Mail;
using System.Net;
using System.Linq;
using System.Xml.Linq;
using Library;
using System.Data.SqlClient;

namespace Library
{
    public class AllCore : System.Web.UI.Page
    {
        private readonly lgk.DAL.tb_flag dal = new lgk.DAL.tb_flag();
        private readonly lgk.DAL.tb_userRecord daluRe = new lgk.DAL.tb_userRecord();
        private readonly lgk.DAL.tb_leaveMsg lm = new lgk.DAL.tb_leaveMsg();

        public string lang = "zh-cn";
        public lgk.BLL.tb_flag flagBLL = new lgk.BLL.tb_flag();
        public lgk.BLL.tb_user userBLL = new lgk.BLL.tb_user();
        public lgk.BLL.tb_userPro proBLL = new lgk.BLL.tb_userPro();
        public lgk.BLL.tb_Address addressBLL = new lgk.BLL.tb_Address();
        public lgk.BLL.tb_wealth wealthBLL = new lgk.BLL.tb_wealth();
        public lgk.BLL.tb_takeMoney takeBLL = new lgk.BLL.tb_takeMoney();
        public lgk.BLL.tb_remit remitBLL = new lgk.BLL.tb_remit();
        public lgk.BLL.tb_recharge rechargeBLL = new lgk.BLL.tb_recharge();
        public lgk.BLL.tb_serviceQQ qqBLL = new lgk.BLL.tb_serviceQQ();
        public lgk.BLL.tb_news newsBLL = new lgk.BLL.tb_news();
        public lgk.BLL.tb_level levelBLL = new lgk.BLL.tb_level();
        public lgk.BLL.tb_leaveReMsg leaveReMsgBLL = new lgk.BLL.tb_leaveReMsg();
        public lgk.BLL.tb_leaveMsg leaveMsgBLL = new lgk.BLL.tb_leaveMsg();
        public lgk.BLL.tb_journal journalBLL = new lgk.BLL.tb_journal();
        public lgk.BLL.tb_globeParam paramBLL = new lgk.BLL.tb_globeParam();
        public lgk.BLL.tb_change changeBLL = new lgk.BLL.tb_change();
        public lgk.BLL.tb_bonus bonusBLL = new lgk.BLL.tb_bonus();
        public lgk.BLL.tb_bonusType bonusTypeBLL = new lgk.BLL.tb_bonusType();
        public lgk.BLL.tb_admin adminBLL = new lgk.BLL.tb_admin();
        public lgk.BLL.tb_agent agentBLL = new lgk.BLL.tb_agent();
        public lgk.BLL.tb_agent1 agent1BLL = new lgk.BLL.tb_agent1();
        public lgk.BLL.tb_systemMoney smoneyBLL = new lgk.BLL.tb_systemMoney();
        public lgk.BLL.BonusOperationBLL bo = new lgk.BLL.BonusOperationBLL();

        public lgk.BLL.tb_systemBank bankBLL = new lgk.BLL.tb_systemBank();
        public lgk.BLL.tb_bankName banknameBLL = new lgk.BLL.tb_bankName();
        public lgk.BLL.tb_setSystem setBLL = new lgk.BLL.tb_setSystem();
        public lgk.BLL.SecondPasswordBLL76 spd = new lgk.BLL.SecondPasswordBLL76();
        public lgk.BLL.tb_mix mixBLL = new lgk.BLL.tb_mix();
        public lgk.BLL.tb_power info_prower = new lgk.BLL.tb_power();
        public lgk.BLL.tb_goods goodsBLL = new lgk.BLL.tb_goods();
        public lgk.BLL.tb_goodsCar goodsCarBLL = new lgk.BLL.tb_goodsCar();
        public lgk.BLL.tb_Order orderBLL = new lgk.BLL.tb_Order();
        public lgk.BLL.tb_OrderDetail orderDetailBLL = new lgk.BLL.tb_OrderDetail();
        public lgk.BLL.tb_produceType produceTypeBLL = new lgk.BLL.tb_produceType();
        public lgk.BLL.tb_Security securityBLL = new lgk.BLL.tb_Security();
        public lgk.BLL.tb_UserMale userMaleBLL = new lgk.BLL.tb_UserMale();

        public lgk.BLL.gp_BusinessNotes gp_notesBLL = new lgk.BLL.gp_BusinessNotes();
        public lgk.BLL.gp_StockIssue gp_issueBLL = new lgk.BLL.gp_StockIssue();
        public lgk.BLL.gp_globeParam gpBLL = new lgk.BLL.gp_globeParam();
        public lgk.BLL.gp_StockPrice gp_priceBLL = new lgk.BLL.gp_StockPrice();
        public lgk.BLL.gp_operation gp_opBLL = new lgk.BLL.gp_operation();
        public lgk.BLL.gp_SplitStockManage gp_ssBLL = new lgk.BLL.gp_SplitStockManage();
        public lgk.BLL.gp_BusinessAmount gp_amountBLL = new lgk.BLL.gp_BusinessAmount();
        public lgk.BLL.tb_Salesroom tb_SalesroomBll = new lgk.BLL.tb_Salesroom();
        public lgk.BLL.tb_Auction auctionBll = new lgk.BLL.tb_Auction();
        public lgk.BLL.tb_message messageBLL = new lgk.BLL.tb_message();

        public lgk.BLL.tb_StockBuy stockBuyBLL = new lgk.BLL.tb_StockBuy();
        public lgk.BLL.tb_Stock stockBLL = new lgk.BLL.tb_Stock();
        public lgk.BLL.tb_StockDetail stockDetailBLL = new lgk.BLL.tb_StockDetail();
        public lgk.BLL.tb_StockIssue stockIssueBLL = new lgk.BLL.tb_StockIssue();
        public lgk.BLL.tb_StockSplit stockSplitBLL = new lgk.BLL.tb_StockSplit();
        public lgk.BLL.tb_StockSplitDetail stockSplitDetailBLL = new lgk.BLL.tb_StockSplitDetail();
        public lgk.BLL.StockBonus stockBonusBLL = new lgk.BLL.StockBonus();

        //public lgk.BLL.tb_StockMode tb_stockModeBLL = new lgk.BLL.tb_StockMode();

        public lgk.BLL.Cashbuy cashbuyBLL = new lgk.BLL.Cashbuy();
        public lgk.BLL.Cashsell cashsellBLL = new lgk.BLL.Cashsell();
        public lgk.BLL.Cashorder cashorderBLL = new lgk.BLL.Cashorder();
        public lgk.BLL.Cashcredit cashcreditBLL = new lgk.BLL.Cashcredit();
        public lgk.BLL.CashManage cashmanageBLL = new lgk.BLL.CashManage();

        public lgk.BLL.tb_Stockorder stockorderBLL = new lgk.BLL.tb_Stockorder();
        public lgk.BLL.tb_Purchase purchaseBLL = new lgk.BLL.tb_Purchase();
        public lgk.BLL.tb_systemMoney systemBll = new lgk.BLL.tb_systemMoney();

        public lgk.BLL.tb_province provinceBLL = new lgk.BLL.tb_province();
        public lgk.BLL.tb_city cityBLL = new lgk.BLL.tb_city();
        public lgk.BLL.tb_area areaBLL = new lgk.BLL.tb_area();

        public lgk.BLL.tb_UserOrder userOrderBLL = new lgk.BLL.tb_UserOrder();
        public lgk.BLL.tb_UserOrderDetail userOrderDetailBLL = new lgk.BLL.tb_UserOrderDetail();
        public lgk.BLL.SysLog sysLogBLL = new lgk.BLL.SysLog();
        public lgk.BLL.tb_UserBank userBankBLL = new lgk.BLL.tb_UserBank();
        public lgk.BLL.tb_IMFriend imFriendBLL = new lgk.BLL.tb_IMFriend();
        public lgk.BLL.tb_Link linkBLL = new lgk.BLL.tb_Link();
        public lgk.BLL.tb_FriendDynamic friendBLL = new lgk.BLL.tb_FriendDynamic();
        public lgk.BLL.tb_FriendDynamicComment friendDynamicCommenBLL = new lgk.BLL.tb_FriendDynamicComment();
        public lgk.BLL.tb_FriendDynamicGood FriendDynamicGoodBLL = new lgk.BLL.tb_FriendDynamicGood();

        public lgk.BLL.SMS smsBLL = new lgk.BLL.SMS();
        public lgk.BLL.tb_LoginToken logintokenBLL = new lgk.BLL.tb_LoginToken();
        public lgk.BLL.tb_SuanliJournal suanliJournalBLL = new lgk.BLL.tb_SuanliJournal();
        public lgk.BLL.tb_BuyMachine buymachineBLL = new lgk.BLL.tb_BuyMachine();
        public lgk.BLL.tb_TransferMachine transferMachineBLL = new lgk.BLL.tb_TransferMachine();
        public lgk.BLL.tb_LockPosition lockPositionBLL = new lgk.BLL.tb_LockPosition();
        public lgk.BLL.tb_MachineDetail machineDetailBLL = new lgk.BLL.tb_MachineDetail();

        public string currentCulture { get; set; }
        /// <summary>
        /// 检查是否拥有权限没有就跳转
        /// </summary>
        /// <param name="p">原始页面</param>
        /// <param name="id">权限编号</param>
        /// <param name="adminID">管理员ID</param>
        public void jumpMain(System.Web.UI.Page p, int id, int adminID)
        {
            bool isNot = true;
            string[] limits = adminBLL.GetModel(adminID).Limits.Split(',');
            for (int i = 0; i < limits.Length; i++)
            {
                if (id.ToString() == limits[i])
                {
                    isNot = false;
                    break;
                }
            }
            if (isNot)
            {
                string _purl = p.Request.Url.ToString();
                string strNewUrl = _purl.ToString().Replace("/admin/business/", "/admin/").Replace("/admin/finance/", "/admin/").Replace("/admin/info/", "/admin/").Replace("/admin/licai/", "/admin/").Replace("/admin/product/", "/admin/").Replace("/admin/team/", "/admin/").Replace("/admin/system/", "/admin/");//取得当前的外网
                strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);
                p.Response.Redirect(strNewUrl + "index.aspx");
            }
        }
        /// <summary>
        /// 获得当天期权发布价格
        /// </summary>
        /// <returns></returns>
        public lgk.Model.gp_StockPrice gp_price()
        {
            return gp_priceBLL.GetModel(" Convert(nvarchar(10),BusinessTime,120)=Convert(nvarchar(10),getdate(),120)");
        }
        /// <summary>
        /// 会员待交易数量
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <param name="type">类型：1-待卖出  2-待买入</param>
        /// <returns></returns>
        public decimal get_dai(int userid, int type)
        {
            if (userid == 0) { return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(BusinessAmount,0)),0) from gp_BusinessNotes where BusinessType=" + type + " and Status=1 and UserType=2")); }
            else { return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(BusinessAmount,0)),0) from gp_BusinessNotes where BusinessType=" + type + " and Status=1 and UserType=1 and UserID=" + userid)); }
        }
        /// <summary>
        /// 获得锁定的期权数
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <param name="type">类型：1-买入锁定、配股锁定  2-拆期权锁定</param>
        /// <returns></returns>
        public decimal getLock(int userid, int type)
        {
            if (type == 1)
            {
                if (userid == 0) { return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(BusinessAmount,0)),0) from gp_BusinessNotes where BusinessType=2 and Status=3 and UserType=1 ")); }
                else { return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(BusinessAmount,0)),0) from gp_BusinessNotes where BusinessType=2 and Status=3 and UserType=1 and UserID=" + userid)); }
            }
            else
            {
                if (userid == 0) { return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(SplitSStock,0)),0) from gp_SplitStockManage where  Split06=0 and Split01=1")); }
                else { return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(SplitSStock,0)),0) from gp_SplitStockManage where  Split06=0 and Split01=1 and UserID=" + userid)); }
            }
        }
        /// <summary>
        /// 获得重消账户修改记录
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetCXList(string strWhere)
        {
            return dal.GetCXList(strWhere);
        }

        /// <summary>
        /// 总成交量
        /// </summary>
        /// <returns></returns>
        public decimal gp_allAmount()
        {
            return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(BusinessAmount,0)),0) from dbo.gp_BusinessNotes where BusinessType=1 and Status=2 "));
        }

        public int flag_fh(long iUserID)
        {
            return dal.flag_fh(iUserID);
        }
        /// <summary>
        /// 股票拆分
        /// </summary>
        /// <returns></returns>
        public bool StockSplit()
        {
            bool bFalg = false;
            decimal dSplitPriceL = getParamAmount("shares4");//原始股价
            decimal dSplitPriceB = getParamAmount("shares5");//当前股价
            decimal dSplitPrice = getParamAmount("shares6");//股票拆分价格(系统拆分价格)

            lgk.Model.tb_StockSplit model = new lgk.Model.tb_StockSplit();

            model.SplitPrice = dSplitPrice;
            model.SplitPriceB = dSplitPriceB;
            model.SplitPriceL = dSplitPriceL;
            model.SplitRate = getParamVarchar("shares7").Trim();
            model.SplitTimes = Convert.ToInt32(getParamAmount("shares8") + 1);
            model.SplitDate = DateTime.Now;

            if (dSplitPriceB == dSplitPrice)
            {
                model.SplitID = stockSplitBLL.Add(model);
                if (model.SplitID > 1)
                {
                    bFalg = stockSplitDetailBLL.SplitProcDetail(model);
                }
            }

            return bFalg;
        }

        /// <summary>
        /// 股票发行
        /// </summary>
        /// <returns></returns>
        public bool StockIssue()
        {
            bool bFalg = false;
            lgk.Model.tb_StockIssue model = new lgk.Model.tb_StockIssue();
            model.IssueAmount = getParamAmount("shares1");
            model.SurplusAmount = getParamAmount("shares1");
            model.IssuePrice = getParamAmount("shares4");
            model.Periods = Convert.ToInt32(getParamAmount("shares9") + 1);
            model.AddDate = DateTime.Now;
            model.IsSell = 1;

            stockIssueBLL.Update();
            int iIssueID = stockIssueBLL.Add(model);

            if (iIssueID > 0)
            {
                lgk.Model.tb_globeParam Param = paramBLL.GetModel("ParamName='shares9'");
                Param.ParamVarchar = model.Periods.ToString();
                paramBLL.Update(Param);

                bFalg = true;
            }
            else
            {
                bFalg = false;
            }

            return bFalg;
        }

        /// <summary>
        /// 录入股票明细表
        /// </summary>
        /// <param name="iStockID">主表编号</param>
        /// <param name="dAmount">购买金额</param>
        /// <param name="iNumber">购买数量</param>
        /// <returns></returns>
        public bool StockDetail(int iStockID, decimal dAmount, int iNumber)
        {
            bool bFalg = false;

            lgk.Model.tb_StockDetail stockDetailInfo = new lgk.Model.tb_StockDetail();
            if (iStockID > 0)
            {
                stockDetailInfo.StockID = iStockID;
                stockDetailInfo.Amount = dAmount;
                stockDetailInfo.Price = getParamAmount("shares5");
                stockDetailInfo.Number = iNumber;
                stockDetailInfo.Periods = Convert.ToInt32(getParamAmount("shares9"));
                stockDetailInfo.BuyDate = DateTime.Now;
                stockDetailBLL.Add(stockDetailInfo);
                bFalg = true;
            }
            else
            {
                bFalg = false;
            }

            return bFalg;
        }

        /// <summary>
        /// 股票价格上涨。
        /// </summary>
        /// <param name="dExtentPrice">上涨后股价</param>
        /// <returns></returns>
        public bool StockRise(decimal dExtentPrice)
        {
            lgk.Model.tb_globeParam paramInfo = paramBLL.GetModel("ParamName='shares5'");

            paramInfo.ParamVarchar = dExtentPrice.ToString();

            bool bFalg = paramBLL.Update(paramInfo);

            stockBLL.Proc_StockRise(dExtentPrice);

            return bFalg;
        }

        /// <summary>
        /// 语言初始化
        /// </summary>
        protected override void InitializeCulture()
        {

            currentCulture = "";
            if (Request.Cookies["Culture"] == null)
            {
                HttpCookie cookie = new HttpCookie("Culture");
                cookie.Value = "zh-cn";
                cookie.Expires = DateTime.MaxValue;
                Response.Cookies.Add(cookie);
                currentCulture = "zh-cn";
            }
            else
            { currentCulture = Request.Cookies["Culture"].Value.ToString(); }

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(currentCulture);
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(currentCulture);

        }

        /// <summary>
        /// 根据给定的键值，获取语言key的值。
        /// </summary>
        /// <param name="key">给定的键值</param>
        /// <returns></returns>
        public string GetLanguage(string key)
        {
            string lang = "zh-cn";//中文
            //if (HttpContext.Current.Request.Cookies["Culture"].Value.ToString() == "en-us")// (Request.Cookies["Culture"].Value == "en-us")
            //{
            //    lang = "en-us";//英语
            //}
            //else
            //{
            //    lang = "zh-cn";//中文
            //}
            XDocument doc = new XDocument();
            doc = XDocument.Load(Server.MapPath("~/language/lang.xml"));

            XElement xEle = doc.Descendants("key").SingleOrDefault(t => t.Attribute("name").Value.Equals(key));
            xEle = xEle.Descendants("langtype").SingleOrDefault(t => t.Attribute("name").Value.Equals(lang));
            if (xEle != null)
            {
                return xEle.Value;
            }
            try
            {
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// 拨出查询
        /// </summary>
        /// <returns></returns>
        public DataSet GetPayScale(string conditon)
        {
            return dal.GetPayScale(conditon);
        }

        /// <summary>
        /// 拨出比率每天
        /// </summary>
        /// <param name="where1">recordTime字段时间段查询</param>
        /// <param name="where2">AddTime字段时间段查询</param>
        /// <returns></returns>
        public DataSet GetPayScale(string where1, string where2)
        {
            return dal.GetPayScale(where1, where2);
        }

        /// <summary>
        /// 获得扣除特殊奖励记录
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public DataSet GetKouChu(string where)
        {
            return dal.GetKouChu(where);
        }

        /// <summary>
        /// 获得总收入
        /// </summary>
        /// <returns></returns>
        public decimal GetIncomeTotal()
        {
            return dal.GetIncomeTotal();
        }

        /// <summary>
        /// 获得总支出
        /// </summary>
        /// <returns></returns>
        public decimal GetPayTotal()
        {
            return dal.GetPayTotal();
        }

        /// <summary>
        /// 奖金结算
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="Bonus">奖金额</param>
        /// <param name="BonusType">奖金类型</param>
        /// <param name="State">奖金发放方式 （0为秒结日发 1为秒结秒发）</param>
        /// <param name="FromUserID">来自哪个会员</param>
        /// <returns></returns>
        public int AddBonus(int UserID, decimal Bonus, int BonusType, int State, int FromUserID)
        {
            return dal.AddBonus(UserID, Bonus, BonusType, State, FromUserID);
        }

        /// <summary>
        /// 注册添加用户
        /// </summary>
        /// <param name="IsAgent">注册类型：1-代理人 0-用户</param>
        /// <param name="UserCode">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="SecondPassword">二级密码</param>
        /// <param name="RecommendID">推荐人ID</param>
        /// <returns></returns>
        public int AddUser(int IsAgent, string UserCode, string Password, string SecondPassword, int RecommendID)
        {
            return dal.AddUser(IsAgent, UserCode, Password, SecondPassword, RecommendID);
        }
        /// <summary>
        /// 任务完成，结算奖金
        /// </summary>
        /// <param name="userid">接任务用户</param>
        /// <param name="fromID">发布任务代理人</param>
        /// <param name="yongjin">任务佣金</param>
        /// <param name="amount">2倍冻结金额</param>
        /// <param name="flagType">1-代理商确认  0-后台确认</param>
        /// <returns></returns>
        public int flag_Bonus(int userid, int fromID, decimal yongjin, decimal amount, int flagType)
        {
            return dal.flag_Bonus(userid, fromID, yongjin, amount, flagType);
        }

        /// <summary>
        /// 开通/晋升计算业绩、奖金
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <returns></returns>

        /// <summary>
        /// 开通指定会员编号的会员，2开通。
        /// </summary>
        /// <param name="userid">指定会员编号</param>
        /// <param name="iIsOpend">2开通</param>
        /// <returns></returns>
        public int flag_open(long iUserID, int iIsOpend)
        {
            return dal.flag_open(iUserID, iIsOpend);
        }
        /// <summary>
        /// 开通指定会员编号的会员 。
        /// </summary>
        /// <param name="NewUserID">指定会员编号</param>
        /// <param name="OpUserID"> </param>
        /// <returns></returns>
        public int flag_ActivationUser(long NewUserID, long OpUserID)
        {
            return dal.flag_ActivationUser(NewUserID, OpUserID);
        }
        /// <summary>
        /// 开通代理商
        /// </summary>
        /// <param name="id">代理商ID</param>
        /// <returns></returns>
        public int flag_openAgent(int id, int Alevel)
        {
            return dal.flag_openAgent(id, Alevel);
        }
        /// <summary>
        /// 删除会员，下线会员位置上移
        /// </summary>
        /// <param name="userid">要删除的会员ID</param>
        /// <returns></returns>
        public int flag_delete(long iUserID)
        {
            return dal.flag_delete(iUserID);
        }
        public bool flag_pro(int UserID, int typen)
        {
            return dal.flag_pro(UserID, typen);
        }
        /// <summary>
        /// 手动发放奖金
        /// </summary>
        /// <param name="type">奖金类型：1-互助奖  2-股东分红</param>
        /// <returns></returns>
        public int flag_send(int type)
        {
            return dal.flag_send(type);
        }
        /// <summary>
        /// 获取任务总数
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="tab">表</param>
        /// <returns></returns>
        public int GetTaskNum(string where, string tab)
        {
            return dal.GetTaskNum(where, tab);
        }
        /// <summary>
        /// 获取保险金额总数
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public int GetAllSafeAmount(string where)
        {
            return dal.GetAllSafeAmount(where);
        }
        /// <summary>
        /// 查询邮件数量
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public int GetMsgNum(string where)
        {
            string sql = "select count(*) from tb_leaveMsg where " + where;
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }
        public int get_yucheng(string where)
        {
            string sql = "select count(*) from tb_user where " + where;
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        /// 获取晋升记录数
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public int get_proNum(string where)
        {
            string sql = "select count(*) from tb_userPro where " + where;
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        /// 获取会员数量
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public int get_userNum(string where)
        {
            string sql = "select count(*) from tb_user where " + where;
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        /// 获得未发放的奖金额
        /// </summary>
        /// <param name="type">奖金类型：1-互助奖 2-股东分红</param>
        /// <returns></returns>
        public decimal get_bonusSum(int type)
        {
            string sql = "select isnull(sum(isnull(sf,0)),0) from tb_bonus where IsSettled=2 and TypeID=" + type;
            return Convert.ToDecimal(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        /// 获得注册的第一个代理商ID
        /// </summary>
        /// <returns></returns>
        public int getOneUserID()
        {
            return Convert.ToInt32(DbHelperSQL.GetSingle("select min(UserID) from tb_user where IsAgent=1 and UserID<>1"));
        }
        public string getnew()
        {
            return DbHelperSQL.GetSingle("select top 1 NewsContent from tb_news where NewType=2 order by id desc").ToString();
        }
        /// <summary>
        /// 获得推荐总PM
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public decimal get_PM(int UserID)
        {
            return Convert.ToDecimal(DbHelperSQL.GetSingle("select sum(isnull(ShopAccount,0)) from tb_user where RecommendID=" + UserID));
        }
        /// <summary>
        /// 添加数据到流水账表
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <param name="inamount">收入</param>
        /// <param name="outamount">支出</param>
        /// <param name="banlance">余额</param>
        /// <param name="jourtype">类型：1奖金，2-E币,3股金钱包</param>
        /// <param name="type">奖金类型</param>
        /// <param name="remark">业务摘要</param>
        /// <param name="fromID">来自哪个会员</param>
        /// <returns></returns>
        public int add_journal(long iUserID, decimal inamount, decimal outamount, decimal banlance, int jourtype, int type, string remark, string remarken, long iFromUserID)
        {
            return dal.add_journal(iUserID, inamount, outamount, banlance, jourtype, type, remark, remarken, iFromUserID);
        }

        public void SendMessage(int Userid, string MobileNum, string Mcontent)
        {
            Mcontent = GetLanguage("DearMembers") + Mcontent;
            try
            {
                string user = new lgk.BLL.tb_globeParam().GetModel(" ParamName='MessageName'").ParamVarchar;
                string pass = new lgk.BLL.tb_globeParam().GetModel(" ParamName='MessagePsw'").ParamVarchar;
                pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "MD5").ToLower();
                string url = " http://api.52ao.com/?user=" + user + "&pass=" + pass + "&mobile=" + MobileNum + "&content=";
                string content = "";
                System.Text.Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                content = HttpUtility.UrlEncode(Mcontent, encode);
                url += content + "&encode=utf-8";

                string result = string.Empty;
                if (user != null)
                { result = GetHtmlFromUrl(url); }
                string flag = "失败";
                if (result != null)
                {
                    switch (result)
                    {
                        case "200":
                            flag = "成功";
                            break;
                        case "101":
                            flag = "用户或密码错误";
                            break;
                        case "106":
                            flag = "剩余短信不足";
                            break;
                        case "110":
                            flag = "手机号码有误";
                            break;
                    }
                    string sql = string.Format(" INSERT INTO [dbo].[tb_message] ([Userid],[MobileNum],[Mcontent],[Flag])VALUES('{0}','{1}','{2}','{3}')", Userid, MobileNum, Mcontent, flag);
                    DbHelperSQL.GetSingle(sql);
                }
            }
            catch
            {

            }
        }

        public string GetHtmlFromUrl(string url)
        {
            string strRet = null;

            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                System.IO.Stream sr = hs.GetResponseStream();
                System.IO.StreamReader ser = new System.IO.StreamReader(sr, System.Text.Encoding.Default);
                strRet= ser.ReadToEnd();
            }
            catch (Exception  )
            {
                strRet = null;
            }
            return strRet;
        }
        /// <summary>
        /// 添加用户数据添加到用户记录表中
        /// </summary>
        /// <param name="Id">用户ID</param>
        /// <param name="recordName">用户名</param>
        /// <param name="recordTime">操作时间</param>
        /// <param name="reMoney">操作金额</param>
        /// <param name="reType">操作类型 1收入2支出</param>
        /// <returns></returns>
        public int add_userRecord(string recordName, DateTime recordTime, decimal reMoney, int reType)
        {
            lgk.Model.tb_userRecord model = new lgk.Model.tb_userRecord();
            model.recordName = recordName;
            model.recordTime = recordTime;
            model.reMoney = reMoney;
            model.reType = reType;
            return daluRe.Add(model);
        }
        /// <summary>
        /// 获得全球分红用户数据列表
        /// </summary>
        public DataSet GetBounsList(int TypeID)
        {
            return dal.GetBounsList(TypeID.ToString().Trim());
        }
        /// <summary>
        /// 更新买入，卖出股票操作权限
        /// </summary>
        /// <param name="id">会员ID</param>
        /// <param name="flag">1-锁定 0-解锁</param>
        /// <returns></returns>
        public int UpdateState(int id, int flag)
        {
            return dal.UpdateState(id, flag);
        }
        /// <summary>
        /// 获得动态参数（字符串）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string getParamVarchar(string str)
        {
            return DbHelperSQL.GetSingle("select ParamVarchar from tb_globeParam where ParamName='" + str + "'").ToString();
        }
        /// <summary>
        /// 获得动态参数（金额）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public decimal getParamAmount(string str)
        {
            return Convert.ToDecimal(DbHelperSQL.GetSingle("select ParamVarchar from tb_globeParam where ParamName='" + str + "'"));
        }

        /// <summary>
        /// 获得动态参数（整数）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int getParamInt(string str)
        {
            return Convert.ToInt32(DbHelperSQL.GetSingle("select ParamVarchar from tb_globeParam where ParamName='" + str + "'"));
        }

        /// <summary>
        /// 根据给定的条件，获取给定字段的值
        /// </summary>
        /// <param name="strFiledName">给定字段的值</param>
        /// <param name="strParamName">给定的条件</param>
        /// <returns></returns>
        public string getRemark(string strFiledName, string strParamName)
        {
            return DbHelperSQL.GetSingle("SELECT [" + strFiledName + "] FROM [tb_globeParam] WHERE [ParamName]='" + strParamName + "'").ToString();
        }

        /// <summary>
        /// 根据给定的条件和字段的值，更新给定的字段。
        /// </summary>
        /// <param name="strFiledName">要更新的字段</param>
        /// <param name="strValue">更新的值</param>
        /// <param name="strParamName">给定的条件</param>
        /// <returns></returns>
        public string UpdateParamVarchar(string strFiledName,string strValue, string strParamName)
        {
            return DbHelperSQL.ExecuteSql("UPDATE [tb_globeParam] SET [" + strFiledName + "]=" + strValue + " WHERE [ParamName]='" + strParamName + "'").ToString();
        }

        /// <summary>
        /// 获得股票动态参数（字符串）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string getGPVarchar(string str)
        {
            return DbHelperSQL.GetSingle("select ParamVarchar from gp_globeParam where ParamName='" + str + "'").ToString();
        }
        /// <summary>
        /// 获得股票动态参数（金额）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public decimal getGPAmount(string str)
        {
            return Convert.ToDecimal(DbHelperSQL.GetSingle("select ParamVarchar from gp_globeParam where ParamName='" + str + "'"));
        }

        /// <summary>
        /// 获得股票动态参数（整数）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int getGPInt(string str)
        {
            return Convert.ToInt32(DbHelperSQL.GetSingle("select ParamVarchar from gp_globeParam where ParamName='" + str + "'"));
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string getstring(string lang,string str, int length)
        {
            string[] list = str.Split('-');
            if (list != null && list.Length == 2)
            {
                if (lang == "zh-cn")
                {
                    str = list[0];
                }
                else
                {
                    str = list[1];
                }
            }
            return str.Length > length ? str.Substring(0, length) + "..." : str;
        }
        /// <summary>
        /// 获得request 参数值 Int类型
        /// </summary>
        /// <param name="key">参数名称</param>
        /// <returns></returns>
        protected int getIntRequest(string key)
        {
            try
            {
                return (Request.QueryString[key] == null || Request.QueryString[key] == "") ? 0 : Convert.ToInt32(Request.QueryString[key]);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// 获得request 参数值 Int类型
        /// </summary>
        /// <param name="key">参数名称</param>
        /// <returns></returns>
        protected long getLongRequest(string key)
        {
            try
            {
                return (Request.QueryString[key] == null || Request.QueryString[key] == "") ? 0 : Convert.ToInt64(Request.QueryString[key]);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// 判断是否有足够金额开通激活会员并扣除相应金额,1自己开通，2推荐人开通。
        /// </summary>
        /// <param name="model">待开通会员实体</param>
        /// <param name="iTypeID"></param>
        /// <returns></returns>
        public int OpenCheck(lgk.Model.tb_user model)
        {
            int flag = 0;
            decimal dRegMoney = model.RegMoney; //注册金额

            var userInfo = userBLL.GetModel(agentBLL.GetUserIDByAgentID(model.AgentsID));

            if (dRegMoney > 0)
            {
                if (userInfo.StockAccount >= dRegMoney)//现金币达到最低要求
                {
                    userInfo.StockAccount = userInfo.StockAccount - dRegMoney;
                    if (userBLL.Update(userInfo))
                    {
                        //加入流水账表扣除奖金币
                        lgk.Model.tb_journal data = new lgk.Model.tb_journal();
                        data.UserID = userInfo.UserID;
                        data.Remark = "开通" + model.UserCode;
                        data.RemarkEn = "open user " + model.UserCode;
                        data.InAmount = 0;
                        data.OutAmount = dRegMoney;
                        data.BalanceAmount = userInfo.StockAccount;
                        data.JournalDate = DateTime.Now;
                        data.JournalType = 5;
                        data.Journal01 = model.UserID;

                        journalBLL.Add(data);

                        UpdateSystemAccount("MoneyAccount", dRegMoney, 1);
                    }
                    else
                    {
                        flag = 1;
                    }
                }
                else
                {
                    flag = 2;
                }
            }
            
            return flag;
        }

        /// <summary>
        /// 判断是否有足够金额开通激活会员并扣除相应金额--错误信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string OpenCheckErrorMsg(int type)
        {
            string msg = "发生错误！";
            switch (type)
            {
                case 1: msg = GetLanguage("CurrencyFailure"); break;
                case 2: msg = GetLanguage("ShortageCash"); break;
            }
            return msg;
        }

        /// <summary>
        /// 新闻类型
        /// </summary>
        /// <param name="newType">类型编号</param>
        /// <returns></returns>
        public string NewType(int newType)
        {
            string typeName = string.Empty;
            switch (newType)
            {
                case 1: typeName = "公告"; break;
                case 2: typeName = "公告"; break;
                case 3: typeName = "购买导航"; break;
                case 4: typeName = "商家加盟"; break;
                case 5: typeName = "官方网站"; break;
                case 6: typeName = "联系我们"; break;
                case 7: typeName = "服务条款"; break;
                case 8: typeName = "最新活动"; break;

            }
            return typeName;
        }

        /// <summary>
        /// 根据新闻类型获取新闻编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetNewIDByNewType(int id)
        {
            string cnen = GetLanguage("LoginLable");
            int langType = cnen.Equals("zh-cn") ? 0 : 1;
            var news = newsBLL.GetModelByNewType(id,langType);
            int newId = 0;
            if (news != null)
            {
                int.TryParse(news.ID.ToString(), out newId);
            }
            return newId;
        }

        /// <summary>
        /// 获得request 参数值 Int类型
        /// </summary>
        /// <param name="key">参数名称</param>
        /// <returns></returns>
        protected int getParentIntRequest(string key)
        {
            try
            {
                return (this.Parent.Page.Request.QueryString[key] == null || this.Parent.Page.Request.QueryString[key] == "") ? 0 : Convert.ToInt32(this.Parent.Page.Request.QueryString[key]);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// 获得request 参数值 string类型
        /// </summary>
        /// <param name="key">参数名称</param>
        /// <returns></returns>
        public string getStringRequest(string key)
        {
            try
            {
                return (Request.QueryString[key] == null || Request.QueryString[key] == "") ? "" : Request.QueryString[key].ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
        #region 导出提现列表
        /// <summary>
        /// 导出提现列表
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ToTakeExecl(string path, DataTable dt)
        {
            Educe ed = new Educe();
            System.Collections.Hashtable htb = new System.Collections.Hashtable();
            htb.Add("UserCode", "会员编号");
            htb.Add("nicename", "会员昵称");
            htb.Add("TakeTime", "申请日期");
            htb.Add("TakeMoney", "提现金额");
            htb.Add("TakePoundage", "手续费");

            htb.Add("RealityMoney", "实发");
            htb.Add("AccountType", "账户类型");
            htb.Add("BankName", "账户名称");
            htb.Add("BankAccount", "账号");
            htb.Add("BankAccountUser", "开户名");

            htb.Add("BankBranch", "支行");

            // dt.Columns.Remove("UserCode");
            dt.Columns.Remove("TrueName");
            //  dt.Columns.Remove("TakeMoney");
            //  dt.Columns.Remove("BankBranch");

            //dt.Columns.Remove("TakePoundage");
            // dt.Columns.Remove("TakeTime");
            dt.Columns.Remove("BankInCity1");

            dt.Columns.Remove("BankDian");
            dt.Columns.Remove("UserID");
            dt.Columns.Remove("ID");
            dt.Columns.Remove("BonusBalance");
            dt.Columns.Remove("Take001");
            dt.Columns.Remove("Take002");
            dt.Columns.Remove("Take004");
            dt.Columns.Remove("Take005");
            dt.Columns.Remove("Take006");
            dt.Columns.Remove("Flag");
            dt.Columns.Remove("IdenCode");
            dt.Columns.Remove("PhoneNum");
            dt.Columns.Remove("Take003");
            dt.Columns.Remove("BankInProvince");
            dt.Columns.Remove("BankInCity");

            DataTable newTable = new DataTable();
            //DataColumn newCol = new DataColumn();
            //newCol.ColumnName = "Num";
            //newTable.Columns.Add(newCol);
            foreach (DataColumn col in dt.Columns)
            {
                DataColumn c = new DataColumn();
                c.ColumnName = col.ColumnName;
                newTable.Columns.Add(c);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = newTable.NewRow();
                //  dr["Num"] = i + 1;
                foreach (DataColumn ncol in dt.Columns)
                {
                    dr[ncol.ColumnName] = dt.Rows[i][ncol.ColumnName];
                }
                newTable.Rows.Add(dr);
            }
            string title = "提现列表";
            return ed.daochu(newTable, htb, path, title);
        } 
        #endregion

        /// <summary>
        /// 导出提现列表
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ToTakeExecl2(string path, DataTable dt)
        {
            Educe ed = new Educe();
            System.Collections.Hashtable htb = new System.Collections.Hashtable();
            htb.Add("UserCode", "会员编号");
            htb.Add("nicename", "会员昵称");
            htb.Add("TakeTime", "申请日期");
            htb.Add("TakeMoney", "提现金额");
            htb.Add("TakePoundage", "手续费");

            htb.Add("RealityMoney", "实发");
            htb.Add("AccountType", "账户类型");
            htb.Add("BankName", "账户名称");
            htb.Add("BankAccount", "账号");
            htb.Add("BankAccountUser", "开户名");
 
            htb.Add("BankBranch", "支行");

           // dt.Columns.Remove("UserCode");
            dt.Columns.Remove("TrueName");
          //  dt.Columns.Remove("TakeMoney");
          //  dt.Columns.Remove("BankBranch");

            //dt.Columns.Remove("TakePoundage");
           // dt.Columns.Remove("TakeTime");
            dt.Columns.Remove("BankInCity1");

            dt.Columns.Remove("BankDian");
            dt.Columns.Remove("UserID");
            dt.Columns.Remove("ID");
            dt.Columns.Remove("BonusBalance");
            dt.Columns.Remove("Take001");
            dt.Columns.Remove("Take002");
            dt.Columns.Remove("Take004");
            dt.Columns.Remove("Take005");
            dt.Columns.Remove("Take006");
            dt.Columns.Remove("Flag");
            dt.Columns.Remove("IdenCode");
            dt.Columns.Remove("PhoneNum");
            dt.Columns.Remove("Take003");
            dt.Columns.Remove("BankInProvince");
            dt.Columns.Remove("BankInCity");

            DataTable newTable = new DataTable();
            //DataColumn newCol = new DataColumn();
            //newCol.ColumnName = "Num";
            //newTable.Columns.Add(newCol);
            foreach (DataColumn col in dt.Columns)
            {
                DataColumn c = new DataColumn();
                c.ColumnName = col.ColumnName;
                newTable.Columns.Add(c);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = newTable.NewRow();
              //  dr["Num"] = i + 1;
                foreach (DataColumn ncol in dt.Columns)
                {
                    dr[ncol.ColumnName] = dt.Rows[i][ncol.ColumnName];
                }
                newTable.Rows.Add(dr);
            }
            string title = "提现列表";
            return ed.daochu(newTable, htb, path, title);
        }

        /// <summary>
        /// 激活方式
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string JhType(int type)
        {
            string bi = "";
            if (currentCulture == "zh-cn")
            {
                if (type == 1)
                {
                    bi="银行汇款";
                }
                else if (type == 2)
                {
                    bi="在线充值";
                }
            }
            else
            {
                if (type == 1)
                {
                    bi = GetLanguage("BankTransfer");
                }
                else if (type == 2)
                {
                    bi = GetLanguage("OnlineRecharge");
                }
            }
            return bi;
        }

        /// <summary>
        /// 转账类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string ChangeType(int type)
        {

            //dropType.Items.Add(new ListItem("报单积分互转", "1"));
            //dropType.Items.Add(new ListItem("电子积分互转", "2"));
            //dropType.Items.Add(new ListItem("报单积分转电子积分", "3"));
            //dropType.Items.Add(new ListItem("奖金积分转电子积分", "4"));
            //dropType.Items.Add(new ListItem("电子积分转消费积分", "5"));
            string bi = "";
            if (currentCulture == "zh-cn")
            {
                if (type == 1)
                {
                    bi = "报单积分互转";
                }
                else if (type == 2)
                {
                    bi = "电子积分互转";
                }
                else if(type == 3)
                {
                    bi = "报单积分转电子积分";
                }
                else if (type == 4)
                {
                    bi = "奖金积分转电子积分";
                }
                else if (type == 5)
                {
                    bi = "电子积分转消费积分";
                }
 

            }
            else
            {
                if (type == 1)
                {
                    bi = "YD to other member";
                }
                else if (type == 2)
                {
                    bi = "Currency to Registered currency";
                }
                else if (type == 3)
                {
                    bi = "Currency to shopping currency";
                }
            }
            return bi;
        }

        /// <summary>
        /// 转账类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string RechargeType(int type)
        {
            string bi = "";
            if (type == 1)
            {
                bi = "奖金积分";
            }
            else if (type == 2)
            {
                bi = "电子积分";
            }
            else if (type == 3)
            {
                bi = "消费积分";
            }
            else if (type == 4)
            {
                bi = "种子积分";
            }
            else if (type == 5)
            {
                bi = "报单积分";
            } 
            return bi;
        }

        /// <summary>
        /// 账目类型
        /// </summary>
        /// <param name="inAmount">收入账户</param>
        /// <returns></returns>
        public string AccountType(string inAmount)
        {
            decimal d = 0;
            decimal.TryParse(inAmount,out d);
            string type = "";
            if (currentCulture == "zh-cn")
            {
                if (d == 0)
                {
                    type = "支出";
                }
                else if (d > 0)
                {
                    type = "收入";
                }
            }
            else if (currentCulture == "en-us")
            {
                if (d == 0)
                {
                    type = "Expenditure";
                }
                else if (d > 0)
                {
                    type = "Income";
                }
            }
            return type;
        }

        /// <summary>
        /// 币种类型
        /// </summary>
        /// <param name="type">币种</param>
        /// <returns></returns>
        public string OpeanType(string type)
        {
            decimal d = 0;
            decimal.TryParse(type, out d);
            string bi = "";
            if (currentCulture == "zh-cn")
            {
                if (d == 1)
                {
                    bi = "奖金积分";
                }
                else if (d == 2)
                {
                    bi = "电子积分";
                }
                else if (d == 3)
                {
                    bi = "消费积分";
                }
                else if (d == 4)
                {
                    bi = "种子积分";
                }
                else if (d == 5)
                {
                    bi = "报单积分";
                }
                else if (d == 6)
                {
                    bi = "平台手续费";
                }
                else if (d == 7)
                {
                    bi = "公益基金";
                }
            }
            else
            {
                if (d == 1)
                {
                    bi = "YD";
                }
                else if (d == 2)
                {
                    bi = "YT";
                }
                else if (d == 3)
                {
                    bi = "LockYT";
                }
            }
            return bi;
        }
        public string GoldType(string type)
        {
            decimal d = 0;
            decimal.TryParse(type, out d);
            string bi = "";
            if (currentCulture == "zh-cn")
            {
                if (d == 1)
                {
                    bi = "积分";
                }
                else if (d == 2)
                {
                    bi = "月分红静态钱包";
                }
                else if (d == 3)
                {
                    bi = "月分红动态钱包";
                }
                else if (d == 4)
                {
                    bi = "年分红静态钱包";
                }
                else if (d == 5)
                {
                    bi = "年分红动态钱包";
                }
            }
            else
            {
                if (d == 1)
                {
                    bi = "Currency";
                }
                else if (d == 2)
                {
                    bi = "MDD Drill";
                }
                else if (d == 3)
                {
                    bi = "Platform cost";
                }
                else if (d == 4)
                {
                    bi = "Shopping currency";
                }
                else if (d == 5)
                {
                    bi = "Registered currency";
                }
            }
            return bi;
        }
        /// <summary>
        /// 币种类型
        /// </summary>
        /// <param name="type">币种</param>
        /// <returns></returns>
        public string GoldDdlQuest(string type)
        {
            string d = type;
            string bi = "";
            if (currentCulture == "zh-cn")
            {
                if (d == "您的姓名是？")
                {
                    bi = "您的姓名是？";
                }
                else if (d == "您的家乡是？")
                {
                    bi = "您的家乡是？";
                }
                else if (d == "您最敬佩的人是？")
                {
                    bi = "您最敬佩的人是？";
                }

                if (d == "Your name is?")
                {
                    bi = "您的姓名是？";
                }
                else if (d == "Your home is?")
                {
                    bi = "您的家乡是？";
                }
                else if (d == "People you admire are?")
                {
                    bi = "您最敬佩的人是？";
                }
            }
            else
            {
                if (d == "Your name is?")
                {
                    bi = "Your name is?";
                }
                else if (d == "Your home is?")
                {
                    bi = "Your home is?";
                }
                else if (d == "People you admire are?")
                {
                    bi = "People you admire are?";
                }

                if (d == "您的姓名是？")
                {
                    bi = "Your name is?";
                }
                else if (d == "您的家乡是？")
                {
                    bi = "Your home is?";
                }
                else if (d == "您最敬佩的人是？")
                {
                    bi = "People you admire are?";
                }
            }
            return bi;
        }

        #region 导出开通会员列表
        /// <summary>
        /// 导出开通会员列表
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ToOpenExecl(string path, DataTable dt)
        {
            Educe ed = new Educe();
            System.Collections.Hashtable htb = new System.Collections.Hashtable();
            htb.Add("RecommendCode", "推荐人编号");
            htb.Add("UserCode", "会员编号");
            htb.Add("TrueName", "会员姓名");
            //htb.Add("RegMoney", "注册金额");
            htb.Add("LevelName", "会员级别");
            htb.Add("User006", "服务网点编号");
            htb.Add("OpenTime1", "开通日期");
            //htb.Add("User008", "报单方式");
            //htb.Add("JhType", "激活方式");
            //htb.Add("ZhuQu", "注册区域");
            htb.Add("RegTime", "注册日期");
            htb.Add("OpenTime", "开通日期");
            dt.Columns.Remove("User007");
            dt.Columns.Remove("RegMoney");
            dt.Columns.Remove("IsOpend");
            dt.Columns.Remove("LevelID");
            dt.Columns.Remove("UserID");
            dt.Columns.Remove("User002");
            dt.Columns.Remove("IsLock");
            dt.Columns.Remove("Level03");
            dt.Columns.Remove("User005");
            dt.Columns.Remove("Batch");
            dt.Columns.Remove("IsOut");
            dt.Columns.Remove("BonusAccount");
            dt.Columns.Remove("Emoney");
            dt.Columns.Remove("Email");
            dt.Columns.Remove("User008");
            dt.Columns.Remove("User015");
            dt.Columns.Remove("User003");
            dt.Columns.Remove("User001");
            dt.Columns.Remove("ParentCode");
            dt.Columns.Remove("GLmoney");
            dt.Columns.Remove("BillCount");



            DataColumn col = new DataColumn() { ColumnName = "OpenTime1", DefaultValue = "" };
            dt.Columns.Add(col);
            //DataColumn col2 = new DataColumn() { ColumnName = "ZhuQu", DefaultValue = "" };
            //dt.Columns.Add(col2);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              
                string OpenTime = dt.Rows[i]["OpenTime"].ToString();
                dt.Rows[i]["OpenTime1"] = OpenTime; 
                //string loction = dt.Rows[i]["Location"].ToString() == "1" ? "左区" : "右区";
                //dt.Rows[i]["ZhuQu"] = loction;
            }
            dt.Columns.Remove("OpenTime");
            dt.Columns.Remove("User004");
            dt.Columns.Remove("Location");
            string title = "开通会员列表";
            return ed.daochu(dt, htb, path, title);
        } 
        #endregion

        #region 导出待开通会员列表
        /// <summary>
        /// 导出待开通会员列表
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ToOpenExecl2(string path, DataTable dt)
        {
            Educe ed = new Educe();
            System.Collections.Hashtable htb = new System.Collections.Hashtable();
            htb.Add("RecommendCode", "推荐人编号");
            htb.Add("UserCode", "会员编号");
            htb.Add("TrueName", "会员姓名");
            htb.Add("RegMoney", "注册金额");
            htb.Add("LevelName", "会员级别");
            htb.Add("User006", "服务网点编号");
            htb.Add("ParentCode", "安置人编号");
            //htb.Add("User008", "报单方式");
            //htb.Add("JhType", "激活方式");
            htb.Add("ZhuQu", "注册区域");
            htb.Add("RegTime", "注册日期");
            dt.Columns.Remove("User007");
            dt.Columns.Remove("RegMoney");
            dt.Columns.Remove("IsOpend");
            dt.Columns.Remove("UserID");
            dt.Columns.Remove("User002");
            dt.Columns.Remove("IsLock");
            dt.Columns.Remove("User008");
            dt.Columns.Remove("LevelID");
            dt.Columns.Remove("User004");
            dt.Columns.Remove("OpenTime");
            DataColumn col2 = new DataColumn() { ColumnName = "ZhuQu", DefaultValue = "" };
            dt.Columns.Add(col2);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string loction = dt.Rows[i]["Location"].ToString() == "1" ? "左区" : "右区";
                dt.Rows[i]["ZhuQu"] = loction;
            }
            dt.Columns.Remove("Location");
            string title = "待开通会员列表";
            return ed.daochu(dt, htb, path, title);
        } 
        #endregion

        #region 导出会员信息列表
        /// <summary>
        /// 导出会员信息列表
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ToDetailExecl(string path, DataTable dt)
        {
            Educe ed = new Educe();
            System.Collections.Hashtable htb = new System.Collections.Hashtable();
            htb.Add("UserCode", "会员编号");
            htb.Add("TrueName", "会员姓名");
            htb.Add("LevelName", "会员级别");
            htb.Add("RegMoney", "注册金额");
            htb.Add("BankName", "开户行");
            htb.Add("BankAccount", "开户账号");
            htb.Add("BankAccountUser", "开户姓名");
            htb.Add("IdenCode", "身份证号");
            htb.Add("PhoneNum", "联系电话");
            htb.Add("Address", "联系地址");
            //htb.Add("User005", "Email");
            htb.Add("NiceName", "昵称");
            htb.Add("BonusAccount", "奖金余额");
            htb.Add("Emoney", "E币余额");
            dt.Columns.Remove("User005");
            dt.Columns.Remove("IsOpend");
            dt.Columns.Remove("LevelID");
            dt.Columns.Remove("UserID");
            dt.Columns.Remove("IsLock");
            string title = "会员信息列表";
            return ed.daochu(dt, htb, path, title);
        } 
        #endregion

        /// <summary>
        /// 服务中心列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetAgentList(string strWhere)
        {
            return dal.GetAgentList(strWhere);
        }
        /// <summary>
        /// 运营中心
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetAgentList1(string strWhere)
        {
            return dal.GetAgentList1(strWhere);
        }
        /// <summary>
        /// 晋升记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetProList(string strWhere)
        {
            return dal.GetProList(strWhere);
        }
        /// <summary>
        /// 获得充值记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetRechangeList(string strWhere)
        {
            return dal.GetRechangeList(strWhere);
        }
        /// <summary>
        /// 获得汇款记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetRemitList(string strWhere)
        {
            return dal.GetRemitList(strWhere);
        }
        /// <summary>
        /// 获得汇款记录 ， 收款账户 和 打款账户信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetRemitAndBankList(string strWhere)
        {
            return dal.GetRemitAndBankList(strWhere);
        }
        /// <summary>
        /// 获得提现总金额。
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public decimal GetTotalTake(long iUserID)
        {
            return dal.GetTotalTake(iUserID);
        }

        /// <summary>
        /// 根据条件获得提现记录
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetTakeList(string strWhere)
        {
            return dal.GetTakeList(strWhere);
        }
        ///// <summary>
        ///// 导出提现列表
        ///// </summary>
        ///// <param name="path"></param>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        //public string ToTakeExecl(string path, DataTable dt)
        //{
        //    return dal.ToTakeExecl(path, dt);
        //}
        /// <summary>
        /// 根据用户名，密码获得管理员信息
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataSet GetAdminModel(string UserCode, string Password)
        {
            return dal.GetAdminModel(UserCode, Password);
        }
        /// <summary>
        /// 更新评论动态(0-减，1-加)
        /// </summary>
        /// <param name="type">账户类型</param>
        /// <param name="userid">会员ID</param>
        /// <param name="money">金额</param>
        /// <param name="flag">1-加，0-减</param>
        /// <returns></returns>
        public int UpdateFriendDynamic(string strFiledName, long iUserID, int num, int iFlag)
        {
            return dal.UpdateFriendDynamic(strFiledName, iUserID, num, iFlag);
        }
        /// <summary>
        /// 更新点赞动态(0-减，1-加)
        /// </summary>
        /// <param name="type">账户类型</param>
        /// <param name="userid">会员ID</param>
        /// <param name="money">金额</param>
        /// <param name="flag">1-加，0-减</param>
        /// <returns></returns>
        //public int UpdateThumbs(string strFiledName, long iUserID, int num, int iFlag)
        //{
        //    return dal.UpdateThumbs(strFiledName, iUserID, num, iFlag);
        //}
        /// <summary>
        /// 更新公司账户(1-增加，0-减少)
        /// </summary>
        /// <param name="Type">字段名</param>
        /// <param name="money">金额</param>
        /// <param name="flag">1-增加，0-减少</param>
        /// <returns></returns>
        public int UpdateSystemAccount(string Type, decimal money, int flag)
        {
            return dal.UpdateSystemAccount(Type, money, flag);
        }
        /// <summary>
        /// 更新账户(0-减，1-加)
        /// </summary>
        /// <param name="type">账户类型</param>
        /// <param name="userid">会员ID</param>
        /// <param name="money">金额</param>
        /// <param name="flag">1-加，0-减</param>
        /// <returns></returns>
        public int UpdateAccount(string strFiledName, long iUserID, decimal dMoney, int iFlag)
        {
            return dal.UpdateAccount(strFiledName, iUserID, dMoney, iFlag);
        }

        /// <summary>
        /// 将给定的字段按用户编号更新成给定的值。
        /// </summary>
        /// <param name="strFiledName">给定的字段</param>
        /// <param name="strFiledValue">给定的值</param>
        /// <param name="iUserID">用户编号</param>
        /// <returns></returns>
        public int UpdateFiled(string strFiledName, string strFiledValue, int iUserID)
        {
            return dal.UpdateFiled(strFiledName, strFiledValue, iUserID);
        }

        /// <summary>
        /// 更新A盘可提现余额
        /// </summary>
        /// <param name="strFiled">更新字段</param>
        /// <param name="iUserID">用户ID</param>
        /// <param name="dMoney">金额</param>
        /// <param name="iFlag">0为减，1为加，即0为提现，1为取消提现。</param>
        /// <returns></returns>
        public int UpdateStockAccount(string strFiled, int iUserID, decimal dMoney, int iFlag)
        {
            return dal.UpdateStockAccount(strFiled, iUserID, dMoney, iFlag);
        }

        /// <summary>
        /// 获得会员账户
        /// </summary>
        /// <param name="type">账户名称</param>
        /// <param name="userid">会员ID</param>
        /// <returns></returns>
        public decimal GetMemberAccount(string type, object userid)
        {
            return dal.GetMemberAccount(type, userid);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsOrderID(string OrderCode)
        {
            return dal.ExistsOrderID(OrderCode);
        }
        /// <summary>
        /// 根据ID获取编号
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetUserCode(long UserID)
        {
            return dal.GetUserCode(UserID);
        }
        /// <summary>
        /// 根据编号获取ID
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public int GetUserID(string UserCode)
        {
            return dal.GetUserID(UserCode);
        }
        public int GetUserIDbByPhone(string PhoneNum)
        {
            return dal.GetUserIDbByPhone(PhoneNum);
        }
        /// <summary>
        /// 更新昵称
        /// </summary>
        public int Update(long UserID, string type, string value, string name)
        {
            return dal.Update(UserID, type, value, name);
        }
        /// <summary>
        /// 更新性别
        /// </summary>
        public int UpdateGender(long UserID, string gender, string name)
        {
            return dal.UpdateGender(UserID, gender, name);
        }
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="UserID">理财者ID</param>
        /// <param name="type">密码类型</param>
        /// <param name="pwd">密码值</param>
        /// <returns></returns>
        public int UpdateUserPwd(long iUserID, string strFieldName, string strPwd)
        {
            return dal.UpdateUserPwd(iUserID, strFieldName, strPwd);
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="UserID">理财者ID</param>
        /// <param name="type">密码类型</param>
        /// <param name="pwd">密码值</param>
        /// <returns></returns>
        public int UpdateAdminPwd(string strUserName, string strFieldName, string strPwd)
        {
            return dal.UpdateAdminPwd(strUserName, strFieldName, strPwd);
        }
        /// <summary>
        /// 根据编号密码测试用户是否存在
        /// </summary>
        /// <param name="UserCode">用户编号</param>
        /// <param name="Password">用户密码</param>
        /// <returns></returns>
        public bool ExistsAdmin(string UserCode, string Password)
        {
            return dal.ExistsAdmin(UserCode, Password);
        }
        /// <summary>
        /// 清空数据库
        /// </summary>
        public int ClearDataBase()
        {
            return dal.ClearDataBase();
        }
        /// <summary>
        /// 更新邮件状态
        /// </summary>
        /// <param name="id">邮件id</param>
        /// <param name="type">更新类型</param>
        /// <returns>更新行数</returns>
        public int UpdateState(long id, string type)
        {
            return dal.UpdateState(id, type);
        }

        #region 删除邮件
        /// <summary>
        /// 删除邮件
        /// </summary>
        /// <param name="id">邮件id</param>
        /// <param name="where">哪一方删除1：发件方2：收件方</param>
        /// <returns>是否成功</returns>
        public int DelEmail(long id, int where)
        {
            bool del = true;
            bool update = true;
            lgk.Model.tb_leaveMsg temp = lm.GetModel(id);
            if (temp.FromIDIsDel == 1 || temp.ToIDIsDel == 1)
            {
                if (lm.Delete(id))
                {
                    dal.DeleteReMsg(id);
                }
                else
                {
                    del = false;
                }
            }
            else
            {
                if (where == 1)
                {
                    if (dal.UpdateState(id, "FromIDIsDel") == 0)
                    {
                        update = false;
                    }
                }
                else
                {
                    if (dal.UpdateState(id, "ToIDIsDel") == 0)
                    {
                        update = false;
                    }
                }
            }
            if (del && update)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        } 
        #endregion

        /// <summary>
        /// 获得完全商品列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetShopList(string strWhere)
        {
            return dal.GetShopList(strWhere);
        }
        /// <summary>
        /// 获取指定类型下是否有商品
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetProduce(int type)
        {
            return dal.GetProduce(type);
        }
        /// <summary>
        /// 销售查询
        /// </summary>
        /// <returns></returns>
        public DataSet GetSell(string strWhere)
        {
            return dal.GetSell(strWhere);
        }
        /// <summary>
        /// 更新商品上架标志
        /// </summary>
        /// <param name="flg">0-下架 1-上架</param>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        public int UpdateShopFlg(int flg, int id)
        {
            return dal.UpdateShopFlg(flg, id);
        }
        /// <summary>
        /// 获得id
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public int GetOrderID(string code)
        {
            return dal.GetOrderID(code);
        }
        /// <summary>
        /// 获得所有订单信息
        /// </summary>
        public DataSet GetAllOrderList(string strWhere)
        {
            return dal.GetAllOrderList(strWhere);
        }

        /// <summary>
        /// 更新订单发货状态
        /// </summary>
        /// <param name="id">订单ID</param>
        /// <returns></returns>
        public int UpdateSendType(long id)
        {
            return dal.UpdateSendType(id);
        }
        /// <summary>
        /// 检测是否是有订单的商品
        /// </summary>
        /// <param name="ProcudeID">商品id</param>
        /// <returns></returns>
        public int ExistsProduct(int ProcudeID)
        {
            return dal.ExistsProduct(ProcudeID);
        }
        /// <summary>
        ///根据订单号删除数据
        /// </summary>
        public bool DeleteByCode(string code)
        {
            return dal.DeleteByCode(code);
        }

        /// <summary>
        /// 根据订单号获取商品
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public DataSet GetDetail(string strOrderCode)
        {
            return dal.GetDetail(strOrderCode);
        }

        /// <summary>
        /// 根据订单号获取商品
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public DataSet GetDetail(string strOrderCode, int iTypeID)
        {
            return dal.GetDetail(strOrderCode, iTypeID);
        }

        /// <summary>
        /// 根据任务ID删除任务信息
        /// </summary>
        public bool DeleteInfoByOrderID(int ID)
        {
            return dal.DeleteInfoByOrderID(ID);
        }
        /// <summary>
        /// 获得我的任务
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataSet GetAllOrder(string where)
        {
            return dal.GetAllOrder(where);
        }
        /// <summary>
        /// 获得我的收藏
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataSet GetMyCollect(string where)
        {
            return dal.GetMyCollect(where);
        }

        /// <summary>
        /// 获得转账记录
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetTransferList(string strWhere)
        {
            return dal.GetTransferList(strWhere);
        }

        #region 添加一条流水账记录
        /// <summary>
        /// 添加一条流水账记录
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <param name="remark">业务摘要</param>
        /// <param name="inamount">收入</param>
        /// <param name="outamount">支出</param>
        /// <param name="balance">余额</param>
        /// <param name="type">类型：1奖金，2-E币</param>
        /// <returns></returns>
        public bool AddJournal(int userid, string remark, decimal inamount, decimal outamount, decimal balance, int type)
        {
            try
            {
                lgk.Model.tb_journal jour_model = new lgk.Model.tb_journal()
                {
                    UserID = userid,
                    Remark = remark,
                    InAmount = inamount,
                    OutAmount = outamount,
                    BalanceAmount = balance,
                    JournalDate = DateTime.Now,
                    JournalType = type
                };
                if (journalBLL.Add(jour_model) > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        } 
        #endregion

        #region 大型数据分页绑定
        /// <summary>
        /// 大型数据分页绑定
        /// </summary>
        /// <param name="sql">查询sql</param>
        /// <param name="rowname">查询数据中必须存在的一列列名，用于标识和排序 如：select id,amount from tb_bonus 传入值则为“id desc”</param>
        /// <param name="AspNetPager1">分页控件id</param>
        /// <param name="Repeater1">repeater绑定控件id</param>
        /// <param name="span1">用于显示是否存在数据的层或者span 的id</param>
        public void bind_repeater(string sql, string rowname, AspNetPager AspNetPager1, Repeater Repeater1, HtmlControl span1)//, string sort
        {
            try
            {
                string topsql = "select top " + AspNetPager1.PageSize + " * from ( select ROW_NUMBER() over (order by " + rowname + ") num ,* from  ("
                                     + sql +
                                    " ) a ) b where num > (" + AspNetPager1.PageSize + " * (" + AspNetPager1.CurrentPageIndex + "-1))  order by num";

                string numsql = "select count(*) from (" + sql + " ) a";
                DataSet ds = DbHelperSQL.Query(topsql);
                //DataView dv = ds.Tables[0].DefaultView;
                //dv.Sort = sort;
                int dsnum = Convert.ToInt32(DbHelperSQL.GetSingle(numsql));
                AspNetPager1.RecordCount = dsnum;
                Repeater1.DataSource = ds;

                Repeater1.DataBind();
                if (span1 != null)
                {
                    span1.Style.Add("display", "none");
                    if (dsnum <= 0)
                    {
                        span1.Style.Add("display", "block");
                    }
                }
            }
            catch
            {
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                if (span1 != null)
                {
                    span1.Style.Add("display", "none");
                }
            }
        } 
        #endregion

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="dateSet">数据源</param>
        /// <param name="AspNetPager1">分页控件名</param>
        /// <param name="Repeater1">绑定的Repeater控件名</param>
        /// <param name="sort">排序</param>
        /// <param name="span1">无数据时提示的控件名</param>
        public void bind_repeater(DataSet dateSet, Repeater Repeater1, string sort, HtmlControl span1, AspNetPager AspNetPager1)
        {
            DataSet ds = null;
            if (dateSet != null)
            {
                try
                {
                    ds = dateSet;
                }
                catch (Exception)
                {
                    ds = null;
                }
            }

            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = sort;
            AspNetPager1.RecordCount = dv.Count;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            Repeater1.DataSource = pds;
            Repeater1.DataBind();
            if (span1 != null)
            {
                //span1.Style.Add("display", "none");
                span1.Visible = false;
                if (dv.Count <= 0)
                {
                    //span1.Style.Add("display", "block");
                    span1.Visible = true;
                }
            }
        } 
        #endregion

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="dateSet">数据源</param>
        /// <param name="Repeater1">绑定的Repeater控件名</param>
        /// <param name="sort">排序</param>
        public void bind_repeater_index(DataSet dateSet, Repeater Repeater1, string sort)
        {
            DataSet ds = null;
            if (dateSet != null)
            {
                try
                {
                    ds = dateSet;
                }
                catch (Exception)
                {
                    ds = null;
                }
            }
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = sort;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dv;
            Repeater1.DataSource = pds;
            Repeater1.DataBind();
        } 
        #endregion

        #region 无分页绑定
        /// <summary>
        /// 无分页绑定
        /// </summary>
        /// <param name="dateSet">数据源</param>
        /// <param name="Repeater1">绑定的Repeater控件名</param>
        /// <param name="sort">排序</param>
        /// <param name="span1">无数据时提示的控件名</param>
        public void bind_repeater(DataSet dateSet, Repeater Repeater1, string sort, HtmlControl span1)
        {
            DataSet ds = null;
            if (dateSet != null)
            {
                try
                {
                    ds = dateSet;
                }
                catch (Exception)
                {
                    ds = null;
                }
            }
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = sort;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = 0;
            pds.PageSize = 0;
            Repeater1.DataSource = pds;
            Repeater1.DataBind();
            if (span1 != null)
            {
                //span1.Style.Add("display", "none");
                span1.Visible = false;
                if (dv.Count <= 0)
                {
                    //span1.Style.Add("display", "block");
                    span1.Visible = true;
                }
            }
        } 
        #endregion

        #region 无分页绑定
        /// <summary>
        /// 无分页绑定
        /// </summary>
        /// <param name="dateSet">数据源</param>
        /// <param name="Repeater1">绑定的Repeater控件名</param>
        /// <param name="sort">排序</param>
        /// <param name="span1">无数据时提示的控件名</param>
        /// <param name="pagesize">取几条数据</param>
        public void bind_repeater(DataSet dateSet, Repeater Repeater1, string sort, HtmlControl span1, int pagesize)
        {
            DataSet ds = null;
            if (dateSet != null)
            {
                try
                {
                    ds = dateSet;
                }
                catch (Exception)
                {
                    ds = null;
                }
            }
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = sort;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = 0;
            pds.PageSize = pagesize;
            Repeater1.DataSource = pds;
            Repeater1.DataBind();
            if (span1 != null)
            {
                //span1.Style.Add("display", "none");
                span1.Visible = false;
                if (dv.Count <= 0)
                {
                    //span1.Style.Add("display", "block");
                    span1.Visible = true;
                }
            }
        } 
        #endregion

        #region 绑定下拉列表
        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        public void bind_DropDownList(DropDownList DropDownList1, DataTable dt, string idname, string valuename)
        {
            try
            {
                DropDownList1.Items.Clear();
                ListItem item_list = new ListItem();
                item_list.Value = "0";
                item_list.Text = GetLanguage("PleaseSselect");//"-请选择-"
                DropDownList1.Items.Add(item_list);
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem item_list1 = new ListItem();
                    item_list1.Value = dr[idname].ToString();
                    item_list1.Text = dr[valuename].ToString();
                    DropDownList1.Items.Add(item_list1);
                }
            }
            catch (Exception)
            {
                DropDownList1.Items.Clear();
            }
        } 
        #endregion

        #region 绑定下拉列表，后台页面
        /// <summary>
        /// 绑定下拉列表，后台页面
        /// </summary>
        public void bind_DropDownList_ht(DropDownList DropDownList1, DataTable dt, string idname, string valuename)
        {
            try
            {
                DropDownList1.Items.Clear();
                ListItem item_list = new ListItem();
                item_list.Value = "0";
                item_list.Text = "-请选择-";
                DropDownList1.Items.Add(item_list);
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem item_list1 = new ListItem();
                    item_list1.Value = dr[idname].ToString();
                    item_list1.Text = dr[valuename].ToString();
                    DropDownList1.Items.Add(item_list1);
                }
            }
            catch (Exception)
            {
                DropDownList1.Items.Clear();
            }
        }
        #endregion

        #region 获得会员编号
        /// <summary>
        /// 获得会员编号
        /// </summary>
        /// <param name="id">会员id</param>
        /// <param name="type">会员类型1：会员2：管理员</param>
        /// <returns></returns>
        public string GetUserCode(string id, string type)
        {
            if (type == "1")
            {
                lgk.Model.tb_user user = userBLL.GetModel(Convert.ToInt64(id));
                return user.UserCode;
            }
            else
            {
                lgk.Model.tb_admin admin = adminBLL.GetModel(int.Parse(id));
                return admin.UserName;
            }
        } 
        #endregion

        /// <summary>
        /// 是否存在该排序记录
        /// </summary>
        public bool OrderExists(int JobOrderID)
        {
            return dal.OrderExists(JobOrderID);
        }

        #region 转换成 HTML code
        /// <summary>
        /// 转换成 HTML code
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public static string ReplaceString(string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("'", "''");
            str = str.Replace("\"", "&quot;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\n", "<br>");
            return str;
        } 
        #endregion

        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="MessageFrom">发信人</param>
        /// <param name="Pwd">密码</param>
        /// <param name="ToMail">收信人</param>
        /// <param name="Title">标题</param>
        /// <param name="Host">发送邮件服务器</param>
        /// <returns></returns>
        public bool SendEmail(MailAddress MessageFrom, string Pwd, string ToMail, string Title, string Body, string Host)
        {
            return dal.SendEmail(MessageFrom, Pwd, ToMail, Title, Body, Host);
        } 
        #endregion

        /// <summary>
        /// 获得增值记录
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public DataSet GetZengZhi(string where)
        {
            return dal.GetZengZhi(where);
        }
        /// <summary>
        /// 获得投资记录
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public DataSet GetTouZi(string where)
        {
            return dal.GetTouZi(where);
        }

        /// <summary>
        /// 分红记录
        /// </summary>
        /// <returns></returns>
        public DataSet GetFenHong(string where)
        {
            return dal.GetFenHong(where);
        }
        /// <summary>
        /// 获得奖金累计
        /// </summary>
        /// <param name="userid">会员ID(0-总的)</param>
        /// <param name="typeid">奖金类型</param>
        /// <returns></returns>
        public decimal GetBonus(long iUserID, int iTypeID)
        {
            string strSQL = "SELECT ISNULL(SUM(ISNULL(Amount,0)),0) FROM tb_bonus";

            if (iUserID > 0)
            {
                if (iTypeID > 0)
                    strSQL += " WHERE UserID=" + iUserID + " AND TypeID=" + iTypeID + "";
                else
                    strSQL += " WHERE UserID=" + iUserID + "";
            }
            else
            {
                strSQL += " WHERE TypeID=" + iTypeID + " AND Amount>0";
            }

            decimal dAmount = Convert.ToDecimal(DbHelperSQL.GetSingle(strSQL));

            return dAmount;
        }

        /// <summary>
        /// 统计总的应发奖金，创业基金，实发奖金
        /// </summary>
        ///  <param name="strFieldName">奖金类型对应的字段</param>
        /// <returns></returns>
        public decimal GetBonusAllTotal(long iUserID, string strFieldName)
        {
            string strSQL = "SELECT ISNULL(SUM(ISNULL(" + strFieldName + ",0)),0) FROM tb_bonus";

            if (iUserID > 0)
                strSQL += " WHERE UserID=" + iUserID + "";

            decimal dAmount = Convert.ToDecimal(DbHelperSQL.GetSingle(strSQL));

            return dAmount;
        }

        /// <summary>
        /// 获取股票数(持有和挂单总和)
        /// </summary>
        /// <returns></returns>
        public decimal GetStock(long iUserID)
        {
            string strSQL = "SELECT ISNULL(SUM(ISNULL(Surplus,0)),0) FROM tb_Stock";

            if (iUserID > 0)
                strSQL += " WHERE UserID=" + iUserID + "";

            decimal dSurplus = Convert.ToDecimal(DbHelperSQL.GetSingle(strSQL));

            return dSurplus;
        }

        /// <summary>
        /// 获取股票数(0.持有，1.挂单，2.卖出中，3.已卖出)
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="iIsSell"></param>
        /// <returns></returns>
        public decimal GetStock(long iUserID, int iIsSell)
        {
            string strSQL = "SELECT ISNULL(SUM(ISNULL(Surplus,0)),0) FROM tb_Stock";

            if (iUserID > 0)
            {
                if (iIsSell > 0)
                    strSQL += " WHERE UserID=" + iUserID + " AND IsSell=" + iIsSell + "";
                else
                    strSQL += " WHERE UserID=" + iUserID + "";
            }
            else
            {
                strSQL += " WHERE IsSell=" + iIsSell + "";
            }

            decimal dSurplus = Convert.ToDecimal(DbHelperSQL.GetSingle(strSQL));

            return dSurplus;
        }

        /// <summary>
        /// 获取出局金额
        /// </summary>
        /// <returns></returns>
        public decimal getOutMoney(int userid)
        {
            if (userid > 0)
            {
                decimal TopMoney = Convert.ToDecimal(getParamAmount("outpraise" + getColumn(0, "LevelID", "tb_user", "UserID=" + userid, "")) * 10000);
                return TopMoney;
            }
            return 0;
        }

        /// <summary>
        /// 获取出局金额
        /// </summary>
        /// <returns></returns>
        public decimal getOutMoney(int userid,string param)
        {
            if (userid > 0)
            {
                decimal TopMoney = getParamAmount(param + getColumn(0, "LevelID", "tb_user", "UserID=" + userid, ""));
                return TopMoney;
            }
            return 0;
        }

        /// <summary>
        /// 获取日封顶值
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <returns></returns>
        public decimal getDateMoney(int userid, int bonusType) 
        {
            string dt = DateTime.Now.ToString("yyyy-MM-dd");
            if (userid > 0)
            {
                return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(Amount,0)),0) from  tb_bonus where userid=" + userid + " and TypeID=" + bonusType + " and CONVERT(VARCHAR(20),AddTime,120) like " + "'%" + dt + "%'"));
            }
            return 0;
        }

        #region 获取奖金金额
        /// <summary>
        /// 获取奖金金额
        /// </summary>
        /// <param name="userid">用户ＩＤ</param>
        /// <returns></returns>
        public string getPaid(int userid)
        {
            if (userid > 0)
            {
                decimal TotalMoney;
                decimal AToB;
                TotalMoney = Convert.ToDecimal(getColumn(0, "BonusAccount", "tb_user", "UserID=" + userid, ""));
                decimal TopMoney = getOutMoney(userid);

                //若A盘拆分后投入到B盘
                int getUserID;
                lgk.BLL.tb_user user = new lgk.BLL.tb_user();
                DataSet ds = user.GetList(0, "RecommendID=" + userid + " AND AccountType=1", "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["UserID"] != null && ds.Tables[0].Rows[i]["UserID"].ToString() != "")
                        {
                            getUserID = int.Parse(ds.Tables[0].Rows[i]["UserID"].ToString());
                            AToB = Convert.ToDecimal(getColumn(0, "BonusAccount", "tb_user", "UserID=" + getUserID, ""));
                            TotalMoney = TotalMoney + AToB;
                        }
                    }
                    if (TotalMoney >= TopMoney)
                    {
                        return TopMoney.ToString("0.00") + " (已到达出局额度)";
                    }
                    return TotalMoney.ToString("0.00");
                }
                if ((TotalMoney) >= TopMoney)
                {
                    return TopMoney.ToString("0.00") + " (已到达出局额度)";
                }
                return TotalMoney.ToString("0.00");
            }
            return "暂无数据显示";
        } 
        #endregion

        /// <summary>
        /// 获得奖金累计应发
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public decimal getBonusYF(int userid, int type)
        {
            if (userid > 0)
            {
                return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(Amount,0)),0) from tb_bonus where Bonus001=" + type + " and userid=" + userid + " and Bonus002=0"));
            }
            return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(Amount,0)),0) from tb_bonus where  Bonus001=" + type + " and Bonus002=0"));
        }
        public decimal getBonusFWF(int userid)
        {
            if (userid > 0)
            {
                return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(Revenue,0)),0) from tb_bonus where Bonus001=1 and userid=" + userid + " and Bonus002=0"));
            }
            return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(Revenue,0)),0) from tb_bonus where Bonus001=1  " + " and Bonus002=0"));
        }
        public decimal getBonusFBF(int userid)
        {
            if (userid > 0)
            {
                return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(Bonus005,0)),0) from tb_bonus where Bonus001=1 and userid=" + userid + " and Bonus002=0"));
            }
            return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(Bonus005,0)),0) from tb_bonus where Bonus001=1  " + " and Bonus002=0"));
        }
        public decimal getBonusCFXF(int userid)
        {
            if (userid > 0)
            {
                return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(Bonus006,0)),0) from tb_bonus where Bonus001=1 and userid=" + userid + " and Bonus002=0"));
            }
            return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(Bonus006,0)),0) from tb_bonus where Bonus001=1  " + " and Bonus002=0"));
        }
        public decimal getBonusSF(int userid)
        {
            if (userid > 0)
            {
                return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(sf,0)),0) from tb_bonus where Bonus001=1 and userid=" + userid + " and Bonus002=0"));
            }
            return Convert.ToDecimal(DbHelperSQL.GetSingle("select isnull(sum(isnull(sf,0)),0) from tb_bonus where Bonus001=1  " + " and Bonus002=0"));
        }

        /// <summary>
        /// 获得推荐人下线最左边点位父节点ID(用于商城用户注册)
        /// </summary>
        /// <param name="recommendid">推荐人ID</param>
        /// <returns></returns>
        public int getLeftParentIDForShop(int recommendid)
        {
            long uid = recommendid;
            while (uid != 0)
            {
                lgk.Model.tb_user model = userBLL.GetModelForShop(" Location=1 and ParentID=" + uid);
                if (model == null)
                {
                    break;
                }
                uid = model.UserID;
            }
            return (int)uid;
        }

        #region 获得推荐人下线最左边点位父节点ID
        /// <summary>
        /// 获得推荐人下线最左边点位父节点ID
        /// </summary>
        /// <param name="recommendid">推荐人ID</param>
        /// <returns></returns>
        public int getLeftParentID(int recommendid)
        {
            long uid = recommendid;
            while (uid != 0)
            {
                lgk.Model.tb_user model = userBLL.GetModel(" Location=1 and ParentID=" + uid);
                if (model == null)
                {
                    break;
                }
                uid = model.UserID;
            }
            return (int)uid;
        } 
        #endregion

        #region 获得线上第一个推荐人是服务网点的人
        /// <summary>
        /// 获得推荐人下线最左边点位父节点ID
        /// </summary>
        /// <param name="recommendid">推荐人ID</param>
        /// <returns></returns>
        public long getFirstAgent(long recommendid)
        {
            long uid = recommendid;
            while (uid != 0)
            {
                lgk.Model.tb_user model = userBLL.GetModel(" UserID=" + uid);
                if (model.IsAgent == 1)
                {
                    uid = model.UserID;
                    break;
                }
                else
                {
                    uid = model.RecommendID;
                }
            }
            return uid;
        }
        #endregion

        /// <summary>
        /// 获取抢购产品购买数量
        /// </summary>
        /// <param name="ProcudeID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int GetOrderSum(int ProcudeID, long UserID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select sum(b.OrderSum) qy from tb_Order a left");
            sb.Append(" join tb_OrderDetail b");
            sb.Append(" on a.OrderCode = b.OrderCode");
            sb.Append(" where IsSend > 0");
            sb.Append(" and b.ProcudeID = " + ProcudeID.ToString());
            sb.Append(" and a.UserID = " + UserID.ToString());
            sb.Append(" and a.TypeID in (select id from tb_produceType where Type02 = 1)");

            return Convert.ToInt32(DbHelperSQL.GetSingle(sb.ToString()));
        }

        /// <summary>
        /// 商品列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetGoodsList(string strWhere)
        {
            return dal.GetGoodsList(strWhere);
        }
        /// <summary>
        /// 获取指定商品下是否有订单
        /// </summary>
        /// <param name="goodsid"></param>
        /// <returns></returns>
        public int getOrder(int goodsid)
        {
            string sql = "select count(*) from tb_OrderDetail where ProcudeID=" + goodsid;
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int MySQL(string sql)
        {
            int n = 0;
            try
            {
                n = DbHelperSQL.ExecuteSql(sql);
            }
            catch (Exception  )
            {

            }
            finally
            {

            }
            return n;
        }

        #region 导出订单列表
        /// <summary>
        /// 导出订单列表
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ToOrderExecl(string path, DataTable dt)
        {
            Educe ed = new Educe();
            System.Collections.Hashtable htb = new System.Collections.Hashtable();
            htb.Add("OrderCode", "订单号");
            htb.Add("UserCode", "会员编号");
            htb.Add("TrueName", "会员姓名");
            htb.Add("UserAddr", "收货地址");
            htb.Add("OrderSum", "购买数量");
            htb.Add("OrderTotal", "总金额");
            htb.Add("OrderDate", "购买日期");
            htb.Add("IsSend", "状态");

            dt.Columns.Remove("OrderCode1");
            dt.Columns.Remove("OrderID");
            dt.Columns.Remove("UserID");
            dt.Columns.Remove("PVTotal");
            dt.Columns.Remove("PayMethod");
            dt.Columns.Remove("OrderType");
            dt.Columns.Remove("order1");
            dt.Columns.Remove("order2");
            dt.Columns.Remove("order3");
            dt.Columns.Remove("order4");

            DataTable dd = new DataTable();
            dd.Columns.Add("OrderCode");
            dd.Columns.Add("UserCode");
            dd.Columns.Add("TrueName");
            dd.Columns.Add("UserAddr");
            dd.Columns.Add("OrderSum");
            dd.Columns.Add("OrderTotal");
            dd.Columns.Add("OrderDate");
            dd.Columns.Add("IsSend");

            foreach (DataRow row in dt.Rows)
            {
                DataRow newrow = dd.NewRow();
                foreach (DataColumn col in dd.Columns)
                {
                    newrow["OrderCode"] = row["OrderCode"];
                    newrow["UserCode"] = row["UserCode"];
                    newrow["TrueName"] = row["TrueName"];
                    newrow["UserAddr"] = row["UserAddr"];
                    newrow["OrderSum"] = row["OrderSum"];
                    newrow["OrderTotal"] = row["OrderTotal"];
                    newrow["OrderDate"] = row["OrderDate"];
                    newrow["IsSend"] = row["IsSend"].ToString().Trim() == "1" ? "已发货" : "未发货";
                }
                dd.Rows.Add(newrow);
            }
            string title = "订单列表";
            return ed.daochu(dd, htb, path, title);
        } 
        #endregion

        #region 导出已开通报单中心列表
        /// <summary>
        /// 导出提现列表
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ToAgentExecl(string path, DataTable dt)
        {
            Educe ed = new Educe();
            System.Collections.Hashtable htb = new System.Collections.Hashtable();
            htb.Add("AgentCode", "服务网点编号");
            htb.Add("UserCode", "会员编号");
            htb.Add("TrueName", "会员姓名");
            htb.Add("LevelName", "会员级别");
            htb.Add("Quyu", "代理区域");
            htb.Add("AppliTime", "申请日期");
            htb.Add("OpenTime", "确认日期");

            dt.Columns.Remove("OrderCode1");
            dt.Columns.Remove("OrderID");
            dt.Columns.Remove("UserID");
            dt.Columns.Remove("PVTotal");
            dt.Columns.Remove("PayMethod");
            dt.Columns.Remove("OrderType");
            dt.Columns.Remove("order1");
            dt.Columns.Remove("order2");
            dt.Columns.Remove("order3");
            dt.Columns.Remove("order4");

            DataTable dd = new DataTable();
            dd.Columns.Add("AgentCode");
            dd.Columns.Add("UserCode");
            dd.Columns.Add("TrueName");
            dd.Columns.Add("LevelName");
            dd.Columns.Add("Quyu");
            dd.Columns.Add("AppliTime");
            dd.Columns.Add("OpenTime");

            foreach (DataRow row in dt.Rows)
            {
                DataRow newrow = dd.NewRow();
                foreach (DataColumn col in dd.Columns)
                {
                    newrow["AgentCode"] = row["AgentCode"];
                    newrow["UserCode"] = row["UserCode"];
                    newrow["TrueName"] = row["TrueName"];
                    newrow["LevelName"] = row["LevelName"];
                    newrow["Quyu"] = row["Quyu"];
                    newrow["AppliTime"] = row["AppliTime"];
                    newrow["OpenTime"] = row["OpenTime"];
                }
                dd.Rows.Add(newrow);
            }
            string title = "已开通报单中心列表";
            return ed.daochu(dd, htb, path, title);
        }
        #endregion

        #region 插入会员
        /// <summary>
        /// 插入会员
        /// </summary>
        /// <param name="moveUserCode"></param>
        /// <param name="targetUserCode"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public int flag_InsertUser(string moveUserCode, string targetUserCode, int location)
        {
            return dal.flag_InsertUser(moveUserCode, targetUserCode, location);
        } 
        #endregion

        /// <summary>
        /// 插入会员网络
        /// </summary>
        /// <param name="moveUserCode"></param>
        /// <param name="targetUserCode"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public int flag_InsertUserNet(string moveUserCode, string targetUserCode, int location)
        {
            return dal.flag_InsertUserNet(moveUserCode, targetUserCode, location);
        }

        /// <summary>
        /// 插入注册会员
        /// </summary>
        /// <param name="moveUserCode"></param>
        /// <param name="targetUserCode"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public int flag_InsertRegUser(string moveUserCode, string targetUserCode, int location)
        {
            return dal.flag_InsertRegUser(moveUserCode, targetUserCode, location);
        }
        /// <summary>
        /// 转换为int类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int ConvertToInt(object obj)
        {
            int result = 0;
            try
            {
                int.TryParse(obj.ToString(), out result);
            }
            catch (Exception)
            {
                 return result;
            }
            return result;
        }
        /// <summary>
        /// 获得request 参数值 Int类型
        /// </summary>
        /// <param name="key">参数名称</param>
        /// <returns></returns>
        protected int RequestInt(string key)
        {
            try
            {
                return (Request.Params[key] == null || Request.Params[key] == "") ? 0 : Convert.ToInt32(Request.Params[key]);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// 执行分红
        /// </summary>
        /// <param name="money">利润总额</param>
        /// <returns></returns>
        public int flag_fenhong(decimal money)
        {
            return dal.flag_fenhong(money);
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="exec_proc">如exec proc ''，0</param>
        /// <returns></returns>
        public int MyExecProc(string exec_proc)
        {
            try
            {
                return DbHelperSQL.ExecuteSql(exec_proc);
            }
            catch (Exception  )
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="strField">要获取的字段</param>
        /// <returns></returns>
        public string getUserInfo(int userid, string strField)
        {
            if (userid > 0 && strField != "")
            {
                return Convert.ToString(DbHelperSQL.GetSingle("select " + strField + " from tb_user where userid=" + userid));// + " and Bonus002=0"));
            }
            return null;
        }

        /// <summary>
        /// 获取股票数
        /// </summary>
        /// <param name="strField"></param>
        /// <param name="strOrder"></param>
        /// <returns></returns>
        public string getStockInfo(string strField, string strOrder) 
        {
            if (strField.Trim() != "" && strOrder.Trim()!="")
            {
                string aaa = Convert.ToString(DbHelperSQL.GetSingle("select  top 1 " + strField + " from StockIssue Order By " + strOrder));
                //return Convert.ToString(DbHelperSQL.GetSingle("select  top 1 " + strField + " from StockIssue Order By " + strOrder));// + " and Bonus002=0"));
                if (aaa != "")
                {
                    return aaa;
                }
                return "0";
            }
            return null;
        }

        #region 获取某表数据
        /// <summary>
        /// 获取某表数据
        /// </summary>
        /// <param name="iTop">选几行</param>
        /// <param name="strField">字段</param>
        /// <param name="strTable">表名</param>
        /// <param name="strTable">条件</param>
        /// <param name="strOrder">排序方式</param>
        /// <returns></returns>
        public string getColumn(int iTop, string strField, string strTable, string strWhere, string strOrder)
        {
            string strSql = "";
            string getValue;
            if (strField.Trim() != "" && strTable.Trim() != "")
            {
                StringBuilder sb = new StringBuilder();
                strSql = (sb.Append("select ")).ToString();
                if (iTop > 0)
                {
                    strSql = (sb.Append(" top " + iTop)).ToString();
                }
                strSql = (sb.Append(strField + " from " + strTable)).ToString();
                getValue = Convert.ToString(DbHelperSQL.GetSingle(strSql));
                if (strWhere.Trim() != "")
                {
                    strSql = strSql + " WHERE " + strWhere;
                    getValue = Convert.ToString(DbHelperSQL.GetSingle(strSql));
                }
                if (strOrder.Trim() != "")
                {
                    strSql = strSql + " Order By " + strOrder;
                    getValue = Convert.ToString(DbHelperSQL.GetSingle(strSql));
                }
                //return Convert.ToString(DbHelperSQL.GetSingle("select  top 1 " + strField + " from StockIssue Order By " + strOrder));// + " and Bonus002=0"));
                if (getValue != "")
                {
                    return getValue;
                }
                return "0";
            }
            return null;
        } 
        #endregion

        #region 获取字段个数
        /// <summary>
        /// 获取字段个数
        /// </summary>
        /// <param name="strField">字段名</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public string getCount(string strField, string strWhere)
        {
            string strSql;
            string getValue;
            StringBuilder sb = new StringBuilder();
            strSql = (sb.Append("Select ")).ToString();
            if (strField.Trim() != "" && strWhere.Trim() != "")
            {
                strSql = (sb.Append("COUNT(" + strField + ")" + " FROM tb_user " + " WHERE " + strWhere)).ToString();
                getValue = Convert.ToString(DbHelperSQL.GetSingle(strSql));
                return getValue;
            }
            return null;
        } 
        #endregion


        /// <summary>
        /// 确认收货
        /// </summary>
        public int Proc_Shopping(long iUserID, string iOrderCode)
        {
            return dal.Proc_Shopping(iUserID, iOrderCode);
        }
        /// <summary>
        /// 获取产品尺码
        /// </summary>
        /// <param name="goodsID">产品ID</param>
        /// <returns></returns>
        public DataSet GetGoodsPropertySize(int goodsID)
        {
            return dal.GetGoodsPropertySize(goodsID);
        }
        /// <summary>
        /// 投资
        /// </summary>
        public int proc_BuyMachine(long UserID, int Num )
        {
            return dal.proc_BuyMachine(UserID, Num, 0);
        }
        /// <summary>
        /// 投资
        /// </summary>
        public int proc_BuyMachine(long UserID, int Num,int BuyType)
        {
            return dal.proc_BuyMachine(UserID, Num, BuyType);
        }
        /// <summary>
        /// 获取主账号投资额度
        /// </summary>
        /// <param name="UserID">ID</param>
        /// <returns></returns>
        public decimal GetInvestAmount(long UserID)
        {
            return dal.GetInvestAmount(UserID);
        }


        /// <summary>
        /// 获取主账号投资额度
        /// </summary>
        /// <param name="UserID">ID</param>
        /// <returns></returns>
        public string GetInvestMaxDate(long UserID)
        {
            return dal.GetInvestMaxDate(UserID);
        }

        /// <summary>
        /// 获取分账号投资额度
        /// </summary>
        /// <param name="UserID">ID</param>
        /// <returns></returns>
        public decimal GetSecondInvestAmount(long UserID)
        {
            return dal.GetSecondInvestAmount(UserID);
        }

        /// <summary>
        /// 获取主账号最大投资额度
        /// </summary>
        /// <param name="UserID">ID</param>
        /// <returns></returns>
        public decimal GetInvestMaxAmount(long UserID)
        {
            return dal.GetInvestMaxAmount(UserID);
        }

        /// <summary>
        /// 获取聚元
        /// </summary>
        /// <param name="userid">接任务用户</param>
        /// <returns></returns>
        public DataSet flag_ShareGet(long userid)
        {
            return dal.flag_ShareGet(userid);
        }

        /// <summary>
        /// 获取聚元总期数
        /// </summary>
        /// <param name="userid">接任务用户</param>
        /// <returns></returns>
        public decimal GetTotalPhase(long userid)
        {
            return dal.GetTotalPhase(userid);
        }
        /// <summary>
        /// 已获取财富源
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataSet GetAlreadyBonusList(long userid)
        {
            return dal.GetAlreadyBonusList(userid);
        }
        /// <summary>
        /// 消费积分列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataSet GetConsumeBonusList(long userid)
        {
            return dal.GetConsumeBonusList(userid);
        }
        /// <summary>
        /// 达人收益列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataSet GetDarenBonusList(long userid)
        {
            return dal.GetDarenBonusList(userid);
        }
        /// <summary>
        /// 富贵达人列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataSet GetRichManBonusList(long userid)
        {
            return dal.GetRichManBonusList(userid);
        }
        /// <summary>
        /// 获取总奖金
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public decimal GetTotalBonus(long userid)
        {
            return dal.GetTotalBonus(userid);
        }
        /// <summary>
        /// 已获取奖金
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public decimal GetTotalBonusAlready(long userid)
        {
            return dal.GetTotalBonusAlready(userid);
        }
        /// <summary>
        /// 达人收益总奖金
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public decimal GetTotalAmount(long userid)
        {
            return dal.GetTotalAmount(userid);
        }
        /// <summary>
        /// 公司帐户 清空默认值
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int UpdateAccountDefault()
        {
            return dal.UpdateAccountDefault();
        }
        /// <summary>
        /// 健康运动任务完成,计算奖金
        /// </summary>
        /// <param name="userid">用户</param>
        /// <returns></returns>
        public int flag_Award_TaskDone(long userid, long taskid, string timelong, string donenum)
        {
            return dal.flag_Award_TaskDone(userid, taskid, timelong, donenum);
        }
        /// <summary>
        /// 获取手机号数量
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public int GetPhoneNumber(string PhoneNum)
        {
            return dal.GetPhoneNumber(PhoneNum);
        }
        /// <summary>
        /// 获取身份证数量
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public int GetIDCodeNumber(string IdenCode)
        {
            return dal.GetIDCodeNumber(IdenCode);
        }

        public int Get_Qiandao(long UserID)
        {
            string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
            decimal Jine = getParamAmount("price_3");//算力和释放币的比例
            decimal Qiandao = getParamAmount("Qiandao");//签到 
            Jine = Qiandao / Qiandao; 
            SqlConnection conn = new SqlConnection(sconn);
            conn.Open();
            //string sql = "insert into tb_Ready_Rand(UserID,Shengyu_Jine,TotalJine,Shengyu_Suanli,Total_Suanli,Flag,Remark,Once_Give,Kuangji,TuiJian_QianDao)values('" + UserID + "'," + 0 + ",'" + Jine + "','" + 0 + "','" + getParamAmount("price_2") + "','" + 1 + "','签到成功','" + Jine + "','" + 0 + "','" + 2 + "');  exec proc_ReadyRand  "+ UserID + " ,2;";
            string sql = "exec proc_Award_Rand " + UserID + " ,2;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int reInt = cmd.ExecuteNonQuery();
            conn.Close();
            //UpdateAccount(,);统计总算力
            if (reInt < 1)
            {
                return 0;
            } 
            return 1;
        }
        /// <summary>
        /// 剩余算力
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int Get_ShengYuSuanLi(long UserID)
        {
            var model = userBLL.GetModel(UserID);
            return (int)model.User012;
            //string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
            //int shengyu = 0;
            //SqlConnection conn = new SqlConnection(sconn);
            //conn.Open();
            //string sql = string.Format("select top(1)  isnull([SurplusAmount],0)Shengyu from tb_SuanliJournal where UserID=" + UserID + "  order by ID desc;");
            //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //conn.Close();
            //if (dt.Rows.Count>0)
            //{
            //  return  shengyu = int.Parse(dt.Rows[0]["Shengyu"].ToString());
            //}
            //return shengyu;
        }

        /// <summary>
        /// 获取手机号
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public string GetPhoneByAccount(string UserCode)
        {
            return  dal.GetPhoneByAccount(UserCode);
        }


        /// <summary>
        /// 获取手机号
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public string GetPhoneByUserID(long UserID)
        {
            return dal.GetPhoneByUserID(UserID);
        }

        /// <summary>
        /// 短信验证码校验
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="smscode">短信验证码</param>
        /// <param name="smstype">短信类型：1-注册，2-登录，3-忘记密码，4-修改登录密码，5-修改支付密码，6-绑定钱包，7-设置登录密码，8-设置支付密码</param>
        /// <returns></returns>
        public long CheckSMSCode(string phone,string smscode,int smstype)
        {
            long Validid = -1;//验证码对应ID
            string regSwitch = System.Configuration.ConfigurationManager.AppSettings["SMS_SWITCH"];//注册短信开关
            if (!regSwitch.Equals("Open")) return 0;//不需要验证

            LogHelper.SaveLog("ToPhone = '" + phone + "' and SCode = '" + smscode + "' and TypeID = " + smstype, "CheckSMSCode");

            string strwhere = " IsValid=0 And IsDeleted=0 And ValidTime>=GETDATE() And ToPhone='" + phone + "' and SCode='" + smscode + "' and TypeID=" + smstype;
            DataSet ds = smsBLL.GetList(1, strwhere, "PublishTime desc");
            if (ds.Tables[0].Rows.Count > 0)
                Validid = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());           

            return Validid;
        }

        public bool SendSMS(string strphone, string strtype)
        {
            int itype;
            bool flag = false;
            string regSwitch = System.Configuration.ConfigurationManager.AppSettings["SMS_SWITCH"];//注册短信开关
            lgk.BLL.SMS smsBLL = new lgk.BLL.SMS();
            if (regSwitch.Equals("Open"))
            {
                int.TryParse(strtype, out itype);

                lgk.Model.SMS model = new lgk.Model.SMS();
                model.IsDeleted = 0;
                model.IsValid = 0;
                model.PublishTime = DateTime.Now;
                model.SCode = new Library.Common().GetRandom(6);
                model.ToPhone = strphone;
                model.SMSContent = model.SCode;
                model.SendNum = 1;
                model.ToUserCode = "";
                model.ValidTime = DateTime.Now.AddMinutes(5);
                model.TypeID = itype;

                long isid = smsBLL.Add(model);
                if (isid > 0)
                {
                    //msg = "验证码已发送";
                    string strreturn = Library.SMSHelper.SendMessage2(strphone, model.SCode);
                    if (strreturn == "0")
                    {
                        flag = true;
                      //  msg = "发送成功";
                    }
                    //else
                   // {
                    //    smsBLL.UpdateDelete(isid, -1);
                       // msg = "发送失败";
                   // }
                }
                else
                {
                    //msg = "验证码发送失败";
                }
            }
            else
            {
               // msg = "短信接口关闭";
            }

            return flag;
        }

        /// <summary>
        /// 交易平台订单状态
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetTradongOrderStateName(string type)
        {
            string strTypeName = "";
            if (type == "-1")
            {
                strTypeName = "已撤销";
            }
            else if (type == "0")
            {
                strTypeName = "挂单中";
            }
            else if (type == "1")
            {
                strTypeName = "已完成";
            }
            return strTypeName;
        }
        /// <summary>
        /// 按小时生成释放币记录
        /// </summary>
        /// <param name="userid">用户</param>
        /// <returns></returns>
        public int flag_ReadyRand(long userid, int type)
        {
            return dal.flag_ReadyRand(userid, type);
        }


        /// <summary>
        /// 获得后台充值矿机数据列表
        /// </summary>
        public DataSet GetAdminMachineList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  u.UserCode,u.TrueName, ID,b.UserID,Price,Num,Amount,BuyTime,CalcPower,IsExpire,IsActive,ActiveTime,SurplusNum,ActiveNum  ");
            strSql.Append(" FROM tb_BuyMachine b");
            strSql.Append("  left join tb_user u on b.UserID = u.UserID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 安卓端注册时偶尔会出现传递的md5密码少第一个字符
        /// 只传递了31个字符，为了兼容多端登录需要做一下特殊处理
        /// </summary>
        /// <param name="pwd">数据库密码（已加密）</param>
        /// <param name="paramPwd">参数密码（已加密）</param>
        /// <returns></returns>
        public bool ValidPassword(string pwd,string paramPwd)
        {
            paramPwd = paramPwd.ToUpper();
            if (pwd.Length != 32 || paramPwd.Length != 32) {
                if (pwd.Length == 32) pwd = pwd.Substring(1, pwd.Length - 1);
                if (paramPwd.Length == 32) paramPwd = paramPwd.Substring(1, paramPwd.Length - 1);
            }
            return pwd == paramPwd;
        }

        #region 返回订单状态名称
        /// <summary>
        /// 返回订单状态名称
        /// </summary>
        /// <param name="iIsSend"></param>
        /// <returns></returns>
        public string OrderStateName(int iIsSend)
        {
            string strState = "";
            if (iIsSend == 0)
            {
                strState = "未付款";
            }
            else if (iIsSend == 1)
            {
                strState = "已支付";
            }
            else if (iIsSend == 2)
            {
                strState = "已发货";
            }
            else if (iIsSend == 3)
            {
                strState = "已完成";
            }
            else if (iIsSend == -1)
            {
                strState = "已取消";
            }
            return strState;
        }
        #endregion
    }
}
