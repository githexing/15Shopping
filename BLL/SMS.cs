using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class SMS
    {
        private readonly lgk.DAL.SMS dal = new lgk.DAL.SMS();
        public SMS()
        { }

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
        public long Add(lgk.Model.SMS model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.SMS model)
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
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.SMS GetModel(long ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="phoneNum"></param>
        /// <param name="Code"></param>
        /// <returns></returns>
        public lgk.Model.SMS GetModelByPhoneAndCode(string phoneNum, string Code)
        {
            return dal.GetModelByPhoneAndCode(phoneNum, Code);
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.SMS> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.SMS> DataTableToList(DataTable dt)
        {
            List<lgk.Model.SMS> modelList = new List<lgk.Model.SMS>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.SMS model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if(model != null)
                    {
                        modelList.Add(model);
                    }
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
        /// 更改短信状态（第三方是否通过）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="iDelete"></param>
        /// <returns></returns>
        public bool UpdateDelete(long id, int iDelete)
        {
            return dal.UpdateDelete(id, iDelete);
        }

        /// <summary>
        /// 更改短信状态（是否已验证）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="iValid">0、未验证，1、验证成功</param>
        /// <returns></returns>
        public bool UpdateState(long id, int iType)
        {
            return dal.UpdateState(id, iType);
        }

        #endregion
    }
}
