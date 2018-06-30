using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;

namespace lgk.BLL
{
    //tb_UserMale
    public partial class tb_UserMale
    {

        private readonly lgk.DAL.tb_UserMale dal = new lgk.DAL.tb_UserMale();
        public tb_UserMale()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_UserMale model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_UserMale model)
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
        public DataSet GetOpenList(string strWhere)
        {
            return dal.GetOpenList(strWhere);
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
        public lgk.Model.tb_UserMale GetModel(int ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_UserMale GetModel(string strWhere)
        {

            return dal.GetModel(strWhere);
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
        public List<lgk.Model.tb_UserMale> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_UserMale> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_UserMale> modelList = new List<lgk.Model.tb_UserMale>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_UserMale model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_UserMale();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = int.Parse(dt.Rows[n]["ParentID"].ToString());
                    }
                    if (dt.Rows[n]["MyLeft"].ToString() != "")
                    {
                        model.MyLeft = int.Parse(dt.Rows[n]["MyLeft"].ToString());
                    }
                    if (dt.Rows[n]["MyRight"].ToString() != "")
                    {
                        model.MyRight = int.Parse(dt.Rows[n]["MyRight"].ToString());
                    }
                    model.UserMaleCode = dt.Rows[n]["UserMaleCode"].ToString();
                    model.UserMale001 = dt.Rows[n]["UserMale001"].ToString();
                    model.UserMale002 = dt.Rows[n]["UserMale002"].ToString();
                    if (dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["AddDate"].ToString() != "")
                    {
                        model.AddDate = DateTime.Parse(dt.Rows[n]["AddDate"].ToString());
                    }
                    if (dt.Rows[n]["IsOut"].ToString() != "")
                    {
                        model.IsOut = int.Parse(dt.Rows[n]["IsOut"].ToString());
                    }
                    if (dt.Rows[n]["OutDate"].ToString() != "")
                    {
                        model.OutDate = DateTime.Parse(dt.Rows[n]["OutDate"].ToString());
                    }
                    model.UserPath = dt.Rows[n]["UserPath"].ToString();
                    if (dt.Rows[n]["Layer"].ToString() != "")
                    {
                        model.Layer = int.Parse(dt.Rows[n]["Layer"].ToString());
                    }
                    if (dt.Rows[n]["Location"].ToString() != "")
                    {
                        model.Location = int.Parse(dt.Rows[n]["Location"].ToString());
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
        /// 统计指定层数的B网公排个数
        /// </summary>
        /// <returns></returns>
        public int CountLayerNumber(int layer)
        {
            return dal.CountLayerNumber(layer);
        }

        /// <summary>
        /// 获取没有放满子节点的公排时间最早的节点
        /// </summary>
        /// <returns></returns>
        public lgk.Model.tb_UserMale GetNoFullChildNode()
        {
            return dal.GetNoFullChildNode();
        }

        /// <summary>
        /// 正在公排数量
        /// </summary>
        public int CountPublicOrder()
        {
            return dal.CountPublicOrder();
        }

        /// <summary>
        /// 第一个出局
        /// </summary>
        public int FirstOut()
        {
            return dal.FirstOut();
        }

        /// <summary>
        /// 更新出局的是否出局状态
        /// </summary>
        public int UpdateOrderID()
        {
            return dal.UpdateOrderID();
        }

        /// <summary>
        /// B网见点奖存储过程
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public int Flag_JianDian4BNet(int userid)
        {
            return dal.Flag_JianDian4BNet(userid);
        }
        /// <summary>
        /// 根据条件获取一条数据
        /// </summary>
        /// <param name="whereStr"></param>
        /// <returns></returns>
        public lgk.Model.tb_UserMale GetModelByWhere(string whereStr)
        {
            return dal.GetModelByWhere(whereStr);
        }
        /// <summary>
        /// 根据ID获取一条数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public lgk.Model.tb_UserMale GetModelByID(int ID)
        {
            return dal.GetModelByID(ID);
        }
        /// <summary>
        /// 根据用户编号查找公排ID
        /// </summary>
        /// <param name="GotoBAreaCode"></param>
        /// <returns></returns>
        public int GetIDByUserCode(string GotoBAreaCode)
        {
            return dal.GetIDByUserCode(GotoBAreaCode);
        }
        /// <summary>
        /// 根据用户ID查找B网公排ID
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetIDByIDUser(int userid)
        {
            return dal.GetIDByIDUser(userid);
        }

        #endregion

    }
}