using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_remit
	/// </summary>
	public partial class tb_remit
	{
		private readonly lgk.DAL.tb_remit dal=new lgk.DAL.tb_remit();
		public tb_remit()
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
		public long Add(lgk.Model.tb_remit model)
		{
			return dal.Add(model);
		}
        public int AddBack(lgk.Model.tb_remitBack model)
        {
            return dal.AddBack(model);
        }
        public lgk.Model.tb_remitBack GetBack(string Strwhere)
        {
            return dal.GetBack(Strwhere);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_remit model)
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
        /// 撤销一条数据
        /// </summary>
        public bool Cancel(long ID)
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
		public lgk.Model.tb_remit GetModel(long ID)
		{
			
			return dal.GetModel(ID);
		}
        public lgk.Model.tb_remit GetModel(string where)
        {

            return dal.GetModel(where);
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
		public List<lgk.Model.tb_remit> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_remit> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_remit> modelList = new List<lgk.Model.tb_remit>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_remit model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_remit();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["BankName"]!=null && dt.Rows[n]["BankName"].ToString()!="")
					{
					model.BankName=dt.Rows[n]["BankName"].ToString();
					}
					if(dt.Rows[n]["BankAccount"]!=null && dt.Rows[n]["BankAccount"].ToString()!="")
					{
					model.BankAccount=dt.Rows[n]["BankAccount"].ToString();
					}
					if(dt.Rows[n]["BankAccountUser"]!=null && dt.Rows[n]["BankAccountUser"].ToString()!="")
					{
					model.BankAccountUser=dt.Rows[n]["BankAccountUser"].ToString();
					}
					if(dt.Rows[n]["RechargeableDate"]!=null && dt.Rows[n]["RechargeableDate"].ToString()!="")
					{
						model.RechargeableDate=DateTime.Parse(dt.Rows[n]["RechargeableDate"].ToString());
					}
					if(dt.Rows[n]["AddDate"]!=null && dt.Rows[n]["AddDate"].ToString()!="")
					{
						model.AddDate=DateTime.Parse(dt.Rows[n]["AddDate"].ToString());
					}
					if(dt.Rows[n]["State"]!=null && dt.Rows[n]["State"].ToString()!="")
					{
						model.State=int.Parse(dt.Rows[n]["State"].ToString());
					}
					if(dt.Rows[n]["RemitMoney"]!=null && dt.Rows[n]["RemitMoney"].ToString()!="")
					{
						model.RemitMoney=decimal.Parse(dt.Rows[n]["RemitMoney"].ToString());
					}
					if(dt.Rows[n]["YuAmount"]!=null && dt.Rows[n]["YuAmount"].ToString()!="")
					{
						model.YuAmount=decimal.Parse(dt.Rows[n]["YuAmount"].ToString());
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
					}
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=long.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["PassDate"]!=null && dt.Rows[n]["PassDate"].ToString()!="")
					{
						model.PassDate=DateTime.Parse(dt.Rows[n]["PassDate"].ToString());
					}
					if(dt.Rows[n]["Remit001"]!=null && dt.Rows[n]["Remit001"].ToString()!="")
					{
						model.Remit001=int.Parse(dt.Rows[n]["Remit001"].ToString());
					}
					if(dt.Rows[n]["Remit002"]!=null && dt.Rows[n]["Remit002"].ToString()!="")
					{
						model.Remit002=int.Parse(dt.Rows[n]["Remit002"].ToString());
					}
					if(dt.Rows[n]["Remit003"]!=null && dt.Rows[n]["Remit003"].ToString()!="")
					{
					model.Remit003=dt.Rows[n]["Remit003"].ToString();
					}
					if(dt.Rows[n]["Remit004"]!=null && dt.Rows[n]["Remit004"].ToString()!="")
					{
					model.Remit004=dt.Rows[n]["Remit004"].ToString();
					}
					if(dt.Rows[n]["Remit005"]!=null && dt.Rows[n]["Remit005"].ToString()!="")
					{
						model.Remit005=dt.Rows[n]["Remit005"].ToString();
					}
					if(dt.Rows[n]["Remit006"]!=null && dt.Rows[n]["Remit006"].ToString()!="")
					{
						model.Remit006=decimal.Parse(dt.Rows[n]["Remit006"].ToString());
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

