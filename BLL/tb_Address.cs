using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    public partial class tb_Address
    {
        private readonly lgk.DAL.tb_Address dal = new lgk.DAL.tb_Address();
        public tb_Address()
        { 
        }
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
        public long Add(lgk.Model.tb_Address model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_Address model)
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
        /// 设置默认地址
        /// </summary>
        public bool SetDefault(long iUserID, long iID)
        {
            return dal.SetDefault(iUserID, iID);
        }

        /// <summary>
        /// 设置默认地址
        /// </summary>
        public bool SetDefault(long iUserID, string strAddress01)
        {
            return dal.SetDefault(iUserID, strAddress01);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_Address GetModel(long ID)
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_Address> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_Address> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_Address> modelList = new List<lgk.Model.tb_Address>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_Address model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_Address();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = long.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["TypeID"] != null && dt.Rows[n]["TypeID"].ToString() != "")
                    {
                        model.TypeID = int.Parse(dt.Rows[n]["TypeID"].ToString());
                    }
                    if (dt.Rows[n]["AreaInProvince"] != null && dt.Rows[n]["AreaInProvince"].ToString() != "")
                    {
                        model.AreaInProvince = dt.Rows[n]["AreaInProvince"].ToString();
                    }
                    if (dt.Rows[n]["AreaInCity"] != null && dt.Rows[n]["AreaInCity"].ToString() != "")
                    {
                        model.AreaInCity = dt.Rows[n]["AreaInCity"].ToString();
                    }
                    if (dt.Rows[n]["PostCode"] != null && dt.Rows[n]["PostCode"].ToString() != "")
                    {
                        model.PostCode = dt.Rows[n]["PostCode"].ToString();
                    }
                    if (dt.Rows[n]["MemberName"] != null && dt.Rows[n]["MemberName"].ToString() != "")
                    {
                        model.MemberName = dt.Rows[n]["MemberName"].ToString();
                    }
                    if (dt.Rows[n]["PhoneNum"] != null && dt.Rows[n]["PhoneNum"].ToString() != "")
                    {
                        model.PhoneNum = dt.Rows[n]["PhoneNum"].ToString();
                    }
                    if (dt.Rows[n]["Phone"] != null && dt.Rows[n]["Phone"].ToString() != "")
                    {
                        model.Phone = dt.Rows[n]["Phone"].ToString();
                    }
                    if (dt.Rows[n]["Mail"] != null && dt.Rows[n]["Mail"].ToString() != "")
                    {
                        model.Mail = dt.Rows[n]["Mail"].ToString();
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }
                    if (dt.Rows[n]["Address01"] != null && dt.Rows[n]["Address01"].ToString() != "")
                    {
                        model.Address01 = dt.Rows[n]["Address01"].ToString();
                    }
                    if (dt.Rows[n]["Address02"] != null && dt.Rows[n]["Address02"].ToString() != "")
                    {
                        model.Address02 = dt.Rows[n]["Address02"].ToString();
                    }
                    if (dt.Rows[n]["Address03"] != null && dt.Rows[n]["Address03"].ToString() != "")
                    {
                        model.Address03 = dt.Rows[n]["Address03"].ToString();
                    }
                    if (dt.Rows[n]["Address04"] != null && dt.Rows[n]["Address04"].ToString() != "")
                    {
                        model.Address04 = dt.Rows[n]["Address04"].ToString();
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

        public long GetAddressID(string strWhere)
        {
            return dal.GetAddressID(strWhere);
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
