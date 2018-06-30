using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class tb_UserOrder
    {
        private readonly lgk.DAL.tb_UserOrder dal = new lgk.DAL.tb_UserOrder();
        public tb_UserOrder()
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
        public long Add(lgk.Model.tb_UserOrder model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_UserOrder model)
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
        public lgk.Model.tb_UserOrder GetModel(long ID)
        {
            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_UserOrder GetModel(string strWhere)
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
        public List<lgk.Model.tb_UserOrder> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_UserOrder> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_UserOrder> modelList = new List<lgk.Model.tb_UserOrder>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_UserOrder model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_UserOrder();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = long.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["Flag"].ToString() != "")
                    {
                        model.Flag = int.Parse(dt.Rows[n]["Flag"].ToString());
                    }
                    if (dt.Rows[n]["SendTime"].ToString() != "")
                    {
                        model.SendTime = DateTime.Parse(dt.Rows[n]["SendTime"].ToString());
                    }
                    if (dt.Rows[n]["ReceiveTime"].ToString() != "")
                    {
                        model.ReceiveTime = DateTime.Parse(dt.Rows[n]["ReceiveTime"].ToString());
                    }
                    if (dt.Rows[n]["ApplyTime"].ToString() != "")
                    {
                        model.ApplyTime = DateTime.Parse(dt.Rows[n]["ApplyTime"].ToString());
                    }
                    if (dt.Rows[n]["FinishTime"].ToString() != "")
                    {
                        model.FinishTime = DateTime.Parse(dt.Rows[n]["FinishTime"].ToString());
                    }
                    if (dt.Rows[n]["IsSettle"].ToString() != "")
                    {
                        model.IsSettle = int.Parse(dt.Rows[n]["IsSettle"].ToString());
                    }
                    if (dt.Rows[n]["SettleTime"].ToString() != "")
                    {
                        model.SettleTime = DateTime.Parse(dt.Rows[n]["SettleTime"].ToString());
                    }
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    model.OrderCode = dt.Rows[n]["OrderCode"].ToString();
                    if (dt.Rows[n]["IntegralAmount"].ToString() != "")
                    {
                        model.IntegralAmount = decimal.Parse(dt.Rows[n]["IntegralAmount"].ToString());
                    }
                    if (dt.Rows[n]["PurchaseAmount"].ToString() != "")
                    {
                        model.PurchaseAmount = decimal.Parse(dt.Rows[n]["PurchaseAmount"].ToString());
                    }
                    if (dt.Rows[n]["SellAmount"].ToString() != "")
                    {
                        model.SellAmount = decimal.Parse(dt.Rows[n]["SellAmount"].ToString());
                    }
                    if (dt.Rows[n]["BuyTime"].ToString() != "")
                    {
                        model.BuyTime = DateTime.Parse(dt.Rows[n]["BuyTime"].ToString());
                    }
                    if (dt.Rows[n]["order001"].ToString() != "")
                    {
                        model.order001 = int.Parse(dt.Rows[n]["order001"].ToString());
                    }
                    if (dt.Rows[n]["order002"].ToString() != "")
                    {
                        model.order002 = decimal.Parse(dt.Rows[n]["order002"].ToString());
                    }
                    if (dt.Rows[n]["ReceivieAddress"].ToString() != "")
                    {
                        model.ReceivieAddress = dt.Rows[n]["ReceivieAddress"].ToString();
                    }
                    if (dt.Rows[n]["Province"].ToString() != "")
                    {
                        model.Province = dt.Rows[n]["Province"].ToString();
                    }
                    if (dt.Rows[n]["City"].ToString() != "")
                    {
                        model.City = dt.Rows[n]["City"].ToString();
                    }
                    if (dt.Rows[n]["Country"].ToString() != "")
                    {
                        model.Country = dt.Rows[n]["Country"].ToString();
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
