using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_globeParam
	/// </summary>
	public partial class tb_globeParam
	{
		private readonly lgk.DAL.tb_globeParam dal=new lgk.DAL.tb_globeParam();
		public tb_globeParam()
		{}
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
		public long Add(lgk.Model.tb_globeParam model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_globeParam model)
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
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lgk.Model.tb_globeParam GetModel(long ID)
		{
			
			return dal.GetModel(ID);
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_globeParam GetModel(string str)
        {

            return dal.GetModel(str);
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_globeParam> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_globeParam> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_globeParam> modelList = new List<lgk.Model.tb_globeParam>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_globeParam model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_globeParam();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["ParamName"]!=null && dt.Rows[n]["ParamName"].ToString()!="")
					{
					model.ParamName=dt.Rows[n]["ParamName"].ToString();
					}
					if(dt.Rows[n]["ParamAmount"]!=null && dt.Rows[n]["ParamAmount"].ToString()!="")
					{
						model.ParamAmount=decimal.Parse(dt.Rows[n]["ParamAmount"].ToString());
					}
					if(dt.Rows[n]["ParamInt"]!=null && dt.Rows[n]["ParamInt"].ToString()!="")
					{
						model.ParamInt=int.Parse(dt.Rows[n]["ParamInt"].ToString());
					}
					if(dt.Rows[n]["ParamVarchar"]!=null && dt.Rows[n]["ParamVarchar"].ToString()!="")
					{
					model.ParamVarchar=dt.Rows[n]["ParamVarchar"].ToString();
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
					}
					if(dt.Rows[n]["EndRemark"]!=null && dt.Rows[n]["EndRemark"].ToString()!="")
					{
					model.EndRemark=dt.Rows[n]["EndRemark"].ToString();
					}
					if(dt.Rows[n]["ParamType"]!=null && dt.Rows[n]["ParamType"].ToString()!="")
					{
						model.ParamType=int.Parse(dt.Rows[n]["ParamType"].ToString());
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

