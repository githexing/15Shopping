using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web.APPService.ViewModel;

namespace Web.APPService.Service
{
    public class TakeMoneyService : AllCore
    {
        public bool TakeMoney(long UserID, string Currency, string ExtMoney,string BankID, string paypassword,out string message)
        {
            if (TakeMoneyValidate(UserID, Currency, ExtMoney, BankID, out message))
            {
                #region 提现申请
               
              
               
                var user = userBLL.GetModel(UserID);
                if (user == null)
                {
                    message = "用户ID不存在";
                    return false;
                }
                
                if (!ValidPassword(user.SecondPassword, paypassword))
                {
                    message = "支付密码错误";
                    return false;
                }

                if (user.IsLock == 1)
                {
                    message = "账户已冻结，提现失败";
                    return false;
                }

                int JournalType = 0;
                int _id = 0;
                 int.TryParse(BankID, out _id);
                var userbank = userBankBLL.GetModel(Convert.ToInt32(_id));
                if (user == null)
                {
                    message = "银行账户ID不存在";
                    return false;
                }
                lgk.Model.tb_takeMoney takeMoneyInfo = new lgk.Model.tb_takeMoney();
                decimal dMoney = decimal.Parse(ExtMoney);
                takeMoneyInfo.TakeTime = DateTime.Now;
                takeMoneyInfo.TakeMoney = dMoney;
                takeMoneyInfo.Flag = 0;
                takeMoneyInfo.UserID = UserID;
                if (Currency.Trim() == "1")
                {
                    takeMoneyInfo.TakePoundage = dMoney * getParamAmount("ATM3") / 100;
                    takeMoneyInfo.RealityMoney = dMoney;// - takeMoneyInfo.TakePoundage;
                    takeMoneyInfo.BonusBalance = user.Emoney - takeMoneyInfo.TakeMoney;
                    JournalType = 1;
                }
                if (Currency.Trim() == "2")
                {
                    takeMoneyInfo.TakePoundage = dMoney * getParamAmount("ATM3") / 100;
                    takeMoneyInfo.RealityMoney = dMoney;// - takeMoneyInfo.TakePoundage;
                    takeMoneyInfo.BonusBalance = user.BonusAccount - takeMoneyInfo.TakeMoney;
                    JournalType = 1;
                }

                takeMoneyInfo.Take001 = Currency == "2" ? 2 : 1; //提现类型
                takeMoneyInfo.Take002 = _id;

                #endregion

                #region 加入流水账表

                lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                journalInfo.UserID = takeMoneyInfo.UserID;
                journalInfo.Remark = Library.AccountTypeHelper.GetName(JournalType) + "提现";

                journalInfo.RemarkEn = "Cash withdrawal";
                journalInfo.InAmount = 0;
                journalInfo.OutAmount = takeMoneyInfo.TakeMoney;
                journalInfo.BalanceAmount = takeMoneyInfo.BonusBalance;
                journalInfo.JournalDate = DateTime.Now;
                journalInfo.JournalType = JournalType;
                journalInfo.Journal01 = takeMoneyInfo.UserID;
                journalBLL.Add(journalInfo);

                lgk.Model.tb_journal journalInfoFee = new lgk.Model.tb_journal();
                journalInfoFee.UserID = takeMoneyInfo.UserID;
                journalInfoFee.Remark = Library.AccountTypeHelper.GetName(JournalType) + "提现手续费";

                journalInfoFee.RemarkEn = "Cash withdrawal";
                journalInfoFee.InAmount = 0;
                journalInfoFee.OutAmount = takeMoneyInfo.TakePoundage;
                journalInfoFee.BalanceAmount = takeMoneyInfo.BonusBalance - takeMoneyInfo.TakePoundage;
                journalInfoFee.JournalDate = DateTime.Now;
                journalInfoFee.JournalType = JournalType;
                journalInfoFee.Journal01 = takeMoneyInfo.UserID;
                journalBLL.Add(journalInfoFee);

                #endregion
                if (takeBLL.Add(takeMoneyInfo) > 0 )
                 {
                    if (Currency.Trim() == "1")
                    {
                       UpdateAccount("Emoney", UserID, takeMoneyInfo.TakeMoney + takeMoneyInfo.TakePoundage, 0);
                    }
                    if (Currency.Trim() == "2")
                    {
                        UpdateAccount("BonusAccount", UserID, takeMoneyInfo.TakeMoney + takeMoneyInfo.TakePoundage, 0);
                    }

                    message = GetLanguage("successful");//申请提现成功
                    return true;
                }
                else
                {
                    message = GetLanguage("OperationFailed");//操作失败
                    return false;
                }

              

            }
            else
                return false;
        }
        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        private bool TakeMoneyValidate(long UserID, string Currency, string ExtMoney, string BankID, out string message)
        {
            lgk.Model.tb_takeMoney takeMoneyInfo = new lgk.Model.tb_takeMoney();
            lgk.Model.tb_user userInfo = userBLL.GetModel(UserID);

            if (BankID.Trim() == "")
            {
                message = "请输入收款账户编号";
                return false;
            }
            if (Currency.Trim() == "")
            {
                message = "请选择币种";
                return false;
            }
            if (ExtMoney.Trim() == "")
            {
                message = "请输入提现金额";
                return false;
            }
            decimal dMoney = 0;
            decimal tx_min = getParamAmount("ATM1");//最小提现额
            decimal tx_bs = getParamAmount("ATM2");//倍数基数
            if (decimal.TryParse(ExtMoney.Trim(), out dMoney))
            {
                if (dMoney < tx_min)
                {
                    message = GetLanguage("AmountThan") + tx_min + GetLanguage("TheInteger");//提现金额必须是大于等于XX的整数!
                    return false;
                }
                if (dMoney % tx_bs != 0)
                {
                    message = GetLanguage("amountMust") + tx_bs + GetLanguage("Multiples");//提现金额必须是" + tx_bs + "的倍数!
                    return false;
                }
            }
            else
            {
                message = GetLanguage("AmountErrors");//金额格式输入错误
                return false;
            }
            if (dMoney < tx_min)
            {
                message = GetLanguage("AmountThan") + tx_min;//提现金额必须是大于等于XX

                return false;
            }
            if (Currency.Trim() == "1")
            {
                if (dMoney > userInfo.Emoney)
                {
                    message = "提现金额不能大于原始币余额！";
                    return false;
                }
                if (dMoney + dMoney * getParamAmount("ATM3") / 100 > userInfo.Emoney)
                {
                    message = "原始币余额不够扣除手续费";
                    return false;
                }
                
            }
            else if (Currency.Trim() == "2")
            {
                if (dMoney > userInfo.BonusAccount)
                {
                    message = "提现金额不能大于释放币余额！";
                    return false;
                }
                if (dMoney + dMoney * getParamAmount("ATM3") / 100 > userInfo.BonusAccount)
                {
                    message = "释放币余额不够扣除手续费";
                    return false;
                }
            }
            message = "";
            return true;
        }
        //会员提现列表
        public List<TakeMoneyModel> TakeModelList(string id)
        {
            //lgk.Model.tb_user userInfo = userBLL.GetModel(userBLL.GetUserID(id.Trim()));
            string strWhere1 = "UserID = " + id;

            var dt = takeBLL.GetList(strWhere1);

            return DataTableToList(dt.Tables[0]);
        }
        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TakeMoneyModel> DataTableToList(DataTable dt)
        {
            List<TakeMoneyModel> modelList = new List<TakeMoneyModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TakeMoneyModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TakeMoneyModel();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.TakeID = dt.Rows[n]["ID"].ToString();
                    }
                    if (dt.Rows[n]["TakeMoney"] != null && dt.Rows[n]["TakeMoney"].ToString() != "")
                    {
                        model.TakeMoney = dt.Rows[n]["TakeMoney"].ToString();
                    }
                    if (dt.Rows[n]["TakePoundage"] != null && dt.Rows[n]["TakePoundage"].ToString() != "")
                    {
                        model.TakePoundage = dt.Rows[n]["TakePoundage"].ToString();
                    }
                    if (dt.Rows[n]["RealityMoney"] != null && dt.Rows[n]["RealityMoney"].ToString() != "")
                    {
                        model.RealityMoney = dt.Rows[n]["RealityMoney"].ToString();
                    }
                    if (dt.Rows[n]["TakeTime"] != null && dt.Rows[n]["TakeTime"].ToString() != "")
                    {
                        model.TakeTime = DateTime.Parse(dt.Rows[n]["TakeTime"].ToString());
                    }
                    if (dt.Rows[n]["Flag"] != null && dt.Rows[n]["Flag"].ToString() != "")
                    {
                        model.Flag = dt.Rows[n]["Flag"].ToString();
                    }
                    if (dt.Rows[n]["Take001"] != null && dt.Rows[n]["Take001"].ToString() != "")
                    {
                        model.AccountType = dt.Rows[n]["Take001"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        //取消会员提现
        public bool ItemCommand(long userid, long txid,string paypassword, out string message)
        {
            lgk.Model.tb_takeMoney takeMoneyInfo = takeBLL.GetModel(txid);
            if (takeMoneyInfo == null)
            {
                message = GetLanguage("recordDeleted");
                return false;
            }
            if (takeMoneyInfo.Flag != 0)
            {
                message = GetLanguage("recordApproved");
                return false;
            }
            //提现账户  1:原始币，2：原始积分
            int AccountType = takeMoneyInfo.Take001;

            lgk.Model.tb_user userInfo = userBLL.GetModel(takeMoneyInfo.UserID);
            
            if (!ValidPassword(userInfo.SecondPassword, paypassword))
            {
                message = "支付密码错误";
                return false;
            }
            if (userInfo.IsLock == 1)
            {
                message = "账户已冻结，取消提现失败";
                return false;
            }
            //加入流水账表
            lgk.Model.tb_journal model = new lgk.Model.tb_journal();
            model.UserID = takeMoneyInfo.UserID;
            model.Remark = "取消提现";
            model.InAmount = takeMoneyInfo.TakeMoney;
            model.OutAmount = 0;
            model.BalanceAmount = (AccountType == 1? userInfo.Emoney : userInfo.StockAccount) + takeMoneyInfo.TakeMoney;
            model.JournalDate = DateTime.Now;
            model.JournalType = (AccountType == 1 ? 1 : 2);
            model.Journal01 = takeMoneyInfo.UserID;

            //如果冻结释放币账户大于0，激活矿机时转入明细
            if (userInfo.User016 > 0)
            {
                UpdateAccount("User016", userInfo.UserID, userInfo.User016, 0);//
                UpdateAccount("BonusAccount", userInfo.UserID, userInfo.User016, 1);//

                lgk.Model.tb_journal jourInfo = new lgk.Model.tb_journal();
                jourInfo.UserID = userInfo.UserID;
                jourInfo.Remark = "释放币账户进账，冻结释放币转入释放币账户";
                jourInfo.RemarkEn = "Cash withdrawal";
                jourInfo.InAmount = userInfo.User016;
                jourInfo.OutAmount = 0;
                jourInfo.BalanceAmount = userBLL.GetMoney(userInfo.UserID, "BonusAccount");
                jourInfo.JournalDate = DateTime.Now;
                jourInfo.JournalType = 2;
                jourInfo.Journal01 = userInfo.UserID;
                journalBLL.Add(jourInfo);
            }
            
            if (journalBLL.Add(model) > 0 && takeBLL.UpdateFlag(Convert.ToInt64(userid), Convert.ToInt64(txid)) >0)
            {
                if (AccountType == 1)
                {
                    UpdateAccount("Emoney", takeMoneyInfo.UserID, takeMoneyInfo.TakeMoney, 1);
                }
                else if (AccountType == 2)
                {
                    UpdateAccount("StockAccount", takeMoneyInfo.UserID, takeMoneyInfo.TakeMoney, 1);
                }
                message = GetLanguage("CancellationSuccess");//取消成功
                return true;
            }
            else
            {
                message = GetLanguage("FailedToCancel");//取消失败
                return false;
            }
                
        }
            
     }

}
