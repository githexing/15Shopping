using System;
using System.Data;
using System.Collections.Generic;

using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_user
	/// </summary>
	public partial class tb_user
	{
		private readonly lgk.DAL.tb_user dal=new lgk.DAL.tb_user();
		public tb_user()
        { }
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long UserID)
		{
			return dal.Exists(UserID);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strUserCode)
        {
            return dal.Exists(strUserCode);
        }

        /// <summary>
        /// 是否有子会员
        /// </summary>
        public bool HasChildren(long userID)
        {
            return dal.HasChildren(userID);
        }

        /// <summary>
        /// 判断给定的用户是否为报单中心
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public bool IsAgent(long iUserID)
        {
            return dal.IsAgent(iUserID);
        }

        /// <summary>
        /// 根据给定的用户ID，获取用户编号。
        /// </summary>
        /// <param name="iUserID">给定的用户ID</param>
        /// <returns></returns>
        public string GetUserCode(long iUserID)
        {
            return dal.GetUserCode(iUserID);
        }

        /// <summary>
        /// 根据给定额用户编号，获取用户ID
        /// </summary>
        /// <param name="strUserCode">给定额用户编号</param>
        /// <returns></returns>
        public long GetUserID(string strUserCode)
        {
            return dal.GetUserID(strUserCode);
        }
        
        /// <summary>
        /// 根据给定手机号码，获取用户ID
        /// </summary>
        /// <param name="PhoneNum"></param>
        /// <returns></returns>
        public long GetUserIDByPhoneNum(string PhoneNum)
        {
            return dal.GetUserIDByPhoneNum(PhoneNum);
        }

        /// <summary>
        /// 获取给定会员ID的注册币。
        /// </summary>
        /// <param name="iUserID">给定的会员ID</param>
        /// <returns></returns>
        public decimal GetEMoney(long iUserID)
        {
            return dal.GetEMoney(iUserID);
        }

        /// <summary>
        /// 判断给定的推荐人和安置人是否在同一条线上。
        /// </summary>
        /// <param name="iRecommendID">给定的推荐人</param>
        /// <param name="iParentID">给定的安置人</param>
        /// <returns></returns>
        public bool OnSameLine(long iRecommendID, long iParentID)
        {
            return dal.OnSameLine(iRecommendID, iParentID);
        }

        /// <summary>
        /// 获取给定会员的路径
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public string GetUserPath(long iUserID)
        {
            return dal.GetUserPath(iUserID);
        }

        /// <summary>
        /// 获取给定会员ID的金币。
        /// </summary>
        /// <param name="iUserID">给定的会员ID</param>
        /// <returns></returns>
        public decimal GetMoney(long iUserID, string strFieldName)
        {
            return dal.GetMoney(iUserID, strFieldName);
        }

        /// <summary>
        /// 获取给定会员ID的金币。
        /// </summary>
        /// <param name="iUserID">给定的会员ID</param>
        /// <returns></returns>
        public decimal GetBonusAccount(long iUserID)
        {
            return dal.GetBonusAccount(iUserID);
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(lgk.Model.tb_user model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_user model)
		{
			return dal.Update(model);
		}
        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool UpdateGender(lgk.Model.tb_user model)
        {
            return dal.UpdateGender(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateNiceName(lgk.Model.tb_user model)
        {
            return dal.UpdateNiceName(model);
        }
        /// <summary>
        /// 更新给定账号ID的复投次数(iTypeID:0减少，1增加)
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="iTypeID"></param>
        /// <returns></returns>
        public bool UpdateBatch(long iUserID, int iTypeID)
        {
            return dal.UpdateBatch(iUserID, iTypeID);
        }

        /// <summary>
        /// 开通空单
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public bool UpdateEmpty(long iUserID)
        {
            return dal.UpdateEmpty(iUserID);
        }

        /// <summary>
        /// 根据给定的会员编号，获取其下面的所有会员。
        /// </summary>
        /// <param name="iUserID">根据给定的会员编号</param>
        /// <returns></returns>
        public string GetAllRecommendID(long iUserID)
        {
            return dal.GetAllRecommendID(iUserID);
        }

        /// <summary>
        /// 将给定的用户ID更新成报单中心
        /// </summary>
        /// <param name="iUserID">用户ID</param>
        /// <returns></returns>
        public bool UpdateAgent(long iUserID)
        {
            return dal.UpdateAgent(iUserID);
        }
        /// <summary>
        /// 将给定的用户ID更新成运营中心
        /// </summary>
        /// <param name="iUserID">用户ID</param>
        /// <returns></returns>
        public bool UpdateAgent1(long iUserID)
        {
            return dal.UpdateAgent1(iUserID);
        }

        /// <summary>
        /// 修改下线的报单中心信息
        /// </summary>
        public void UpdateAgent(long iID, long iUserID, string strUserCode)
        {
            string strRecom = "";
            dal.UpdateAgent(iID, iUserID, strUserCode);//更新直接推荐的会员

            //更新下线会员
            string strRecommendID = dal.GetAllRecommendID(iUserID);

            if (!string.IsNullOrEmpty(strRecommendID))
            {
                string[] arrayRecommendID = strRecommendID.Split(',');

                foreach (string strRecID in arrayRecommendID)
                {
                    if (dal.IsAgent(long.Parse(strRecID)) && long.Parse(strRecID) != iUserID)
                    {
                        strRecom = dal.GetAllRecommendID(long.Parse(strRecID));

                        if (!string.IsNullOrEmpty(strRecom))
                        {
                            string[] arrayRecom = strRecom.Split(',');
                            foreach (string strRecomID in arrayRecom)
                            {
                                strRecommendID = strRecommendID.Replace(strRecomID, "");
                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(strRecommendID))
            {
                string[] arrayRecommendID = strRecommendID.Split(',');

                foreach (string strRecID in arrayRecommendID)
                {
                    if (!string.IsNullOrEmpty(strRecID))
                    {
                        if (!dal.IsAgent(long.Parse(strRecID)))
                        {
                            dal.UpdateAgent(iID, long.Parse(strRecID), strUserCode);
                        }
                    }
                }
            }
        }


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long UserID)
		{
			return dal.Delete(UserID);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserIDlist )
		{
			return dal.DeleteList(UserIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lgk.Model.tb_user GetModel(long UserID)
		{
			return dal.GetModel(UserID);
		}
        /// <summary>
        /// 查询语句
        /// </summary>
        /// <param name="pTable"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet getData_Chaxun(string pTable, string strWhere)
        {
            return dal.getData_Chaxun(pTable, strWhere);
        }
        /// <summary>
        /// 根据条件获得会员实体(用户商城用户注册)
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public lgk.Model.tb_user GetModelForShop(string strWhere)
        {
            return dal.GetModelForShop(strWhere);
        }

        /// <summary>
        /// 根据条件获得会员实体
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public lgk.Model.tb_user GetModel(string strWhere)
        {
            return dal.GetModel(strWhere);
        }
        /// <summary>
        /// 根据用户编号获得会员实体
        /// </summary>
        /// <param name="usercode">用户编号</param>
        /// <returns></returns>
        public lgk.Model.tb_user GetModelByUserCode(string usercode)
        {
            return dal.GetModelByUserCode(usercode);
        }

        /// <summary>
        /// 根据手机号码获得会员实体
        /// </summary>
        /// <param name="usercode">手机号码</param>
        /// <returns></returns>
        public lgk.Model.tb_user GetModelByPhoneNum(string PhoneNum)
        {
            return dal.GetModelByPhoneNum(PhoneNum);
        }

        /// <summary>
        /// 根据给定的会员编号，获取其下面的所有会员
        /// </summary>
        /// <param name="iUserID">根据给定的会员编号</param>
        /// <returns></returns>
        public string GetAllChildrenID(long iUserID)
        {
            return dal.GetAllChildrenID(iUserID);
        }

        /// <summary>
        /// 根据给定的会员编号，获取能安置会员的会员编号
        /// </summary>
        /// <param name="iParentID"></param>
        /// <returns></returns>
        public long GetPlacementID(long iParentID)
        {
            return dal.GetPlacementID(iParentID);
        }

        /// <summary>
        /// 根据给定的用户编号，获取其能安置下线的位置。
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public int GetLocation(long iUserID)
        {
            return dal.GetLocation(iUserID);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
        }
        public DataSet RemitGetList(string strWhere)
        {
            return dal.RemitGetList(strWhere);
        }
        public DataSet RemitToProLevel(string strWhere)
        {
            return dal.RemitToProLevel(strWhere);
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetOpenList(string strWhere)
        {
            return dal.GetOpenList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDetailList(string strWhere)
        {
            return dal.GetDetailList(strWhere);
        }

        /// <summary>
        /// 计算注册金额
        /// </summary>
        public decimal CountRegMoney(string strWhere)
        {
            return dal.CountRegMoney(strWhere);
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

        /// <summary>
        /// 获得前几行字段
        /// </summary>
        public DataSet GetListField(int Top, string strField, string strWhere)
        {
            return dal.GetListField(Top, strField, strWhere);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_user> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_user> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_user> modelList = new List<lgk.Model.tb_user>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_user model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        } 
        #endregion

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
        /// <summary>
        /// 判断给定的会员是否已开通
        /// </summary>
        public bool ExistsIsOpend(long UserID)
        {
            return dal.ExistsIsOpend(UserID);
        }
        /// <summary>
        /// 判断给定的父节点和区域是否已有开通的会员
        /// </summary>
        /// <param name="iParentID"></param>
        /// <param name="iLoc"></param>
        /// <returns></returns>
        public bool FlagLoc(long iParentID, int iLoc)
        {
            return dal.FlagLoc(iParentID, iLoc);
        }
        /// <summary>
        /// 获取已开通的父接点
        /// </summary>
        /// <returns></returns>
        public long GetParentID(long iUserID)
        {
            return dal.GetParentID(iUserID);
        }

        /// <summary>
        /// 根据用户ID获取用户编号
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string GetUserCodeByUserID(long iUserID)
        {
            return dal.GetUserCodeByUserID(iUserID);
        }

        /// <summary>
        /// 判断给定的推荐人和安置人是否在同一条线上。
        /// </summary>
        /// <param name="iRecommendID">给定的推荐人</param>
        /// <param name="iUserID">给定的会员</param>
        /// <returns></returns>
        public bool OnRecommendSameLine(long iRecommendID, long iUserID)
        {
            return dal.OnRecommendSameLine(iRecommendID, iUserID);
        }

        /// <summary>
        /// 更新身份证与真实姓名
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="IdCard"></param>
        /// <param name="RealName"></param>
        /// <returns></returns>
        public bool UpdateIdCardAndTrueName(long UserID, string IdCard, string RealName)
        {
            return dal.UpdateIdCardAndTrueName(UserID, IdCard, RealName);
        }

        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string proc_RegisterUser(lgk.Model.tb_user model)
        {
            return dal.proc_RegisterUser(model);
        }

        #endregion  Method
    }
}

