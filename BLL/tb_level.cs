using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_level
	/// </summary>
	public partial class tb_level
	{
		private readonly lgk.DAL.tb_level dal=new lgk.DAL.tb_level();
		public tb_level()
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
		public bool Exists(int LevelID)
		{
			return dal.Exists(LevelID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(lgk.Model.tb_level model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_level model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LevelID)
		{
			
			return dal.Delete(LevelID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string LevelIDlist )
		{
			return dal.DeleteList(LevelIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lgk.Model.tb_level GetModel(int LevelID)
		{
			return dal.GetModel(LevelID);
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
		public List<lgk.Model.tb_level> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
            return GetModelList(ds.Tables[0]);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<lgk.Model.tb_level> GetModelList(DataTable dt)
        {
            List<lgk.Model.tb_level> myList = new List<lgk.Model.tb_level>();
            lgk.Model.tb_level model;

            if (dt.Rows.Count == 0)
                return myList;

            foreach (DataRow row in dt.Rows)
            {
                model = new lgk.Model.tb_level();

                if (row["LevelID"] != null && row["LevelID"].ToString() != "")
                {
                    model.LevelID = int.Parse(row["LevelID"].ToString());
                }
                if (row["LevelName"] != null && row["LevelName"].ToString() != "")
                {
                    model.LevelName = row["LevelName"].ToString();
                }
                if (row["RegMoney"] != null && row["RegMoney"].ToString() != "")
                {
                    model.RegMoney = decimal.Parse(row["RegMoney"].ToString());
                }
                if (row["level01"] != null && row["level01"].ToString() != "")
                {
                    model.level01 = int.Parse(row["level01"].ToString());
                }
                if (row["level02"] != null && row["level02"].ToString() != "")
                {
                    model.level02 = int.Parse(row["level02"].ToString());
                }
                if (row["level03"] != null && row["level03"].ToString() != "")
                {
                    model.level03 = row["level03"].ToString();
                }
                if (row["level04"] != null && row["level04"].ToString() != "")
                {
                    model.level04 = row["level04"].ToString();
                }
                if (row["level05"] != null && row["level05"].ToString() != "")
                {
                    model.level05 = decimal.Parse(row["level05"].ToString());
                }
                if (row["level06"] != null && row["level06"].ToString() != "")
                {
                    model.level06 = decimal.Parse(row["level06"].ToString());
                }
                if (row["level07"] != null && row["level07"].ToString() != "")
                {
                    model.level07 = decimal.Parse(row["level07"].ToString());
                }
                if (row["level08"] != null && row["level08"].ToString() != "")
                {
                    model.level08 = decimal.Parse(row["level08"].ToString());
                }

                myList.Add(model);
            }

            return myList;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

        public string GetLevelName(int LevelID)
        {
            return dal.GetLevelName(LevelID);
        }

        /// <summary>
        /// 根据给定的等级ID，获取会员等级名称en-us。
        /// </summary>
        /// <param name="iLevelID"></param>
        /// <param name="strLanguage"></param>
        /// <returns></returns>
        public string GetLevelName(int iLevelID, string strLanguage)
        {
            return dal.GetLevelName(iLevelID, strLanguage);
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

