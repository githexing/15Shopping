/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-2-6 10:23:38 
 * 文 件 名：		BonusOperationBLL.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace lgk.BLL
{
    /// <summary>
    /// 有关奖金、E币的业务类
    /// </summary>
    public class BonusOperationBLL
    {
        lgk.DAL.BonusOperationDAL dal = new lgk.DAL.BonusOperationDAL();
        /// <summary>
        /// 激活计算奖金（）
        /// </summary>
        /// <param name="userid">理财者ID</param>
        /// <returns></returns>
        public int flag_open(int userid, int agentType)
        {
            return dal.flag_open(userid, agentType);
        }
        /// <summary>
        /// 代理商晋升补差额计算业绩
        /// </summary>
        /// <param name="userid">代理商ID</param>
        /// <param name="money">补差金额</param>
        /// <returns></returns>
        public int flag_pro(int userid, decimal money)
        {
            return dal.flag_pro(userid, money);
        }
        /// <summary>
        /// 账户管理
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet getAccount(string strWhere)
        {
            return dal.getAccount(strWhere);
        }
        /// <summary>
        /// 拨出查询
        /// </summary>
        /// <returns></returns>
        public DataSet GetPayScale(string conditon)
        {
            return dal.GetPayScale(conditon);
        }

        /// <summary>
        /// 获得总收入
        /// </summary>
        /// <returns></returns>
        public decimal GetIncomeTotal()
        {
            return dal.GetIncomeTotal();
        }

        /// <summary>
        /// 获得总支出
        /// </summary>
        /// <returns></returns>
        public decimal GetPayTotal()
        {
            return dal.GetPayTotal();
        }

        /// <summary>
        /// 奖金查询
        /// </summary>
        public DataSet GetAList(string strWhere)
        {
            return dal.GetAList(strWhere);
        }
        /// <summary>
        /// 奖金查询
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得奖金明细
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList_money(string strWhere)
        {
            return dal.GetList_money(strWhere);
        }

        /// <summary>
        /// 获取奖金明细
        /// </summary>
        /// <param name="iTop">选择条数</param>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrder">排序</param>
        /// <returns></returns>
        public DataSet GetList_money1(int iTop, string strWhere, string strOrder)
        {
            return dal.GetList_money1(iTop, strWhere, strOrder);
        }

        /// <summary>
        /// 获取每日的奖金明细
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList_DayBonus(string strWhere)
        {
            return dal.GetList_DayBonus(strWhere);
        }

        /// <summary>
        /// 获取广告分红总览和明细
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList_AdBonus(string strWhere)
        {
            return dal.GetList_AdBonus(strWhere);
        }

        /// <summary>
        /// 获得荣誉奖衔列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetHonorarayRs(string strWhere)
        {
            return dal.GetHonorarayRs(strWhere);
        }

        /// <summary>
        /// 获得荣誉奖衔列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList_HonoraryAward(string strWhere)
        {
            return dal.GetList_HonoraryAward(strWhere);
        }

        /// <summary>
        /// 环保基金分红
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetFenHong(string strWhere)
        {
            return dal.GetFenHong(strWhere);
        }
        /// <summary>
        /// 代理商奖金
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetUserBonus(string strWhere)
        {
            return dal.GetUserBonus(strWhere);
        }
        /// <summary>
        /// 奖金查询
        /// </summary>
        public DataSet GetBList(string strWhere)
        {
            return dal.GetBList(strWhere);
        }
        /// <summary>
        /// 总业绩查询
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetAllScore(string strWhere)
        {
            return dal.GetAllScore(strWhere);
        }
        /// <summary>
        /// 业绩查询
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetScore(string strWhere)
        {
            return dal.GetScore(strWhere);
        }


        /// <summary>
        /// 获得分红
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet Getfenhong1(string strWhere)
        {
            return dal.Getfenhong1(strWhere);
        }
    }
}
