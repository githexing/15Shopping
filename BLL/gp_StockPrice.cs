using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// gp_StockPrice
	/// </summary>
	public partial class gp_StockPrice
	{
		private readonly lgk.DAL.gp_StockPrice dal=new lgk.DAL.gp_StockPrice();
		public gp_StockPrice()
		{}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.gp_StockPrice GetModel(string strWhere)
        {
            return dal.GetModel(strWhere);
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
		public long Add(lgk.Model.gp_StockPrice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.gp_StockPrice model)
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
		public lgk.Model.gp_StockPrice GetModel(long ID)
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
		public List<lgk.Model.gp_StockPrice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.gp_StockPrice> DataTableToList(DataTable dt)
		{
			List<lgk.Model.gp_StockPrice> modelList = new List<lgk.Model.gp_StockPrice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.gp_StockPrice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.gp_StockPrice();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["PriceType"]!=null && dt.Rows[n]["PriceType"].ToString()!="")
					{
						model.PriceType=int.Parse(dt.Rows[n]["PriceType"].ToString());
					}
					if(dt.Rows[n]["BusinessTime"]!=null && dt.Rows[n]["BusinessTime"].ToString()!="")
					{
						model.BusinessTime=DateTime.Parse(dt.Rows[n]["BusinessTime"].ToString());
					}
					if(dt.Rows[n]["UpPrice"]!=null && dt.Rows[n]["UpPrice"].ToString()!="")
					{
						model.UpPrice=decimal.Parse(dt.Rows[n]["UpPrice"].ToString());
					}
					if(dt.Rows[n]["OpenMoney"]!=null && dt.Rows[n]["OpenMoney"].ToString()!="")
					{
						model.OpenMoney=decimal.Parse(dt.Rows[n]["OpenMoney"].ToString());
					}
					if(dt.Rows[n]["Price"]!=null && dt.Rows[n]["Price"].ToString()!="")
					{
						model.Price=decimal.Parse(dt.Rows[n]["Price"].ToString());
					}
					if(dt.Rows[n]["Up_DropDayNumber"]!=null && dt.Rows[n]["Up_DropDayNumber"].ToString()!="")
					{
						model.Up_DropDayNumber=int.Parse(dt.Rows[n]["Up_DropDayNumber"].ToString());
					}
					if(dt.Rows[n]["LastOpenMoney"]!=null && dt.Rows[n]["LastOpenMoney"].ToString()!="")
					{
						model.LastOpenMoney=decimal.Parse(dt.Rows[n]["LastOpenMoney"].ToString());
					}
					if(dt.Rows[n]["LastUp_DropDayNumber"]!=null && dt.Rows[n]["LastUp_DropDayNumber"].ToString()!="")
					{
						model.LastUp_DropDayNumber=DateTime.Parse(dt.Rows[n]["LastUp_DropDayNumber"].ToString());
					}
					if(dt.Rows[n]["AddTime"]!=null && dt.Rows[n]["AddTime"].ToString()!="")
					{
						model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
					}
					if(dt.Rows[n]["Price01"]!=null && dt.Rows[n]["Price01"].ToString()!="")
					{
						model.Price01=int.Parse(dt.Rows[n]["Price01"].ToString());
					}
					if(dt.Rows[n]["Price02"]!=null && dt.Rows[n]["Price02"].ToString()!="")
					{
						model.Price02=int.Parse(dt.Rows[n]["Price02"].ToString());
					}
					if(dt.Rows[n]["Price03"]!=null && dt.Rows[n]["Price03"].ToString()!="")
					{
						model.Price03=int.Parse(dt.Rows[n]["Price03"].ToString());
					}
					if(dt.Rows[n]["Price04"]!=null && dt.Rows[n]["Price04"].ToString()!="")
					{
						model.Price04=DateTime.Parse(dt.Rows[n]["Price04"].ToString());
					}
					if(dt.Rows[n]["Price05"]!=null && dt.Rows[n]["Price05"].ToString()!="")
					{
						model.Price05=DateTime.Parse(dt.Rows[n]["Price05"].ToString());
					}
					if(dt.Rows[n]["Price06"]!=null && dt.Rows[n]["Price06"].ToString()!="")
					{
						model.Price06=decimal.Parse(dt.Rows[n]["Price06"].ToString());
					}
					if(dt.Rows[n]["Price07"]!=null && dt.Rows[n]["Price07"].ToString()!="")
					{
						model.Price07=decimal.Parse(dt.Rows[n]["Price07"].ToString());
					}
					if(dt.Rows[n]["Price08"]!=null && dt.Rows[n]["Price08"].ToString()!="")
					{
						model.Price08=decimal.Parse(dt.Rows[n]["Price08"].ToString());
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

