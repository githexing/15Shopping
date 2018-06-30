using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using lgk.Model;
namespace lgk.BLL
{
    //tb_PacketSend
    public partial class tb_PacketSend
    {

        private readonly lgk.DAL.tb_PacketSend dal = new lgk.DAL.tb_PacketSend();
        public tb_PacketSend()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long PackID)
        {
            return dal.Exists(PackID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_PacketSend model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_PacketSend model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long PackID)
        {

            return dal.Delete(PackID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string PackIDlist)
        {
            return dal.DeleteList(PackIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_PacketSend GetModel(long PackID)
        {

            return dal.GetModel(PackID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public lgk.Model.tb_PacketSend GetModelByCache(long PackID)
        //{

        //    string CacheKey = "tb_PacketSendModel-" + PackID;
        //    object objModel = lgk.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(PackID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = lgk.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                lgk.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (lgk.Model.tb_PacketSend)objModel;
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
        public List<lgk.Model.tb_PacketSend> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_PacketSend> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_PacketSend> modelList = new List<lgk.Model.tb_PacketSend>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_PacketSend model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_PacketSend();
                    if (dt.Rows[n]["PackID"].ToString() != "")
                    {
                        model.PackID = long.Parse(dt.Rows[n]["PackID"].ToString());
                    }
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = decimal.Parse(dt.Rows[n]["Amount"].ToString());
                    }
                    if (dt.Rows[n]["Number"].ToString() != "")
                    {
                        model.Number = int.Parse(dt.Rows[n]["Number"].ToString());
                    }
                    model.LeaveMessage = dt.Rows[n]["LeaveMessage"].ToString();
                    if (dt.Rows[n]["SendTime"].ToString() != "")
                    {
                        model.SendTime = DateTime.Parse(dt.Rows[n]["SendTime"].ToString());
                    }
                    if (dt.Rows[n]["ReceiveNum"].ToString() != "")
                    {
                        model.ReceiveNum = int.Parse(dt.Rows[n]["ReceiveNum"].ToString());
                    }
                    if (dt.Rows[n]["ReceiveMoney"].ToString() != "")
                    {
                        model.ReceiveMoney = decimal.Parse(dt.Rows[n]["ReceiveMoney"].ToString());
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