using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public class tb_PhoneAmcount
    {
        private readonly lgk.DAL.tb_PhoneAmcount dal = new lgk.DAL.tb_PhoneAmcount();
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_PhoneAmcount model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_PhoneAmcount model)
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
        public lgk.Model.tb_PhoneAmcount GetModel(string where)
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
        public List<lgk.Model.tb_PhoneAmcount> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        public List<lgk.Model.tb_PhoneAmcount> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_PhoneAmcount> modelList = new List<lgk.Model.tb_PhoneAmcount>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_PhoneAmcount model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_PhoneAmcount();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Amcount"] != null && dt.Rows[n]["Amcount"].ToString() != "")
                    {
                        model.Amcount = int.Parse(dt.Rows[n]["Amcount"].ToString());
                    }
                    if (dt.Rows[n]["State"] != null && dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
    }
}
