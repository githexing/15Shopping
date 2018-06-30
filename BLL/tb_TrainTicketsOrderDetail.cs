using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public class tb_TrainTicketsOrderDetail
    {
        
        private readonly lgk.DAL.tb_TrainTicketsOrderDetail dal = new lgk.DAL.tb_TrainTicketsOrderDetail();
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_TrainTicketsOrderDetail model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_TrainTicketsOrderDetail model)
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
        public lgk.Model.tb_TrainTicketsOrderDetail GetModel(string where)
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
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_TrainTicketsOrderDetail> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_TrainTicketsOrderDetail> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_TrainTicketsOrderDetail> modelList = new List<lgk.Model.tb_TrainTicketsOrderDetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_TrainTicketsOrderDetail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_TrainTicketsOrderDetail();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["OrderID"] != null && dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = Convert.ToInt32(dt.Rows[n]["OrderID"].ToString());
                    }
                    if (dt.Rows[n]["PassengerseName"] != null && dt.Rows[n]["PassengerseName"].ToString() != "")
                    {
                        model.PassengerseName = dt.Rows[n]["PassengerseName"].ToString();
                    }
                    if (dt.Rows[n]["PiaoType"] != null && dt.Rows[n]["PiaoType"].ToString() != "")
                    {
                        model.PiaoType = int.Parse(dt.Rows[n]["PiaoType"].ToString());
                    }
                    if (dt.Rows[n]["PiaotypeName"] != null && dt.Rows[n]["PiaotypeName"].ToString() != "")
                    {
                        model.PiaotypeName =dt.Rows[n]["PiaotypeName"].ToString();
                    }
                    if (dt.Rows[n]["Passporttypeseid"] != null && dt.Rows[n]["Passporttypeseid"].ToString() != "")
                    {
                        model.Passporttypeseid = Convert.ToInt32(dt.Rows[n]["Passporttypeseid"].ToString());
                    }
                    if (dt.Rows[n]["PassporttypeseidName"] != null && dt.Rows[n]["PassporttypeseidName"].ToString() != "")
                    {
                        model.PassporttypeseidName = dt.Rows[n]["PassporttypeseidName"].ToString();
                    }
                    if (dt.Rows[n]["PassportseNO"] != null && dt.Rows[n]["PassportseNO"].ToString() != "")
                    {
                        model.PassportseNO = dt.Rows[n]["PassportseNO"].ToString();
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["ZWCode"] != null && dt.Rows[n]["ZWCode"].ToString() != "")
                    {
                        model.ZWCode = dt.Rows[n]["ZWCode"].ToString();
                    }
                    if (dt.Rows[n]["ZWName"] != null && dt.Rows[n]["ZWName"].ToString() != "")
                    {
                        model.ZWName = dt.Rows[n]["ZWName"].ToString();
                    }
                    if (dt.Rows[n]["InsuranceID"] != null && dt.Rows[n]["InsuranceID"].ToString() != "")
                    {
                        model.InsuranceID = Convert.ToInt32(dt.Rows[n]["InsuranceID"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool UpdateStatus(string Cxin, int State, int OrderID, int PassengerId)
        {
            return dal.UpdateStatus(Cxin,State,OrderID,PassengerId);
        }
    }
}
