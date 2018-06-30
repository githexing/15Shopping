using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_province
	/// </summary>
	public partial class tb_province
	{
		private readonly lgk.DAL.tb_province dal=new lgk.DAL.tb_province();
		public tb_province()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(lgk.Model.tb_province model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_province model)
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
		public lgk.Model.tb_province GetModel(string strWhere)
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
		public List<lgk.Model.tb_province> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_province> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_province> modelList = new List<lgk.Model.tb_province>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_province model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_province();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["provinceID"]!=null && dt.Rows[n]["provinceID"].ToString()!="")
					{
					model.provinceID=dt.Rows[n]["provinceID"].ToString();
					}
					if(dt.Rows[n]["province"]!=null && dt.Rows[n]["province"].ToString()!="")
					{
					model.province=dt.Rows[n]["province"].ToString();
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

