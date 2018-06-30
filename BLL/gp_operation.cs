/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-19 10:55:29 
 * 文 件 名：		gp_operation.cs 
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
    public class gp_operation
    {
        private readonly lgk.DAL.gp_operation dal = new lgk.DAL.gp_operation();
        public gp_operation()
		{}
        /// <summary>
        /// 更新股票发行量
        /// </summary>
        /// <param name="id">发行量ID</param>
        /// <param name="money">股票数</param>
        /// <param name="where">0-减少 1-增加</param>
        /// <returns></returns>
        public int UpdateSurplusAmount(int id, decimal money, int where)
        {
            return dal.UpdateSurplusAmount(id, money, where);
        }
        /// <summary>
        /// 拆股前(返还待卖出股数)
        /// </summary>
        /// <returns></returns>
        public int chaigu()
        {
            return dal.chaigu();
        }
        /// <summary>
        ///判断是否进入贡献仓
        /// </summary>
        /// <returns></returns>
        public int gxc()
        {
            return dal.gxc();
        }
        /// <summary>
        /// 拆股
        /// </summary>
        /// <param name="open_money">开盘价</param>
        /// <param name="cg_rate">拆分比率</param>
        /// <returns></returns>
        public int chaigu(decimal open_money, decimal cg_rate)
        {
            return dal.chaigu(open_money, cg_rate);
        }
        /// <summary>
        /// 强制回购会员股票或贡献仓
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <param name="zh_type">1-股票 2-贡献仓</param>
        /// <param name="amount">交易价格</param>
        /// <returns></returns>
        public int flag_HuiGou(int userid, int zh_type, decimal amount)
        {
            return dal.flag_HuiGou(userid, zh_type, amount);
        }
        /// <summary>
        /// 回购全部
        /// </summary>
        /// <returns></returns>
        public int flag_HuiGou(decimal amount)
        {
            return dal.flag_HuiGou(amount);
        }
        /// <summary>
        /// 后台管理员买股
        /// </summary>
        /// <param name="num"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int A_SaleIn(int num, decimal amount)
        {
            return dal.A_SaleIn(num, amount);
        }

        /// <summary>
        /// 后台管理员卖股
        /// </summary>
        /// <param name="num"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int A_SaleOut(int num, decimal amount)
        {
            return dal.A_SaleOut(num, amount);
        }

        /// <summary>
        /// 前台会员卖股
        /// </summary>
        /// <param name="num"></param>
        /// <param name="amount"></param>
        /// <param name="ucode"></param>
        /// <returns></returns>
        public bool U_MaiGu(int num, decimal amount, long uid, string ucode, int zh_type)
        {
            return dal.U_MaiGu(num, amount, uid, ucode, zh_type);
        }

        /// <summary>
        /// 前台会员买股
        /// </summary>
        /// <param name="num"></param>
        /// <param name="amount"></param>
        /// <param name="ucode"></param>
        /// <returns></returns>
        public bool U_MaiGuOut(int num, decimal amount, long uid, string ucode)
        {
            return dal.U_MaiGuOut(num, amount, uid, ucode);
        }
        /// <summary>
        /// 行情图
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDtForPic(int num)
        {
            return dal.GetDtForPic(num);
        }
        /// <summary>
        /// 价格、成交量图
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetPic(int num)
        {
            return dal.GetPic(num);
        }
        /// <summary>
        /// 查出数据库中是否存在今天的记录
        /// </summary>
        /// <returns></returns>
        public bool IsHasPrice()
        {
            return dal.IsHasPrice();
        }
        /// <summary>
        /// 查出最后发不价格的时间
        /// </summary>
        /// <returns></returns>
        public int Enbtn()
        {
            return dal.Enbtn();
        }
        public void ExecProc(string procName)
        {
            dal.ExecProc(procName);
        }
    }
}
