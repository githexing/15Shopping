using System;
using System.Data;
using System.Collections.Generic;
using lgk.Model;
namespace lgk.BLL
{
    /// <summary>
    /// tb_agent
    /// </summary>
    public partial class tb_agent1
    {
        private readonly lgk.DAL.tb_agent1 dal = new lgk.DAL.tb_agent1();
        public tb_agent1()
        { }
        /// <summary>
        /// 验证报单中心名是否可用 
        /// </summary>
        /// <param name="users02"></param>
        /// <returns></returns>
        public bool isExistByName(string AgentCode)
        {
            return dal.isExistByName(AgentCode);
        }
        public long GetUserIDByAgentCode(string AgentCode)
        {
            return dal.GetUserIDByAgentCode(AgentCode);
        }
        public long GetUserIDByAgentID(long iAgentID)
        {
            return dal.GetUserIDByAgentID(iAgentID);
        }
        public int GetAgentsID(string AgentCode)
        {
            return dal.GetAgentsID(AgentCode);
        }
        public int GetIDByIDUser(long iUserID)
        {
            return dal.GetIDByIDUser(iUserID);
        }

        public int GetAgentsIDByUserCode(string AgentCode)
        {
            return dal.GetAgentsIDByUserCode(AgentCode);

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
        public long Add(lgk.Model.tb_agent1 model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_agent1 model)
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
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_agent1 GetModel(long ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得服务中心
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public lgk.Model.tb_agent1 GetModel(string where)
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
        public List<lgk.Model.tb_agent1> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<lgk.Model.tb_agent1> DataTableToList(DataTable dt)
        {
            List<lgk.Model.tb_agent1> modelList = new List<lgk.Model.tb_agent1>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                lgk.Model.tb_agent1 model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new lgk.Model.tb_agent1();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = long.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["AgentCode"] != null && dt.Rows[n]["AgentCode"].ToString() != "")
                    {
                        model.AgentCode = dt.Rows[n]["AgentCode"].ToString();
                    }
                    if (dt.Rows[n]["Flag"] != null && dt.Rows[n]["Flag"].ToString() != "")
                    {
                        model.Flag = int.Parse(dt.Rows[n]["Flag"].ToString());
                    }
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["AgentType"] != null && dt.Rows[n]["AgentType"].ToString() != "")
                    {
                        model.AgentType = int.Parse(dt.Rows[n]["AgentType"].ToString());
                    }
                    if (dt.Rows[n]["AppliTime"] != null && dt.Rows[n]["AppliTime"].ToString() != "")
                    {
                        model.AppliTime = DateTime.Parse(dt.Rows[n]["AppliTime"].ToString());
                    }
                    if (dt.Rows[n]["JoinMoney"] != null && dt.Rows[n]["JoinMoney"].ToString() != "")
                    {
                        model.JoinMoney = decimal.Parse(dt.Rows[n]["JoinMoney"].ToString());
                    }
                    if (dt.Rows[n]["OpenTime"] != null && dt.Rows[n]["OpenTime"].ToString() != "")
                    {
                        model.OpenTime = DateTime.Parse(dt.Rows[n]["OpenTime"].ToString());
                    }
                    if (dt.Rows[n]["PicLink"] != null && dt.Rows[n]["PicLink"].ToString() != "")
                    {
                        model.PicLink = dt.Rows[n]["PicLink"].ToString();
                    }
                    if (dt.Rows[n]["AgentInProvince"] != null && dt.Rows[n]["AgentInProvince"].ToString() != "")
                    {
                        model.AgentInProvince = dt.Rows[n]["AgentInProvince"].ToString();
                    }
                    if (dt.Rows[n]["AgentInCity"] != null && dt.Rows[n]["AgentInCity"].ToString() != "")
                    {
                        model.AgentInCity = dt.Rows[n]["AgentInCity"].ToString();
                    }
                    if (dt.Rows[n]["AgentAddress"] != null && dt.Rows[n]["AgentAddress"].ToString() != "")
                    {
                        model.AgentAddress = dt.Rows[n]["AgentAddress"].ToString();
                    }
                    if (dt.Rows[n]["Agent001"] != null && dt.Rows[n]["Agent001"].ToString() != "")
                    {
                        model.Agent001 = int.Parse(dt.Rows[n]["Agent001"].ToString());
                    }
                    if (dt.Rows[n]["Agent002"] != null && dt.Rows[n]["Agent002"].ToString() != "")
                    {
                        model.Agent002 = int.Parse(dt.Rows[n]["Agent002"].ToString());
                    }
                    if (dt.Rows[n]["Agent003"] != null && dt.Rows[n]["Agent003"].ToString() != "")
                    {
                        model.Agent003 = dt.Rows[n]["Agent003"].ToString();
                    }
                    if (dt.Rows[n]["Agent004"] != null && dt.Rows[n]["Agent004"].ToString() != "")
                    {
                        model.Agent004 = dt.Rows[n]["Agent004"].ToString();
                    }
                    if (dt.Rows[n]["Agent005"] != null && dt.Rows[n]["Agent005"].ToString() != "")
                    {
                        model.Agent005 = decimal.Parse(dt.Rows[n]["Agent005"].ToString());
                    }
                    if (dt.Rows[n]["Agent006"] != null && dt.Rows[n]["Agent006"].ToString() != "")
                    {
                        model.Agent006 = decimal.Parse(dt.Rows[n]["Agent006"].ToString());
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

