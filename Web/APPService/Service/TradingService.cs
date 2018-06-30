using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Web.APPService.Service
{
    public class TradingService : AllCore
    {
        public List<TradingFloorModel> TradingFloor(int userid)
        {
            string strWhere1 = "UnitNum<>SaleNum AND [Cashsell].[UserID]<>" + userid + " AND IsSell=1 AND [Cashsell].[IsUndo]=0";//

            var dt = cashsellBLL.GetInnerList(strWhere1);
            decimal price = getParamAmount("Exchange");
            return DataTableToList(dt.Tables[0], price);
        }
        //保证金比率
        public Dictionary<string, string> GetBond()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("exchange", getParamVarchar("Exchange")); //汇率，单价
            values.Add("bond", getParamVarchar("Gold2"));// 保证金
            values.Add("minamount", getParamVarchar("Gold1"));// 最小交易额
            values.Add("transrate", getParamVarchar("TransferRateBTE"));// 聚元宝转换注册币比例 1:
            return values;
        }
        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TradingFloorModel> DataTableToList(DataTable dt,decimal price)
        {
            List<TradingFloorModel> modelList = new List<TradingFloorModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TradingFloorModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TradingFloorModel();
                    if (dt.Rows[n]["UserCode"] != null && dt.Rows[n]["UserCode"].ToString() != "")
                    {
                        model.UserCode = dt.Rows[n]["UserCode"].ToString();
                    }
                    if (dt.Rows[n]["CashSellID"] != null && dt.Rows[n]["CashSellID"].ToString() != "")
                    {
                        model.OrderID = dt.Rows[n]["CashSellID"].ToString();
                    }
                    if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                    {
                        model.OrderCode = dt.Rows[n]["Title"].ToString();
                    }
                    if (dt.Rows[n]["Number"] != null && dt.Rows[n]["Number"].ToString() != "")
                    {
                        model.Total = dt.Rows[n]["Number"].ToString();
                    }
                    if (dt.Rows[n]["Balance"] != null && dt.Rows[n]["Balance"].ToString() != "")
                    {
                        model.Balance = dt.Rows[n]["Balance"].ToString();
                    }
                    model.Price = price.ToString("0.00");
                    //if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    //{
                    //    model.Price = dt.Rows[n]["Price"].ToString();
                    //}
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CashOrderModel> DataTableToOrderList(DataTable dt,decimal Price)
        {
            List<CashOrderModel> modelList = new List<CashOrderModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CashOrderModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CashOrderModel();
                    
                    if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.TransOrderID = dt.Rows[n]["OrderID"].ToString();
                    }
                    if (dt.Rows[n]["SellUserCode"] != null && dt.Rows[n]["SellUserCode"].ToString() != "")
                    {
                        model.SellUserCode = dt.Rows[n]["SellUserCode"].ToString();
                    }
                    if (dt.Rows[n]["CashbuyID"] != null && dt.Rows[n]["CashbuyID"].ToString() != "")
                    {
                        model.BuyOrderID = dt.Rows[n]["CashbuyID"].ToString();
                    }
                    if (dt.Rows[n]["OrderCode"] != null && dt.Rows[n]["OrderCode"].ToString() != "")
                    {
                        model.BuyOrderCode = dt.Rows[n]["OrderCode"].ToString();
                    }
                    if (dt.Rows[n]["CashsellID"] != null && dt.Rows[n]["CashsellID"].ToString() != "")
                    {
                        model.SellOrderID = dt.Rows[n]["CashsellID"].ToString();
                    }
                    if (dt.Rows[n]["SellOrderCode"] != null && dt.Rows[n]["SellOrderCode"].ToString() != "")
                    {
                        model.SellOrderCode = dt.Rows[n]["SellOrderCode"].ToString();
                    }

                    if (dt.Rows[n]["BuyNum"] != null && dt.Rows[n]["BuyNum"].ToString() != "")
                    {
                        model.Number = dt.Rows[n]["BuyNum"].ToString();
                    }
                    int iSStatus = int.Parse(dt.Rows[n]["SStatus"].ToString());
                    int iBStatus = int.Parse(dt.Rows[n]["BStatus"].ToString());
                    int iStatus = int.Parse(dt.Rows[n]["Status"].ToString());
                    int Status;
                   
                    model.StatusText = GetStatus(iSStatus, iBStatus, iStatus,out Status);//订单状态
                    model.Status = Status.ToString();

                    if (dt.Rows[n]["OrderDate"] != null && dt.Rows[n]["OrderDate"].ToString() != "")
                    {
                        model.OrderDate = DateTime.Parse(dt.Rows[n]["OrderDate"].ToString());
                    }
                    if (dt.Rows[n]["downtime"] != null && dt.Rows[n]["downtime"].ToString() != "")
                    {
                        model.ExpireDate = DateTime.Parse(dt.Rows[n]["downtime"].ToString());
                    }
                    if (dt.Rows[n]["bankid"] != null && dt.Rows[n]["bankid"].ToString() != "")
                    {
                        model.BankID = long.Parse(dt.Rows[n]["bankid"].ToString());
                    }
                    if (dt.Rows[n]["SellerPhone"] != null && dt.Rows[n]["SellerPhone"].ToString() != "")
                    {
                        model.SellerPhone = dt.Rows[n]["SellerPhone"].ToString();
                    }
                    if (dt.Rows[n]["BuyUserCode"] != null && dt.Rows[n]["BuyUserCode"].ToString() != "")
                    {
                        model.BuyUserCode = dt.Rows[n]["BuyUserCode"].ToString();
                    }
                    if (dt.Rows[n]["BuyerPhone"] != null && dt.Rows[n]["BuyerPhone"].ToString() != "")
                    {
                        model.BuyerPhone = dt.Rows[n]["BuyerPhone"].ToString();
                    }
                    if (dt.Rows[n]["BuyNiceName"] != null && dt.Rows[n]["BuyNiceName"].ToString() != "")
                    {
                        model.BuyNiceName = dt.Rows[n]["BuyNiceName"].ToString();
                    }

                    model.BuyerRemark = dt.Rows[n]["BRemark"] == null ? "" : dt.Rows[n]["BRemark"].ToString();
                    model.SellerRemark = dt.Rows[n]["SRemark"] == null ? "" : dt.Rows[n]["SRemark"].ToString();                   
                    model.Pic = dt.Rows[n]["Pic"] == null || dt.Rows[n]["Pic"].ToString() == "" ? "":WebHelper.HttpDomain + dt.Rows[n]["Pic"].ToString();
                    model.Price = Price.ToString("0.00");// dt.Rows[n]["Price"] == null ? "1" : dt.Rows[n]["Price"].ToString();

                    modelList.Add(model);
                }
            }
            return modelList;
        }
        //订单状态
        private string GetStatus(int iSStatus, int iBStatus, int iStatus,out int Status)
        {

            if (iSStatus == 0 && iBStatus == 0)
            {
                Status = 0;
                return "等待付款";
            }
            if (iSStatus == 0 && iBStatus == 1)
            {
                //if (iIsFeedback == 1)
                //    return GetLanguage("WaitingConfirmPayWait");//未收到付款，待审核
                //else
                Status = 1;
                return "确认收款中";

            }
            //已付款和已发货表明订单已完成交付，所以不能取消
            if (iSStatus == 1 && iBStatus == 1 && iStatus == 0)
            {
                Status = 2;
                return "等待发货";
            }
            else if (iStatus == 1)
            {
                Status = 3;
                return "已完成";
            }
            else if (iStatus == 2 || iSStatus == 2 || iBStatus == 2)
            {
                Status = -1;
                return "已撤销";
            }
            Status = -2;
            return "无效";
        }
        #endregion
        //卖出
        public bool Sell(long UserID, string Number, string phone, long bankid,string paypassword, out string message)
        {
            var user = userBLL.GetModel(UserID);
            if (user == null)
            {
                message = "该账号不存在";
                return false;
            }

            if (user.SecondPassword != paypassword)
            {
                message = "支付密码错误";
                return false;
            }
            if (user.IsLock == 1)
            {
                message = "账户已冻结，挂卖失败";
                return false;
            }
            if (getParamInt("Gold") == 0)
            {
                message = GetLanguage("Feature");//该功能未开放
                return false;
            }

            var bank = userBankBLL.GetModel(bankid);
            if (bank == null)
            {
                message = "请选择收款账户";
                return false;
            }
            if(bank.UserID != UserID)
            {
                message = "收款账户不存在";
                return false;
            }
            #region 金额验证
            if (Number.Trim() == "")
            {
                message = GetLanguage("AmountNoEmpty");//卖出金额不能为空
                return false;
            }
            int dNumber = 0;
            if (int.TryParse(Number.Trim(), out dNumber))
            {
                decimal dGold1 = getParamAmount("Gold1");
                if (dNumber < dGold1)
                {
                    message = GetLanguage("Minimum");//最小交易额
                    return false;
                }
            }
            else
            {
                message = GetLanguage("NumberThanZero");//金额格式输入错误
                return false;
            }

            int mul = getParamInt("Gold7");
            if (dNumber % mul != 0)
            {
                message = string.Format(GetLanguage("CashSellMul"), mul);//出售金额必须为 7 的整数倍
                return false;
            }

            decimal dMaxNumber = 0;//每日最大挂卖数量
            decimal dBaseNumber = 0;//每日挂卖基数 dBNumber = 0,
            decimal dANumber = 0;//今日已挂卖数量

            dBaseNumber = getParamAmount("Gold6");
            // dBNumber = getParamAmount("Gold7");
            dMaxNumber = dBaseNumber;// dBaseNumber + dBNumber * userBLL.GetCount("RecommendID = " + LoginUser.UserID + " AND IsOpend = 2");//每日挂卖基数
            dANumber = cashsellBLL.GetAlready(UserID) + dNumber;

            if (dANumber > dMaxNumber)
            {
                message = GetLanguage("ConsignmentOver");// 寄售数量已超额
                return false;
            }

            //decimal dPrice = getParamAmount("GoldPrice");
            decimal dPrice = getParamAmount("Exchange");

            #endregion

            //if (txtThreePassword.Value.Trim() == "")
            //{
            //    MessageBox.ShowBox(this.Page, GetLanguage("Pleasepassword"), Library.Enums.ModalTypes.warning);// 请输入二级密码
            //    return;
            //}

            //string strPassword = PageValidate.GetMd5(txtThreePassword.Value.Trim());
            //int re = spd.findSecondpws(strPassword, 1, getLoginID());
            //if (re == 0)
            //{
            //    MessageBox.ShowBox(this.Page, GetLanguage("PasswordError"), Library.Enums.ModalTypes.error);// >密码输入错误!
            //    return;
            //}

            // int iUnitNum = Convert.ToInt32(txtUnitNum.Value.Trim());//发布件数1
            decimal dFactorage = dNumber * getParamAmount("Gold2") / 100;//手续费

            lgk.Model.tb_user userInfo = new lgk.Model.tb_user();
            lgk.Model.Cashsell cashsellInfo = new lgk.Model.Cashsell();

            decimal dAmount = dNumber * dPrice;

            userInfo = userBLL.GetModel(UserID);

            #region 赋值给金币销售表实体
            cashsellInfo.Title = Util.CreateNo();
            cashsellInfo.UserID = UserID;
            cashsellInfo.Amount = dAmount;//总金额
            cashsellInfo.Number = dNumber;//单件数量
            cashsellInfo.Price = dPrice;//商品单价
            cashsellInfo.UnitNum = getParamAmount("Gold2");//手续费率
            cashsellInfo.SaleNum = 0;//已卖件数
            cashsellInfo.Charge = dFactorage;//所需手续费
            cashsellInfo.SellDate = DateTime.Now;//提交时间
            cashsellInfo.Remark = "";
           // cashsellInfo.PurchaseID = 0;
            cashsellInfo.IsSell = 1;
            cashsellInfo.Phone = phone;
            cashsellInfo.PurchaseID = bankid; //收款账户ID
            #endregion

            #region 加入流水账表
            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            journalInfo.UserID = cashsellInfo.UserID;
            journalInfo.Remark = "卖出交易币";
            journalInfo.RemarkEn = "Sell Circulating gold";
            journalInfo.InAmount = 0;
            journalInfo.OutAmount = cashsellInfo.Number;// cashsellInfo.Number * iUnitNum + dFactorage;
            journalInfo.BalanceAmount = userInfo.ShopAccount - dNumber;// userInfo.BonusAccount - dNumber - dFactorage;
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = (int)Library.AccountType.交易钱包;
            journalInfo.Journal01 = cashsellInfo.UserID;
            #endregion

            #region 保证金 加入流水账表
            lgk.Model.tb_journal journalInfoTrans = new lgk.Model.tb_journal()
            {
                UserID = cashsellInfo.UserID,
                Remark = "卖出交易币,扣除保证金",
                RemarkEn = "Sell gold points, consumption code",
                InAmount = 0,
                OutAmount = dFactorage,// cashsellInfo.Number * iUnitNum + dFactorage;
                BalanceAmount = userInfo.ShopAccount - dFactorage,// userInfo.BonusAccount - dNumber - dFactorage;
                JournalDate = DateTime.Now,
                JournalType = (int)Library.AccountType.交易钱包,
                Journal01 = cashsellInfo.UserID
            };

            #endregion

            decimal dBonusAccount = dNumber;// + dFactorage;

            if (userInfo.ShopAccount < (dBonusAccount + dFactorage))
            {
                message = GetLanguage("GoldInsufficient");// 金币不足，请重新填写数据之后再试！!
                return false;
            }

            //if (userInfo.ShopAccount < dFactorage)
            //{
            //    message = GetLanguage("GoldTransInsufficient");//交易码不足！

            //    return false;
            //}

            journalBLL.Add(journalInfoTrans);
           // UpdateAccount("ShopAccount", UserID, dBonusAccount+ dFactorage, 0); //扣除保证金

            if (cashsellBLL.Add(cashsellInfo) > 0 && journalBLL.Add(journalInfo) > 0 && UpdateAccount("ShopAccount", UserID, dBonusAccount + dFactorage, 0) > 0)
            {
                message = GetLanguage("Successful");//卖出成功!
                return true;
            }
            else
                message = GetLanguage("OperationFailed");//操作失败!

            return false;

        }
        //卖出订单状态
        private string GetSellStatus(int Status)
        {
            if (Status == -1)
            {
                return "已撤消";
            }
            if (Status == 0)
            {
                return "挂单中";
            }
           
            if (Status == 2)
            {
                return "已完成";
            }
            // if (Status == 1)
            {
                return "交易中";
            }
        }
        //买入
        public bool Buy(long UserID, string OrderSellID, string Number, string phone, string paypassword,out long orderid, out string message)
        {
            orderid = 0;
            var user = userBLL.GetModel(UserID);
            if (user == null)
            {
                message = "该账号不存在";
                return false;
            }

            if (user.SecondPassword != paypassword)
            {
                message = "支付密码错误";
                return false;
            }
            if (user.IsLock == 1)
            {
                message = "账户已冻结，买入失败";
                return false;
            }
            lgk.Model.Cashbuy cashbuyInfo = new lgk.Model.Cashbuy();
            lgk.Model.Cashsell cashsellInfo = new lgk.Model.Cashsell();
            lgk.Model.Cashorder cashorderInfo = new lgk.Model.Cashorder();

            if (getParamInt("Gold") == 0)
            {
                message = GetLanguage("Feature");//该功能未开放
                return false;
            }

            if (user.IsOpend == 0)
            {
                message = GetLanguage("AccountNoActiveInfo");//您的帐号未激活
                return false;
            }

            if (user.IsLock == 1)
            {
                message = GetLanguage("AccountLock") + GetLanguage("AccountLockInfo");//您的帐号已冻结，不能进行操作
                return false;
            }

            decimal iBuyNum = Number.ToDecimal();//购买件数
       
            if (iBuyNum <= 0)
            {
                message = GetLanguage("NumberThanZero");//数量必须大于零
                return false;
            }

            int _orderSellID = OrderSellID.ToInt();

            cashsellInfo = cashsellBLL.GetModel(_orderSellID);
            if (cashsellInfo == null)
            {
                message = "挂卖订单不存在";
                return false;
            }

            decimal iUnitNum = cashsellInfo.Number;//发布件数
            decimal iSaleNum = cashsellInfo.SaleNum;//已卖件数

            decimal iSurplus = iUnitNum - iSaleNum;//剩余件数

            if (iBuyNum > iSurplus)
            {
                message = GetLanguage("BuyAmountMust");//购买金额不能大于售出金额
                return false;
            }

            cashsellInfo.SaleNum = iSaleNum + iBuyNum; 

            #region EP币购买表
            cashbuyInfo.CashsellID = cashsellInfo.CashsellID;
            cashbuyInfo.UserID = UserID;
            cashbuyInfo.Amount = iBuyNum;
            cashbuyInfo.Price = cashsellInfo.Price;
            cashbuyInfo.Number = (int)iBuyNum;
            cashbuyInfo.BuyNum = iBuyNum;
            cashbuyInfo.BuyDate = DateTime.Now;
            cashbuyInfo.IsBuy = 0;
            cashbuyInfo.Phone = phone;
            #endregion

            #region EP币订单表
            cashorderInfo.CashsellID = cashsellInfo.CashsellID;
            cashorderInfo.BUserID = cashbuyInfo.UserID;
            cashorderInfo.SUserID = cashsellInfo.UserID;
            // string strOrderCode = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            //strOrderCode = strOrderCode + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            cashorderInfo.OrderCode = Library.Util.CreateNo();// strOrderCode + GetRandom();
            cashorderInfo.OrderDate = DateTime.Now;
            cashorderInfo.BStatus = 0;
            cashorderInfo.BRemark = "";
            cashorderInfo.SStatus = 0;
            cashorderInfo.SRemark = "";
            cashorderInfo.Status = 0;
           // cashorderInfo.Pic = picpath;
            #endregion

            long iCashbuyID = cashbuyBLL.Add(cashbuyInfo);

            if (iCashbuyID > 0)
            {
                cashsellBLL.Update(cashsellInfo);
                cashorderInfo.CashbuyID = iCashbuyID;
                cashorderBLL.Add(cashorderInfo);
                orderid = iCashbuyID;
                message = GetLanguage("Successful") + "，" + GetLanguage("OrderNumber") + "：" + cashorderInfo.OrderCode;
                return true;
            }
            message = "买入失败";
            return false;
        }
        //卖出订单列表
        public List<CashSellInfoModel> SellOrder(long userid)
        {
            string strWhere = "UserID=" + userid;
            var dt = cashsellBLL.GetOrderList(strWhere);
            return SellTableToList(dt.Tables[0]);
        }
        //卖出记录列表
        public List<CashOrderModel> SellAndBuyOrder(long userid,long orderid)
        {
            string strWhere = "SUserID=" + userid + " and CashSellID =" + orderid;
            var dt = cashorderBLL.GetOrderList(strWhere);
            decimal price = getParamAmount("Exchange");
            return DataTableToOrderList(dt.Tables[0], price);
        }
        //卖出交易订单详情
        public List<CashOrderModel> SellTransOrderInfo(long userid, long orderid)
        {
            string strWhere = "SUserID=" + userid + " and OrderID =" + orderid;
            var dt = cashorderBLL.GetOrderList(strWhere);
            decimal price = getParamAmount("Exchange");
            return DataTableToOrderList(dt.Tables[0], price);
        }
        //买入订单列表
        public List<CashOrderModel> BuyOrder(long userid)
        {
            string strWhere = "BUserID=" + userid;
            var dt = cashorderBLL.GetOrderList(strWhere);
            decimal price = getParamAmount("Exchange");
            return DataTableToOrderList(dt.Tables[0], price);
        }
        //卖出订单详情
        public CashSellInfoModel SellOrderInfo(long userid, int orderid)
        {
            CashSellInfoModel sellinfo = new CashSellInfoModel();
            string strWhere = "UserID=" + userid + " and CashSellID =" + orderid;
            var dt = cashsellBLL.GetOrderList(strWhere);
            return SellTableToModel(dt.Tables[0]);
        }
        //买入订单详情
        public CashOrderModel BuyOrderInfo(long userid, long orderid)
        {
            string strWhere = "BUserID=" + userid + " and CashBuyID =" + orderid;
            var dt = cashorderBLL.GetOrderList(strWhere);
            decimal price = getParamAmount("Exchange");
            return DataTableToOrderList(dt.Tables[0], price).FirstOrDefault();
        }
        //付款
        public bool OrderPay(long userid,long orderid,string picpath,string remark, out string message)
        {
            var user = userBLL.GetModel(userid);
            if (user.IsLock == 1)
            {
                message = "账户已冻结，付款失败";
                return false;
            }

            lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(orderid);
            if(cashorderInfo == null)
            {
                message = "订单不存在";
                return false;
            }
            if (cashorderInfo.BUserID != userid)
            {
                message = "订单无效";
                return false;
            }
            if (cashorderInfo.BUserID == userid && cashorderInfo.SStatus == 0 && cashorderInfo.BStatus == 0)
            {
                remark = SafeHelper.GetSafeSqlandHtml(remark);
                cashorderBLL.Update(userid, cashorderInfo.OrderID, DateTime.Now, picpath, remark, 1);//付款
                message = GetLanguage("Successful");
                return true;
            }
            message = "付款失败";
            return false;
        }

        //收款
        public bool OrderGet(long userid, long orderid, out string message)
        {
            var user = userBLL.GetModel(userid);
            if (user.IsLock == 1)
            {
                message = "账户已冻结，收款失败";
                return false;
            }

            lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(orderid);
            if (cashorderInfo == null)
            {
                message = "订单不存在";
                return false;
            }
            if (cashorderInfo.SUserID != userid)
            {
                message = "订单无效";
                return false;
            }

            if (cashorderInfo.SUserID == userid && cashorderInfo.BStatus == 1 && cashorderInfo.SStatus == 0 )
            {
                cashorderBLL.Update(userid, cashorderInfo.OrderID, DateTime.Now, "", "", 2);//确认已付款

                cashorderBLL.Update(cashorderInfo.SUserID, orderid, DateTime.Now, "", "", 3);//发货

                lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);

                lgk.Model.Cashsell CashsellInfo = cashsellBLL.GetModel(cashbuyInfo.CashsellID);

                decimal dNumber = cashbuyInfo.Number;
                //decimal dCharge = CashsellInfo.Charge;//总手续费
                //decimal dMTaxRate = dNumber * getParamAmount("Gold3") / 100;//买家获得手续费
                //decimal dCTaxRate = dNumber * getParamAmount("Gold4") / 100;//公司获得手续费

                //decimal dTNumber = dNumber - dCharge + dMTaxRate;

                //聚元宝：注册币（ 1：TransferRateBTE）
                //注册币 = 聚元宝 * 比例b
                decimal dTNumber = dNumber * getParamAmount("TransferRateBTE");//聚元宝转换注册币比例 ;// + dMTaxRate;
                //买家得到的是聚元宝 StockMoney
                UpdateAccount("Emoney", cashorderInfo.BUserID, dTNumber, 1);//发货给购买者

                //UpdateSystemAccount("MoneyAccount", dCTaxRate, 1);

                ////SetAccount(iUserID, dAccount, "EP币发货！", 1);
                SetAccount(cashorderInfo.BUserID, dTNumber, "金币发货！", cashorderInfo.SUserID, (int)Library.AccountType.交易钱包);

                message = GetLanguage("Successful");
                return true;
            }
            message = "收款失败";
            return false;
        }

        /// <summary>
        /// 加入流水账表
        /// </summary>
        /// <param name="iUserID">用户编号</param>
        /// <param name="dAccount">收发货数量</param>
        /// <param name="strRemark">备注</param>
        private void SetAccount(long iBUserID, decimal dAccount, string strRemark, long iSUserID, int JournalType)
        {
            #region 加入流水账表

            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            lgk.Model.tb_user userInfo = userBLL.GetModel(iBUserID);
            journalInfo.UserID = iBUserID;
            journalInfo.Remark = strRemark;//"EP币发货";
            journalInfo.RemarkEn = "Gold coin receipt!";
            journalInfo.InAmount = dAccount;
            journalInfo.OutAmount = 0;
            journalInfo.BalanceAmount = userInfo.Emoney;//EP币收货！
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = JournalType;
            journalInfo.Journal01 = iSUserID;

            #endregion

            journalBLL.Add(journalInfo);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public CashSellInfoModel SellTableToModel(DataTable dt)
        {
            int n = 0;
            CashSellInfoModel model = new CashSellInfoModel();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                {
                    model.OrderID = dt.Rows[n]["OrderID"].ToString();
                }
                if (dt.Rows[n]["OrderCode"] != null && dt.Rows[n]["OrderCode"].ToString() != "")
                {
                    model.OrderCode = dt.Rows[n]["OrderCode"].ToString();
                }
                if (dt.Rows[n]["Total"] != null && dt.Rows[n]["Total"].ToString() != "")
                {
                    model.Total = dt.Rows[n]["Total"].ToString();
                }
                if (dt.Rows[n]["SaleNum"] != null && dt.Rows[n]["SaleNum"].ToString() != "")
                {
                    model.SaleNum = dt.Rows[n]["SaleNum"].ToString();
                }
                if (dt.Rows[n]["FrozenNum"] != null && dt.Rows[n]["FrozenNum"].ToString() != "")
                {
                    model.FrozenNum = dt.Rows[n]["FrozenNum"].ToString();
                }
                if (dt.Rows[n]["BanlanceNum"] != null && dt.Rows[n]["BanlanceNum"].ToString() != "")
                {
                    model.BanlanceNum = dt.Rows[n]["BanlanceNum"].ToString();
                }

                if (dt.Rows[n]["TotalBond"] != null && dt.Rows[n]["TotalBond"].ToString() != "")
                {
                    model.TotalBond = dt.Rows[n]["TotalBond"].ToString();
                }

                if (dt.Rows[n]["BalanceBond"] != null && dt.Rows[n]["BalanceBond"].ToString() != "")
                {
                    model.BalanceBond = dt.Rows[n]["BalanceBond"].ToString();
                }
                if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                {
                    model.Status = dt.Rows[n]["Status"].ToString();
                    model.StatusText = Enum.GetName(typeof(Library.Enums.CashSellStatusTypes), int.Parse(model.Status));
                }
            }

            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CashSellInfoModel> SellTableToList(DataTable dt)
        {
            List<CashSellInfoModel> modelList = new List<CashSellInfoModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CashSellInfoModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CashSellInfoModel();
                    if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = dt.Rows[n]["OrderID"].ToString();
                    }
                    if (dt.Rows[n]["OrderCode"] != null && dt.Rows[n]["OrderCode"].ToString() != "")
                    {
                        model.OrderCode = dt.Rows[n]["OrderCode"].ToString();
                    }
                    if (dt.Rows[n]["Total"] != null && dt.Rows[n]["Total"].ToString() != "")
                    {
                        model.Total = dt.Rows[n]["Total"].ToString();
                    }
                    if (dt.Rows[n]["SaleNum"] != null && dt.Rows[n]["SaleNum"].ToString() != "")
                    {
                        model.SaleNum = dt.Rows[n]["SaleNum"].ToString();
                    }
                    if (dt.Rows[n]["FrozenNum"] != null && dt.Rows[n]["FrozenNum"].ToString() != "")
                    {
                        model.FrozenNum = dt.Rows[n]["FrozenNum"].ToString();
                    }
                    if (dt.Rows[n]["BanlanceNum"] != null && dt.Rows[n]["BanlanceNum"].ToString() != "")
                    {
                        model.BanlanceNum = dt.Rows[n]["BanlanceNum"].ToString();
                    }

                    if (dt.Rows[n]["TotalBond"] != null && dt.Rows[n]["TotalBond"].ToString() != "")
                    {
                        model.TotalBond = dt.Rows[n]["TotalBond"].ToString();
                    }

                    if (dt.Rows[n]["BalanceBond"] != null && dt.Rows[n]["BalanceBond"].ToString() != "")
                    {
                        model.BalanceBond = dt.Rows[n]["BalanceBond"].ToString();
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = dt.Rows[n]["Status"].ToString();
                    }
                    if (dt.Rows[n]["SellDate"] != null && dt.Rows[n]["SellDate"].ToString() != "")
                    {
                        model.SellDate =DateTime.Parse((dt.Rows[n]["SellDate"].ToString()));
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.StatusText = GetSellStatus(int.Parse(dt.Rows[n]["Status"].ToString()));
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        //撤销挂卖订单
        public bool SellOrderCancel(long userid, long orderid, out string message)
        {
            string strWhere = "UserID=" + userid + " and CashsellID = " + orderid;
            var dt = cashsellBLL.GetOrderList(strWhere);
            var cashsellinfo = SellTableToList(dt.Tables[0]).FirstOrDefault();

            if (cashsellinfo == null)
            {
                message = "订单不存在";
                return false;
            }
            var user = userBLL.GetModel(userid);
            if (user.IsLock == 1)
            {
                message = "账户已冻结，撤销挂卖订单失败";
                return false;
            }
            if ( cashsellinfo.Status.Equals("0") )
            {
 
              //  lgk.Model.Cashsell cashsellInfo = cashsellBLL.GetOrderList(cashorderInfo.CashbuyID);
                decimal dAccount = decimal.Parse(cashsellinfo.Total);// * cashorderInfo.;//每件数量*件数
                decimal dFactorage = decimal.Parse(cashsellinfo.TotalBond);//
                //decimal dFactorage = cashbuyInfo.Number * getParamAmount("Gold2") / 100;//手续费
                decimal dTotal = dAccount + dFactorage;

                string strRemark = "卖家已取消";
                var sell = cashsellBLL.GetModel(orderid);
                sell.IsUndo = 1;
                cashsellBLL.Update(sell);

                cashorderBLL.Update(strRemark, orderid, userid, 2);
                UpdateAccount("BonusAccount", userid, dTotal, 1);//终止交易，将EP币返还卖家

                SetAccount(userid, dTotal, strRemark, (int)Library.AccountType.交易钱包);

                lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
                lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
                log.LogMsg = "卖家已取消订单【" + cashsellinfo.OrderCode + "】";
                log.LogType = 24;//
                log.LogLeve = 0;//
                log.LogDate = DateTime.Now;
                log.LogCode = "卖家已取消订单";//
                log.IsDeleted = 0;
                log.Log1 = userid.ToString();//用户UserID
                log.Log2 = "";// BrowserHelper.UserHostIP(this.Page);
                log.Log3 = "";//BrowserHelper.UserHostName();
                log.Log4 = "";
                syslogBLL.Add(log);

                message = "卖家取消成功！";
                return true;
            }

            message = "该订单不能撤销";
            return false;
        }

        //撤销买入订单
        public bool BuyOrderCancel(long userid, long orderid, out string message)
        {
            string strRemark = "";
            decimal dAccount = Convert.ToDecimal(0.00);
            lgk.Model.Cashorder cashorderInfo = cashorderBLL.GetModel(orderid);
            lgk.Model.Cashbuy cashbuyInfo = cashbuyBLL.GetModel(cashorderInfo.CashbuyID);

            var user = userBLL.GetModel(userid);
            if (user.IsLock == 1)
            {
                message = "账户已冻结，撤销买入订单失败";
                return false;
            }

            strRemark = "买家已取消";

            //加入流水账表
            if (userid == cashorderInfo.BUserID && cashorderInfo.BStatus == 0)
            {
                cashorderBLL.UndoOrder(orderid, strRemark);//买家撤销订单
                lgk.Model.Cashsell cashsellInfo = cashsellBLL.GetModel(cashorderInfo.CashsellID);
                cashsellInfo.SaleNum = cashsellInfo.SaleNum - cashbuyInfo.BuyNum; //减掉购买的金额,卖方继续挂卖
                cashsellBLL.Update(cashsellInfo);

                cashbuyInfo.IsBuy = -1;//买家已取消
                cashbuyBLL.Update(cashbuyInfo);

                lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
                lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
                log.LogMsg = "买家已取消订单【" + cashorderInfo.OrderCode + "】";
                log.LogType = 23;//
                log.LogLeve = 0;//
                log.LogDate = DateTime.Now;
                log.LogCode = "买家已取消订单";//
                log.IsDeleted = 0;
                log.Log1 = cashorderInfo.BUserID.ToString();//用户UserID
                log.Log2 = ""; // BrowserHelper.UserHostIP(this.Page);
                log.Log3 = ""; //BrowserHelper.UserHostName();
                log.Log4 = "";
                syslogBLL.Add(log);

                message = "买家取消成功";
                return true;
            }

            message = "该订单不能撤销";
            return false;
        }
        /// <summary>
        /// 加入流水账表
        /// </summary>
        /// <param name="iUserID">用户编号</param>
        /// <param name="dAccount">终止交易货物数量</param>
        /// <param name="strRemark">备注(终止原因)</param>
        private void SetAccount(long iUserID, decimal dAccount, string strRemark, int JournalType)
        {
            #region 加入流水账表

            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
            lgk.Model.tb_user userInfo = userBLL.GetModel(iUserID);
            journalInfo.UserID = iUserID;
            journalInfo.Remark = strRemark;
            journalInfo.RemarkEn = "Trading halt!";
            journalInfo.InAmount = dAccount;
            journalInfo.OutAmount = 0;
            journalInfo.BalanceAmount = userInfo.BonusAccount + dAccount;
            journalInfo.JournalDate = DateTime.Now;
            journalInfo.JournalType = JournalType;
            journalInfo.Journal01 = iUserID;

            #endregion

            journalBLL.Add(journalInfo);
        }
        //收款账户
        public object GetSellBank(long bankid)
        {
            var bank = userBankBLL.GetModel(bankid);
            SortedDictionary<string, object> values = new SortedDictionary<string, object>();
            values.Add("BankName", bank.BankName);
            values.Add("BankAccount", bank.BankAccount);
            values.Add("BankAccountUser", bank.BankAccountUser);
            values.Add("AccountType", bank.Bank003);
            values.Add("Pic", string.IsNullOrEmpty(bank.Bank001) || bank.Bank001 == null? "":WebHelper.HttpDomain +  bank.Bank001);
            return values;
        }
    }
}