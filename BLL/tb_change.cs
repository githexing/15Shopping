using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_change
	/// </summary>
	public partial class tb_change
	{
		private readonly lgk.DAL.tb_change dal=new lgk.DAL.tb_change();
		public tb_change()
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
		public long Add(lgk.Model.tb_change model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_change model)
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
		public lgk.Model.tb_change GetModel(long ID)
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetDataSet(string strWhere)
        {
            return dal.GetDataSet(strWhere);
        }
        public DataSet GetDataSet2(string strWhere)
        {
            return dal.GetDataSet2(strWhere);
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
		public List<lgk.Model.tb_change> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_change> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_change> modelList = new List<lgk.Model.tb_change>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_change model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_change();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["ToUserType"]!=null && dt.Rows[n]["ToUserType"].ToString()!="")
					{
						model.ToUserType=int.Parse(dt.Rows[n]["ToUserType"].ToString());
					}
					if(dt.Rows[n]["ToUserID"]!=null && dt.Rows[n]["ToUserID"].ToString()!="")
					{
						model.ToUserID=int.Parse(dt.Rows[n]["ToUserID"].ToString());
					}
					if(dt.Rows[n]["ChangeType"]!=null && dt.Rows[n]["ChangeType"].ToString()!="")
					{
						model.ChangeType=int.Parse(dt.Rows[n]["ChangeType"].ToString());
					}
					if(dt.Rows[n]["MoneyType"]!=null && dt.Rows[n]["MoneyType"].ToString()!="")
					{
						model.MoneyType=int.Parse(dt.Rows[n]["MoneyType"].ToString());
					}
					if(dt.Rows[n]["Amount"]!=null && dt.Rows[n]["Amount"].ToString()!="")
					{
						model.Amount=decimal.Parse(dt.Rows[n]["Amount"].ToString());
					}
					if(dt.Rows[n]["ChangeDate"]!=null && dt.Rows[n]["ChangeDate"].ToString()!="")
					{
						model.ChangeDate=DateTime.Parse(dt.Rows[n]["ChangeDate"].ToString());
					}
					if(dt.Rows[n]["Change001"]!=null && dt.Rows[n]["Change001"].ToString()!="")
					{
						model.Change001=int.Parse(dt.Rows[n]["Change001"].ToString());
					}
					if(dt.Rows[n]["Change002"]!=null && dt.Rows[n]["Change002"].ToString()!="")
					{
						model.Change002=int.Parse(dt.Rows[n]["Change002"].ToString());
					}
					if(dt.Rows[n]["Change003"]!=null && dt.Rows[n]["Change003"].ToString()!="")
					{
					model.Change003=dt.Rows[n]["Change003"].ToString();
					}
					if(dt.Rows[n]["Change004"]!=null && dt.Rows[n]["Change004"].ToString()!="")
					{
					model.Change004=dt.Rows[n]["Change004"].ToString();
					}
					if(dt.Rows[n]["Change005"]!=null && dt.Rows[n]["Change005"].ToString()!="")
					{
						model.Change005=decimal.Parse(dt.Rows[n]["Change005"].ToString());
					}
					if(dt.Rows[n]["Change006"]!=null && dt.Rows[n]["Change006"].ToString()!="")
					{
						model.Change006=decimal.Parse(dt.Rows[n]["Change006"].ToString());
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

