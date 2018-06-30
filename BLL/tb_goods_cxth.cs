using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lgk.Model;
using System.Data;
namespace lgk.BLL
{
  

    /// <summary>
    /// tb_goods_cxth
    /// </summary>
    public partial class tb_goods_cxth
    {
        private readonly lgk.DAL.tb_goods_cxth dal = new lgk.DAL.tb_goods_cxth();
        public tb_goods_cxth()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

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
        public int Add(lgk.Model.tb_goods_cxth model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_goods_cxth model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }

        /// <summary>
        /// 删除一条数据(只是隐藏）
        /// </summary>
        public bool Delete1(int ID)
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
        public lgk.Model.tb_goods_cxth GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public lgk.Model.tb_goods_cxth GetModel(string where)
        {
            return dal.GetModel(where);
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
            //return dal.GetList(Top,strWhere,filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_goods_cxth> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_goods_cxth> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_goods_cxth> modelList = new List<lgk.Model.tb_goods_cxth>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_goods_cxth model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_goods_cxth();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["GoodsCode"] != null && dt.Rows[n]["GoodsCode"].ToString() != "")
                    {
                        model.GoodsCode = dt.Rows[n]["GoodsCode"].ToString();
                    }
                    if (dt.Rows[n]["GoodsName"] != null && dt.Rows[n]["GoodsName"].ToString() != "")
                    {
                        model.GoodsName = dt.Rows[n]["GoodsName"].ToString();
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["RealityPrice"] != null && dt.Rows[n]["RealityPrice"].ToString() != "")
                    {
                        model.RealityPrice = decimal.Parse(dt.Rows[n]["RealityPrice"].ToString());
                    }
                 
                    if (dt.Rows[n]["TypeID"] != null && dt.Rows[n]["TypeID"].ToString() != "")
                    {
                        model.TypeID = int.Parse(dt.Rows[n]["TypeID"].ToString());
                    }
                    if (dt.Rows[n]["GoodsType"] != null && dt.Rows[n]["GoodsType"].ToString() != "")
                    {
                        model.GoodsType = int.Parse(dt.Rows[n]["GoodsType"].ToString());
                    }
                    if (dt.Rows[n]["Pic1"] != null && dt.Rows[n]["Pic1"].ToString() != "")
                    {
                        model.Pic1 = dt.Rows[n]["Pic1"].ToString();
                    }
                    if (dt.Rows[n]["Pic2"] != null && dt.Rows[n]["Pic2"].ToString() != "")
                    {
                        model.Pic2 = dt.Rows[n]["Pic2"].ToString();
                    }
                    if (dt.Rows[n]["Pic3"] != null && dt.Rows[n]["Pic3"].ToString() != "")
                    {
                        model.Pic3 = dt.Rows[n]["Pic3"].ToString();
                    }
                    if (dt.Rows[n]["Pic4"] != null && dt.Rows[n]["Pic4"].ToString() != "")
                    {
                        model.Pic4 = dt.Rows[n]["Pic4"].ToString();
                    }
                    if (dt.Rows[n]["Pic5"] != null && dt.Rows[n]["Pic5"].ToString() != "")
                    {
                        model.Pic5 = dt.Rows[n]["Pic5"].ToString();
                    }
                 
                    if (dt.Rows[n]["Remarks"] != null && dt.Rows[n]["Remarks"].ToString() != "")
                    {
                        model.Remarks = dt.Rows[n]["Remarks"].ToString();
                    }
                    if (dt.Rows[n]["AddTime"] != null && dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["Goods001"] != null && dt.Rows[n]["Goods001"].ToString() != "")
                    {
                        model.Goods001 = int.Parse(dt.Rows[n]["Goods001"].ToString());
                    }
                    if (dt.Rows[n]["Goods002"] != null && dt.Rows[n]["Goods002"].ToString() != "")
                    {
                        model.Goods002 = int.Parse(dt.Rows[n]["Goods002"].ToString());
                    }
                    if (dt.Rows[n]["Goods003"] != null && dt.Rows[n]["Goods003"].ToString() != "")
                    {
                        model.Goods003 = int.Parse(dt.Rows[n]["Goods003"].ToString());
                    }
                    if (dt.Rows[n]["Goods004"] != null && dt.Rows[n]["Goods004"].ToString() != "")
                    {
                        model.Goods004 = dt.Rows[n]["Goods004"].ToString();
                    }
                    if (dt.Rows[n]["Goods005"] != null && dt.Rows[n]["Goods005"].ToString() != "")
                    {
                        model.Goods005 = decimal.Parse(dt.Rows[n]["Goods005"].ToString());
                    }
                    if (dt.Rows[n]["Goods006"] != null && dt.Rows[n]["Goods006"].ToString() != "")
                    {
                        model.Goods006 = int.Parse(dt.Rows[n]["Goods006"].ToString());
                    }
                    if (dt.Rows[n]["Goods007"] != null && dt.Rows[n]["Goods007"].ToString() != "")
                    {
                        model.Goods007 = DateTime.Parse(dt.Rows[n]["Goods007"].ToString());
                    }
                    if (dt.Rows[n]["Goods008"] != null && dt.Rows[n]["Goods008"].ToString() != "")
                    {
                        model.Goods008 = DateTime.Parse(dt.Rows[n]["Goods008"].ToString());
                    }
                    
                    if (dt.Rows[n]["SealCount"] != null && dt.Rows[n]["SealCount"].ToString() != "")
                    {
                        model.Goods008 = DateTime.Parse(dt.Rows[n]["SealCount"].ToString());
                    }
                    if (dt.Rows[n]["Purchase"] != null && dt.Rows[n]["Purchase"].ToString() != "")
                    {
                        model.Purchase = int.Parse(dt.Rows[n]["Purchase"].ToString());
                    }
                    if (dt.Rows[n]["SealPurchase"] != null && dt.Rows[n]["SealPurchase"].ToString() != "")
                    {
                        model.SealPurchase = int.Parse(dt.Rows[n]["SealPurchase"].ToString());
                    }
                    if (dt.Rows[n]["UserCode"] != null && dt.Rows[n]["UserCode"].ToString() != "")
                    {
                        model.UserCode = dt.Rows[n]["UserCode"].ToString();
                    }
                    if (dt.Rows[n]["IsLucky"] != null && dt.Rows[n]["IsLucky"].ToString() != "")
                    {
                        model.IsLucky = int.Parse(dt.Rows[n]["IsLucky"].ToString());
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
        /// <summary>
        /// 促销商品一级分类列表
        /// </summary>
        /// <param cxType="促销类型,团购,秒杀"></param>
        /// <returns></returns>
        public DataTable GetGoodsOneName(int cxType)
        {
            DataSet ds = dal.GetGoodsOneName(cxType);
            return ds.Tables[0];
        }
        /// <summary>
        /// 促销商品二级分类列表
        /// </summary>
        /// <param cxType="促销类型,团购,秒杀"></param>
        /// <returns></returns>
        public DataTable GetGoodsTwoName(int cxType,int typeID)
        {
            DataSet ds = dal.GetGoodsTwoName(cxType, typeID);
            return ds.Tables[0];
        }

        #endregion  Method
    }
}
