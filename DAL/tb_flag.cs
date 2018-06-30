/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-22 16:06:12 
 * 文 件 名：		tb_flag.cs 
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
using System.Data.SqlClient;
using System.Data;
using DataAccess;
using System.Net.Mail;

namespace lgk.DAL
{
    public class tb_flag
    {
        /// <summary>
        /// 奖金结算
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="Bonus">奖金额</param>
        /// <param name="BonusType">奖金类型</param>
        /// <param name="State">奖金发放方式 （0为秒结日发 1为秒结秒发）</param>
        /// <param name="FromUserID">来自哪个会员</param>
        /// <returns></returns>
        public int AddBonus(int UserID, decimal Bonus, int BonusType, int State, int FromUserID)
        {
            int result;
            string prop = "proc_bonus";
            SqlParameter[] para = { new SqlParameter("@userid", SqlDbType.Int),
                                   new SqlParameter("@bonus", SqlDbType.Decimal),
                                   new SqlParameter("@bonustype", SqlDbType.Int),
                                   new SqlParameter("@state", SqlDbType.Int),
                                   new SqlParameter("@fromUserid", SqlDbType.Int)};
            para[0].Value = UserID;
            para[1].Value = Bonus;
            para[2].Value = BonusType;
            para[3].Value = State;
            para[4].Value = FromUserID;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        /// <summary>
        /// 注册添加用户
        /// </summary>
        /// <param name="IsAgent">注册类型：1-代理人 0-用户</param>
        /// <param name="UserCode">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="SecondPassword">二级密码</param>
        /// <param name="RecommendID">推荐人ID</param>
        /// <returns></returns>
        public int AddUser(int IsAgent, string UserCode, string Password, string SecondPassword, int RecommendID)
        {
            int result;
            string prop = "proc_find";
            SqlParameter[] para = { new SqlParameter("@IsAgent", SqlDbType.Int),
                                   new SqlParameter("@UserCode", SqlDbType.VarChar,200),
                                   new SqlParameter("@Password", SqlDbType.VarChar,200),
                                   new SqlParameter("@SecondPassword", SqlDbType.VarChar,200),
                                   new SqlParameter("@RecommendID", SqlDbType.Int)};
            para[0].Value = IsAgent;
            para[1].Value = UserCode;
            para[2].Value = Password;
            para[3].Value = SecondPassword;
            para[4].Value = RecommendID;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        /// <summary>
        /// 任务完成，结算奖金
        /// </summary>
        /// <param name="userid">接任务用户</param>
        /// <param name="fromID">发布任务代理人</param>
        /// <param name="yongjin">任务佣金</param>
        /// <param name="amount">2倍冻结金额</param>
        /// <param name="flagType">1-代理商确认  0-后台确认</param>
        /// <returns></returns>
        public int flag_Bonus(int userid, int fromID, decimal yongjin, decimal amount, int flagType)
        {
            int result;
            string prop = "proc_yongjin";
            SqlParameter[] para = { new SqlParameter("@openUserid", SqlDbType.Int),
                                   new SqlParameter("@fromID", SqlDbType.Int),
                                   new SqlParameter("@yongjin", SqlDbType.Decimal),
                                   new SqlParameter("@amount", SqlDbType.Decimal),
                                   new SqlParameter("@flagType", SqlDbType.Int)};
            para[0].Value = userid;
            para[1].Value = fromID;
            para[2].Value = yongjin;
            para[3].Value = amount;
            para[4].Value = flagType;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }

        /// <summary>
        /// 开通指定会员编号的会员，2开通实单，3开通空单。
        /// </summary>
        /// <param name="userid">指定会员编号</param>
        /// <param name="iIsOpend">2开通实单，3开通空单</param>
        /// <returns></returns>
        public int flag_open(long iUserID, int iIsOpend)
        {
            int result;
            string prop = "proc_open";
            SqlParameter[] para = { new SqlParameter("@UserID", SqlDbType.BigInt,8),
                                    new SqlParameter("@IsOpend ", SqlDbType.Int)};
            para[0].Value = iUserID;
            para[1].Value = iIsOpend;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        /// <summary>
        /// 开通指定会员编号的会员 。
        /// </summary>
        /// <param name="NewUserID">指定会员编号</param>
        /// <param name="OpUserID"> </param>
        /// <returns></returns>
        public int flag_ActivationUser(long NewUserID, long OpUserID)
        {
            int result;
            string prop = "proc_OpenCheck";
            SqlParameter[] para = { new SqlParameter("@NewUserID", SqlDbType.BigInt,8),
                                    new SqlParameter("@OpUserID ", SqlDbType.BigInt,8)};
            para[0].Value = NewUserID;
            para[1].Value = OpUserID;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        /// <summary>
        /// 插入会员
        /// </summary>
        /// <param name="moveUserCode"></param>
        /// <param name="targetUserCode"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public int flag_InsertUser(string moveUserCode, string targetUserCode, int location)
        {
            int result;
            string prop = "proc_InsertUser";
            SqlParameter[] para = { new SqlParameter("@moveUserCode", SqlDbType.NVarChar),
                                    new SqlParameter("@tagetUserCode ", SqlDbType.NVarChar) ,
                                   new SqlParameter("@location",SqlDbType.Int)};
            para[0].Value = moveUserCode;
            para[1].Value = targetUserCode;
            para[2].Value = location;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }

        /// <summary>
        ///  插入会员网络
        /// </summary>
        /// <param name="moveUserCode"></param>
        /// <param name="targetUserCode"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public int flag_InsertUserNet(string moveUserCode, string targetUserCode, int location)
        {
            int result;
            string prop = "proc_InsertUserNet";
            SqlParameter[] para = { new SqlParameter("@moveUserCode", SqlDbType.NVarChar),
                                    new SqlParameter("@tagetUserCode ", SqlDbType.NVarChar) ,
                                   new SqlParameter("@location",SqlDbType.Int)};
            para[0].Value = moveUserCode;
            para[1].Value = targetUserCode;
            para[2].Value = location;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }

        /// <summary>
        ///  插入注册会员
        /// </summary>
        /// <param name="moveUserCode"></param>
        /// <param name="targetUserCode"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public int flag_InsertRegUser(string moveUserCode, string targetUserCode, int location)
        {
            int result;
            string prop = "proc_InsertRegUser";
            SqlParameter[] para = { new SqlParameter("@moveUserCode", SqlDbType.NVarChar),
                                    new SqlParameter("@tagetUserCode ", SqlDbType.NVarChar) ,
                                   new SqlParameter("@location",SqlDbType.Int)};
            para[0].Value = moveUserCode;
            para[1].Value = targetUserCode;
            para[2].Value = location;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }

        /// <summary>
        /// 开通代理商
        /// </summary>
        /// <param name="id">代理商ID</param>
        /// <returns></returns>
        public int flag_openAgent(int id, int Alevel)
        {
            int result;
            string prop = "proc_openAgent";
            SqlParameter[] para = { 
                                      new SqlParameter("@openID", SqlDbType.Int)};
            para[0].Value = id;
            para[1].Value = Alevel;

            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        /// <summary>
        /// 删除会员，下线会员位置上移
        /// </summary>
        /// <param name="userid">要删除的会员ID</param>
        /// <returns></returns>
        public int flag_delete(long iUserID)
        {
            int result;
            string prop = "proc_delete";
            SqlParameter[] para = { new SqlParameter("@UserID", SqlDbType.BigInt,8) };
            para[0].Value = iUserID;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        public bool flag_pro(int id, int typen)//xdffd
        {
            int result;
            string prop = "proc_openPro";
            SqlParameter[] para = { new SqlParameter("@UserID", SqlDbType.Int) ,
                                   new SqlParameter("@typen ", SqlDbType.Int)};
            para[0].Value = id;
            para[1].Value = typen;
            DbHelperSQL.RunProcedure(prop, para, out result);
            if (result > 0) { return true; }
            else return false;
        }
        public int flag_fh(long iUserID)
        {
            int result;
            string prop = "proc_fenhongdian";
            SqlParameter[] para = { new SqlParameter("@openUserid", SqlDbType.BigInt,8) };
            para[0].Value = iUserID;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }

        //public bool flag_pro(int id, int typen)//xdffd
        //{
        //    int result;
        //    string prop = string.Format("exec proc_openPro {0},{1}", id, typen);
            
        //   result= DbHelperSQL.ExecuteSql(prop);
        //    if (result > 0) { return true; }
        //    else return false;
        //}



        /// <summary>
        /// 手动发放奖金
        /// </summary>
        /// <param name="type">奖金类型：1-互助奖  2-股东分红</param>
        /// <returns></returns>
        public int flag_send(int type)
        {
            int result;
            string prop = "proc_sendbyHand";
            SqlParameter[] para = { new SqlParameter("@sendtype", SqlDbType.Int) };
            para[0].Value = type;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        /// <summary>
        /// 添加数据到流水账表
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <param name="inamount">收入</param>
        /// <param name="outamount">支出</param>
        /// <param name="banlance">余额</param>
        /// <param name="jourtype">类型：1奖金，2-E币,3股金钱包</param>
        /// <param name="type">奖金类型</param>
        /// <param name="remark">业务摘要</param>
        /// <param name="fromID">来自哪个会员</param>
        /// <returns></returns>
        public int add_journal(long iUserID, decimal inamount, decimal outamount, decimal banlance, int jourtype, int type, string remark, string remarken, long iFromUserID)
        {
            int result;
            string prop = "proc_AddJournal";
            SqlParameter[] para = { new SqlParameter("@UserID", SqlDbType.Int),
                                   new SqlParameter("@InAmount", SqlDbType.Decimal),
                                   new SqlParameter("@OutAmount", SqlDbType.Decimal),
                                   new SqlParameter("@balance", SqlDbType.Decimal),
                                   new SqlParameter("@jourType", SqlDbType.Int),
                                   new SqlParameter("@bonusType", SqlDbType.Int),
                                   new SqlParameter("@Remark", SqlDbType.VarChar,200),
                                   new SqlParameter("@RemarkEn", SqlDbType.VarChar,200),
                                   new SqlParameter("@FromUserID", SqlDbType.Int)};
            para[0].Value = iUserID;
            para[1].Value = inamount;
            para[2].Value = outamount;
            para[3].Value = banlance;
            para[4].Value = jourtype;
            para[5].Value = type;
            para[6].Value = remark;
            para[7].Value = remarken;
            para[8].Value = iFromUserID;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        /// <summary>
        /// 获得全球分红用户数据列表
        /// </summary>
        public DataSet GetBounsList(string TypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tb_user.*,tb_level.LevelName,tb_bonus.* from tb_user INNER JOIN tb_level ON tb_user.LevelID = tb_level.LevelID INNER JOIN tb_bonus ON dbo.tb_user.UserID = tb_bonus.UserID ");
            if (TypeID.Trim() != "")
            {
                strSql.Append(" where tb_bonus.TypeID=" + TypeID.Trim());
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 服务中心列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetAgentList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select a.ID,a.AgentCode,a.AgentType,a.Flag,a.AgentInProvince,a.AgentInCity,a.AgentAddress,a.AppliTime,a.OpenTime,
                        u.UserID,u.UserCode,u.TrueName,u.LevelID,u.AgentsID,u.User006,
                        l.LevelName from tb_agent as a join tb_user as u on a.UserID=u.UserID Join tb_level as l on u.LevelID=l.LevelID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetAgentList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select a.ID,a.AgentCode,a.AgentType,a.Flag,a.AgentInProvince,a.AgentInCity,a.AgentAddress,a.AppliTime,a.OpenTime,
                        u.UserID,u.UserCode,u.TrueName,u.LevelID,u.AgentsID,u.User006,
                        l.LevelName from tb_agent1 as a join tb_user as u on a.UserID=u.UserID Join tb_level as l on u.LevelID=l.LevelID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 晋升记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetProList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select p.ID,p.UserID,u.usercode,u.truename,p.LastLevel,p.EndLevel,p.ProMoney,p.AddDate,p.FlagDate,p.Remark,p.Flag,p.Pro001,p.Pro002,p.Pro003,p.Pro004,p.Pro005,p.Pro006,p.Pro007,p.Pro008 ");
            strSql.Append(" FROM tb_userPro as p join tb_user as u on u.userid=p.userid ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得充值记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetRechangeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select r.ID,r.UserID,u.usercode,u.truename,r.RechargeableMoney,r.RechargeStyle,r.Flag,r.RechargeDate,r.YuAmount,r.RechargeType,r.AgentID,r.Recharge001,r.Recharge002,r.Recharge003,r.Recharge004,r.Recharge005,r.Recharge006  from tb_recharge as r join tb_user as u on u.userid=r.userid ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得汇款记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetRemitList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select r.ID,u.usercode,u.truename,r.BankName,r.BankAccount,r.BankAccountUser,r.RechargeableDate,r.AddDate,r.State,r.RemitMoney,r.YuAmount,r.Remark,r.UserID,r.PassDate,r.Remit001,r.Remit002,r.Remit003,r.Remit004,r.Remit005,r.Remit006 from tb_remit as r join tb_user as u on u.userid=r.userid");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by r.AddDate asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得汇款记录 ， 收款账户 和 打款账户信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetRemitAndBankList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select r.ID,u.usercode,u.truename,sb.BankName,sb.BankAccount,sb.BankAccountUser,sb.BankAddress,sb.BankType,");
            strSql.Append("ub.BankName as PlayBankName,ub.BankAccount as PlayBankAccount,ub.BankAccountUser as PlayBankAccountUser,ub.MasterType,ub.Bank003,");
            strSql.Append("r.RechargeableDate,r.AddDate,r.State,r.RemitMoney,r.YuAmount,r.Remark,r.UserID,r.PassDate,r.Remit003,r.Remit004,r.Remit006");
            strSql.Append(" from tb_remit as r ");
            strSql.Append(" join tb_user as u on u.userid=r.userid");
            strSql.Append(" left join tb_systemBank sb on sb.ID = r.Remit002");
            strSql.Append(" left join tb_UserBank ub on ub.ID = r.Remit001");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by r.AddDate desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得提现总金额
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalTake(long iUserID)
        {
            string strSQL = "select isnull(sum(TakeMoney),0) from tb_takeMoney where Flag=1";
            if (iUserID != 0)
            {
                strSQL += " and UserID=" + iUserID;
            }
            object rs = DbHelperSQL.GetSingle(strSQL);
            if (rs == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(rs);
            }
        }
        /// <summary>
        /// 根据条件获得提现记录
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetTakeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  b.ID,u.UserID, u.UserCode,u.TrueName,nicename,");
            strSql.Append(" bank.BankAccountUser as BankAccountUser, bank.BankAccount as BankAccount, bank.BankName as BankName,");
            strSql.Append(" bank.BankAddress as BankBranch,");
            strSql.Append(" u.IdenCode, u.PhoneNum, b.Take003, u.BankInProvince, u.BankInCity,");
            strSql.Append(" b.TakeMoney, b.TakePoundage, b.RealityMoney, b.TakeTime,");
            strSql.Append(" b.BankDian, b.BonusBalance, b.Flag, u.BankInCity, b.Take001, b.Take002, b.Take004, b.Take005, b.Take006");
            strSql.Append(" , case when  bank.Bank003 = 2 then '支付宝' when  bank.Bank003 = 3 then '微信' else  '银行卡' end as AccountType ");
            strSql.Append(" from tb_takeMoney as b ");
            strSql.Append("  inner join tb_user as u on u.UserID=b.UserID ");
            strSql.Append("  left join [tb_UserBank] bank on bank.UserID = b.UserID and bank.ID = b.Take002");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得重消账户修改记录
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetCXList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select m.ID,m.UserID,u.UserCode,u.TrueName,m.BonusID,u.BonusAccount,m.Amount,m.AddTime,m.Source,m.FromUserID,m.Mix001,m.Mix002,m.Mix003,m.Mix004,m.Mix005,m.Mix006,m.Mix007 from tb_mix m join tb_user u on u.userid=m.userid");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据用户名，密码获得管理员信息
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataSet GetAdminModel(string UserCode, string Password)
        {
            string sql = "select * from tb_admin where UserName=@UserName and Password=@Password";
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    new SqlParameter("@Password", SqlDbType.VarChar,50),
            };
            parameters[0].Value = UserCode;
            parameters[1].Value = Password;
            return DbHelperSQL.Query(sql, parameters);
        }
        /// <summary>
        /// 更新动态（iFlag：1-加，0-减)
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="userid">会员ID</param>
        /// <param name="flag">1-加，0-减</param>
        /// <returns></returns>
        public int UpdateFriendDynamic(string strFiledName, long DynamicID, int num, int iFlag)
        {
            string strSQL = "";

            if (iFlag == 0)
            {
                strSQL = "UPDATE tb_FriendDynamic SET " + strFiledName + "=" + strFiledName + "-" + num + " WHERE ID=" + DynamicID;
            }
            else
            {
                strSQL = "UPDATE tb_FriendDynamic SET " + strFiledName + "=" + strFiledName + "+" + num + " WHERE ID=" + DynamicID;
            }
            return DbHelperSQL.ExecuteSql(strSQL);
        }
        /// <summary>
        /// 更新动态（iFlag：1-加，0-减)
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="userid">会员ID</param>
        /// <param name="flag">1-加，0-减</param>
        /// <returns></returns>
        //public int UpdateThumbs(string strFiledName, long DynamicID, int num, int iFlag)
        //{
        //    string strSQL = "";

        //    if (iFlag == 0)
        //    {
        //        strSQL = "UPDATE tb_FriendDynamic SET " + strFiledName + "=" + strFiledName + "-" + num + " WHERE ID=" + DynamicID;
        //    }
        //    else
        //    {
        //        strSQL = "UPDATE tb_FriendDynamic SET " + strFiledName + "=" + strFiledName + "+" + num + " WHERE ID=" + DynamicID;
        //    }
        //    return DbHelperSQL.ExecuteSql(strSQL);
        //}
        /// <summary>
        /// 更新公司账户(1-增加，0-减少)
        /// </summary>
        /// <param name="Type">字段名</param>
        /// <param name="money">金额</param>
        /// <param name="flag">1-增加，0-减少</param>
        /// <returns></returns>
        public int UpdateSystemAccount(string Type, decimal money, int flag)
        {
            string sql = "";

            if (flag == 0)
            {
                sql = "update tb_systemMoney set " + Type + "=" + Type + "-" + money;
            }
            else
            {
                sql = "update tb_systemMoney set " + Type + "=" + Type + "+" + money;
            }
            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 获取层数
        /// </summary>
        /// <param name="Users01">ID</param>
        /// <returns></returns>
        public int NodeNun(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Layer from tb_user");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = UserID;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            return obj == null ? 0 : Int32.Parse(obj.ToString());
        }
        /// <summary>
        /// 更新给定的账户（iFlag：1-加，0-减)
        /// </summary>
        /// <param name="type">账户类型</param>
        /// <param name="userid">会员ID</param>
        /// <param name="money">金额</param>
        /// <param name="flag">1-加，0-减</param>
        /// <returns></returns>
        public int UpdateAccount(string strFiledName, long iUserID, decimal dMoney, int iFlag)
        {
            string strSQL = "";

            if (iFlag == 0)
            {
                strSQL = "UPDATE tb_user SET " + strFiledName + "=" + strFiledName + "-" + dMoney + " WHERE UserID=" + iUserID;
            }
            else
            {
                strSQL = "UPDATE tb_user SET " + strFiledName + "=" + strFiledName + "+" + dMoney + " WHERE UserID=" + iUserID;
            }
            return DbHelperSQL.ExecuteSql(strSQL);
        }

        /// <summary>
        /// 将给定的字段按用户编号更新成给定的值。
        /// </summary>
        /// <param name="strFiledName">给定的字段</param>
        /// <param name="strFiledValue">给定的值</param>
        /// <param name="iUserID">用户编号</param>
        /// <returns></returns>
        public int UpdateFiled(string strFiledName, string strFiledValue, int iUserID)
        {
            string strSql = "";

            strSql = "UPDATE tb_user SET " + strFiledName + "=" + strFiledValue + " WHERE UserID=" + iUserID;

            return DbHelperSQL.ExecuteSql(strSql);
        }

        /// <summary>
        /// 更新A盘可提现余额
        /// </summary>
        /// <param name="strFiled">更新字段</param>
        /// <param name="iUserID">用户ID</param>
        /// <param name="dMoney">金额</param>
        /// <param name="iFlag">0为减，1为加，即0为提现，1为取消提现。</param>
        /// <returns></returns>
        public int UpdateStockAccount(string strFiled, int iUserID, decimal dMoney, int iFlag)
        {
            string sql = "";

            if (iFlag == 0)
            {
                sql = "UPDATE Stock SET " + strFiled + "=" + strFiled + "-" + dMoney + " WHERE UserID=" + iUserID;
            }
            else
            {
                sql = "UPDATE Stock SET " + strFiled + "=" + strFiled + "+" + dMoney + " WHERE UserID=" + iUserID;
            }
            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 公司帐户 清空默认值
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int UpdateAccountDefault()
        {
            string sql = "UPDATE tb_systemBank SET IsMor = 0 ";

            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 获得会员账户
        /// </summary>
        /// <param name="type">账户名称</param>
        /// <param name="userid">会员ID</param>
        /// <returns></returns>
        public decimal GetMemberAccount(string type, object userid)
        {
            return Convert.ToDecimal(DbHelperSQL.GetSingle("select " + type + " from tb_memberAccount where UserID=" + Convert.ToInt32(userid)));
        }
        /// <summary>
        /// 根据编号获取ID
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public int GetUserIDbByPhone(string UserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID from tb_user");
            strSql.Append(" where PhoneNum=@PhoneNum ");
            SqlParameter[] parameters = {
				new SqlParameter("@PhoneNum", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = UserCode;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }
        public int GetUserID(string UserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID from tb_user");
            strSql.Append(" where UserCode=@UserCode ");
            SqlParameter[] parameters = {
                new SqlParameter("@UserCode", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = UserCode;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 根据ID获取编号
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetUserCode(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserCode from tb_user");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
				new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = UserID;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
        #region 更新昵称
        /// <summary>
        /// 更新昵称  UPDATE tb_user SET gender = @value WHERE UserID=@UserID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(long UserID, string type, string value, string name)
        {
            string strSQL = "UPDATE tb_user SET " + type + "=@value  WHERE UserID=@UserID";
            SqlParameter[] parameters = {
                    new SqlParameter("@value", SqlDbType.VarChar,50),
                    new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = name;
            parameters[1].Value = UserID;

            return DbHelperSQL.ExecuteSql(strSQL, parameters);

           
        }
        #endregion
        #region 更新性别
        /// <summary>
        /// 更新性别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateGender(long UserID, string gender, string name)
        {
            string strSQL = "UPDATE tb_user SET " + gender + "=@Gender WHERE UserID=@UserID";
            SqlParameter[] parameters = {
                    new SqlParameter("@Gender", SqlDbType.VarChar,50),
                    new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = name;
            parameters[1].Value = UserID;

            return DbHelperSQL.ExecuteSql(strSQL, parameters);


        }
        #endregion
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="UserID">理财者ID</param>
        /// <param name="type">密码类型</param>
        /// <param name="pwd">密码值</param>
        /// <returns></returns>
        public int UpdateUserPwd(long UserID, string strFieldName, string strPwd)
        {
            string strSQL = "UPDATE tb_user SET " + strFieldName + "=@Password WHERE UserID=@UserID";
            SqlParameter[] parameters = {
                    new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = strPwd;
            parameters[1].Value = UserID;

            return DbHelperSQL.ExecuteSql(strSQL, parameters);
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="UserID">理财者ID</param>
        /// <param name="type">密码类型</param>
        /// <param name="pwd">密码值</param>
        /// <returns></returns>
        public int UpdateAdminPwd(string UserName, string strFieldName, string strPwd)
        {
            string strSQL = "UPDATE tb_admin SET " + strFieldName + "=@Password WHERE UserName=@UserName";
            SqlParameter[] parameters = {
                    new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.VarChar,50)};
            parameters[0].Value = strPwd;
            parameters[1].Value = UserName;

            return DbHelperSQL.ExecuteSql(strSQL, parameters);
        }

        /// <summary>
        /// 根据编号密码测试用户是否存在
        /// </summary>
        /// <param name="UserCode">用户编号</param>
        /// <param name="Password">用户密码</param>
        /// <returns></returns>
        public bool ExistsAdmin(string UserCode, string Password)
        {
            string sql = "select count(*) from tb_admin where UserName=@UserName and Password=@Password";
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    new SqlParameter("@Password", SqlDbType.VarChar,50),
            };
            parameters[0].Value = UserCode;
            parameters[1].Value = Password;
            int rs = Convert.ToInt32(DbHelperSQL.GetSingle(sql, parameters));
            if (rs > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 清空数据库
        /// </summary>
        public int ClearDataBase()
        {
            return SqlHelper.ExecuteNonQuery(SqlHelper.connStrs, CommandType.StoredProcedure, "DelAll", null);
        }
        /// <summary>
        /// 更新邮件状态
        /// </summary>
        /// <param name="id">邮件id</param>
        /// <param name="type">更新类型</param>
        /// <returns>更新行数</returns>
        public int UpdateState(long id, string type)
        {
            string sql = "update tb_leaveMsg set " + type + "=1 where ID=" + id;
            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新买入，卖出股票操作权限
        /// </summary>
        /// <param name="id">会员ID</param>
        /// <param name="flag">1-锁定 0-解锁</param>
        /// <returns></returns>
        public int UpdateState(int id, int flag)
        {
            string sql = "update tb_user set User003=" + flag + " where UserID=" + id;
            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 删除指定回复留言
        /// </summary>
        /// <param name="ID">留言表的id</param>
        /// <returns>是否成功</returns>
        public bool DeleteReMsg(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_leaveReMsg ");
            strSql.Append(" where LeaveID=@LeaveID");
            SqlParameter[] parameters = {
					new SqlParameter("@LeaveID", SqlDbType.BigInt)
};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获得完全商品列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetShopList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t.ParentID,t.TypeName,p.ProcudeID,p.ProcudeCode,p.procudeName,p.MarketPrice,p.MemberPrice,p.procudePV,p.picture,p.LinkURL,p.IsPutaway,p.Note ");
            strSql.Append(" from tb_produce as p ");
            strSql.Append(" left join tb_produceType as t on p.procudePV=t.ID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取指定类型下是否有商品
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetProduce(int type)
        {
            string sql = "select count(*) from tb_goods where GoodsType=" + type;
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        /// 获取任务总数
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="tab">表</param>
        /// <returns></returns>
        public int GetTaskNum(string where, string tab)
        {
            string sql = "select count(*) from " + tab + " where " + where;
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        /// 获取保险金额总数
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public int GetAllSafeAmount(string where)
        {
            string sql = "select isnull(sum(JobAmount*2),0) from tb_job where " + where;
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        /// 销售查询
        /// </summary>
        /// <returns></returns>
        public DataSet GetSell(string strWhere)
        {
            string sql = @"select u.UserCode,pro.ProcudeID,pro.ProcudeCode,pro.procudeName,pro.Price,pro.OrderSum,pro.OrderTotal,pro.OrderDate from 
                            (
                            select o.UserID,p.ProcudeID,ProcudeCode,p.procudeName,od.Price,od.OrderSum,od.OrderTotal,od.OrderDate
                            from tb_OrderDetail as od
                            left join tb_produce as p on od.ProcudeID=p.ProcudeID
                            left join tb_Order as o on o.OrderCode= od.OrderCode
                            where o.IsSend<>0
                            )
                            as pro
                            left join tb_user as u on pro.UserID=u.UserID";
            if (strWhere != "")
            {
                sql += " where " + strWhere;
            }
            return DbHelperSQL.Query(sql);
        }
        /// <summary>
        /// 修改商品上架标志
        /// </summary>
        /// <param name="flg">0-下架 1-上架</param>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        public int UpdateShopFlg(int flg, int id)
        {
            string sql = "update tb_produce set IsPutaway=" + flg + " where ProcudeID=" + id;

            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 获得id
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public int GetOrderID(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select orderid from tb_order");
            strSql.Append(" where OrderCode=@OrderCode ");
            SqlParameter[] parameters = {
				new SqlParameter("@OrderCode", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = code;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 更新订单发货状态
        /// </summary>
        /// <param name="id">订单ID</param>
        /// <returns></returns>
        public int UpdateSendType(long id)
        {
            int result;
            string prop = "proc_shop";
            SqlParameter[] para = { new SqlParameter("@orderID", SqlDbType.Int) };
            para[0].Value = id;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        /// <summary>
        /// 获得所有订单信息
        /// </summary>
        public DataSet GetAllOrderList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select o.OrderCode,u.UserCode,u.TrueName,u.PhoneNum,o.* ");
            strSql.Append(" from tb_Order as o join tb_user as u on u.UserID=o.UserID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 检测是否是有订单的商品
        /// </summary>
        /// <param name="ProcudeID">商品id</param>
        /// <returns></returns>
        public int ExistsProduct(int ProcudeID)
        {
            string sql = "select count(*) from tb_OrderDetail where ProcudeID=" + ProcudeID;
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        ///根据订单号删除数据
        /// </summary>
        public bool DeleteByCode(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_OrderDetail ");
            strSql.Append(" where OrderCode=@OrderCode");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderCode", SqlDbType.VarChar,50)};
            parameters[0].Value = code;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据任务ID删除任务信息
        /// </summary>
        public bool DeleteInfoByOrderID(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_info ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.Int)
};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是否存在任务号
        /// </summary>
        public bool ExistsOrderID(string OrderCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Order");
            strSql.Append(" where OrderCode=@OrderCode");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderCode", SqlDbType.VarChar,50)
};
            parameters[0].Value = OrderCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得我的任务
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataSet GetAllOrder(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select o.OrderID,o.OrderCode,o.JobID,u.UserCode,j.JobCode,j.JobName,o.SafeAmount,o.JobAmount,o.BaoDanNum,o.BuyDate,o.State ");
            strSql.Append(" from tb_Order as o ");
            strSql.Append(" inner join tb_job as j on o.JobID=j.JobID");
            strSql.Append(" inner join tb_user as u on u.UserID=j.Job001");
            strSql.Append(" where " + where);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得我的收藏
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataSet GetMyCollect(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select j.JobCode,j.JobName,c.AddDate,c.ID,c.JobID ");
            strSql.Append(" from tb_collect as c ");
            strSql.Append(" inner join tb_job as j on j.JobID=c.JobID");
            strSql.Append(" where " + where);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据订单号获取商品
        /// </summary>
        /// <param name="userid">订单号</param>
        /// <returns></returns>
        public DataSet GetDetail(string strOrderCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select o.*,g.*,r.Order5 from dbo.tb_OrderDetail as o join tb_goods as g on g.ID=o.ProcudeID  left join tb_Order r on r.OrderCode=o.OrderCode  ");
            strSql.Append(" where o.OrderCode= '" + strOrderCode + "'");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据订单号获取商品
        /// </summary>
        /// <param name="userid">订单号</param>
        /// <returns></returns>
        public DataSet GetDetail(string strOrderCode, int iTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select g.*,g.RealityPrice as ShopPrice,o.* from dbo.tb_OrderDetail as o join tb_goods_cxth as g on g.ID=o.ProcudeID ");
            strSql.Append(" where o.OrderCode= '" + strOrderCode + "'");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得转账记录
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetTransferList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c.ID,c.UserID,u1.usercode,u1.truename,c.ToUserType,c.ToUserID,u2.usercode tocode,u2.truename toname,c.ChangeType,c.MoneyType,c.Amount,c.ChangeDate,c.Change001,c.Change002,c.Change003,c.Change004,c.Change005,c.Change006  ");
            strSql.Append(" From tb_change c left join tb_user u1 on u1.userid=c.userid left join  tb_user u2 on u2.userid=c.touserid ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该排序记录
        /// </summary>
        public bool OrderExists(int JobOrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_job");
            strSql.Append(" where Job002=@JobOrderID");
            SqlParameter[] parameters = {
					new SqlParameter("@JobOrderID", SqlDbType.Int,4)
};
            parameters[0].Value = JobOrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="MessageFrom">发信人</param>
        /// <param name="Pwd">密码</param>
        /// <param name="ToMail">收信人</param>
        /// <param name="Title">标题</param>
        /// <param name="Body">内容</param>
        /// <param name="Host">发送邮件服务器</param>
        /// <returns></returns>
        public bool SendEmail(MailAddress MessageFrom, string Pwd, string ToMail, string Title, string Body, string Host)
        {
            MailMessage msg = new MailMessage();


            //这边是添加发送人的地址
            //msg.To.Add("发送的邮件");------这里注意，这里是写死的地址，只做到发送邮件并不能为自动。


            msg.To.Add(ToMail);

            msg.From = new MailAddress(MessageFrom.Address, "淘宝掘金", System.Text.Encoding.UTF8);

            msg.Subject = Title;//邮件标题 
            msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码 
            msg.Body = Body;//邮件内容 
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码 
            msg.IsBodyHtml = false;//是否是HTML邮件 
            msg.Priority = MailPriority.High;//邮件优先级

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(MessageFrom.Address, Pwd);



            //注册的邮箱和密码 
            client.Host = Host;
            try
            {
                client.Send(msg);

                return true;

            }
            catch (Exception )
            {
                return false;
            }
        }
        /// <summary>
        /// 拨出查询
        /// </summary>
        /// <returns></returns>
        public DataSet GetPayScale(string conditon)
        {
            string sql = "select isnull(TU.totle,0) totle,isnull(TZ.yf,0) yf,TZ.settleTime,(isnull(TU.totle,0)-isnull(TZ.yf,0)) yl,(case when isnull(TU.totle,0) =0 then 0 else isnull(TZ.yf,0)/TU.totle*100 end) bb from (select sum(isnull(RegMoney,0)) as totle,Convert(nvarchar(10),OpenTime,120) as settleTime from tb_user where UserID<>1 and IsOpend=2 group by Convert(nvarchar(10),OpenTime,120)) TU right join (select sum(isnull(sf,0)) yf,Convert(nvarchar(10),AddTime,120) settleTime from tb_bonus  where UserID<>1 group by Convert(nvarchar(10),AddTime,120) )  TZ on TU.settleTime = TZ.settleTime";
            if (conditon != "")
            {
                sql += " where " + conditon;
            }
            return DbHelperSQL.Query(sql);
        }


        /// <summary>
        /// 拨出比率每天
        /// </summary>
        /// <param name="where1">recordTime字段时间段查询</param>
        /// <param name="where2">AddTime字段时间段查询</param>
        /// <returns></returns>
        public DataSet GetPayScale(string where1,string where2)
        {
            string sql =string.Format( "select ISNULL(shour.zhichu,0) as sr ,shour.recordTime, ISNULL(yf,0)as zc,(ISNULL(shour.zhichu,0)-ISNULL(yf,0))as yl from (select sum(isnull(reMoney,0)) zhichu,Convert(nvarchar(10),recordTime,120) recordTime from tb_userRecord  where 1=1 {0} and reType=2  group by Convert(nvarchar(10),recordTime,120)) shour left join (select sum(isnull(sf,0)) yf,Convert(nvarchar(10),AddTime,120) settleTime from tb_bonus  where 1=1 {1} group by Convert(nvarchar(10),AddTime,120))zhuc  on zhuc.settleTime=shour.recordTime where 1=1 ",where1,where2);
         
            return DbHelperSQL.Query(sql);
        }


        /// <summary>
        /// 获得扣除特殊奖励记录
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public DataSet GetKouChu(string where)
        {
            string sql = "select ID,m.UserID,u.UserCode,u.TrueName,m.BonusID,m.Amount,m.AddTime,m.Source,m.FromUserID,m.Mix001,m.Mix002,m.Mix003,m.Mix004,m.Mix005,m.Mix006,m.Mix007 from dbo.tb_mix m join tb_user u on u.userid=m.userid";
            if (where != "")
            {
                sql += " where " + where;
            }
            return DbHelperSQL.Query(sql);
        }
        /// <summary>
        /// 获得总收入
        /// </summary>
        /// <returns></returns>
        public decimal GetIncomeTotal()
        {
            //string sql = "select (sum(u.RegMoney)+sum(isnull(p.Pmoney,0))) from tb_user u left join tb_userPro p on u.UserID=p.UserID WHERE u.UserID<>1 and u.IsOpend<>0 ";
            //string sql = "select sum(isnull(RegMoney,0)) from tb_user where userid<>1 and isopend=2";
            string sql = "select SUM( isnull(reMoney,0))as sf from tb_userRecord  where 1=1";
            return Convert.ToDecimal(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        /// 获得总支出
        /// </summary>
        /// <returns></returns>
        public decimal GetPayTotal()
        {
            string sql = "select sum(isnull(sf,0)) from tb_bonus where 1=1";
            return Convert.ToDecimal(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        /// 获得增值记录
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public DataSet GetZengZhi(string where)
        {
            string sql = "select j.JobID,u.UserCode,u.TrueName,j. JobCode,j. JobName,j. SafeAmount,j. ProductAmount,j. JobAmount,j. SafeType,j. AddTime,j. PayDate,j. FlagType,j. IsPutaway,j. Job001,j. Sult,j. picture,j. Accesssory,j. LinkURL,j. JobInfo,j. Note,j. Job002,j. Job003,j. Job004,j. Job005,j. Job006 from dbo.tb_job as j join tb_user u on j.Job001=u.UserID";
            if (where != "")
            {
                sql += " where " + where;
            }
            return DbHelperSQL.Query(sql);
        }
        /// <summary>
        /// 获得投资记录
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public DataSet GetTouZi(string where)
        {
            string sql = "select o.OrderID,o.UserID,u.UserCode,u.TrueName,o.OrderCode,o.JobID,o.SafeAmount,o.ProductAmount,o.JobAmount,o.BaoDanNum,o.BuyDate,o.State,o.order7,o.InfoFor,o.Info,o.order1,o.order2,o.order3,o.order4,o.order5,o.order6 from dbo.tb_Order o join tb_user u on u.UserID=o.UserID";
            if (where != "")
            {
                sql += " where " + where;
            }
            return DbHelperSQL.Query(sql);
        }
        /// <summary>
        /// 分红记录
        /// </summary>
        /// <returns></returns>
        public DataSet GetFenHong(string where)
        {
            string sql = "select convert(varchar(20),AddTime,120) sendtime,Amount from tb_mix ";
            if (where != "")
            {
                sql += " where " + where;
            }
            sql += " group by convert(varchar(20),AddTime,120),Amount";
            return DbHelperSQL.Query(sql);
        }

        /// <summary>
        /// 商品列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetGoodsList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select p.ID,p.GoodsCode,p.GoodsName,p.Price,p.RealityPrice,
                p.Standard,p.IsHave,p.TypeID,p.GoodsType,p.Pic1,p.Pic2,p.Pic3,p.Pic4,p.Pic5,
                p.Summary,p.Remarks,p.AddTime,p.Goods001,p.Goods002,p.Goods003,p.Goods004,p.Goods005,p.ShopPrice,
                p.Goods006,p.Goods007,p.Goods008,p.StateType,p.City,
                (SELECT TypeName FROM tb_produceType WHERE ID=p.TypeID) AS OneName,
                (SELECT TypeName FROM tb_produceType WHERE ID=p.GoodsType) AS TypeName,
       (SELECT TypeName FROM tb_produceType WHERE ID=p.Goods006) AS SypeName from tb_goods p JOIN tb_produceType t ON  t.ParentID=p.TypeID AND t.ID = p.GoodsType AND p.Goods003 <> '1'");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 促销商品列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetGoodsListCx(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select p.*,
                (SELECT TypeName FROM tb_produceType WHERE ID=p.TypeID) AS OneName,
                (SELECT TypeName FROM tb_produceType WHERE ID=p.GoodsType) AS TwoName,
                (SELECT TypeName FROM tb_produceType WHERE ID=p.PareTopId) AS ThreeName from [tb_goods_cxth] p");
            //JOIN tb_produceType t ON  t.ParentID=p.TypeID AND t.ID = p.GoodsType AND p.Goods003 <> '1'
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 执行分红
        /// </summary>
        /// <param name="money">利润总额</param>
        /// <returns></returns>
        public int flag_fenhong(decimal money)
        {
            int result;
            string prop = "Proc_tb_HandlePartnerBouns";
            SqlParameter[] para = { new SqlParameter("@BonusMoney", SqlDbType.Decimal) };
            para[0].Value = money;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }

        /// <summary>
        /// 购买
        /// </summary>
        /// <param name="money">利润总额</param>
        /// <returns></returns>
        public int Proc_Shopping(long iUserID, string iOrderCode)
        {
            int result;
            string prop = "Proc_Shopping";
            SqlParameter[] para = { 
                                      new SqlParameter("@UserID", SqlDbType.BigInt),
                                      new SqlParameter("@OrderCode", SqlDbType.VarChar,50)
                                  };
            para[0].Value = iUserID;
            para[1].Value = iOrderCode;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }

        /// <summary>
        /// 获取产品尺码
        /// </summary>
        /// <param name="goodsID">产品ID</param>
        /// <returns></returns>
        public DataSet GetGoodsPropertySize(int goodsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select goodsID,SizeName  from tb_goods_property_size");
            strSql.Append(" where goodsID = " + goodsID);
            strSql.Append(" group by goodsID,SizeName");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 投资
        /// </summary>
        public int proc_BuyMachine(long UserID,  int Num,int BuyType)
        {
            int result = 0;
            int rowsAffected;
            SqlParameter[] parameters = {
                          new SqlParameter("@UserID", SqlDbType.VarChar,50),
                          new SqlParameter("@Num", SqlDbType.Int,4),
                          new SqlParameter("@BuyType", SqlDbType.Int,4)
                          };
            parameters[0].Value = UserID;
            parameters[1].Value = Num;
            parameters[2].Value = BuyType;
            result = DbHelperSQL.RunProcedure("proc_BuyMachine", parameters, out rowsAffected);
            
            return result;
        }

        /// <summary>
        /// 获取主账号投资额度
        /// </summary>
        /// <param name="UserID">ID</param>
        /// <returns></returns>
        public decimal GetInvestAmount(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(Amount) from tb_OrderInvest ");
            strSql.Append(" where UserID = " + UserID);
            strSql.Append(" and AccountType = 1 and InvestType = 1");
            var val = DbHelperSQL.GetSingle(strSql.ToString());
            return val == null?0: decimal.Parse(val.ToString());
        }

        /// <summary>
        /// 获取主账号投资额度
        /// </summary>
        /// <param name="UserID">ID</param>
        /// <returns></returns>
        public string GetInvestMaxDate(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(Addtime) from tb_OrderInvest ");
            strSql.Append(" where UserID = " + UserID);
            strSql.Append(" and AccountType = 1 and InvestType = 1");
            var val = DbHelperSQL.GetSingle(strSql.ToString());
            return val == null ? "": val.ToString();
        }

        /// <summary>
        /// 获取分账号投资额度
        /// </summary>
        /// <param name="UserID">ID</param>
        /// <returns></returns>
        public decimal GetSecondInvestAmount(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(Amount) from tb_OrderInvest ");
            strSql.Append(" where UserID = " + UserID);
            strSql.Append(" and AccountType = 2 and InvestType = 1");
            var val = DbHelperSQL.GetSingle(strSql.ToString());
            return val == null ? 0 : decimal.Parse(val.ToString());
        }

        /// <summary>
        /// 获取主账号最大投资额度
        /// </summary>
        /// <param name="UserID">ID</param>
        /// <returns></returns>
        public decimal GetInvestMaxAmount(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(Amount) from tb_OrderInvest ");
            strSql.Append(" where UserID = " + UserID);
            strSql.Append(" and AccountType = 1 and InvestType = 1");
            var val = DbHelperSQL.GetSingle(strSql.ToString());
            return val == null ? 0 : decimal.Parse(val.ToString());
        }

        /// <summary>
        /// 获取聚元
        /// </summary>
        /// <param name="userid">接任务用户</param>
        /// <returns></returns>
        public DataSet flag_ShareGet(long userid)
        {
            string prop = "proc_Award_ShareGet";
            SqlParameter[] para = { new SqlParameter("@UserID", SqlDbType.BigInt)};
            para[0].Value = userid;

            DataSet ds = DbHelperSQL.RunProcedure(prop, para, "table");
            return ds;
        }
        /// <summary>
        /// 总期数
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public decimal GetTotalPhase(long userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull((select top 1 TotalPhase from tb_OrderInvest where [state] = 0 and UserID = " + userid + "),0)");
            strSql.Append(" + isnull((select SUM(RealReleasedPhase) from tb_OrderInvest where [state] > 0 and UserID = " + userid + "), 0) ");
            var val = DbHelperSQL.GetSingle(strSql.ToString());
            return val == null ? 0 : decimal.Parse(val.ToString());
        }
        /// <summary>
        /// 已获取财富源
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataSet GetAlreadyBonusList(long userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select '已获取:'+cast(Amount as varchar)+'财富源' as bonus,[Source] ,SttleTime from [tb_bonus] where UserID = " + userid + " and TypeID in (1,2,3,4) order by AddTime desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 消费积分
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataSet GetConsumeBonusList(long userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Revenue as bonus,[Source] ,SttleTime from [tb_bonus] where UserID = " + userid + " and TypeID = 1");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 达人收益列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataSet GetDarenBonusList(long userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Amount as bonus,[Source] ,SttleTime from [tb_bonus] where UserID = "+ userid +" and TypeID = 5");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 富贵达人列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataSet GetRichManBonusList(long userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Amount as bonus,[Source] ,SttleTime from [tb_bonus] where UserID = " + userid + " and (TypeID = 5 or TypeID = 6)");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取总奖金
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public decimal GetTotalBonus(long userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(TotalBonus) - isnull((select sum(TotalBonus - ReleasedBonus) from tb_OrderInvest where UserID = " + userid + " and [State] = 1),0),0) TotalBonus  from tb_OrderInvest where UserID = " + userid + "  ");
            var val = DbHelperSQL.GetSingle(strSql.ToString());
            return val == null ? 0 : decimal.Parse(val.ToString());
        }
        /// <summary>
        /// 已获取奖金
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public decimal GetTotalBonusAlready(long userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(ReleasedBonus),0) from tb_OrderInvest where UserID = " + userid );
            var val = DbHelperSQL.GetSingle(strSql.ToString());
            return val == null ? 0 : decimal.Parse(val.ToString());
        }
        /// <summary>
        /// 达人收益总奖金
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public decimal GetTotalAmount(long userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(Amount) Amount from tb_bonus where UserID = " + userid + " and  TypeID = 5");
            var val = DbHelperSQL.GetSingle(strSql.ToString());
            return val == null ? 0 : decimal.Parse(val.ToString());
        }

        /// <summary>
        /// 健康运动任务完成,计算奖金
        /// </summary>
        /// <param name="userid">用户</param>
        /// <returns></returns>
        public int flag_Award_TaskDone(long userid,long taskid, string timelong, string donenum)
        {
            int result;

            string prop = "proc_Award_InterestTask";
            SqlParameter[] para = { new SqlParameter("@UserID", SqlDbType.BigInt),
                new SqlParameter("@TaskID", SqlDbType.BigInt),
                new SqlParameter("@timelong", SqlDbType.VarChar,50),
                new SqlParameter("@donenum", SqlDbType.VarChar,50)};
            para[0].Value = userid;
            para[1].Value = taskid;
            para[2].Value = timelong;
            para[3].Value = donenum;

            return DbHelperSQL.RunProcedure(prop, para, out result);
        }

        /// <summary>
        /// 获取手机号数量
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public int GetPhoneNumber(string UserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) ct from tb_user");
            strSql.Append(" where PhoneNum=@PhoneNum ");
            SqlParameter[] parameters = {
                new SqlParameter("@PhoneNum", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = UserCode;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取身份证数量
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public int GetIDCodeNumber(string IdenCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) ct from tb_user");
            strSql.Append(" where IdenCode=@IdenCode ");
            SqlParameter[] parameters = {
                new SqlParameter("@IdenCode", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = IdenCode;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取手机号
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public string GetPhoneByAccount(string UserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PhoneNum from tb_user");
            strSql.Append(" where UserCode=@UserCode ");
            SqlParameter[] parameters = {
                new SqlParameter("@UserCode", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = UserCode;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取手机号
        /// </summary>
        /// <param name="UserCode"></param>
        /// <returns></returns>
        public string GetPhoneByUserID(long userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PhoneNum  from tb_user");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", SqlDbType.BigInt,8)
            };
            parameters[0].Value = userid;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 按小时生成释放币记录
        /// </summary>
        /// <param name="userid">用户</param>
        /// <returns></returns>
        public int flag_ReadyRand(long userid, int type )
        {
            int result;

            string prop = "proc_ReadyRand";
            SqlParameter[] para = { new SqlParameter("@UserID", SqlDbType.BigInt),
                new SqlParameter("@type", SqlDbType.Int,4)};
            para[0].Value = userid;
            para[1].Value = type;
            
            return DbHelperSQL.RunProcedure(prop, para, out result);
        }
    }
}
