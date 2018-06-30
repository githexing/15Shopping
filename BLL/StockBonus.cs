using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// StockSplit
    /// </summary>
    public partial class StockBonus
    {
        private readonly lgk.DAL.StockBonus dal = new lgk.DAL.StockBonus();
        public StockBonus()
        { }

        #region Method

        public bool Exists(int BonusID)
        {
            return dal.Exists(BonusID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.StockBonus model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.StockBonus model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int BonusID)
        {
            return dal.Delete(BonusID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string BonusIDlist)
        {
            return dal.DeleteList(BonusIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.StockBonus GetModel(int BonusID)
        {
            return dal.GetModel(BonusID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.StockBonus GetModel(string strWhere)
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

        #endregion
    }
}
