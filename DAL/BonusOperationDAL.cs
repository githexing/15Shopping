/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-2-6 10:22:38 
 * 文 件 名：		BonusOperationDAL.cs 
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
using DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace lgk.DAL
{
    /// <summary>
    /// 有关奖金、E币的数据类
    /// </summary>
    public class BonusOperationDAL
    {
        /// <summary>
        /// 激活计算奖金（）
        /// </summary>
        /// <param name="userid">理财者ID</param>
        /// <returns></returns>
        public int flag_open(int userid, int agentType)
        {
            int result;
            string prop = "proc_open";
            SqlParameter[] para = { new SqlParameter("@openUserid", SqlDbType.Int),
                                   new SqlParameter("@agentType", SqlDbType.Int)};
            para[0].Value = userid;
            para[1].Value = agentType;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        /// <summary>
        /// 代理商晋升补差额计算业绩
        /// </summary>
        /// <param name="userid">代理商ID</param>
        /// <param name="money">补差金额</param>
        /// <returns></returns>
        public int flag_pro(int userid, decimal money)
        {
            int result;
            string prop = "proc_UserPro";
            SqlParameter[] para = { new SqlParameter("@openUserid", SqlDbType.Int),
                                  new SqlParameter("@RegMoney", SqlDbType.Decimal)};
            para[0].Value = userid;
            para[1].Value = money;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        /// <summary>
        /// 账户管理
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet getAccount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select u.UserCode usercode,u.TrueName truename,u.BonustotalAccount lj,u.BonusAccount yu,isnull(sum(t.TakeMoney),0) tx from tb_user as u left join tb_bonusTakeMoney as t on u.UserID=t.UserID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by u.usercode,u.truename,BonustotalAccount,BonusAccount ");
            return DbHelperSQL.Query(strSql.ToString());

        }
        /// <summary>
        /// 拨出查询
        /// </summary>
        /// <returns></returns>
        public DataSet GetPayScale(string conditon)
        {
            string sql = "select isnull(TU.totle,0) totle,isnull(TZ.yf,0) yf,tz.settletime,TU.settleTime,(isnull(TU.totle,0)-isnull(TZ.yf,0)) yl,(case when isnull(TU.totle,0) =0 then isnull(TZ.yf,0) else isnull(TZ.yf,0)/TU.totle*100 end) bb from (select (sum(u.RegMoney)+sum(isnull(p.Pmoney,0))) as totle,Convert(nvarchar(10),u.OpenTime,120) as settleTime from tb_user u left join tb_userPro p on u.UserID=p.UserID WHERE u.UserID<>1 and u.IsOpend<>0 group by Convert(nvarchar(10),u.OpenTime,120)) TU right join (select sum(isnull(b.realityAmount,0)) yf,Convert(nvarchar(10),b.AddTime,120) settleTime from tb_bonus b where UserID<>1 and TypeID<>6 group by Convert(nvarchar(10),b.AddTime,120) )  TZ on TU.settleTime = TZ.settleTime";
            if (conditon != "")
            {
                sql += " where " + conditon;
            }
            return DbHelperSQL.Query(sql);
        }

        /// <summary>
        /// 获得总收入
        /// </summary>
        /// <returns></returns>
        public decimal GetIncomeTotal()
        {
            string sql = "select (sum(u.RegMoney)+sum(isnull(p.Pmoney,0))) from tb_user u left join tb_userPro p on u.UserID=p.UserID WHERE u.UserID<>1 and u.IsOpend<>0 ";
            return Convert.ToDecimal(DbHelperSQL.GetSingle(sql));
        }

        /// <summary>
        /// 获得总支出
        /// </summary>
        /// <returns></returns>
        public decimal GetPayTotal()
        {
            string sql = "select isnull(sum(realityAmount),0) from tb_bonus where UserID<>1 and TypeID<>6 and Bonus002=0";
            return Convert.ToDecimal(DbHelperSQL.GetSingle(sql));
        }

        /// <summary>
        /// 查询用户荣誉奖获奖明细
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetHonorarayRs(string strWhere)
        {
            return DbHelperSQL.Query(strWhere);
        }

        /// <summary>
        /// 奖金查询 ljlj
        /// </summary>
        public DataSet GetAList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select Convert(nvarchar(10),SttleTime,120) SttleTime,
                            sum(case when typeID = 1 then isnull(Amount,0) else 0 end) shifang,
                            sum(case when typeID = 2 then isnull(Amount,0) else 0 end) jingtai,
                            sum(case when typeID = 3 then isnull(Amount,0) else 0 end) dongtai,
                            sum(Bonus005) Bonus005,
                            sum(Amount) am,
                            sum(Revenue) Revenue,
                            sum(sf) sf
                            from tb_bonus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);// + " and Bonus002=0");
            }
            strSql.Append(" group by Convert(nvarchar(10),SttleTime,120) ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Convert(nvarchar(10),SttleTime,120) SttleTime,sum(case when typeID =3 then isnull(Amount,0) else 0 end) yc,sum(case when typeID =3 then isnull(Amount,0) else 0 end) yf from  tb_bonus ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);// + " and Bonus002=0");
            }
            strSql.Append(" group by  Convert(nvarchar(10),SttleTime,120) ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得奖金明细  ljlj
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList_money(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select b.UserID UserID,u.UserCode UserCode,u.TrueName TrueName,
                            Convert(nvarchar(10),b.SttleTime,120) SttleTime,
                            sum(case when b.typeID = 1 then isnull(b.Amount,0) else 0 end) shifang, 
                            sum(case when b.typeID = 2 then isnull(b.Amount,0) else 0 end) jingtai,
                            sum(case when b.typeID = 3 then isnull(b.Amount,0) else 0 end) dongtai,
                            sum(case when b.typeID = 4 then isnull(b.Amount,0) else 0 end) dongtai1,
                            sum(case when b.typeID = 5 then isnull(b.Amount,0) else 0 end) dongtai2,
                            sum(case when b.typeID = 6 then isnull(b.Amount,0) else 0 end) dongtai3,
                            sum(case when b.typeID = 7 then isnull(b.Amount,0) else 0 end) dongtai4,
                            sum(Bonus005) Bonus005,
                            sum(Amount) am,
                            sum(Revenue) Revenue,
                            sum(sf) sf,
                            sum(Bonus006) Bonus006
                            from tb_bonus b join tb_user u on u.UserID=b.UserID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);// + " and b.Bonus002=0");
            }
            strSql.Append(" group by b.userid,u.usercode,u.truename, Convert(nvarchar(10),b.SttleTime,120)");
            return DbHelperSQL.Query(strSql.ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select ");
            if (iTop > 0) 
            {
                strSql.Append(" top " + iTop);
            }
            strSql.Append(@" b.UserID uid,u.UserCode yhm,u.TrueName xm, u.AccountType at,u.isLock il,u.LevelID li,
                            Convert(nvarchar(10),b.SttleTime,120) SttleTime,
                            Convert(nvarchar(10),u.OpenTime,120) OpenTime,
                            replace( replace( 'SttleTime=OpenTime&UserID=uid','OpenTime',Convert(nvarchar(10),u.OpenTime,120)),'uid',b.UserID) jj,
                            sum(case when b.typeID =1 then isnull(b.Amount,0) else 0 end) tj, 
                            sum(case when b.typeID =2 then isnull(b.Amount,0) else 0 end) dp,
                            sum(case when b.typeID =4 then isnull(b.Amount,0) else 0 end)  fl,
                            sum(Amount) am,
                            sum(sf) am
                            from  tb_bonus b join tb_user u on u.userid=b.userid");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);// + " and b.Bonus002=0");
            }
            strSql.Append(" group by b.userid,u.usercode,u.truename,u.AccountType,u.isLock,u.LevelID,Convert(nvarchar(10),b.SttleTime,120),Convert(nvarchar(10),u.OpenTime,120)");
            if (strOrder.Trim() != "") 
            {
                strSql.Append(" order by " + strOrder);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取每日的奖金明细
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList_DayBonus(string strWhere)
        {
            return DbHelperSQL.Query(strWhere);
        }

        /// <summary>
        /// 获取广告分红总览和明细
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList_AdBonus(string strWhere)
        {
            return DbHelperSQL.Query(strWhere);
        }

        /// <summary>
        /// 获得荣誉奖衔列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList_HonoraryAward(string strWhere)
        {
            return DbHelperSQL.Query(strWhere);
        }

        /// <summary>
        /// 环保基金分红
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetFenHong(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.UserID userid,b.IsSettled IsSettled,u.UserCode usercode,u.TrueName truename,u.LevelID levelid,isnull(b.Amount,0) fh,sum(isnull(b.Amount,0)) yf,b.SttleTime SttleTime from  tb_bonus as b inner join tb_user as u on u.UserID=b.UserID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere + " and b.Bonus002=0");
            }
            strSql.Append(" group by b.userid,b.IsSettled,u.usercode,u.truename,u.levelid,b.Amount,b.SttleTime");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 代理商奖金
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetUserBonus(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.UserID UserID,b.IsSettled IsSettled,bt.TypeID TypeID,bt.TypeName TypeName,bt.TypeNameEn TypeNameEn,b.SttleTime SttleTime,b.Source source,b.SourceEn sourceen,isnull(b.Amount,0) Amount,isnull(b.Revenue,0) Revenue,isnull(b.Bonus005,0) Bonus005,isnull(b.Bonus006,0) Bonus006,isnull(b.sf,0) sf,Batch from  tb_bonus as b inner join tb_bonusType as bt on bt.TypeID=b.TypeID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);// + "and b.Bonus002=0");
            }
            //strSql.Append(" group by userid,usercode,truename,Convert(nvarchar(10),SttleTime,120)");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 奖金查询
        /// </summary>
        public DataSet GetBList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID userid,Convert(nvarchar(10),SttleTime,120) SttleTime,sum(case when typeID =1 then isnull(Amount,0) else 0 end) jd,sum(case when typeID =2 then isnull(Amount,0) else 0 end) tj,sum(isnull(Amount,0)) yf from  tb_bonus");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " and Bonus002=0");
            }
            strSql.Append(" group by userid,Convert(nvarchar(10),SttleTime,120) ");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 总业绩查询
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetAllScore(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select convert(varchar(6),AddDate,112) stime,sum(isnull(Score,0)) smoney from tb_Score  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by convert(varchar(6),AddDate,112) ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 业绩查询
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetScore(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserCode usercode,TrueName truename,sum(case when TypeID =1 then isnull(Score,0) else 0 end) money1,sum(case when TypeID =2 then isnull(Score,0) else 0 end) money2,sum(case when TypeID =3 then isnull(Score,0) else 0 end) money3,sum(case when TypeID =4 then isnull(Score,0) else 0 end) money4,sum(case when TypeID =5 then isnull(Score,0) else 0 end) money5,sum(case when TypeID =6 then isnull(Score,0) else 0 end) money6,sum(case when TypeID =7 then isnull(Score,0) else 0 end) money7,sum(isnull(Score,0)) smoney,convert(varchar(6),AddDate,112) stime from tb_Score  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by usercode,truename,convert(varchar(6),AddDate,112) ");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得分红
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet Getfenhong1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select b.UserID uid,u.UserCode yhm,u.TrueName xm,
                            Convert(nvarchar(10),b.SttleTime,120) SttleTime,
                            b.Amount fhlr
                            from  tb_bonus b join tb_user u on u.userid=b.userid ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere + " and b.Bonus002=0");
            }
            strSql.Append(" and b.TypeID=5");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
