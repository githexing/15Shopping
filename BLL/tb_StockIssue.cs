using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// tb_StockIssue
    /// </summary>
    public partial class tb_StockIssue
    {
        private readonly lgk.DAL.tb_StockIssue dal = new lgk.DAL.tb_StockIssue();
        public tb_StockIssue()
		{}
        #region Method

        /// <summary>
        /// 根据给定的ID，判断是否存在该记录。
        /// </summary>
        /// <param name="IssueID">给定的ID</param>
        /// <returns></returns>
        public bool Exists(int IssueID)
        {
            return dal.Exists(IssueID);
        }

        /// <summary>
        /// 根据给定的ID，判断是否存在该记录。
        /// </summary>
        /// <param name="IssueID">给定的ID</param>
        /// <returns></returns>
        public bool Exists()
        {
            return dal.Exists();
        }

        /// <summary>
        /// 根据给定的条件，判断记录是否存在。
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
        public int Add(lgk.Model.tb_StockIssue model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 获得最新一轮的次数
        /// </summary>
        public int GetMax(string FieldName)
        {
            return dal.GetMax(FieldName);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_StockIssue model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            return dal.Update();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int IssueID)
        {
            return dal.Delete(IssueID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IssueIDlist)
        {
            return dal.DeleteList(IssueIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_StockIssue GetModel(int IssueID)
        {
            return dal.GetModel(IssueID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_StockIssue GetModel(string strWhere)
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
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_StockIssue> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_StockIssue> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_StockIssue> modelList = new List<lgk.Model.tb_StockIssue>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_StockIssue model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_StockIssue();
                    if (dt.Rows[n]["IssueID"] != null && dt.Rows[n]["IssueID"].ToString() != "")
                    {
                        model.IssueID = int.Parse(dt.Rows[n]["IssueID"].ToString());
                    }
                    if (dt.Rows[n]["IssueAmount"] != null && dt.Rows[n]["IssueAmount"].ToString() != "")
                    {
                        model.IssueAmount = decimal.Parse(dt.Rows[n]["IssueAmount"].ToString());
                    }
                    if (dt.Rows[n]["SurplusAmount"] != null && dt.Rows[n]["SurplusAmount"].ToString() != "")
                    {
                        model.SurplusAmount = decimal.Parse(dt.Rows[n]["SurplusAmount"].ToString());
                    }
                    if (dt.Rows[n]["AddDate"] != null && dt.Rows[n]["AddDate"].ToString() != "")
                    {
                        model.AddDate = DateTime.Parse(dt.Rows[n]["AddDate"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获取未卖出的股票数量
        /// </summary>
        public int GetSurplusAmount()
        {
            return dal.GetSurplusAmount();
        }

        #endregion
    }
}
