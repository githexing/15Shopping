using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using lgk.Model;
namespace lgk.BLL
{
    //tb_goods_property_color
    public partial class tb_goods_property_color
    {

        private readonly lgk.DAL.tb_goods_property_color dal = new lgk.DAL.tb_goods_property_color();
        public tb_goods_property_color()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ColorID)
        {
            return dal.Exists(ColorID);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strWhere)
        {
            return dal.Exists(strWhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_goods_property_color model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_goods_property_color model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ColorID)
        {

            return dal.Delete(ColorID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string ColorIDlist)
        {
            return dal.DeleteList(ColorIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_goods_property_color GetModel(int ColorID)
        {

            return dal.GetModel(ColorID);
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
        public List<lgk.Model.tb_goods_property_color> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_goods_property_color> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_goods_property_color> modelList = new List<lgk.Model.tb_goods_property_color>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_goods_property_color model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_goods_property_color();
                    if (dt.Rows[n]["ColorID"].ToString() != "")
                    {
                        model.ColorID = int.Parse(dt.Rows[n]["ColorID"].ToString());
                    }
                    if (dt.Rows[n]["goodsID"].ToString() != "")
                    {
                        model.goodsID = int.Parse(dt.Rows[n]["goodsID"].ToString());
                    }
                    model.ColorName = dt.Rows[n]["ColorName"].ToString();
                    model.Pic = dt.Rows[n]["Pic"].ToString();


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