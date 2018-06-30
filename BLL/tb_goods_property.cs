using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using lgk.Model;
namespace lgk.BLL
{
    //tb_goods_property
    public partial class tb_goods_property
    {

        private readonly lgk.DAL.tb_goods_property dal = new lgk.DAL.tb_goods_property();
        public tb_goods_property()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PropertyID)
        {
            return dal.Exists(PropertyID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_goods_property model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_goods_property model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int PropertyID)
        {

            return dal.Delete(PropertyID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string PropertyIDlist)
        {
            return dal.DeleteList(PropertyIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_goods_property GetModel(int PropertyID)
        {

            return dal.GetModel(PropertyID);
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
        public List<lgk.Model.tb_goods_property> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_goods_property> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_goods_property> modelList = new List<lgk.Model.tb_goods_property>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_goods_property model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_goods_property();
                    if (dt.Rows[n]["PropertyID"].ToString() != "")
                    {
                        model.PropertyID = int.Parse(dt.Rows[n]["PropertyID"].ToString());
                    }
                    if (dt.Rows[n]["goodsID"].ToString() != "")
                    {
                        model.goodsID = int.Parse(dt.Rows[n]["goodsID"].ToString());
                    }
                    model.ColorID = dt.Rows[n]["ColorID"].ToString();
                    if (dt.Rows[n]["Qry"].ToString() != "")
                    {
                        model.Qry = int.Parse(dt.Rows[n]["Qry"].ToString());
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
        #endregion

    }
}