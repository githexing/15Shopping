using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_area
	/// </summary>
	public partial class tb_area
	{
		private readonly lgk.DAL.tb_area dal=new lgk.DAL.tb_area();
		public tb_area()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(lgk.Model.tb_area model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_area model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lgk.Model.tb_area GetModel(string strWhere)
		{
			//该表无主键信息，请自定义主键/条件字段
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_area> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_area> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_area> modelList = new List<lgk.Model.tb_area>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_area model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_area();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["areaID"]!=null && dt.Rows[n]["areaID"].ToString()!="")
					{
					model.areaID=dt.Rows[n]["areaID"].ToString();
					}
					if(dt.Rows[n]["area"]!=null && dt.Rows[n]["area"].ToString()!="")
					{
					model.area=dt.Rows[n]["area"].ToString();
					}
					if(dt.Rows[n]["father"]!=null && dt.Rows[n]["father"].ToString()!="")
					{
					model.father=dt.Rows[n]["father"].ToString();
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

