using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
   public  class tb_PhoneOrder
    {
        private readonly lgk.DAL.tb_PhoneOrder dal = new lgk.DAL.tb_PhoneOrder();
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_PhoneOrder model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_PhoneOrder model)
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
        public lgk.Model.tb_PhoneOrder GetModel(string where)
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
        public List<lgk.Model.tb_PhoneOrder> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        public List<lgk.Model.tb_PhoneOrder> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_PhoneOrder> modelList = new List<lgk.Model.tb_PhoneOrder>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_PhoneOrder model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_PhoneOrder();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["PhoneNO"] != null && dt.Rows[n]["PhoneNO"].ToString() != "")
                    {
                        model.PhoneNO = dt.Rows[n]["PhoneNO"].ToString();
                    }
                    if (dt.Rows[n]["CardNum"] != null && dt.Rows[n]["CardNum"].ToString() != "")
                    {
                        model.CardNum = int.Parse(dt.Rows[n]["CardNum"].ToString());
                    }
                    if (dt.Rows[n]["UorderID"] != null && dt.Rows[n]["UorderID"].ToString() != "")
                    {
                        model.UorderID = dt.Rows[n]["UorderID"].ToString();
                    }
                    if (dt.Rows[n]["CardID"] != null && dt.Rows[n]["CardID"].ToString() != "")
                    {
                        model.CardID = dt.Rows[n]["CardID"].ToString();
                    }
                    if (dt.Rows[n]["OrderCash"] != null && dt.Rows[n]["OrderCash"].ToString() != "")
                    {
                        model.OrderCash = dt.Rows[n]["OrderCash"].ToString();
                    }
                    if (dt.Rows[n]["CardName"] != null && dt.Rows[n]["CardName"].ToString() != "")
                    {
                        model.CardName = dt.Rows[n]["CardName"].ToString();
                    }
                    if (dt.Rows[n]["SporderID"] != null && dt.Rows[n]["SporderID"].ToString() != "")
                    {
                        model.SporderID = dt.Rows[n]["SporderID"].ToString();
                    }
                    if (dt.Rows[n]["State"] != null && dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    if (dt.Rows[n]["AddDate"] != null && dt.Rows[n]["AddDate"].ToString() != "")
                    {
                        model.AddDate =Convert.ToDateTime(dt.Rows[n]["AddDate"].ToString());
                    }
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
    }
}
