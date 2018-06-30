using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_produceType
	/// </summary>
	public partial class tb_produceType
	{
		private readonly lgk.DAL.tb_produceType dal=new lgk.DAL.tb_produceType();
		public tb_produceType()
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
		public int  Add(lgk.Model.tb_produceType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_produceType model)
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
        /// 更新商品为隐藏
        /// </summary>
        public bool DeleteForHide(int ID)
        {
            Delete(ID);
            return dal.DeleteForHide(ID);
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
		public lgk.Model.tb_produceType GetModel(int ID)
		{
			return dal.GetModel(ID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_produceType GetModel(string strWhere)
        {
            return dal.GetModel(strWhere);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetTypeName(int ID)
        {
            return dal.GetTypeName(ID);
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
		public List<lgk.Model.tb_produceType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// 获得（top条）数据列表
        /// </summary>
        public List<lgk.Model.tb_produceType> GetModelList2(int Top, string strWhere, string filedOrder)
        {
            DataSet ds = dal.GetList(Top, strWhere, filedOrder);
            return DataTableToList(ds.Tables[0]);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_produceType> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_produceType> modelList = new List<lgk.Model.tb_produceType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_produceType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_produceType();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["ParentID"]!=null && dt.Rows[n]["ParentID"].ToString()!="")
					{
						model.ParentID=int.Parse(dt.Rows[n]["ParentID"].ToString());
					}
					if(dt.Rows[n]["TypeName"]!=null && dt.Rows[n]["TypeName"].ToString()!="")
					{
					model.TypeName=dt.Rows[n]["TypeName"].ToString();
					}
					if(dt.Rows[n]["Type01"]!=null && dt.Rows[n]["Type01"].ToString()!="")
					{
						model.Type01=int.Parse(dt.Rows[n]["Type01"].ToString());
					}
					if(dt.Rows[n]["Type02"]!=null && dt.Rows[n]["Type02"].ToString()!="")
					{
						model.Type02=int.Parse(dt.Rows[n]["Type02"].ToString());
					}
					if(dt.Rows[n]["Type03"]!=null && dt.Rows[n]["Type03"].ToString()!="")
					{
						model.Type03=decimal.Parse(dt.Rows[n]["Type03"].ToString());
					}
					if(dt.Rows[n]["Type04"]!=null && dt.Rows[n]["Type04"].ToString()!="")
					{
						model.Type04=decimal.Parse(dt.Rows[n]["Type04"].ToString());
					}
					if(dt.Rows[n]["Type05"]!=null && dt.Rows[n]["Type05"].ToString()!="")
					{
					model.Type05=dt.Rows[n]["Type05"].ToString();
					}
					if(dt.Rows[n]["Type06"]!=null && dt.Rows[n]["Type06"].ToString()!="")
					{
					model.Type06=dt.Rows[n]["Type06"].ToString();
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

