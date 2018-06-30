using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// 业务逻辑类:tb_Purchase
    /// </summary>
    public partial class tb_Purchase
    {
        private readonly lgk.DAL.tb_Purchase dal = new lgk.DAL.tb_Purchase();
        public tb_Purchase()
        { }
        #region Method
        public bool Exists(long PurchaseID)
        {
            return dal.Exists(PurchaseID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_Purchase model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_Purchase model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdatePur(long iPurchaseID)
        {
            return dal.UpdatePur(iPurchaseID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long PurchaseID)
        {
            return dal.Delete(PurchaseID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string PurchaseIDlist)
        {
            return dal.DeleteList(PurchaseIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Purchase GetModel(long PurchaseID)
        {
            return dal.GetModel(PurchaseID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Purchase GetModel(string strWhere)
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetInnerList(string strWhere)
        {
            return dal.GetInnerList(strWhere);
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
