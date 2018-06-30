using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
    /// <summary>
    /// tb_bonusType
    /// </summary>
    public partial class tb_bonusType
    {
        private readonly lgk.DAL.tb_bonusType dal = new lgk.DAL.tb_bonusType();
        public tb_bonusType()
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
        public bool Exists(int TypeID)
        {
            return dal.Exists(TypeID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(lgk.Model.tb_bonusType model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_bonusType model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int TypeID)
        {

            return dal.Delete(TypeID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string TypeIDlist)
        {
            return dal.DeleteList(TypeIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_bonusType GetModel(int TypeID)
        {

            return dal.GetModel(TypeID);
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
        public List<lgk.Model.tb_bonusType> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_bonusType> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_bonusType> modelList = new List<lgk.Model.tb_bonusType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_bonusType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_bonusType();
                    if (dt.Rows[n]["TypeID"] != null && dt.Rows[n]["TypeID"].ToString() != "")
                    {
                        model.TypeID = int.Parse(dt.Rows[n]["TypeID"].ToString());
                    }
                    if (dt.Rows[n]["TypeName"] != null && dt.Rows[n]["TypeName"].ToString() != "")
                    {
                        model.TypeName = dt.Rows[n]["TypeName"].ToString();
                    }
                    if (dt.Rows[n]["TypeNameEn"] != null && dt.Rows[n]["TypeNameEn"].ToString() != "")
                    {
                        model.TypeNameEn = dt.Rows[n]["TypeNameEn"].ToString();
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

        #endregion  Method
    }
}

