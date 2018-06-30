using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
	/// <summary>
	/// tb_leaveMsg
	/// </summary>
	public partial class tb_leaveMsg
	{
		private readonly lgk.DAL.tb_leaveMsg dal=new lgk.DAL.tb_leaveMsg();
		public tb_leaveMsg()
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
		public long Add(lgk.Model.tb_leaveMsg model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_leaveMsg model)
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
		public lgk.Model.tb_leaveMsg GetModel(long ID)
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
		public List<lgk.Model.tb_leaveMsg> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetRecordList(string strWhere)
        {
            DataSet ds = dal.GetRecordList(strWhere);
            return ds;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_leaveMsg> DataTableToList(DataTable dt)
		{
			List<lgk.Model.tb_leaveMsg> modelList = new List<lgk.Model.tb_leaveMsg>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.tb_leaveMsg model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new lgk.Model.tb_leaveMsg();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["MsgTitle"]!=null && dt.Rows[n]["MsgTitle"].ToString()!="")
					{
					model.MsgTitle=dt.Rows[n]["MsgTitle"].ToString();
					}
					if(dt.Rows[n]["MsgContent"]!=null && dt.Rows[n]["MsgContent"].ToString()!="")
					{
					model.MsgContent=dt.Rows[n]["MsgContent"].ToString();
					}
					if(dt.Rows[n]["LeaveTime"]!=null && dt.Rows[n]["LeaveTime"].ToString()!="")
					{
						model.LeaveTime=DateTime.Parse(dt.Rows[n]["LeaveTime"].ToString());
					}
					if(dt.Rows[n]["IsRead"]!=null && dt.Rows[n]["IsRead"].ToString()!="")
					{
						model.IsRead=int.Parse(dt.Rows[n]["IsRead"].ToString());
					}
					if(dt.Rows[n]["IsReply"]!=null && dt.Rows[n]["IsReply"].ToString()!="")
					{
						model.IsReply=int.Parse(dt.Rows[n]["IsReply"].ToString());
					}
					if(dt.Rows[n]["FromUserType"]!=null && dt.Rows[n]["FromUserType"].ToString()!="")
					{
						model.FromUserType=int.Parse(dt.Rows[n]["FromUserType"].ToString());
					}
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=long.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["UserCode"]!=null && dt.Rows[n]["UserCode"].ToString()!="")
					{
					model.UserCode=dt.Rows[n]["UserCode"].ToString();
					}
					if(dt.Rows[n]["FromIDIsDel"]!=null && dt.Rows[n]["FromIDIsDel"].ToString()!="")
					{
						model.FromIDIsDel=int.Parse(dt.Rows[n]["FromIDIsDel"].ToString());
					}
					if(dt.Rows[n]["ToUserType"]!=null && dt.Rows[n]["ToUserType"].ToString()!="")
					{
						model.ToUserType=int.Parse(dt.Rows[n]["ToUserType"].ToString());
					}
					if(dt.Rows[n]["ToUserID"]!=null && dt.Rows[n]["ToUserID"].ToString()!="")
					{
						model.ToUserID=long.Parse(dt.Rows[n]["ToUserID"].ToString());
					}
					if(dt.Rows[n]["ToUserCode"]!=null && dt.Rows[n]["ToUserCode"].ToString()!="")
					{
					model.ToUserCode=dt.Rows[n]["ToUserCode"].ToString();
					}
					if(dt.Rows[n]["ToIDIsDel"]!=null && dt.Rows[n]["ToIDIsDel"].ToString()!="")
					{
						model.ToIDIsDel=int.Parse(dt.Rows[n]["ToIDIsDel"].ToString());
					}
                    if (dt.Rows[n]["MsgType"] != null && dt.Rows[n]["MsgType"].ToString() != "")
                    {
                        model.MsgType = int.Parse(dt.Rows[n]["MsgType"].ToString());
                    }
                    if (dt.Rows[n]["Pic"] != null && dt.Rows[n]["Pic"].ToString() != "")
                    {
                        model.Pic = dt.Rows[n]["Pic"].ToString();
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

