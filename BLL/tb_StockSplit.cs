using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// tb_StockSplit
    /// </summary>
    public partial class tb_StockSplit
    {
        private readonly lgk.DAL.tb_StockSplit dal = new lgk.DAL.tb_StockSplit();
        public tb_StockSplit()
        { }
        #region Method

        public bool Exists(long SplitID)
        {
            return dal.Exists(SplitID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_StockSplit model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_StockSplit model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long SplitID)
        {
            return dal.Delete(SplitID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string SplitIDlist)
        {
            return dal.DeleteList(SplitIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_StockSplit GetModel(long SplitID)
        {
            return dal.GetModel(SplitID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_StockSplit GetModel(string strWhere)
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
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool SplitProc(lgk.Model.tb_StockSplit model)
        {
            return dal.SplitProc(model);
        }

        #endregion
    }
}
