using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    /// <summary>
    /// tb_Security
    /// </summary>
    public partial class tb_Security
    {
        private readonly lgk.DAL.tb_Security dal = new lgk.DAL.tb_Security();
        public tb_Security()
		{}
        #region Method

        public bool Exists(int SecurityID)
        {
            return dal.Exists(SecurityID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_Security model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_Security model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(int SecurityID)
        {
            return dal.Update(SecurityID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SecurityID)
        {
            return dal.Delete(SecurityID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string SecurityIDlist)
        {
            return dal.DeleteList(SecurityIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Security GetModel(int SecurityID)
        {
            return dal.GetModel(SecurityID);
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
        public List<lgk.Model.tb_Security> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return GetModelList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_Security> GetModelList(DataTable dt)
        {
            List<lgk.Model.tb_Security> myList = new List<lgk.Model.tb_Security>();
            lgk.Model.tb_Security model;

            if (dt.Rows.Count == 0)
                return myList;

            foreach (DataRow row in dt.Rows)
            {
                model = new lgk.Model.tb_Security();

                if (row["SecurityID"] != null && row["SecurityID"].ToString() != "")
                {
                    model.SecurityID = int.Parse(row["SecurityID"].ToString());
                }
                if (row["Question"] != null && row["Question"].ToString() != "")
                {
                    model.Question = row["Question"].ToString();
                }
                if (row["AddUserID"] != null && row["AddUserID"].ToString() != "")
                {
                    model.AddUserID = int.Parse(row["AddUserID"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }

                myList.Add(model);
            }

            return myList;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        #endregion
    }
}
