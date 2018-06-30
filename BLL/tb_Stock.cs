using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// tb_Stock
    /// </summary>
    public partial class tb_Stock
    {
        private readonly lgk.DAL.tb_Stock dal = new lgk.DAL.tb_Stock();
        public tb_Stock()
		{}
        #region Method

        /// <summary>
        /// 根据给定的ID，判断记录是否存在
        /// </summary>
        /// <param name="StockID">给定的ID</param>
        /// <returns></returns>
        public bool Exists(long StockID)
        {
            return dal.Exists(StockID);
        }

        /// <summary>
        /// 根据给定的条件，判断是否存在记录
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public bool Exists(string strWhere)
        {
            return dal.Exists(strWhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_Stock model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_Stock model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long StockID)
        {
            return dal.Delete(StockID);
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
        public bool DeleteList(string StockIDlist)
        {
            return dal.DeleteList(StockIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Stock GetModel(long StockID)
        {
            return dal.GetModel(StockID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Stock GetModel(string strWhere)
        {
            return dal.GetModel(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据(Max(AddDate))
        /// </summary>
        public DataSet GetList(string strWhere, string strFiledOrder)
        {
            return dal.GetList(strWhere, strFiledOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetInnerList(string strWhere)
        {
            return dal.GetInnerList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_Stock> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return GetModelList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_Stock> GetModelList(DataTable dt)
        {
            int iCount = dt.Rows.Count;
            List<lgk.Model.tb_Stock> myList = new List<lgk.Model.tb_Stock>();

            if (iCount > 0)
            {
                lgk.Model.tb_Stock model;
                foreach (DataRow row in dt.Rows)
                {
                    model = new lgk.Model.tb_Stock();
                    if (row["StockID"] != null && row["StockID"].ToString() != "")
                    {
                        model.StockID = long.Parse(row["StockID"].ToString());
                    }
                    if (row["UserID"] != null && row["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(row["UserID"].ToString());
                    }
                    if (row["Amount"] != null && row["Amount"].ToString() != "")
                    {
                        model.Amount = decimal.Parse(row["Amount"].ToString());
                    }
                    if (row["BuyPrice"] != null && row["BuyPrice"].ToString() != "")
                    {
                        model.BuyPrice = decimal.Parse(row["BuyPrice"].ToString());
                    }
                    if (row["Price"] != null && row["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(row["Price"].ToString());
                    }
                    if (row["Number"] != null && row["Number"].ToString() != "")
                    {
                        model.Number = int.Parse(row["Number"].ToString());
                    }
                    if (row["Surplus"] != null && row["Surplus"].ToString() != "")
                    {
                        model.Surplus = int.Parse(row["Surplus"].ToString());
                    }
                    if (row["SplitNum"] != null && row["SplitNum"].ToString() != "")
                    {
                        model.SplitNum = int.Parse(row["SplitNum"].ToString());
                    }
                    if (row["BuyDate"] != null && row["BuyDate"].ToString() != "")
                    {
                        model.BuyDate = DateTime.Parse(row["BuyDate"].ToString());
                    }
                    if (row["IsLock"] != null && row["IsLock"].ToString() != "")
                    {
                        model.IsLock = int.Parse(row["IsLock"].ToString());
                    }
                    if (row["IsSell"] != null && row["IsSell"].ToString() != "")
                    {
                        model.IsSell = int.Parse(row["IsSell"].ToString());
                    }

                    myList.Add(model);
                }
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
        /// 执行股票价格上涨存储过程，并计算利润。
        /// </summary>
        /// <param name="dExtentPrice">上涨后股价</param>
        /// <returns></returns>
        public bool Proc_StockRise(decimal dExtentPrice)
        {
            return dal.Proc_StockRise(dExtentPrice);
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
