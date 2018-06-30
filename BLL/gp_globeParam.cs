using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// gp_globeParam
	/// </summary>
	public partial class gp_globeParam
	{
		private readonly lgk.DAL.gp_globeParam dal=new lgk.DAL.gp_globeParam();
		public gp_globeParam()
		{}
		#region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.gp_globeParam model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.gp_globeParam model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long Id)
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
        public lgk.Model.gp_globeParam GetModel(long Id)
        {
            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.gp_globeParam GetModel(string strWhere)
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
        public List<lgk.Model.gp_globeParam> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.gp_globeParam> DataTableToList(DataTable dt)
        {
            List<lgk.Model.gp_globeParam> modelList = new List<lgk.Model.gp_globeParam>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.gp_globeParam model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.gp_globeParam();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = long.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.ParamName = dt.Rows[n]["ParamName"].ToString();
                    if (dt.Rows[n]["ParamAmount"].ToString() != "")
                    {
                        model.ParamAmount = decimal.Parse(dt.Rows[n]["ParamAmount"].ToString());
                    }
                    if (dt.Rows[n]["ParamInt"].ToString() != "")
                    {
                        model.ParamInt = int.Parse(dt.Rows[n]["ParamInt"].ToString());
                    }
                    model.ParamVarchar = dt.Rows[n]["ParamVarchar"].ToString();
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    if (dt.Rows[n]["ParamType"].ToString() != "")
                    {
                        model.ParamType = int.Parse(dt.Rows[n]["ParamType"].ToString());
                    }
                    model.EndRemark = dt.Rows[n]["EndRemark"].ToString();
                    if (dt.Rows[n]["IsEdit"].ToString() != "")
                    {
                        model.IsEdit = int.Parse(dt.Rows[n]["IsEdit"].ToString());
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

		#endregion  Method
	}
}

