using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_systemBank
	/// </summary>
	public partial class tb_systemBank
	{
		private readonly lgk.DAL.tb_systemBank dal=new lgk.DAL.tb_systemBank();
		public tb_systemBank()
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
		public int  Add(lgk.Model.tb_systemBank model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_systemBank model)
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
        /// 停用一条数据
        /// </summary>
        public bool Cancel(int ID)
        {
            return dal.Cancel(ID);
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
		public lgk.Model.tb_systemBank GetModel(int ID)
		{
			
			return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_systemBank GetModel(string bankname)
        {

            return dal.GetModel(bankname);
        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_systemBank GetModel()
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
		public List<lgk.Model.tb_systemBank> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        public lgk.Model.tb_systemBank strGetModel(string strWhere)
        {
            //DataSet ds = dal.GetList(strWhere);
            return dal.strGetModel(strWhere); ;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_systemBank> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_systemBank> modelList = new List<lgk.Model.tb_systemBank>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_systemBank model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_systemBank();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["BankName"]!=null && dt.Rows[n]["BankName"].ToString()!="")
					{
					model.BankName=dt.Rows[n]["BankName"].ToString();
					}
					if(dt.Rows[n]["BankAddress"]!=null && dt.Rows[n]["BankAddress"].ToString()!="")
					{
					model.BankAddress=dt.Rows[n]["BankAddress"].ToString();
					}
					if(dt.Rows[n]["BankAccount"]!=null && dt.Rows[n]["BankAccount"].ToString()!="")
					{
					model.BankAccount=dt.Rows[n]["BankAccount"].ToString();
					}
					if(dt.Rows[n]["BankAccountUser"]!=null && dt.Rows[n]["BankAccountUser"].ToString()!="")
					{
					model.BankAccountUser=dt.Rows[n]["BankAccountUser"].ToString();
					}
					if(dt.Rows[n]["BankType"]!=null && dt.Rows[n]["BankType"].ToString()!="")
					{
						model.BankType=int.Parse(dt.Rows[n]["BankType"].ToString());
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

