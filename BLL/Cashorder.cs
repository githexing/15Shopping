using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// 业务逻辑类:Cashorder
    /// </summary>
    public partial class Cashorder
    {
        private readonly lgk.DAL.Cashorder dal = new lgk.DAL.Cashorder();
        public Cashorder()
        { }
        #region Method

        public bool Exists(long OrderID)
        {
            return dal.Exists(OrderID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.Cashorder model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.Cashorder model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 根据给定的用户ID和订单编号，修改订单状态（1付款，2确认已付款，3发货）。
        /// </summary>
        /// <param name="iUserID">给定的用户编号</param>
        /// <param name="iOrderID">给定的订单编号</param>
        /// <param name="dtDate">给定的时间</param>
        /// <param name="picpath">上传凭证</param>
        /// <param name="iActionID">1付款，2确认已付款，3发货，4撤销</param>
        /// <returns></returns>
        public int Update(long iUserID, long iOrderID, DateTime dtDate,string picpath,string remark, int iActionID)
        {
            return dal.Update(iUserID, iOrderID, dtDate, picpath, remark, iActionID);
        }

        /// <summary>
        /// 更新数据终止交易
        /// </summary>
        /// <param name="strFiled">更新的字段</param>
        /// <param name="iOrderID">订单编号</param>
        /// <param name="iUserID">给定用户编号</param>
        /// <param name="iStatus">状态</param>
        /// <param name="iActionID">1为买家终止,2为卖家终止</param>
        /// <returns></returns>
        public int Update(string strRemark, long iOrderID, long iUserID, int iActionID)
        {
            return dal.Update(strRemark, iOrderID, iUserID, iActionID);
        }

        /// <summary>
        /// 根据给定的订单ID，将订单撤销。
        /// </summary>
        /// <param name="iOrderID">给定的订单ID</param>
        /// <param name="strRemark">撤销备注</param>
        /// <returns></returns>
        public int UndoOrder(long iOrderID, string strRemark)
        {
            return dal.UndoOrder(iOrderID, strRemark);
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
        public lgk.Model.Cashorder GetModel(long OrderID)
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
        /// 根据给定的条件，获取订单列表
        /// </summary>
        /// <param name="strWhere">给定的条件</param>
        /// <returns></returns>
        public DataSet GetOrderList(string strWhere)
        {
            return dal.GetOrderList(strWhere);
        }

        /// <summary>
        /// 根据给定的订单ID，反馈。
        /// </summary>
        /// <param name="iOrderID">给定的订单ID</param>
        /// <param name="Feedback">备注</param>
        /// <param name="FeedbackDate">反馈时间</param>
        /// <returns></returns>
        public int Feedback(long iOrderID, string Feedback, DateTime FeedbackDate)
        {
            return dal.Feedback(iOrderID,  Feedback,  FeedbackDate);
        }
        #endregion
    }
}
