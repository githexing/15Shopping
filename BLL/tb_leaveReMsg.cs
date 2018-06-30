using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_leaveReMsg
	/// </summary>
	public partial class tb_leaveReMsg
	{
		private readonly lgk.DAL.tb_leaveReMsg dal=new lgk.DAL.tb_leaveReMsg();
		public tb_leaveReMsg()
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
		public long Add(lgk.Model.tb_leaveReMsg model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_leaveReMsg model)
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
		public lgk.Model.tb_leaveReMsg GetModel(long ID)
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
		public List<lgk.Model.tb_leaveReMsg> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_leaveReMsg> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_leaveReMsg> modelList = new List<lgk.Model.tb_leaveReMsg>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_leaveReMsg model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_leaveReMsg();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["LeaveID"]!=null && dt.Rows[n]["LeaveID"].ToString()!="")
					{
						model.LeaveID=long.Parse(dt.Rows[n]["LeaveID"].ToString());
					}
					if(dt.Rows[n]["ReContent"]!=null && dt.Rows[n]["ReContent"].ToString()!="")
					{
					model.ReContent=dt.Rows[n]["ReContent"].ToString();
					}
					if(dt.Rows[n]["ReTime"]!=null && dt.Rows[n]["ReTime"].ToString()!="")
					{
						model.ReTime=DateTime.Parse(dt.Rows[n]["ReTime"].ToString());
					}
					if(dt.Rows[n]["UserType"]!=null && dt.Rows[n]["UserType"].ToString()!="")
					{
						model.UserType=int.Parse(dt.Rows[n]["UserType"].ToString());
					}
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=long.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["UserCode"]!=null && dt.Rows[n]["UserCode"].ToString()!="")
					{
					model.UserCode=dt.Rows[n]["UserCode"].ToString();
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

