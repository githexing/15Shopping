using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace Web.APPService.Service
{
    public class RemitServic : AllCore
    {
        //申请充值
        public bool Remit(long userid,string playid, string revenueid, string money,  string pictures, out string message)
        {
            if (money.Trim() == "")
            {
                message = "请输入充值金额";
                return false;

            }
            
            decimal jy = money.ToDecimal();

            string amount;

            if (jy <= 0)
            {
                message = "请输入有效的充值金额";
                return false;
            }
            amount = jy.ToString();
            if (PageValidate.IsNumberOrDecimal(amount))
            {
                decimal a = Convert.ToDecimal(amount);
                decimal remitMin = getParamAmount("RemitMin");
                if (Convert.ToDecimal(amount) < remitMin)
                {
                    message = "充值最小金额是" + remitMin;
                    return false;
                }
            }
            
            lgk.Model.tb_remit remitInfo = new lgk.Model.tb_remit();
            lgk.Model.tb_user userInfo = userBLL.GetModel(userid);
            if (userInfo.IsLock == 1)
            {
                message = "账户已冻结，申请充值失败";
                return false;
            }
            remitInfo.UserID = userid;
            remitInfo.RechargeableDate = DateTime.Now;//汇款时间
            remitInfo.State = 0;
            remitInfo.AddDate = DateTime.Now;
            remitInfo.RemitMoney = Convert.ToDecimal(jy.ToString("0.00"));  //注册币充值金额
            remitInfo.YuAmount = userInfo.Emoney + jy; //余额
            remitInfo.Remit004 = pictures.Trim();//凭证图片

            int _playid = playid.ToInt();
            int _revenueid = revenueid.ToInt();

            remitInfo.Remit001 = _playid;//打款id
            remitInfo.Remit002 = _revenueid;//收款id
            // 释放币：注册币（ 1：TransferRateBTE），释放币：人民币 （1：Exchange）
            //人民币 = 释放币 * 比例a
            //注册币 = 释放币 * 比例b
            //人民币 = 注册币 / 比例b * 比例a
            remitInfo.Remit006 = Math.Round(jy / getParamAmount("TransferRateBTE") * getParamAmount("Exchange") ,2); //四舍五入

            long iRemitID = remitBLL.Add(remitInfo);

            if (iRemitID > 0)
            {
                message = "申请充值成功！";
                return true;
            }
            else
            {
                message = "申请充值失败！";//操作失败
                return false;
            }

        }

        //申请充值
        public List<RemitModel> ApplyRemitList(long userid)
        {
            string strWhere = "UserID=" + userid;
            var dt = remitBLL.GetList(strWhere);
            return RemitList(dt.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RemitModel> RemitList(DataTable dt)
        {
            List<RemitModel> modelList = new List<RemitModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                RemitModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new RemitModel();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.RemitID = dt.Rows[n]["ID"].ToString();
                    }
                    if (dt.Rows[n]["AddDate"] != null && dt.Rows[n]["AddDate"].ToString() != "")
                    {
                        model.AddDate = dt.Rows[n]["AddDate"].ToString();
                    }
                    if (dt.Rows[n]["RemitMoney"] != null && dt.Rows[n]["RemitMoney"].ToString() != "")
                    {
                        model.RemitMoney = dt.Rows[n]["RemitMoney"].ToString();
                    }
                    if (dt.Rows[n]["State"] != null && dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = dt.Rows[n]["State"].ToString();
                    }
                    if (dt.Rows[n]["Remit006"] != null && dt.Rows[n]["Remit006"].ToString() != "")
                    {
                        model.PayMoney = dt.Rows[n]["Remit006"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        //申请充值详情
        public lgk.Model.tb_remit RemitInfo(long remitid)
        {
            return remitBLL.GetModel(remitid);
        }
        //打款帐户信息
        public lgk.Model.tb_UserBank UserBank(long id)
        {
            return userBankBLL.GetModel(id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RemitInfoModel> RemitInfoList(DataTable dt)
        {
            List<RemitInfoModel> remitList = new List<RemitInfoModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                RemitInfoModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new RemitInfoModel();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = dt.Rows[n]["ID"].ToString();
                    }
                    if (dt.Rows[n]["Remit001"] != null && dt.Rows[n]["Remit001"].ToString() != "")
                    {
                        model.Remit001 = dt.Rows[n]["Remit001"].ToString();
                    }
                    if (dt.Rows[n]["Remit002"] != null && dt.Rows[n]["Remit002"].ToString() != "")
                    {
                        model.Remit002 = dt.Rows[n]["Remit002"].ToString();
                    }
                    if (dt.Rows[n]["RemitMoney"] != null && dt.Rows[n]["RemitMoney"].ToString() != "")
                    {
                        model.RemitMoney = dt.Rows[n]["RemitMoney"].ToString();
                    }

                    remitList.Add(model);
                }
            }
            return remitList;
        }

        //收款帐户信息
        public lgk.Model.tb_systemBank BankModel(int id)
        {
           return bankBLL.GetModel(id);
        }

        //银行卡列表
        public List<BankModel> BankList()
        {
            string strWhere1 = " Flag = 0 ";

            var dt = bankBLL.GetList(strWhere1);

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
                    
                    model.BankAccountUser = dt.Rows[n]["BankAccountUser"] == null ?"":dt.Rows[n]["BankAccountUser"].ToString();
                    model.BankAddress = dt.Rows[n]["BankAddress"] == null ?"":dt.Rows[n]["BankAddress"].ToString();
                    
                    if (dt.Rows[n]["BankType"] != null && dt.Rows[n]["BankType"].ToString() != "")
                    {
                        model.AccountType = dt.Rows[n]["BankType"].ToString();
                    }
                    model.Pic = "";
                    model.MasterType = "0";
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
    }
}