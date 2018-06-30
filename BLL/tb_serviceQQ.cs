using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_serviceQQ
	/// </summary>
	public partial class tb_serviceQQ
	{
		private readonly lgk.DAL.tb_serviceQQ dal=new lgk.DAL.tb_serviceQQ();
		public tb_serviceQQ()
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
		public long Add(lgk.Model.tb_serviceQQ model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_serviceQQ model)
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
		public lgk.Model.tb_serviceQQ GetModel(long ID)
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
		public List<lgk.Model.tb_serviceQQ> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_serviceQQ> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_serviceQQ> modelList = new List<lgk.Model.tb_serviceQQ>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_serviceQQ model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_serviceQQ();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["ServiceName"]!=null && dt.Rows[n]["ServiceName"].ToString()!="")
					{
					model.ServiceName=dt.Rows[n]["ServiceName"].ToString();
					}
					if(dt.Rows[n]["QQnum"]!=null && dt.Rows[n]["QQnum"].ToString()!="")
					{
					model.QQnum=dt.Rows[n]["QQnum"].ToString();
					}
					if(dt.Rows[n]["QQ001"]!=null && dt.Rows[n]["QQ001"].ToString()!="")
					{
					model.QQ001=dt.Rows[n]["QQ001"].ToString();
					}
					if(dt.Rows[n]["QQ002"]!=null && dt.Rows[n]["QQ002"].ToString()!="")
					{
					model.QQ002=dt.Rows[n]["QQ002"].ToString();
					}
					if(dt.Rows[n]["QQ003"]!=null && dt.Rows[n]["QQ003"].ToString()!="")
					{
					model.QQ003=dt.Rows[n]["QQ003"].ToString();
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

