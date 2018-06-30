using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Web.APPService.Service
{
    public class BonusService : AllCore
    {
        public List<BonusPolyListModel> ShareGet(long userid)
        {
            var list = flag_ShareGet(userid);
            return DataTableToList(list.Tables[0]);
        }
        public List<BonusPolyAlreadyListModel> AlreadyBonusList(long userid)
        {
            var list = GetAlreadyBonusList(userid);
            return DataTableAlreadyToList(list.Tables[0]);
        }
        //达人收益列表
        public List<BonusPolyAlreadyListModel> DarenBonusList(long userid)
        {
            var list = GetDarenBonusList(userid);
            return DataTableDarenToList(list.Tables[0]);
        }
        //富贵达人列表
        public List<BonusPolyAlreadyListModel> RichManBonusList(long userid)
        {
            var list = GetRichManBonusList(userid);
            return DataTableRichManToList(list.Tables[0]);
        }
        //消费积分
        public List<BonusPolyAlreadyListModel> ConsumeBonusList(long userid)
        {
            var list = GetConsumeBonusList(userid);
            return DataTableDarenToList(list.Tables[0]);
        }

        public string IsRichMan(long userid)
        {
            var user = userBLL.GetModel(userid);
            return user.User002.ToString();
        }

        //获取期数
        public decimal GetPhase(long userid, int type)
        {
            decimal phase = 0;
            if (type == 1) //总量
                phase = GetTotalPhase(userid);
            else if (type == 2) //已获取
            {
                var user = userBLL.GetModel(userid);
                phase = user.User011;
            }
            else if (type == 3) //未获取
            {
                decimal totalPhase = GetTotalPhase(userid);

                var user = userBLL.GetModel(userid);
                phase = user.User011;

                phase = totalPhase - phase;
            }
            return phase;
        }
        //获取奖金
        public decimal GetPolyBonus(long userid, int type)
        {
            decimal bonus = 0;
            if (type == 1)  //总奖金
            {
                bonus = GetTotalBonus(userid);
            }
            else if (type == 2) //已获取
            {
                // var model = userBLL.GetModel(userid);
                //  bonus = model.AllBonusAccount;
                bonus = GetTotalBonusAlready(userid);
            }
            else if (type == 3)  //未获取
            {
                decimal allbonus = GetTotalBonus(userid);

                //var model = userBLL.GetModel(userid);
                // decimal alreadybonus = model.AllBonusAccount;
                decimal alreadybonus = GetTotalBonusAlready(userid);
                bonus = allbonus - alreadybonus;
            }
            return bonus;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BonusPolyListModel> DataTableToList(DataTable dt)
        {
            List<BonusPolyListModel> modelList = new List<BonusPolyListModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BonusPolyListModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BonusPolyListModel();

                    if (dt.Rows[n]["Bonus"] != null && dt.Rows[n]["Bonus"].ToString() != "")
                    {
                        model.Bonus = dt.Rows[n]["Bonus"].ToString();
                    }
                    if (dt.Rows[n]["ShareDay"] != null && dt.Rows[n]["ShareDay"].ToString() != "")
                    {
                        model.ShareDay = dt.Rows[n]["ShareDay"].ToString();
                    }
                    if (dt.Rows[n]["ShowDate"] != null && dt.Rows[n]["ShowDate"].ToString() != "")
                    {
                        model.ShowDate = dt.Rows[n]["ShowDate"].ToString();
                    }
                    if (dt.Rows[n]["ShowTotalHour"] != null && dt.Rows[n]["ShowTotalHour"].ToString() != "")
                    {
                        model.ShowTotalHour = dt.Rows[n]["ShowTotalHour"].ToString();
                    }
                    if (dt.Rows[n]["Flag"] != null && dt.Rows[n]["Flag"].ToString() != "")
                    {
                        model.Flag = int.Parse(dt.Rows[n]["Flag"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BonusPolyAlreadyListModel> DataTableAlreadyToList(DataTable dt)
        {
            List<BonusPolyAlreadyListModel> modelList = new List<BonusPolyAlreadyListModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BonusPolyAlreadyListModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BonusPolyAlreadyListModel();

                    if (dt.Rows[n]["Bonus"] != null && dt.Rows[n]["Bonus"].ToString() != "")
                    {
                        model.Bonus = dt.Rows[n]["Bonus"].ToString();
                    }
                    if (dt.Rows[n]["Source"] != null && dt.Rows[n]["Source"].ToString() != "")
                    {
                        model.Source = dt.Rows[n]["Source"].ToString();
                    }
                    if (dt.Rows[n]["SttleTime"] != null && dt.Rows[n]["SttleTime"].ToString() != "")
                    {
                        model.ShowDate = dt.Rows[n]["SttleTime"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        //获取达人收益总金额
        public decimal GetDarenTotal(long userid)
        {
            decimal amount = 0;
            amount = GetTotalAmount(userid);
            return amount;
        }
        //达人收益列表
        public List<BonusPolyAlreadyListModel> DataTableDarenToList(DataTable dt)
        {
            List<BonusPolyAlreadyListModel> darenlList = new List<BonusPolyAlreadyListModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BonusPolyAlreadyListModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BonusPolyAlreadyListModel();

                    if (dt.Rows[n]["Bonus"] != null && dt.Rows[n]["Bonus"].ToString() != "")
                    {
                        model.Bonus = dt.Rows[n]["Bonus"].ToString();
                    }
                    if (dt.Rows[n]["Source"] != null && dt.Rows[n]["Source"].ToString() != "")
                    {
                        model.Source = dt.Rows[n]["Source"].ToString();
                    }
                    if (dt.Rows[n]["SttleTime"] != null && dt.Rows[n]["SttleTime"].ToString() != "")
                    {
                        model.ShowDate = dt.Rows[n]["SttleTime"].ToString();
                    }
                    darenlList.Add(model);
                }
            }
            return darenlList;
        }
      

        //富贵达人列表
        public List<BonusPolyAlreadyListModel> DataTableRichManToList(DataTable dt)
        {
            List<BonusPolyAlreadyListModel> RichManList = new List<BonusPolyAlreadyListModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BonusPolyAlreadyListModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BonusPolyAlreadyListModel();

                    if (dt.Rows[n]["Bonus"] != null && dt.Rows[n]["Bonus"].ToString() != "")
                    {
                        model.Bonus = dt.Rows[n]["Bonus"].ToString();
                    }
                    if (dt.Rows[n]["Source"] != null && dt.Rows[n]["Source"].ToString() != "")
                    {
                        model.Source = dt.Rows[n]["Source"].ToString();
                    }
                    if (dt.Rows[n]["SttleTime"] != null && dt.Rows[n]["SttleTime"].ToString() != "")
                    {
                        model.ShowDate = dt.Rows[n]["SttleTime"].ToString();
                    }
                    RichManList.Add(model);
                }
            }
            return RichManList;
        }
    }
}