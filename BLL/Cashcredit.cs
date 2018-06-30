using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// 业务逻辑类:Cashcredit
    /// </summary>
    public partial class Cashcredit
    {
        private readonly lgk.DAL.Cashcredit dal = new lgk.DAL.Cashcredit();
        public Cashcredit()
        { }
        #region Method

        /// <summary>
        /// 根据给定的编号，判断是否已存在记录。
        /// </summary>
        /// <param name="CreditID">给定的编号</param>
        /// <returns></returns>
        public bool Exists(long CreditID)
        {
            return dal.Exists(CreditID);
        }

        /// <summary>
        /// 根据给定的条件，判断是否存在记录。
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public bool Exists(string strWhere)
        {
            return dal.Exists(strWhere);
        }

        /// <summary>
        /// 根据会员ID获取给定的会员评分。
        /// </summary>
        /// <param name="iUserID">会员ID</param>
        /// <param name="strFiledName">会员评分字段</param>
        /// <returns></returns>
        public int GetValues(long iUserID, string strFiledName)
        {
            return dal.GetValues(iUserID, strFiledName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.Cashcredit model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.Cashcredit model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long CreditID)
        {
            return dal.Delete(CreditID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string CreditIDlist)
        {
            return dal.DeleteList(CreditIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashcredit GetModel(long CreditID)
        {
            return dal.GetModel(CreditID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.Cashcredit GetModel(string strWhere)
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
