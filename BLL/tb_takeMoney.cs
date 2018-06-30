using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
    /// <summary>
    /// tb_takeMoney
    /// </summary>
    public partial class tb_takeMoney
    {
        private readonly lgk.DAL.tb_takeMoney dal = new lgk.DAL.tb_takeMoney();
        public tb_takeMoney()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

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
        public int Add(lgk.Model.tb_takeMoney model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_takeMoney model)
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
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="strDefaults">理财者ID</param>

        /// <returns></returns>
        public int UpdateFlag(long UserID, long ID)
        {
            return dal.UpdateFlag(UserID,ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_takeMoney GetModel(long ID)
        {
            return dal.GetModel(ID);
        }
        public lgk.Model.tb_takeMoney GetModel(string where)
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
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_takeMoney> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_takeMoney> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_takeMoney> modelList = new List<lgk.Model.tb_takeMoney>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_takeMoney model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_takeMoney();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = long.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["TakeTime"] != null && dt.Rows[n]["TakeTime"].ToString() != "")
                    {
                        model.TakeTime = DateTime.Parse(dt.Rows[n]["TakeTime"].ToString());
                    }
                    if (dt.Rows[n]["TakeMoney"] != null && dt.Rows[n]["TakeMoney"].ToString() != "")
                    {
                        model.TakeMoney = decimal.Parse(dt.Rows[n]["TakeMoney"].ToString());
                    }
                    if (dt.Rows[n]["TakePoundage"] != null && dt.Rows[n]["TakePoundage"].ToString() != "")
                    {
                        model.TakePoundage = decimal.Parse(dt.Rows[n]["TakePoundage"].ToString());
                    }
                    if (dt.Rows[n]["RealityMoney"] != null && dt.Rows[n]["RealityMoney"].ToString() != "")
                    {
                        model.RealityMoney = decimal.Parse(dt.Rows[n]["RealityMoney"].ToString());
                    }
                    if (dt.Rows[n]["BonusBalance"] != null && dt.Rows[n]["BonusBalance"].ToString() != "")
                    {
                        model.BonusBalance = decimal.Parse(dt.Rows[n]["BonusBalance"].ToString());
                    }
                    if (dt.Rows[n]["Flag"] != null && dt.Rows[n]["Flag"].ToString() != "")
                    {
                        model.Flag = int.Parse(dt.Rows[n]["Flag"].ToString());
                    }
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["BankName"] != null && dt.Rows[n]["BankName"].ToString() != "")
                    {
                        model.BankName = dt.Rows[n]["BankName"].ToString();
                    }
                    if (dt.Rows[n]["BankAccount"] != null && dt.Rows[n]["BankAccount"].ToString() != "")
                    {
                        model.BankAccount = dt.Rows[n]["BankAccount"].ToString();
                    }
                    if (dt.Rows[n]["BankAccountUser"] != null && dt.Rows[n]["BankAccountUser"].ToString() != "")
                    {
                        model.BankAccountUser = dt.Rows[n]["BankAccountUser"].ToString();
                    }
                    if (dt.Rows[n]["BankDian"] != null && dt.Rows[n]["BankDian"].ToString() != "")
                    {
                        model.BankDian = dt.Rows[n]["BankDian"].ToString();
                    }
                    if (dt.Rows[n]["Take001"] != null && dt.Rows[n]["Take001"].ToString() != "")
                    {
                        model.Take001 = int.Parse(dt.Rows[n]["Take001"].ToString());
                    }
                    if (dt.Rows[n]["Take002"] != null && dt.Rows[n]["Take002"].ToString() != "")
                    {
                        model.Take002 = int.Parse(dt.Rows[n]["Take002"].ToString());
                    }
                    if (dt.Rows[n]["Take003"] != null && dt.Rows[n]["Take003"].ToString() != "")
                    {
                        model.Take003 = dt.Rows[n]["Take003"].ToString();
                    }
                    if (dt.Rows[n]["Take004"] != null && dt.Rows[n]["Take004"].ToString() != "")
                    {
                        model.Take004 = dt.Rows[n]["Take004"].ToString();
                    }
                    if (dt.Rows[n]["Take005"] != null && dt.Rows[n]["Take005"].ToString() != "")
                    {
                        model.Take005 = decimal.Parse(dt.Rows[n]["Take005"].ToString());
                    }
                    if (dt.Rows[n]["Take006"] != null && dt.Rows[n]["Take006"].ToString() != "")
                    {
                        model.Take006 = DateTime.Parse(dt.Rows[n]["Take006"].ToString());
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

