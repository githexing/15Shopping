using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using lgk.Model;
namespace lgk.BLL
{
    //tb_OrderInvest
    public partial class tb_OrderInvest
    {

        private readonly lgk.DAL.tb_OrderInvest dal = new lgk.DAL.tb_OrderInvest();
        public tb_OrderInvest()
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
        public int Add(lgk.Model.tb_OrderInvest model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_OrderInvest model)
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_OrderInvest GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public lgk.Model.tb_OrderInvest GetModelByCache(int ID)
        //{

        //    string CacheKey = "tb_OrderInvestModel-" + ID;
        //    object objModel = lgk.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = lgk.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                lgk.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (lgk.Model.tb_OrderInvest)objModel;
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
        public List<lgk.Model.tb_OrderInvest> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_OrderInvest> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_OrderInvest> modelList = new List<lgk.Model.tb_OrderInvest>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_OrderInvest model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_OrderInvest();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["GetDays"].ToString() != "")
                    {
                        model.GetDays = int.Parse(dt.Rows[n]["GetDays"].ToString());
                    }
                    if (dt.Rows[n]["GetInterest"].ToString() != "")
                    {
                        model.GetInterest = decimal.Parse(dt.Rows[n]["GetInterest"].ToString());
                    }
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    model.OrderCode = dt.Rows[n]["OrderCode"].ToString();
                    if (dt.Rows[n]["AccountType"].ToString() != "")
                    {
                        model.AccountType = int.Parse(dt.Rows[n]["AccountType"].ToString());
                    }
                    if (dt.Rows[n]["InvestType"].ToString() != "")
                    {
                        model.InvestType = int.Parse(dt.Rows[n]["InvestType"].ToString());
                    }
                    if (dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = decimal.Parse(dt.Rows[n]["Amount"].ToString());
                    }
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["OutType"].ToString() != "")
                    {
                        model.OutType = int.Parse(dt.Rows[n]["OutType"].ToString());
                    }
                    if (dt.Rows[n]["OutTime"].ToString() != "")
                    {
                        model.OutTime = DateTime.Parse(dt.Rows[n]["OutTime"].ToString());
                    }
                    if (dt.Rows[n]["ReleasedPhase"].ToString() != "")
                    {
                        model.ReleasedPhase = decimal.Parse(dt.Rows[n]["ReleasedPhase"].ToString());
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