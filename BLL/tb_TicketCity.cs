using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public class tb_TicketCity
    {
        private readonly lgk.DAL.tb_TicketCity dal = new lgk.DAL.tb_TicketCity();
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_TicketCity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_TicketCity model)
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
        public lgk.Model.tb_TicketCity GetModel(string where)
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
        public List<lgk.Model.tb_TicketCity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public List<lgk.Model.tb_TicketCity> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_TicketCity> modelList = new List<lgk.Model.tb_TicketCity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_TicketCity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_TicketCity();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Name"] != null && dt.Rows[n]["Name"].ToString() != "")
                    {
                        model.Name = dt.Rows[n]["Name"].ToString();
                    }
                    if (dt.Rows[n]["Code"] != null && dt.Rows[n]["Code"].ToString() != "")
                    {
                        model.Code = dt.Rows[n]["Code"].ToString();
                    }
                    if (dt.Rows[n]["City"] != null && dt.Rows[n]["City"].ToString() != "")
                    {
                        model.City = dt.Rows[n]["City"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
    }
}
