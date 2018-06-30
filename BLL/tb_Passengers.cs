using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public class tb_Passengers
    {
        private readonly lgk.DAL.tb_Passengers dal = new lgk.DAL.tb_Passengers();
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_Passengers model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_Passengers model)
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
        public lgk.Model.tb_Passengers GetModel(string where)
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
        public List<lgk.Model.tb_Passengers> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_Passengers> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_Passengers> modelList = new List<lgk.Model.tb_Passengers>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_Passengers model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_Passengers();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = Convert.ToInt32(dt.Rows[n]["OrderID"].ToString());
                    }
                    if (dt.Rows[n]["Name"] != null && dt.Rows[n]["Name"].ToString() != "")
                    {
                        model.Name = dt.Rows[n]["Name"].ToString();
                    }
                    if (dt.Rows[n]["Cardno"] != null && dt.Rows[n]["Cardno"].ToString() != "")
                    {
                        model.Cardno = dt.Rows[n]["Cardno"].ToString();
                    }
                    if (dt.Rows[n]["Cardtype"] != null && dt.Rows[n]["Cardtype"].ToString() != "")
                    {
                        model.Cardtype = dt.Rows[n]["Cardtype"].ToString();
                    }
                    if (dt.Rows[n]["Mantype"] != null && dt.Rows[n]["Mantype"].ToString() != "")
                    {
                        model.Mantype =dt.Rows[n]["Mantype"].ToString();
                    }
                    if (dt.Rows[n]["Birthday"] != null && dt.Rows[n]["Birthday"].ToString() != "")
                    {
                        model.Birthday = dt.Rows[n]["Birthday"].ToString();
                    }
                    if (dt.Rows[n]["Sex"] != null && dt.Rows[n]["Sex"].ToString() != "")
                    {
                        model.Sex = dt.Rows[n]["Sex"].ToString();
                    }
                    if (dt.Rows[n]["InsurancePrice"] != null && dt.Rows[n]["InsurancePrice"].ToString() != "")
                    {
                        model.InsurancePrice = decimal.Parse(dt.Rows[n]["InsurancePrice"].ToString());
                    }
                    if (dt.Rows[n]["InsuranceNum"] != null && dt.Rows[n]["InsuranceNum"].ToString() != "")
                    {
                        model.InsuranceNum = Convert.ToInt32(dt.Rows[n]["InsuranceNum"].ToString());
                    }
                   
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        public bool UpdateStatus(string TicketsNo, string Cardno)
        {
            return dal.UpdateStatus(TicketsNo, Cardno);
        }
    }
}
