using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_userPro
	/// </summary>
	public partial class tb_userPro
	{
		private readonly lgk.DAL.tb_userPro dal=new lgk.DAL.tb_userPro();
		public tb_userPro()
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
		public int  Add(lgk.Model.tb_userPro model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_userPro model)
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
		public lgk.Model.tb_userPro GetModel(int ID)
		{
			return dal.GetModel(ID);
		}
        public lgk.Model.tb_userPro GetModel(string strwhere)
        {
            return dal.GetModel(strwhere);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_userPro GetModelByUserID(int UserID)
        {
            return dal.GetModelByUserID(UserID);
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
		public List<lgk.Model.tb_userPro> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_userPro> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_userPro> modelList = new List<lgk.Model.tb_userPro>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_userPro model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_userPro();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=long.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["LastLevel"]!=null && dt.Rows[n]["LastLevel"].ToString()!="")
					{
						model.LastLevel=int.Parse(dt.Rows[n]["LastLevel"].ToString());
					}
					if(dt.Rows[n]["EndLevel"]!=null && dt.Rows[n]["EndLevel"].ToString()!="")
					{
						model.EndLevel=int.Parse(dt.Rows[n]["EndLevel"].ToString());
					}
					if(dt.Rows[n]["ProMoney"]!=null && dt.Rows[n]["ProMoney"].ToString()!="")
					{
						model.ProMoney=decimal.Parse(dt.Rows[n]["ProMoney"].ToString());
					}
					if(dt.Rows[n]["AddDate"]!=null && dt.Rows[n]["AddDate"].ToString()!="")
					{
						model.AddDate=DateTime.Parse(dt.Rows[n]["AddDate"].ToString());
					}
					if(dt.Rows[n]["FlagDate"]!=null && dt.Rows[n]["FlagDate"].ToString()!="")
					{
						model.FlagDate=DateTime.Parse(dt.Rows[n]["FlagDate"].ToString());
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
					}
					if(dt.Rows[n]["Flag"]!=null && dt.Rows[n]["Flag"].ToString()!="")
					{
						model.Flag=int.Parse(dt.Rows[n]["Flag"].ToString());
					}
					if(dt.Rows[n]["Pro001"]!=null && dt.Rows[n]["Pro001"].ToString()!="")
					{
						model.Pro001=int.Parse(dt.Rows[n]["Pro001"].ToString());
					}
					if(dt.Rows[n]["Pro002"]!=null && dt.Rows[n]["Pro002"].ToString()!="")
					{
						model.Pro002=int.Parse(dt.Rows[n]["Pro002"].ToString());
					}
					if(dt.Rows[n]["Pro003"]!=null && dt.Rows[n]["Pro003"].ToString()!="")
					{
						model.Pro003=decimal.Parse(dt.Rows[n]["Pro003"].ToString());
					}
					if(dt.Rows[n]["Pro004"]!=null && dt.Rows[n]["Pro004"].ToString()!="")
					{
						model.Pro004=decimal.Parse(dt.Rows[n]["Pro004"].ToString());
					}
					if(dt.Rows[n]["Pro005"]!=null && dt.Rows[n]["Pro005"].ToString()!="")
					{
						model.Pro005=decimal.Parse(dt.Rows[n]["Pro005"].ToString());
					}
					if(dt.Rows[n]["Pro006"]!=null && dt.Rows[n]["Pro006"].ToString()!="")
					{
					model.Pro006=dt.Rows[n]["Pro006"].ToString();
					}
					if(dt.Rows[n]["Pro007"]!=null && dt.Rows[n]["Pro007"].ToString()!="")
					{
					model.Pro007=dt.Rows[n]["Pro007"].ToString();
					}
					if(dt.Rows[n]["Pro008"]!=null && dt.Rows[n]["Pro008"].ToString()!="")
					{
					model.Pro008=dt.Rows[n]["Pro008"].ToString();
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

