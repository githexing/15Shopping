using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_admin
	/// </summary>
	public partial class tb_admin
	{
		private readonly lgk.DAL.tb_admin dal=new lgk.DAL.tb_admin();
		public tb_admin()
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
		public int  Add(lgk.Model.tb_admin model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_admin model)
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
		public lgk.Model.tb_admin GetModel(int ID)
		{
			
			return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_admin GetModel(string code)
        {

            return dal.GetModel(code);
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
		public List<lgk.Model.tb_admin> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_admin> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_admin> modelList = new List<lgk.Model.tb_admin>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_admin model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_admin();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["UserName"]!=null && dt.Rows[n]["UserName"].ToString()!="")
					{
					model.UserName=dt.Rows[n]["UserName"].ToString();
					}
					if(dt.Rows[n]["TrueName"]!=null && dt.Rows[n]["TrueName"].ToString()!="")
					{
					model.TrueName=dt.Rows[n]["TrueName"].ToString();
					}
					if(dt.Rows[n]["Password"]!=null && dt.Rows[n]["Password"].ToString()!="")
					{
					model.Password=dt.Rows[n]["Password"].ToString();
					}
					if(dt.Rows[n]["SecondPassword"]!=null && dt.Rows[n]["SecondPassword"].ToString()!="")
					{
					model.SecondPassword=dt.Rows[n]["SecondPassword"].ToString();
					}
					if(dt.Rows[n]["ThirdPassword"]!=null && dt.Rows[n]["ThirdPassword"].ToString()!="")
					{
					model.ThirdPassword=dt.Rows[n]["ThirdPassword"].ToString();
					}
					if(dt.Rows[n]["Limits"]!=null && dt.Rows[n]["Limits"].ToString()!="")
					{
					model.Limits=dt.Rows[n]["Limits"].ToString();
					}
					if(dt.Rows[n]["AddDate"]!=null && dt.Rows[n]["AddDate"].ToString()!="")
					{
						model.AddDate=DateTime.Parse(dt.Rows[n]["AddDate"].ToString());
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

