using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Web.APPService.Service
{
    public class BankAcountService : AllCore
    {
        //添加银行
        public bool Bank(long userid, string BankName, string BankAccount, string BankUser, string Defaults, string paypwd, string FromWhere, out string message)
        {
            if (BankValidate(userid, BankName, BankAccount, BankUser, Defaults, out message))
            {
                lgk.Model.tb_user userModel = userBLL.GetModel(userid);
                if(userModel == null)
                {
                    message = "用户ID不存在";
                    return false;
                }
                if (FromWhere == "pc")
                {
                    if (!ValidPassword(userModel.SecondPassword, paypwd))
                    {
                        message = "交易密码错误";
                        return false;
                    }
                }

                if (Defaults == "1")
                {
                    userBankBLL.UpdateDefaults(userid);
                }
                
                lgk.Model.tb_UserBank userbankInfo = new lgk.Model.tb_UserBank();

                userbankInfo.UserID = Convert.ToInt32(userid);
                userbankInfo.BankName = BankName;
                userbankInfo.BankAccount = BankAccount;
                userbankInfo.BankAccountUser = BankUser;
                userbankInfo.MasterType = Convert.ToInt32(Defaults);
                userbankInfo.Bank003 = 1;
                userbankInfo.Bank004 = 0;
                if (userBankBLL.Add(userbankInfo) > 0)
                {
                    message = "添加成功";
                    return true;
                }
                else
                {
                    message = "添加失败";
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
        private bool BankValidate(long userid, string BankName, string BankAccount, string BankUser, string Defaults, out string message)
        {
            lgk.Model.tb_UserBank userbankInfo = new lgk.Model.tb_UserBank();
            if (BankName.Trim() == "")
            {
                message = "请输入银行卡名称";
            }
            if (BankAccount.Trim() == "")
            {
                message = "请输入银行账号";
            }
            if (BankUser.Trim() == "")
            {
                message = "请输入持卡人姓名";
            }
            message = "";
            return true;
        }
        //银行卡列表
        public List<BankModel> BankList(long userid)
        {
            string strWhere1 = " Bank004 = 0 and Bank003=1 and UserID=" + userid;

            var dt = userBankBLL.GetList(strWhere1);

            return DataBankList(dt.Tables[0]);
        }
        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BankModel> DataBankList(DataTable dt)
        {
            List<BankModel> modelList = new List<BankModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BankModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BankModel();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.BankID = dt.Rows[n]["ID"].ToString();
                    }
                    if (dt.Rows[n]["BankName"] != null && dt.Rows[n]["BankName"].ToString() != "")
                    {
                        model.BankName = dt.Rows[n]["BankName"].ToString();
                    }
                    if (dt.Rows[n]["BankAccount"] != null && dt.Rows[n]["BankAccount"].ToString() != "")
                    {
                        model.BankAccount = dt.Rows[n]["BankAccount"].ToString();
                    }
                    if (dt.Rows[n]["BankAccountUser"] != null && dt.Rows[n]["BankAccountUser"].ToString() != "")
                    {
                        model.BankAccountUser = dt.Rows[n]["BankAccountUser"].ToString();
                    }
                    if (dt.Rows[n]["MasterType"] != null && dt.Rows[n]["MasterType"].ToString() != "")
                    {
                        model.MasterType = dt.Rows[n]["MasterType"].ToString();
                    }
                    if (dt.Rows[n]["Bank003"] != null && dt.Rows[n]["Bank003"].ToString() != "")
                    {
                        model.AccountType = dt.Rows[n]["Bank003"].ToString();
                    }
                    if (dt.Rows[n]["Bank001"] != null && dt.Rows[n]["Bank001"].ToString() != "")
                    {
                        model.Pic = WebHelper.HttpDomain + dt.Rows[n]["Bank001"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        //绑定微信,支付宝
        public bool AlipayWeixin(long userid, string nickname, string accounts, string states, string defaults, string picpath, string paypwd, string fromwhere, out string message)
        {
            if (AlipayValidate(userid, nickname, accounts, states, out message))
            {
                lgk.Model.tb_user userModel = userBLL.GetModel(userid);
                if (GetUserCode(userid) == "")
                {
                    message = "用户ID不存在";
                    return false;
                }
                if (fromwhere == "pc")
                {
                    if (!ValidPassword(userModel.SecondPassword, paypwd))
                    {
                        message = "交易密码错误";
                        return false;
                    }
                }
                if (defaults == "1")
                {
                    userBankBLL.UpdateDefaults(userid);
                }

                lgk.Model.tb_UserBank userbankInfo = new lgk.Model.tb_UserBank();

                userbankInfo.UserID = Convert.ToInt32(userid);
                userbankInfo.BankName = nickname;
                userbankInfo.BankAccount = accounts;
                userbankInfo.Bank003 = Convert.ToInt32(states);
                userbankInfo.MasterType = defaults == "1" ? 1 : 0;
                userbankInfo.Bank004 = 0;
                userbankInfo.Bank001 = picpath;
                if (userBankBLL.Add(userbankInfo) > 0)
                {
                    message = "绑定成功";
                    return true;
                }
                else
                {
                    message = "绑定失败";
                    return false;
                }
            }
            else
                return false;
        }
        //钱包地址
        public bool BagAddress(long userid,string accountname, string accounts, string defaults,  string paypwd, string fromwhere, out string message)
        {
            if (BagAddressValidate(userid, accountname,accounts, out message))
            {
                lgk.Model.tb_user userModel = userBLL.GetModel(userid);
                if (GetUserCode(userid) == "")
                {
                    message = "用户ID不存在";
                    return false;
                }
                if (fromwhere == "pc")
                {
                    if (!ValidPassword(userModel.SecondPassword, paypwd))
                    {
                        message = "交易密码错误";
                        return false;
                    }
                }
                if (defaults == "1")
                {
                    userBankBLL.UpdateDefaults(userid);
                }

                lgk.Model.tb_UserBank userbankInfo = new lgk.Model.tb_UserBank();

                userbankInfo.UserID = Convert.ToInt32(userid);
                userbankInfo.BankName = accountname; //钱包名称
                userbankInfo.BankAccount = accounts;
                userbankInfo.Bank003 =4;
                userbankInfo.MasterType = defaults == "1" ? 1 : 0;
                userbankInfo.Bank004 = 0;
                userbankInfo.Bank001 = "";
                if (userBankBLL.Add(userbankInfo) > 0)
                {
                    message = "绑定成功";
                    return true;
                }
                else
                {
                    message = "绑定失败";
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
        private bool AlipayValidate(long userid, string nickname, string accounts, string states, out string message)
        {
            // lgk.Model.tb_UserBank userbankInfo = new lgk.Model.tb_UserBank();
            if (states == "2")
            {
                if (nickname.Trim() == "")
                {
                    message = "请输入支付宝昵称";
                }
                if (accounts.Trim() == "")
                {
                    message = "请输入支付宝账号";
                }
            }
            if (states == "3")
            {
                if (nickname.Trim() == "")
                {
                    message = "请输入微信昵称";
                }
                if (accounts.Trim() == "")
                {
                    message = "请输入微信账号";
                }
            }
            
            message = "";
            return true;
        }/// <summary>
         /// 输入验证
         /// </summary>
         /// <returns></returns>
        private bool BagAddressValidate(long userid,string accountname, string accounts, out string message)
        {
            if (accountname.Trim() == "")
            {
                message = "请输入钱包名称";
            }
            if (accounts.Trim() == "")
            {
                message = "请输入钱包地址";
            }

            message = "";
            return true;
        }
        //取消银行卡
        public bool BankCard(long userid, long bankid, out string message)
        {
            lgk.Model.tb_UserBank userbankInfo = userBankBLL.GetModel(bankid);
            if (userbankInfo == null)
            {
                message = "该记录已删除，无法再进行此操作!";
                return false;
            }
            if (userbankInfo.Bank004 != 0)
            {
                message = "该记录已审核，无法再进行此操作!";
                return false;
            }

            bool isDefault = userbankInfo.MasterType == 1;//是否删除的市默认的记录

            if (userBankBLL.UpdateBank(Convert.ToInt64(userid), Convert.ToInt64(bankid)) > 0)
            {
                if (isDefault) userBankBLL.AutoSetDefault(userid); //自动设置默认
                message = GetLanguage("CancellationSuccess");//取消成功
                return true;
            }
            else
            {
                message = GetLanguage("FailedToCancel");//取消失败
                return false;
            }
        }
        //设置默认
        public bool SetDefault(long userid, long bankid, out string message)
        {
            if (userBankBLL.SetDefault(userid, bankid) > 0)
            {
                message = "设置默认成功";
                return true;
            }
            else
            {
                message = "设置默认失败";
                return false;
            }
        }
        
        public BankTypeListModel GetBankTypeList(long userid)
        {
            BankTypeListModel model = new BankTypeListModel();
            List<BankTypeModel> mlist = new List<BankTypeModel>();
            for (int i=1; i<=1; i++)
            {
                BankTypeModel banktypemodel = new BankTypeModel();
                banktypemodel.AccountType = i;
                banktypemodel.AccountTypeName = AccountTypeName(i);
                mlist.Add(banktypemodel);
            }
            model.list = mlist;
            model.bankList = banknameBLL.GetModelList("");
            model.provinceList = provinceBLL.GetModelList("");
            model.userbankList = BankList(userid);
            return model;
        }

        public string AccountTypeName(int TypeID)
        {
            string strname = "";
            if(TypeID == 1)
            {
                strname = "银行卡";
            }
            //else if (TypeID == 2)
            //{
            //    strname = "微信";
            //}
            //else if (TypeID == 3)
            //{
            //    strname = "支付宝";
            //}
            //else if (TypeID == 4)
            //{
            //    strname = "数字钱包地址";
            //}
            return strname;
        }

    }
}