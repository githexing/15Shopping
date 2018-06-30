using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_city
	/// </summary>
	public partial class tb_city
	{
		private readonly lgk.DAL.tb_city dal=new lgk.DAL.tb_city();
		public tb_city()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(lgk.Model.tb_city model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_city model)
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
		public lgk.Model.tb_city GetModel(string strWhere)
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
		public List<lgk.Model.tb_city> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_city> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_city> modelList = new List<lgk.Model.tb_city>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_city model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_city();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["cityID"]!=null && dt.Rows[n]["cityID"].ToString()!="")
					{
					model.cityID=dt.Rows[n]["cityID"].ToString();
					}
					if(dt.Rows[n]["city"]!=null && dt.Rows[n]["city"].ToString()!="")
					{
					model.city=dt.Rows[n]["city"].ToString();
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

