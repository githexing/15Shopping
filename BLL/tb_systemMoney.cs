using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_systemMoney
	/// </summary>
	public partial class tb_systemMoney
	{
		private readonly lgk.DAL.tb_systemMoney dal=new lgk.DAL.tb_systemMoney();
		public tb_systemMoney()
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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(lgk.Model.tb_systemMoney model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_systemMoney model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
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
		public lgk.Model.tb_systemMoney GetModel(int ID)
		{
			
			return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_systemMoney GetModel()
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
		public List<lgk.Model.tb_systemMoney> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_systemMoney> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_systemMoney> modelList = new List<lgk.Model.tb_systemMoney>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_systemMoney model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_systemMoney();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["MoneyAccount"]!=null && dt.Rows[n]["MoneyAccount"].ToString()!="")
					{
						model.MoneyAccount=decimal.Parse(dt.Rows[n]["MoneyAccount"].ToString());
					}
					if(dt.Rows[n]["AllBonusAccount"]!=null && dt.Rows[n]["AllBonusAccount"].ToString()!="")
					{
						model.AllBonusAccount=decimal.Parse(dt.Rows[n]["AllBonusAccount"].ToString());
					}
					if(dt.Rows[n]["Money001"]!=null && dt.Rows[n]["Money001"].ToString()!="")
					{
						model.Money001=decimal.Parse(dt.Rows[n]["Money001"].ToString());
					}
					if(dt.Rows[n]["Money002"]!=null && dt.Rows[n]["Money002"].ToString()!="")
					{
						model.Money002=decimal.Parse(dt.Rows[n]["Money002"].ToString());
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

