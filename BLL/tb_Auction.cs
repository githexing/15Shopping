using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace lgk.BLL
{
    /// <summary>
    /// tb_Auction
    /// </summary>
    public partial class tb_Auction
    {
        private readonly lgk.DAL.tb_Auction dal = new lgk.DAL.tb_Auction();
        public tb_Auction()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AID)
        {
            return dal.Exists(AID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_Auction model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_Auction model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AID)
        {

            return dal.Delete(AID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string AIDlist)
        {
            return dal.DeleteList(AIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Auction GetModel(int AID)
        {

            return dal.GetModel(AID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public lgk.Model.tb_Auction GetModelByCache(int AID)
        //{

        //    string CacheKey = "tb_AuctionModel-" + AID;
        //    object objModel = DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(AID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
        //                DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (lgk.Model.tb_Auction)objModel;
        //}

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
        public List<lgk.Model.tb_Auction> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_Auction> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_Auction> modelList = new List<lgk.Model.tb_Auction>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_Auction model;
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
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByUser(string strWhere)
        {
            return dal.GetListByUser(strWhere);
        }
        public DataSet GetListWithSalesroom(string strWhere)
        {
            return dal.GetListWithSalesroom(strWhere);
        }
        #endregion  ExtensionMethod
    }
}
