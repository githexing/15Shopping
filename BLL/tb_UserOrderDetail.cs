using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class tb_UserOrderDetail
    {
        private readonly lgk.DAL.tb_UserOrderDetail dal = new lgk.DAL.tb_UserOrderDetail();
        public tb_UserOrderDetail()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_UserOrderDetail model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_UserOrderDetail model)
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_UserOrderDetail GetModel(long ID)
        {
            return dal.GetModel(ID);
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
        public List<lgk.Model.tb_UserOrderDetail> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<lgk.Model.tb_UserOrderDetail> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_UserOrderDetail> modelList = new List<lgk.Model.tb_UserOrderDetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_UserOrderDetail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_UserOrderDetail();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = long.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.d003 = dt.Rows[n]["d003"].ToString();
                    model.OrderCode = dt.Rows[n]["OrderCode"].ToString();
                    model.SellerCode = dt.Rows[n]["SellerCode"].ToString();
                    if (dt.Rows[n]["Integral"].ToString() != "")
                    {
                        model.Integral = decimal.Parse(dt.Rows[n]["Integral"].ToString());
                    }
                    if (dt.Rows[n]["Purchase"].ToString() != "")
                    {
                        model.Purchase = decimal.Parse(dt.Rows[n]["Purchase"].ToString());
                    }
                    if (dt.Rows[n]["Sale"].ToString() != "")
                    {
                        model.Sale = decimal.Parse(dt.Rows[n]["Sale"].ToString());
                    }
                    if (dt.Rows[n]["Quantity"].ToString() != "")
                    {
                        model.Quantity = int.Parse(dt.Rows[n]["Quantity"].ToString());
                    }
                    if (dt.Rows[n]["d001"].ToString() != "")
                    {
                        model.d001 = int.Parse(dt.Rows[n]["d001"].ToString());
                    }
                    if (dt.Rows[n]["d002"].ToString() != "")
                    {
                        model.d002 = decimal.Parse(dt.Rows[n]["d002"].ToString());
                    }
                    if (dt.Rows[n]["Equity"].ToString() != "")
                    {
                        model.Equity = decimal.Parse(dt.Rows[n]["Equity"].ToString());
                    }
                    if (dt.Rows[n]["EquityTop"].ToString() != "")
                    {
                        model.EquityTop = decimal.Parse(dt.Rows[n]["EquityTop"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        } 
        #endregion

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
