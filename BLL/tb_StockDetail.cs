using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// tb_StockDetail
    /// </summary>
    public partial class tb_StockDetail
    {
        private readonly lgk.DAL.tb_StockDetail dal = new lgk.DAL.tb_StockDetail();
        public tb_StockDetail()
		{}
        #region Method

        public bool Exists(long StockDetailID)
        {
            return dal.Exists(StockDetailID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_StockDetail model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_StockDetail model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long StockDetailID)
        {
            return dal.Delete(StockDetailID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string StockDetailIDlist)
        {
            return dal.DeleteList(StockDetailIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_StockDetail GetModel(long StockDetailID)
        {
            return dal.GetModel(StockDetailID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_StockDetail GetModel(string strWhere)
        {
            return dal.GetModel(strWhere);
        }

        /// <summary>
        /// 根据主表编号，获取购买的股票金额。
        /// </summary>
        /// <param name="iStockID">主表编号</param>
        /// <returns></returns>
        public decimal GetCountAmount(int iStockID)
        {
            return dal.GetCountAmount(iStockID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 根据给定的主表编号，返回明细表的实体列表。
        /// </summary>
        /// <param name="iStockID">主表编号</param>
        /// <returns></returns>
        public List<lgk.Model.tb_StockDetail> GetModelList(long iStockID)
        {
            StringBuilder strSql = new StringBuilder();
            List<lgk.Model.tb_StockDetail> myList = new List<lgk.Model.tb_StockDetail>();

            DataSet ds = dal.GetList("StockID=" + iStockID + "");

            if (ds.Tables[0].Rows.Count == 0)
                return myList;

            lgk.Model.tb_StockDetail model;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                model = new lgk.Model.tb_StockDetail();

                if (row["StockDetailID"] != null && row["StockDetailID"].ToString() != "")
                {
                    model.StockDetailID = int.Parse(row["StockDetailID"].ToString());
                }
                if (row["StockID"] != null && row["StockID"].ToString() != "")
                {
                    model.StockID = int.Parse(row["StockID"].ToString());
                }
                if (row["Amount"] != null && row["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(row["Amount"].ToString());
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["Number"] != null && row["Number"].ToString() != "")
                {
                    model.Number = int.Parse(row["Number"].ToString());
                }
                if (row["Periods"] != null && row["Periods"].ToString() != "")
                {
                    model.Periods = int.Parse(row["Periods"].ToString());
                }
                if (row["BuyDate"] != null && row["BuyDate"].ToString() != "")
                {
                    model.BuyDate = DateTime.Parse(row["BuyDate"].ToString());
                }
                myList.Add(model);
            }

            return myList;
        }

        #endregion
    }
}
