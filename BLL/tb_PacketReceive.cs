using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using lgk.Model;
namespace lgk.BLL
{
    //tb_PacketReceive
    public partial class tb_PacketReceive
    {

        private readonly lgk.DAL.tb_PacketReceive dal = new lgk.DAL.tb_PacketReceive();
        public tb_PacketReceive()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ReceiveID)
        {
            return dal.Exists(ReceiveID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_PacketReceive model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_PacketReceive model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ReceiveID)
        {

            return dal.Delete(ReceiveID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string ReceiveIDlist)
        {
            return dal.DeleteList(ReceiveIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_PacketReceive GetModel(long ReceiveID)
        {

            return dal.GetModel(ReceiveID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public lgk.Model.tb_PacketReceive GetModelByCache(long ReceiveID)
        //{

        //    string CacheKey = "tb_PacketReceiveModel-" + ReceiveID;
        //    object objModel = lgk.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ReceiveID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = lgk.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                lgk.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (lgk.Model.tb_PacketReceive)objModel;
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
        public List<lgk.Model.tb_PacketReceive> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_PacketReceive> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_PacketReceive> modelList = new List<lgk.Model.tb_PacketReceive>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_PacketReceive model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_PacketReceive();
                    if (dt.Rows[n]["ReceiveID"].ToString() != "")
                    {
                        model.ReceiveID = long.Parse(dt.Rows[n]["ReceiveID"].ToString());
                    }
                    if (dt.Rows[n]["PackID"].ToString() != "")
                    {
                        model.PackID = long.Parse(dt.Rows[n]["PackID"].ToString());
                    }
                    if (dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = decimal.Parse(dt.Rows[n]["Amount"].ToString());
                    }
                    if (dt.Rows[n]["ReceiveFlag"].ToString() != "")
                    {
                        model.ReceiveFlag = int.Parse(dt.Rows[n]["ReceiveFlag"].ToString());
                    }
                    if (dt.Rows[n]["ReceiveUserID"].ToString() != "")
                    {
                        model.ReceiveUserID = long.Parse(dt.Rows[n]["ReceiveUserID"].ToString());
                    }
                    if (dt.Rows[n]["ReceiveTime"].ToString() != "")
                    {
                        model.ReceiveTime = DateTime.Parse(dt.Rows[n]["ReceiveTime"].ToString());
                    }
                    if (dt.Rows[n]["CancelTime"].ToString() != "")
                    {
                        model.CancelTime = DateTime.Parse(dt.Rows[n]["CancelTime"].ToString());
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