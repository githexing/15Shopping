using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
    /// <summary>
    /// tb_Order
    /// </summary>
    public partial class tb_Order
    {
        private readonly lgk.DAL.tb_Order dal = new lgk.DAL.tb_Order();
        public tb_Order()
        { }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Order GetModelByCode(string OrderID)
        {
            return dal.GetModelByCode(OrderID);
        }
        #region  Method
        
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long OrderID)
        {
            return dal.Exists(OrderID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_Order model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_Order model)
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string strOrderCode)
        {
            return dal.Delete(strOrderCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string OrderIDlist)
        {
            return dal.DeleteList(OrderIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Order GetModel(long OrderID)
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
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_Order> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_Order> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_Order> modelList = new List<lgk.Model.tb_Order>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_Order model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_Order();
                    if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = long.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["OrderCode"] != null && dt.Rows[n]["OrderCode"].ToString() != "")
                    {
                        model.OrderCode = dt.Rows[n]["OrderCode"].ToString();
                    }
                    if (dt.Rows[n]["UserAddr"] != null && dt.Rows[n]["UserAddr"].ToString() != "")
                    {
                        model.UserAddr = dt.Rows[n]["UserAddr"].ToString();
                    }
                    if (dt.Rows[n]["OrderSum"] != null && dt.Rows[n]["OrderSum"].ToString() != "")
                    {
                        model.OrderSum = int.Parse(dt.Rows[n]["OrderSum"].ToString());
                    }
                    if (dt.Rows[n]["OrderTotal"] != null && dt.Rows[n]["OrderTotal"].ToString() != "")
                    {
                        model.OrderTotal = decimal.Parse(dt.Rows[n]["OrderTotal"].ToString());
                    }
                    if (dt.Rows[n]["PVTotal"] != null && dt.Rows[n]["PVTotal"].ToString() != "")
                    {
                        model.PVTotal = decimal.Parse(dt.Rows[n]["PVTotal"].ToString());
                    }
                    if (dt.Rows[n]["OrderDate"] != null && dt.Rows[n]["OrderDate"].ToString() != "")
                    {
                        model.OrderDate = DateTime.Parse(dt.Rows[n]["OrderDate"].ToString());
                    }
                    if (dt.Rows[n]["IsSend"] != null && dt.Rows[n]["IsSend"].ToString() != "")
                    {
                        model.IsSend = int.Parse(dt.Rows[n]["IsSend"].ToString());
                    }
                    if (dt.Rows[n]["PayMethod"] != null && dt.Rows[n]["PayMethod"].ToString() != "")
                    {
                        model.PayMethod = int.Parse(dt.Rows[n]["PayMethod"].ToString());
                    }
                    if (dt.Rows[n]["OrderType"] != null && dt.Rows[n]["OrderType"].ToString() != "")
                    {
                        model.OrderType = int.Parse(dt.Rows[n]["OrderType"].ToString());
                    }
                    if (dt.Rows[n]["Order1"] != null && dt.Rows[n]["Order1"].ToString() != "")
                    {
                        model.Order1 = decimal.Parse(dt.Rows[n]["Order1"].ToString());
                    }
                    if (dt.Rows[n]["Order2"] != null && dt.Rows[n]["Order2"].ToString() != "")
                    {
                        model.Order2 = decimal.Parse(dt.Rows[n]["Order2"].ToString());
                    }
                    if (dt.Rows[n]["Order3"] != null && dt.Rows[n]["Order3"].ToString() != "")
                    {
                        model.Order3 = dt.Rows[n]["Order3"].ToString();
                    }
                    if (dt.Rows[n]["Order4"] != null && dt.Rows[n]["Order4"].ToString() != "")
                    {
                        model.Order4 = dt.Rows[n]["Order4"].ToString();
                    }
                    if (dt.Rows[n]["Order5"] != null && dt.Rows[n]["Order5"].ToString() != "")
                    {
                        model.Order5 = dt.Rows[n]["Order5"].ToString();
                    }
                    if (dt.Rows[n]["Order6"] != null && dt.Rows[n]["Order6"].ToString() != "")
                    {
                        model.Order6 = dt.Rows[n]["Order6"].ToString();
                    }
                    if (dt.Rows[n]["Order7"] != null && dt.Rows[n]["Order7"].ToString() != "")
                    {
                        model.Order7 = dt.Rows[n]["Order7"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Order GetModel(string strwhere)
        {
            return dal.GetModel(strwhere);
        }
    }
}

