using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// gp_BusinessNotes
	/// </summary>
	public partial class gp_BusinessNotes
	{
		private readonly lgk.DAL.gp_BusinessNotes dal=new lgk.DAL.gp_BusinessNotes();
		public gp_BusinessNotes()
		{}
        /// <summary>
        /// 计算交易表中代售股票
        /// </summary>
        /// <param name="a">交易状态1 待交易，2 是已完成 3 是冻结 4 是已撤单</param>
        /// <param name="b">交易会员的类型 1 是前台会员 2 是后台会员</param>
        /// <param name="c">交易的类型1 是卖出 2是买入</param>
        /// <returns></returns>
        public object GetNum(int status, int usertype, int businesstype, int uid)
        {
            return dal.GetNum(status, usertype, businesstype, uid);
        }
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
		public long Add(lgk.Model.gp_BusinessNotes model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.gp_BusinessNotes model)
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
		public lgk.Model.gp_BusinessNotes GetModel(long ID)
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
		public List<lgk.Model.gp_BusinessNotes> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.gp_BusinessNotes> DataTableToList(DataTable dt)
		{
			List<lgk.Model.gp_BusinessNotes> modelList = new List<lgk.Model.gp_BusinessNotes>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.gp_BusinessNotes model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.gp_BusinessNotes();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=long.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["UserCode"]!=null && dt.Rows[n]["UserCode"].ToString()!="")
					{
					model.UserCode=dt.Rows[n]["UserCode"].ToString();
					}
					if(dt.Rows[n]["BusinessType"]!=null && dt.Rows[n]["BusinessType"].ToString()!="")
					{
						model.BusinessType=int.Parse(dt.Rows[n]["BusinessType"].ToString());
					}
					if(dt.Rows[n]["UserType"]!=null && dt.Rows[n]["UserType"].ToString()!="")
					{
						model.UserType=int.Parse(dt.Rows[n]["UserType"].ToString());
					}
					if(dt.Rows[n]["BusinessTime"]!=null && dt.Rows[n]["BusinessTime"].ToString()!="")
					{
						model.BusinessTime=DateTime.Parse(dt.Rows[n]["BusinessTime"].ToString());
					}
					if(dt.Rows[n]["BusinessAmount"]!=null && dt.Rows[n]["BusinessAmount"].ToString()!="")
					{
						model.BusinessAmount=decimal.Parse(dt.Rows[n]["BusinessAmount"].ToString());
					}
					if(dt.Rows[n]["BusinessPrice"]!=null && dt.Rows[n]["BusinessPrice"].ToString()!="")
					{
						model.BusinessPrice=decimal.Parse(dt.Rows[n]["BusinessPrice"].ToString());
					}
					if(dt.Rows[n]["SumMoney"]!=null && dt.Rows[n]["SumMoney"].ToString()!="")
					{
						model.SumMoney=decimal.Parse(dt.Rows[n]["SumMoney"].ToString());
					}
					if(dt.Rows[n]["Poundage"]!=null && dt.Rows[n]["Poundage"].ToString()!="")
					{
						model.Poundage=decimal.Parse(dt.Rows[n]["Poundage"].ToString());
					}
					if(dt.Rows[n]["AmountMoney"]!=null && dt.Rows[n]["AmountMoney"].ToString()!="")
					{
						model.AmountMoney=decimal.Parse(dt.Rows[n]["AmountMoney"].ToString());
					}
					if(dt.Rows[n]["InStockAccount"]!=null && dt.Rows[n]["InStockAccount"].ToString()!="")
					{
						model.InStockAccount=decimal.Parse(dt.Rows[n]["InStockAccount"].ToString());
					}
					if(dt.Rows[n]["InBonusAccount"]!=null && dt.Rows[n]["InBonusAccount"].ToString()!="")
					{
						model.InBonusAccount=decimal.Parse(dt.Rows[n]["InBonusAccount"].ToString());
					}
					if(dt.Rows[n]["InManageAccount"]!=null && dt.Rows[n]["InManageAccount"].ToString()!="")
					{
						model.InManageAccount=decimal.Parse(dt.Rows[n]["InManageAccount"].ToString());
					}
					if(dt.Rows[n]["FromUserID"]!=null && dt.Rows[n]["FromUserID"].ToString()!="")
					{
						model.FromUserID=long.Parse(dt.Rows[n]["FromUserID"].ToString());
					}
					if(dt.Rows[n]["FromUserCode"]!=null && dt.Rows[n]["FromUserCode"].ToString()!="")
					{
					model.FromUserCode=dt.Rows[n]["FromUserCode"].ToString();
					}
					if(dt.Rows[n]["SucTime"]!=null && dt.Rows[n]["SucTime"].ToString()!="")
					{
						model.SucTime=DateTime.Parse(dt.Rows[n]["SucTime"].ToString());
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["Notes01"]!=null && dt.Rows[n]["Notes01"].ToString()!="")
					{
						model.Notes01=int.Parse(dt.Rows[n]["Notes01"].ToString());
					}
					if(dt.Rows[n]["Notes02"]!=null && dt.Rows[n]["Notes02"].ToString()!="")
					{
						model.Notes02=int.Parse(dt.Rows[n]["Notes02"].ToString());
					}
					if(dt.Rows[n]["Notes03"]!=null && dt.Rows[n]["Notes03"].ToString()!="")
					{
						model.Notes03=decimal.Parse(dt.Rows[n]["Notes03"].ToString());
					}
					if(dt.Rows[n]["Notes04"]!=null && dt.Rows[n]["Notes04"].ToString()!="")
					{
						model.Notes04=decimal.Parse(dt.Rows[n]["Notes04"].ToString());
					}
					if(dt.Rows[n]["Notes05"]!=null && dt.Rows[n]["Notes05"].ToString()!="")
					{
					model.Notes05=dt.Rows[n]["Notes05"].ToString();
					}
					if(dt.Rows[n]["Notes06"]!=null && dt.Rows[n]["Notes06"].ToString()!="")
					{
					model.Notes06=dt.Rows[n]["Notes06"].ToString();
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

