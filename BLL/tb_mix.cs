using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_mix
	/// </summary>
	public partial class tb_mix
	{
		private readonly lgk.DAL.tb_mix dal=new lgk.DAL.tb_mix();
		public tb_mix()
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
		public long Add(lgk.Model.tb_mix model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_mix model)
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
		public lgk.Model.tb_mix GetModel(long ID)
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
        public DataSet GetJoinList(string strWhere)
        {
            return dal.GetJoinList(strWhere);
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
		public List<lgk.Model.tb_mix> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_mix> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_mix> modelList = new List<lgk.Model.tb_mix>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_mix model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_mix();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=long.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["BonusID"]!=null && dt.Rows[n]["BonusID"].ToString()!="")
					{
						model.BonusID=int.Parse(dt.Rows[n]["BonusID"].ToString());
					}
					if(dt.Rows[n]["Amount"]!=null && dt.Rows[n]["Amount"].ToString()!="")
					{
						model.Amount=decimal.Parse(dt.Rows[n]["Amount"].ToString());
					}
					if(dt.Rows[n]["AddTime"]!=null && dt.Rows[n]["AddTime"].ToString()!="")
					{
						model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
					}
					if(dt.Rows[n]["Source"]!=null && dt.Rows[n]["Source"].ToString()!="")
					{
					model.Source=dt.Rows[n]["Source"].ToString();
					}
					if(dt.Rows[n]["FromUserID"]!=null && dt.Rows[n]["FromUserID"].ToString()!="")
					{
						model.FromUserID=int.Parse(dt.Rows[n]["FromUserID"].ToString());
					}
					if(dt.Rows[n]["Mix001"]!=null && dt.Rows[n]["Mix001"].ToString()!="")
					{
						model.Mix001=int.Parse(dt.Rows[n]["Mix001"].ToString());
					}
					if(dt.Rows[n]["Mix002"]!=null && dt.Rows[n]["Mix002"].ToString()!="")
					{
						model.Mix002=int.Parse(dt.Rows[n]["Mix002"].ToString());
					}
					if(dt.Rows[n]["Mix003"]!=null && dt.Rows[n]["Mix003"].ToString()!="")
					{
					model.Mix003=dt.Rows[n]["Mix003"].ToString();
					}
					if(dt.Rows[n]["Mix004"]!=null && dt.Rows[n]["Mix004"].ToString()!="")
					{
					model.Mix004=dt.Rows[n]["Mix004"].ToString();
					}
					if(dt.Rows[n]["Mix005"]!=null && dt.Rows[n]["Mix005"].ToString()!="")
					{
						model.Mix005=decimal.Parse(dt.Rows[n]["Mix005"].ToString());
					}
					if(dt.Rows[n]["Mix006"]!=null && dt.Rows[n]["Mix006"].ToString()!="")
					{
						model.Mix006=decimal.Parse(dt.Rows[n]["Mix006"].ToString());
					}
					if(dt.Rows[n]["Mix007"]!=null && dt.Rows[n]["Mix007"].ToString()!="")
					{
						model.Mix007=DateTime.Parse(dt.Rows[n]["Mix007"].ToString());
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

