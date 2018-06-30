using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// gp_BusinessAmount
	/// </summary>
	public partial class gp_BusinessAmount
	{
		private readonly lgk.DAL.gp_BusinessAmount dal=new lgk.DAL.gp_BusinessAmount();
		public gp_BusinessAmount()
		{}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(DateTime date)
        {
            return dal.Exists(date);
        }
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
		public long Add(lgk.Model.gp_BusinessAmount model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.gp_BusinessAmount model)
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
		public lgk.Model.gp_BusinessAmount GetModel(long ID)
		{
			
			return dal.GetModel(ID);
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
		public List<lgk.Model.gp_BusinessAmount> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.gp_BusinessAmount> DataTableToList(DataTable dt)
		{
			List<lgk.Model.gp_BusinessAmount> modelList = new List<lgk.Model.gp_BusinessAmount>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.gp_BusinessAmount model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.gp_BusinessAmount();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["BusinessTime"]!=null && dt.Rows[n]["BusinessTime"].ToString()!="")
					{
						model.BusinessTime=DateTime.Parse(dt.Rows[n]["BusinessTime"].ToString());
					}
					if(dt.Rows[n]["BusinessAmount"]!=null && dt.Rows[n]["BusinessAmount"].ToString()!="")
					{
						model.BusinessAmount=decimal.Parse(dt.Rows[n]["BusinessAmount"].ToString());
					}
					if(dt.Rows[n]["by01"]!=null && dt.Rows[n]["by01"].ToString()!="")
					{
						model.by01=int.Parse(dt.Rows[n]["by01"].ToString());
					}
					if(dt.Rows[n]["by02"]!=null && dt.Rows[n]["by02"].ToString()!="")
					{
						model.by02=decimal.Parse(dt.Rows[n]["by02"].ToString());
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

