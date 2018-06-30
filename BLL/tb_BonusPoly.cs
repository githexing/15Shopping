using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using lgk.Model;
namespace lgk.BLL {
	 	//tb_BonusPoly
		public partial class tb_BonusPoly
	{
   		     
		private readonly lgk.DAL.tb_BonusPoly dal=new lgk.DAL.tb_BonusPoly();
		public tb_BonusPoly()
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
		public long  Add(lgk.Model.tb_BonusPoly model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_BonusPoly model)
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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lgk.Model.tb_BonusPoly GetModel(long ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		//public lgk.Model.tb_BonusPoly GetModelByCache(long ID)
		//{
			
		//	string CacheKey = "tb_BonusPolyModel-" + ID;
		//	object objModel = lgk.Common.DataCache.GetCache(CacheKey);
		//	if (objModel == null)
		//	{
		//		try
		//		{
		//			objModel = dal.GetModel(ID);
		//			if (objModel != null)
		//			{
		//				int ModelCache = lgk.Common.ConfigHelper.GetConfigInt("ModelCache");
		//				lgk.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
		//			}
		//		}
		//		catch{}
		//	}
		//	return (lgk.Model.tb_BonusPoly)objModel;
		//}

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
		public List<lgk.Model.tb_BonusPoly> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_BonusPoly> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_BonusPoly> modelList = new List<lgk.Model.tb_BonusPoly>();
			int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_BonusPoly model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_BonusPoly();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = long.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["SettleTime"].ToString() != "")
                    {
                        model.SettleTime = DateTime.Parse(dt.Rows[n]["SettleTime"].ToString());
                    }
                    if (dt.Rows[n]["TaskCompletedFlag"].ToString() != "")
                    {
                        model.TaskCompletedFlag = int.Parse(dt.Rows[n]["TaskCompletedFlag"].ToString());
                    }
                    if (dt.Rows[n]["TaskCompletedTime"].ToString() != "")
                    {
                        model.TaskCompletedTime = DateTime.Parse(dt.Rows[n]["TaskCompletedTime"].ToString());
                    }
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["InvestOrderID"].ToString() != "")
                    {
                        model.InvestOrderID = long.Parse(dt.Rows[n]["InvestOrderID"].ToString());
                    }
                    if (dt.Rows[n]["Bonus"].ToString() != "")
                    {
                        model.Bonus = decimal.Parse(dt.Rows[n]["Bonus"].ToString());
                    }
                    if (dt.Rows[n]["ShareDay"].ToString() != "")
                    {
                        model.ShareDay = int.Parse(dt.Rows[n]["ShareDay"].ToString());
                    }
                    if (dt.Rows[n]["ShareDate"].ToString() != "")
                    {
                        model.ShareDate = DateTime.Parse(dt.Rows[n]["ShareDate"].ToString());
                    }
                    model.ShowDate = dt.Rows[n]["ShowDate"].ToString();
                    if (dt.Rows[n]["Flag"].ToString() != "")
                    {
                        model.Flag = int.Parse(dt.Rows[n]["Flag"].ToString());
                    }

                    if (dt.Rows[n]["TaskBonus"].ToString() != "")
                    {
                        model.TaskBonus = decimal.Parse(dt.Rows[n]["TaskBonus"].ToString());
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
#endregion
   
	}
}