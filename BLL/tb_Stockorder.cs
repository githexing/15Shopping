using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// tb_Stockorder
    /// </summary>
    public partial class tb_Stockorder
    {
        private readonly lgk.DAL.tb_Stockorder dal = new lgk.DAL.tb_Stockorder();
        public tb_Stockorder()
		{}
        #region Method

        public bool Exists(long OrderID)
        {
            return dal.Exists(OrderID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_Stockorder model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_Stockorder model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long OrderID)
        {
            return dal.Delete(OrderID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string OrderIDlist)
        {
            return dal.DeleteList(OrderIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Stockorder GetModel(long OrderID)
        {
            return dal.GetModel(OrderID);
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
        /// 获取未卖出的股票数量
        /// </summary>
        public long GetSurplusAmount()
        {
            return dal.GetSurplusAmount();
        }

        #endregion
    }
}
