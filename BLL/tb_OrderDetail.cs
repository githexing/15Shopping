﻿using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
    /// <summary>
    /// tb_OrderDetail
    /// </summary>
    public partial class tb_OrderDetail
    {
        private readonly lgk.DAL.tb_OrderDetail dal = new lgk.DAL.tb_OrderDetail();
        public tb_OrderDetail()
        { }
        /// <summary>
        /// 通过订单编号得到一个对象实体
        /// <param name="orderID">订单编号</param>
        /// </summary>
        public lgk.Model.tb_OrderDetail GetModelByOrderCode(string strOrderCode)
        {
            return dal.GetModelByOrderCode(strOrderCode);
        }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_OrderDetail model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_OrderDetail model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ID)
        {
            return dal.Delete(ID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByOrderCode(string strOrderCode)
        {
            return dal.DeleteByOrderCode(strOrderCode);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_OrderDetail GetModel(long ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_OrderDetail GetModel(string strWhere)
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
        public List<lgk.Model.tb_OrderDetail> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_OrderDetail> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_OrderDetail> modelList = new List<lgk.Model.tb_OrderDetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_OrderDetail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_OrderDetail> GetJoinList(string strWhere)
        {
            DataSet ds = dal.GetJoinList(strWhere);
            DataTable dt = ds.Tables[0];

            List<lgk.Model.tb_OrderDetail> modelList = new List<lgk.Model.tb_OrderDetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_OrderDetail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_OrderDetail> GetJoinListAll(string strWhere)
        {
            DataSet ds = dal.GetJoinListAll(strWhere);
            DataTable dt = ds.Tables[0];

            List<lgk.Model.tb_OrderDetail> modelList = new List<lgk.Model.tb_OrderDetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_OrderDetail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        public DataSet GetGoodsListAll(string strWhere)
        {
            return dal.GetGoodsListAll(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}

