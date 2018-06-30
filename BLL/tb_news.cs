using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_news
	/// </summary>
	public partial class tb_news
	{
		private readonly lgk.DAL.tb_news dal=new lgk.DAL.tb_news();
		public tb_news()
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
		public long Add(lgk.Model.tb_news model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_news model)
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
		public lgk.Model.tb_news GetModel(long ID)
		{
			
			return dal.GetModel(ID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_news GetModelByNewType(int typeId,int langType)
        {
            return dal.GetModelByNewType(typeId, langType);
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
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList_Rank(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList_Rank(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_news> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_news> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_news> modelList = new List<lgk.Model.tb_news>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_news model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_news();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["NewsTitle"]!=null && dt.Rows[n]["NewsTitle"].ToString()!="")
					{
					model.NewsTitle=dt.Rows[n]["NewsTitle"].ToString();
					}
					if(dt.Rows[n]["NewsContent"]!=null && dt.Rows[n]["NewsContent"].ToString()!="")
					{
					model.NewsContent=dt.Rows[n]["NewsContent"].ToString();
					}
					if(dt.Rows[n]["NewsType"]!=null && dt.Rows[n]["NewsType"].ToString()!="")
					{
						model.NewsType=int.Parse(dt.Rows[n]["NewsType"].ToString());
					}
					if(dt.Rows[n]["PublishTime"]!=null && dt.Rows[n]["PublishTime"].ToString()!="")
					{
						model.PublishTime=DateTime.Parse(dt.Rows[n]["PublishTime"].ToString());
					}
					if(dt.Rows[n]["Publisher"]!=null && dt.Rows[n]["Publisher"].ToString()!="")
					{
					model.Publisher=dt.Rows[n]["Publisher"].ToString();
					}
					if(dt.Rows[n]["ImageURL"]!=null && dt.Rows[n]["ImageURL"].ToString()!="")
					{
					model.ImageURL=dt.Rows[n]["ImageURL"].ToString();
					}
					if(dt.Rows[n]["NewType"]!=null && dt.Rows[n]["NewType"].ToString()!="")
					{
						model.NewType=int.Parse(dt.Rows[n]["NewType"].ToString());
					}
					if(dt.Rows[n]["Classify"]!=null && dt.Rows[n]["Classify"].ToString()!="")
					{
					model.Classify=dt.Rows[n]["Classify"].ToString();
					}
					if(dt.Rows[n]["Tags"]!=null && dt.Rows[n]["Tags"].ToString()!="")
					{
					model.Tags=dt.Rows[n]["Tags"].ToString();
					}
					if(dt.Rows[n]["Click"]!=null && dt.Rows[n]["Click"].ToString()!="")
					{
						model.Click=int.Parse(dt.Rows[n]["Click"].ToString());
					}
					if(dt.Rows[n]["New01"]!=null && dt.Rows[n]["New01"].ToString()!="")
					{
						model.New01=int.Parse(dt.Rows[n]["New01"].ToString());
					}
					if(dt.Rows[n]["New02"]!=null && dt.Rows[n]["New02"].ToString()!="")
					{
						model.New02=int.Parse(dt.Rows[n]["New02"].ToString());
					}
					if(dt.Rows[n]["New03"]!=null && dt.Rows[n]["New03"].ToString()!="")
					{
						model.New03=decimal.Parse(dt.Rows[n]["New03"].ToString());
					}
					if(dt.Rows[n]["New04"]!=null && dt.Rows[n]["New04"].ToString()!="")
					{
						model.New04=decimal.Parse(dt.Rows[n]["New04"].ToString());
					}
					if(dt.Rows[n]["New05"]!=null && dt.Rows[n]["New05"].ToString()!="")
					{
					model.New05=dt.Rows[n]["New05"].ToString();
					}
					if(dt.Rows[n]["New06"]!=null && dt.Rows[n]["New06"].ToString()!="")
					{
					model.New06=dt.Rows[n]["New06"].ToString();
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

