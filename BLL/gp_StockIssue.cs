using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// gp_StockIssue
	/// </summary>
	public partial class gp_StockIssue
	{
		private readonly lgk.DAL.gp_StockIssue dal=new lgk.DAL.gp_StockIssue();
		public gp_StockIssue()
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
        /// 更新可交易股票
        /// </summary>
        /// <param name="id"></param>
        /// <param name="money"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int UpdateSurplusAmount(int id, decimal money, int where)
        {
            return dal.UpdateSurplusAmount(id, money, where);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(lgk.Model.gp_StockIssue model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.gp_StockIssue model)
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
		public lgk.Model.gp_StockIssue GetModel(long ID)
		{
			
			return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.gp_StockIssue GetModel()
        {

            return dal.GetModel();
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
		public List<lgk.Model.gp_StockIssue> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.gp_StockIssue> DataTableToList(DataTable dt)
		{
			List<lgk.Model.gp_StockIssue> modelList = new List<lgk.Model.gp_StockIssue>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.gp_StockIssue model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.gp_StockIssue();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["IssueAmount"]!=null && dt.Rows[n]["IssueAmount"].ToString()!="")
					{
						model.IssueAmount=decimal.Parse(dt.Rows[n]["IssueAmount"].ToString());
					}
					if(dt.Rows[n]["SurplusAmount"]!=null && dt.Rows[n]["SurplusAmount"].ToString()!="")
					{
						model.SurplusAmount=decimal.Parse(dt.Rows[n]["SurplusAmount"].ToString());
					}
					if(dt.Rows[n]["SaleAmount"]!=null && dt.Rows[n]["SaleAmount"].ToString()!="")
					{
						model.SaleAmount=decimal.Parse(dt.Rows[n]["SaleAmount"].ToString());
					}
					if(dt.Rows[n]["AddTime"]!=null && dt.Rows[n]["AddTime"].ToString()!="")
					{
						model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
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

