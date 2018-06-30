using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
    /// <summary>
    /// tb_goods
    /// </summary>
    public partial class tb_goods
    {
        private readonly lgk.DAL.tb_goods dal = new lgk.DAL.tb_goods();
        public tb_goods()
        { }
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
        public long Add(lgk.Model.tb_goods model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_goods model)
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
        /// 删除一条数据(只是隐藏）
        /// </summary>
        public bool Delete1(long ID)
        {

            return dal.Delete1(ID);
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
        public lgk.Model.tb_goods GetModel(long ID)
        {
            return dal.GetModel(ID);
        }

        public lgk.Model.tb_goods GetModel(string where)
        {
            return dal.GetModel(where);
        }

        /// <summary>
        /// 得到一个对象实体,只有一级名称
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public lgk.Model.tb_goods GetModelAndOneName(long ID)
        {
            return dal.GetModelAndOneName(ID);
        }

        /// <summary>
        /// 得到一个对象实体,包括一级，二级名称
        /// </summary>
        public lgk.Model.tb_goods GetModelAndName(long ID)
        {
            return dal.GetModelAndName(ID);
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
        /// <param name="Top">前几行</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序方式</param>
        /// <returns></returns>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_goods> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_goods> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_goods> modelList = new List<lgk.Model.tb_goods>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_goods model;
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
        /// 普通商品一级分类列表
        /// </summary>
        /// <param cxType="促销类型,团购,秒杀"></param>
        /// <returns></returns>
        public DataTable GetGoodsOneName(int cxType, string where)
        {
            DataSet ds = dal.GetGoodsOneName(cxType, where);
            return ds.Tables[0];
        }

        /// <summary>
        /// 促销商品二级分类列表
        /// </summary>
        /// <param cxType="促销类型,团购,秒杀"></param>
        /// <returns></returns>
        public DataTable GetGoodsTwoName(int cxType, string where)
        {
            DataSet ds = dal.GetGoodsTwoName(cxType, where);
            return ds.Tables[0];
        }

        /// <summary>
        /// 商品列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetGoodsList(string strWhere)
        {
            return dal.GetGoodsList(strWhere);
        }

        public DataSet GetModelAndOneNameList(string strWhere)
        {
            return dal.GetModelAndOneNameList(strWhere);
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

