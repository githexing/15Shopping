﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using lgk.Model;
namespace lgk.BLL
{
    //tb_FriendDynamic
    public partial class tb_FriendDynamic
    {

        private readonly lgk.DAL.tb_FriendDynamic dal = new lgk.DAL.tb_FriendDynamic();
        public tb_FriendDynamic()
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
        public long Add(lgk.Model.tb_FriendDynamic model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_FriendDynamic model)
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
        public lgk.Model.tb_FriendDynamic GetModel(long ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public lgk.Model.tb_FriendDynamic GetModelByCache(long ID)
        //{

        //    string CacheKey = "tb_FriendDynamicModel-" + ID;
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
        //    return (lgk.Model.tb_FriendDynamic)objModel;
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
        public List<lgk.Model.tb_FriendDynamic> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_FriendDynamic> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_FriendDynamic> modelList = new List<lgk.Model.tb_FriendDynamic>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_FriendDynamic model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_FriendDynamic();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = long.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    model.Content = dt.Rows[n]["Content"].ToString();
                    model.Pic = dt.Rows[n]["Pic"].ToString();
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["GoodNum"].ToString() != "")
                    {
                        model.GoodNum = int.Parse(dt.Rows[n]["GoodNum"].ToString());
                    }
                    if (dt.Rows[n]["CommentNum"].ToString() != "")
                    {
                        model.CommentNum = int.Parse(dt.Rows[n]["CommentNum"].ToString());
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