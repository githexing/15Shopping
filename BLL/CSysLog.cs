using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;//Please add references
namespace lgk.BLL
{
	/// <summary>
	///  
	/// </summary>
    public partial class SysLog 
	{
        private readonly lgk.DAL.CSysLog dal = new lgk.DAL.CSysLog();
		public SysLog()
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
		public long  Add(lgk.Model.SysLog model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.SysLog model)
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
		public lgk.Model.SysLog GetModel(long ID)
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
		public List<lgk.Model.SysLog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.SysLog> DataTableToList(DataTable dt)
		{
			List<lgk.Model.SysLog> modelList = new List<lgk.Model.SysLog>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				lgk.Model.SysLog model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.SysLog();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = long.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.Log2 = dt.Rows[n]["Log2"].ToString();
                    model.Log3 = dt.Rows[n]["Log3"].ToString();
                    model.Log4 = dt.Rows[n]["Log4"].ToString();
                    if (dt.Rows[n]["IsDeleted"].ToString() != "")
                    {
                        model.IsDeleted = int.Parse(dt.Rows[n]["IsDeleted"].ToString());
                    }
                    if (dt.Rows[n]["LogType"].ToString() != "")
                    {
                        model.LogType = int.Parse(dt.Rows[n]["LogType"].ToString());
                    }
                    if (dt.Rows[n]["LogLeve"].ToString() != "")
                    {
                        model.LogLeve = int.Parse(dt.Rows[n]["LogLeve"].ToString());
                    }
                    model.LogCode = dt.Rows[n]["LogCode"].ToString();
                    if (dt.Rows[n]["DataInt"].ToString() != "")
                    {
                        model.DataInt = decimal.Parse(dt.Rows[n]["DataInt"].ToString());
                    }
                    model.DataStr = dt.Rows[n]["DataStr"].ToString();
                    model.LogMsg = dt.Rows[n]["LogMsg"].ToString();
                    if (dt.Rows[n]["LogDate"].ToString() != "")
                    {
                        model.LogDate = DateTime.Parse(dt.Rows[n]["LogDate"].ToString());
                    }
                    model.Log1 = dt.Rows[n]["Log1"].ToString();


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

