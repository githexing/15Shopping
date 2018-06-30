using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_journal
	/// </summary>
	public partial class tb_journal
	{
		private readonly lgk.DAL.tb_journal dal=new lgk.DAL.tb_journal();
		public tb_journal()
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
		public long Add(lgk.Model.tb_journal model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_journal model)
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
		public lgk.Model.tb_journal GetModel(long ID)
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
		public List<lgk.Model.tb_journal> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_journal> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_journal> modelList = new List<lgk.Model.tb_journal>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_journal model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_journal();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
					}
					if(dt.Rows[n]["InAmount"]!=null && dt.Rows[n]["InAmount"].ToString()!="")
					{
						model.InAmount=decimal.Parse(dt.Rows[n]["InAmount"].ToString());
					}
					if(dt.Rows[n]["OutAmount"]!=null && dt.Rows[n]["OutAmount"].ToString()!="")
					{
						model.OutAmount=decimal.Parse(dt.Rows[n]["OutAmount"].ToString());
					}
					if(dt.Rows[n]["BalanceAmount"]!=null && dt.Rows[n]["BalanceAmount"].ToString()!="")
					{
						model.BalanceAmount=decimal.Parse(dt.Rows[n]["BalanceAmount"].ToString());
					}
					if(dt.Rows[n]["JournalDate"]!=null && dt.Rows[n]["JournalDate"].ToString()!="")
					{
						model.JournalDate=DateTime.Parse(dt.Rows[n]["JournalDate"].ToString());
					}
					if(dt.Rows[n]["JournalType"]!=null && dt.Rows[n]["JournalType"].ToString()!="")
					{
						model.JournalType=int.Parse(dt.Rows[n]["JournalType"].ToString());
					}
					if(dt.Rows[n]["Journal01"]!=null && dt.Rows[n]["Journal01"].ToString()!="")
					{
						model.Journal01=int.Parse(dt.Rows[n]["Journal01"].ToString());
					}
					if(dt.Rows[n]["Journal02"]!=null && dt.Rows[n]["Journal02"].ToString()!="")
					{
						model.Journal02=int.Parse(dt.Rows[n]["Journal02"].ToString());
					}
					if(dt.Rows[n]["Journal03"]!=null && dt.Rows[n]["Journal03"].ToString()!="")
					{
					model.Journal03=dt.Rows[n]["Journal03"].ToString();
					}
					if(dt.Rows[n]["Journal04"]!=null && dt.Rows[n]["Journal04"].ToString()!="")
					{
					model.Journal04=dt.Rows[n]["Journal04"].ToString();
					}
					if(dt.Rows[n]["Journal05"]!=null && dt.Rows[n]["Journal05"].ToString()!="")
					{
						model.Journal05=decimal.Parse(dt.Rows[n]["Journal05"].ToString());
					}
					if(dt.Rows[n]["Journal06"]!=null && dt.Rows[n]["Journal06"].ToString()!="")
					{
						model.Journal06=decimal.Parse(dt.Rows[n]["Journal06"].ToString());
					}
					if(dt.Rows[n]["Journal07"]!=null && dt.Rows[n]["Journal07"].ToString()!="")
					{
						model.Journal07=DateTime.Parse(dt.Rows[n]["Journal07"].ToString());
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
        /// 增加一条数据
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
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

