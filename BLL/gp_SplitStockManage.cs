using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// gp_SplitStockManage
	/// </summary>
	public partial class gp_SplitStockManage
	{
		private readonly lgk.DAL.gp_SplitStockManage dal=new lgk.DAL.gp_SplitStockManage();
		public gp_SplitStockManage()
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
		public long Add(lgk.Model.gp_SplitStockManage model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.gp_SplitStockManage model)
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
		public lgk.Model.gp_SplitStockManage GetModel(long ID)
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
		public List<lgk.Model.gp_SplitStockManage> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.gp_SplitStockManage> DataTableToList(DataTable dt)
		{
			List<lgk.Model.gp_SplitStockManage> modelList = new List<lgk.Model.gp_SplitStockManage>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.gp_SplitStockManage model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.gp_SplitStockManage();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=long.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["UserCode"]!=null && dt.Rows[n]["UserCode"].ToString()!="")
					{
					model.UserCode=dt.Rows[n]["UserCode"].ToString();
					}
					if(dt.Rows[n]["SplitQStock"]!=null && dt.Rows[n]["SplitQStock"].ToString()!="")
					{
						model.SplitQStock=decimal.Parse(dt.Rows[n]["SplitQStock"].ToString());
					}
					if(dt.Rows[n]["SplitSStock"]!=null && dt.Rows[n]["SplitSStock"].ToString()!="")
					{
						model.SplitSStock=decimal.Parse(dt.Rows[n]["SplitSStock"].ToString());
					}
					if(dt.Rows[n]["SplitHStock"]!=null && dt.Rows[n]["SplitHStock"].ToString()!="")
					{
						model.SplitHStock=decimal.Parse(dt.Rows[n]["SplitHStock"].ToString());
					}
					if(dt.Rows[n]["SplitStockTime"]!=null && dt.Rows[n]["SplitStockTime"].ToString()!="")
					{
						model.SplitStockTime=DateTime.Parse(dt.Rows[n]["SplitStockTime"].ToString());
					}
					if(dt.Rows[n]["SplitRate"]!=null && dt.Rows[n]["SplitRate"].ToString()!="")
					{
						model.SplitRate=decimal.Parse(dt.Rows[n]["SplitRate"].ToString());
					}
					if(dt.Rows[n]["OpenMoney"]!=null && dt.Rows[n]["OpenMoney"].ToString()!="")
					{
						model.OpenMoney=decimal.Parse(dt.Rows[n]["OpenMoney"].ToString());
					}
					if(dt.Rows[n]["Split01"]!=null && dt.Rows[n]["Split01"].ToString()!="")
					{
						model.Split01=int.Parse(dt.Rows[n]["Split01"].ToString());
					}
					if(dt.Rows[n]["Split02"]!=null && dt.Rows[n]["Split02"].ToString()!="")
					{
						model.Split02=int.Parse(dt.Rows[n]["Split02"].ToString());
					}
					if(dt.Rows[n]["Split03"]!=null && dt.Rows[n]["Split03"].ToString()!="")
					{
						model.Split03=decimal.Parse(dt.Rows[n]["Split03"].ToString());
					}
					if(dt.Rows[n]["Split04"]!=null && dt.Rows[n]["Split04"].ToString()!="")
					{
						model.Split04=decimal.Parse(dt.Rows[n]["Split04"].ToString());
					}
					if(dt.Rows[n]["Split05"]!=null && dt.Rows[n]["Split05"].ToString()!="")
					{
						model.Split05=DateTime.Parse(dt.Rows[n]["Split05"].ToString());
					}
					if(dt.Rows[n]["Split06"]!=null && dt.Rows[n]["Split06"].ToString()!="")
					{
					model.Split06=dt.Rows[n]["Split06"].ToString();
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

