using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Web.APPService.Service
{
    public class AccountService: AllCore
    {
        //绑定微信,支付宝
        public bool AccountInfo(long userid,out object info)
        {
            info = "";
            var user = userBLL.GetModel(userid);
            if (user == null)
            {
                info = "用户ID不存在";
                return false;
            }

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("YT", user.BonusAccount); //释放币
            dict.Add("YD", user.Emoney); //原始币
            dict.Add("CalcPower",Get_ShengYuSuanLi(user.UserID)); //算力
            dict.Add("WalletAddress", user.User010 == null ? "" :user.User010); //第三方交易平台钱包地址
            dict.Add("nickname", user.NiceName); //昵称
            dict.Add("YTAddress", user.User007); //释放币钱包地址
            dict.Add("LockPositionAmount", user.User018); //智能钱包

            info = dict;
            return true;
        }

        public bool AssetInfo(long userid, out object info)
        {
            info = "";
            var user = userBLL.GetModel(userid);
            if (user == null)
            {
                info = "用户ID不存在";
                return false;
            }

            lgk.BLL.tb_InviteInfo inviteInfoBLL = new lgk.BLL.tb_InviteInfo();
            var model = inviteInfoBLL.GetModel(1);

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("YD", user.Emoney); //原始币
            dict.Add("WalletAddress", user.User010 == null ? "" : user.User010); //第三方交易平台钱包地址
            dict.Add("Intro", model == null ? "" : model.Intro); //介绍
            dict.Add("nickname", user.NiceName); //昵称

            info = dict;
            return true;
        }
        //账户明细
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="FindKey"></param>
        /// <returns></returns>
        public Dictionary<string, object> AccountList(long UserID, int PageIndex, int PageSize, string FindKey,int _type)
        {
            int PageCount;
            int TotalCount;

            //PageCount 总页数
            //TotalCount 总记录数
            var ds = journalBLL.GetListByPage(UserID, PageIndex, PageSize, out PageCount, out TotalCount,FindKey,_type);

            var list = FillJournalList(ds.Tables[0]);

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("pagecount", PageCount.ToString());
            dic.Add("totalcount", TotalCount.ToString());
            dic.Add("list", list);

            return dic;
        }
        //账户明细 释放币
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="FindKey"></param>
        /// <returns></returns>
        public Dictionary<string, object> AccountYTList(long UserID, int PageIndex, int PageSize, string FindKey, int _type)
        {
            int PageCount;
            int TotalCount;

            //PageCount 总页数
            //TotalCount 总记录数
            var ds = journalBLL.GetListYTByPage(UserID, PageIndex, PageSize, out PageCount, out TotalCount, FindKey, _type);

            var list = FillJournalList(ds.Tables[0]);

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("pagecount", PageCount.ToString());
            dic.Add("totalcount", TotalCount.ToString());
            dic.Add("list", list);

            return dic;
        }
        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AccountListModel> FillJournalList(DataTable dt)
        {
            decimal inAmount = 0,outAmount = 0 ;
            List<AccountListModel> modelList = new List<AccountListModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AccountListModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    inAmount = 0; outAmount = 0;
                    model = new AccountListModel();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = dt.Rows[n]["ID"].ToString();
                    }
                    if (dt.Rows[n]["InAmount"] != null && dt.Rows[n]["InAmount"].ToString() != "")
                    {
                        inAmount = decimal.Parse(dt.Rows[n]["InAmount"].ToString());
                    }
                    if (dt.Rows[n]["OutAmount"] != null && dt.Rows[n]["OutAmount"].ToString() != "")
                    {
                        outAmount = decimal.Parse(dt.Rows[n]["OutAmount"].ToString());
                    }
                    model.Amount = inAmount > 0 ? inAmount.ToString() : (0 - outAmount).ToString();

                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }

                    if (dt.Rows[n]["JournalDate"] != null && dt.Rows[n]["JournalDate"].ToString() != "")
                    {
                        model.RecordDate = DateTime.Parse(dt.Rows[n]["JournalDate"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion

        public bool AccountBalance(long userid, out object info)
        {
            info = "";
            var user = userBLL.GetModel(userid);
            if (user == null)
            {
                info = "用户ID不存在";
                return false;
            }

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("YT", user.BonusAccount); //释放币
            dict.Add("YD", user.Emoney); //原始币
            dict.Add("LockPositionAmount", user.User018); //智能钱包

            info = dict;
            return true;
        }

    }
}