using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// tb_StockBuy
    /// </summary>
    public partial class tb_StockBuy
    {
        private readonly lgk.DAL.tb_StockBuy dal = new lgk.DAL.tb_StockBuy();
        public tb_StockBuy()
        { }
        #region Method

        /// <summary>
        /// 给据给定的编号，判断数据是否存在。
        /// </summary>
        /// <param name="StockBuyID">给定的编号</param>
        /// <returns></returns>
        public bool Exists(long StockBuyID)
        {
            return dal.Exists(StockBuyID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_StockBuy model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_StockBuy model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long StockBuyID)
        {
            return dal.Delete(StockBuyID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string strWhere)
        {
            return dal.Delete(strWhere);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string StockBuyIDlist)
        {
            return dal.DeleteList(StockBuyIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_StockBuy GetModel(long StockBuyID)
        {
            return dal.GetModel(StockBuyID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetInnerList(string strWhere)
        {
            return dal.GetInnerList(strWhere);
        }

        /// <summary>
        /// 根据给定的主表编号，返回明细表的实体列表。
        /// </summary>
        /// <param name="iStockID">主表编号</param>
        /// <returns></returns>
        public List<lgk.Model.tb_StockBuy> GetModelList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            List<lgk.Model.tb_StockBuy> myList = new List<lgk.Model.tb_StockBuy>();

            DataSet ds = dal.GetList(strWhere);

            if (ds.Tables[0].Rows.Count == 0)
                return myList;

            lgk.Model.tb_StockBuy model;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                model = new lgk.Model.tb_StockBuy();

                if (row["StockBuyID"] != null && row["StockBuyID"].ToString() != "")
                {
                    model.StockBuyID = long.Parse(row["StockBuyID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(row["UserID"].ToString());
                }
                if (row["Amount"] != null && row["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(row["Amount"].ToString());
                }
                if (row["SurplusSum"] != null && row["SurplusSum"].ToString() != "")
                {
                    model.SurplusSum = decimal.Parse(row["SurplusSum"].ToString());
                }
                if (row["BuyDate"] != null && row["BuyDate"].ToString() != "")
                {
                    model.BuyDate = DateTime.Parse(row["BuyDate"].ToString());
                }
                if (row["IsBuy"] != null && row["IsBuy"].ToString() != "")
                {
                    model.IsBuy = int.Parse(row["IsBuy"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                myList.Add(model);
            }

            return myList;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 根据给定的条件，获取总的购买金额。
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public decimal GetAmountCount(string strWhere)
        {
            return dal.GetAmountCount(strWhere);
        }

        #endregion
    }
}
