using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_recharge
	/// </summary>
	public partial class tb_recharge
	{
		private readonly lgk.DAL.tb_recharge dal=new lgk.DAL.tb_recharge();
		public tb_recharge()
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
		public long Add(lgk.Model.tb_recharge model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_recharge model)
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
		public lgk.Model.tb_recharge GetModel(long ID)
		{
			return dal.GetModel(ID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_recharge GetModel(string str)
        {
            return dal.GetModel(str);
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
		public List<lgk.Model.tb_recharge> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_recharge> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_recharge> modelList = new List<lgk.Model.tb_recharge>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_recharge model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_recharge();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=long.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["RechargeableMoney"]!=null && dt.Rows[n]["RechargeableMoney"].ToString()!="")
					{
						model.RechargeableMoney=decimal.Parse(dt.Rows[n]["RechargeableMoney"].ToString());
					}
					if(dt.Rows[n]["RechargeStyle"]!=null && dt.Rows[n]["RechargeStyle"].ToString()!="")
					{
						model.RechargeStyle=int.Parse(dt.Rows[n]["RechargeStyle"].ToString());
					}
					if(dt.Rows[n]["Flag"]!=null && dt.Rows[n]["Flag"].ToString()!="")
					{
						model.Flag=int.Parse(dt.Rows[n]["Flag"].ToString());
					}
					if(dt.Rows[n]["RechargeDate"]!=null && dt.Rows[n]["RechargeDate"].ToString()!="")
					{
						model.RechargeDate=DateTime.Parse(dt.Rows[n]["RechargeDate"].ToString());
					}
					if(dt.Rows[n]["YuAmount"]!=null && dt.Rows[n]["YuAmount"].ToString()!="")
					{
						model.YuAmount=decimal.Parse(dt.Rows[n]["YuAmount"].ToString());
					}
					if(dt.Rows[n]["RechargeType"]!=null && dt.Rows[n]["RechargeType"].ToString()!="")
					{
						model.RechargeType=int.Parse(dt.Rows[n]["RechargeType"].ToString());
					}
					if(dt.Rows[n]["AgentID"]!=null && dt.Rows[n]["AgentID"].ToString()!="")
					{
						model.AgentID=int.Parse(dt.Rows[n]["AgentID"].ToString());
					}
					if(dt.Rows[n]["Recharge001"]!=null && dt.Rows[n]["Recharge001"].ToString()!="")
					{
						model.Recharge001=int.Parse(dt.Rows[n]["Recharge001"].ToString());
					}
					if(dt.Rows[n]["Recharge002"]!=null && dt.Rows[n]["Recharge002"].ToString()!="")
					{
						model.Recharge002=int.Parse(dt.Rows[n]["Recharge002"].ToString());
					}
					if(dt.Rows[n]["Recharge003"]!=null && dt.Rows[n]["Recharge003"].ToString()!="")
					{
					model.Recharge003=dt.Rows[n]["Recharge003"].ToString();
					}
					if(dt.Rows[n]["Recharge004"]!=null && dt.Rows[n]["Recharge004"].ToString()!="")
					{
					model.Recharge004=dt.Rows[n]["Recharge004"].ToString();
					}
					if(dt.Rows[n]["Recharge005"]!=null && dt.Rows[n]["Recharge005"].ToString()!="")
					{
						model.Recharge005=decimal.Parse(dt.Rows[n]["Recharge005"].ToString());
					}
					if(dt.Rows[n]["Recharge006"]!=null && dt.Rows[n]["Recharge006"].ToString()!="")
					{
						model.Recharge006=decimal.Parse(dt.Rows[n]["Recharge006"].ToString());
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

