using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using lgk.Model;
namespace lgk.BLL
{
    //tb_InviteInfo
    public partial class tb_InviteInfo
    {

        private readonly lgk.DAL.tb_InviteInfo dal = new lgk.DAL.tb_InviteInfo();
        public tb_InviteInfo()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_InviteInfo model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_InviteInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_InviteInfo GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        ////public lgk.Model.tb_InviteInfo GetModelByCache(int Id)
        ////{

        ////    string CacheKey = "tb_InviteInfoModel-" + Id;
        ////    object objModel = lgk.Common.DataCache.GetCache(CacheKey);
        ////    if (objModel == null)
        ////    {
        ////        try
        ////        {
        ////            objModel = dal.GetModel(Id);
        ////            if (objModel != null)
        ////            {
        ////                int ModelCache = lgk.Common.ConfigHelper.GetConfigInt("ModelCache");
        ////                lgk.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        ////            }
        ////        }
        ////        catch { }
        ////    }
        ////    return (lgk.Model.tb_InviteInfo)objModel;
        ////}

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
        public List<lgk.Model.tb_InviteInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_InviteInfo> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_InviteInfo> modelList = new List<lgk.Model.tb_InviteInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_InviteInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_InviteInfo();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.InviteInfo = dt.Rows[n]["InviteInfo"].ToString();
                    model.InviteRule = dt.Rows[n]["InviteRule"].ToString();
                    model.AppDownUrl = dt.Rows[n]["AppDownUrl"].ToString();
                    if (dt.Rows[n]["ModifyTime"].ToString() != "")
                    {
                        model.ModifyTime = DateTime.Parse(dt.Rows[n]["ModifyTime"].ToString());
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