using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library;
using lgk.BLL;
using System.Data;

namespace Web.APPService.Service
{
    public class TransferService : AllCore
    {
        public bool Transfer(long userid, string toUserCode, string txtMoney, string dropCurrency, string Phone, string paypassword, out string message)
        {
            if (RegValidate(userid, toUserCode, txtMoney, dropCurrency, Phone, paypassword, out message))
            {
                long toUserID = 0;
                decimal fee = 0, balance = 0;
                lgk.Model.tb_user userInfo = userBLL.GetModel(userid);
                if (userInfo.IsLock == 1)
                {
                    message = "账户已冻结，转账失败";
                    return false;
                }
                lgk.Model.tb_user touserInfo = userBLL.GetModelByUserCode(toUserCode.Trim());
                if (touserInfo == null)
                {
                    message = "接收账户不存在";
                    return false;
                }
                toUserID = touserInfo.UserID;

                lgk.Model.tb_change changeInfo = new lgk.Model.tb_change();

                changeInfo.UserID = userInfo.UserID;
                changeInfo.ToUserID = toUserID;
                changeInfo.ToUserType = 0;
                changeInfo.MoneyType = 0;
                changeInfo.Amount = decimal.Parse(txtMoney);
                changeInfo.ChangeType = Convert.ToInt32(dropCurrency);
                changeInfo.Change003 = Util.CreateNo();//订单号
                changeInfo.ChangeDate = DateTime.Now;
                //if (dropCurrency != "3")
                //{
                    changeInfo.Change005 = changeInfo.Amount - changeInfo.Amount * getParamAmount("Transfer3") / 100;  //到账金额
                    changeInfo.Change006 = getParamAmount("Transfer3");// 转账手续费
                //}
                //else
                //{
                //    changeInfo.Change006 = getParamAmount("TransferRateBTE");//释放币转换注册币比例 
                //    changeInfo.Change005 = Math.Round(changeInfo.Amount / getParamAmount("TransferRateBTE"), 2);  //释放币转换注册币比例  ,Change005 释放币，Amount 注册币
                //}
                if (changeBLL.Add(changeInfo) > 0)
                {
                    try
                    {
                        if (changeInfo.ChangeType == 1)//原始币转给其他会员
                        {
                            #region 原始币转给其他会员
                            decimal dBonusAccount = userBLL.GetMoney(userid, "Emoney ");
                            if (dBonusAccount >= changeInfo.Amount)
                            {
                                UpdateAccount("Emoney ", userInfo.UserID, changeInfo.Amount, 0);//
                                UpdateAccount("Emoney ", toUserID, changeInfo.Change005, 1);//

                                balance = userBLL.GetMoney(userid, "Emoney ");
                                fee = changeInfo.Amount - changeInfo.Change005;
                                //加入流水账表（佣金币减少）
                                lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                                jmodel.UserID = userInfo.UserID;
                                jmodel.Remark = "原始币转给" + toUserCode;
                                jmodel.RemarkEn = "Currency to shopping currency";
                                jmodel.InAmount = 0;
                                jmodel.OutAmount = changeInfo.Change005;
                                jmodel.BalanceAmount = balance + fee;
                                jmodel.JournalDate = DateTime.Now;
                                jmodel.JournalType = 1;
                                jmodel.Journal01 = toUserID;
                                journalBLL.Add(jmodel);

                                //转账手续费
                                if (fee > 0)
                                {
                                    lgk.Model.tb_journal jmodelfee = new lgk.Model.tb_journal();
                                    jmodelfee.UserID = userInfo.UserID;
                                    jmodelfee.Remark = "原始币转给" + toUserCode + ",手续费";
                                    jmodelfee.RemarkEn = "Currency to shopping currency";
                                    jmodelfee.InAmount = 0;
                                    jmodelfee.OutAmount = fee;
                                    jmodelfee.BalanceAmount = balance;
                                    jmodelfee.JournalDate = DateTime.Now;
                                    jmodelfee.JournalType = 1;
                                    jmodelfee.Journal01 = toUserID;
                                    journalBLL.Add(jmodelfee);
                                }

                                //加入流水账表(现金币增加)
                                lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                                journalInfo.UserID = toUserID;
                                journalInfo.Remark = "获得" + userInfo.UserCode + "转来原始币";
                                journalInfo.RemarkEn = "Currency to shopping currency";
                                journalInfo.InAmount = changeInfo.Change005;
                                journalInfo.OutAmount = 0;
                                journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "Emoney ");
                                journalInfo.JournalDate = DateTime.Now;
                                journalInfo.JournalType = 1;
                                journalInfo.Journal01 = userInfo.UserID;
                                journalBLL.Add(journalInfo);
                            }
                            else
                            {
                                message = GetLanguage("objectExist");//转帐对象不存在

                            }
                            #endregion
                        }
                        else if (changeInfo.ChangeType == 2)//释放币转给其他会员
                        {
                            #region 释放币转给其他会员
                            decimal dBonusAccount = userBLL.GetMoney(userid, "BonusAccount ");
                            if (dBonusAccount >= changeInfo.Amount)
                            {
                                UpdateAccount("BonusAccount ", userInfo.UserID, changeInfo.Amount, 0);//
                                UpdateAccount("BonusAccount ", toUserID, changeInfo.Change005, 1);//

                                balance = userBLL.GetMoney(userid, "BonusAccount ");
                                fee = changeInfo.Amount - changeInfo.Change005;
                                //加入流水账表（佣金币减少）
                                lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                                jmodel.UserID = userInfo.UserID;
                                jmodel.Remark = "释放币转给" + toUserCode;
                                jmodel.RemarkEn = "Currency to shopping currency";
                                jmodel.InAmount = 0;
                                jmodel.OutAmount = changeInfo.Change005;
                                jmodel.BalanceAmount = balance + fee;
                                jmodel.JournalDate = DateTime.Now;
                                jmodel.JournalType = 2;
                                jmodel.Journal01 = toUserID;
                                journalBLL.Add(jmodel);

                                //转账手续费
                                if (fee > 0)
                                {
                                    lgk.Model.tb_journal jmodelfee = new lgk.Model.tb_journal();
                                    jmodelfee.UserID = userInfo.UserID;
                                    jmodelfee.Remark = "释放币转给" + toUserCode + ",手续费";
                                    jmodelfee.RemarkEn = "Currency to shopping currency";
                                    jmodelfee.InAmount = 0;
                                    jmodelfee.OutAmount = fee;
                                    jmodelfee.BalanceAmount = balance;
                                    jmodelfee.JournalDate = DateTime.Now;
                                    jmodelfee.JournalType = 2;
                                    jmodelfee.Journal01 = toUserID;
                                    journalBLL.Add(jmodelfee);
                                }

                                //加入流水账表(现金币增加)
                                lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                                journalInfo.UserID = toUserID;
                                journalInfo.Remark = "获得" + userInfo.UserCode + "转来释放币";
                                journalInfo.RemarkEn = "Currency to shopping currency";
                                journalInfo.InAmount = changeInfo.Change005;
                                journalInfo.OutAmount = 0;
                                journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "BonusAccount ");
                                journalInfo.JournalDate = DateTime.Now;
                                journalInfo.JournalType = 2;
                                journalInfo.Journal01 = userInfo.UserID;
                                journalBLL.Add(journalInfo);

                                //如果冻结释放币账户大于0，激活矿机时转入明细
                                if (touserInfo.User016 > 0)
                                {
                                    UpdateAccount("User016", toUserID, touserInfo.User016, 0);//
                                    UpdateAccount("BonusAccount", toUserID, touserInfo.User016, 1);//

                                    lgk.Model.tb_journal jourInfo = new lgk.Model.tb_journal();
                                    jourInfo.UserID = touserInfo.UserID;
                                    jourInfo.Remark = "释放币账户进账，冻结释放币转入释放币账户";
                                    jourInfo.RemarkEn = "Cash withdrawal";
                                    jourInfo.InAmount = touserInfo.User016;
                                    jourInfo.OutAmount = 0;
                                    jourInfo.BalanceAmount = userBLL.GetMoney(toUserID, "BonusAccount");
                                    jourInfo.JournalDate = DateTime.Now;
                                    jourInfo.JournalType = 2;
                                    jourInfo.Journal01 = touserInfo.UserID;
                                    journalBLL.Add(jourInfo);
                                }
                            }
                            else
                            {
                                message = GetLanguage("objectExist");//转帐对象不存在

                            }
                            #endregion
                        }
                        else if (changeInfo.ChangeType == 3)//智能钱包转给其他会员
                        {
                            #region 释放币转给其他会员
                            decimal dBonusAccount = userBLL.GetMoney(userid, "User018 ");
                            if (dBonusAccount >= changeInfo.Amount)
                            {
                                UpdateAccount("User018 ", userInfo.UserID, changeInfo.Amount, 0);//
                                UpdateAccount("User018 ", toUserID, changeInfo.Change005, 1);//

                                balance = userBLL.GetMoney(userid, "User018 ");
                                fee = changeInfo.Amount - changeInfo.Change005;
                                //加入流水账表（佣金币减少）
                                lgk.Model.tb_journal jmodel = new lgk.Model.tb_journal();
                                jmodel.UserID = userInfo.UserID;
                                jmodel.Remark = "智能钱包转给" + toUserCode;
                                jmodel.RemarkEn = "Currency to shopping currency";
                                jmodel.InAmount = 0;
                                jmodel.OutAmount = changeInfo.Change005;
                                jmodel.BalanceAmount = balance + fee;
                                jmodel.JournalDate = DateTime.Now;
                                jmodel.JournalType = 3;
                                jmodel.Journal01 = toUserID;
                                journalBLL.Add(jmodel);

                                //转账手续费
                                if (fee > 0)
                                {
                                    lgk.Model.tb_journal jmodelfee = new lgk.Model.tb_journal();
                                    jmodelfee.UserID = userInfo.UserID;
                                    jmodelfee.Remark = "智能钱包转给" + toUserCode + ",手续费";
                                    jmodelfee.RemarkEn = "Currency to shopping currency";
                                    jmodelfee.InAmount = 0;
                                    jmodelfee.OutAmount = fee;
                                    jmodelfee.BalanceAmount = balance;
                                    jmodelfee.JournalDate = DateTime.Now;
                                    jmodelfee.JournalType = 3;
                                    jmodelfee.Journal01 = toUserID;
                                    journalBLL.Add(jmodelfee);
                                }
                                //加入流水账表(现金币增加)
                                lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                                journalInfo.UserID = toUserID;
                                journalInfo.Remark = "获得" + userInfo.UserCode + "转来智能钱包";
                                journalInfo.RemarkEn = "Currency to shopping currency";
                                journalInfo.InAmount = changeInfo.Change005;
                                journalInfo.OutAmount = 0;
                                journalInfo.BalanceAmount = userBLL.GetMoney(toUserID, "User018 ");
                                journalInfo.JournalDate = DateTime.Now;
                                journalInfo.JournalType = 3;
                                journalInfo.Journal01 = userInfo.UserID;
                                journalBLL.Add(journalInfo);
                            }
                            else
                            {
                                message = GetLanguage("objectExist");//转帐对象不存在
                            }
                            #endregion
                        }
                    }
                    catch
                    {
                        message = GetLanguage("addError");//添加流水账错误


                    }
                    message = GetLanguage("TransferSuccess");//转账成功


                }
                else
                {
                    message = GetLanguage("addError");//操作失败


                }
                return true;
            }
            else
                return false;
        }



        /// <summary>
        /// 输入验证
        /// </summary>
        /// <returns></returns>
        private bool RegValidate(long userid, string toUserCode, string txtMoney, string dropCurrency, string Phone, string paypassword, out string message)
        {
            long toUserID = 0;
            decimal dResult;
            lgk.Model.tb_user userInfo = userBLL.GetModel(userid);

            lgk.Model.tb_change changeInfo = new lgk.Model.tb_change();
            if (userInfo == null)
            {
                message = "会员不存在";
                return false;
            }
            
            if (!ValidPassword(userInfo.SecondPassword, paypassword))
            {
                message = "支付密码错误";
                return false;
            }

            if (txtMoney.Trim() == "")
            {
                message = GetLanguage("transferMoneyIsnull");//转账金额不能为空

                return false;
            }
            //if (Phone.Trim() == "")
            //{
            //    message = GetLanguage("Phoneempty");//手机号不能为空

            //    return false;
            //}
            dResult = 0;
            if (decimal.TryParse(txtMoney.Trim(), out dResult))
            {
                decimal dTrans = getParamAmount("Transfer1");//转账最低金额
                decimal d = getParamAmount("Transfer2");//转账倍数基数
                if (dResult < dTrans)
                {
                    message = GetLanguage("equalTo") + dTrans;//转账金额必须是大于等于XX的整数

                    return false;
                }
                if (d != 0 && dResult % d != 0)
                {
                    message = GetLanguage("amountMustbe") + d + GetLanguage("Multiples");//转账金额必须是XX的倍数

                    return false;
                }
            }
            if (dropCurrency == "1")
            {
                if (dResult > userInfo.Emoney)
                {
                    message = GetLanguage("NotRegistered"); //注册币余额不足
                    return false;
                }
            }
            else if (dropCurrency == "3")
            {
                // if (Math.Round(dResult / getParamAmount("TransferRateBTE"), 2) > userInfo.BonusAccount)
                if (dResult > userInfo.User018)
                {
                    message = "智能钱包余额不足"; //智能钱包余额不足
                    return false;
                }
            }
            else
            {
                if (dResult > userInfo.BonusAccount)
                {
                    message = GetLanguage("NotCurrency"); //释放币余额不足
                    return false;
                }
            }

          //  if (dropCurrency != "3") //转给其他会员
            {
                lgk.Model.tb_user touserInfo = userBLL.GetModel(userBLL.GetUserID(toUserCode.Trim()));

                string strUserCode = userInfo.UserCode;

                if (touserInfo == null)
                {
                    message = GetLanguage("numberIsExist");//会员编号不存在
                    return false;
                }
                else
                {
                    toUserID = int.Parse(touserInfo.UserID.ToString());
                }

                if (toUserID <= 0)
                {
                    message = GetLanguage("objectExist");//转帐对象不存在

                    return false;
                }
                if (toUserID == userInfo.UserID)
                {
                    message = GetLanguage("TransferToOuner");//不能给自己转账
                    return false;
                }

            }
            message = "";
            return true;

        }
        //转账列表
        public List<TransferModel> TransferModelList(long userid)
        {
            //lgk.Model.tb_user userInfo = userBLL.GetModel(userid);

            string strWhere1 = userid.ToString();
            var dt = changeBLL.GetDataSet(strWhere1);

            return DataTableToList(dt.Tables[0]);
        }
        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TransferModel> DataTableToList(DataTable dt)
        {
            List<TransferModel> modelList = new List<TransferModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TransferModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TransferModel();
                    if (dt.Rows[n]["UserCode"] != null && dt.Rows[n]["UserCode"].ToString() != "")
                    {
                        model.UserCode = dt.Rows[n]["UserCode"].ToString();
                    }
                    if (dt.Rows[n]["TrueName"] != null && dt.Rows[n]["TrueName"].ToString() != "")
                    {
                        model.TrueName = dt.Rows[n]["TrueName"].ToString();
                    }
                    if (dt.Rows[n]["ChangeType"] != null && dt.Rows[n]["ChangeType"].ToString() != "")
                    {
                        model.ChangeType = dt.Rows[n]["ChangeType"].ToString();
                    }
                    if (dt.Rows[n]["Amount"] != null && dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = dt.Rows[n]["Amount"].ToString();
                    }
                    if (dt.Rows[n]["ChangeDate"] != null && dt.Rows[n]["ChangeDate"].ToString() != "")
                    {
                        model.ChangeDate = DateTime.Parse(dt.Rows[n]["ChangeDate"].ToString());
                    }
                    if (dt.Rows[n]["Change003"] != null && dt.Rows[n]["Change003"].ToString() != "")
                    {
                        model.OrderCode = dt.Rows[n]["Change003"].ToString();
                    }
                    if (dt.Rows[n]["Currency"] != null && dt.Rows[n]["Currency"].ToString() != "")
                    {
                        model.Currency = dt.Rows[n]["Currency"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
    }
}
