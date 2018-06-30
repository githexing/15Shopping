using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_produce
	/// </summary>
	public partial class tb_produce
	{
		private readonly lgk.DAL.tb_produce dal=new lgk.DAL.tb_produce();
		public tb_produce()
		{}
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
		public bool Exists(int ProcudeID)
		{
			return dal.Exists(ProcudeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(lgk.Model.tb_produce model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_produce model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ProcudeID)
		{
			
			return dal.Delete(ProcudeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProcudeIDlist )
		{
			return dal.DeleteList(ProcudeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lgk.Model.tb_produce GetModel(int ProcudeID)
		{
			
			return dal.GetModel(ProcudeID);
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
		public List<lgk.Model.tb_produce> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_produce> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_produce> modelList = new List<lgk.Model.tb_produce>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_produce model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_produce();
					if(dt.Rows[n]["ProcudeID"]!=null && dt.Rows[n]["ProcudeID"].ToString()!="")
					{
						model.ProcudeID=int.Parse(dt.Rows[n]["ProcudeID"].ToString());
					}
					if(dt.Rows[n]["ProcudeCode"]!=null && dt.Rows[n]["ProcudeCode"].ToString()!="")
					{
					model.ProcudeCode=dt.Rows[n]["ProcudeCode"].ToString();
					}
					if(dt.Rows[n]["procudeName"]!=null && dt.Rows[n]["procudeName"].ToString()!="")
					{
					model.procudeName=dt.Rows[n]["procudeName"].ToString();
					}
					if(dt.Rows[n]["MarketPrice"]!=null && dt.Rows[n]["MarketPrice"].ToString()!="")
					{
						model.MarketPrice=decimal.Parse(dt.Rows[n]["MarketPrice"].ToString());
					}
					if(dt.Rows[n]["MemberPrice"]!=null && dt.Rows[n]["MemberPrice"].ToString()!="")
					{
						model.MemberPrice=decimal.Parse(dt.Rows[n]["MemberPrice"].ToString());
					}
					if(dt.Rows[n]["procudePV"]!=null && dt.Rows[n]["procudePV"].ToString()!="")
					{
						model.procudePV=int.Parse(dt.Rows[n]["procudePV"].ToString());
					}
					if(dt.Rows[n]["picture"]!=null && dt.Rows[n]["picture"].ToString()!="")
					{
					model.picture=dt.Rows[n]["picture"].ToString();
					}
					if(dt.Rows[n]["LinkURL"]!=null && dt.Rows[n]["LinkURL"].ToString()!="")
					{
					model.LinkURL=dt.Rows[n]["LinkURL"].ToString();
					}
					if(dt.Rows[n]["IsPutaway"]!=null && dt.Rows[n]["IsPutaway"].ToString()!="")
					{
						model.IsPutaway=int.Parse(dt.Rows[n]["IsPutaway"].ToString());
					}
					if(dt.Rows[n]["Note"]!=null && dt.Rows[n]["Note"].ToString()!="")
					{
					model.Note=dt.Rows[n]["Note"].ToString();
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

