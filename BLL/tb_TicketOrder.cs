using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public class tb_TicketOrder
    {
        private readonly lgk.DAL.tb_TicketOrder dal = new lgk.DAL.tb_TicketOrder();
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_TicketOrder model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_TicketOrder model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="status"></param>
        /// <param name="paystatus"></param>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public bool UpdateStatus(int status, int paystatus, string orderno)
        {
            return dal.UpdateStatus(status, paystatus, orderno);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        public lgk.Model.tb_TicketOrder GetModel(string where)
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
    }
}
