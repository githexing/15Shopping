using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web.APPService.ViewModel;

namespace Web.APPService.Service
{
    public class SuanLiJournalService : AllCore
    {
        public SuanLiListModel GetSuanLiJournalList(long userid, int pageindex, int pagesize)
        {
            SuanLiListModel model = new SuanLiListModel();
            int pagecount=0, totalcount=0;
            DataSet ds = suanliJournalBLL.GetListByPageProc(userid, pageindex, pagesize, out pagecount, out totalcount, "", 1);
            model.NotesList = SellTableToList(ds.Tables[0]);
            model.CountPage = pagecount;
            return model;
        }

        public List<SuanLiModel> SellTableToList(DataTable dt)
        {
            List<SuanLiModel> modelList = new List<SuanLiModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SuanLiModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new SuanLiModel();
                    if (dt.Rows[n]["JoinTime"] != null && dt.Rows[n]["JoinTime"].ToString() != "")
                    {
                        model.Time = Convert.ToDateTime(dt.Rows[n]["JoinTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    if (dt.Rows[n]["MoneyType"] != null && dt.Rows[n]["MoneyType"].ToString() != "")
                    {
                        model.Suanli_Type = GetMoneyTypeName(dt.Rows[n]["MoneyType"].ToString());
                    }
                    if (dt.Rows[n]["SurplusAmount"] != null && dt.Rows[n]["SurplusAmount"].ToString() != "")
                    {
                        model.Total = Convert.ToInt32(dt.Rows[n]["SurplusAmount"]);
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }

                    decimal addm = Convert.ToDecimal(dt.Rows[n]["AddAmount"]);
                    decimal reducem = Convert.ToDecimal(dt.Rows[n]["ReduceAmount"]);

                    if (addm > 0)
                    {
                        model.SuanLi = addm;
                    }
                    else
                    {
                        model.SuanLi = 0 - reducem;
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获取算力方式
        /// </summary>
        /// <param name="strType"></param>
        /// <returns></returns>
        private string GetMoneyTypeName(string strType)
        {
            string strName = "";
            if (strType == "0")
            {
                strName = "购买矿机";
            }
            else if (strType == "1")
            {
                strName = "推荐获得";
            }
            else if (strType == "2")
            {
                strName = "签到";
            }
            else if (strType == "3")
            {
                strName = "注册赠送";
            }
            else if (strType == "4")
            {
                strName = "算力衰减";
            }
            return strName;
        }

    }
}