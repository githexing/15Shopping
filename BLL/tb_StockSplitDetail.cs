using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// tb_StockSplitDetail
    /// </summary>
    public partial class tb_StockSplitDetail
    {
        private readonly lgk.DAL.tb_StockSplitDetail dal = new lgk.DAL.tb_StockSplitDetail();
        public tb_StockSplitDetail()
        { }
        #region Method

        /// <summary>
        /// 根据给定的编号，查询是否存在该记录。
        /// </summary>
        /// <param name="SplitDetailID"></param>
        /// <returns></returns>
        public bool Exists(long SplitDetailID)
        {
            return dal.Exists(SplitDetailID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_StockSplitDetail model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_StockSplitDetail model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SplitDetailID)
        {
            return dal.Delete(SplitDetailID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string SplitDetailIDlist)
        {
            return dal.DeleteList(SplitDetailIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_StockSplitDetail GetModel(long SplitDetailID)
        {
            return dal.GetModel(SplitDetailID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_StockSplitDetail GetModel(string strWhere)
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
        /// 执行股票拆分存储过程
        /// </summary>
        /// <param name="iSplitID">拆分主表ID</param>
        /// <param name="iSplitTimes">拆分次数</param>
        /// <returns></returns>
        public bool SplitProcDetail(lgk.Model.tb_StockSplit model)
        {
            return dal.SplitProcDetail(model);
        }

        #endregion
    }
}
